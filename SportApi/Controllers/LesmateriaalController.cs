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
    public class LesmateriaalController : ControllerBase
    {

        ILesmateriaal _repo;

        public LesmateriaalController(ILesmateriaal repo)
        {
            _repo = repo;
        }



        // GET: api/Lesmateriaal
        [HttpGet]
        public IEnumerable<Lesmateriaal> Get()
        {
            return _repo.GetAll();
        }

        // GET: api/Lesmateriaal/5
        [HttpGet("{id}")]
        public Lesmateriaal Get(int id)
        {
            return _repo.GetById(id);
        }

        // POST: api/Lesmateriaal
        [HttpPost]
        public void Post([FromBody] Lesmateriaal lesm)
        {
            _repo.Add(lesm);
        }

        // PUT: api/Lesmateriaal/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Add(_repo.GetById(id));
        }
    }
}
