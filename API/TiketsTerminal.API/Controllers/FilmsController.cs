using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketsTerminal.API.DTOs;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.BusinessLogic.CustomeExceptions;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmService _filmService;
        private readonly IFilmViewingTimeService _filmViewingTimeService;
        private readonly AutoMapper.IMapper _mapper;

        public FilmsController(IFilmService filmService, IFilmViewingTimeService filmViewingTimeService, AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
            _filmService = filmService;
            _filmViewingTimeService = filmViewingTimeService;
        }

        [HttpGet("{id}")]
        public async Task<GetFilmResponse> Get(int id)
        {
            var film = new Film();
            var result = new GetFilmResponse();

            film = await _filmService.GetDeepByKeysAsync(id);
            if (film == null)
                throw new NotFoundDataException($"Film not found.");

            result = _mapper.Map<Film, GetFilmResponse>(film);

            result.viewingTimes = _mapper.Map<List<FilmViewingTime>, List<GetFilmViewingTimeLiteResponse>>(film.FilmViewingTimes.ToList());

            return result;
        }

        [HttpGet()]
        public async Task<List<GetFilmLiteResponse>> Get(string searchInput = "")
        {
            var films = await _filmService.GetFilmsWithSearchAsync(searchInput);

            return _mapper.Map<List<Film>, List<GetFilmLiteResponse>>(films.ToList());
        }

        [HttpGet("{id}/viewingTimes")]
        public async Task<List<GetFilmViewingTimeResponse>> GetViewingTimes(int id)
        {
            var list = await _filmViewingTimeService.GetByFilmAsync(id);

            return _mapper.Map<List<FilmViewingTime>, List<GetFilmViewingTimeResponse>>(list.ToList());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<AddFilmResponse> Add(AddFilmRequest film)
        {
            var _film = _mapper.Map<AddFilmRequest, Film>(film);
            await _filmService.SaveAsync(_film);

            return _mapper.Map<Film, AddFilmResponse>(_film);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<AddFilmResponse> Update(int id, AddFilmRequest item)
        {
           
            var _itemNew = _mapper.Map<AddFilmRequest, Film>(item);
            //_itemNew.ID = _item.ID;

            var result = await _filmService.UpdateAsync(_itemNew, id);

            return _mapper.Map<Film, AddFilmResponse>(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> Delete(int id)
        {
            await _filmService.Delete(id);
            return true;
        }

        [HttpDelete("hardDelete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> HardDelete(int id)
        {
            await _filmService.HardDelete(id);
            return true;
        }

    }
}
