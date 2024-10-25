using System.IO;

public partial class Factory : IDisposable
{
    internal static class CharacterEnum
    {
        private static Character CreateCharacter(params string[] names)
        {
            var retval = new Character(names);
            Ravenloftdb.Characters.Add(retval);
            return retval;
        }

        #region Arak
        public readonly static Character Lolth = CreateCharacter("Lolth");
        #endregion

        #region Arkandale
        public readonly static Character NataliaVhorishkova = CreateCharacter("Natalia Vhorishkova");
        public readonly static Character CainTimothy = CreateCharacter("Cain Timothy");
        public readonly static Character ElizabethTimothy = CreateCharacter("Elizabeth Timothy");
        public readonly static Character VirginiaDilisnya = CreateCharacter("Virginia Dilisnya");
        public readonly static Character RichardRatcliff = CreateCharacter("Richard Ratcliff");
        public readonly static Character MichaelRatcliff = CreateCharacter("Michael Ratcliff");
        public readonly static Character CharlotteWinchester = CreateCharacter("Charlotte Winchester");
        public readonly static Character CliffordDilisnya = CreateCharacter("Clifford Ratcliff");
        public readonly static Character CynthiaHerbert = CreateCharacter("Cynthia Herbert");
        public readonly static Character EmilyGerhardt = CreateCharacter("Emily Gerhardt");
        public readonly static Character IreneTimothy = CreateCharacter("Irene Timothy");
        public readonly static Character FranklinDodds = CreateCharacter("Franklin Dodds");
        public readonly static Character ThomasDodds = CreateCharacter("Thomas Dodds");
        public readonly static Character PatriciaRichards = CreateCharacter("Patricia Richards");
        public readonly static Character PriscillaSchilling = CreateCharacter("Priscilla Schilling");
        public readonly static Character ArabellaTimothy = CreateCharacter("Arabella Timothy");
        public readonly static Character WilliamTimothy = CreateCharacter("William Timothy");
        public readonly static Character EvelynWesterfield = CreateCharacter("Evelyn Westerfield");
        public readonly static Character LawrenceTimothy = CreateCharacter("Lawrence Timothy");
        public readonly static Character EsterTimothy = CreateCharacter("Ester Timothy");
        public readonly static Character CharlesNickerson = CreateCharacter("Charles Nickerson");
        public readonly static Character WinifredRatcliff = CreateCharacter("Winifred Ratcliff");
        #endregion

