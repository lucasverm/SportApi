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
    public class LesgeverController : ControllerBase
    {
        private IGebruiker _gebruikerRepository;

        public LesgeverController(IGebruiker gebruikerRepository)
        {
            _gebruikerRepository = gebruikerRepository;
        }

        // GET: api/Gebruiker
        [HttpGet]
        public IEnumerable<Gebruiker> GetAll()
        {
            return _gebruikerRepository.GetAllLesgevers();
        }

        // POST: api/Gebruiker
        [HttpPost]
        public ActionResult<Gebruiker> Post(LesgeverDTO dto)
        {
            try
            {
                Gebruiker g = new Lesgever(dto.Voornaam, dto.Naam, dto.StraatNaam, dto.Huisnummer,
                dto.Postcode, dto.Stad, dto.TelefoonNummer, dto.Email, dto.Geboortedatum, dto.Geslacht);
                _gebruikerRepository.Add(g);
                _gebruikerRepository.SaveChanges();
                return CreatedAtAction(nameof(GebruikerController.GetBy), new { id = g.Id }, g);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // PUT: api/Gebruiker/5
        [HttpPut("{id}")]
        public ActionResult<Gebruiker> Put(int id, LesgeverDTO dto)
        {
            try
            {
                Gebruiker g = _gebruikerRepository.GetBy(id);
                if (g == null) return BadRequest("De gebruiker kon niet worden gevonden!");
                g.Voornaam = dto.Voornaam;
                g.Naam = dto.Naam;
                g.Straatnaam = dto.StraatNaam;
                g.Huisnummer = dto.Huisnummer;
                g.Postcode = dto.Postcode;
                g.Stad = dto.Stad;
                g.Telefoonnummer = dto.TelefoonNummer;
                g.Email = dto.Email;
                g.Geboortedatum = dto.Geboortedatum;
                g.Geslacht = dto.Geslacht;
                _gebruikerRepository.Update(g);
                _gebruikerRepository.SaveChanges();
                return g;
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }
    }
}