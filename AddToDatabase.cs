namespace Ravenloft
{
    internal static class AddToDatabase
    {
        public static void Add (RavenloftContext db) 
        {
            void Add (Appearance input)
            {
                var retval = db.Find(typeof(Appearance), input.Id);
                if (retval == null) db.Add(input);
            }

            #region Universal Traits
            var e1  = new Trait("1st Edition"  , Trait.TraitType.Source);
            var e2  = new Trait("2nd Edition"  , Trait.TraitType.Source);
            var e3  = new Trait("3rd Edition"  , Trait.TraitType.Source);
            var e35 = new Trait("3.5th Edition", Trait.TraitType.Source);
            var e4  = new Trait("4th Edition"  , Trait.TraitType.Source);
            var e5  = new Trait("5th Edition"  , Trait.TraitType.Source);

            var pc = new Trait("Potentially Canon", Trait.TraitType.Source);
            var nc = new Trait("Not Canon", Trait.TraitType.Source);
            nc.ExtraInfo = pc.ExtraInfo = "Unless explicity stated as 'Potentially Canon' or 'Not Canon', everything else is treated Canon.";

            var comic      = new Trait("Comic"      , Trait.TraitType.Source);
            var module     = new Trait("Module"     , Trait.TraitType.Source);
            var novel      = new Trait("Novel"      , Trait.TraitType.Source);
            var gamebook   = new Trait("Gamebook"   , Trait.TraitType.Source);
            var sourcebook = new Trait("Sourcebook" , Trait.TraitType.Source);
            var magazine   = new Trait("Magazine"   , Trait.TraitType.Source);
            var videogame  = new Trait("Video Game" , Trait.TraitType.Source);
            var boardgame  = new Trait("Board Game" , Trait.TraitType.Source);

            var Darklord      = new Trait("Darklord", Trait.TraitType.Creature);
            var Vistani       = new Trait("Vistani", Trait.TraitType.Creature | Trait.TraitType.Location | Trait.TraitType.Item);

            var Male          = new Trait("Male", Trait.TraitType.Creature);
            var Female        = new Trait("Female", Trait.TraitType.Creature);
            var Agender       = new Trait("No Gender", Trait.TraitType.Creature);

            var Human = new Trait("Human", Trait.TraitType.Creature);

            var Undead = new Trait("Undead", Trait.TraitType.Creature);

            var Castle          = new Trait("Castle", Trait.TraitType.Location);
            var DarklordLair    = new Trait("Darklord Lair", Trait.TraitType.Location);
            var Church          = new Trait("Church", Trait.TraitType.Location);
            var Forest          = new Trait("Forest", Trait.TraitType.Location);
            var Camp            = new Trait("Camp", Trait.TraitType.Location);
            var Town            = new Trait("Town", Trait.TraitType.Location);
            var Mansion         = new Trait("Mansion", Trait.TraitType.Location);

            var Card           = new Trait("Card", Trait.TraitType.Item);
            #endregion

            var I6Ravenloft = new Source("I6: Ravenloft");
            I6Ravenloft.Traits.AddRange(new[] { e1, module });
            I6Ravenloft.ReleaseDate = new DateTime(1983, 11, 1);
            I6Ravenloft.Contributors = "Authors: Tracy Hickman and Laura Hickman\nEditor: Curtis Smith\n";
            I6Ravenloft.Contributors += "Graphic Designer: Debra Stubbe\nIllustrator: Clyde Caldwell";
            I6Ravenloft.ExtraInfo = "'ModuleInfo':'An adventure for 6-8 characters of levels 5-7'";

            var Barovia = new Domain("Barovia");
            Add(new Appearance(I6Ravenloft, Barovia, 1));

            var Strahd = new NPC("Count Strahd von Zarovich");
            Add(new Appearance(I6Ravenloft, Strahd, 1));
            Cross.Add(Strahd, Male);
            Cross.Add(Strahd, Barovia);
            Cross.Add(Strahd, Darklord);
            Strahd.ExtraInfo = "'ClosedBorders': 'Deadly Fog'";

            var MadamEva = new NPC("Madam Eva");
            Add(new Appearance(I6Ravenloft, MadamEva, 1));
            Cross.Add(MadamEva, Female);
            Cross.Add(MadamEva, Barovia);
            Cross.Add(MadamEva, Vistani);

            var IreenaKolyana = new NPC("Ireena Kolyana");
            Add(new Appearance(I6Ravenloft, IreenaKolyana, 1));
            Cross.Add(IreenaKolyana, Female);
            Cross.Add(IreenaKolyana, Barovia);

            var Sergei = new NPC("Sergei von Zarovich");
            Add(new Appearance(I6Ravenloft, Sergei, 1));
            Cross.Add(Sergei, Male);
            Cross.Add(Sergei, Barovia);

            var VistaniCamp = new Location("Vistani Camp");
            Add(new Appearance(I6Ravenloft, VistaniCamp, 1));
            Cross.Add(VistaniCamp, Barovia);
            Cross.Add(VistaniCamp, MadamEva);
            Cross.Add(VistaniCamp, Camp);
            Cross.Add(VistaniCamp, Vistani);

            var TownOfBarovia = new Location("Town of Barovia");
            Add(new Appearance(I6Ravenloft, TownOfBarovia, 1));
            Cross.Add(TownOfBarovia, Barovia);
            Cross.Add(TownOfBarovia, IreenaKolyana);
            Cross.Add(TownOfBarovia, Town);

            var CastleRavenloft = new Location("Castle Ravenloft");
            Add(new Appearance(I6Ravenloft, CastleRavenloft, 1));
            Cross.Add(CastleRavenloft, Barovia);
            Cross.Add(CastleRavenloft, Castle);
            Cross.Add(CastleRavenloft, DarklordLair);
            Cross.Add(CastleRavenloft, Strahd);

            var SvalichWoods = new Location("Svalich Woods");
            Add(new Appearance(I6Ravenloft, SvalichWoods, 1));
            Cross.Add(SvalichWoods, Barovia);
            Cross.Add(SvalichWoods, Forest);

            var BurgomasterMansion = new Location("Burgomaster's Mansion");
            Add(new Appearance(I6Ravenloft, BurgomasterMansion, 1));
            Cross.Add(BurgomasterMansion, Barovia);
            Cross.Add(BurgomasterMansion, Mansion);

            var BarovianChurch = new Location("Church of Barovia");
            Add(new Appearance(I6Ravenloft, BarovianChurch, 1));
            Cross.Add(BarovianChurch, Barovia);
            Cross.Add(BarovianChurch, TownOfBarovia);
            Cross.Add(BarovianChurch, Church);

            var Burgomaster = new Trait("Burgomaster", Trait.TraitType.Creature);
            Add(new Appearance(I6Ravenloft, Burgomaster, 1));
            Cross.Add(Burgomaster, Barovia);
            Cross.Add(Burgomaster, BurgomasterMansion);
            Cross.Add(Burgomaster, TownOfBarovia);

            var Wolf = new Trait("Wolf", Trait.TraitType.Creature);
            Add(new Appearance(I6Ravenloft, Wolf, 1));
            Cross.Add(Wolf, Barovia);
            Cross.Add(Wolf, SvalichWoods);

            var Worg = new Trait("Worg", Trait.TraitType.Creature);
            Add(new Appearance(I6Ravenloft, Worg, 1));
            Cross.Add(Worg, Barovia);
            Cross.Add(Worg, SvalichWoods);

            var Bat = new Trait("Bat", Trait.TraitType.Creature);
            Add(new Appearance(I6Ravenloft, Bat, 1));
            Cross.Add(Bat, Barovia);
            Cross.Add(Bat, CastleRavenloft);

            var Vampire = new Trait("Vampire", Trait.TraitType.Creature);
            Add(new Appearance(I6Ravenloft, Vampire, 1));
            Cross.Add(Vampire, Barovia);
            Cross.Add(Vampire, Strahd);

            var Tarokka = new Item("Tarokka");
            Cross.Add(Tarokka, Barovia);
            Cross.Add(Tarokka, Vistani);
            Cross.Add(Tarokka, MadamEva);
            Cross.Add(Tarokka, Card);
            Cross.Add(Tarokka, VistaniCamp);
            Cross.Add(Tarokka, Vistani);
            Add(new Appearance(I6Ravenloft, Tarokka, 1));

            db.SaveChanges();

            /*#region 2e
            var E2Canon = Add(new Canon("2e Canon"));
            #region Clusters
            var Core = Add(new Cluster("Core"));
            var CorePreGC = Add(new Cluster("Core (Pre-Grand Conjuction)"));
            var Shadowlands = Add(new Cluster("The Shadowlands"));
            var AmberWastes = Add(new Cluster("Amber Wastes"));
            var BurningPeaks = Add(new Cluster("Burning Peaks"));
            var FrozenReaches = Add(new Cluster("Frozen Reaches"));
            var VerdurousLands = Add(new Cluster("Verdurous Lands"));
            var Zherisia = Add(new Cluster("Zherisia"));
            #endregion
            #region Mistways
            var HereticsEgress = Add(new Mistway("Heretic's Egress"));
            var ShroudedWay = Add(new Mistway("Shrouded Way"));
            var ViaCorona = Add(new Mistway("Via Corona"));
            var RoadOfSecrets = Add(new Mistway("Road of a Thousand Secrets"));
            var ShatterPassage = Add(new Mistway("Shattered Passage"));
            var JackalsRuse = Add(new Mistway("Jackal's Ruse"));
            var WakeOfTheLoa = Add(new Mistway("Wake of the Loa"));
            var WayfarerPath = Add(new Mistway("Wayfarer's Path"));
            var VenomousTears = Add(new Mistway("Way of Venomous Tears"));
            var EmeraldStream = Add(new Mistway("Emerald Stream"));
            var LeviathanClutch = Add(new Mistway("Leviathan's Clutches"));
            var PathOfInnocence = Add(new Mistway("Path of Innocence"));
            #endregion
            #region Domains
            var Barovia = Add(new Domain("Barovia"));
            var Bluetspur = Add(new Domain("Bluetspur"));
            var Borca = Add(new Domain("Borca"));
            var LMorai = Add(new Domain("L'Morai", "The Carnival"));
            var Darkon = Add(new Domain("Darkon"));
            var Dementlieu = Add(new Domain("Dementlieu"));
            var Falkovnia = Add(new Domain("Falkovnia"));
            var HarAkir = Add(new Domain("Har'Akir"));
            var Hazlan = Add(new Domain("Hazlan"));
            var ICath = Add(new Domain("I'Cath"));
            var SriRaji = Add(new Domain("Sri Raji", "Kalakeri"));
            var Kartakass = Add(new Domain("Kartakass"));
            var Lamordia = Add(new Domain("Lamordia"));
            var Mordent = Add(new Domain("Mordent"));
            var Richemulot = Add(new Domain("Richemulot"));
            var Tepest = Add(new Domain("Tepest"));
            var Valachan = Add(new Domain("Valachan"));
            var Forlorn = Add(new Domain("Forlorn"));
            var Ghastria = Add(new Domain("Ghastria"));
            var Ghenna = Add(new Domain("G'Henna"));
            var Invidia = Add(new Domain("Invidia"));
            var Keening = Add(new Domain("Keening"));
            var Markovia = Add(new Domain("Markovia"));
            var NightmareLands = Add(new Domain("Nightmare Lands"));
            var NovaVaasa = Add(new Domain("Nova Vaasa"));
            var Odiare = Add(new Domain("Odiare", "Odaire"));
            var WindingRoad = Add(new Domain("Winding Road", "Endless Road", "Rider's Bridge"));
            var Risibilos = Add(new Domain("Risibilos"));
            var Scaena = Add(new Domain("Scaena"));
            var SeaOfSorrows = Add(new Domain("Sea of Sorrows"));
            var Blaustein = Add(new Domain("Blaustein"));
            var Dominia = Add(new Domain("Dominia"));
            var IsleOfTheRavens = Add(new Domain("Isle of the Ravens"));
            var Lighthouse = Add(new Domain("L'ile de le Tempete, The Lighthouse"));
            var ShadowbornManor = Add(new Domain("Shadowborn Manor", "Shadowlands"));
            var Souragne = Add(new Domain("Souragne"));
            var StauntonBluffs = Add(new Domain("Staunton Bluffs"));
            var Tovag = Add(new Domain("Tovag"));
            var Paridon = Add(new Domain("Paridon", "Zherisia"));
            var HouseOfLament = Add(new Domain("House of Lament"));
            var Demise = Add(new Domain("Demise"));
            var Kalidnay = Add(new Domain("Kalidnay"));
            var Sithicus = Add(new Domain("Sithicus"));
            var Cavitius = Add(new Domain("Cavitius"));
            var Aggarath = Add(new Domain("Aggarath"));
            var Avonleigh = Add(new Domain("Avonleigh"));
            var CastleIsland = Add(new Domain("Castle Island"));
            var Daglan = Add(new Domain("Daglan"));
            var Davion = Add(new Domain("Davion"));
            var Liffe = Add(new Domain("Liffe"));
            var Nebligtode = Add(new Domain("Nebligtode", "Nocturnal Sea"));
            var Necropolis = Add(new Domain("Necropolis"));
            var Nidala = Add(new Domain("Nidala"));
            var Nosos = Add(new Domain("Nosos"));
            var Pharazia = Add(new Domain("Pharazia"));
            var Rokushima = Add(new Domain("Rokushima Taiyoo"));
            var Sanguinia = Add(new Domain("Sanguinia"));
            var Saragross = Add(new Domain("Saragross"));
            var Sebua = Add(new Domain("Sebua"));
            var ShadowRift = Add(new Domain("Shadow Rift"));
            var TheEyrie = Add(new Domain("The Eyrie"));
            var TheIsle = Add(new Domain("The Isle"));
            var TheWildlands = Add(new Domain("The Wildlands"));
            var Timor = Add(new Domain("Timor"));
            var Vechor = Add(new Domain("Vechor"));
            var Verbrek = Add(new Domain("Verbrek"));
            var Vorostokov = Add(new Domain("Vorostokov"));
            var LeederiksTower = Add(new Domain("Leederik's Tower"));
            var Farelle = Add(new Domain("Farelle"));
            var RichtenHaus = Add(new Domain("Richten Haus"));

            var Malosia = Add(new Domain("Malosia"));
            var MithrasCourt = Add(new Domain("Mithras Court"));
            var Riverbend = Add(new Domain("Riverbend"));
            var Kislova = Add(new Domain("Kislova"));
            var Estrangia = Add(new Domain("Estrangia"));
            var AlKathos = Add(new Domain("Al-Kathos"));
            var Maridrar = Add(new Domain("Maridrar"));
            var DonskoysLand = Add(new Domain("Donskoy's Land"));
            var Arak = Add(new Domain("Arak"));
            var Arkandale = Add(new Domain("Arkandale"));
            var Dorvinia = Add(new Domain("Dorvinia"));
            var Gundarak = Add(new Domain("Gundarak"));
            #endregion
            #endregion

            #region 2e Potential
            var E2CanonPot = Add(new Canon("2e Potential Canon"));
            #region Mistways
            var BleakRoad = Add(new Mistway("Bleak Road"));
            var OutlandersGate = Add(new Mistway("Outlander's Gate"));
            var SerpentsCoils = Add(new Mistway("Serpent's Coils"));
            var MtFrostAnhalla = Add(new Mistway("Mount Frost-Anhalla"));
            var OakOfScreams = Add(new Mistway("Oak of Screams"));
            Cross.Add(E2CanonPot, BleakRoad, OutlandersGate, SerpentsCoils, MtFrostAnhalla, OakOfScreams);
            #endregion
            #endregion

            #region 2e Not Canon
            var E2CanonNot = Add(new Canon("2e Not Canon"));
            #endregion

            #region 3.5e Canon
            var E35Canon = Add(new Canon("3.5e Canon"));
            #endregion

            #region 4e Canon
            var E4Canon = Add(new Canon("4e Canon"));
            #region Domains
            var Graefmotte = Add(new Domain("Graefmotte"));
            var Histaven = Add(new Domain("Histaven"));
            var Monadhan = Add(new Domain("Monadhan"));
            var Sunderheart = Add(new Domain("Sunderheart"));
            var Timbergorge = Add(new Domain("Timbergorge"));
            var Bakumora = Add(new Domain("Bakumora"));
            var Darani = Add(new Domain("Darani"));
            #endregion
            #endregion

            #region 5e Canon
            var E5Canon = Add(new Canon("5e Canon"));
            #region Domains
            var Cyre1313 = Add(new Domain("Cyre 1313", "The Mourning Rail"));
            var Klorr = Add(new Domain("Klorr"));
            var Niranjan = Add(new Domain("Niranjan"));
            var VhageAgency = Add(new Domain("Vhage Agency"));
            var VigilantsBluff = Add(new Domain("Vigilant's Bluff"));
            #endregion
            #endregion

            #region Netbook
            var Netbook = Add(new Canon("Netbook"));
            #region Mistways
            var CallOfTheClaw = Add(new Mistway("Call of the Claw"));
            var SomnambulistPath = Add(new Mistway("Somnambulist's Path"));
            var RoyalChannel = Add(new Mistway("Royal Channel"));
            var TheWindingJaws = Add(new Mistway("Way of the Winding Jaws"));
            var UrchinsPath = Add(new Mistway("Urchin's Path"));
            var SleepOfReason = Add(new Mistway("Sleep of Reason"));
            var IronWay = Add(new Mistway("Iron Way"));
            Cross.Add(Netbook, CallOfTheClaw, SomnambulistPath, RoyalChannel, TheWindingJaws, UrchinsPath, SleepOfReason, IronWay);
            #endregion
            #endregion

            #region Homebrew
            var Homebrew = Add(new Canon("Homebrew"));
            #endregion




            #region Sources
            #endregion

            #region Locations
            #endregion

            #region Items
            #endregion

            #region Darklords
            var Strahd         = Add(new Darklord("Count Strahd von Zarovich", "The Devil Strahd", "Lord Vasili von Holtz", "Strahd XI", "Vladislav"));
            var Diederic       = Add(new Darklord("Sir Diederic de Wyndt"));
            var Lucius         = Add(new Darklord("Lord Lucius Knight", "Colonel Lucius Merriwether"));
            var Alistair       = Add(new Darklord("Doctor Alistair Weldon"));
            var Magroth        = Add(new Darklord("Emperor Magroth the Mad"));
            var Ilsabet        = Add(new Darklord("Baroness Ilsabet Obour"));
            var Whelm          = Add(new Darklord("Friar Whelm"));
            var Malbus         = Add(new Darklord("Malbus"));
            var Velkaarn       = Add(new Darklord("Lord Velkaarn"));
            var Milos          = Add(new Darklord("Lord Milos Donskoy"));
            var GodBrain       = Add(new Darklord("The Illithid God-Brain"));
            var Ivan           = Add(new Darklord("Ivan Dilisnya"));
            var Ivana          = Add(new Darklord("Ivana Boritsi"));
            var RubyPendant    = Add(new Darklord("RubyPendant"));
            var Nepenthe       = Add(new Darklord("Nepenthe"));
            var AzalinRex      = Add(new Darklord("Azalin Rex", "Firan Darcalus Zal'honan"));
            var Dominic        = Add(new Darklord("Dominic d'Honaire"));
            var Saidra         = Add(new Darklord("Saidra d'Honaire"));
            var Vlad           = Add(new Darklord("Vlad Drakov"));
            var Vladeska       = Add(new Darklord("Vladeska Drakov"));
            var Ankhtepot      = Add(new Darklord("Ankhtepot"));
            var Hazlik         = Add(new Darklord("Hazlik"));
            var TsienChiang    = Add(new Darklord("Empress Tsien Chiang"));
            var Arijani        = Add(new Darklord("Maharaja Arijani"));
            var Ramya          = Add(new Darklord("Ramya Vasavadan"));
            var HarkonLukas    = Add(new Darklord("Meistersinger Harkon Lukas"));
            var Adam           = Add(new Darklord("Adam"));
            var Viktra         = Add(new Darklord("Doctor Viktra Mordenheim"));
            var Wilfred        = Add(new Darklord("Wilfred Godefroy"));
            var Jacqueline     = Add(new Darklord("Jacqueline Renier"));
            var Mindefisk      = Add(new Darklord("The Sisters Mindefisk", "The Three Hags of Tepest", "Three Sisters"));
            var Lorinda        = Add(new Darklord("Mother Lorinda"));
            var UrikVonKarkov  = Add(new Darklord("Urik von Kharkov"));
            var Chakuna        = Add(new Darklord("Chakuna"));
            var TristenApBlanc = Add(new Darklord("Tristen ApBlanc", "The Solleyder"));
            var StezenDPolarno = Add(new Darklord("Marquis Stezen D'Polarno"));
            var YagnoPetrovna  = Add(new Darklord("Yagno Petrovna"));
            var Gabrielle      = Add(new Darklord("Gabrielle Aderre"));
            var Tristessa      = Add(new Darklord("Tristessa"));
            var Frantisek      = Add(new Darklord("Doctor Frantisek Markov"));
            var NigtmareMan    = Add(new Darklord("The Nigtmare Man"));
            var Hypnos         = Add(new Darklord("Hypnos"));
            var Mullonga       = Add(new Darklord("Mullonga"));
            var GhostDancer    = Add(new Darklord("The Ghost Dancer"));
            var Morpheus       = Add(new Darklord("Morpheus"));
            var RainbowSerpent = Add(new Darklord("The Rainbow Serpent"));
            var RedheadedChild = Add(new Darklord("The Redheaded Child"));
            var Malken         = Add(new Darklord("Tristen Hiregaard","Malken"));
            var Malkan         = Add(new Darklord("Myar Hiregaard" ," Malkan"));
            var Maligno        = Add(new Darklord("Maligno", "Figlio"));
            var Horseman       = Add(new Darklord("Headless Horseman"));
            var EliVanHassen   = Add(new Darklord("Eli van Hassen"));
            var Doerdon        = Add(new Darklord("King Doerdon"));
            var Puncheron      = Add(new Darklord("Puncheron"));
            var LemotSediam    = Add(new Darklord("Lemot Sediam Juste"));
            var PieterVanRiese = Add(new Darklord("Captain Pieter van Riese"));
            var PietraVanRiese = Add(new Darklord("Captain Pietra van Riese"));
            var Bluebeard      = Add(new Darklord("Bluebeard"));
            var Daclaud        = Add(new Darklord("Doctor Daclaud Heinfroth"));
            var LadyOfRavens   = Add(new Darklord("Lady of Ravens"));
            var AlainMonette   = Add(new Darklord("Captain Alain Monette"));
            var Ebonbane       = Add(new Darklord("Ebonbane"));
            var AntonMisroi    = Add(new Darklord("Anton Misroi"));
            var Torrence       = Add(new Darklord("Torrence Bleysmith"));
            var Teresa         = Add(new Darklord("Teresa Bleysmith"));
            var Kas            = Add(new Darklord("Kas the Destroyer", "Kas of Tycheron", "Kas the Terrible", "Kas the Bloody-Handed", "Kas the Hateful", "Kas the Betrayer"));
            var Sodo           = Add(new Darklord("Sodo"));
            var HouseOfLamentDL= Add(new Darklord("House of Lament"));
            var Althea         = Add(new Darklord("Althea"));
            var ThakokAn       = Add(new Darklord("Thakok-An"));
            var Soth           = Add(new Darklord("Lord Loren Soth", "Knight of the Black Rose"));
            var InzaMagdova    = Add(new Darklord("Inza Magdova Kulchevich"));
            var Vecna          = Add(new Darklord("Vecna"));
            var Chardath       = Add(new Darklord("Chardath Spulzeer"));
            var Morgoroth      = Add(new Darklord("Morgoroth the Black"));
            var LadyOfTheLake  = Add(new Darklord("Lady of the Lake"));
            var Radaga         = Add(new Darklord("Radaga"));
            var DavionTheMad   = Add(new Darklord("Davion the Mad"));
            var LyronEvensong  = Add(new Darklord("Lyron Evensong"));
            var Meredoth       = Add(new Darklord("Meredoth"));
            var Lowellyn       = Add(new Darklord("Death", "Lowellyn Dachine"));
            var ElenaFaithHold = Add(new Darklord("Elena Faith-hold"));
            var MalusSceleris  = Add(new Darklord("Malus Sceleris"));
            var Diamabel       = Add(new Darklord("Diamabel"));
            var HakiShinpi     = Add(new Darklord("Haki Shinpi"));
            var LadislavMircea = Add(new Darklord("Prince Ladislav Mircea"));
            var DragaSaltbiter = Add(new Darklord("Draga Saltbiter"));
            var Tiyet          = Add(new Darklord("Tiyet"));
            var Gwydion        = Add(new Darklord("Gwydion"));
            var TheBaron       = Add(new Darklord("The Baron"));
            var BlakeRamsay    = Add(new Darklord("Dr. Blake Ramsay"));
            var KingCrocodile  = Add(new Darklord("King Crocodile"));
            var HiveQueen      = Add(new Darklord("Hive Queen"));
            var EasanTheMad    = Add(new Darklord("Easan the Mad"));
            var AlfredTimothy  = Add(new Darklord("Alfred Timothy"));
            var NathanTimothy  = Add(new Darklord("Captain Nathan Timothy"));
            var GregorZolnik   = Add(new Darklord("Boyar Gregor Zolnik"));
            var Leederik       = Add(new Darklord("Leederik", "The Phantom Lover"));
            var JackKarn       = Add(new Darklord("Jack Karn"));
            var Radanavich     = Add(new Darklord("Madame Radanavich"));
            var DurvenGraef    = Add(new Darklord("Lord Durven Graef"));
            var RagMan         = Add(new Darklord("Rag Man"));
            var Arantor        = Add(new Darklord("Arantor"));
            var IvaniaDreygu   = Add(new Darklord("Lady Ivania Dreygu"));
            var Ghoul          = Add(new Darklord("The Ghoul", "Vorno Kahnebor"));
            var Silvermaw      = Add(new Darklord("Silvermaw"));
            var Fotari         = Add(new Darklord("Fotari"));
            var LastPassenger  = Add(new Darklord("Last Passenger"));
            var KlorrDL        = Add(new Darklord("Klorr"));
            var Sarthak        = Add(new Darklord("Sarthak"));
            var FlimiraVhage   = Add(new Darklord("Detective Flimira Vhage"));
            var UndeadPaladin  = Add(new Darklord("Unnamed Undead Paladin"));
            var NharovGundar   = Add(new Darklord("Duke Nharov Gundar"));
            #endregion

            #region NPCs
            #endregion

            #region CreatureTraits
            #endregion

            #region Events
            #endregion

            #region Not bound by Canon

            var Unknown = Add(new Domain("Unknown")); //Special Entry
            var OutsideWorld = Add(new Domain("Outside of Ravenloft")); //Special Entry

            #region Location.Traits
            #endregion
            #region Domain.Traits
            var PocketDomains = Add(new Domain.Trait("Pocket Domains"));
            var IslandsOfTerror = Add(new Domain.Trait("Islands of Terror"));
            var Shadowfell = Add(new Domain.Trait("Shadowfell"));
            var Desert = Add(new Domain.Trait("Desert"));
            var Frozen = Add(new Domain.Trait("Frozen"));
            var Coastal = Add(new Domain.Trait("Coastal"));
            var MostlyWater = Add(new Domain.Trait("Coastal"));
            var NovelOnly = Add(new Domain.Trait("NovelOnly"));
            #endregion
            #region Item.Traits
            var MistTalisman = Add(new Item.Trait("Mist Talisman"));
            #endregion
            #endregion

            #region Add Domains to Clusters
            Cross.Add(Core, Barovia, Blaustein, Borca, Darkon, Necropolis, Dementlieu, Demise, Dominia, Falkovnia, Forlorn);
            Cross.Add(Core, Ghastria, Hazlan, Invidia, IsleOfTheRavens, Kartakass, Keening, Lamordia, Liffe, Lighthouse, Markovia);
            Cross.Add(Core, Mordent, Nebligtode, NovaVaasa, Richemulot, SeaOfSorrows, ShadowRift, Sithicus, Tepest, CastleIsland);
            Cross.Add(Core, TheIsle, Valachan, Vechor, Verbrek, VigilantsBluff, HouseOfLament);

            Cross.Add(CorePreGC, Barovia, SeaOfSorrows, Demise, Lamordia, Dementlieu, Mordent, Darkon, Ghenna, Keening, Tepest, Arak);
            Cross.Add(CorePreGC, Markovia, Dorvinia, Richemulot, Borca, NovaVaasa, NightmareLands, Hazlan, Verbrek, Invidia, Forlorn);
            Cross.Add(CorePreGC, Kartakass, Bluetspur, Sithicus, Valachan, Daglan);

            Cross.Add(Shadowlands, Avonleigh, ShadowbornManor, Nidala);
            Cross.Add(AmberWastes, HarAkir, Sebua, Pharazia, Kalidnay);
            Cross.Add(BurningPeaks, Tovag, Cavitius);
            Cross.Add(FrozenReaches, Sanguinia, Vorostokov);
            Cross.Add(VerdurousLands, Saragross, SriRaji, Niranjan, TheWildlands);
            Cross.Add(Zherisia, Paridon, Timor);
            #endregion

            #region Add DomainTraits to Domains
            Cross.Add(PocketDomains, HouseOfLament, CastleIsland, Davion, Aggarath, LMorai, WindingRoad, Scaena, TheEyrie, Cyre1313);
            Cross.Add(PocketDomains, VhageAgency, LeederiksTower);

            Cross.Add(IslandsOfTerror, Bluetspur, ICath, Ghenna, Kalidnay, Klorr, NightmareLands, Nosos, Odiare, Risibilos, Rokushima);
            Cross.Add(IslandsOfTerror, Souragne, StauntonBluffs, Paridon, AlKathos, Darani, DonskoysLand, Estrangia, Kislova, Malosia);
            Cross.Add(IslandsOfTerror, Maridrar, MithrasCourt, Riverbend);

            Cross.Add(Coastal,SriRaji, Souragne, Demise, Lamordia, Dementlieu, Mordent, Darkon, Rokushima, Dominia, Markovia, Ghastria);
            Cross.Add(Coastal, Blaustein, IsleOfTheRavens, Nebligtode, Lighthouse, Liffe, Vechor, NovaVaasa);

            Cross.Add(NovelOnly, AlKathos, Darani, DonskoysLand, Estrangia, Kislova, Malosia, Maridrar, MithrasCourt, Riverbend);
            Cross.Add(Shadowfell, Bakumora, Graefmotte, Histaven, Monadhan, Sunderheart, Timbergorge, Darani);
            Cross.Add(Desert, HarAkir, Sebua, Pharazia);
            Cross.Add(Frozen, Sanguinia, Vorostokov, Lamordia);
            Cross.Add(MostlyWater, SeaOfSorrows, Nebligtode, Saragross, CastleIsland, VigilantsBluff);
            #endregion

            Cross.Add(E2Canon, Core, CorePreGC, Shadowlands, AmberWastes, BurningPeaks, FrozenReaches, VerdurousLands);
            #region Add Canon Mistways 
            Cross.Add(E2Canon, EmeraldStream, HereticsEgress, JackalsRuse, LeviathanClutch, PathOfInnocence, RoadOfSecrets);
            Cross.Add(E2Canon, ShatterPassage, ShroudedWay, ViaCorona, WakeOfTheLoa, VenomousTears, WayfarerPath);

            Cross.Add(E2CanonPot, BleakRoad, OutlandersGate, SerpentsCoils, MtFrostAnhalla, OakOfScreams);
            Cross.Add(Netbook, CallOfTheClaw, SomnambulistPath, RoyalChannel, TheWindingJaws, UrchinsPath, SleepOfReason, IronWay);
            #endregion
            #region Add Canon Domains 
            Cross.Add(E2Canon, Barovia);
            Cross.Add(E2Canon, Bluetspur);
            Cross.Add(E2Canon, Borca);
            Cross.Add(E2Canon, LMorai);
            Cross.Add(E2Canon, Darkon);
            Cross.Add(E2Canon, Dementlieu);
            Cross.Add(E2Canon, Falkovnia);
            Cross.Add(E2Canon, HarAkir);
            Cross.Add(E2Canon, Hazlan);
            Cross.Add(E2Canon, ICath);
            Cross.Add(E2Canon, SriRaji);
            Cross.Add(E2Canon, Kartakass);
            Cross.Add(E2Canon, Lamordia);
            Cross.Add(E2Canon, Mordent);
            Cross.Add(E2Canon, Richemulot);
            Cross.Add(E2Canon, Tepest);
            Cross.Add(E2Canon, Valachan);
            Cross.Add(E2Canon, Forlorn);
            Cross.Add(E2Canon, Ghastria);
            Cross.Add(E2Canon, Ghenna);
            Cross.Add(E2Canon, Invidia);
            Cross.Add(E2Canon, Keening);
            Cross.Add(E2Canon, Markovia);
            Cross.Add(E2Canon, NightmareLands);
            Cross.Add(E2Canon, NovaVaasa);
            Cross.Add(E2Canon, Odiare);
            Cross.Add(E2Canon, WindingRoad);
            Cross.Add(E2Canon, Risibilos);
            Cross.Add(E2Canon, Scaena);
            Cross.Add(E2Canon, SeaOfSorrows);
            Cross.Add(E2Canon, Blaustein);
            Cross.Add(E2Canon, Dominia);
            Cross.Add(E2Canon, IsleOfTheRavens);
            Cross.Add(E2Canon, Lighthouse);
            Cross.Add(E2Canon, ShadowbornManor);
            Cross.Add(E2Canon, Souragne);
            Cross.Add(E2Canon, StauntonBluffs);
            Cross.Add(E2Canon, Tovag);
            Cross.Add(E2Canon, Paridon);
            Cross.Add(E2Canon, HouseOfLament);
            Cross.Add(E2Canon, Demise);
            Cross.Add(E2Canon, Kalidnay);
            Cross.Add(E2Canon, Sithicus);
            Cross.Add(E2Canon, Cavitius);
            Cross.Add(E2Canon, Aggarath);
            Cross.Add(E2Canon, Avonleigh);
            Cross.Add(E2Canon, CastleIsland);
            Cross.Add(E2Canon, Daglan);
            Cross.Add(E2Canon, Davion);
            Cross.Add(E2Canon, Liffe);
            Cross.Add(E2Canon, Nebligtode);
            Cross.Add(E2Canon, Necropolis);
            Cross.Add(E2Canon, Nidala);
            Cross.Add(E2Canon, Nosos);
            Cross.Add(E2Canon, Pharazia);
            Cross.Add(E2Canon, Rokushima);
            Cross.Add(E2Canon, Sanguinia);
            Cross.Add(E2Canon, Saragross);
            Cross.Add(E2Canon, Sebua);
            Cross.Add(E2Canon, ShadowRift);
            Cross.Add(E2Canon, TheEyrie);
            Cross.Add(E2Canon, TheIsle);
            Cross.Add(E2Canon, TheWildlands);
            Cross.Add(E2Canon, Timor);
            Cross.Add(E2Canon, Vechor);
            Cross.Add(E2Canon, Verbrek);
            Cross.Add(E2Canon, Vorostokov);
            Cross.Add(E2Canon, LeederiksTower);
            Cross.Add(E2Canon, Farelle);
            Cross.Add(E2Canon, RichtenHaus);
            Cross.Add(E2Canon, Graefmotte);
            Cross.Add(E2Canon, Histaven);
            Cross.Add(E2Canon, Monadhan);
            Cross.Add(E2Canon, Sunderheart);
            Cross.Add(E2Canon, Timbergorge);
            Cross.Add(E2Canon, Bakumora);
            Cross.Add(E2Canon, Cyre1313);
            Cross.Add(E2Canon, Klorr);
            Cross.Add(E2Canon, Niranjan);
            Cross.Add(E2Canon, VhageAgency);
            Cross.Add(E2Canon, VigilantsBluff);
            Cross.Add(E2Canon, Malosia);
            Cross.Add(E2Canon, MithrasCourt);
            Cross.Add(E2Canon, Riverbend);
            Cross.Add(E2Canon, Darani);
            Cross.Add(E2Canon, Kislova);
            Cross.Add(E2Canon, Estrangia);
            Cross.Add(E2Canon, AlKathos);
            Cross.Add(E2Canon, Maridrar);
            Cross.Add(E2Canon, DonskoysLand);
            Cross.Add(E2Canon, Arak);
            Cross.Add(E2Canon, Arkandale);
            Cross.Add(E2Canon, Dorvinia);
            Cross.Add(E2Canon, Gundarak);
            #endregion
            #region Add Canon Source
            #endregion
            #region Add Canon Location
            #endregion
            #region Add Canon Item
            #endregion
            #region Add Canon Darklord
            #endregion
            #region Add Canon NPC
            #endregion
            #region Add Canon CreatureTrait
            #endregion
            #region Add Canon Event
            #endregion

            #region Add Darklord to Domain
            Cross.Add(Odiare, Maligno);
            Cross.Add(Barovia, Strahd);
            #endregion

            #region Add Darklord trait to Darklord
            var Darklord = Add(new CreatureTrait("Darklord"));
            Cross.Add(Darklord, Strahd, Maligno);
            #endregion*/
        }
    }
}