        #region Barovia
        public readonly static Character TaraKolyana = CreateCharacter("Tara Kolyana");
        public readonly static Character IreenaKolyana = CreateCharacter("Ireena Kolyana");
        public readonly static Character Tatyana = CreateCharacter("Tatyana");
        public readonly static Character FatherDonavich = CreateCharacter("Father Donavich");
        public readonly static Character KingBarov = CreateCharacter("King Barov von Zarovich");
        public readonly static Character Ravenovia = CreateCharacter("Queen Ravenovia von Zarovich");
        public readonly static Character Sergei = CreateCharacter("Lord Sergei von Zarovich");
        public readonly static Character MadamEva = CreateCharacter("Madam Eva");
        public readonly static Character LiefLipsiege = CreateCharacter("Lief Lipsiege");
        public readonly static Character Helga = CreateCharacter("Helga");
        public readonly static Character CyrusBelview = CreateCharacter("Cyrus Belview");
        public readonly static Character SpectreAbCenteer = CreateCharacter("Spectre Ab-Centeer");
        public readonly static Character ArtistaDeSlop = CreateCharacter("Artista DeSlop");
        public readonly static Character LadyIsoldeYunk = CreateCharacter("Lady Isolde Yunk", "Isolde the Incredible");
        public readonly static Character AerialDuPlumette = CreateCharacter("Aerial the Heavy", "Prince Aerial Du Plumette");
        public readonly static Character ArtankSwilovich = CreateCharacter("Artank Swilovich");
        public readonly static Character DorfniyaDilisny = CreateCharacter("Duchess Dorfniya Dilisnya");
        public readonly static Character Pidlwik = CreateCharacter("Pidlwik");
        public readonly static Character LeanneTriksky = CreateCharacter("Sir Lee the Crusher", "Sir Leanne Triksky");
        public readonly static Character TashaPetrovna = CreateCharacter("Tasha Petrovna");
        public readonly static Character KingToisky = CreateCharacter("King Toisky");
        public readonly static Character KingIntreeKatsky = CreateCharacter("Katsky the Bright", "King Intree Katsky");
        public readonly static Character StahbalIndiBhak = CreateCharacter("Stahbal Indi-Bhak");
        public readonly static Character Khazan = CreateCharacter("Khazan");
        public readonly static Character ElsaFallona = CreateCharacter("Elsa Fallona");
        public readonly static Character SedrikSpinwitovich = CreateCharacter("Admiral Spinwitovich", "Sir Sedrik Spinwitovich");
        public readonly static Character Animus = CreateCharacter("Animus");
        public readonly static Character ErikVonderbucks = CreateCharacter("Sir Erik Vonderbucks");
        public readonly static Character IvanDeRose = CreateCharacter("Ivan DeRose");
        public readonly static Character StephanGregorovich = CreateCharacter("Stephan Gregorovich");
        public readonly static Character IntreeSikValoo = CreateCharacter("Intree Sik-Valoo");
        public readonly static Character ArdentPallette = CreateCharacter("Ardent Pallette");
        public readonly static Character IvanIvanovich = CreateCharacter("Ivan Ivanovich");
        public readonly static Character CirilRomulich = CreateCharacter("Prefect Ciril Romulich");
        public readonly static Character Dollars = CreateCharacter("$$");
        public readonly static Character Finderway = CreateCharacter("St. Finderway");
        public readonly static Character Dostron = CreateCharacter("King Dostron");
        public readonly static Character GralmoreNimblenobs = CreateCharacter("Gralmore Nimblenobs");
        public readonly static Character AmericoStandardski = CreateCharacter("Americo Standardski");
        public readonly static Character Beucephalus = CreateCharacter("Beucephalus");
        public readonly static Character TatsaulEris = CreateCharacter("Tatsaul Eris");
        public readonly static Character AnnaPetrovna = CreateCharacter("AnnaPetrovna");
        public readonly static Character Arik = CreateCharacter("Arik");
        public readonly static Character MaryaMarkovia = CreateCharacter("Marya Markovia");
        public readonly static Character Endorovich = CreateCharacter("Endorovich the Terrible");
        public readonly static Character SashaIvliskova = CreateCharacter("Sasha Ivliskova");
        public readonly static Character PatrinaVelikovna = CreateCharacter("Patrina Velikovna");
        public readonly static Character KolyanIndirovich = CreateCharacter("Kolyan Indirovich");
        public readonly static Character Ismark = CreateCharacter("Ismark the Lesser");
        public readonly static Character MadMary = CreateCharacter("Mad Mary");
        public readonly static Character Gertruda = CreateCharacter("Gertruda");
        public readonly static Character Bildrath = CreateCharacter("Bildrath");
        public readonly static Character Parriwimple = CreateCharacter("Parriwimple");
        public readonly static Character GuardianOfSorrow = CreateCharacter("Guardian of Sorrow");
        public readonly static Character BabaLysaga = CreateCharacter("Baba Lysaga");
        public readonly static Character Mikhash = CreateCharacter("Mikhash");
        public readonly static Character JerenSureblade = CreateCharacter("Jeren Sureblade");
        public readonly static Character JanderSunstar = CreateCharacter("Jander Sunstar");
        public readonly static Character Bilkon = CreateCharacter("Bilkon");
        public readonly static Character Burganet = CreateCharacter("Burganet");
        public readonly static Character TheodoricTheBook = CreateCharacter("Theodoric the Book");
        public readonly static Character Sedgewick = CreateCharacter("Sedgewick");
        public readonly static Character Blinsky = CreateCharacter("Blinsky");
        public readonly static Character Aisha = CreateCharacter("Aisha");
        public readonly static Character Casius = CreateCharacter("Casius");
        public readonly static Character Elana = CreateCharacter("Elana");
        public readonly static Character Marnius = CreateCharacter("Marnius");
        public readonly static Character Walla = CreateCharacter("Walla");
        public readonly static Character Sturm = CreateCharacter("Lord Sturm Von Zarovich");
        public readonly static Character GisellaFallona = CreateCharacter("Gisella Fallona");
        public readonly static Character AnnaVonZarovich = CreateCharacter("Anna Von Zarovich");
        public readonly static Character TodHeitman = CreateCharacter("Tod Heitman");
        public readonly static Character SiskaVonZarovich = CreateCharacter("Siska Von Zarovich");
        public readonly static Character IvanReichhardt = CreateCharacter("Ivan Reichhardt");
        public readonly static Character KatarinaVonZarovich = CreateCharacter("Katarina Von Zarovich");
        public readonly static Character HolgarVonZarovich = CreateCharacter("Holgar Von Zarovich");
        public readonly static Character IsoldeVonKoss = CreateCharacter("Isolde Von Koss");
        public readonly static Character NatashaItskovich = CreateCharacter("Natasha Itskovich");
        public readonly static Character YsildeVonZarovich = CreateCharacter("Ysilde Von Zarovich");
        public readonly static Character SergeiVonZarovich2 = CreateCharacter("Sergei Von Zarovich (2)");
        public readonly static Character IreenaKolokoff = CreateCharacter("Ireena Kolokoff");
        public readonly static Character GeierVonZarovich = CreateCharacter("Geier Von Zarovich");
        public readonly static Character IvanVonZarovich = CreateCharacter("Ivan Von Zarovich");
        public readonly static Character NataliaAndas = CreateCharacter("Natalia Andas");
        public readonly static Character PeterVonZarovich = CreateCharacter("Peter Von Zarovich");
        public readonly static Character KatarinaDragus = CreateCharacter("Katarina Dragus");
        public readonly static Character BarovVonZarovich2 = CreateCharacter("Barov Von Zarovich (2)");
        public readonly static Character ElsaDrache = CreateCharacter("Elsa Drache");
        public readonly static Character AndreaVonZarovich = CreateCharacter("Andrea Von Zarovich");
        public readonly static Character KlausVonZarovich = CreateCharacter("Klaus Von Zarovich");
        public readonly static Character VictorVonZarovich = CreateCharacter("Victor Von Zarovich");
        public readonly static Character LisbethVonZarovich = CreateCharacter("Lisbeth Von Zarovich");
        public readonly static Character VasiliGeistlinger = CreateCharacter("Vasili Geistlinger");
        public readonly static Character MyroslavVonZarovich = CreateCharacter("Myroslav Von Zarovich");
        public readonly static Character MarlenaLeibnik = CreateCharacter("Marlena Leibnik");
        public readonly static Character HansVonZarovich = CreateCharacter("Hans Von Zarovich");
        #endregion

        #region Blaustein
        public readonly static Character Marcella = CreateCharacter("Marcella");
        public readonly static Character Lorel = CreateCharacter("Lorel");
        public readonly static Character Antonia = CreateCharacter("Antonia");
        public readonly static Character Ursula = CreateCharacter("Ursula");
        public readonly static Character Jacinda = CreateCharacter("Jacinda");
        public readonly static Character Marguerite = CreateCharacter("Marguerite");
        public readonly static Character Jacqueline = CreateCharacter("Jacqueline");
        public readonly static Character Beatrice = CreateCharacter("Beatrice");
        public readonly static Character Camilla = CreateCharacter("Camilla");
        public readonly static Character Matilda = CreateCharacter("Matilda");
        public readonly static Character Lenor = CreateCharacter("Lenor");
        #endregion

        #region Bluetspur
        public readonly static Character HighMasterIllithid = CreateCharacter("High Master Illithid");
        #endregion

