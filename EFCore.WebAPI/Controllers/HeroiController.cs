using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EFCore.Repo;
using EFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HeroiController: ControllerBase
    {
        private readonly HeroiContexto _context;
        public HeroiController(HeroiContexto context)
        {
            _context = context;
        }

        //GET: api/Heroi
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Heroi());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        //GET: api/Heroi/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        //POST: api/Heroi
        [HttpPost]
        public ActionResult Post(Heroi model)
        {
            try
            {   
                _context.Herois.Add(model);
                _context.SaveChanges();

                return Ok("BAZINGA");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        //PUT: api/Heroi
        [HttpPut("{id}")]
        public ActionResult Put(int id, Heroi model)
        {
            try
            {
                //if(_context.Herois.Find(id) != null)
                if(_context.Herois.AsNoTracking().FirstOrDefault(
                        h => h.Id == id
                    ) != null)
                {
                    _context.Herois.Update(model);
                    _context.SaveChanges();
                    return Ok("BAZINGA");
                }
                return Ok("Não encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }
    }
}