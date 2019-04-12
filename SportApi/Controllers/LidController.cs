using Microsoft.AspNetCore.Mvc;
using ProjectG05.Models.Domain;
using SportApi.DTO_s;
using System.Collections.Generic;

namespace SportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LidController : ControllerBase
    {
        private IGebruiker _gebruikerRepository;

        public LidController(IGebruiker gebruikerRepository)
        {
            _gebruikerRepository = gebruikerRepository;
        }

        // GET: api/Leden
        [HttpGet]
        public IEnumerable<Gebruiker> GetLeden()
        {
            return _gebruikerRepository.GetAllLeden();
        }

        // POST: api/Lid
        [HttpPost]
        public void PostLid(LidDTO dto)
        {
            Lid lid = new Lid(dto.Voornaam, dto.Naam, dto.StraatNaam, dto.Huisnummer, dto.Postcode, dto.Stad, dto.TelefoonNummer, dto.Email, dto.Geboortedatum, dto.Nationaliteit, dto.EmailOuder, dto.RijksregisterNummer, dto.GeborenTe, dto.Geslacht, dto.InschrijvingsDatum, dto.Graad);
            _gebruikerRepository.Add(lid);
            _gebruikerRepository.SaveChanges();
        }

        // PUT: api/Gebruiker/5
        [HttpPut("{id}")]
        public void Put(int id, LidDTO dto)
        {
            Lid g = (Lid)_gebruikerRepository.GetBy(id);
            g.Voornaam = dto.Voornaam;
            g.Naam = dto.Naam;
            g.Straatnaam = dto.StraatNaam;
            g.Huisnummer = dto.Huisnummer;
            g.Postcode = dto.Postcode;
            g.Stad = dto.Stad;
            g.Telefoonnummer = dto.TelefoonNummer;
            g.Email = dto.Email;
            g.Geboortedatum = dto.Geboortedatum;
            g.Nationaleit = dto.Nationaliteit;
            g.EmailOuders = dto.EmailOuder;
            g.Rijksregisternummer = dto.RijksregisterNummer;
            g.GeborenTe = dto.GeborenTe;
            g.Geslacht = dto.Geslacht;
            g.InschrijvingsDatum = dto.InschrijvingsDatum;
            g.Graad = dto.Graad;
            _gebruikerRepository.Update(g);
            _gebruikerRepository.SaveChanges();
        }
    }
}