        #region Borca
        public readonly static Character DuralIronHills = CreateCharacter("Dural of the Iron Hills");
        public readonly static Character Vadarin = CreateCharacter("Vadarin");
        public readonly static Character Dorfniya = CreateCharacter("Dorfniya");
        public readonly static Character GuntherCosco = CreateCharacter("Gunther Cosco");
        public readonly static Character PidlwickDilisnya = CreateCharacter("Pidlwick Dilisnya");
        public readonly static Character LeoDilisnya = CreateCharacter("Leo Dilisnya");
        public readonly static Character LevDilisnya = CreateCharacter("Lev Dilisnya");
        public readonly static Character NikiRomanoff = CreateCharacter("Niki Romanoff");
        public readonly static Character ElenaAlmeida = CreateCharacter("Elena Almeida");
        public readonly static Character YakovDilisnya = CreateCharacter("Yakov Dilisnya");
        public readonly static Character OleskaDilisnya = CreateCharacter("Oleska Dilisnya");
        public readonly static Character StepanDilisnya = CreateCharacter("Stepan Dilisnya");
        public readonly static Character AnnaKurdzeil = CreateCharacter("Anna Kurdzeil");
        public readonly static Character TadeuszPaldo = CreateCharacter("Tadeusz Paldo");
        public readonly static Character RichtorDilisnya = CreateCharacter("Richtor Dilisnya");
        public readonly static Character SiegfriedGrymig = CreateCharacter("Siegfried Grymig");
        public readonly static Character MariaDiazi = CreateCharacter("Maria Diazi");
        public readonly static Character KlausBoritsi = CreateCharacter("Klaus Boritsi");
        public readonly static Character StepanTaroyan = CreateCharacter("Stepan Taroyan");
        public readonly static Character Brunhilda = CreateCharacter("Brunhilda");
        public readonly static Character OlehFortich = CreateCharacter("Oleh Fortich");
        public readonly static Character AbelardoLeoni = CreateCharacter("Abelardo Leoni");
        public readonly static Character NikoliChesniak = CreateCharacter("Nikoli Chesniak");
        public readonly static Character AlexanderManduchi = CreateCharacter("Alexander Manduchi");
        public readonly static Character SuloBoritsi = CreateCharacter("Sulo Boritsi");
        public readonly static Character LuciaRitter = CreateCharacter("Lucia Ritter");
        public readonly static Character AntonBoritsi = CreateCharacter("Anton Boritsi");
        public readonly static Character KatarinaPiechota = CreateCharacter("Katarina Piechota");
        #endregion

        #region Cavitius
        #endregion

        #region Daglan
        public readonly static Character HordockCann = CreateCharacter("Hordock-Cann");
        #endregion

        #region Darkon
        public readonly static Character Clarke = CreateCharacter("Clarke");
        public readonly static Character Phillips = CreateCharacter("Phillips");
        public readonly static Character HowardAshton = CreateCharacter("Howard Ashton");
        public readonly static Character MarionRobinsdottir = CreateCharacter("Marion Robinsdottir");
        public readonly static Character Mazrikoth = CreateCharacter("Mazrikoth");
        public readonly static Character AlanikRay = CreateCharacter("Alanik Ray");
        public readonly static Character DorothaKenig = CreateCharacter("Dorotha Kenig");
        public readonly static Character GilesBowman = CreateCharacter("Giles the Bowman");
        public readonly static Character RatikUbel = CreateCharacter("Ratik Ubel");
        public readonly static Character DoctorRudolphVanRichten = CreateCharacter("Doctor Rudolph Van Richten");
        public readonly static Character KaleenCorigrave = CreateCharacter("Kaleen Corigrave");
        public readonly static Character Tyr = CreateCharacter("Tyr");
        public readonly static Character LatislavOfDarkon = CreateCharacter("Latislav of Darkon");
        #endregion

        #region Dementlieu
        public readonly static Character MarcelGuignol = CreateCharacter("Marcel Guignol");
        public readonly static Character Claude = CreateCharacter("Claude d`Honaire");
        public readonly static Character AliciaCorgiat = CreateCharacter("Alicia Corgiat");
        public readonly static Character Bernadette = CreateCharacter("Bernadette d`Honaire");
        public readonly static Character HuguesMousel = CreateCharacter("Hugues Mousel");
        public readonly static Character FrancoisMousel = CreateCharacter("Francois Mousel");
        public readonly static Character JoelieFontaine = CreateCharacter("Francois Fontaine");
        public readonly static Character MadeleineMousel = CreateCharacter("Madeleine Mousel");
        public readonly static Character RaymondeBiourne = CreateCharacter("Raymonde Biourne");
        public readonly static Character Maurice = CreateCharacter("Maurice d`Honaire");
        public readonly static Character AliciaNorberte = CreateCharacter("Alicia Norberte");
        public readonly static Character ErnestinePasier = CreateCharacter("Ernestine Pasier");
        public readonly static Character LouisePecquet = CreateCharacter("Louise Pecquet");
        public readonly static Character LouiseGirod = CreateCharacter("Louise Girod");
        public readonly static Character DominicdHonaire2 = CreateCharacter("Dominic d`Honaire II");
        public readonly static Character BabetteBatista = CreateCharacter("Babette Batista");
        public readonly static Character Julienne = CreateCharacter("Julienne d`Honaire");
        public readonly static Character BernardLoverde = CreateCharacter("Bernard Loverde");
        public readonly static Character Gerard = CreateCharacter("Gerard d`Honaire");
        #endregion

        #region Dorvinia
        public readonly static Character BorisDilisnya = CreateCharacter("Boris Dilisnya");
        public readonly static Character StefaniaSeptow = CreateCharacter("Stefania Septow");
        public readonly static Character KristinaDilisnya = CreateCharacter("Kristina Dilisnya");
        public readonly static Character NataliaOlszanik = CreateCharacter("Natalia Olszanik");
        public readonly static Character LucretiaMarzeya = CreateCharacter("Lucretia Marzeya");
        public readonly static Character ReinholdDilisnya = CreateCharacter("Reinhold Dilisnya");
        public readonly static Character NadiaYakimov = CreateCharacter("Nadia Yakimov");
        public readonly static Character GertudeDilisnya = CreateCharacter("Gertude Dilisnya");
        public readonly static Character IvanBuchvold = CreateCharacter("Ivan Buchvold");
        public readonly static Character OlekaDilisnya = CreateCharacter("Oleka Dilisnya");
        public readonly static Character VictorWachter = CreateCharacter("Victor Wachter");
        public readonly static Character LovinaWachter = CreateCharacter("Lovina Wachter");
        public readonly static Character RomanDilisnya = CreateCharacter("Roman Dilisnya");
        public readonly static Character AnnaSpachuk = CreateCharacter("Anna Spachuk");
        public readonly static Character CamilleYakimov = CreateCharacter("Camille Yakimov");
        public readonly static Character FredrikDilisnya = CreateCharacter("Fredrik Dilisnya");
        public readonly static Character TaraYanoff = CreateCharacter("Tara Yanoff");
        public readonly static Character KatinaDilisnya = CreateCharacter("Katina Dilisnya");
        public readonly static Character HassligDilisnya = CreateCharacter("Hasslig Dilisnya");
        public readonly static Character EdgarLeskovich = CreateCharacter("Edgar Leskovich");
        #endregion

        #region Falkovnia
        public readonly static Character SymbukTorul = CreateCharacter("Symbuk Torul");
        public readonly static Character Killeen = CreateCharacter("Killeen");
        public readonly static Character Kevlin = CreateCharacter("Kevlin");
        public readonly static Character Knightengale = CreateCharacter("Knightengale");
        public readonly static Character Gondegal = CreateCharacter("Gondegal", "Lost King");

