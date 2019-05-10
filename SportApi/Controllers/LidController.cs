using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectG05.Models.Domain;
using SportApi.DTO_s;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LidController : ControllerBase
    {
        private IGebruiker _gebruikerRepository;

        private readonly UserManager<IdentityUser> _userManager;

        public LidController(IGebruiker gebruikerRepository, UserManager<IdentityUser> userManager)
        {
            _gebruikerRepository = gebruikerRepository;
            _userManager = userManager;
        }

        // GET: api/Leden
        [HttpGet]
        public IEnumerable<Gebruiker> GetAll()
        {
            return _gebruikerRepository.GetAllLeden();
        }

        // POST: api/Lid
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult<Gebruiker>> PostLidAsync(LidDTO dto)
        {
            try
            {
                DateTime inschrijvingsdatum = DateTime.Today;
                Gebruiker lid = new Lid(dto.Voornaam, dto.Naam, dto.StraatNaam, dto.Huisnummer, dto.Busnummer, dto.Postcode,
                    dto.Stad, dto.TelefoonNummer, dto.Email, zetDatumOm(dto.Geb), dto.Nationaliteit,
                    dto.EmailOuders, dto.RijksregisterNummer, dto.GeborenTe, dto.Geslacht,
                    inschrijvingsdatum, dto.Graad);

                string eMailAddress = dto.Email;
                IdentityUser user = new IdentityUser { UserName = eMailAddress, Email = eMailAddress };
                await _userManager.CreateAsync(user, "Test123@!");
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "lid"));

                _gebruikerRepository.Add(lid);
                _gebruikerRepository.SaveChanges();
                return lid;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Lid> GetBy(int id)
        {
            Gebruiker g = _gebruikerRepository.GetBy(id);
            if (g == null) return NotFound("Het Lid kon niet worden gevonden");
            if (g.Type != "Lid")
            {
                return BadRequest("De gevraagde gebruiker is niet van het type lid");
            }
            Lid l = (Lid)_gebruikerRepository.GetBy(id);

            return l;
        }

        // PUT: api/Gebruiker/5
        [HttpPut("{id}")]
        public ActionResult<Gebruiker> Put(int id, LidDTO dto)
        {
            try
            {
                Lid g = (Lid)_gebruikerRepository.GetBy(id);
                if (g == null) throw new Exception("Gebruiker kon niet worden gevonden!");
                if (!(g is Lid))
                    return BadRequest("De opgegeven gebruiker is geen lesgever");
                g.Voornaam = dto.Voornaam;
                g.Naam = dto.Naam;
                g.Straatnaam = dto.StraatNaam;
                g.Huisnummer = dto.Huisnummer;
                g.Postcode = dto.Postcode;
                g.Stad = dto.Stad;
                g.Telefoonnummer = dto.TelefoonNummer;
                g.Email = dto.Email;
                //  g.GeboorteDatum = zetDatumOm(dto.Geb);
                g.GeboorteDatum = DateTime.Parse(dto.GeboorteDatum);
                g.Nationaliteit = dto.Nationaliteit;
                g.EmailOuders = dto.EmailOuders;
                g.Rijksregisternummer = dto.RijksregisterNummer;
                g.GeborenTe = dto.GeborenTe;
                g.Geslacht = dto.Geslacht;
                g.Graad = dto.Graad;
                g.WenstInfoTeKrijgenOverClubAangelegenheden = dto.WenstInfoTeKrijgenOverClubAangelegenheden;
                g.WenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties = dto.WenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties;
                g.ToestemmingAudioVisueelMateriaal = dto.ToestemmingAudioVisueelMateriaal;
                g.AkkoordMetHuishoudelijkRegelement = dto.AkkoordMetHuishoudelijkRegelement;
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