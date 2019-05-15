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
        public int GeefScoreBord()
        {
            int puntenVanGebruiker = 0;
            int aantalLessenVanGebruiker = 0;
            int puntenToevoegenBijAanwezigheid = 0;
            var gebruiker = (Lid)_gebruikerRepository.GetBy(1);
            if (gebruiker == null) return -1;

            _lesRepository.GetAll().ToList().ForEach(t =>
            {
                Debug.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                Debug.WriteLine("les: " + t);
                t.LedenVoorLes.ToList().ForEach(i =>
                {
                    Debug.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                    Debug.WriteLine("leden ingeschreven voor les:" + i.Naam);
                    if (i.Id == 1)
                    {
                        aantalLessenVanGebruiker += 1;
                    }
                });
            });
            Debug.WriteLine(aantalLessenVanGebruiker);
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
                Debug.WriteLine("----------------------------------------");
                Debug.WriteLine("De gebruiker bezit geen 1/2 lessen!!");
            }
            _gebruikerSessie.ToList().ForEach(t =>
            {
                if (t.Gebruiker.Id == gebruiker.Id)
                {
                    puntenVanGebruiker += puntenToevoegenBijAanwezigheid;
                }
            });

            Debug.WriteLine("---------------------------");
            Debug.WriteLine(gebruiker.Naam + " heeft " + puntenVanGebruiker);
            return puntenVanGebruiker;

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
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // UPDATE
        /*[HttpPut("{id}")]
        public ActionResult<Gebruiker> Update(int id)
        {
            try
            {
                Gebruiker g = _gebruikerRepository.GetBy(id);
                if (g == null) return BadRequest("Gebruiker kon niet worden gevonden");
                _gebruikerRepository.Update(g);
                _gebruikerRepository.SaveChanges();
                return g;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }*/
    }
}