        public readonly static Character NadiaRuzich = CreateCharacter("Nadia Ruzich");
        public readonly static Character IreenaImlach = CreateCharacter("Ireena Imlach");
        public readonly static Character YuriMitrovic = CreateCharacter("Yuri Mitrovic");

        public readonly static Character LelaDekovan = CreateCharacter("Lela Dekovan");
        public readonly static Character VladDrakov2 = CreateCharacter("Vlad Drakov II");
        public readonly static Character TatyanaOstevic = CreateCharacter("Tatyana Ostevic");
        public readonly static Character VladDrakov3 = CreateCharacter("Vlad Drakov III");
        public readonly static Character KaraDrakov = CreateCharacter("Kara Drakov");
        public readonly static Character DmitriLikarevie = CreateCharacter("Dmitri Likarevie");
        public readonly static Character MirceaDrakov = CreateCharacter("Mircea Drakov");
        public readonly static Character AnnaHatziavas = CreateCharacter("Anna Hatziavas");
        public readonly static Character TaraFastov = CreateCharacter("Tara Fastov");
        public readonly static Character SzotaDrakov = CreateCharacter("Szota Drakov");
        public readonly static Character PeterVonBorstel = CreateCharacter("Peter Von Borstel");

        public readonly static Character GriseldaZamiara = CreateCharacter("Griselda Zamiara");
        public readonly static Character MikhailDrakov = CreateCharacter("Mikhail Drakov");
        public readonly static Character OlanaCrepeau = CreateCharacter("Olana Crepeau");
        public readonly static Character NatashaDrakov = CreateCharacter("Natasha Drakov");
        public readonly static Character LevKrenkovich = CreateCharacter("Lev Krenkovich");
        #endregion

        #region G'Henna
        public readonly static Character Zhakata = CreateCharacter("Zhakata");
        #endregion

        #region Ghastria
        #endregion

        #region Gundarak
        public readonly static Character BonnieLee = CreateCharacter("Bonnie Lee");
        public readonly static Character Margaret = CreateCharacter("Margaret");
        public readonly static Character AnimatedCoffin = CreateCharacter("Animated Coffin");
        #endregion

        #region Har'Akir
        public readonly static Character Senmet = CreateCharacter("Senmet");
        public readonly static Character Trisler = CreateCharacter("Trisler");
        public readonly static Character Ra = CreateCharacter("Ra");
        public readonly static Character Nephyr = CreateCharacter("Nephyr");
        #endregion

        #region Hazlan
        public readonly static Character JulioMasterThief = CreateCharacter("Julio, Master Thief of Haslic", "Julio, Master Thief of Hazlan");
        #endregion

        #region House of Lament
        public readonly static Character LordDranzorg = CreateCharacter("Lord Dranzorg");
        public readonly static Character LordSilva = CreateCharacter("Lord Silva");
        public readonly static Character LadyMaraSilva = CreateCharacter("Mara");
        #endregion

        #region Invidia
        public readonly static Character Isabella = CreateCharacter("Isabella");
        public readonly static Character Matton = CreateCharacter("Matton");
        #endregion

        #region Kartakass
        public readonly static Character Akriel = CreateCharacter("Akriel");
        public readonly static Character Nhalvaen = CreateCharacter("Nhalvaen");
        public readonly static Character Milil = CreateCharacter("Milil");
        public readonly static Character MeistersingerCasimir = CreateCharacter("Meistersinger Casimir Lukas");
        public readonly static Character MeistersingerZhone = CreateCharacter("Meistersinger Zhone Clieous");
        public readonly static Character Kahrus = CreateCharacter("Kahrus");
        public readonly static Character Devon = CreateCharacter("Devon");
        public readonly static Character Bakki = CreateCharacter("Bakki");
        public readonly static Character JaconosHanabara = CreateCharacter("Jaconos Hanabara");
        public readonly static Character Maria = CreateCharacter("Maria");
        public readonly static Character Ontosh = CreateCharacter("Ontosh");
        public readonly static Character Frantosh = CreateCharacter("Frantosh");
        public readonly static Character Jelena = CreateCharacter("Jelena");
        public readonly static Character Joshua = CreateCharacter("Joshua");
        public readonly static Character Jackques = CreateCharacter("Jackques");
        public readonly static Character MadamLupapus = CreateCharacter("Madam Lupapus");
        public readonly static Character HeinstockBeeterLupock = CreateCharacter("Heinstock Beeter Lupock");
        public readonly static Character Coraline = CreateCharacter("Coraline");
        public readonly static Character HaldrakeMoonbaun = CreateCharacter("Haldrake Moonbaun");
        public readonly static Character Ledalar = CreateCharacter("Ledalar");
        public readonly static Character Gleeda = CreateCharacter("Gleeda");
        public readonly static Character Teena = CreateCharacter("Teena");
        #endregion

        #region Klorr
        #endregion

        #region Lamordia
        public readonly static Character DoctorAugustus = CreateCharacter("Doctor Augustus");
        public readonly static Character NurseRoberts = CreateCharacter("Nurse Roberts");
        public readonly static Character KatrinaVonBrandthofen = CreateCharacter("Katrina Von Brandthofen");
        public readonly static Character DoctorVictorMordenheim = CreateCharacter("Doctor Victor Mordenheim");
        public readonly static Character Eva = CreateCharacter("Eva");
        public readonly static Character BaronVonAubrecker = CreateCharacter("Baron Von Aubrecker");
        public readonly static Character EliseVonBrandthofen = CreateCharacter("Elise Von Brandthofen", "Elise Mordenheim");
        public readonly static Character MerileeMarkuza = CreateCharacter("Merilee Markuza");
        #endregion

        #region Liffe
        public readonly static Character CaptainAlecRapacion = CreateCharacter("Captain Alec Rapacion");
        public readonly static Character Eldon = CreateCharacter("Eldon");
        public readonly static Character Ravewood = CreateCharacter("Ravewood");
        public readonly static Character DanteLysin = CreateCharacter("Dante Lysin", "Dante Carare");
        public readonly static Character Lendor = CreateCharacter("Lendor");
        public readonly static Character LadyWindall = CreateCharacter("Lady Windall");
        public readonly static Character Rannow = CreateCharacter("Rannow");
        public readonly static Character JovisBlackwere = CreateCharacter("Captain Jovis Blackwere");
        public readonly static Character EjrikSpellbender = CreateCharacter("Ejrik Spellbender");
        public readonly static Character EronNalwand = CreateCharacter("Eron Nalwand");
        public readonly static Character TheaGyntheos = CreateCharacter("Thea Gyntheos");
        public readonly static Character Alisia = CreateCharacter("Alisia");
        #endregion

