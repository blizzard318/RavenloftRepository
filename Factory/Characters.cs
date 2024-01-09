using Humanizer;
using System.Diagnostics.Metrics;
using static Factory.ItemEnum;

public partial class Factory : IDisposable
{
    internal static class CharacterEnum
    {
        private static NPC CreateCharacter(params string[] names)
        {
            var retval = new NPC(names);
            Ravenloftdb.Characters.Add(retval);
            return retval;
        }
        #region Arkandale
        public readonly static NPC NataliaVhorishkova = CreateCharacter("Natalia Vhorishkova");
        #endregion

        #region Barovia
        public readonly static NPC CountStrahd = CreateCharacter("Count Strahd von Zarovich");
        public readonly static NPC IreenaKolyana = CreateCharacter("Ireena Kolyana");
        public readonly static NPC Tatyana = CreateCharacter("Tatyana");
        public readonly static NPC FatherDonavich = CreateCharacter("Father Donavich");
        public readonly static NPC KingBarov = CreateCharacter("King Barov von Zarovich");
        public readonly static NPC Ravenovia = CreateCharacter("Queen Ravenovia von Zarovich");
        public readonly static NPC Sergei = CreateCharacter("Sergei von Zarovich");
        public readonly static NPC MadamEva = CreateCharacter("Madam Eva");
        public readonly static NPC LiefLipsiege = CreateCharacter("Lief Lipsiege");
        public readonly static NPC Helga = CreateCharacter("Helga");
        public readonly static NPC CyrusBelview = CreateCharacter("Cyrus Belview");
        public readonly static NPC SpectreAbCenteer = CreateCharacter("Spectre Ab-Centeer");
        public readonly static NPC ArtistaDeSlop = CreateCharacter("Artista DeSlop");
        public readonly static NPC LadyIsoldeYunk = CreateCharacter("Lady Isolde Yunk", "Isolde the Incredible");
        public readonly static NPC AerialDuPlumette = CreateCharacter("Aerial the Heavy", "Prince Aerial Du Plumette");
        public readonly static NPC ArtankSwilovich = CreateCharacter("Artank Swilovich");
        public readonly static NPC DorfniyaDilisny = CreateCharacter("Duchess Dorfniya Dilisnya");
        public readonly static NPC Pidlwik = CreateCharacter("Pidlwik");
        public readonly static NPC LeanneTriksky = CreateCharacter("Sir Lee the Crusher", "Sir Leanne Triksky");
        public readonly static NPC TashaPetrovna = CreateCharacter("Tasha Petrovna");
        public readonly static NPC KingToisky = CreateCharacter("King Toisky");
        public readonly static NPC KingIntreeKatsky = CreateCharacter("Katsky the Bright", "King Intree Katsky");
        public readonly static NPC StahbalIndiBhak = CreateCharacter("Stahbal Indi-Bhak");
        public readonly static NPC Khazan = CreateCharacter("Khazan");
        public readonly static NPC ElsaFallona = CreateCharacter("Elsa Fallona");
        public readonly static NPC SedrikSpinwitovich = CreateCharacter("Admiral Spinwitovich", "Sir Sedrik Spinwitovich");
        public readonly static NPC Animus = CreateCharacter("Animus");
        public readonly static NPC ErikVonderbucks = CreateCharacter("Sir Erik Vonderbucks");
        public readonly static NPC IvanDeRose = CreateCharacter("Ivan DeRose");
        public readonly static NPC StephanGregorovich = CreateCharacter("Stephan Gregorovich");
        public readonly static NPC IntreeSikValoo = CreateCharacter("Intree Sik-Valoo");
        public readonly static NPC ArdentPallette = CreateCharacter("Ardent Pallette");
        public readonly static NPC IvanIvanovich = CreateCharacter("Ivan Ivanovich");
        public readonly static NPC CirilRomulich = CreateCharacter("Prefect Ciril Romulich");
        public readonly static NPC Dollars = CreateCharacter("$$");
        public readonly static NPC Finderway = CreateCharacter("St. Finderway");
        public readonly static NPC Dostron = CreateCharacter("King Dostron");
        public readonly static NPC GralmoreNimblenobs = CreateCharacter("Gralmore Nimblenobs");
        public readonly static NPC AmericoStandardski = CreateCharacter("Americo Standardski");
        public readonly static NPC Beucephalus = CreateCharacter("Beucephalus");
        public readonly static NPC TatsaulEris = CreateCharacter("Tatsaul Eris");
        public readonly static NPC AnnaPetrovna = CreateCharacter("AnnaPetrovna");
        public readonly static NPC Arik = CreateCharacter("Arik");
        public readonly static NPC MaryaMarkovia = CreateCharacter("Marya Markovia");
        public readonly static NPC Endorovich = CreateCharacter("Endorovich the Terrible");
        public readonly static NPC SashaIvliskova = CreateCharacter("Sasha Ivliskova");
        public readonly static NPC PatrinaVelikovna = CreateCharacter("Patrina Velikovna");
        public readonly static NPC KolyanIndirovich = CreateCharacter("Kolyan Indirovich");
        public readonly static NPC Ismark = CreateCharacter("Ismark the Lesser");
        public readonly static NPC MadMary = CreateCharacter("Mad Mary");
        public readonly static NPC Gertruda = CreateCharacter("Gertruda");
        public readonly static NPC Bildrath = CreateCharacter("Bildrath");
        public readonly static NPC Parriwimple = CreateCharacter("Parriwimple");
        public readonly static NPC GuardianOfSorrow = CreateCharacter("Guardian of Sorrow");
        public readonly static NPC BabaLysaga = CreateCharacter("Baba Lysaga");
        public readonly static NPC Mikhash = CreateCharacter("Mikhash");
        public readonly static NPC JerenSureblade = CreateCharacter("Jeren Sureblade");
        public readonly static NPC JanderSunstar = CreateCharacter("Jander Sunstar");
        public readonly static NPC Bilkon = CreateCharacter("Bilkon");
        public readonly static NPC Burganet = CreateCharacter("Burganet");
        public readonly static NPC TheodoricTheBook = CreateCharacter("Theodoric the Book");
        #endregion

