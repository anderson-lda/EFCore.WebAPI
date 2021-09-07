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

    public class BatalhaController : ControllerBase
    {
        private readonly IEFCoreRepository _repo;
        public BatalhaController(IEFCoreRepository repo)
        {
            this._repo = repo;
        }

        //GET: api/Batalha
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var batalhas = await _repo.GetAllBatalhas();
                return Ok(batalhas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        //GET: api/Batalha/id
        [HttpGet("{id}", Name = "GetBatalha")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var batalha = await _repo.GetBatalhaById(id, true);
                return Ok(batalha);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        //POST: api/Heroi
        [HttpPost]
        public async Task<IActionResult> Post(Batalha model)
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

        //PUT: api/Batalha
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Batalha model)
        {
            try
            {
                var heroi = await _repo.GetBatalhaById(id);
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
                var batalha = await _repo.GetBatalhaById(id);
                if (batalha != null)
                {
                    {
                        _repo.Delete(batalha);
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