        #region Markovia
        public readonly static Character Ludmilla = CreateCharacter("Ludmilla");
        public readonly static Character JurgenVastish = CreateCharacter("Jurgen Vastish");
        #endregion

        #region Mordent
        public readonly static Character GoergeWeathermay = CreateCharacter("Goerge Weathermay");
        public readonly static Character TheCreature = CreateCharacter("The Creature");
        public readonly static Character TheAlchemist = CreateCharacter("The Alchemist");
        public readonly static Character LadyWeathermay = CreateCharacter("Lady Virginia Anne Weathermay");
        public readonly static Character OldLadyWeathermay = CreateCharacter("Lady Katherine Weathermay", "Lady Katherine Sutherwaite");
        public readonly static Character LordWeathermay = CreateCharacter("Lord Byron Merril Weathermay");
        public readonly static Character MistressArdent = CreateCharacter("Mistress Ysilda Gemanine Ardent");
        public readonly static Character Germain = CreateCharacter("Docteur Germain d'Honaire");
        public readonly static Character Marion = CreateCharacter("Marion Atwater");
        public readonly static Character Dominic = CreateCharacter("Dominic");
        public readonly static Character Luker = CreateCharacter("Luker");
        public readonly static Character CavelWarden = CreateCharacter("Cavel Warden");
        public readonly static Character KedarKlienan = CreateCharacter("Kedar Klienan");
        public readonly static Character Justinian = CreateCharacter("Justinian");
        public readonly static Character Honorius = CreateCharacter("Honorius");
        public readonly static Character Carlisle = CreateCharacter("Carlisle");
        public readonly static Character BrennaRaven = CreateCharacter("Brenna Raven");
        public readonly static Character TabbFinhallen = CreateCharacter("Tabb Finhallen");
        public readonly static Character KirkTerrinton = CreateCharacter("Kirk Terrinton");
        public readonly static Character MayorMalvinHeatherby = CreateCharacter("Mayor Malvin Heatherby");
        public readonly static Character TylerSmythy = CreateCharacter("Tyler Smythy");
        public readonly static Character GregorBoyd = CreateCharacter("Gregor Boyd");
        public readonly static Character GlennaWarden = CreateCharacter("Glenna Warden");
        public readonly static Character Gwydion = CreateCharacter("Gwydion (Mordent)");
        public readonly static Character GastonHedgewick = CreateCharacter("Gaston Hedgewick");
        public readonly static Character ArianaBartel = CreateCharacter("Ariana Bartel");
        public readonly static Character CarinaLoch = CreateCharacter("Carina Loch");
        public readonly static Character DarcyPease = CreateCharacter("Darcy Pease");
        public readonly static Character BathildaSud = CreateCharacter("Bathilda Sud");
        public readonly static Character IdaHobson = CreateCharacter("Ida Hobson");
        public readonly static Character KynaSmythy = CreateCharacter("Kyna Smythy");
        public readonly static Character SolitaMaravan = CreateCharacter("Solita Maravan");
        public readonly static Character UstisMaravan = CreateCharacter("Ustis Maravan");
        public readonly static Character SterlingToddburry = CreateCharacter("Sterling Toddburry");
        public readonly static Character EthanToddburry = CreateCharacter("Ethan Toddburry");
        public readonly static Character ChristinaBartel = CreateCharacter("Christina Bartel");
        public readonly static Character EricaToddburry = CreateCharacter("Erica Toddburry");
        public readonly static Character FatherJoshuaTalbot = CreateCharacter("Father Joshua Talbot");
        public readonly static Character NormalKervil = CreateCharacter("Normal Kervil");
        public readonly static Character NeolaCaraway = CreateCharacter("Neola Caraway");
        public readonly static Character SilasArcher = CreateCharacter("Silas Archer");
        public readonly static Character VioletArcher = CreateCharacter("Violet Archer");
        public readonly static Character PenelopeArcher = CreateCharacter("Penelope Archer");
        public readonly static Character ElwinHobson = CreateCharacter("Elwin Hobson");
        public readonly static Character TildaMayberry = CreateCharacter("Tilda Mayberry");
        public readonly static Character FreedaMayberry = CreateCharacter("Freeda Mayberry");
        public readonly static Character BerwinHedgewick = CreateCharacter("Berwin Hedgewick");
        public readonly static Character LenorHedgewick = CreateCharacter("Lenor Hedgewick");
        public readonly static Character LobeliaTarner = CreateCharacter("Lobelia Tarner");
        public readonly static Character RaeSoddenter = CreateCharacter("Rae Soddenter");
        public readonly static Character ParvisSoddenter = CreateCharacter("Parvis Soddenter");
        public readonly static Character LeeHeatherby = CreateCharacter("Lee Heatherby");
        public readonly static Character MargaretHeatherby = CreateCharacter("Margaret Heatherby");
        public readonly static Character TobaisKenkiny = CreateCharacter("Tobais Kenkiny");
        public readonly static Character DesmaKenkiny = CreateCharacter("Desma Kenkiny");
        public readonly static Character LadyEstelleWeathermayGodefroy = CreateCharacter("Lady Estelle Weathermay Godefroy");
        public readonly static Character LiliaGodefroy = CreateCharacter("Penelope Godefroy", "Lilia Godefroy");
        public readonly static Character PenelopeGodefroy = LiliaGodefroy;
        public readonly static Character GoodmanMorris = CreateCharacter("Goodman Morris");
        public readonly static Character LordRenier = CreateCharacter("Lord Renier");
        public readonly static Character VoglerKervil = CreateCharacter("Vogler Kervil");
        public readonly static Character Marston = CreateCharacter("Marston");
        public readonly static Character Ellie = CreateCharacter("Ellie");
        public readonly static Character AxtelBartel = CreateCharacter("Axtel Bartel");
        public readonly static Character BarthKleinen = CreateCharacter("Barth Kleinen");
        public readonly static Character PercivalSud = CreateCharacter("Percival Sud");
        public readonly static Character HargelGrummsh = CreateCharacter("Hargel Grummsh");
        public readonly static Character EismanKhargug = CreateCharacter("Eisman Khargug");
        public readonly static Character CoriemonHandlet = CreateCharacter("Coriemon Handlet");
        public readonly static Character GorbaghSnarltooth = CreateCharacter("Gorbagh Snarltooth");
        public readonly static Character GastonImrad = CreateCharacter("Gaston Imrad");
        public readonly static Character SheclkeDuskman = CreateCharacter("Sheclke Duskman");
        public readonly static Character ArlieEsterbridge = CreateCharacter("Arlie Esterbridge");
        public readonly static Character CarlRamm = CreateCharacter("Carl Ramm");
        public readonly static Character TandleCoreystal = CreateCharacter("Tandle Coreystal");
        public readonly static Character EllenStinworthy = CreateCharacter("Ellen Stinworthy");
        public readonly static Character KarenEdgerton = CreateCharacter("Karen Edgerton");
        public readonly static Character Sshhisthulhuu = CreateCharacter("Sshhisthulhuu");
        public readonly static Character WinifredKleinen = CreateCharacter("Winifred Kleinen");
        public readonly static Character BridgetDumas = CreateCharacter("Bridget Dumas");
        public readonly static Character BaronFielders = CreateCharacter("Baron Fielders", "Baron Fielding");
        public readonly static Character BaronessFielders = CreateCharacter("Baroness Fielders", "Baroness Fielding");
        public readonly static Character LadyFielders = CreateCharacter("Lady Fielders", "Lady Fielding");
        public readonly static Character Lucifer = CreateCharacter("Lucifer");
        public readonly static Character EmmaKelley = CreateCharacter("Emma Kelley");
        public readonly static Character Tintantilus = CreateCharacter("Tintantilus");
        public readonly static Character CharityBliss = CreateCharacter("Charity Bliss");
        public readonly static Character ThadeusMontBreezar = CreateCharacter("Thadeus the Magnificent", "Thadeus Mont Breezar");
        public readonly static Character MystiTokana = CreateCharacter("Mysti Tokana");
        public readonly static Character AmarBoriSandflinger = CreateCharacter("Amar Bori Sandflinger");
        public readonly static Character RogoldGildenman = CreateCharacter("Rogold Gildenman");
        public readonly static Character Barnabas = CreateCharacter("Barnabas");
        public readonly static Character PhillipeDelamana = CreateCharacter("Phillipe Delamana");
        public readonly static Character Rembrania = CreateCharacter("Rembrania");
        public readonly static Character BrendaCrimsonBlade = CreateCharacter("Brenda of the Crimson Blade");
        public readonly static Character Sugartooth = CreateCharacter("Sugartooth");
        public readonly static Character BrotherSummer = CreateCharacter("Kregash Garzaala", "Brother Summer");
        public readonly static Character Muffin = CreateCharacter("Muffin");
        public readonly static Character TGRedanto = CreateCharacter("Terribly Good Redanto", "T.G. Redanto");
        public readonly static Character Apricot = CreateCharacter("Apricot");
        public readonly static Character MikhailYelkif = CreateCharacter("Mikhail Yelkif");
        public readonly static Character Trellgaard = CreateCharacter("Trellgaard");
        public readonly static Character MasterIlmen = CreateCharacter("Master Ilmen");
        public readonly static Character CaareyGelthik = CreateCharacter("Caarey Gelthik");
        public readonly static Character SeanTimothy = CreateCharacter("Sean Timothy");
        public readonly static Character JerimyEstmore = CreateCharacter("Jerimy Estmore");
        public readonly static Character MasterTangle = CreateCharacter("Master Tangle");
        public readonly static Character WrenThims = CreateCharacter("Wren Thims");
        public readonly static Character SharonTeece = CreateCharacter("Sharon Teece");
        public readonly static Character MollyGrayswit = CreateCharacter("Molly Grayswit");
        public readonly static Character Stelwaard = CreateCharacter("Stelwaard");
        public readonly static Character ThinnBalder = CreateCharacter("Thinn Balder");
        public readonly static Character BadderGhastling = CreateCharacter("Badder Ghastling");
        public readonly static Character EstherTimothy = CreateCharacter("Esther Timothy", "Ester Timothy");
        public readonly static Character GeamPelstap = CreateCharacter("Geam Pelstap");
        public readonly static Character MaquirLoft = CreateCharacter("Maquir Loft");
        public readonly static Character MirandaLangstry = CreateCharacter("Miranda Langstry");
        public readonly static Character KelmanOsterlaker = CreateCharacter("Kelman Osterlaker");
        public readonly static Character FionaMatheson = CreateCharacter("Fiona Matheson");
        public readonly static Character Fanerath = CreateCharacter("Fanerath");
        public readonly static Character Hellinken = CreateCharacter("Hellinken");
        public readonly static Character KattleLisbury = CreateCharacter("Kattle Lisbury");
        public readonly static Character EmoryMaus = CreateCharacter("Emory Maus");
        public readonly static Character MarcusLithe = CreateCharacter("Marcus Lithe");
        public readonly static Character NendrumSintel = CreateCharacter("Nendrum Sintel");
        public readonly static Character ThellactinMianns = CreateCharacter("Thellactin Mianns");
        public readonly static Character KellyDuncan = CreateCharacter("Kelly Duncan");
        public readonly static Character CheldonIllcome = CreateCharacter("Cheldon Illcome");
        public readonly static Character Mythrel = CreateCharacter("Mythrel");
        public readonly static Character MillicentHodgson = CreateCharacter("Millicent Hodgson");
        public readonly static Character NatterlyKnutnor = CreateCharacter("Natterly Knutnor");
        public readonly static Character EowinTimothy = CreateCharacter("Eowin Timothy");
        public readonly static Character MomsinAlenny = CreateCharacter("Momsin Alenny");
        public readonly static Character ShingolTann = CreateCharacter("Shingol Tann");
        public readonly static Character LarsonChelf = CreateCharacter("Larson Chelf");
        public readonly static Character YettergunFolie = CreateCharacter("Yettergun Folie");
        public readonly static Character LeslieKale = CreateCharacter("Leslie Kale");
        public readonly static Character GeorgeWeathermay = CreateCharacter("George Weathermay");
        public readonly static Character Perseus = CreateCharacter("Perseus");
        public readonly static Character HenryLeighton = CreateCharacter("Henry Leighton", "Henry Weathermay");
        public readonly static Character ElizabethWeathermay = CreateCharacter("Elizabeth Weathermay");
        public readonly static Character PrudenceWeathermay = CreateCharacter("Prudence Weathermay");
        public readonly static Character TorrenceSeabag = CreateCharacter("Torrence Seabag");
        public readonly static Character VivianSeabag = CreateCharacter("Vivian Seabag");
        public readonly static Character DonaldSherwood = CreateCharacter("Donald Sherwood");
        public readonly static Character HelenSeabag = CreateCharacter("Helen Seabag");
        public readonly static Character JulesWeathermay = CreateCharacter("Jules Weathermay");
        public readonly static Character MarthaScoville = CreateCharacter("Martha Scoville Weathermay");
        public readonly static Character AliceWeathermay = CreateCharacter("Alice Weathermay");
        public readonly static Character DanielFoxgrove = CreateCharacter("Daniel Foxgrove");
        #endregion

