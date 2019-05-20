using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectG05.Models.Domain;
using System.Diagnostics;
using ProjectG05.Data;
using Microsoft.EntityFrameworkCore;
using SportApi.IRepos;

namespace SportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikerController : ControllerBase
    {
        private IGebruiker _gebruikerRepository;
        private ILes _lesRepository;
        private DbSet<GebruikerSessie> _gebruikerSessie;

        public GebruikerController(IGebruiker gebruikerRepository, ILes lesRepository, ApplicationDbContext context)
        {
            _gebruikerRepository = gebruikerRepository;
            _lesRepository = lesRepository;
            _gebruikerSessie = context.GebruikerSessie;
        }

        // GET: api/Gebruiker
        [HttpGet]
        public IEnumerable<Gebruiker> Get()
        {
            return _gebruikerRepository.GetAll();
        }

        [HttpGet("geefScore")]
        public ActionResult<List<Lid>> GeefScoreBord()
        {
            List<Lid> uitvoer = new List<Lid>();
            List<Lid> alleLeden = _gebruikerRepository.GetAllLeden().ToList();
            List<Les> alleLessen = _lesRepository.GetAll().ToList();
            alleLeden.ForEach(lid =>
            {
                int puntenVanGebruiker = 0;
                int aantalLessenVanGebruiker = 0;
                int puntenToevoegenBijAanwezigheid = 0;
                //if (Lid == null) return BadRequest("Er liep iets fout: er kon een lid niet worden gevonden!");


                alleLessen.ForEach(les =>
                {
                    les.LedenVoorLes.ToList().ForEach(i =>
                    {
                        if (i.Id == lid.Id)
                        {
                            aantalLessenVanGebruiker += 1;
                        }
                    });
                });
                if (aantalLessenVanGebruiker == 2)
                {
                    puntenToevoegenBijAanwezigheid = 5;
                }
                else if (aantalLessenVanGebruiker == 1)
                {
                    puntenToevoegenBijAanwezigheid = 10;
                }
                else
                {
                    puntenToevoegenBijAanwezigheid = 5;
                }
                _gebruikerSessie.ToList().ForEach(t =>
                {
                    if (t.Gebruiker.Id == lid.Id)
                    {
                        puntenVanGebruiker += puntenToevoegenBijAanwezigheid;
                    }
                });

                lid.PuntenScorebord = puntenVanGebruiker;
                uitvoer.Add(lid);
                
            });
            return uitvoer;

        }

        // GET: api/Gebruiker/5
        [HttpGet("{id}")]
        public ActionResult<Gebruiker> GetBy(int id)
        {
            Gebruiker g = _gebruikerRepository.GetBy(id);
            if (g == null) return NotFound("De gebruiker kon niet worden gevonden");
            return g;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Gebruiker> Delete(int id)
        {
            try
            {
                Gebruiker g = _gebruikerRepository.GetBy(id);
                if (g == null) return BadRequest("Gebruiker kon niet worden gevonden");
                _gebruikerRepository.Delete(g);
                _gebruikerRepository.SaveChanges();
                return g;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}