using Microsoft.AspNetCore.Mvc;
using ProjectG05.Models.Domain;
using SportApi.DTO_s;
using System;
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
        public IEnumerable<Gebruiker> GetAll()
        {
            return _gebruikerRepository.GetAllLeden();
        }

        // POST: api/Lid
        [HttpPost]
        public ActionResult<Gebruiker> PostLid(LidDTO dto)
        {
            try
            {
                Gebruiker lid = new Lid(dto.Voornaam, dto.Naam, dto.StraatNaam, dto.Huisnummer, dto.Postcode,
                    dto.Stad, dto.TelefoonNummer, dto.Email, dto.Geboortedatum, dto.Nationaliteit,
                    dto.EmailOuder, dto.RijksregisterNummer, dto.GeborenTe, dto.Geslacht,
                    dto.InschrijvingsDatum, dto.Graad);
                _gebruikerRepository.Add(lid);
                _gebruikerRepository.SaveChanges();
                return lid;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Gebruiker/5
        [HttpPut("{id}")]
        public ActionResult<Gebruiker> Put(int id, LidDTO dto)
        {
            try
            {
                Lid g = (Lid)_gebruikerRepository.GetBy(id);
                if (g == null) throw new Exception("Gebruiker kon niet worden gevonden!");
                if (!(g is Lid)) ;
                return BadRequest("De opgegeven gebruiker is geen lesgever");
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
                return g;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}