        #region Blaustein
        public readonly static NPC Bluebeard = CreateCharacter("Bluebeard");
        #endregion

        #region Bluetspur
        public readonly static NPC HighMasterIllithid = CreateCharacter("High Master Illithid");
        #endregion

        #region Borca
        public readonly static NPC DuralIronHills = CreateCharacter("Dural of the Iron Hills");
        public readonly static NPC Vadarin = CreateCharacter("Vadarin");
        public readonly static NPC IvanaBoritsi = CreateCharacter("Ivana Boritsi");
        #endregion

        #region Cavitius
        public readonly static NPC Vecna = CreateCharacter("Vecna");
        #endregion

        #region Daglan
        public readonly static NPC Daglan = CreateCharacter("Daglan");
        #endregion

        #region Darkon
        public readonly static NPC AzalinRex = CreateCharacter("Azalin Rex");
        public readonly static NPC Clarke = CreateCharacter("Clarke");
        public readonly static NPC Phillips = CreateCharacter("Phillips");
        public readonly static NPC HowardAshton = CreateCharacter("Howard Ashton");
        public readonly static NPC MarionRobinsdottir = CreateCharacter("Marion Robinsdottir");
        public readonly static NPC Mazrikoth = CreateCharacter("Mazrikoth");
        public readonly static NPC AlanikRay = CreateCharacter("Alanik Ray");
        public readonly static NPC DorothaKenig = CreateCharacter("Dorotha Kenig");
        public readonly static NPC GilesBowman = CreateCharacter("Giles the Bowman");
        public readonly static NPC RatikUbel = CreateCharacter("Ratik Ubel");
        public readonly static NPC DoctorRudolphVanRichten = CreateCharacter("Doctor Rudolph Van Richten");
        public readonly static NPC KaleenCorigrave = CreateCharacter("Kaleen Corigrave");
        public readonly static NPC Tyr = CreateCharacter("Tyr");
        public readonly static NPC LatislavOfDarkon = CreateCharacter("Latislav of Darkon");
        #endregion

