using System.Threading;

public partial class Factory : IDisposable
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
        public readonly static Location BaroviaChurch = CreateLocation("Church (Barovia)");
        public readonly static Location BildrathMercantile = CreateLocation("Bildrath's Mercantile");
        public readonly static Location BloodVineTavern = CreateLocation("Blood of the Vine Tavern", "Blood on the Vine Tavern");
        public readonly static Location MaryHouse = CreateLocation("Mad Mary's Townhouse");
        public readonly static Location BurgomasterHome = CreateLocation("Burgomaster's Home");
        public readonly static Location BurgomasterGuestHouse = CreateLocation("Burgomaster's Guest House");
        public readonly static Location BaroviaCemetery = CreateLocation("Cemetery (Barovia)");
        public readonly static Location MadamEvasTent = CreateLocation("Madam Eva's Tent");
        public readonly static Location OldSvalichRoad = CreateLocation("Old Svalich Road");
        public readonly static Location GatesOfBarovia = CreateLocation("Gates of Barovia");
        public readonly static Location SvalichWoods = CreateLocation("Svalich Woods");
        public readonly static Location RiverIvlis = CreateLocation("River Ivlis");
        public readonly static Location RiverLuna = CreateLocation("River Luna");
        public readonly static Location RoadJunction = CreateLocation("Road Junction (Barovia)");
        public readonly static Location TserFalls = CreateLocation("Tser Falls");
        public readonly static Location TserPool = CreateLocation("Tser Pool");
        public readonly static Location GatesOfRavenloft = CreateLocation("Gates of Ravenloft");
        public readonly static Location OldBonegrinder = CreateLocation("Old Bonegrinder");
        public readonly static Location MountBaratak = CreateLocation("Mount Baratak");
        public readonly static Location MountGhakis = CreateLocation("Mount Ghakis");
        public readonly static Location LakeZarovich = CreateLocation("Lake Zarovich");
        public readonly static Location TepurichForest = CreateLocation("Tepurich Forest");
        #endregion

        #region Darkon
        public readonly static Location MillsOfNartok = CreateLocation("Lumber Mills (Nartok)");
        public readonly static Location AzalinsGraveyard = CreateLocation("Azalin`s Graveyard");
        public readonly static Location KargatMausoleum = CreateLocation("Kargat Mausoleum");
        #endregion

        #region Dementlieu
        public readonly static Location ParnaultBay = CreateLocation("Parnault Bay");
        #endregion

        #region Dorvinia
        public readonly static Location MountGries = CreateLocation("Mount Gries");
        public readonly static Location DilisnyaEstate = CreateLocation("Dilisnya Family Estate");
        public readonly static Location DoldakHeights = CreateLocation("Doldak Heights");
        #endregion

        #region Falkovnia
        public readonly static Location LakeKriegvogel = CreateLocation("Lake Kriegvogel");
        #endregion

        #region Forlorn
        public readonly static Location CastleTristenoira = CreateLocation("Castle Tristenoira");
        public readonly static Location LakeRedTears = CreateLocation("Lake of Red Tears");
        #endregion

        #region G'Henna
        public readonly static Location Outland = CreateLocation("The Outland");
        #endregion
        
        #region Gundarak
        public readonly static Location CastleHunadora = CreateLocation("Castle Hunadora");
        #endregion

        #region HarAkir
        public readonly static Location PharaohsRest = CreateLocation("Pharaoh`s Rest");
        #endregion

        #region Hazlan
        public readonly static Location TheTables = CreateLocation("The Tables");
        #endregion

        #region Kartakass
        public readonly static Location ChurchOfMilil = CreateLocation("Church of Milil");
        public readonly static Location MeistersingerMansion = CreateLocation("Meistersinger Mansion");
        #endregion

        #region Lamordia
        public readonly static Location DharlaethAsylum = CreateLocation("Dharlaeth Asylum");
        public readonly static Location IsleOfAgony = CreateLocation("Isle of Agony");
        public readonly static Location SleepingBeast = CreateLocation("Sleeping Beast");
        public readonly static Location SchlossMordenheim = CreateLocation("Schloss Mordenheim");
        #endregion

        #region Mordent
        public readonly static Location SaulbridgeSanitarium = CreateLocation("Saulbridge Sanitarium");
        public readonly static Location GryphonHill = CreateLocation("Gryphon Hill");
        public readonly static Location GryphonHillMansion = CreateLocation("Gryphon Hill Mansion");
        public readonly static Location HeatherHouse = CreateLocation("Weathermay Estate", "Heather House");
        public readonly static Location WeathermayEstate = HeatherHouse;
        public readonly static Location WeathermayMausoleum = CreateLocation("Weathermay Mausoleum");
        public readonly static Location BlackardInn = CreateLocation("Blackard Inn");
        public readonly static Location Livery = CreateLocation("Livery (Mordentshire)");
        public readonly static Location Garrison = CreateLocation("Garrison (Mordentshire)");
        public readonly static Location BurnedChurch = CreateLocation("Burned Church (Mordentshire)", "Church of High Faith");
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
        public readonly static Location MarketStreet = CreateLocation("Market Street");
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
        public readonly static Location HiddenTrack = CreateLocation("Hidden Track (Gryphon Hill)");
        public readonly static Location HeatherHousePoint = CreateLocation("Heather House Point");
        public readonly static Location Heatherwood = CreateLocation("Heatherwood");
        public readonly static Location HeatherRoad = CreateLocation("Heather Road");
        #endregion

        #region Sanguinia
        public readonly static Location MountRadu = CreateLocation("Nedragaard Keep");
        public readonly static Location CastleGuirgiu = CreateLocation("Castle Guirgiu");
        public readonly static Location LakeArgus = CreateLocation("Lake Argus");
        #endregion

        #region Sithicus
        public readonly static Location NedragaardKeep = CreateLocation("Nedragaard Keep");
        #endregion

        #region Sri Raji / Kalakeri
        public readonly static Location YamashaMountains = CreateLocation("Yamasha Mountains");
        public readonly static Location MountYamatali = CreateLocation("Mount Yamatali");
        #endregion

        #region Staunton Bluffs
        public readonly static Location CastleStonecrest = CreateLocation("Castle Stonecrest");
        #endregion

        #region Tepest
        public readonly static Location TimoriRoad = CreateLocation("Timori Road");
        public readonly static Location LakeKronov = CreateLocation("Lake Kronov");
        #endregion

        #region Valachan
        public readonly static Location CastlePantara = CreateLocation("Castle Pantara");
        #endregion

        #region Verbrek
        public readonly static Location CliffsOfVesani = CreateLocation("The Cliffs of Vesani");
        #endregion

        #region Verbrek
        public readonly static Location TheCircle = CreateLocation("The Circle");
        #endregion

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
        public readonly static Location RiverVuchar = CreateLocation("River Vuchar");
        public readonly static Location RiverMusarde = CreateLocation("River Musarde");
        public readonly static Location RiverArden = CreateLocation("River Arden");
        #endregion
    }
}