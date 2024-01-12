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
        public readonly static Character TaraKolyana = CreateCharacter("Tara Kolyana");
        public readonly static Character GoergeWeathermay = CreateCharacter("Goerge Weathermay");

        #region Arkandale
        public readonly static Character NataliaVhorishkova = CreateCharacter("Natalia Vhorishkova");
        #endregion

        #region Barovia
        public readonly static Character IreenaKolyana = CreateCharacter("Ireena Kolyana");
        public readonly static Character Tatyana = CreateCharacter("Tatyana");
        public readonly static Character FatherDonavich = CreateCharacter("Father Donavich");
        public readonly static Character KingBarov = CreateCharacter("King Barov von Zarovich");
        public readonly static Character Ravenovia = CreateCharacter("Queen Ravenovia von Zarovich");
        public readonly static Character Sergei = CreateCharacter("Sergei von Zarovich");
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
        #endregion

        #region Blaustein
        #endregion

        #region Bluetspur
        public readonly static Character HighMasterIllithid = CreateCharacter("High Master Illithid");
        #endregion

        #region Borca
        public readonly static Character DuralIronHills = CreateCharacter("Dural of the Iron Hills");
        public readonly static Character Vadarin = CreateCharacter("Vadarin");
        #endregion

        #region Cavitius
        #endregion

        #region Daglan
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
        #endregion

        #region Falkovnia
        public readonly static Character SymbukTorul = CreateCharacter("Symbuk Torul");
        public readonly static Character Killeen = CreateCharacter("Killeen");
        public readonly static Character Kevlin = CreateCharacter("Kevlin");
        public readonly static Character Knightengale = CreateCharacter("Knightengale");
        public readonly static Character Gondegal = CreateCharacter("Gondegal");
        #endregion

        #region G'Henna
        public readonly static Character Zhakata = CreateCharacter("Zhakata");
        #endregion

        #region Ghastria
        #endregion

        #region Gundarak
        public readonly static Character BonnieLee = CreateCharacter("Bonnie Lee");
        #endregion

        #region Har'Akir
        public readonly static Character Senmet = CreateCharacter("Senmet");
        public readonly static Character Trisler = CreateCharacter("Trisler");
        #endregion

        #region Hazlan
        public readonly static Character JulioMasterThief = CreateCharacter("Julio, Master Thief of Haslic", "Julio, Master Thief of Hazlan");
        #endregion

        #region Invidia
        #endregion

        #region Kartakass
        public readonly static Character Nhalvaen = CreateCharacter("Nhalvaen");
        public readonly static Character Milil = CreateCharacter("Milil");
        public readonly static Character MeistersingerCasimir = CreateCharacter("Meistersinger Casimir Lukas");
        #endregion

        #region Klorr
        #endregion

        #region Lamordia
        public readonly static Character DoctorAugustus = CreateCharacter("Doctor Augustus");
        public readonly static Character NurseRoberts = CreateCharacter("Nurse Roberts");
        public readonly static Character KatrinaVonBrandthofen = CreateCharacter("Katrina Von Brandthofen");
        public readonly static Character DoctorVictorMordenheim = CreateCharacter("Doctor Victor Mordenheim");
        public readonly static Character Eva = CreateCharacter("Eva");
        #endregion

        #region Liffe
        #endregion

        #region Markovia
        public readonly static Character Ludmilla = CreateCharacter("Ludmilla");
        public readonly static Character JurgenVastish = CreateCharacter("Jurgen Vastish");
        #endregion

        #region Mordent
        public readonly static Character LadyWeathermay = CreateCharacter("Lady Virginia Anne Weathermay");
        public readonly static Character OldLadyWeathermay = CreateCharacter("Lady Weathermay");
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
        public readonly static Character EstherTimothy = CreateCharacter("Esther Timothy");
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
        #endregion

        #region Nebligtode
        #endregion

        #region Nova Vaasa
        #endregion

        #region Paridon
        public readonly static Character SirEdmundBloodsworth = CreateCharacter("Sir Edmund Bloodsworth");
        #endregion

        #region Richemulot
        #endregion

        #region Sebua
        #endregion

        #region Sithicus
        public readonly static Character Kitiara = CreateCharacter("Kitiara");
        public readonly static Character SothSteed = CreateCharacter("Soth's Steed");
        #endregion

        #region Sri Raji / Kalakeri
        #endregion

        #region Souragne
        public readonly static Character LarissaSnowmane = CreateCharacter("Larissa Snowmane");
        #endregion

        #region Valachan
        public readonly static Character Felkovic = CreateCharacter("Felkovic");
        #endregion

        #region Winding Road
        #endregion

        #region Inside Ravenloft
        public readonly static Character EleazerClyde = CreateCharacter("EleazerClyde");
        public readonly static Character TLaan = CreateCharacter("T`Laan");
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
        #endregion
    }
}