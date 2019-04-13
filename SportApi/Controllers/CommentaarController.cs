using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectG05.Models.Domain;
using SportApi.DTO_s;

namespace SportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CommentaarController : ControllerBase
    {

        ICommentaar _repo;
        IGebruiker _gebruikerRepository;
        ILesmateriaal _lesmateriaalRepository;

        public CommentaarController(ICommentaar rep, IGebruiker gebruikerRepo, ILesmateriaal lesmatRepo)
        {
            _repo = rep;
            _gebruikerRepository = gebruikerRepo;
            _lesmateriaalRepository = lesmatRepo;
        }

        // GET: api/Commentaar
        [HttpGet]
        public IEnumerable<Commentaar> GetAll()
        {
            return _repo.GetAll();
        }

        // GET: api/Repositories/5
        [HttpGet("{id}")]
        public ActionResult<Commentaar> GetBy(int id)
        {
            Commentaar c = _repo.GetBy(id);
            if (c == null) return NoContent();
            return c;
        }

        // POST: api/Repositories
        [HttpPost]
        public ActionResult<Commentaar> Post(CommentaarDTO DTO)
        {
            try
            {
                Lid l = (Lid) _gebruikerRepository.GetBy(DTO.LidId);
                if (l == null) return BadRequest("Het opgegeven lid bestaat niet!");
                Lesmateriaal lesmat = _lesmateriaalRepository.GetBy(DTO.LesmateriaalId);
                if (lesmat == null) return BadRequest("Het opgegeven lesmateriaal bestaat niet!");
                Commentaar c = new Commentaar(l, lesmat, DTO.Tekst);
                _repo.Add(c);
                _repo.SaveChanges();
                return CreatedAtAction(nameof(GetBy), new { id = c.Id }, c);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Repositories/5
        [HttpPut("{id}")]
        public ActionResult<Commentaar> Put(int id, CommentaarDTO DTO)
        {
            try
            {
                Lid l = (Lid) _gebruikerRepository.GetBy(DTO.LidId);
                if (l == null) return BadRequest("Het opgegeven lid bestaat niet!");
                Commentaar c = _repo.GetBy(id);
                if (c == null) return BadRequest("De Commentaar die u wenst te wijzigen bestaat nier");
                Lesmateriaal lesmat = _lesmateriaalRepository.GetBy(DTO.LesmateriaalId);
                if (lesmat == null) return BadRequest("Het opgegeven lesmateriaal bestaat niet!");
                c.Lid = l;
                c.Lesmateriaal = lesmat;
                    c.Tekst = DTO.Tekst;
                _repo.Update(c);
                _repo.SaveChanges();
                return CreatedAtAction(nameof(GetBy), new { id = c.Id }, c);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Commentaar> Delete(int id)
        {
            Commentaar c = _repo.GetBy(id);
            if (c == null) return BadRequest("de afbeelding die u wenst te verwijderen bestaat niet!");
            _repo.Delete(c);
            return c;
        }
    }
}