        #region Falkovnia
        public readonly static NPC VladDrakov = CreateCharacter("Vlad Drakov");
        public readonly static NPC SymbukTorul = CreateCharacter("Symbuk Torul");
        public readonly static NPC Killeen = CreateCharacter("Killeen");
        public readonly static NPC Kevlin = CreateCharacter("Kevlin");
        public readonly static NPC Knightengale = CreateCharacter("Knightengale");
        public readonly static NPC Gondegal = CreateCharacter("Gondegal");
        #endregion

        #region G'Henna
        public readonly static NPC Zhakata = CreateCharacter("Zhakata");
        public readonly static NPC YagnoPetrovna = CreateCharacter("Yagno Petrovna");
        #endregion

        #region Ghastria
        public readonly static NPC StezenDPolarno = CreateCharacter("Stezen D`Polarno");
        #endregion

        #region Gundarak
        public readonly static NPC BonnieLee = CreateCharacter("Bonnie Lee");
        public readonly static NPC LordGundar = CreateCharacter("Lord Gundar");
        #endregion

        #region Har'Akir
        public readonly static NPC Anhktepot = CreateCharacter("Anhktepot");
        public readonly static NPC Senmet = CreateCharacter("Senmet");
        public readonly static NPC Trisler = CreateCharacter("Trisler");
        #endregion

        #region Hazlan
        public readonly static NPC Hazlik = CreateCharacter("Hazlik");
        #endregion

        #region Invidia
        public readonly static NPC GabrielleAderre = CreateCharacter("Gabrielle Aderre");
        #endregion

        #region Kartakass
        public readonly static NPC HarkonLukas = CreateCharacter("Harkon Lukas");
        public readonly static NPC Nhalvaen = CreateCharacter("Nhalvaen");
        public readonly static NPC Milil = CreateCharacter("Milil");
        public readonly static NPC MeistersingerCasimiar = CreateCharacter("Meistersinger Casimir Lukas");
        #endregion

        #region Klorr
        public readonly static NPC Klorr = CreateCharacter("Klorr");
        #endregion

        #region Lamordia
        public readonly static NPC DoctorAugustus = CreateCharacter("Doctor Augustus");
        public readonly static NPC NurseRoberts = CreateCharacter("Nurse Roberts");
        public readonly static NPC KatrinaVonBrandthofen = CreateCharacter("Katrina Von Brandthofen");
        public readonly static NPC DoctorVictorMordenheim = CreateCharacter("Doctor Victor Mordenheim");
        public readonly static NPC Adam = CreateCharacter("Adam");
        public readonly static NPC Eva = CreateCharacter("Eva");
        #endregion

        #region Liffe
        public readonly static NPC BaronLyronEvensong = CreateCharacter("Baron Lyron Evensong");
        #endregion

        #region Markovia
        public readonly static NPC Ludmilla = CreateCharacter("Ludmilla");
        public readonly static NPC FrantisekMarkov = CreateCharacter("Frantisek Markov");
        public readonly static NPC JurgenVastish = CreateCharacter("Jurgen Vastish");
        #endregion

