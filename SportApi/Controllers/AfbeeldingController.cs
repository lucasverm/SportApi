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
    public class AfbeeldingController : ControllerBase
    {
        private IAfbeelding _afbeeldingRepository;

        public AfbeeldingController(IAfbeelding afbeeldingRepository)
        {
            _afbeeldingRepository = afbeeldingRepository;
        }

        // GET: api/Afbeelding
        [HttpGet]
        public IEnumerable<Afbeelding> Get()
        {
            return _afbeeldingRepository.GetAll();
        }

        // GET: api/Afbeelding/5
        [HttpGet("{id}")]
        public List<Afbeelding> Get(int id)
        {
            return _afbeeldingRepository.GetAlleAfbeeldingDieHorenBijEenSpecifiekLesmateriaal(id);
        }

        // POST: api/Afbeelding
        [HttpPost]
        public void Post(AfbeeldingDTO DTO)
        {
            Afbeelding a = new Afbeelding(DTO.LesMateriaalId, DTO.Adres);
            _afbeeldingRepository.Add(a);
            _afbeeldingRepository.SaveChanges();
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
            throw new Exception("Not implemented yet");
        }
    }
}