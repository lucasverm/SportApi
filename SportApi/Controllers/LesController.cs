using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectG05.Models.Domain;
using SportApi.DTO_s;
using SportApi.IRepos;

namespace SportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LesController : ControllerBase
    {

        private ILes _lesRepository;
        private IGebruiker _gebruikerRepository;

        public LesController(ILes repo, IGebruiker gebruikerRepository)
        {
            _lesRepository = repo;
            _gebruikerRepository = gebruikerRepository;
        }

        // GET: api/Les
        [HttpGet]
        public IEnumerable<Les> Get()
        {
            return _lesRepository.GetAll();
        }

        // GET: api/Les/5
        [HttpGet("{id}")]
        public ActionResult<Les> GetBy(int id)
        {
            Les l = _lesRepository.GetBy(id);
            if (l == null) return NotFound("De les kon niet worden gevonden");
            return l;
        }

        // POST: api/Les
        [HttpPost]
        public ActionResult<Les> Post(LesDTO DTO)
        {
            try
            {
                Gebruiker lesgever = _gebruikerRepository.GetBy(DTO.LesgeverId);
                if (lesgever == null)
                {
                    return BadRequest("Lesgever kon niet worden gevonden");
                }
                if (!(lesgever is Lesgever || lesgever is Beheerder))
                    return BadRequest("Gelieve een lesgever op te geven");
                List<Lid> LedenVoorLes = new List<Lid>();
                Boolean LidNietGevonden = false;
                int LidNietGevondenId = 0;
                DTO.LedenIds.ForEach(LidId =>
                {
                    Gebruiker lid = _gebruikerRepository.GetBy(LidId);
                    if (lid == null)
                    {
                        LidNietGevonden = true;
                        LidNietGevondenId = LidId;
                    }

                    else
                    {
                        LedenVoorLes.Add((Lid)lid);
                    }
                        
                });
                if (LidNietGevonden)
                {
                    return BadRequest("Lid met id " + LidNietGevondenId + " kon niet worden gevonden!");
                }
                Les l = new Les(lesgever, DTO.StartUur, DTO.Duur, DTO.Weekdag, LedenVoorLes);
                _lesRepository.Add(l);
                _lesRepository.SaveChanges();
                return l;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Les/5
        [HttpPut("{id}")]
        public ActionResult<Les> Put(int id, LesDTO DTO)
        {
            try
            {
                Les l = _lesRepository.GetBy(id);
                if (l == null) return BadRequest("Les kon niet worden gevonden");
                Gebruiker lesgever = _gebruikerRepository.GetBy(DTO.LesgeverId);
                if (lesgever == null)
                {
                    return BadRequest("Lesgever kon niet worden gevonden");
                }
                if (!(lesgever is Lesgever || lesgever is Beheerder))
                    return BadRequest("Gelieve een lesgever op te geven");
                List<Lid> LedenVoorLes = new List<Lid>();
                Boolean LidNietGevonden = false;
                int LidNietGevondenId = 0;
                DTO.LedenIds.ForEach(LidId =>
                {
                    Gebruiker lid = _gebruikerRepository.GetBy(LidId);
                    if (lid == null)
                    {
                        LidNietGevonden = true;
                        LidNietGevondenId = LidId;
                    }

                    else
                    {
                        LedenVoorLes.Add((Lid)lid);
                    }

                });
                if (LidNietGevonden)
                {
                    return BadRequest("Lid met id " + LidNietGevondenId + " kon niet worden gevonden!");
                }

                l.Lesgever = lesgever;
                l.StartUur = DTO.StartUur;
                l.Duur = DTO.Duur;
                l.Weekdag = DTO.Weekdag;
                l.LedenVoorLes = LedenVoorLes;
                _lesRepository.Update(l);
                _lesRepository.SaveChanges();
                return CreatedAtAction(nameof(GetBy), new { id = l.Id }, l);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Les> Delete(int id)
        {
            Les les = _lesRepository.GetBy(id);
            if (les == null) return BadRequest("Les kon niet worden gevonden!");
            _lesRepository.Delete(les);
            return les;
        }
    }
}
