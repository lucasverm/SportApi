using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectG05.Models.Domain;

namespace SportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CommentaarController : ControllerBase
    {

        ICommentaar _repo;

        public CommentaarController(ICommentaar rep)
        {
            this._repo = rep;
        }

        // GET: api/Commentaar
        [HttpGet]
        public IEnumerable<Commentaar> Get()
        {
            return _repo.GetAll();
        }

        // GET: api/Repositories/5
        [HttpGet("{id}")]
        public IEnumerable<Commentaar> Get(int id)
        {
            return _repo.GetById(id);
        }

        // POST: api/Repositories
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Repositories/5
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