        #region Mordent
        public readonly static NPC LadyWeathermay = CreateCharacter("Lady Virginia Anne Weathermay");
        public readonly static NPC OldLadyWeathermay = CreateCharacter("Lady Weathermay");
        public readonly static NPC LordWeathermay = CreateCharacter("Lord Byron Merril Weathermay");
        public readonly static NPC MistressArdent = CreateCharacter("Mistress Ysilda Gemanine Ardent");
        public readonly static NPC Germain = CreateCharacter("Docteur Germain d'Honaire");
        public readonly static NPC Marion = CreateCharacter("Marion Atwater");
        public readonly static NPC Dominic = CreateCharacter("Dominic");
        public readonly static NPC Luker = CreateCharacter("Luker");
        public readonly static NPC CavelWarden = CreateCharacter("Cavel Warden");
        public readonly static NPC KedarKlienan = CreateCharacter("Kedar Klienan");
        public readonly static NPC Justinian = CreateCharacter("Justinian");
        public readonly static NPC Honorius = CreateCharacter("Honorius");
        public readonly static NPC Carlisle = CreateCharacter("Carlisle");
        public readonly static NPC BrennaRaven = CreateCharacter("Brenna Raven");
        public readonly static NPC TabbFinhallen = CreateCharacter("Tabb Finhallen");
        public readonly static NPC KirkTerrinton = CreateCharacter("Kirk Terrinton");
        public readonly static NPC MayorMalvinHeatherby = CreateCharacter("Mayor Malvin Heatherby");
        public readonly static NPC TylerSmythy = CreateCharacter("Tyler Smythy");
        public readonly static NPC GregorBoyd = CreateCharacter("Gregor Boyd");
        public readonly static NPC GlennaWarden = CreateCharacter("Glenna Warden");
        public readonly static NPC Gwydion = CreateCharacter("Gwydion");
        public readonly static NPC GastonHedgewick = CreateCharacter("Gaston Hedgewick");
        public readonly static NPC ArianaBartel = CreateCharacter("Ariana Bartel");
        public readonly static NPC CarinaLoch = CreateCharacter("Carina Loch");
        public readonly static NPC DarcyPease = CreateCharacter("Darcy Pease");
        public readonly static NPC BathildaSud = CreateCharacter("Bathilda Sud");
        public readonly static NPC IdaHobson = CreateCharacter("Ida Hobson");
        public readonly static NPC KynaSmythy = CreateCharacter("Kyna Smythy");
        public readonly static NPC SolitaMaravan = CreateCharacter("Solita Maravan");
        public readonly static NPC UstisMaravan = CreateCharacter("Ustis Maravan");
        public readonly static NPC SterlingToddburry = CreateCharacter("Sterling Toddburry");
        public readonly static NPC EthanToddburry = CreateCharacter("Ethan Toddburry");
        public readonly static NPC ChristinaBartel = CreateCharacter("Christina Bartel");
        public readonly static NPC EricaToddburry = CreateCharacter("Erica Toddburry");
        public readonly static NPC FatherJoshuaTalbot = CreateCharacter("Father Joshua Talbot");
        public readonly static NPC NormalKervil = CreateCharacter("Normal Kervil");
        public readonly static NPC NeolaCaraway = CreateCharacter("Neola Caraway");
        public readonly static NPC SilasArcher = CreateCharacter("Silas Archer");
        public readonly static NPC VioletArcher = CreateCharacter("Violet Archer");
        public readonly static NPC PenelopeArcher = CreateCharacter("Penelope Archer");
        public readonly static NPC ElwinHobson = CreateCharacter("Elwin Hobson");
        public readonly static NPC TildaMayberry = CreateCharacter("Tilda Mayberry");
        public readonly static NPC FreedaMayberry = CreateCharacter("Freeda Mayberry");
        public readonly static NPC BerwinHedgewick = CreateCharacter("Berwin Hedgewick");
        public readonly static NPC LenorHedgewick = CreateCharacter("Lenor Hedgewick");
        public readonly static NPC LobeliaTarner = CreateCharacter("Lobelia Tarner");
        public readonly static NPC RaeSoddenter = CreateCharacter("Rae Soddenter");
        public readonly static NPC ParvisSoddenter = CreateCharacter("Parvis Soddenter");
        public readonly static NPC LeeHeatherby = CreateCharacter("Lee Heatherby");
        public readonly static NPC MargaretHeatherby = CreateCharacter("Margaret Heatherby");
        public readonly static NPC TobaisKenkiny = CreateCharacter("Tobais Kenkiny");
        public readonly static NPC DesmaKenkiny = CreateCharacter("Desma Kenkiny");
        public readonly static NPC LordWilfredGodefroy = CreateCharacter("Lord Wilfred Godefroy");
        public readonly static NPC LadyEstelleWeathermayGodefroy = CreateCharacter("Lady Estelle Weathermay Godefroy");
        public readonly static NPC PenelopeGodefroy = CreateCharacter("Penelope Godefroy", "Lilia Godefroy");
        public readonly static NPC LiliaGodefroy = CreateCharacter("Penelope Godefroy", "Lilia Godefroy");
        public readonly static NPC GoodmanMorris = CreateCharacter("Goodman Morris");
        public readonly static NPC LordRenier = CreateCharacter("Lord Renier");
        public readonly static NPC VoglerKervil = CreateCharacter("Vogler Kervil");
        public readonly static NPC Marston = CreateCharacter("Marston");
        public readonly static NPC Ellie = CreateCharacter("Ellie");
        public readonly static NPC AxtelBartel = CreateCharacter("Axtel Bartel");
        public readonly static NPC BarthKleinen = CreateCharacter("Barth Kleinen");
        public readonly static NPC PercivalSud = CreateCharacter("Percival Sud");
        public readonly static NPC HargelGrummsh = CreateCharacter("Hargel Grummsh");
        public readonly static NPC EismanKhargug = CreateCharacter("Eisman Khargug");
        public readonly static NPC CoriemonHandlet = CreateCharacter("Coriemon Handlet");
        public readonly static NPC GorbaghSnarltooth = CreateCharacter("Gorbagh Snarltooth");
        public readonly static NPC GastonImrad = CreateCharacter("Gaston Imrad");
        public readonly static NPC SheclkeDuskman = CreateCharacter("Sheclke Duskman");
        public readonly static NPC ArlieEsterbridge = CreateCharacter("Arlie Esterbridge");
        public readonly static NPC CarlRamm = CreateCharacter("Carl Ramm");
        public readonly static NPC TandleCoreystal = CreateCharacter("Tandle Coreystal");
        public readonly static NPC EllenStinworthy = CreateCharacter("Ellen Stinworthy");
        public readonly static NPC KarenEdgerton = CreateCharacter("Karen Edgerton");
        public readonly static NPC Sshhisthulhuu = CreateCharacter("Sshhisthulhuu");
        public readonly static NPC WinifredKleinen = CreateCharacter("Winifred Kleinen");
        public readonly static NPC BridgetDumas = CreateCharacter("Bridget Dumas");
        public readonly static NPC BaronFielders = CreateCharacter("Baron Fielders", "Baron Fielding");
        public readonly static NPC BaronessFielders = CreateCharacter("Baroness Fielders", "Baroness Fielding");
        public readonly static NPC LadyFielders = CreateCharacter("Lady Fielders", "Lady Fielding");
        public readonly static NPC Lucifer = CreateCharacter("Lucifer");
        public readonly static NPC EmmaKelley = CreateCharacter("Emma Kelley");
        public readonly static NPC Tintantilus = CreateCharacter("Tintantilus");
        public readonly static NPC CharityBliss = CreateCharacter("Charity Bliss");
        public readonly static NPC ThadeusMontBreezar = CreateCharacter("Thadeus the Magnificent", "Thadeus Mont Breezar");
        public readonly static NPC MystiTokana = CreateCharacter("Mysti Tokana");
        public readonly static NPC AmarBoriSandflinger = CreateCharacter("Amar Bori Sandflinger");
        public readonly static NPC RogoldGildenman = CreateCharacter("Rogold Gildenman");
        public readonly static NPC Barnabas = CreateCharacter("Barnabas");
        public readonly static NPC PhillipeDelamana = CreateCharacter("Phillipe Delamana");
        public readonly static NPC Rembrania = CreateCharacter("Rembrania");
        public readonly static NPC BrendaCrimsonBlade = CreateCharacter("Brenda of the Crimson Blade");
        public readonly static NPC Sugartooth = CreateCharacter("Sugartooth");
        public readonly static NPC BrotherSummer = CreateCharacter("Kregash Garzaala", "Brother Summer");
        public readonly static NPC Muffin = CreateCharacter("Muffin");
        public readonly static NPC TGRedanto = CreateCharacter("Terribly Good Redanto", "T.G. Redanto");
        public readonly static NPC Apricot = CreateCharacter("Apricot");
        public readonly static NPC MikhailYelkif = CreateCharacter("Mikhail Yelkif");
        public readonly static NPC Trellgaard = CreateCharacter("Trellgaard");
        public readonly static NPC MasterIlmen = CreateCharacter("Master Ilmen");
        public readonly static NPC CaareyGelthik = CreateCharacter("Caarey Gelthik");
        public readonly static NPC SeanTimothy = CreateCharacter("Sean Timothy");
        public readonly static NPC JerimyEstmore = CreateCharacter("Jerimy Estmore");
        public readonly static NPC MasterTangle = CreateCharacter("Master Tangle");
        public readonly static NPC WrenThims = CreateCharacter("Wren Thims");
        public readonly static NPC SharonTeece = CreateCharacter("Sharon Teece");
        public readonly static NPC MollyGrayswit = CreateCharacter("Molly Grayswit");
        public readonly static NPC Stelwaard = CreateCharacter("Stelwaard");
        public readonly static NPC ThinnBalder = CreateCharacter("Thinn Balder");
        public readonly static NPC BadderGhastling = CreateCharacter("Badder Ghastling");
        public readonly static NPC EstherTimothy = CreateCharacter("Esther Timothy");
        public readonly static NPC GeamPelstap = CreateCharacter("Geam Pelstap");
        public readonly static NPC MaquirLoft = CreateCharacter("Maquir Loft");
        public readonly static NPC MirandaLangstry = CreateCharacter("Miranda Langstry");
        public readonly static NPC KelmanOsterlaker = CreateCharacter("Kelman Osterlaker");
        public readonly static NPC FionaMatheson = CreateCharacter("Fiona Matheson");
        public readonly static NPC Fanerath = CreateCharacter("Fanerath");
        public readonly static NPC Hellinken = CreateCharacter("Hellinken");
        public readonly static NPC KattleLisbury = CreateCharacter("Kattle Lisbury");
        public readonly static NPC EmoryMaus = CreateCharacter("Emory Maus");
        public readonly static NPC MarcusLithe = CreateCharacter("Marcus Lithe");
        public readonly static NPC NendrumSintel = CreateCharacter("Nendrum Sintel");
        public readonly static NPC ThellactinMianns = CreateCharacter("Thellactin Mianns");
        public readonly static NPC KellyDuncan = CreateCharacter("Kelly Duncan");
        public readonly static NPC CheldonIllcome = CreateCharacter("Cheldon Illcome");
        public readonly static NPC Mythrel = CreateCharacter("Mythrel");
        public readonly static NPC MillicentHodgson = CreateCharacter("Millicent Hodgson");
        public readonly static NPC NatterlyKnutnor = CreateCharacter("Natterly Knutnor");
        public readonly static NPC EowinTimothy = CreateCharacter("Eowin Timothy");
        public readonly static NPC MomsinAlenny = CreateCharacter("Momsin Alenny");
        public readonly static NPC ShingolTann = CreateCharacter("Shingol Tann");
        public readonly static NPC LarsonChelf = CreateCharacter("Larson Chelf");
        public readonly static NPC YettergunFolie = CreateCharacter("Yettergun Folie");
        public readonly static NPC LeslieKale = CreateCharacter("Leslie Kale");
        #endregion

