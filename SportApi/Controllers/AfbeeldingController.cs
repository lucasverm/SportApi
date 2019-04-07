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
    public class AfbeeldingController : ControllerBase
    {

        IAfbeelding _repo;

        public AfbeeldingController(IAfbeelding repo)
        {
            _repo = repo;
        }



        // GET: api/Afbeelding
        [HttpGet]
        public IEnumerable<Afbeelding> Get()
        {
            return _repo.GetAll();
        }

        // GET: api/Afbeelding/5
        [HttpGet("{id}")]
        public List<Afbeelding> Get(int id)
        {
            return _repo.GetAlleAfbeeldingDieHorenBijEenSpecifiekLesmateriaal(id);
        }

        // POST: api/Afbeelding
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Afbeelding/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
