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

        // GET: api/Gebruiker/5
        [HttpGet("{id}")]
        public Gebruiker Get(int id)
        {
            return _gebruikerRepository.GetBy(id);
        }

        // POST: api/Gebruiker
        [HttpPost]
        public void Post(LesgeverDTO dto)
        {
            Gebruiker g = new Lesgever(dto.Voornaam, dto.Naam, dto.StraatNaam, dto.Huisnummer, dto.Postcode, dto.Stad, dto.TelefoonNummer, dto.Email, dto.Geboortedatum, dto.Geslacht);
            _gebruikerRepository.Add(g);
        }

        // PUT: api/Gebruiker/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _gebruikerRepository.Delete(_gebruikerRepository.GetBy(id));
        }
    }
}