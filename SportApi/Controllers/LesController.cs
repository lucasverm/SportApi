using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectG05.Models.Domain;
using SportApi.IRepos;

namespace SportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LesController : ControllerBase
    {

        ILes _repo;

        public LesController(ILes repo)
        {
            _repo = repo;
        }

        // GET: api/Les
        [HttpGet]
        public IEnumerable<Les> Get()
        {
            return _repo.GetAll();
        }

        // GET: api/Les/5
        [HttpGet("{id}")]
        public Les Get(int id)
        {
            return _repo.GetBy(id);
        }

        // POST: api/Les
        [HttpPost]
        public void Post(Les les)
        {
            _repo.Add(les);
        }

        // PUT: api/Les/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Les les = _repo.GetBy(id);
            _repo.Delete(les);
        }
    }
}
