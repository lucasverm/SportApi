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
    public class VideoController : ControllerBase
    {
        private IVideo _videoRepository;
        private ILesmateriaal _lesmateriaalRepository;

        public VideoController(IVideo videoRepository, ILesmateriaal lesmateriaalRepository)
        {
            _videoRepository = videoRepository;
            _lesmateriaalRepository = lesmateriaalRepository;
        }

        // GET: api/Video
        [HttpGet]
        public IEnumerable<Video> GetAll()
        {
            return _videoRepository.GetAll();
        }

        // GET: api/Video/5
        [HttpGet("{id}")]
        public ActionResult<Video> GetBy(int id)
        {
            Video a = _videoRepository.GetBy(id);
            if (a == null) return NoContent();
            return a;
        }

        // POST: api/Video
        [HttpPost]
        public ActionResult<Video> Post(VideoDTO DTO)
        {
            try
            {
                if (_lesmateriaalRepository.GetBy(DTO.LesMateriaalId) == null)
                    return BadRequest("Het opgegeven lesmateriaal kon niet worden gevonden!");
                Video a = new Video(DTO.LesMateriaalId, DTO.Adres);
                _videoRepository.Add(a);
                _videoRepository.SaveChanges();
                return CreatedAtAction(nameof(GetBy), new { id = a.Id }, a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT: api/Video/5
        [HttpPut("{id}")]
        public ActionResult<Video> Put(int id, VideoDTO DTO)
        {
            try
            {
                Video a = _videoRepository.GetBy(id);
                if (a == null)
                {
                    return BadRequest("De video die u wenst te wijzigen bestaat niet");
                }
                Lesmateriaal lesMateriaal = _lesmateriaalRepository.GetBy(DTO.LesMateriaalId);
                if (lesMateriaal == null)
                {
                    return BadRequest("Het opgegeven lesmateriaal bestaat niet!");
                }
                a.LesmateriaalId = DTO.LesMateriaalId;
                a.Adres = DTO.Adres;
                _videoRepository.Update(a);
                _videoRepository.SaveChanges();
                return a;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Video> Delete(int id)
        {
            Video a = _videoRepository.GetBy(id);
            if (a == null) return BadRequest("Video die u wenst te verwijderen bestaat niet!");
            _videoRepository.Delete(a);
            _videoRepository.SaveChanges();
            return a;
        }
    }
}