        #region Nebligtode
        public readonly static Character Garvyn = CreateCharacter("Captain Garvyn");
        public readonly static Character Killian = CreateCharacter("Captain Killian");
        public readonly static Character Brummett = CreateCharacter("Brummett"); //1st Mate
        public readonly static Character CharlotteReisland = CreateCharacter("Charlotte Reisland");
        public readonly static Character Ralfeo = CreateCharacter("Ralfeo"); //2nd Mate
        public readonly static Character Koresh = CreateCharacter("Koresh"); //Gunner
        public readonly static Character Peregrine = CreateCharacter("Peregrine"); //Navigator
        public readonly static Character Thorvid = CreateCharacter("Thorvid"); //Carpenter
        public readonly static Character Jacob = CreateCharacter("Jacob");
        public readonly static Character Basil = CreateCharacter("Basil"); //Cook
        public readonly static Character Hugo = CreateCharacter("Hugo"); //Crewman
        public readonly static Character MadelineStern = CreateCharacter("Madeline Stern");
        public readonly static Character Morvan = CreateCharacter("Morvan");
        public readonly static Character KarlReisland = CreateCharacter("Karl Reisland");
        public readonly static Character LouisaReisland = CreateCharacter("Louisa Reisland");
        public readonly static Character Graben = CreateCharacter("Graben");
        public readonly static Character HorstGraben = CreateCharacter("Horst Graben");
        public readonly static Character LucretiaGraben = CreateCharacter("Lucretia Graben"); //Midwife
        public readonly static Character MiriamBrote = CreateCharacter("Miriam Brote"); //Baker
        public readonly static Character HarvidFleischer = CreateCharacter("Harvid Fleischer"); //Butcher
        public readonly static Character Jeremiah = CreateCharacter("Jeremiah");
        public readonly static Character MargaretAckerman = CreateCharacter("Margaret Ackerman");
        public readonly static Character HiramAckerman = CreateCharacter("Hiram Ackerman");
        public readonly static Character PieterFischer = CreateCharacter("Pieter Fischer");
        public readonly static Character LarsStromm  = CreateCharacter("Lars Stromm");
        public readonly static Character BarnabasVincent  = CreateCharacter("Barnabas Vincent");
        public readonly static Character HansMueller  = CreateCharacter("Hans Mueller");
        public readonly static Character MarcusGwynn  = CreateCharacter("Marcus Gwynn");
        public readonly static Character VanceStellen  = CreateCharacter("Vance Stellen");
        public readonly static Character ColinGraben  = CreateCharacter("Colin Graben");

