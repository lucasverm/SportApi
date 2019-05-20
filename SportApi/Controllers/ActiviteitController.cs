using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectG05.Models.Domain;
using SportApi.DTO_s;
using SportApi.IRepos;

namespace SportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiviteitController : ControllerBase
    {

        private IActiviteit _activiteitRepository;
        private IGebruiker _gebruikerRepository;

        public ActiviteitController(IActiviteit repo, IGebruiker gebruikerRepository)
        {
            _activiteitRepository = repo;
            _gebruikerRepository = gebruikerRepository;
        }

        // GET: api/Activiteit
        [HttpGet]
        public IEnumerable<Activiteit> Get()
        {
            return _activiteitRepository.GetAll();
        }

        // GET: api/Activiteit/5
        [HttpGet("{id}")]
        public ActionResult<Activiteit> GetBy(int id)
        {
            Activiteit l = _activiteitRepository.GetBy(id);
            if (l == null) return NotFound("De activiteit kon niet worden gevonden");
            return l;
        }

        // POST: api/Activiteit
        [HttpPost]
        public ActionResult<Activiteit> Post(ActiviteitDTO DTO)
        {
            try
            {
                List<Gebruiker> gebruikers = new List<Gebruiker>();
                Boolean GebruikerNietGevonden = false;
                int GebruikerNietGevondenId = 0;
                //DTO.GebruikerIds.ForEach(GebruikerId =>
                //{
                //    Gebruiker gebruiker = _gebruikerRepository.GetBy(GebruikerId);
                //    if (gebruiker == null)
                //    {
                //        GebruikerNietGevonden = true;
                //        GebruikerNietGevondenId = GebruikerId;
                //    }

                //    else
                //    {
                //        GebruikersVoorActiviteit.Add((Gebruiker)gebruiker);
                //    }
                        
                //});
                //if (GebruikerNietGevonden)
                //{
                //    return BadRequest("Gebruiker met id " + GebruikerNietGevondenId + " kon niet worden gevonden!");
                //}
                if(DTO.GebruikersVoorActiviteit != null)
                {
                    foreach(int i in DTO.GebruikersVoorActiviteit)
                    {
                        gebruikers.Add(_gebruikerRepository.GetByApiId(i));
                    }
                }
                Activiteit l = new Activiteit(DateTime.Parse(DTO.StartDatum), gebruikers, DateTime.Parse(DTO.EindDatum), DTO.Naam, DTO.Type, DTO.MaxAantalGebruikers, DTO.Straat, DTO.Huisnr, DTO.Postcode, DTO.Stad, DTO.Startuur, DTO.Email, DTO.Telefoonnummer);
                l.GebruikersVoorActiviteit = DTO.GebruikersVoorActiviteit;
                _activiteitRepository.Add(l);
                _activiteitRepository.SaveChanges();
                return l;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Activiteit/5
        [HttpPut("{id}")]
        public async System.Threading.Tasks.Task<ActionResult<Activiteit>> Put(int id, ActiviteitDTO DTO)
        {
            try
            {
                Activiteit l = _activiteitRepository.GetBy(id);
                if (l == null) return BadRequest("Activiteit kon niet worden gevonden");
                List<Gebruiker> gebruikers = new List<Gebruiker>();
                Boolean GebruikerNietGevonden = false;
                int GebruikerNietGevondenId = 0;
                //DTO.GebruikerIds.ForEach(GebruikerId =>
                //{
                //    Gebruiker gebruiker = _gebruikerRepository.GetBy(GebruikerId);
                //    if (gebruiker == null)
                //    {
                //        GebruikerNietGevonden = true;
                //        GebruikerNietGevondenId = GebruikerId;
                //    }

                //    else
                //    {
                //        GebruikersVoorActiviteit.Add((Gebruiker)gebruiker);
                //    }

                //});
                //if (GebruikerNietGevonden)
                //{
                //    return BadRequest("Gebruiker met id " + GebruikerNietGevondenId + " kon niet worden gevonden!");
                //}

                foreach(int i in DTO.GebruikersVoorActiviteit)
                {
                    Gebruiker gebruiker = _gebruikerRepository.GetBy(i);
                    if (gebruiker == null)
                        gebruiker = _gebruikerRepository.GetByApiId(i);
                    gebruikers.Add(gebruiker);
                }

                l.MaxAantalGebruikers = DTO.MaxAantalGebruikers;
                l.GebruikersApi = gebruikers;
                l.GebruikersVoorActiviteit = DTO.GebruikersVoorActiviteit;
                l.StartDatum = DateTime.Parse(DTO.StartDatum.ToString());
                l.EindDatum = DateTime.Parse(DTO.EindDatum.ToString());
                l.Naam = DTO.Naam;
                l.Email = DTO.Email;
                l.Huisnr = DTO.Huisnr;
                l.Postcode = DTO.Postcode;
                l.Stad = DTO.Stad;
                l.Startuur = DTO.Startuur;
                l.Straat = DTO.Straat;
                l.Telefoonnummer = DTO.Telefoonnummer;
                l.Type = DTO.Type;
                _activiteitRepository.Update(l);
                _activiteitRepository.SaveChanges();
                //     return CreatedAtAction(nameof(GetBy), new { id = l.Id }, l);
                return l;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Activiteit> Delete(int id)
        {
            Activiteit activiteit = _activiteitRepository.GetBy(id);
            if (activiteit == null) return BadRequest("Activiteit kon niet worden gevonden!");
            _activiteitRepository.Delete(activiteit);
            return activiteit;
        }

        private DateTime zetDatumOm(string datum)
        {
            StringBuilder sB = new StringBuilder();
            sB.Append(datum.Substring(4, 2)).Append("/");
            sB.Append(kiesMaand(datum.Substring(0, 3))).Append("/");
            sB.Append(datum.Substring(8, 4));
            return DateTime.Parse(sB.ToString());
        }

        private string kiesMaand(string maand)
        {
            switch (maand.ToLower())
            {
                case "jan":
                    return "01";

                case "feb":
                    return "02";

                case "mrt":
                    return "03";
                case "mar":
                    return "03";

                case "apr":
                    return "04";

                case "mei":
                    return "05";
                case "may":
                    return "05";

                case "jun":
                    return "06";

                case "jul":
                    return "07";

                case "aug":
                    return "08";

                case "sep":
                    return "09";

                case "okt":
                    return "10";
                case "oct":
                    return "10";
                case "nov":
                    return "11";

                case "dec":
                    return "12";
            }
            return null;
        }
    }
}