        #region Nebligtode
        public readonly static NPC Meredoth = CreateCharacter("Meredoth");
        #endregion

        #region Nova Vaasa
        public readonly static NPC SirTristenHiregaard = CreateCharacter("Sir Tristen Hiregaard");
        #endregion

        #region Paridon
        public readonly static NPC SirEdmundBloodsworth = CreateCharacter("Sir Edmund Bloodsworth");
        #endregion

        #region Sebua
        public readonly static NPC Tiyet = CreateCharacter("Tiyet");
        #endregion

        #region Sithicus
        public readonly static NPC Kitiara = CreateCharacter("Kitiara");
        public readonly static NPC LordLorenSoth = CreateCharacter("Lord Loren Soth");
        #endregion

        #region Sri Raji / Kalakeri
        public readonly static NPC Arijani = CreateCharacter("Arijani");
        #endregion

        #region Souragne
        public readonly static NPC AntonMisroi = CreateCharacter("Anton Misroi");
        public readonly static NPC LarissaSnowmane = CreateCharacter("Larissa Snowmane");
        #endregion

        #region Valachan
        public readonly static NPC BaronUrikVonKharkov = CreateCharacter("Baron Urik von Kharkov");
        public readonly static NPC Felkovic = CreateCharacter("Felkovic");
        #endregion

