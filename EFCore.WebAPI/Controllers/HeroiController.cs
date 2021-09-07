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
        private readonly IEFCoreRepository _repo;
        public HeroiController(IEFCoreRepository repo)
        {
            this._repo = repo;
        }

        //GET: api/Heroi
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var herois = await _repo.GetAllHerois();
                return Ok(herois);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        //GET: api/Heroi/id
        [HttpGet("{id}", Name = "GetHeroi")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var batalha = await _repo.GetHeroiById(id, true);
                return Ok(batalha);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        //POST: api/Heroi
        [HttpPost]
        public async Task<IActionResult> Post(Heroi model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangeAssync())
                {
                    return Ok("Salvo com sucesso");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não salvou");
        }

        //PUT: api/Heroi
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Heroi model)
        {
            try
            {
                var heroi = await _repo.GetHeroiById(id);
                if (heroi != null)
                {
                    {
                        _repo.Update(model);
                        if (await _repo.SaveChangeAssync())
                            return Ok("Atualizado com sucesso");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não salvou");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var heroi = await _repo.GetHeroiById(id);
                if (heroi != null)
                {
                    {
                        _repo.Delete(heroi);
                        if (await _repo.SaveChangeAssync())
                            return Ok("Deletado com sucesso");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não salvou");
        }
    }
}