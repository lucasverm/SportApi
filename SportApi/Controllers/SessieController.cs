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
    public class SessieController : ControllerBase
    {


        ISessie _repo;

        public SessieController(ISessie repo)
        {
            _repo = repo;
        }

        // GET: api/Sessie
        [HttpGet]
        public IEnumerable<Sessie> Get()
        {
            return _repo.GetAll();
        }

        // GET: api/Sessie/5
        [HttpGet("{id}")]
        public Sessie Get(int id)
        {
            return _repo.GetBy(id);
        }

        // POST: api/Sessie
        [HttpPost]
        public void Post(Sessie sessie)
        {
            _repo.Add(sessie);
        }

        // PUT: api/Sessie/5
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
