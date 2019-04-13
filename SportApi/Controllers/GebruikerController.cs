using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectG05.Models.Domain;

namespace SportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikerController : ControllerBase
    {
        private IGebruiker _gebruikerRepository;

        public GebruikerController(IGebruiker gebruikerRepository)
        {
            _gebruikerRepository = gebruikerRepository;
        }

        // GET: api/Gebruiker
        [HttpGet]
        public IEnumerable<Gebruiker> Get()
        {
            return _gebruikerRepository.GetAll();
        }

        // GET: api/Gebruiker/5
        [HttpGet("{id}")]
        public ActionResult<Gebruiker> Get(int id)
        {
            Gebruiker g = _gebruikerRepository.GetBy(id);
            if (g == null) return BadRequest("De gebruiker bestaat niet");
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
                return BadRequest("e.message");
            }
            
        }
    }
}