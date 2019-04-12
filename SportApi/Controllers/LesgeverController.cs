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
        public IEnumerable<Gebruiker> Get()
        {
            return _gebruikerRepository.GetAllLesgevers();
        }

        // POST: api/Gebruiker
        [HttpPost]
        public void Post(LesgeverDTO dto)
        {
            Gebruiker g = new Lesgever(dto.Voornaam, dto.Naam, dto.StraatNaam, dto.Huisnummer, dto.Postcode, dto.Stad, dto.TelefoonNummer, dto.Email, dto.Geboortedatum, dto.Geslacht);
            _gebruikerRepository.Add(g);
            _gebruikerRepository.SaveChanges();
        }

        // PUT: api/Gebruiker/5
        [HttpPut("{id}")]
        public void Put(int id, LesgeverDTO dto)
        {
            Gebruiker g = _gebruikerRepository.GetBy(id);
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
        }
    }
}