        public readonly static Character EzekielGraben  = CreateCharacter("Ezekiel Graben");
        public readonly static Character MariettaGraben  = CreateCharacter("Marietta Graben");
        public readonly static Character MatthiasGraben  = CreateCharacter("Matthias Graben");
        public readonly static Character DanarGraben  = CreateCharacter("Danar Graben");
        public readonly static Character MetanGraben  = CreateCharacter("Metan Graben");
        public readonly static Character KuganGraben  = CreateCharacter("Kugan Graben");
        public readonly static Character GeneelGraben  = CreateCharacter("Geneel Graben");
        public readonly static Character MavisGraben  = CreateCharacter("Mavis Graben");

        public readonly static Character DriddamGraben  = CreateCharacter("Driddam Graben");
        public readonly static Character StymarGraben  = CreateCharacter("Stymar Graben");
        public readonly static Character ArabyGraben  = CreateCharacter("Araby Graben");
        public readonly static Character ElenaGraben  = CreateCharacter("Elena Graben");
        public readonly static Character RosaleeGraben  = CreateCharacter("Rosalee Graben");
        public readonly static Character BlaineGraben  = CreateCharacter("Blaine Graben");
        public readonly static Character Nestor  = CreateCharacter("Nestor");
        public readonly static Character OlsainGraben = CreateCharacter("Olsain Graben");
        #endregion

        #region Nova Vaasa
        public readonly static Character PrinceOthmar = CreateCharacter("Prince Othmar");
        #endregion

        #region Paridon
        public readonly static Character SirEdmundBloodsworth = CreateCharacter("Sir Edmund Bloodsworth");
        #endregion

        #region Richemulot
        public readonly static Character HenriDuBois = CreateCharacter("Henri DuBois");
        public readonly static Character IsabelleMoseau = CreateCharacter("Isabelle Moseau");
        public readonly static Character AnaisRenier = CreateCharacter("Anais Isabelle Renier");
        public readonly static Character HenriMilette = CreateCharacter("Henri Milette");
        public readonly static Character JoelleMilette = CreateCharacter("Joelle Isabelle Milette");
        public readonly static Character GregoireAlairan = CreateCharacter("Gregoire Alairan");
        public readonly static Character MauriceMilette = CreateCharacter("Maurice Milette");
        public readonly static Character EliseDeLauren = CreateCharacter("Elise DeLauren");

        public readonly static Character MarieRenier = CreateCharacter("Marie Isabelle Renier");
        public readonly static Character SimonAudaire = CreateCharacter("Simon Audaire");
        public readonly static Character AntionetteRenier = CreateCharacter("Antionette Isabelle Renier");
        public readonly static Character LaurrentHaurie = CreateCharacter("Laurrent Haurie");
        public readonly static Character DominicSoufel = CreateCharacter("Dominic Soufel");
        public readonly static Character JacquesRenier = CreateCharacter("Jacques Renier");
        public readonly static Character LouiseRenier = CreateCharacter("Louise Isabelle Renier");
        public readonly static Character RaulRenier = CreateCharacter("Raul Renier");
        public readonly static Character GertrudeVonZarovich = CreateCharacter("Gertrude Von Zarovich");

        public readonly static Character EduardoRenier = CreateCharacter("Eduardo Renier");
        public readonly static Character MargueritePentarde = CreateCharacter("Marguerite Pentarde");
        public readonly static Character PierreRenier = CreateCharacter("Pierre Pentarde");
        public readonly static Character GerardRenier = CreateCharacter("Gerard Pentarde");
        public readonly static Character SandrineDaugeri = CreateCharacter("Sandrine Daugeri");
        #endregion

