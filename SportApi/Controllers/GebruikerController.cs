using System;
using System.Collections.Generic;
using System.Linq;
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

        IGebruiker _repo;

        public GebruikerController(IGebruiker repo)
        {
            _repo = repo;
        }

        // GET: api/Gebruiker
        [HttpGet]
        public IEnumerable<Gebruiker> Get()
        {
            return _repo.GetAll();
        }

        // GET: api/Gebruiker/5
        [HttpGet("{id}")]
        public Gebruiker Get(int id)
        {
            return _repo.GetBy(id);
        }

        // POST: api/Gebruiker
        [HttpPost]
        public void Post([FromBody] Gebruiker gebruiker)
        {
            _repo.Add(gebruiker);
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
            _repo.Delete(_repo.GetBy(id));
        }
    }
}
