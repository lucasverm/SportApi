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
            return _gebruikerRepository.GetAll();
        }

        // POST: api/Lid
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult<Gebruiker>> PostLidAsync(LidDTO dto)
        {
            DateTime inschrijvingsdatum = DateTime.Today;
            Gebruiker g;
            try
            {
                if (dto.Type.ToLower().Equals("lid"))
                {
                    g = new Lid(dto.Voornaam, dto.Naam, dto.StraatNaam, dto.Huisnummer, dto.Busnummer, dto.Postcode,
                   dto.Stad, dto.TelefoonNummer, dto.Email, zetDatumOm(dto.Geb), dto.Nationaliteit,
                   dto.EmailOuders, dto.RijksregisterNummer, dto.GeborenTe, dto.Geslacht,
                   inschrijvingsdatum, dto.AkkoordMetHuishoudelijkRegelement, dto.ToestemmingAudioVisueelMateriaal, dto.WenstInfoTeKrijgenOverClubAangelegenheden, dto.WenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties, dto.Graad);
                    _gebruikerRepository.Add(g);
                    _gebruikerRepository.SaveChanges();
                    return g;
                }

                if (dto.Type.ToLower().Equals("nietlid"))
                {
                    g = new NietLid(dto.Voornaam, dto.Naam, dto.StraatNaam, dto.Huisnummer, dto.Busnummer,
                dto.Postcode, dto.Stad, dto.TelefoonNummer, dto.Email, zetDatumOm(dto.Geb), dto.Geslacht);
                    _gebruikerRepository.Add(g);
                    _gebruikerRepository.SaveChanges();
                    return g;
                }
                if (dto.Type.ToLower().Equals("beheerder"))
                {
                    g = new Beheerder(dto.Voornaam, dto.Naam, dto.StraatNaam, dto.Huisnummer, dto.Busnummer,
                dto.Postcode, dto.Stad, dto.TelefoonNummer, dto.Email, zetDatumOm(dto.Geb), dto.Geslacht);
                    _gebruikerRepository.Add(g);
                    _gebruikerRepository.SaveChanges();
                    return g;
                }
                if (dto.Type.ToLower().Equals("lesgever"))
                {
                    g = new Lesgever(dto.Voornaam, dto.Naam, dto.StraatNaam, dto.Huisnummer, dto.Busnummer,
                dto.Postcode, dto.Stad, dto.TelefoonNummer, dto.Email, zetDatumOm(dto.Geb), dto.Geslacht);
                    _gebruikerRepository.Add(g);
                    _gebruikerRepository.SaveChanges();
                    return g;
                }
                if (dto.Type.ToLower().Equals("oudlid"))
                {
                    g = new OudLid(dto.Voornaam, dto.Naam, dto.StraatNaam, dto.Huisnummer, dto.Busnummer,
                dto.Postcode, dto.Stad, dto.TelefoonNummer, dto.Email, zetDatumOm(dto.Geb), dto.Geslacht);
                    _gebruikerRepository.Add(g);
                    _gebruikerRepository.SaveChanges();
                    return g;
                }
                if (!dto.Type.ToLower().Equals("nietlid"))
                {
                    string eMailAddress = dto.Email;
                    IdentityUser user = new IdentityUser { UserName = eMailAddress, Email = eMailAddress };
                    await _userManager.CreateAsync(user, "Test123@!");
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, dto.Type.ToLower()));
                    _gebruikerRepository.SaveChanges();
                }

                return null;
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
                if (dto.Type.ToLower().Equals("lid"))
                {
                    Lid lid = (Lid)_gebruikerRepository.GetBy(id);
                    if (lid == null) throw new Exception("Gebruiker kon niet worden gevonden!");
                    initialiseerAttributenLid(lid, dto);
                    initialiseerAttributenGebruiker(lid, dto);
                    _gebruikerRepository.SaveChanges();
                    return lid;
                }
                else
                {
                    if (dto.Type.ToLower().Equals("nietlid"))
                    {
                        NietLid nietLid = (NietLid)_gebruikerRepository.GetBy(id);
                        if (nietLid == null) throw new Exception("Gebruiker kon niet worden gevonden!");
                        nietLid = (NietLid)initialiseerAttributenGebruiker(nietLid, dto);
                        _gebruikerRepository.SaveChanges();
                        return nietLid;
                    }
                    if (dto.Type.ToLower().Equals("beheerder"))
                    {
                        Beheerder beheerder = (Beheerder)_gebruikerRepository.GetBy(id);
                        if (beheerder == null) throw new Exception("Gebruiker kon niet worden gevonden!");
                        beheerder = (Beheerder)initialiseerAttributenGebruiker(beheerder, dto);
                        _gebruikerRepository.SaveChanges();
                        return beheerder;
                    }
                    if (dto.Type.ToLower().Equals("lesgever"))
                    {
                        Lesgever lesgever = (Lesgever)_gebruikerRepository.GetBy(id);
                        if (lesgever == null) throw new Exception("Gebruiker kon niet worden gevonden!");
                        lesgever = (Lesgever)initialiseerAttributenGebruiker(lesgever, dto);
                        _gebruikerRepository.SaveChanges();
                        return lesgever;
                    }
                    if (dto.Type.ToLower().Equals("oudlid"))
                    {
                        OudLid oudLid = (OudLid)_gebruikerRepository.GetBy(id);
                        if (oudLid == null) throw new Exception("Gebruiker kon niet worden gevonden!");
                        oudLid = (OudLid)initialiseerAttributenGebruiker(oudLid, dto);
                        _gebruikerRepository.SaveChanges();
                        return oudLid;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Gebruiker> Delete(int id)
        {
            try
            {
                Gebruiker g = _gebruikerRepository.GetBy(id);
                if (g == null) return BadRequest("Gebruiker kon niet worden gevonden");
                _gebruikerRepository.Delete(g);
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

        private Gebruiker initialiseerAttributenGebruiker(Gebruiker g, LidDTO dto)
        {
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
            g.Geslacht = dto.Geslacht;
            g.Busnummer = dto.Busnummer;
            _gebruikerRepository.Update(g);
            return g;
        }
        private Lid initialiseerAttributenLid(Lid g, LidDTO dto)
        {
            g.Nationaliteit = dto.Nationaliteit;
            g.EmailOuders = dto.EmailOuders;
            g.Rijksregisternummer = dto.RijksregisterNummer;
            g.GeborenTe = dto.GeborenTe;
            g.Graad = dto.Graad;
            g.WenstInfoTeKrijgenOverClubAangelegenheden = dto.WenstInfoTeKrijgenOverClubAangelegenheden;
            g.WenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties = dto.WenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties;
            g.ToestemmingAudioVisueelMateriaal = dto.ToestemmingAudioVisueelMateriaal;
            g.AkkoordMetHuishoudelijkRegelement = dto.AkkoordMetHuishoudelijkRegelement;
            _gebruikerRepository.Update(g);
            return g;
        }
    }
}