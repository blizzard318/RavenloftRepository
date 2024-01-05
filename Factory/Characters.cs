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
        public readonly static NPC Meredoth = CreateCharacter("Meredoth");

        public readonly static NPC GabrielleAderre = CreateCharacter("Gabrielle Aderre");

        public readonly static NPC VladDrakov = CreateCharacter("Vlad Drakov");

        public readonly static NPC Hazlik = CreateCharacter("Hazlik");

        public readonly static NPC HarkonLukas = CreateCharacter("Harkon Lukas");

        public readonly static NPC Ludmilla = CreateCharacter("Ludmilla");
        public readonly static NPC FrantisekMarkov = CreateCharacter("Frantisek Markov");

        public readonly static NPC Zhakata = CreateCharacter("Zhakata");
        public readonly static NPC YagnoPetrovna = CreateCharacter("Yagno Petrovna");

        public readonly static NPC Clarke = CreateCharacter("Clarke");
        public readonly static NPC Phillips = CreateCharacter("Phillips");
        public readonly static NPC HowardAshton = CreateCharacter("Howard Ashton");

        public readonly static NPC DoctorAugustus = CreateCharacter("Doctor Augustus");
        public readonly static NPC NurseRoberts = CreateCharacter("Nurse Roberts");

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

        public readonly static NPC AzalinRex = CreateCharacter("Azalin Rex");

        public readonly static NPC EleazerClyde = CreateCharacter("EleazerClyde");
    }
}