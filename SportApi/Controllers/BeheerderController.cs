using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectG05.Models.Domain;
using SportApi.DTO_s;

namespace SportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeheerderController : ControllerBase
    {
        private IGebruiker _gebruikerRepository;

        private readonly UserManager<IdentityUser> _userManager;

        public BeheerderController(IGebruiker gebruikerRepository, UserManager<IdentityUser> userManager)
        {
            _gebruikerRepository = gebruikerRepository;
            _userManager = userManager;
        }

        // GET: api/Gebruiker
        [HttpGet]
        public IEnumerable<Gebruiker> GetAll()
        {
            return _gebruikerRepository.GetAllBeheerders();
        }

        // POST: api/Gebruiker
        [HttpPost]
        public async Task<ActionResult<Gebruiker>> PostAsync(LesgeverDTO dto)
        {
            try
            {
                Gebruiker g = new Beheerder(dto.Voornaam, dto.Naam, dto.StraatNaam, dto.Huisnummer, dto.Busnummer,
                dto.Postcode, dto.Stad, dto.TelefoonNummer, dto.Email, zetDatumOm(dto.Geb), dto.Geslacht);

                string eMailAddress = dto.Email;
                IdentityUser user = new IdentityUser { UserName = eMailAddress, Email = eMailAddress };
                await _userManager.CreateAsync(user, "Test123@!");
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "beheerder"));

                _gebruikerRepository.Add(g);
                _gebruikerRepository.SaveChanges();
                return g;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Beheerder> GetBy(int id)
        {
            Gebruiker g = _gebruikerRepository.GetBy(id);
            if (g == null) return NotFound("De Beheerder kon niet worden gevonden");
            try
            {
                var geb = (Beheerder) _gebruikerRepository.GetBy(id);
                return geb;
            }catch(Exception e)
            {
                return BadRequest("De gevraagde gebruiker is niet van het type Beheerder");
            }
            
        }

        // PUT: api/Gebruiker/5
        [HttpPut("{id}")]
        public ActionResult<Gebruiker> Put(int id, LesgeverDTO dto)
        {
            try
            {
                Gebruiker g = _gebruikerRepository.GetBy(id);
                if (g == null) return BadRequest("De gebruiker kon niet worden gevonden!");
                if (!(g is Beheerder)) return BadRequest("De gebruiker is geen beheerder!");
                g.Voornaam = dto.Voornaam;
                g.Naam = dto.Naam;
                g.Straatnaam = dto.StraatNaam;
                g.Huisnummer = dto.Huisnummer;
                g.Postcode = dto.Postcode;
                g.Stad = dto.Stad;
                g.Telefoonnummer = dto.TelefoonNummer;
                g.Email = dto.Email;
                g.GeboorteDatum = DateTime.Parse(dto.GeboorteDatum);
                g.Geslacht = dto.Geslacht;
                _gebruikerRepository.Update(g);
                _gebruikerRepository.SaveChanges();
                return g;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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

                case "apr":
                    return "04";

                case "mei":
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

                case "nov":
                    return "11";

                case "dec":
                    return "12";
            }
            return null;
        }
    }
}