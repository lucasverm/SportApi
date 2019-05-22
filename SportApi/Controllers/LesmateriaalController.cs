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
    public class LesmateriaalController : ControllerBase
    {

        ILesmateriaal _lesmateriaalRepository;

        public LesmateriaalController(ILesmateriaal repo)
        {
            _lesmateriaalRepository = repo;
        }



        // GET: api/Lesmateriaal
        [HttpGet]
        public IEnumerable<Lesmateriaal> GetAll()
        {
            return _lesmateriaalRepository.GetAll();
        }

        // GET: api/Lesmateriaal/5
        [HttpGet("{id}")]
        public ActionResult<Lesmateriaal> GetBy(int id)
        {
            Lesmateriaal l = _lesmateriaalRepository.GetBy(id);
            if (l == null)
                return NotFound("Het opgegeven lesmateriaal bestaat niet");
            return l;
        }

        // POST: api/Lesmateriaal
        [HttpPost]
        public IActionResult Post(LesmateriaalDTO DTO)
        {
            try
            {
                Lesmateriaal l = new Lesmateriaal(DTO.Graad, DTO.Naam, DTO.OefeningUitlegTekst,
                    DTO.Categorie, DTO.Afbeeldingen, DTO.Videos, DTO.Commentaren);
                if (DTO.Afbeeldingen == null)
                {
                    DTO.Afbeeldingen = new List<Afbeelding>();
                }
                if (DTO.Videos == null)
                {
                    DTO.Videos = new List<Video>();
                }
                if (DTO.Commentaren == null)
                {
                    DTO.Commentaren = new List<Commentaar>();
                }
                _lesmateriaalRepository.Add(l);
                _lesmateriaalRepository.SaveChanges();
                return CreatedAtAction(nameof(GetBy), new { id = l.Id }, l);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Lesmateriaal/5
        [HttpPut("{id}")]
        public ActionResult<Lesmateriaal> Put(int id, LesmateriaalDTO DTO)
        {
            try
            {
                Lesmateriaal l = _lesmateriaalRepository.GetBy(id);
                if (l == null)
                    return BadRequest("Het opgegeven lesmateriaal kon niet worden gevonden!");

               
                l.Graad = DTO.Graad;
                l.Naam = DTO.Naam;
                l.OefeningUitlegTekst = DTO.OefeningUitlegTekst;
                l.Categorie = DTO.Categorie;
                l.Afbeeldingen = DTO.Afbeeldingen;
                //if(DTO.Afbeeldingen != null)
                //foreach (Afbeelding afb in DTO.Afbeeldingen)
                //{
                //    afbeeldingRepository.Add(afb);
                //    afbeeldingRepository.SaveChanges();
                //}
                l.Videos = DTO.Videos;
                l.Commentaren = DTO.Commentaren;
                _lesmateriaalRepository.Update(l);
                _lesmateriaalRepository.SaveChanges();
                return CreatedAtAction(nameof(GetBy), new { id = l.Id }, l);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Lesmateriaal> Delete(int id)
        {
            Lesmateriaal l = _lesmateriaalRepository.GetBy(id);
            if(l == null)
                return BadRequest("Het opgegeven lesmateriaal kon niet worden gevonden!");
            _lesmateriaalRepository.Delete(l);
            return l;
        }
    }
}
