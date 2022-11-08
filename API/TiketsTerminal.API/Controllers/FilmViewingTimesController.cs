using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketsTerminal.API.DTOs;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmViewingTimesController : ControllerBase
    {
        private readonly IFilmViewingTimeService _filmViewingTimeService;
        private readonly AutoMapper.IMapper _mapper;

        public FilmViewingTimesController(IFilmViewingTimeService filmViewingTimeService, AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
            _filmViewingTimeService = filmViewingTimeService;
        }

        [HttpGet]
        public async Task<List<GetFilmViewingTimeLiteResponse>> Get()
        {
            var list = await _filmViewingTimeService.GetAsync();

            return _mapper.Map<List<FilmViewingTime>, List<GetFilmViewingTimeLiteResponse>>(list.ToList());
        }

        [HttpGet("{id}")]
        public async Task<GetFilmViewingTimeResponse> Get(int id)
        {
            var time = await _filmViewingTimeService.GetDeepDataAsync(id);
            return _mapper.Map<FilmViewingTime, GetFilmViewingTimeResponse>(time);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<AddFilmViewingTimeResponse> Post(AddFilmViewingTimeRequest item)
        {
            var viewTime = _mapper.Map<AddFilmViewingTimeRequest, FilmViewingTime>(item);

            await _filmViewingTimeService.SaveAsync(viewTime);

            return _mapper.Map<FilmViewingTime, AddFilmViewingTimeResponse>(viewTime);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<AddFilmViewingTimeResponse> Update(int id, AddFilmViewingTimeRequest item)
        {
            var _itemNew = _mapper.Map<AddFilmViewingTimeRequest, FilmViewingTime>(item);

            await _filmViewingTimeService.UpdateAsync(_itemNew, id);

            return _mapper.Map<FilmViewingTime, AddFilmViewingTimeResponse>(_itemNew);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> Delete(int id)
        {
            await _filmViewingTimeService.Delete(id);
            return true;
        }
    }
}
