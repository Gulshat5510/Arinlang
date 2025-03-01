﻿using ARINLAB.Models;
using ARINLAB.Services;
using ARINLAB.Services.Email;
using ARINLAB.Services.News;
using ARINLAB.Services.SessionService;
using ARINLAB.Services.Settings;
using ARINLAB.Services.Statistic;
using ARINLAB.Services.Subscribe;
using DAL.Models;
using DAL.Models.Dto.EmailsModelDTO;
using DAL.Models.Dto.NewsModelDTO;
using DAL.Models.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ARINLAB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStatisticsService _statService;
        private readonly UserDictionary _userDict;
        private readonly IDictionaryService _dictService;
        private readonly IWordServices _wordServices;
        private readonly INewsService _newsService;
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly ISubscribeService _subscriberService;
        private readonly ISettingsService _settings;
        private readonly IEmailService _emailService;
        public HomeController(ILogger<HomeController> logger, IStatisticsService statisticsService, 
                              UserDictionary userDictionary, IDictionaryService dictionaryService,
                              IWordServices wordServices, INewsService newsService, IStringLocalizer<SharedResource> localizer,
                              ISettingsService settingsService, ISubscribeService subscribeService, IEmailService emailService)
        {
            _logger = logger;
            _statService = statisticsService;
            _userDict = userDictionary;
            _dictService = dictionaryService;
            _wordServices = wordServices;
            _newsService = newsService;
            _localizer = localizer;
            _settings = settingsService;
            _subscriberService = subscribeService;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            var dicts = _dictService.GetAllDictionaries();
            ViewBag.Dictionaries = dicts;
            HomeViewModel model = new HomeViewModel() { StatistiCards = _statService.GetStatisticsCard() };
            ViewBag.News = (List<NewsDTO>)(_newsService.GetFourPublishNews().ToList());

            return View(model);
        }

        public IActionResult SetDictionary(int dictId)
        {
            _userDict.SetDictionary(dictId);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult SetLanguage(string culture, string returnUrl, string value)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect($"{returnUrl}{value}");
        }

        public ActionResult Unsubscribe()
        {
            return View();
        }

        public async Task<IActionResult> Unsubscribed(string email)
        {
            List<Settings> settings = new List<Settings>(_settings.GetAllSettings());

            string UnsubLink = settings.Find(x => x.Name == "UnsubLink").Value;
            string AdminEmail = settings.Find(x => x.Name == "AdminEmail").Value;
            string AdminEmailPassword = settings.Find(x => x.Name == "AdminEmailPassword").Value;
            string id = _subscriberService.GetEmail(email);
            if (id.Length > 0)
            {
                SingleEmailDTO sEmail = new SingleEmailDTO();
                sEmail.Header = _localizer["TSTB Unsubscribe"];
                sEmail.Message = _localizer["Please Follow the link below to unsubscribe from ARINLANG: "] + UnsubLink + "?id=" + id;
                sEmail.Password = AdminEmailPassword;
                sEmail.AdminEmail = AdminEmail;
                sEmail.EmailTo = email;
                sEmail.Subject = _localizer["Unsubscribe Link from ARINLANG Web Site"];
                bool isSend =  _emailService.SendSingleEmail(sEmail);
                if (isSend)
                    ViewBag.Email = _localizer["Dateiled instructions was send to "] + email + _localizer[" email to unsubscribed."];
                else
                    ViewBag.Email = _localizer["Some thing went wrong, Please try again later !"];
            }
            else
            {
                ViewBag.Email = email + _localizer[" email does not subscribed"];
            }
            return View();
            //return View(email + "does not subscribes");
        }
        public IActionResult UnsubLink(string id)
        {
            _subscriberService.DeleteSubscriber(id);
            ViewBag.UnSub = _localizer["You have succeffully unsubscribed"];
            return View();
        }

        public async Task<ActionResult> Subscribe(string email)
        {
            Subscribers sub = new Subscribers();
            sub.Email = email;
            sub.Id = Guid.NewGuid().ToString();
            bool isSub = await _subscriberService.AddSubscriber(sub);
            if (isSub)
                ViewBag.Sub = email + " " + _localizer["Email successfully subscribed"];
            else
                ViewBag.Sub = email + " " + _localizer["Email is already subscribed ! "];
            return View();
        }
       
    }
}
