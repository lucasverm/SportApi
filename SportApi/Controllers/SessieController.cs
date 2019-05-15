using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectG05.Models.Domain;
using SportApi.DTO_s;

namespace SportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessieController : ControllerBase
    {


        ISessie _sessieRepository;
        IGebruiker _gebruikerRepository;

        public SessieController(ISessie repo, IGebruiker gebruikerRepository)
        {
            _sessieRepository = repo;
            _gebruikerRepository = gebruikerRepository;
        }

        // GET: api/Sessie
        [HttpGet]
        public IEnumerable<Sessie> Get()
        {
            return _sessieRepository.GetAll();
        }

        // GET: api/Sessie/5
        [HttpGet("{id}")]
        public ActionResult<Sessie> GetBy(int id)
        {
            Sessie s = _sessieRepository.GetBy(id);
            if (s == null) return NotFound("Sessie kon niet worden gevonden");
            return s;
        }

        // POST: api/Sessie
        [HttpPost]
        public ActionResult<Sessie> Post(SessieDTO DTO)
        {
            try
            {
                Lesgever lesgever = (Lesgever)_gebruikerRepository.GetBy(DTO.LesgeverId);
                if (lesgever == null)
                    return BadRequest("De lesgever bestaat niet");
                List<Lid> ledenVoorLes = new List<Lid>();
                List<Gebruiker> Aanwezigen = new List<Gebruiker>();
                if (DTO.LedenVoorLes == null)
                {
                    DTO.LedenVoorLes = new List<int>();
                }
                DTO.LedenVoorLes.ForEach(t =>
                {
                    var gebruiker = (Lid) _gebruikerRepository.GetBy(t);
                    ledenVoorLes.Add(gebruiker);
                });
                if (DTO.Aanwezigen == null)
                {
                    DTO.Aanwezigen = new List<int>();
                }
                DTO.Aanwezigen.ForEach(t =>
                {
                    var gebruiker = (Gebruiker)_gebruikerRepository.GetBy(t);
                    Aanwezigen.Add(gebruiker);
                });
                Sessie sessie = new Sessie(lesgever, DTO.Datum, DTO.Duur, DTO.StartUur, DTO.Weekdag, ledenVoorLes);
                sessie.Aanwezigen = Aanwezigen;
                _sessieRepository.Add(sessie);
                _sessieRepository.SaveChanges();
                return CreatedAtAction(nameof(GetBy), new { id = sessie.Id }, sessie);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Sessie/5
        [HttpPut("{id}")]
        public ActionResult<Sessie> Put(int id, SessieDTO DTO)
        {
            try
            {
                Sessie sessie = _sessieRepository.GetBy(id);
                if (sessie == null)
                    return BadRequest("De sessie kon niet worden gevonden");
                Lesgever lesgever = (Lesgever)_gebruikerRepository.GetBy(DTO.LesgeverId);
                if (lesgever == null)
                    return BadRequest("De lesgever bestaat niet");
                sessie.Lesgever = lesgever;
                sessie.Datum = DTO.Datum;
                sessie.Duur = DTO.Duur;
                sessie.StartUur = DTO.StartUur;
                sessie.Weekdag = DTO.Weekdag;
                List<Lid> ledenVoorLes = new List<Lid>();
                DTO.LedenVoorLes.ForEach(t =>
                {
                    var gebruiker = (Lid)_gebruikerRepository.GetBy(t);
                    ledenVoorLes.Add(gebruiker);
                });
                sessie.LedenVoorLes = ledenVoorLes;
                _sessieRepository.Update(sessie);
                return sessie;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Sessie> Delete(int id)
        {
            Sessie s = _sessieRepository.GetBy(id);
            if (s == null) return BadRequest("De opgegeven sessie kon niet worden gevonden");
            _sessieRepository.Delete(s);
            return s;
        }
    }
}
