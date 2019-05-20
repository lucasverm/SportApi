using Microsoft.AspNetCore.Identity;
using ProjectG05.Models.Domain;
using SportApi.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectG05.Data
{
    public class DataInitializer
    {
        #region Fields

        private ApplicationDbContext _dbContext;

        private List<Beheerder> beheerders;

        private List<Gebruiker> lesgevers;

        private IActiviteit _activiteitenRepository;

        private List<Lid> leden;
        private List<NietLid> Nietleden;

        private ILes _lesRepository;

        private ISessie _sessieRepository;

        private readonly UserManager<IdentityUser> _userManager;

        #endregion Fields

        #region Constructors

        public DataInitializer(ApplicationDbContext dbContext, ILes lesRepo, ISessie sessieRepository, UserManager<IdentityUser> userManager, IActiviteit activiteitRepo)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _lesRepository = lesRepo;
            _sessieRepository = sessieRepository;
            this.beheerders = new List<Beheerder>();
            lesgevers = new List<Gebruiker>();
            leden = new List<Lid>();
            Nietleden = new List<NietLid>();
            _activiteitenRepository = activiteitRepo;
        }

        #endregion Constructors

        #region Methods

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();

            if (_dbContext.Database.EnsureCreated())
            {
                await InitializeUsers();
                
               
                ////leden die deelnemen aan sessie
                //////les met 1 en 2 op dinsdag 12:30 - 14:30
                //TimeSpan duur = new TimeSpan(2, 0, 0);
                //TimeSpan startUur = new TimeSpan(13, 30, 0);
                //Les les = new Les(lesgevers[0], startUur, duur, DayOfWeek.Tuesday, leden.GetRange(0, 1));
                //this._lesRepository.Add(les);


                //List<Gebruiker> gebruikers = new List<Gebruiker>();
                //gebruikers.Add(this.leden.First());
                //Activiteit a = new Activiteit(new DateTime(2019, 06, 11), gebruikers, new DateTime(2019, 06, 13), "Weekendje Ardennen", "ontspanning", 30);
                //_activiteitenRepository.Add(a);
                //////les met 2 en 3 op donderdag 12:30 - 14:30
                //Les les2 = new Les(lesgevers[1], startUur, duur, DayOfWeek.Thursday, leden.GetRange(1, 5));
                //this._lesRepository.Add(les2);

                //////les voor beheerder
                //Les les3 = new Les(beheerders[0], startUur, duur, DayOfWeek.Thursday, leden.GetRange(1, 5));
                //this._lesRepository.Add(les3);

                //Activiteit activiteit = new Activiteit(new DateTime(2019, 6, 1), new DateTime(2019, 6, 6), "JiuJitsu Beerpong", "type murde", 8);
                //_dbContext.Activiteiten.Add(activiteit);
                //_dbContext.SaveChanges();
                //}
            }
        }

        private async Task InitializeUsers()
        {
            Afbeelding afb1 = new Afbeelding(1, "adrasNaarAfb1");
            _dbContext.Afbeeldingen.Add(afb1);
            Video vid1 = new Video(1, "adresNaarVid1");
            _dbContext.Videos.Add(vid1);
            List<Afbeelding> listafb1 = new List<Afbeelding>();
            listafb1.Add(afb1);
            List<Video> listvid1 = new List<Video>();
            listvid1.Add(vid1);
            Lesmateriaal lesm1 = new Lesmateriaal(1, "lesm1", "dit is uitleg", "categorie1", listafb1, listvid1);
            _dbContext.Lesmaterialen.Add(lesm1);
            _dbContext.SaveChanges();

            Lesmateriaal lesmTest = new Lesmateriaal(1, "ditiseentest", "ditiseenuitleg", "ditiseencategorie");
            _dbContext.Lesmaterialen.Add(lesmTest);
            _dbContext.SaveChanges();
            
            string eMailAddress = "alain.lescur@jiu-jitsu-gent.be";
            IdentityUser user = new IdentityUser { UserName = eMailAddress, Email = eMailAddress };
            await _userManager.CreateAsync(user, "Test123@!");
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "beheerder"));
            Lesgever lesgever = new Lesgever("Alain", "Lescur", "nederstraat", "5", "1", "9000", "Gent", "0495192770", eMailAddress, new DateTime(1992, 5, 24), "M");
            _dbContext.Gebruikers.Add(lesgever);
            lesgevers.Add(lesgever);
            _dbContext.SaveChanges();
            //eMailAddress = "beheerder2@hogent.be";
            //user = new IdentityUser { UserName = eMailAddress, Email = eMailAddress };
            //await _userManager.CreateAsync(user, "Test123@!");
            //await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "beheerder"));
            //Beheerder beheerder = new Beheerder("Beheerder2", "beheerder2", "nederstraat", "5","0" , "9000", "Gent", "0495192770", eMailAddress, new DateTime(1998, 5, 24), "M");
            //_dbContext.Gebruikers.Add(beheerder);
            //beheerders.Add(beheerder);
            //lesgevers.Add(beheerder);

            //////lesgever
            //eMailAddress = "lesgever2@hogent.be";
            //user = new IdentityUser { UserName = eMailAddress, Email = eMailAddress };
            //await _userManager.CreateAsync(user, "Test123@!");
            //await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "lesgever"));
            //Lesgever lesgever = new Lesgever("Tom", "De Bakker", "nederstraat", "5", "B", "9000", "Gent", "0495192770", eMailAddress, new DateTime(1998, 5, 24), "M");
            //_dbContext.Gebruikers.Add(lesgever);
            //lesgevers.Add(lesgever);

            //eMailAddress = "tom@jiu-jitsu-gent.be";
            //user = new IdentityUser { UserName = eMailAddress, Email = eMailAddress };
            //await _userManager.CreateAsync(user, "Test123@!");
            //await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "lesgever"));
            //lesgever = new Lesgever("Tom", "Joris", "nederstraat", "5", "9000", "Gent", "0495192770", eMailAddress, new DateTime(1998, 5, 24), "M");
            //_dbContext.Gebruikers.Add(lesgever);
            //lesgevers.Add(lesgever);

            ////lid
            eMailAddress = "lid@hogent.be";
            user = new IdentityUser { UserName = eMailAddress, Email = eMailAddress };
            user.SecurityStamp = Guid.NewGuid().ToString();
            await _userManager.CreateAsync(user, "Test123@!");
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "lid"));
            Lid lid = new Lid("Wouter", "Opsommer", "nederstraat", "5","1", "9000", "Gent", "0495192770", eMailAddress, new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "M", 50);
            _dbContext.Gebruikers.Add(lid);
            _dbContext.SaveChanges();

            List<Lid> LedenVoorLes = new List<Lid>();
            LedenVoorLes.Add(lid);
            Les les = new Les(lesgever, new TimeSpan(2, 0, 0), new TimeSpan(2, 0, 0), DateTime.Now.DayOfWeek, LedenVoorLes);
            _dbContext.Lessen.Add(les);
            _dbContext.SaveChanges();

            Sessie s = new Sessie();
            s.StartSessieVanLes(les);

            s.Aanwezigen.Add(lid);
           _dbContext.SaveChanges();

            //Lid lid = new Lid("Lucas", "Vermeulen", "nederstraat", "5", "B", "9000", "Gent", "0495192770", "lid2@Lid2.com", new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "M", 2);
            //_dbContext.Gebruikers.Add(lid);
            //leden.Add(lid);
            //lid = new Lid("Bert", "Van Eeckhoutte", "nederstraat", "5", "B", "9000", "Gent", "0495192770", "lid3@Lid3.com", new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "M", 3);
            //_dbContext.Gebruikers.Add(lid);
            //leden.Add(lid);
            //Lid lid = new Lid("Elias", "Gryp", "nederstraat", "5", "B", "9000", "Gent", "0495192770", "elias.gryp@student.hogent.be", new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "M", 3);
            //_dbContext.Gebruikers.Add(lid);
            //leden.Add(lid);
            //lid = new Lid("Adam", "Maertens", "nederstraat", "5", "B", "9000", "Gent", "0495192770", "adam.maertens@student.hogent.be", new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "M", 3);
            //_dbContext.Gebruikers.Add(lid);
            //leden.Add(lid);
            //Lid lid4 = new Lid("Jan", "Muysons", "nederstraat", "5", "9000", "Gent", "0495192770", "Jan.Muysons@student.hogent.be", new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "M", 3);
            //_dbContext.Gebruikers.Add(lid4);
            //leden.Add(lid4);
            //lid = new Lid("Hans", "Mortrue", "nederstraat", "5", "9000", "Gent", "0495192770", "Hans.Mortrue@student.hogent.be", new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "M", 3);
            //_dbContext.Gebruikers.Add(lid);
            //leden.Add(lid);
            //lid = new Lid("Rani", "Tjack", "nederstraat", "5", "9000", "Gent", "0495192770", "rani.tjack@student.hogent.be", new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "V", 8);
            //_dbContext.Gebruikers.Add(lid);
            //leden.Add(lid);
            //lid = new Lid("Michael", "Meirlaan", "nederstraat", "5", "9000", "Gent", "0495192770", "rani.tjack@student.hogent.be", new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "V", 7);
            //_dbContext.Gebruikers.Add(lid);
            //leden.Add(lid);
            //lid = new Lid("Tijl", "Zwartjes", "nederstraat", "5", "9000", "Gent", "0495192770", "rani.tjack@student.hogent.be", new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "V", 6);
            //_dbContext.Gebruikers.Add(lid);
            //leden.Add(lid);
            //lid = new Lid("Stef", "Bondroit", "nederstraat", "5", "9000", "Gent", "0495192770", "rani.tjack@student.hogent.be", new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "V", 4);
            //_dbContext.Gebruikers.Add(lid);
            //leden.Add(lid);
            //lid = new Lid("Jens", "Crucke", "nederstraat", "5", "9000", "Gent", "0495192770", "rani.tjack@student.hogent.be", new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "V", 3);
            //_dbContext.Gebruikers.Add(lid);
            //leden.Add(lid);
            //lid = new Lid("Michiel", "Robbe", "nederstraat", "5", "9000", "Gent", "0495192770", "rani.tjack@student.hogent.be", new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "V", 3);
            //_dbContext.Gebruikers.Add(lid);
            //leden.Add(lid);
            //lid = new Lid("Nathan", "Delcourt", "nederstraat", "5", "9000", "Gent", "0495192770", "rani.tjack@student.hogent.be", new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "V", 5);
            //_dbContext.Gebruikers.Add(lid);
            //leden.Add(lid);
            //lid = new Lid("Stefan", "Vermote", "nederstraat", "5", "9000", "Gent", "0495192770", "rani.tjack@student.hogent.be", new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "V", 4);
            //_dbContext.Gebruikers.Add(lid);
            //leden.Add(lid);
            //lid = new Lid("Sebastian", "Vandergote", "nederstraat", "5", "9000", "Gent", "0495192770", "rani.tjack@student.hogent.be", new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "V", 2);
            //_dbContext.Gebruikers.Add(lid);
            //leden.Add(lid);
            //lid = new Lid("Frederic", "Dhondt", "nederstraat", "5", "9000", "Gent", "0495192770", "rani.tjack@student.hogent.be", new DateTime(1998, 5, 24), "Belg", "mama@hotmail.com", "98.05.24-381.22", "Roeselare", "V", 2);
            //_dbContext.Gebruikers.Add(lid);
            //leden.Add(lid);

            ////nietLid
            //eMailAddress = "Nietlid@hogent.be";
            //user = new IdentityUser { UserName = eMailAddress, Email = eMailAddress };
            //user.SecurityStamp = Guid.NewGuid().ToString();
            //await _userManager.CreateAsync(user, "Test123@!");
            //await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "nietLid"));
            //NietLid nietLid = new NietLid("Lucas", "Vermeulen", "nederstraat", "5", "B", "9000", "Gent", "0499764654", eMailAddress, new DateTime(1998, 5, 24), "M");
            //_dbContext.Gebruikers.Add(nietLid);
            ////nietLid = new NietLid("Thomas", "Schuddinck", "nederstraat", "5", "9000", "Gent", "0499764654", eMailAddress, new DateTime(1998, 5, 24), "M");
            //_dbContext.Gebruikers.Add(nietLid);
            //nietLid = new NietLid("Keelan", "Savat", "nederstraat", "5", "9000", "Gent", "0499764654", eMailAddress, new DateTime(1998, 5, 24), "M");
            //_dbContext.Gebruikers.Add(nietLid);
            //nietLid = new NietLid("Sofie", "Seru", "nederstraat", "5", "9000", "Gent", "0499764654", eMailAddress, new DateTime(1998, 5, 24), "M");
            //_dbContext.Gebruikers.Add(nietLid);

            //List<Afbeelding> Oefening1 = new List<Afbeelding>();
            //Afbeelding afb1 = new Afbeelding(1, "achterwaartse_stand_1.jpg");
            //Afbeelding afb2 = new Afbeelding(5, "achterwaartse_stand_3.jpg");
            //Afbeelding afb3 = new Afbeelding(3, "logo.png");
            //Afbeelding afb4 = new Afbeelding(4, "logo.png");
            //Afbeelding afb5 = new Afbeelding(3, "achterwaartse_stand_1.jpg");

            //Afbeelding afb6 = new Afbeelding(6, "achterwaartse_stand_3.jpg");
            //Oefening1.Add(afb2);

            //_dbContext.Afbeeldingen.Add(afb3);

            //_dbContext.Afbeeldingen.Add(afb5);

            //Video vid1 = new Video(1, "1 Dan aanval trekken en duwen-nekklem.mp4");
            //Video vid2 = new Video(2, "1ste Dan verdediging op trap maag-beenveeg.mp4");
            //Video vid3 = new Video(3, "2de Dan Posaanval zelfde kant-schouderklem.mp4");
            //Video vid4 = new Video(4, "1 Dan aanval trekken en duwen-nekklem.mp4");
            //Video vid5 = new Video(5, "1ste Dan verdediging op trap maag-beenveeg.mp4");
            //Video vid6 = new Video(6, "2de Dan Posaanval zelfde kant-schouderklem.mp4");
            //_dbContext.Videos.Add(vid1);
            //_dbContext.Videos.Add(vid2);
            //_dbContext.Videos.Add(vid3);
            //_dbContext.Videos.Add(vid4);
            //_dbContext.Videos.Add(vid5);
            //_dbContext.Videos.Add(vid6);

            //Lesmateriaal oefening1 = new Lesmateriaal(1, 2, "Schoppen", "Schop met je voeten");
            //Lesmateriaal oefening2 = new Lesmateriaal(2, 2, "Slaan", "slaan met je voeten");
            //Lesmateriaal oefening3 = new Lesmateriaal(3, 1, "Voorwaartse stand", "De benen zijn gespreid en staan in een rechthoekige driehoek (zie tekening). Het achterste been is gestrekt en het voorste been is gebogen zodat de knie zich recht boven de voet bevindt. De voorste voet staat recht naar voor en de achterste voet staat schuin op 30°. De heupen zijn omlaag gebracht, het bovenlichaam staat loodrecht ten opzichte van de grond en is naar voor gericht. Het gezicht is recht naar voor. Ongeveer 60% van het gewicht rust op het voorste en 40% op het achterste been.");
            //Lesmateriaal oefening4 = new Lesmateriaal(4, 1, "Achterwaartse stand", "slaan met je voeten");
            //Lesmateriaal oefening5 = new Lesmateriaal(5, 3, "Schoppen", "Schop met je voeten");
            //Lesmateriaal oefening6 = new Lesmateriaal(6, 3, "Slaan", "slaan met je voeten");
            //_dbContext.Lesmaterialen.Add(oefening1);
            //_dbContext.Lesmaterialen.Add(oefening2);
            //_dbContext.Lesmaterialen.Add(oefening3);
            //_dbContext.Lesmaterialen.Add(oefening4);
            //_dbContext.Lesmaterialen.Add(oefening5);
            //_dbContext.Lesmaterialen.Add(oefening6);

            //      //6de graad
            //      //bassistanden
            //      //1ste oef: Vorderen (categorie basisstanden)
            //      Afbeelding afb7 = new Afbeelding(1, "vorderen.jpg");
            //      Lesmateriaal oefening1 = new Lesmateriaal(1, "Vorderen", "Het vorderen naar voor gebeurt zonder de stand of de positie van het bovenlichaam te veranderen en door met de heupen op één lijn snel naar voor te stoten. Breng de voet van het achterste been naast de voet van het afzetbeen (voorste been waar overwegend het gewicht op rust). Het oude achterste been glijdt schuin naar voor terwijl de knie van het afzetbeen gestrekt wordt en de voetzool, vooral de hiel, krachtig tegen de grond gedrukt wordt (waardoor de voet 30° draait). Tijdens de verplaatsing wordt het lichaamsgewicht van de ene voet naar de andere verplaatst. Maak een draaibeweging zodat het vorderen in de tegenovergestelde richting opnieuw kan worden uitgevoerd (doe dit na herhaaldelijk de vorderbeweging te hebben uitgevoerd). Maak de draaibeweging door het achterste been bij te trekken, het lichaam 180° terug te draaien en het oude achterste been naar voor te brengen. De draaibeweging kan/mag ook worden uitgevoerd door het voorste been (afzetbeen) naar het achterste been te brengen, 180° te draaien en het oude voorste been verder diagonaal terug naar voor te brengen. Achteruit vorderen moet eveneens ingeoefend worden.", "basisstanden");
            //      //Commentaar commentaar1 = new Commentaar(lid1, oefening1, "Mooie oefening");
            //      //_dbContext.Commentaren.Add(commentaar1);
            //      _dbContext.Afbeeldingen.Add(afb7);
            //      _dbContext.Lesmaterialen.Add(oefening1);
            //      _dbContext.SaveChanges();
            //      //2de oef: Voorwaartse stand (basisstanden)
            //      Afbeelding afb8 = new Afbeelding(2, "voorwaartsestand1.jpg");
            //      Afbeelding afb9 = new Afbeelding(2, "voorwaartsestand2.jpg");
            //      Afbeelding afb10 = new Afbeelding(2, "voorwaartsestand3.jpg");
            //      Lesmateriaal oefening2 = new Lesmateriaal(1, "Voorwaartse stand", "De benen zijn gespreid en staan in een rechthoekige driehoek (zie tekening). Het achterste been is gestrekt en het voorste been is gebogen zodat de knie zich recht boven de voet bevindt. De voorste voet staat recht naar voor en de achterste voet staat schuin op 30°. De heupen zijn omlaag gebracht, het bovenlichaam staat loodrecht ten opzichte van de grond en is naar voor gericht. Het gezicht is recht naar voor. Ongeveer 60% van het gewicht rust op het voorste en 40% op het achterste been.", "basisstanden");
            //      //Commentaar commentaar2 = new Commentaar(lid1, oefening2, "Uitdagend!");
            //      //_dbContext.Commentaren.Add(commentaar2);
            //      _dbContext.Afbeeldingen.Add(afb8);
            //      _dbContext.Afbeeldingen.Add(afb9);
            //      _dbContext.Afbeeldingen.Add(afb10);
            //      _dbContext.Lesmaterialen.Add(oefening2);
            //      _dbContext.SaveChanges();
            //      //3de oef: achterwaartse stand (basisstanden)
            //      Afbeelding afb11 = new Afbeelding(3, "achterwaartsestand2.jpg");
            //      Afbeelding afb12 = new Afbeelding(3, "achterwaartse_stand_1.jpg");
            //      Afbeelding afb13 = new Afbeelding(3, "achterwaartse_stand_3.jpg");
            //      Lesmateriaal oefening3 = new Lesmateriaal(1, "Achterwaartse stand", "De benen zijn gespreid en staan op één lijn. De knie van het achterste been is sterk gebogen, naar buiten gedraaid en bevindt zich recht boven de voet. Het voorste been is licht gebogen. De voorste voet staat recht naar voor en de achterste voet staat schuin op 90° in T of L stand. De heupen zijn omlaag gebracht, het bovenlichaam staat loodrecht ten opzichte van de grond en is half weggedraaid. Het gezicht is recht naar voor. Ongeveer 30% van het gewicht rust op het voorste en 70% op het achterste been.", "basisstanden");
            //      _dbContext.Afbeeldingen.Add(afb11);
            //      _dbContext.Afbeeldingen.Add(afb12);
            //      _dbContext.Afbeeldingen.Add(afb13);
            //      _dbContext.Lesmaterialen.Add(oefening3);
            //      _dbContext.SaveChanges();
            //      //basisslagen
            //      //4de oef: voorwaartse stoot (basisslagen)
            //      Afbeelding afb14 = new Afbeelding(4, "voorwaartsestoot1.jpg");
            //      Afbeelding afb15 = new Afbeelding(4, "voorwaartsestoot2.jpg");
            //      Lesmateriaal oefening4 = new Lesmateriaal(1, "Voorwaartse stoot", "De elleboog van de stootarm moet licht langs het lichaam strijken en de onderarm moet naar binnen draaien. De arm maakt een voorwaartse rechtlijnige beweging. De vuist moet stevig gebald zijn en beschrijft tijdens de beweging een halve cirkel. Raak met het voorste deel van de vuist, met name de knokkels van de wijs- en middenvinger, de plexus. De andere arm wordt zo snel mogelijk terug naar de heup getrokken.", "basisslagen");
            //      _dbContext.Afbeeldingen.Add(afb14);
            //      _dbContext.Afbeeldingen.Add(afb15);
            //      _dbContext.Lesmaterialen.Add(oefening4);
            //      _dbContext.SaveChanges();
            //      //5de oef: omhooggaande stoot (basisslagen)
            //      Afbeelding afb16 = new Afbeelding(5, "Omhooggaandestoot1.jpg");
            //      Afbeelding afb17 = new Afbeelding(5, "Omhooggaandestoot2.jpg");
            //      Afbeelding afb18 = new Afbeelding(5, "Omhooggaandestoot3.jpg");
            //      Lesmateriaal oefening5 = new Lesmateriaal(1, "Omhooggaande stoot", "De elleboog van de stootarm moet licht langs het lichaam strijken en de onderarm moet naar binnen draaien. De arm maakt een omhooggaande rechtlijnige beweging. De vuist moet stevig gebald zijn en beschrijft tijdens de beweging een halve cirkel. Raak met het voorste deel van de vuist, met name de knokkels van de wijs- en middenvinger, de strot of het gezicht. De andere arm wordt zo snel mogelijk terug naar de heup getrokken.", "basisslagen");
            //      //Commentaar commentaar3 = new Commentaar(lid3, oefening5, "Hier zou ik wel wat meer uitleg van de leerkracht kunnen gebruikeren");
            //      //_dbContext.Commentaren.Add(commentaar3);
            //      _dbContext.Afbeeldingen.Add(afb16);
            //      _dbContext.Afbeeldingen.Add(afb17);
            //      _dbContext.Afbeeldingen.Add(afb18);
            //      _dbContext.Lesmaterialen.Add(oefening5);
            //      _dbContext.SaveChanges();
            //      //6de oef: Verticale stoot (bassislagen)
            //      Afbeelding afb19 = new Afbeelding(6, "verticalestoot1.jpg");
            //      Afbeelding afb20 = new Afbeelding(6, "verticalestoot2.jpg");
            //      Afbeelding afb21 = new Afbeelding(6, "verticalestoot3.jpg");
            //      Lesmateriaal oefening6 = new Lesmateriaal(1, "Verticale stoot", "De elleboog van de stootarm moet licht langs het lichaam strijken en de onderarm moet naar binnen draaien. De arm maakt een voorwaartse of omhooggaande rechtlijnige beweging. De vuist moet stevig gebald zijn en beschrijft tijdens de beweging een kwart van een cirkel. Raak met het voorste deel van de vuist, met name de knokkels van de wijs- en middenvinger, de plexus, de strot of het gezicht. De andere arm wordt zo snel mogelijk terug naar de heup getrokken.", "basisslagen");
            //      _dbContext.Afbeeldingen.Add(afb19);
            //      _dbContext.Afbeeldingen.Add(afb20);
            //      _dbContext.Afbeeldingen.Add(afb21);
            //      _dbContext.Lesmaterialen.Add(oefening6);
            //      _dbContext.SaveChanges();
            //      //7de oef: Hoekstoot (bassislagen)
            //      Afbeelding afb22 = new Afbeelding(7, "hoekstoot1.jpg");
            //      Afbeelding afb23 = new Afbeelding(7, "hoekstoot2.jpg");
            //      Afbeelding afb24 = new Afbeelding(7, "hoekstoot3.jpg");
            //      Afbeelding afb25 = new Afbeelding(7, "hoekstoot4.jpg");
            //      Lesmateriaal oefening7 = new Lesmateriaal(1, "Hoekstoot", "De elleboog van de stootarm moet licht langs het lichaam strijken en de onderarm moet naar binnen draaien. De arm maakt een voorwaartse hoekbeweging. De vuist moet stevig gebald zijn en beschrijft tijdens de beweging een halve cirkel. Raak met het voorste deel van de vuist (de elleboog is volledig geplooid), met name de knokkels van de wijs- en middenvinger, de kin, de slaap of de plexus. De andere arm wordt zo snel mogelijk terug naar de heup getrokken.", "basisslagen");
            //      //Commentaar commentaar4 = new Commentaar(lid4, oefening7, "Heel goed beschreven");
            //      //_dbContext.Commentaren.Add(commentaar4);
            //      _dbContext.Afbeeldingen.Add(afb22);
            //      _dbContext.Afbeeldingen.Add(afb23);
            //      _dbContext.Afbeeldingen.Add(afb24);
            //      _dbContext.Afbeeldingen.Add(afb25);
            //      _dbContext.Lesmaterialen.Add(oefening7);
            //      _dbContext.SaveChanges();
            //      //8ste oef: Ronde stoot (bassislagen)
            //      Afbeelding afb26 = new Afbeelding(8, "rondestoot1.jpg");
            //      Afbeelding afb27 = new Afbeelding(8, "rondestoot2.jpg");
            //      Afbeelding afb28 = new Afbeelding(8, "rondestoot3.jpg");
            //      Afbeelding afb29 = new Afbeelding(8, "rondestoot4.png");
            //      Lesmateriaal oefening8 = new Lesmateriaal(1, "Ronde stoot", "De elleboog van de stootarm moet licht langs het lichaam strijken en de onderarm moet naar binnen draaien. De arm maakt een omhooggaande gedraaide beweging naar buiten en terug naar binnen. De vuist moet stevig gebald zijn en beschrijft tijdens de beweging een driekwart draai van een cirkel. Raak met het voorste deel van de vuist (pols is licht naar buiten geplooid), met name de knokkels van de wijs- en middenvinger, de slaap. De andere arm wordt zo snel mogelijk terug naar de heup getrokken.", "basisslagen");
            //      _dbContext.Afbeeldingen.Add(afb26);
            //      _dbContext.Afbeeldingen.Add(afb27);
            //      _dbContext.Afbeeldingen.Add(afb28);
            //      _dbContext.Afbeeldingen.Add(afb29);
            //      _dbContext.Lesmaterialen.Add(oefening8);
            //      _dbContext.SaveChanges();
            //      //9de oef: Stoot van dichtbij (basislagen)
            //      Afbeelding afb30 = new Afbeelding(9, "stootVanDichtbij.jpg");
            //      Afbeelding afb31 = new Afbeelding(9, "stootVanDichtbij2.jpg");
            //      Afbeelding afb32 = new Afbeelding(9, "stootVanDichtbij3.jpg");
            //      Afbeelding afb33 = new Afbeelding(9, "stootVanDichtbij4.jpg");
            //      Lesmateriaal oefening9 = new Lesmateriaal(1, "Stoot van dichtbij", "De elleboog van de stootarm moet licht langs het lichaam strijken. De arm maakt een opwaartse hoekbeweging. De vuist moet stevig gebald zijn en stoot recht naar boven. Zorg dat de binnenkant van de vuist naar binnen wijst. Raak met het voorste deel van de vuist, met name de knokkels van de wijs- en middenvinger, de kin, de zijkant of het middengedeelte van het lichaam. De andere arm wordt zo snel mogelijk terug naar de heup getrokken.", "basisslagen");
            //      _dbContext.Afbeeldingen.Add(afb30);
            //      _dbContext.Afbeeldingen.Add(afb31);
            //      _dbContext.Afbeeldingen.Add(afb32);
            //      _dbContext.Afbeeldingen.Add(afb33);
            //      _dbContext.Lesmaterialen.Add(oefening9);
            //      _dbContext.SaveChanges();

            //      //5de graad
            //      //bassistanden
            //      //10ste oef: Vorderen (categorie basisstanden)
            //      Afbeelding afb34 = new Afbeelding(10, "vorderen.jpg");
            //      Lesmateriaal oefening10 = new Lesmateriaal(2, "Vorderen", "Het vorderen naar voor gebeurt zonder de stand of de positie van het bovenlichaam te veranderen en door met de heupen op één lijn snel naar voor te stoten. Breng de voet van het achterste been naast de voet van het afzetbeen (voorste been waar overwegend het gewicht op rust). Het oude achterste been glijdt schuin naar voor terwijl de knie van het afzetbeen gestrekt wordt en de voetzool, vooral de hiel, krachtig tegen de grond gedrukt wordt (waardoor de voet 30° draait). Tijdens de verplaatsing wordt het lichaamsgewicht van de ene voet naar de andere verplaatst. Maak een draaibeweging zodat het vorderen in de tegenovergestelde richting opnieuw kan worden uitgevoerd (doe dit na herhaaldelijk de vorderbeweging te hebben uitgevoerd). Maak de draaibeweging door het achterste been bij te trekken, het lichaam 180° terug te draaien en het oude achterste been naar voor te brengen. De draaibeweging kan/mag ook worden uitgevoerd door het voorste been (afzetbeen) naar het achterste been te brengen, 180° te draaien en het oude voorste been verder diagonaal terug naar voor te brengen. Achteruit vorderen moet eveneens ingeoefend worden.", "basisstanden");
            //      _dbContext.Afbeeldingen.Add(afb34);
            //      _dbContext.Lesmaterialen.Add(oefening10);
            //      _dbContext.SaveChanges();
            //      //2de oef: Voorwaartse stand (basisstanden)
            //      Afbeelding afb35 = new Afbeelding(11, "voorwaartsestand1.jpg");
            //      Afbeelding afb36 = new Afbeelding(11, "voorwaartsestand2.jpg");
            //      Afbeelding afb37 = new Afbeelding(11, "voorwaartsestand3.jpg");
            //      Lesmateriaal oefening11 = new Lesmateriaal(2, "Voorwaartse stand", "De benen zijn gespreid en staan in een rechthoekige driehoek (zie tekening). Het achterste been is gestrekt en het voorste been is gebogen zodat de knie zich recht boven de voet bevindt. De voorste voet staat recht naar voor en de achterste voet staat schuin op 30°. De heupen zijn omlaag gebracht, het bovenlichaam staat loodrecht ten opzichte van de grond en is naar voor gericht. Het gezicht is recht naar voor. Ongeveer 60% van het gewicht rust op het voorste en 40% op het achterste been.", "basisstanden");
            ////      Commentaar commentaar5 = new Commentaar(lid4, oefening11, "Heel goed beschreven");
            // //     _dbContext.Commentaren.Add(commentaar5);
            //      _dbContext.Afbeeldingen.Add(afb35);
            //      _dbContext.Afbeeldingen.Add(afb36);
            //      _dbContext.Afbeeldingen.Add(afb37);
            //      _dbContext.Lesmaterialen.Add(oefening11);
            //      _dbContext.SaveChanges();
            //      //3de oef: achterwaartse stand (basisstanden)
            //      Afbeelding afb38 = new Afbeelding(12, "achterwaartsestand2.jpg");
            //      Afbeelding afb39 = new Afbeelding(12, "achterwaartse_stand_1.jpg");
            //      Afbeelding afb40 = new Afbeelding(12, "achterwaartse_stand_3.jpg");
            //      Lesmateriaal oefening12 = new Lesmateriaal(2, "Achterwaartse stand", "De benen zijn gespreid en staan op één lijn. De knie van het achterste been is sterk gebogen, naar buiten gedraaid en bevindt zich recht boven de voet. Het voorste been is licht gebogen. De voorste voet staat recht naar voor en de achterste voet staat schuin op 90° in T of L stand. De heupen zijn omlaag gebracht, het bovenlichaam staat loodrecht ten opzichte van de grond en is half weggedraaid. Het gezicht is recht naar voor. Ongeveer 30% van het gewicht rust op het voorste en 70% op het achterste been.", "basisstanden");
            //      _dbContext.Afbeeldingen.Add(afb38);
            //      _dbContext.Afbeeldingen.Add(afb39);
            //      _dbContext.Afbeeldingen.Add(afb40);
            //      _dbContext.Lesmaterialen.Add(oefening12);
            //      _dbContext.SaveChanges();
            //      //basisslagen
            //      //4de oef: voorwaartse stoot (basisslagen)
            //      Afbeelding afb41 = new Afbeelding(13, "voorwaartsestoot1.jpg");
            //      Afbeelding afb42 = new Afbeelding(13, "voorwaartsestoot2.jpg");
            //      Lesmateriaal oefening13 = new Lesmateriaal(2, "Voorwaartse stoot", "De elleboog van de stootarm moet licht langs het lichaam strijken en de onderarm moet naar binnen draaien. De arm maakt een voorwaartse rechtlijnige beweging. De vuist moet stevig gebald zijn en beschrijft tijdens de beweging een halve cirkel. Raak met het voorste deel van de vuist, met name de knokkels van de wijs- en middenvinger, de plexus. De andere arm wordt zo snel mogelijk terug naar de heup getrokken.", "basisslagen");
            //      _dbContext.Afbeeldingen.Add(afb41);
            //      _dbContext.Afbeeldingen.Add(afb42);
            //      _dbContext.Lesmaterialen.Add(oefening13);
            //      _dbContext.SaveChanges();
            //      //5de oef: omhooggaande stoot (basisslagen)
            //      Afbeelding afb43 = new Afbeelding(14, "Omhooggaandestoot1.jpg");
            //      Afbeelding afb44 = new Afbeelding(14, "Omhooggaandestoot2.jpg");
            //      Afbeelding afb45 = new Afbeelding(14, "Omhooggaandestoot3.jpg");
            //      Lesmateriaal oefening14 = new Lesmateriaal(2, "Omhooggaande stoot", "De elleboog van de stootarm moet licht langs het lichaam strijken en de onderarm moet naar binnen draaien. De arm maakt een omhooggaande rechtlijnige beweging. De vuist moet stevig gebald zijn en beschrijft tijdens de beweging een halve cirkel. Raak met het voorste deel van de vuist, met name de knokkels van de wijs- en middenvinger, de strot of het gezicht. De andere arm wordt zo snel mogelijk terug naar de heup getrokken.", "basisslagen");
            //    //  Commentaar commentaar6 = new Commentaar(lid3, oefening14, "Een van de gemakkelijkere oefeningen");
            // //     _dbContext.Commentaren.Add(commentaar6);
            //      _dbContext.Afbeeldingen.Add(afb43);
            //      _dbContext.Afbeeldingen.Add(afb44);
            //      _dbContext.Afbeeldingen.Add(afb45);
            //      _dbContext.Lesmaterialen.Add(oefening14);
            //      _dbContext.SaveChanges();
            //      //6de oef: Verticale stoot (bassislagen)
            //      Afbeelding afb46 = new Afbeelding(15, "verticalestoot1.jpg");
            //      Afbeelding afb47 = new Afbeelding(15, "verticalestoot2.jpg");
            //      Afbeelding afb48 = new Afbeelding(15, "verticalestoot3.jpg");
            //      Lesmateriaal oefening15 = new Lesmateriaal(2, "Verticale stoot", "De elleboog van de stootarm moet licht langs het lichaam strijken en de onderarm moet naar binnen draaien. De arm maakt een voorwaartse of omhooggaande rechtlijnige beweging. De vuist moet stevig gebald zijn en beschrijft tijdens de beweging een kwart van een cirkel. Raak met het voorste deel van de vuist, met name de knokkels van de wijs- en middenvinger, de plexus, de strot of het gezicht. De andere arm wordt zo snel mogelijk terug naar de heup getrokken.", "basisslagen");
            //      _dbContext.Afbeeldingen.Add(afb46);
            //      _dbContext.Afbeeldingen.Add(afb47);
            //      _dbContext.Afbeeldingen.Add(afb48);
            //      _dbContext.Lesmaterialen.Add(oefening15);
            //      _dbContext.SaveChanges();
            //      //7de oef: Hoekstoot (bassislagen)
            //      Afbeelding afb49 = new Afbeelding(16, "hoekstoot1.jpg");
            //      Afbeelding afb50 = new Afbeelding(16, "hoekstoot2.jpg");
            //      Afbeelding afb51 = new Afbeelding(16, "hoekstoot3.jpg");
            //      Afbeelding afb52 = new Afbeelding(16, "hoekstoot4.jpg");
            //      Lesmateriaal oefening16 = new Lesmateriaal(2, "Hoekstoot", "De elleboog van de stootarm moet licht langs het lichaam strijken en de onderarm moet naar binnen draaien. De arm maakt een voorwaartse hoekbeweging. De vuist moet stevig gebald zijn en beschrijft tijdens de beweging een halve cirkel. Raak met het voorste deel van de vuist (de elleboog is volledig geplooid), met name de knokkels van de wijs- en middenvinger, de kin, de slaap of de plexus. De andere arm wordt zo snel mogelijk terug naar de heup getrokken.", "basisslagen");
            ////      Commentaar commentaar7 = new Commentaar(lid2, oefening16, "Deze voer ik altijd uit met plezier!");
            //  //    _dbContext.Commentaren.Add(commentaar7);
            //      _dbContext.Afbeeldingen.Add(afb49);
            //      _dbContext.Afbeeldingen.Add(afb50);
            //      _dbContext.Afbeeldingen.Add(afb51);
            //      _dbContext.Afbeeldingen.Add(afb52);
            //      _dbContext.Lesmaterialen.Add(oefening16);
            //      _dbContext.SaveChanges();
            //      //8ste oef: Ronde stoot (bassislagen)
            //      Afbeelding afb53 = new Afbeelding(17, "rondestoot1.jpg");
            //      Afbeelding afb54 = new Afbeelding(17, "rondestoot2.jpg");
            //      Afbeelding afb55 = new Afbeelding(17, "rondestoot3.jpg");
            //      Afbeelding afb56 = new Afbeelding(17, "rondestoot4.png");
            //      Lesmateriaal oefening17 = new Lesmateriaal(2, "Ronde stoot", "De elleboog van de stootarm moet licht langs het lichaam strijken en de onderarm moet naar binnen draaien. De arm maakt een omhooggaande gedraaide beweging naar buiten en terug naar binnen. De vuist moet stevig gebald zijn en beschrijft tijdens de beweging een driekwart draai van een cirkel. Raak met het voorste deel van de vuist (pols is licht naar buiten geplooid), met name de knokkels van de wijs- en middenvinger, de slaap. De andere arm wordt zo snel mogelijk terug naar de heup getrokken.", "basisslagen");
            //      _dbContext.Afbeeldingen.Add(afb53);
            //      _dbContext.Afbeeldingen.Add(afb54);
            //      _dbContext.Afbeeldingen.Add(afb55);
            //      _dbContext.Afbeeldingen.Add(afb56);
            //      _dbContext.Lesmaterialen.Add(oefening17);
            //_dbContext.SaveChanges();
            ////9de oef: Stoot van dichtbij (basislagen)
            //Afbeelding afb57 = new Afbeelding(18, "stootVanDichtbij.jpg");
            //Afbeelding afb58 = new Afbeelding(18, "stootVanDichtbij2.jpg");
            //Afbeelding afb59 = new Afbeelding(18, "stootVanDichtbij3.jpg");
            //Afbeelding afb60 = new Afbeelding(18, "stootVanDichtbij4.jpg");
            //Lesmateriaal oefening18 = new Lesmateriaal(2, "Stoot van dichtbij", "De elleboog van de stootarm moet licht langs het lichaam strijken. De arm maakt een opwaartse hoekbeweging. De vuist moet stevig gebald zijn en stoot recht naar boven. Zorg dat de binnenkant van de vuist naar binnen wijst. Raak met het voorste deel van de vuist, met name de knokkels van de wijs- en middenvinger, de kin, de zijkant of het middengedeelte van het lichaam. De andere arm wordt zo snel mogelijk terug naar de heup getrokken.", "basisslagen");
            //Commentaar commentaar8 = new Commentaar(lid1, oefening18, "Deze is wel van heel dichtbij!");
            //_dbContext.Commentaren.Add(commentaar8);
            //_dbContext.Afbeeldingen.Add(afb57);
            //_dbContext.Afbeeldingen.Add(afb58);
            //_dbContext.Afbeeldingen.Add(afb59);
            //_dbContext.Afbeeldingen.Add(afb60);
            //_dbContext.Lesmaterialen.Add(oefening18);
            //_dbContext.SaveChanges();

            ////oef graad 4
            //Lesmateriaal oefening19 = new Lesmateriaal(3, "Afwachtingskata", "Groet af, neem de natuurlijke stand met de voeten bij elkaar aan en ga over naar spreidstand. Vouw de armen. Stap met het linkerbeen naar voor uit in een naar voor leunende stand.Geef tezelfdertijd een stamp met open handpalm op de kin, onmiddellijk gevolgd door een rechtse verticale slag op de plexus.Keer terug in paardezitstand en ga over in spreidstand door het linkerbeen bij te trekken. Omklem met het rechterhand de linkervingers.Val met het linkerbeen uit naar links, geef met het linkerhand een slag meskant hand op de strot en kom in een voorwaartse stand.Geef met beide handen een slag in de nek(halsslagaders), neem de schouders vast, geef een rechter kniestoot in de plexus en kom in een hurkstand.Keer terug in paardezitstand en ga over naar spreidstand door het linkerbeen bij te trekken. Breng de rechterhand aan de eigen kin.Geef met het rechterbeen een zijwaartse trap naar rechts, onmiddellijk gevolgd door een zijwaartse slag meskant hand op de strot en geef een linkse verticale vuiststoot op de plexus.Kom in een naar achter leunende stand.Keer terug in paardezitstand, ga over in spreidstand door het rechterbeen bij te trekken en groet af.", "kata");
            //_dbContext.Lesmaterialen.Add(oefening19);
            //_dbContext.SaveChanges();
            //Commentaar commentaar12 = new Commentaar(lid1, oefening19, "Afwachten is geen probleem voor mij!");

            //Lesmateriaal oefening20 = new Lesmateriaal(3, "Kata slagen en standen", "Groet af en neem de natuurlijke stand met de voeten bij elkaar aan. Zet de tenen naar buiten en stap 20cm naar rechts (natuurlijke stand met de tenen naar buiten). Voer een neerwaartse blokkering uit terwijl met het rechterbeen naar achter gestapt wordt en ga in een naar voor leunende stand staan. Geef een verticale stoot terwijl gevorderd wordt naar voor (opnieuw een naar voor leunende stand). Vorder naar achter terwijl u een afweer met de zwaardhand (meskant) uitvoert en kom in een naar achter leunende stand. Vorder vanuit deze achterwaartse stand naar voor tot paardezitstand en geef terwijl een horizontale omgekeerde vuistslag en eindig met beide vuisten in de heupen. RUST. Vorder naar voor door het linkerbeen naar voor te plaatsten en kom zo in een verankerde stand te staan.Geef tijdens deze beweging een U - stoot.Trek het rechterbeen bij, draai vervolgens de romp 180° en kom in een naar voorleunende stand te staan geef gelijktijdig een verticale omgekeerde vuistslag.Trek het achterste been bij het voorste en geef een stoot van dichtbij.Plaats dat zelfde been uit naar links(hurkstand) en geef rechts een slag zwaardhand van buiten naar binnen.Breng het linkerbeen 90° naar achter(paardezitstand) en geef een dubbele evenwijdige stoot.Keer terug in de natuurlijk stand door het linkerbeen bij te trekken, breng de voeten bij elkaar en groet af.", "kata");
            //_dbContext.Lesmaterialen.Add(oefening20);
            //_dbContext.SaveChanges();
            //Commentaar commentaar13 = new Commentaar(lid1, oefening20, "Kata slagen vind ik leuk!");

            ////oef graad 3
            ////bassistanden
            ////10ste oef: Vorderen (categorie basisstanden)
            //Afbeelding afb68 = new Afbeelding(21, "vorderen.jpg");
            //Lesmateriaal oefening21 = new Lesmateriaal(4, "Vorderen", "Het vorderen naar voor gebeurt zonder de stand of de positie van het bovenlichaam te veranderen en door met de heupen op één lijn snel naar voor te stoten. Breng de voet van het achterste been naast de voet van het afzetbeen (voorste been waar overwegend het gewicht op rust). Het oude achterste been glijdt schuin naar voor terwijl de knie van het afzetbeen gestrekt wordt en de voetzool, vooral de hiel, krachtig tegen de grond gedrukt wordt (waardoor de voet 30° draait). Tijdens de verplaatsing wordt het lichaamsgewicht van de ene voet naar de andere verplaatst. Maak een draaibeweging zodat het vorderen in de tegenovergestelde richting opnieuw kan worden uitgevoerd (doe dit na herhaaldelijk de vorderbeweging te hebben uitgevoerd). Maak de draaibeweging door het achterste been bij te trekken, het lichaam 180° terug te draaien en het oude achterste been naar voor te brengen. De draaibeweging kan/mag ook worden uitgevoerd door het voorste been (afzetbeen) naar het achterste been te brengen, 180° te draaien en het oude voorste been verder diagonaal terug naar voor te brengen. Achteruit vorderen moet eveneens ingeoefend worden.", "basisstanden");
            //_dbContext.Afbeeldingen.Add(afb68);
            //_dbContext.Lesmaterialen.Add(oefening21);
            //_dbContext.SaveChanges();
            ////2de oef: Voorwaartse stand (basisstanden)
            //Afbeelding afb69 = new Afbeelding(22, "voorwaartsestand1.jpg");
            //Afbeelding afb70 = new Afbeelding(22, "voorwaartsestand2.jpg");
            //Afbeelding afb71 = new Afbeelding(22, "voorwaartsestand3.jpg");
            //Lesmateriaal oefening22 = new Lesmateriaal(24, "Voorwaartse stand", "De benen zijn gespreid en staan in een rechthoekige driehoek (zie tekening). Het achterste been is gestrekt en het voorste been is gebogen zodat de knie zich recht boven de voet bevindt. De voorste voet staat recht naar voor en de achterste voet staat schuin op 30°. De heupen zijn omlaag gebracht, het bovenlichaam staat loodrecht ten opzichte van de grond en is naar voor gericht. Het gezicht is recht naar voor. Ongeveer 60% van het gewicht rust op het voorste en 40% op het achterste been.", "basisstanden");
            //Commentaar commentaar10 = new Commentaar(lid4, oefening22, "Heel goed beschreven");
            //_dbContext.Commentaren.Add(commentaar10);
            //_dbContext.Afbeeldingen.Add(afb69);
            //_dbContext.Afbeeldingen.Add(afb70);
            //_dbContext.Afbeeldingen.Add(afb71);
            //_dbContext.Lesmaterialen.Add(oefening22);
            //_dbContext.SaveChanges();
            ////3de oef: achterwaartse stand (basisstanden)
            //Afbeelding afb72 = new Afbeelding(23, "achterwaartsestand2.jpg");
            //Afbeelding afb73 = new Afbeelding(23, "achterwaartse_stand_1.jpg");
            //Afbeelding afb74 = new Afbeelding(23, "achterwaartse_stand_3.jpg");
            //Lesmateriaal oefening23 = new Lesmateriaal(4, "Achterwaartse stand", "De benen zijn gespreid en staan op één lijn. De knie van het achterste been is sterk gebogen, naar buiten gedraaid en bevindt zich recht boven de voet. Het voorste been is licht gebogen. De voorste voet staat recht naar voor en de achterste voet staat schuin op 90° in T of L stand. De heupen zijn omlaag gebracht, het bovenlichaam staat loodrecht ten opzichte van de grond en is half weggedraaid. Het gezicht is recht naar voor. Ongeveer 30% van het gewicht rust op het voorste en 70% op het achterste been.", "basisstanden");
            //_dbContext.Afbeeldingen.Add(afb72);
            //_dbContext.Afbeeldingen.Add(afb73);
            //_dbContext.Afbeeldingen.Add(afb74);
            //_dbContext.Lesmaterialen.Add(oefening23);
            //_dbContext.SaveChanges();

            //Lesmateriaal oefening24 = new Lesmateriaal(5, "De aanvaller grijpt de rechterpols", "Geef de aanvaller ter afleiding een trap op het scheenbeen en draait met de romp naar links. Stoot met het linkerhand (open handpalm) op de pols van de aanvaller (houdt de pols van de aanvaller vast) en draai de romp onmiddellijk in de andere richting. Draai tezelfdertijd de pols uit de greep van de aanvaller. Trek de aanvaller licht naar u toe en werk af met een vuistslag op het gezicht.", "Polsbevrijdingen");
            //_dbContext.Lesmaterialen.Add(oefening24);
            //Commentaar commentaar14 = new Commentaar(lid2, oefening24, "Goed ter verdediging!");
            //_dbContext.SaveChanges();

            //Lesmateriaal oefening25 = new Lesmateriaal(5, "De aanvaller grijpt de linkerpols.", "Geef de aanvaller ter afleiding een trap op het scheenbeen en draai met de romp naar links. Draai de romp onmiddellijk in de andere richting. Draai tezelfdertijd (richting duimen) de pols uit de greep van de aanvaller en keer terug met een slag meskant hand op de neusbrug.", "Polsbevrijdingen");
            //_dbContext.Lesmaterialen.Add(oefening25);
            //_dbContext.SaveChanges();

            //VOORBEELD
            //Afbeelding afb14 = new Afbeelding(4, "voorwaartsestoot1.jpg");
            //Afbeelding afb15 = new Afbeelding(4, "voorwaartsestoot2.jpg");
            //Lesmateriaal oefening14 = new Lesmateriaal(4, 1, "Voorwaartse stoot", "");
            //_dbContext.Afbeeldingen.Add(afb14);
            //_dbContext.Afbeeldingen.Add(afb15);
            //_dbContext.Lesmaterialen.Add(oefening14);
            //_dbContext.SaveChanges();

            _dbContext.SaveChanges();
        }

        #endregion Methods
    }
}