﻿using ARINLAB.Services.ImageService;
using ARINLAB.Services.SessionService;
using AutoMapper;
using DAL.Data;
using DAL.Models;
using DAL.Models.Dto.NamesDTO;
using DAL.Models.ResponceModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARINLAB.Services
{
    public class NamesService : INamesService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        private readonly IDictionaryService _dictionaryService;
        private readonly UserDictionary _userDict;

        public NamesService(ApplicationDbContext applicationDb, IImageService imageService, 
                            IMapper mapper, IDictionaryService dict, UserDictionary userDictionary)
        {
            _dbContext = applicationDb;
            _imageService = imageService;
            _mapper = mapper;
            _dictionaryService = dict;
            _userDict = userDictionary;
        }

        public async Task<Responce> ApproveImage(int image_id, bool approve)
        {
            var res = await _dbContext.NameImages.FindAsync(image_id);
            if(res != null)
            {
                res.IsApproved = approve;
                _dbContext.NameImages.Update(res);
                await _dbContext.SaveChangesAsync();
                return ResponceGenerator.GetResponceModel(true,"", res);
            }
            return ResponceGenerator.GetResponceModel(false);
        }

        public async Task<Responce> CreateImageforNameAsync(CreateNameImagesDto image)
        {
            NameImages model = new();            
            try
            {
                if(image != null)
                {
                    model.NamesId = image.NamesId;
                    model.UserId = image.UserId;
                    model.IsApproved = true;
                    if (image.ImageUri != null)
                    {
                        model.ImageUri = await _imageService._UploadImage(image.ImageUri, "Names");
                        _dbContext.NameImages.Add(model);
                        _dbContext.SaveChanges();
                        return ResponceGenerator.GetResponceModel(true, "Success", model);
                    }
                }                
            }
            catch(Exception e)
            {
                return ResponceGenerator.GetResponceModel(false, e.Message, image);
            }
            return ResponceGenerator.GetResponceModel(false, "Image is not set", image);
        }

        public async Task<Responce> CreateNameAsync(CreateNamesDto name)
        {
            try {
                var res = _mapper.Map<Names>(name);
                _dbContext.Names.Add(res);
                await _dbContext.SaveChangesAsync();
                return ResponceGenerator.GetResponceModel(true, "Success", name);
            }
            catch(Exception e)
            {
                return ResponceGenerator.GetResponceModel(false, e.Message, name);
            }
        }

        public async Task<Responce> DeleteImageforNameAsync(int id)
        {
            var res = await _dbContext.NameImages.FindAsync(id);
            if (res != null)
            {
                _imageService._DeleteImage(res.ImageUri, "Names");
                _dbContext.NameImages.Remove(res);
                await _dbContext.SaveChangesAsync();
                return ResponceGenerator.GetResponceModel(false, "", res);
            }
            return ResponceGenerator.GetResponceModel(false, $"Does not found the image for word with id={id}", null);
        }

        public async Task<Responce> DeleteNameAsync(int id)
        {
            try
            {
                var res = await _dbContext.Names.FindAsync(id);
                if (res != null)
                { 
                    var images = _dbContext.NameImages.Where(p => p.NamesId == id);
                    _dbContext.Names.Remove(res);
                    await _dbContext.SaveChangesAsync();
                    foreach (var image in images)
                    {
                        _imageService._DeleteImage(image.ImageUri, "Names");
                        _dbContext.NameImages.Remove(image);                        
                    }
                    await _dbContext.SaveChangesAsync();
                    return ResponceGenerator.GetResponceModel(true, "Success", res);
                }
            }catch(Exception e)
            {
                return ResponceGenerator.GetResponceModel(false, e.Message, null);
            }
            return ResponceGenerator.GetResponceModel(false, $"Failed to find Name with id={id}", null);
        }
        public async Task<Responce> EditNameAsync(NamesDto name)
        {
            try
            {
                name.NameImages = null;
                var result = await _dbContext.Names.FindAsync(name.Id);
                if (result != null)
                {
                    result.ArabName = name.ArabName;
                    result.DictionaryId = name.DictionaryId;
                    result.IsApproved = name.IsApproved;
                    result.UserId = name.UserId;
                    result.ImageForShare = name.ImageForShare;
                    result.OtherName = name.OtherName;
                    _dbContext.Update(result);
                    _dbContext.SaveChanges();
                    return ResponceGenerator.GetResponceModel(true, "", result);
                }
                return ResponceGenerator.GetResponceModel(false, "", null);
            }
            catch(Exception e)
            {
                return ResponceGenerator.GetResponceModel(false, e.Message, null);
            }
        }

        public List<NamesDto> GetAllNames()
        {
            try
            {
                var res = _mapper.Map<List<NamesDto>>(_dbContext.Names);
                var dicts = new List<Dictionary>((IEnumerable<Dictionary>)_dictionaryService.GetAllDictionaries().Data);
                foreach (var name in res)
                {
                    name.DictionaryName = dicts.SingleOrDefault(p => p.Id == name.DictionaryId)?.Language;
                }
                return res;
            }catch(Exception e)
            {
                return null;
            }
        }
        public List<NamesDto> GetAllNames(string userId)
        {
            try
            {
                var res = _mapper.Map<List<NamesDto>>(_dbContext.Names.Where(p => p.UserId == userId));
                var dicts = new List<Dictionary>((IEnumerable<Dictionary>)_dictionaryService.GetAllDictionaries().Data);
                foreach (var name in res)
                {
                    name.DictionaryName = dicts.SingleOrDefault(p => p.Id == name.DictionaryId)?.Language;
                }
                return res;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<NameImagesDto> GetAllNamesImagesByNameId(int id)
        {
            try
            {
                return _mapper.Map<List<NameImagesDto>>(_dbContext.NameImages.Where(p => p.NamesId == id));
            }catch(Exception e)
            {
                return null;
            }
            
        }

        public List<NamesDto> GetAllNamesWithDictId(int id)
        {
            try
            {
                var res = _dbContext.Names.Where(p => p.DictionaryId == id && p.IsApproved == true);
                return _mapper.Map<List<NamesDto>>(res);
            }catch(Exception e)
            {
                return new List<NamesDto>();
            }
        }

        public async Task<NamesDto> GetNameByIdAsync(int id)
        {
            try
            {
                var res = await _dbContext.Names.FindAsync(id);
                if (res != null)
                {
                    var data = _mapper.Map<NamesDto>(res);
                    data.DictionaryName = _dictionaryService.GetDictionaryNameById(data.DictionaryId);
                    return data;
                }
            }catch(Exception e)
            {
                return null;
            }
            return null;
        }

        public async Task<NamesDto> GetNameByIdAsync(string userId, int id)
        {
            try
            {
                var res = await _dbContext.Names.FindAsync(id);                
                if (res != null)
                {
                    if (res.UserId != userId)
                        return null;
                    var data = _mapper.Map<NamesDto>(res);
                    data.DictionaryName = _dictionaryService.GetDictionaryNameById(data.DictionaryId);
                    return data;
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        public async Task<NameImagesDto> GetNameImageByImageIdAsync(int id)
        {
            try
            {
                var res = await _dbContext.NameImages.FindAsync(id);
                if(res != null)
                {
                    return _mapper.Map<NameImagesDto>(res);
                }
            }catch(Exception e)
            {
                return null;
            }
            return null;
        }

        public List<NamesDto> GetRandom_N_Names(int n)
        {
            try
            {
                var dictId = _userDict.GetDictionaryId();
                Random rnd = new Random(DateTime.UtcNow.Millisecond);
                int rn = rnd.Next();
                var res = _dbContext.Names.Where(p => p.DictionaryId == dictId && p.IsApproved == true).Take(n).ToList();
                _dictionaryService.Shuffle(res);
                if (res != null)
                {                   
                    var r = _mapper.Map<List<NamesDto>>(res);
                    //foreach(var item in r)
                    //{
                    //    item.DictionaryName = _dbContext.Dictionaries.FirstOrDefault(p => p.Id == item.DictionaryId)?.Language;
                    //}
                    return r;
                }
                else
                {
                    return null;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public async Task<Responce> SetNameImageForShare(int nameId, string ImageLocation)
        {
            try
            {
                var res = await _dbContext.Names.FindAsync(nameId);
                if (res != null && string.IsNullOrEmpty(res.ImageForShare))
                {
                    res.ImageForShare = ImageLocation;
                    _dbContext.Names.Update(res);
                    await _dbContext.SaveChangesAsync();
                    return ResponceGenerator.GetResponceModel(true, "", res);
                }
            }catch(Exception e)
            {

            }
            return ResponceGenerator.GetResponceModel(false, "Unknown eror", null);

        }
    }
}
