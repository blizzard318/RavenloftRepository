﻿public partial class Factory : IDisposable
{
    internal static class LocationEnum
    {
        private static Location CreateLocation(params string[] names)
        {
            var retval = new Location(names);
            Ravenloftdb.Locations.Add(retval);
            return retval;
        }
        #region Arak
        public readonly static Location MountNyid = CreateLocation("Mount Nyid");
        public readonly static Location MountNirka= CreateLocation("Mount Nirka");
        #endregion

        #region Barovia
        public readonly static Location CastleRavenloft = CreateLocation("Castle Ravenloft", "Castle Strahd");
        public readonly static Location BaroviaChurch = CreateLocation("Barovia Church");
        public readonly static Location BildrathMercantile = CreateLocation("Bildrath`s Mercantile");
        public readonly static Location BloodVineTavern = CreateLocation("Blood of the Vine Tavern", "Blood on the Vine Tavern");
        public readonly static Location MaryHouse = CreateLocation("Mad Mary`s Townhouse");
        public readonly static Location BurgomasterHome = CreateLocation("Burgomaster`s Home");
        public readonly static Location BurgomasterGuestHouse = CreateLocation("Burgomaster`s Guest House");
        public readonly static Location BaroviaCemetery = CreateLocation("Barovia Cemetery");
        public readonly static Location MadamEvasTent = CreateLocation("Madam Eva`s Tent");
        public readonly static Location OldSvalichRoad = CreateLocation("Old Svalich Road");
        public readonly static Location GatesOfBarovia = CreateLocation("Gates of Barovia");
        public readonly static Location SvalichWoods = CreateLocation("Svalich Woods");
        public readonly static Location RiverIvlis = CreateLocation("River Ivlis", "Ivlis River");
        public readonly static Location IvlisRiver = RiverIvlis;
        public readonly static Location RiverLuna = CreateLocation("River Luna");
        public readonly static Location LunaRiver = RiverLuna;
        public readonly static Location RoadJunction = CreateLocation("Barovia Road Junction");
        public readonly static Location TserFalls = CreateLocation("Tser Falls");
        public readonly static Location TserPool = CreateLocation("Tser Pool");
        public readonly static Location GatesOfRavenloft = CreateLocation("Gates of Ravenloft");
        public readonly static Location OldBonegrinder = CreateLocation("Old Bonegrinder");
        public readonly static Location MountBaratak = CreateLocation("Mount Baratak", "Mount Baratok");
        public readonly static Location MountGhakis = CreateLocation("Mount Ghakis");
        public readonly static Location LakeZarovich = CreateLocation("Lake Zarovich");
        public readonly static Location TepurichForest = CreateLocation("Tepurich Forest");
        public readonly static Location StoneCircle = CreateLocation("The Circle", "The Stone Circle");
        public readonly static Location WolfsDen = CreateLocation("Wolf`s Den");
        public readonly static Location BurgomasterWay = CreateLocation("Burgomaster's Way");
        public readonly static Location BaroviaBakery = CreateLocation("Barovia Bakery");
        public readonly static Location BaroviaMarketStreet = CreateLocation("Barovia Market Street");
        public readonly static Location BaroviaChurchStreet = CreateLocation("Barovia Church Street");
        public readonly static Location BaroviaSeamstressShop = CreateLocation("Barovia Seamstress Shop");
        public readonly static Location BaroviaPigPen = CreateLocation("Barovia Pig Pen");
        #endregion

        #region Blaustein
        public readonly static Location CastleBluebeard = CreateLocation("Castle Bluebeard", "Bluebeard`s Castle");
        #endregion

        #region Borca
        public readonly static Location BoritsiEstate = CreateLocation("Boritsi Estate", "Misericordia", "Miseria Corpa");
        public readonly static Location LevkarestFerry = CreateLocation("Levkarest Ferry");
        public readonly static Location FenBridge = CreateLocation("Fen Bridge");
        #endregion

        #region Daglan
        public readonly static Location HomlockChurch = CreateLocation("Homlock Church", "Homloch Church");
        public readonly static Location TowerOfMagic = CreateLocation("Daglan`s Tower of Magic");
        public readonly static Location BarrowMounds = CreateLocation("Barrow Mounds");
        public readonly static Location HomlockCemetery = CreateLocation("Cemetery (Homlock)");
        #endregion

        #region Darkon
        public readonly static Location AzalinCastle = CreateLocation("Azalin`s Castle", "Avernus");

        public readonly static Location NorthCanal = CreateLocation("North Canal (Il Aluk)");
        public readonly static Location SouthCanal = CreateLocation("South Canal (Il Aluk)");

        public readonly static Location MillsOfNartok = CreateLocation("Lumber Mills (Nartok)");
        
        public readonly static Location UpperCityKarg = CreateLocation("Upper City (Karg)");
        public readonly static Location MausoleumsKarg = CreateLocation("Mausoleums (Karg)");
        public readonly static Location LowerCityKarg = CreateLocation("Lower City (Karg)");
        public readonly static Location GraveyardKarg = CreateLocation("Graveyard (Karg)");

        public readonly static Location RiverCorvus = CreateLocation("Corvus River", "River Corvus");
        public readonly static Location CorvusRiver = RiverCorvus;
        public readonly static Location RiverTempe = CreateLocation("Tempe River", "River Tempe");
        public readonly static Location TempeRiver = RiverTempe;
        public readonly static Location AzalinsGraveyard = CreateLocation("Azalin`s Graveyard");
        public readonly static Location KargatMausoleum = CreateLocation("Kargat Mausoleum");
        #endregion

        #region Davion
        #region Arcanon
        public readonly static Location ArcanonMagicShop = CreateLocation("Arcanon Magic Shop");
        public readonly static Location ArcanonHall = CreateLocation("Arcanon Gathering Hall");
        public readonly static Location ArcanonInn = CreateLocation("Arcanon Inn");
        public readonly static Location ArcanonTavern = CreateLocation("Arcanon Tavern");
        public readonly static Location ArcanonStore = CreateLocation("Arcanon Store");
        #endregion
        #region Boromars Knoll
        public readonly static Location BoromarsTavern = CreateLocation("Boromar`s Knoll Tavern");
        public readonly static Location BoromarsSign = CreateLocation("Boromar`s Knoll Signpost");
        public readonly static Location BoromarsTavern2 = CreateLocation("Boromar`s Knoll Other Tavern");
        public readonly static Location BoromarsStable = CreateLocation("Boromar`s Knoll Stable");
        public readonly static Location BoromarsArmory = CreateLocation("Boromar`s Knoll Armory", "Boromar`s Knoll Blacksmith");
        #endregion
        #region Pallatia
        public readonly static Location PallatiaInn = CreateLocation("Pallatia Inn");
        public readonly static Location PallatiaStable = CreateLocation("Pallatia Stable");
        public readonly static Location PallatiaBlacksmith = CreateLocation("Pallatia Blacksmith");
        public readonly static Location PallatiaTemple = CreateLocation("Pallatia Temple of Loviatar");
        public readonly static Location PallatiaSign = CreateLocation("Pallatia Signpost");
        public readonly static Location PallatiaStore = CreateLocation("Pallatia Store");
        #endregion
        #region Thornewood
        public readonly static Location ThornewoodTavern = CreateLocation("Thornewood Tavern");
        public readonly static Location ThornewoodBlacksmith = CreateLocation("Thornewood Blacksmith");
        public readonly static Location ThornewoodStable = CreateLocation("Thornewood Stable");
        public readonly static Location ThornewoodInfirmary = CreateLocation("Thornewood Infirmary");
        public readonly static Location ThornewoodFortune = CreateLocation("Thornewood Fortune Teller");
        public readonly static Location ThornewoodStore = CreateLocation("Thornewood Ruined General Store");
        public readonly static Location DavionManor = CreateLocation("Davion Manor");
        #endregion
        #endregion

        #region Dementlieu
        public readonly static Location ParnaultBay = CreateLocation("Parnault Bay");
        public readonly static Location GovernmentQuarter = CreateLocation("Government Quarter");
        public readonly static Location DocksPortALucine = CreateLocation("Government");
        public readonly static Location QuartierMarchard = CreateLocation("Quartier Marchard","Merchant`s Quarter");
        public readonly static Location GuildHalls = CreateLocation("Guild Halls");
        public readonly static Location RuinsOfSteMeredesLarmes = CreateLocation("Ruins of Ste. Mere des Larmes");
        public readonly static Location LaborerTenements = CreateLocation("Laborer`s Tenements");
        #endregion

        #region Dorvinia
        public readonly static Location MountGries = CreateLocation("Mount Gries");
        public readonly static Location DilisnyaEstate = CreateLocation("Dilisnya Family Estate", "Degravo");
        public readonly static Location DoldakHeights = CreateLocation("Doldak Heights");
        #endregion

        #region Falkovnia
        public readonly static Location VladDrakovCastle = CreateLocation("Vlad Drakov`s Castle", "Castle Draccipetri");
        public readonly static Location BoyarsQuarters = CreateLocation("Boyars` Quarters");
        public readonly static Location MerchantsQuarters = CreateLocation("Merchants` Quarters");
        public readonly static Location LaborersQuarters = CreateLocation("Laborers` Quarters");
        public readonly static Location BastionOfIron = CreateLocation("Bastion of Iron");
        public readonly static Location Harbour = CreateLocation("Harbour (Lekar)");
        public readonly static Location DocksLekar = CreateLocation("Docks (Lekar)");
        public readonly static Location OpenMarket = CreateLocation("Open Market (Lekar)");
        public readonly static Location GateOfJustice = CreateLocation("Gate of Justice");
        public readonly static Location Slaughterhouse = CreateLocation("Slaughterhouses (Lekar)");

        public readonly static Location LakeKriegvogel = CreateLocation("Lake Kriegvogel");
        public readonly static Location UpperCitySilbervas = CreateLocation("Upper City (Silbervas)");
        public readonly static Location SummerPalace = CreateLocation("Summer Palace");

        public readonly static Location LowerCitySilbervas = CreateLocation("Lower City (Silbervas)");
        public readonly static Location NachtfliegenWoods = CreateLocation("Nachtfliegen Woods");
        #endregion

        #region Farelle
        public readonly static Location MourfaRiver = CreateLocation("Mourfa River", "River Mourfa");
        #endregion

        #region Forlorn
        public readonly static Location CastleTristenoira = CreateLocation("Castle Tristenoira", "Castle of Forlorn");
        public readonly static Location LakeRedTears = CreateLocation("Lake of Red Tears");
        #endregion

        #region G'Henna
        public readonly static Location Outland = CreateLocation("The Outland");
        public readonly static Location YagnoPetrovnaTemple = CreateLocation("Yagno Petrovna`s Temple", "Temple of Zhakata");
        #endregion

        #region Ghastria
        public readonly static Location TheGoldWolf = CreateLocation("The Gold Wolf Inn");
        public readonly static Location TheDarkHeart = CreateLocation("The Dark Heart Inn");
        public readonly static Location StezenManorHouse = CreateLocation("Stezen`s Manor House");
        public readonly static Location GarnRiver = CreateLocation("Garn River");
        public readonly static Location GhastriaStables = CreateLocation("Stables (Ghastria)");
        public readonly static Location GhastriaOpenAirMarket = CreateLocation("Open Air Market (Ghastria)");
        public readonly static Location GhastriaMill = CreateLocation("Mill (Ghastria)");
        public readonly static Location GhastriaAbandonedChapel = CreateLocation("Abandoned Chapel (Ghastria)");
        #endregion
        
        #region Gundarak
        public readonly static Location CastleHunadora = CreateLocation("Castle Hunadora");
        public readonly static Location DrDominianiKeep = CreateLocation("Dr. Dominiani`s Keep", "Doctor Dominiani`s Keep");
        #endregion

        #region HarAkir
        public readonly static Location PharaohsRest = CreateLocation("Pharaoh`s Rest");
        public readonly static Location AnhkepotTomb = CreateLocation("Anhkepot`s Tomb");
        #endregion

        #region Hazlan
        public readonly static Location TheTables = CreateLocation("The Tables");
        public readonly static Location HazlikEstate = CreateLocation("Hazlik`s Estate", "Veneficus");
        public readonly static Location TheBoneHeap = CreateLocation("The Bone Heap");
        #endregion

        #region House of Lament
        public readonly static Location HouseOfLament = CreateLocation("House of Lament");
        #endregion

        #region Kartakass
        public readonly static Location ChurchOfMilil = CreateLocation("Church of Milil");
        public readonly static Location KartakanInn = CreateLocation("Kartakan Inn", "Old Kartakan Inn and Taverna");
        public readonly static Location MeistersingerMansion = CreateLocation("Meistersinger Mansion");
        public readonly static Location MeistersingerKeep = CreateLocation("Meistersinger Keep");
        public readonly static Location MeistersingerDungeon = CreateLocation("Meistersinger Dungeon");
        public readonly static Location RadagaCavern = CreateLocation("Radaga`s Cavern");
        public readonly static Location KartakanWoods = CreateLocation("Kartakan Woods");
        public readonly static Location HarmonicHall = CreateLocation("Harmonic Hall");
        public readonly static Location CrystalClub = CreateLocation("Crystal Club Tavern");
        public readonly static Location RoadToHarmony = CreateLocation("The Road to Harmony");
        public readonly static Location TheLoop = CreateLocation("The Loop");
        public readonly static Location Amphitheater = CreateLocation("The Amphitheater");
        public readonly static Location SouthHillHarmonia = CreateLocation("South Hill (Harmonia)");
        public readonly static Location SouthGateHarmonia = CreateLocation("South Gate (Harmonia)");
        public readonly static Location WestGateHarmonia = CreateLocation("West Gate (Harmonia)");
        public readonly static Location CityMoatHarmonia = CreateLocation("City Moat (Harmonia)");
        public readonly static Location MinstrelRiver = CreateLocation("Minstrel River");
        public readonly static Location WhirlingBridge = CreateLocation("Whirling Bridge of Harmonia");
        public readonly static Location GuardTowersHarmonia = CreateLocation("Guard Towers (Harmonia)");
        public readonly static Location CliffLift = CreateLocation("Cliff Lift");
        public readonly static Location TheGreatCatapult = CreateLocation("The Great Catapult");
        public readonly static Location JailHouseHarmonia = CreateLocation("Jail House (Harmonia)");
        public readonly static Location TheAlleyHarmonia = CreateLocation("The Alley (Harmonia)");
        public readonly static Location MariaFarm = CreateLocation("Maria`s Farm", "Ontash`s Home");
        public readonly static Location JackquesFarm = CreateLocation("Jackques` Farm");
        public readonly static Location CatacombsOfRadaga = CreateLocation("Catacombs of Kartakass", "Catacombs of Radaga");
        public readonly static Location SingSong = CreateLocation("Sing Song River");
        public readonly static Location TheCauldron = CreateLocation("The Cauldron");
        public readonly static Location GundarRoad = CreateLocation("Gundar Road", "Old Kartakan Road");
        public readonly static Location PeasantsWay = CreateLocation("Peasants` Way");
        public readonly static Location DireCreek = CreateLocation("Dire Creek");
        public readonly static Location ClockTowerMill = CreateLocation("Clock Tower Mill");
        public readonly static Location MillHouseSkald = CreateLocation("Mill House (Skald)");
        public readonly static Location OldFortress = CreateLocation("Old Fortress");
        public readonly static Location OutTown = CreateLocation("Out Town");
        public readonly static Location TheWharvesSkald = CreateLocation("The Wharves (Skald)");
        public readonly static Location LowerSkald = CreateLocation("Lower Skald");
        public readonly static Location SkaldSawMill = CreateLocation("Skald Saw Mill");
        public readonly static Location LowerTollBridge = CreateLocation("Lower Toll Bridge");
        public readonly static Location UpperTollBridge = CreateLocation("Upper Toll Bridge");
        public readonly static Location UpperIsland = CreateLocation("Upper Island");
        public readonly static Location LowerIsland = CreateLocation("Lower Island");
        public readonly static Location HighWharves = CreateLocation("High Wharves");
        public readonly static Location UpperSkald = CreateLocation("Upper Skald");
        public readonly static Location GrandHallOfSongAndDance = CreateLocation("Grand Hall of Song and Dance");
        public readonly static Location OldShacks = CreateLocation("Old Shacks");
        public readonly static Location ArkaliasHill = CreateLocation("Arkalias Hill");
        #endregion

        #region Keening
        public readonly static Location MountLament = CreateLocation("Mount Lament");
        public readonly static Location BansheeLair = CreateLocation("Banshee Lair");
        public readonly static Location KryderRiver = CreateLocation("Kryder River");
        public readonly static Location OldToll = CreateLocation("Old Toll");
        public readonly static Location AlbiaCreek = CreateLocation("Albia Creek");
        public readonly static Location CityOfTheDeadMarketSquare = CreateLocation("Market Square (City of the Dead)");
        public readonly static Location CityOfTheDeadPalace = CreateLocation("Palace (City of the Dead)");
        public readonly static Location CityOfTheDeadOldMarket = CreateLocation("Old Market (City of the Dead)");
        public readonly static Location CityOfTheDeadBarracks = CreateLocation("Barracks (City of the Dead)");
        public readonly static Location CityOfTheDeadArena = CreateLocation("Arena (City of the Dead)");
        public readonly static Location CityOfTheDeadInn = CreateLocation("Inn (City of the Dead)");
        public readonly static Location CityOfTheDeadTemple = CreateLocation("Temple (City of the Dead)");
        public readonly static Location CityOfTheDeadMill = CreateLocation("Mill (City of the Dead)");
        public readonly static Location CityOfTheDeadBath = CreateLocation("Bath (City of the Dead)");
        public readonly static Location CityOfTheDeadGate = CreateLocation("Gate (City of the Dead)");
        public readonly static Location CityOfTheDeadNewWall = CreateLocation("New Wall (City of the Dead)");
        public readonly static Location CityOfTheDeadOldWall = CreateLocation("Old Wall (City of the Dead)");
        public readonly static Location CityOfTheDeadBellTower = CreateLocation("Bell Tower (City of the Dead)");
        public readonly static Location CityOfTheDeadGrainMarket = CreateLocation("Grain Market (City of the Dead)");
        public readonly static Location CityOfTheDeadClothMarket = CreateLocation("Cloth Market (City of the Dead)");
        public readonly static Location CityOfTheDeadNewMarketFair = CreateLocation("New Market Fair (City of the Dead)");
        public readonly static Location CityOfTheDeadLaborersQuarter = CreateLocation("Laborer`s Quarter (City of the Dead)");
        public readonly static Location CityOfTheDeadSeasonalHorseMarket = CreateLocation("Seasonal Horse Market (City of the Dead)");
        public readonly static Location CityOfTheDeadResidentialDistrict = CreateLocation("Residential District (City of the Dead)");
        public readonly static Location CityOfTheDeadTannersDistrict = CreateLocation("Tanner`s District (City of the Dead)");
        public readonly static Location CityOfTheDeadBusinessDistrict = CreateLocation("Business District (City of the Dead)");
        public readonly static Location CityOfTheDeadMetalworkersDistrict = CreateLocation("Metalworker`s District (City of the Dead)");
        public readonly static Location CityOfTheDeadManorHouse = CreateLocation("Manor House (City of the Dead)");
        public readonly static Location CityOfTheDeadAleHouse = CreateLocation("Ale House (City of the Dead)");
        #endregion

        #region Lamordia
        public readonly static Location IsleOfAgony = CreateLocation("Isle of Agony");
        public readonly static Location TheFinger = CreateLocation("The Finger");
        public readonly static Location AbandonedEstate = CreateLocation("Abandoned Estate (Lamordia)");
        public readonly static Location DharlaethAsylum = CreateLocation("Dharlaeth Asylum");
        public readonly static Location SleepingBeast = CreateLocation("Sleeping Beast");
        public readonly static Location SchlossMordenheim = CreateLocation("Schloss Mordenheim", "Mordenheim`s Estate");
        public readonly static Location BlackRiver = CreateLocation("Black River");
        public readonly static Location OuterWard = CreateLocation("Outer Ward");
        public readonly static Location RoadToAubreckerCastle = CreateLocation("Road to Aubrecker`s Castle");
        public readonly static Location AubreckerCastle = CreateLocation("Aubrecker`s Castle");
        #endregion

        #region Leederik's Tower
        public readonly static Location LeederiksTower = CreateLocation("Leederik`s Tower");
        #endregion

        #region Liffe
        public readonly static Location MoondaleInn = CreateLocation("Moondale Inn");
        public readonly static Location NeverwereManor = CreateLocation("Neverwere Manor");
        public readonly static Location ArmeikosConstable = CreateLocation("Constable Station of Armeikos");
        public readonly static Location HordumRiver = CreateLocation("Hordum River");
        public readonly static Location HordumBay = CreateLocation("Hordum Bay");
        public readonly static Location SoundOfLiffe = CreateLocation("Sound of Liffe");
        public readonly static Location HouseOfAlisia = CreateLocation("House of Alisia");
        public readonly static Location HouseOfEronNalwand = CreateLocation("House of Eron Nalwand");
        public readonly static Location HouseOfTheaGyntheos = CreateLocation("House of Thea Gyntheos");
        public readonly static Location HouseOfSinaraDoom = CreateLocation("House of Sinara Doom");
        #endregion

        #region Lighthouse
        public readonly static Location EyeOfMidnight = CreateLocation("Eye of Midnight");
        #endregion

        #region Markovia
        public readonly static Location Temple = CreateLocation("Temple");
        public readonly static Location Quarters = CreateLocation("Quarters");
        public readonly static Location HallOfNecessity = CreateLocation("Hall of Necessity");
        public readonly static Location Library = CreateLocation("Library");
        public readonly static Location LiftHouse = CreateLocation("Lift House");
        public readonly static Location ContemplationHall = CreateLocation("Contemplation Hall");
        public readonly static Location MarkovEstate = CreateLocation("Markov Estate", "The House of Diosamblet");
        #endregion

        #region Mordent
        public readonly static Location SaulbridgeSanitarium = CreateLocation("Saulbridge Sanitarium");
        public readonly static Location GryphonHill = CreateLocation("Gryphon Hill");
        public readonly static Location GryphonHillMansion = CreateLocation("Gryphon Hill Mansion");
        public readonly static Location GryphonHillCemetery = CreateLocation("Gryphon Hill Cemetery", "Gryphon Hill Graveyard");
        public readonly static Location HeatherHouse = CreateLocation("Weathermay Estate", "Heather House");
        public readonly static Location WeathermayEstate = HeatherHouse;
        public readonly static Location WeathermayMausoleum = CreateLocation("Weathermay Mausoleum");
        public readonly static Location BlackardInn = CreateLocation("Blackard Inn");
        public readonly static Location Livery = CreateLocation("Livery (Mordentshire)");
        public readonly static Location Garrison = CreateLocation("Garrison (Mordentshire)");
        public readonly static Location BurnedChurch = CreateLocation("Burned Church (Mordentshire)", "Church of High Faith", "Ruined Church (Mordentshire)");
        public readonly static Location Smithy = CreateLocation("Smithy (Mordentshire)");
        public readonly static Location MayorsHouse = CreateLocation("Mayor's House (Mordentshire)");
        public readonly static Location KervilsShop = CreateLocation("Kervil's Shop", "Kervil's General Store");
        public readonly static Location Marketplace = CreateLocation("Marketplace (Mordentshire)");
        public readonly static Location Warehouse = CreateLocation("Warehouse (Mordentshire)");
        public readonly static Location SouthRoad = CreateLocation("South Road (Mordentshire)");
        public readonly static Location KeeldevilPoint = CreateLocation("Keeldevil Point");
        public readonly static Location FishermanAlley = CreateLocation("Fisherman`s Alley");
        public readonly static Location ShippingHouse = CreateLocation("Shipping House (Mordentshire)");
        public readonly static Location SeventhSea = CreateLocation("The Seventh Sea");
        public readonly static Location TravelersInn = CreateLocation("Traveler`s Inn");
        public readonly static Location AnchorStreet = CreateLocation("Anchor Street");
        public readonly static Location ShoreLane = CreateLocation("Shore Lane");
        public readonly static Location MillRoad = CreateLocation("Mill Road");
        public readonly static Location MillBridge = CreateLocation("Mill Bridge");
        public readonly static Location OldMill = CreateLocation("Old Mill (Mordentshire)");
        public readonly static Location Churchyard = CreateLocation("Churchyard (Mordentshire)");
        public readonly static Location OldSaltHouse = CreateLocation("Old Salt House");
        public readonly static Location SaltyDogTavern = CreateLocation("Salty Dog Tavern");
        public readonly static Location Butcher = CreateLocation("Butcher (Mordentshire)");
        public readonly static Location Bakery = CreateLocation("Bakery (Mordentshire)");
        public readonly static Location Groundskeeper = CreateLocation("Groundskeeper");
        public readonly static Location OldBooks = CreateLocation("Old Books");
        public readonly static Location Wharf = CreateLocation("Wharf (Mordentshire)");
        public readonly static Location Farms = CreateLocation("Farms (Mordentshire)");
        public readonly static Location ArdentBay = CreateLocation("Ardent Bay");
        public readonly static Location WindwandAvenue = CreateLocation("Windwand Avenue");
        public readonly static Location GlenRoad = CreateLocation("Glen Road");
        public readonly static Location MordentMarketStreet = CreateLocation("Market Street");
        public readonly static Location Barracks = CreateLocation("Barracks (Mordentshire)");
        public readonly static Location Gaol = CreateLocation("Gaol (Mordentshire)");
        public readonly static Location HeatherWay = CreateLocation("Heather Way");
        public readonly static Location MaddingRoad = CreateLocation("Madding Road");
        public readonly static Location Backwater = CreateLocation("Backwater");
        public readonly static Location ButcherLane = CreateLocation("Butcher Lane");
        public readonly static Location WoodHollow = CreateLocation("Wood Hollow");
        public readonly static Location Cliffedge = CreateLocation("Cliffedge (Mordentshire)");
        public readonly static Location Scrimshaw = CreateLocation("Scrimshaw");
        public readonly static Location NorthRoad = CreateLocation("North Road (Mordentshire)");
        public readonly static Location Moors = CreateLocation("Moors (Mordentshire)");
        public readonly static Location NorthMoors = CreateLocation("North Moors");
        public readonly static Location Cliffs = CreateLocation("Cliffs (Mordentshire)");
        public readonly static Location DarkWoods = CreateLocation("Dark Woods (Mordentshire)");
        public readonly static Location GryphonRoad = CreateLocation("Gryphon Road");
        public readonly static Location Bog = CreateLocation("Bog (Mordentshire)");
        public readonly static Location MordentshireCemetery = CreateLocation("Cemetery (Mordentshire)");
        public readonly static Location HiddenTrack = CreateLocation("Hidden Track (Gryphon Hill)", "Hidden Path (Gryphon Hill)");
        public readonly static Location HeatherHousePoint = CreateLocation("Heather House Point");
        public readonly static Location Heatherwood = CreateLocation("Heatherwood");
        public readonly static Location HeatherRoad = CreateLocation("Heather Road");
        public readonly static Location LostRoad = CreateLocation("Lost Road");
        #endregion

        #region Nebligtode
        public readonly static Location TheEndurance = CreateLocation("The Endurance", "Ship of Horror");
        public readonly static Location EternalTorture = CreateLocation("Eternal Torture");
        public readonly static Location GrabenIsland = CreateLocation("Graben Island");
        public readonly static Location GrabenFamilyEstate = CreateLocation("Graben Family Estate");
        public readonly static Location Todstein = CreateLocation("Todstein");
        public readonly static Location MeredothChamber = CreateLocation("Meredoth Chamber");
        public readonly static Location KnammenIsland = CreateLocation("Knammen Island");
        public readonly static Location GrabenBakery = CreateLocation("Bakery (Graben)");
        public readonly static Location GrabenButcher = CreateLocation("Butcher (Graben)");
        public readonly static Location GrabenCooper = CreateLocation("Cooper (Graben)");
        public readonly static Location GrabenCottonSpinner = CreateLocation("Cotton Spinner (Graben)");
        public readonly static Location GrabenFishMarket = CreateLocation("Fish Market (Graben)");
        public readonly static Location GrabenGeneralStore = CreateLocation("General Store (Graben)");
        public readonly static Location BlackSheepInn = CreateLocation("The Black Sheep Inn");
        public readonly static Location GrabenMill = CreateLocation("Mill (Graben)");
        public readonly static Location GrabenWeaver = CreateLocation("Weaver (Graben)");
        public readonly static Location GrabenWoolSpinner = CreateLocation("Wool Spinner (Graben)");
        public readonly static Location GrabenCemetery = CreateLocation("Cemetery (Graben)");
        public readonly static Location TodsteinMausoleums = CreateLocation("Mausoleums (Todstein)");
        #endregion

        #region Nova Vaasa
        public readonly static Location HiregaardCastle = CreateLocation("Hiregaard`s Castle", "Faerhaaven");
        #endregion

        #region Richemulot
        public readonly static Location RenierEstate = CreateLocation("Renier Estate", "Chateau Delanuit");
        #endregion

        #region Risibilos
        public readonly static Location RisibilosCastle = CreateLocation("Risibilos Castle");
        #endregion

        #region Sanguinia
        public readonly static Location MountRadu = CreateLocation("Nedragaard Keep");
        public readonly static Location CastleGuirgiu = CreateLocation("Castle Guirgiu", "Mircea`s Castle");
        public readonly static Location LakeArgus = CreateLocation("Lake Argus");
        #endregion

        #region Sebua
        public readonly static Location TheAbyss = CreateLocation("The Abyss");
        public readonly static Location ValleyOfDeath = CreateLocation("Valley of Death");
        public readonly static Location TempleOfApophis = CreateLocation("Temple of Apophis");
        public readonly static Location RedOasis = CreateLocation("Red Oasis");
        public readonly static Location SebuaWell = CreateLocation("Well (Sebua)");
        public readonly static Location FetidWell = CreateLocation("Fetid Well");
        public readonly static Location SandstoneTowers = CreateLocation("Sandstone Towers");
        public readonly static Location SebuaDunes = CreateLocation("Dunes");
        public readonly static Location RockyHills = CreateLocation("Rocky Hills");
        public readonly static Location DryRiverBed = CreateLocation("Dry River Bed");
        public readonly static Location TiyetEstate = CreateLocation("Tiyet`s Estate");
        public readonly static Location SebuaOasis = CreateLocation("Oasis (Sebua)");
        #endregion

        #region Shadowborn Manor
        public readonly static Location ShadowbornManor = CreateLocation("Shadowborn Manor");
        #endregion

        #region Sithicus
        public readonly static Location NedragaardKeep = CreateLocation("Nedragaard Keep");
        #endregion

        #region Souragne
        public readonly static Location Tristepas = CreateLocation("Tristepas");
        public readonly static Location LakeNoir = CreateLocation("Lake Noir");
        #endregion

        #region Sri Raji / Kalakeri
        public readonly static Location YamashaMountains = CreateLocation("Yamasha Mountains");
        public readonly static Location MountYamatali = CreateLocation("Mount Yamatali", "Mount Yamati");
        public readonly static Location ArijaniTemple = CreateLocation("Arijani`s Temple", "Mahakala");
        public readonly static Location LakeVeda = CreateLocation("Lake Veda");
        #endregion

        #region Staunton Bluffs
        public readonly static Location CastleStonecrest = CreateLocation("Castle Stonecrest");
        public readonly static Location WillisRiver = CreateLocation("Willis River", "River Willis");
        #endregion

        #region Tepest
        public readonly static Location TimoriRoad = CreateLocation("Timori Road");
        public readonly static Location LakeKronov = CreateLocation("Lake Kronov");
        public readonly static Location GoblinLairs = CreateLocation("Goblin Lairs");
        public readonly static Location HagCottage = CreateLocation("Hag Cottage");
        public readonly static Location CauldronOfRegeneration = CreateLocation("Cauldron of Regeneration");
        #endregion

        #region Valachan
        public readonly static Location CastlePantara = CreateLocation("Castle Pantara");
        #endregion

        #region Vechor
        public readonly static Location CliffsOfVesani = CreateLocation("The Cliffs of Vesani");
        public readonly static Location NostruRiver = CreateLocation("Nostru River", "River Nostru");
        #endregion

        #region Verbrek
        public readonly static Location TheCircle = CreateLocation("The Circle");
        #endregion

        #region Vorostokov
        public readonly static Location BottomlessLake = CreateLocation("Bottomless Lake");
        public readonly static Location GregorsCave = CreateLocation("Gregor`s Cave");
        public readonly static Location RiverTrau = CreateLocation("River Trau");
        public readonly static Location VorostokovCarpenter = CreateLocation("Carpenter (Vorostokov)");
        public readonly static Location VorostokovSmokehouse = CreateLocation("Smokehouse (Vorostokov)");
        public readonly static Location VorostokovTanner = CreateLocation("Tanner (Vorostokov)");
        public readonly static Location VorostokovFurrier = CreateLocation("Furrier (Vorostokov)");
        public readonly static Location VorostokovTrader = CreateLocation("Trader (Vorostokov)");
        public readonly static Location VorostokovSmithy = CreateLocation("Smithy (Vorostokov)");
        public readonly static Location Sauna = CreateLocation("Sauna", "Communal Sweathouse");
        public readonly static Location AlehouseMeetingHall = CreateLocation("Alehouse Meeting Hall");
        public readonly static Location VillageGreen = CreateLocation("Village Green", "The Green");
        public readonly static Location GregorsHome = CreateLocation("Gregor`s Home");
        public readonly static Location MariksHome = CreateLocation("Marik`s Home");
        #endregion

        #region Paridon / Zherisia
        public readonly static Location RhastikRiver = CreateLocation("Rhastik River", "River Rhastik");
        #endregion

        public readonly static Location WindingRoad = CreateLocation("Winding Road");

        #region Inside Ravenloft
        public readonly static Location QuebeHauntedMansion = CreateLocation("Quebe`s Haunted Mansion");
        public readonly static Location CastleBloodmere = CreateLocation("Castle Bloodmere");
        public readonly static Location UnderDread = CreateLocation("UnderDread");
        public readonly static Location DreadChamber = CreateLocation("The Dread Chamber");
        public readonly static Location TowerOfSpirits = CreateLocation("Tower of Spirits");
        public readonly static Location TheDeathShip = CreateLocation("The Death Ship");
        public readonly static Location HauntedGraveyard = CreateLocation("Haunted Graveyard");
        public readonly static Location MadScientistLaboratory = CreateLocation("Mad Scientist`s Laboratory");
        public readonly static Location RuinsOfLololia = CreateLocation("The Ruins of Lololia");
        public readonly static Location TowerOfThalus = CreateLocation("Tower of Thalus");
        public readonly static Location Balinoks = CreateLocation("Balinoks", "Balinok Mountains");
        public readonly static Location RiverVuchar = CreateLocation("River Vuchar", "Vuchar River");
        public readonly static Location RiverMusarde = CreateLocation("River Musarde", "Musarde River");
        public readonly static Location RiverArden = CreateLocation("River Arden", "Arden River");
        public readonly static Location NightbloodCatacombs = CreateLocation("Nightblood Catacombs", "Nightblood Crypt", "Nightblood Lair");
        #region Aferdale
        public readonly static Location BaggsFarm = CreateLocation("Baggs Farm");
        public readonly static Location AferdaleCemetery = CreateLocation("Aferdale Cemetery");
        public readonly static Location WeppesInn = CreateLocation("Weppe`s Inn");
        public readonly static Location AdventuresRest = CreateLocation("Adventure`s Rest");
        public readonly static Location AferdaleHorseRanch = CreateLocation("Aferdale Horse Ranch");
        public readonly static Location AferdaleCattleRanch = CreateLocation("Aferdale Cattle Ranch");
        public readonly static Location AferdaleMalarTemple = CreateLocation("Aferdale Temple of the Wind", "Aferdale Temple of Weeshy");
        public readonly static Location AferdaleAlfalfaFarm = CreateLocation("Aferdale Alfalfa Farm");
        public readonly static Location AferdaleTempleOfMilil = CreateLocation("Aferdale Temple of Milil");
        public readonly static Location ParsedLip = CreateLocation("Parsed Lip");
        public readonly static Location YearningGoblet = CreateLocation("Yearning Goblet");
        public readonly static Location MiddleInn = CreateLocation("Middle Inn");
        public readonly static Location WagonsRest = CreateLocation("Wagon`s Rest");
        public readonly static Location AferdaleConstabulary = CreateLocation("Aferdale Constabulary", "Aferdale Jail");
        public readonly static Location AferdaleHunterGuild = CreateLocation("Aferdale Hunter`s Guild");
        #endregion
        #endregion
    }
}