        #region Sebua
        public readonly static Character Khamose = CreateCharacter("Khamose");
        public readonly static Character Nufreri = CreateCharacter("Nufreri");
        public readonly static Character Zordenahkt = CreateCharacter("Zordenahkt");
        public readonly static Character Apophis = CreateCharacter("Apophis");
        public readonly static Character Anubis = CreateCharacter("Anubis");
        public readonly static Character Osiris = CreateCharacter("Osiris");
        public readonly static Character Maat = CreateCharacter("Maat");
        #endregion

        #region Shadowborn Manor
        public readonly static Character KateriShadowborn = CreateCharacter("Lady Kateri Shadowborn");
        #endregion

        #region Sithicus
        public readonly static Character Kitiara = CreateCharacter("Kitiara");
        public readonly static Character SothSteed = CreateCharacter("Soth's Steed");
        #endregion

        #region Sri Raji / Kalakeri
        public readonly static Character Kali = CreateCharacter("Kali");
        public readonly static Character Rudra = CreateCharacter("Rudra");
        public readonly static Character Shiva = CreateCharacter("Shiva");
        public readonly static Character Ravana = CreateCharacter("Ravana");
        public readonly static Character Yama = CreateCharacter("Yama");
        #endregion

        #region Souragne
        public readonly static Character LarissaSnowmane = CreateCharacter("Larissa Snowmane");
        #endregion

        #region Tepest
        public readonly static Character RudellaMindefisk = CreateCharacter("Rudella Mindefisk");
        public readonly static Character HolgerMindefisk = CreateCharacter("Holger Mindefisk");
        #endregion

        #region Valachan
        public readonly static Character Felkovic = CreateCharacter("Felkovic");
        public readonly static Character Morphayus = CreateCharacter("Morphayus");
        public readonly static Character Selena = CreateCharacter("Selena");
        #endregion

        #region Verbrek
        public readonly static Character WolfGod = CreateCharacter("Wolf God");
        #endregion

        #region Vorostokov
        public readonly static Character Ireena = CreateCharacter("Ireena");
        public readonly static Character Nicolai = CreateCharacter("Nicolai");
        public readonly static Character AntoninaZolnik = CreateCharacter("Antonina Zolnik");
        public readonly static Character NatalyaZolnik = CreateCharacter("Natalya Zolnik");
        public readonly static Character ElenaZolnik = CreateCharacter("Elena Zolnik");
        public readonly static Character MarikMouseEater = CreateCharacter("Marik the Mouse-eater");
        #endregion

        #region Winding Road
        #endregion

        #region Inside Ravenloft
        public readonly static Character Keesla = CreateCharacter("Keesla");
        public readonly static Character EleazerClyde = CreateCharacter("EleazerClyde");
        public readonly static Character TLaan = CreateCharacter("T`Laan", "Dorin");
        public readonly static Character MorganDarkdawn = CreateCharacter("MorganDarkdawn");
        public readonly static Character TarlVanovitch = CreateCharacter("Tarl Vanovitch");
        public readonly static Character Quebe = CreateCharacter("Quebe");
        public readonly static Character HoelgarArnutsson = CreateCharacter("Hoelgar Arnutsson");
        public readonly static Character RafeWillowand = CreateCharacter("Rafe Willowand");
        public readonly static Character Lathander = CreateCharacter("Lathander");
        public readonly static Character Almen = CreateCharacter("Almen");
        public readonly static Character Leilana = CreateCharacter("Leilana");
        public readonly static Character BrightGaelea = CreateCharacter("Bright Gaelea");
        public readonly static Character ThaedranMeridian = CreateCharacter("Thaedran Meridian");
        public readonly static Character DevanCory = CreateCharacter("Devan Cory");
        public readonly static Character MasterEliasSturn = CreateCharacter("Master Elias Sturn");
        public readonly static Character Tavelia = CreateCharacter("Tavelia");
        public readonly static Character MelykurionRaven = CreateCharacter("Melykurion of the Raven");
        public readonly static Character HannibilRaven = CreateCharacter("Hannibil of the Raven");
        public readonly static Character MarkRaven = CreateCharacter("Mark of the Raven");
        public readonly static Character CastellanPietor = CreateCharacter("Castellan Pietor");
        public readonly static Character StefanDyreth = CreateCharacter("Stefan Dyreth");
        public readonly static Character KaraliJenei = CreateCharacter("Karali Jenei");
        public readonly static Character WeeJas = CreateCharacter("Wee Jas");
        public readonly static Character Vashtar = CreateCharacter("Vashtar");
        public readonly static Character Tithion = CreateCharacter("Tithion");
        public readonly static Character Seldain = CreateCharacter("Seldain");
        public readonly static Character PatronArabel = CreateCharacter("Patron Arabel", "Father Arabel");
        public readonly static Character Brindletople = CreateCharacter("Brindletople");
        public readonly static Character JaraqTheDeceiver = CreateCharacter("Jaraq the Deceiver");
        public readonly static Character GhostlyPiper = CreateCharacter("Ghostly Piper");
        public readonly static Character TheRedDeath = CreateCharacter("The Red Death");
        public readonly static Character RedJack = CreateCharacter("Red Jack");
        public readonly static Character RedTide = CreateCharacter("Red Tide");
        public readonly static Character ChantalBanshee = CreateCharacter("Chantal the Banshee");
        public readonly static Character Iseult = CreateCharacter("Iseult");
        public readonly static Character Pearl = CreateCharacter("Pearl");
        public readonly static Character Amber = CreateCharacter("Amber");
        public readonly static Character Aquamarina = CreateCharacter("Aquamarina");
        public readonly static Character TingLing = CreateCharacter("Ting Ling");
        public readonly static Character BrideOfMalice = CreateCharacter("Bride of Malice");
        public readonly static Character VultureOfTheCore = CreateCharacter("Vulture of the Core");
        public readonly static Character TheBogMonster = CreateCharacter("The Bog Monster");
        public readonly static Character NemonHotep = CreateCharacter("Nemon Hotep");
        public readonly static Character SheraTheWise = CreateCharacter("Shera the Wise");
        public readonly static Character VarneyTheVampire = CreateCharacter("Varney the Vampire");
        public readonly static Character GibLhadsemlo = CreateCharacter("Gib Lhadsemlo");
        public readonly static Character Vathan = CreateCharacter("Vathan");
        public readonly static Character Saul = CreateCharacter("Saul");
        public readonly static Character Vincenzia = CreateCharacter("Vincenzia");
        public readonly static Character Claudia = CreateCharacter("Claudia");
        #endregion
    }
}