        #region Winding Road
        public readonly static NPC HeadlessHorseman = CreateCharacter("The Headless Horseman");
        #endregion

        #region Inside Ravenloft
        public readonly static NPC EleazerClyde = CreateCharacter("EleazerClyde");
        public readonly static NPC TLaan = CreateCharacter("T`Laan");
        public readonly static NPC TarlVanovitch = CreateCharacter("Tarl Vanovitch");
        public readonly static NPC Quebe = CreateCharacter("Quebe");
        public readonly static NPC HoelgarArnutsson = CreateCharacter("Hoelgar Arnutsson");
        public readonly static NPC RafeWillowand = CreateCharacter("Rafe Willowand");
        public readonly static NPC Lathander = CreateCharacter("Lathander");
        public readonly static NPC Almen = CreateCharacter("Almen");
        public readonly static NPC Leilana = CreateCharacter("Leilana");
        public readonly static NPC BrightGaelea = CreateCharacter("Bright Gaelea");
        public readonly static NPC ThaedranMeridian = CreateCharacter("Thaedran Meridian");
        public readonly static NPC DevanCory = CreateCharacter("Devan Cory");
        public readonly static NPC MasterEliasSturn = CreateCharacter("Master Elias Sturn");
        public readonly static NPC Tavelia = CreateCharacter("Tavelia");
        public readonly static NPC MelykurionRaven = CreateCharacter("Melykurion of the Raven");
        public readonly static NPC HannibilRaven = CreateCharacter("Hannibil of the Raven");
        public readonly static NPC MarkRaven = CreateCharacter("Mark of the Raven");
        public readonly static NPC CastellanPietor = CreateCharacter("Castellan Pietor");
        public readonly static NPC StefanDyreth = CreateCharacter("Stefan Dyreth");
        public readonly static NPC KaraliJenei = CreateCharacter("Karali Jenei");
        public readonly static NPC WeeJas = CreateCharacter("Wee Jas");
        public readonly static NPC Vashtar = CreateCharacter("Vashtar");
        public readonly static NPC Tithion = CreateCharacter("Tithion");
        public readonly static NPC Seldain = CreateCharacter("Seldain");
        public readonly static NPC PatronArabel = CreateCharacter("Patron Arabel", "Father Arabel");
        public readonly static NPC Brindletople = CreateCharacter("Brindletople");
        public readonly static NPC JaraqTheDeceiver = CreateCharacter("Jaraq the Deceiver");
        public readonly static NPC GhostlyPiper = CreateCharacter("Ghostly Piper");
        public readonly static NPC TheRedDeath = CreateCharacter("The Red Death");
        public readonly static NPC ChantalBanshee = CreateCharacter("Chantal the Banshee");
        public readonly static NPC Iseult = CreateCharacter("Iseult");
        #endregion
    }
}