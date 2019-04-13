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
    //[ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AfbeeldingController : ControllerBase
    {
        private IAfbeelding _afbeeldingRepository;
        private ILesmateriaal _lesmateriaalRepository;

        public AfbeeldingController(IAfbeelding afbeeldingRepository, ILesmateriaal lesmateriaalRepository)
        {
            _afbeeldingRepository = afbeeldingRepository;
            _lesmateriaalRepository = lesmateriaalRepository;
        }

        // GET: api/Afbeelding
        [HttpGet]
        public IEnumerable<Afbeelding> GetAll()
        {
            return _afbeeldingRepository.GetAll();
        }

        // GET: api/Afbeelding/5
        [HttpGet("{id}")]
        public ActionResult<Afbeelding> GetBy(int id)
        {
            Afbeelding a = _afbeeldingRepository.GetBy(id);
            if (a == null) return NoContent();
            return a;
        }

        // POST: api/Afbeelding
        [HttpPost]
        public ActionResult<Afbeelding> Post(AfbeeldingDTO DTO)
        {
            try
            {
                if (_lesmateriaalRepository.GetBy(DTO.LesMateriaalId) == null)
                    return BadRequest("Het opgegeven lesmateriaal kon niet worden gevonden!");
                Afbeelding a = new Afbeelding(DTO.LesMateriaalId, DTO.Adres);
                _afbeeldingRepository.Add(a);
                _afbeeldingRepository.SaveChanges();
                return CreatedAtAction(nameof(GetBy), new{ id = a.Id}, a);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // PUT: api/Afbeelding/5
        [HttpPut("{id}")]
        public ActionResult<Afbeelding> Put(int id, AfbeeldingDTO DTO)
        {
            try
            {
            Afbeelding a = _afbeeldingRepository.GetBy(id);
            if (a == null)
            {
                return BadRequest("De afbeelding die u wenst te wijzigen bestaat niet");
            }
                a.LesmateriaalId = DTO.LesMateriaalId;
                a.Adres = DTO.Adres;
                _afbeeldingRepository.Add(a);
                return a;
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Afbeelding> Delete(int id)
        {
            Afbeelding a = _afbeeldingRepository.GetBy(id);
            if (a == null) return BadRequest("Afbeelding die u wenst te verwijderen bestaat niet!");
            _afbeeldingRepository.Delete(a);
            _afbeeldingRepository.SaveChanges();
            return a;
        }
    }
}