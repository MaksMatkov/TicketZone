using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TiketsTerminal.Bll.Interfaces;
using TiketsTerminal.BLL.Interfaces;
using TiketsTerminal.BLL.ViewModels;
using TiketsTerminal.DAL.Infrastructure;
using TiketsTerminal.Domain.Interfaces;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService FilmService;
        private readonly AutoMapper.IMapper mapper;

        public FilmController(IFilmService _FilmService, AutoMapper.IMapper _mapper)
        {
            mapper = _mapper;
            FilmService = _FilmService;
        }

        [HttpGet]
        public ActionResult<List<FilmViewModel>> Get()
        {
            var data = new List<FilmViewModel>();

            try
            {
                var users = FilmService.GetAll();
                if(users != null)
                {
                    data = mapper.Map<List<FilmViewModel>>(users);
                }
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<FilmViewModel> Get(int id)
        {
            try
            {
                return Ok(FilmService.Get(id));
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<FilmViewModel> Post(FilmViewModel item)
        {
            try
            {
                FilmService.Save(item);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        [Route("SetViewingTime")]
        public ActionResult SetViewingTime(ViewingTimeModel model)
        {
            try
            {
                FilmService.SetViewingTime(model);
            }
            catch
            {

            }

            return Ok();
        }


    }
}
