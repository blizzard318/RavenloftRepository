internal static partial class AddToDatabase
{
    public static void Add0 () 
    {
        //Domains, NPCs, Items and Locations are Source-locked, but not Traits.
        //Consider not making new instances within Create, so that adding can be better structured.
        AddI6Ravenloft();
        AddI10TheHouseOnGryphonHill();

        Factory.db.SaveChanges();

        void AddI6Ravenloft()
        {
            var releaseDate = "01/11/1983";
            string ExtraInfo = "<br/>&emsp;Authors: Tracy Hickman and Laura Hickman";
            ExtraInfo += "<br/>&emsp;Editor: Curtis Smith";
            ExtraInfo += "<br/>&emsp;Graphic Designer: Debra Stubbe";
            ExtraInfo += "<br/>&emsp;Illustrator: Clyde Caldwell";
            ExtraInfo += "<br/>&emsp;Module Info: An adventure for 6-8 characters of levels 5-7";
            using var ctx = Factory.CreateSource("I6: Ravenloft", releaseDate, ExtraInfo, Traits.Edition.e1, Traits.Media.module);
            if (ctx == null) return;

            #region Domains
            var Barovia = ctx.CreateDomain("Barovia").AddTraits(Traits.Creature.Ghoul);
            #endregion

            #region Locations
            var VillageOfBarovia = ctx.CreateSettlement("Village of Barovia", "1, 6, 7");
            var BildrathMercantile = ctx.CreateLocation("Bildrath's Mercantile", "8");
            var BloodVineTavern = ctx.CreateLocation("Blood of the Vine Tavern", "8, 9").AddInfo("Also known as 'Blood on the Vine' Tavern.");
            var MaryHouse = ctx.CreateLocation("Mad Mary's Townhouse", "9");
            var BurgomasterHome = ctx.CreateLocation("Burgomaster's Home", "1, 9");
            var BarovianChurch = ctx.CreateLocation("Church of Barovia", "9, 10");
            var BurgomasterGuestHouse = ctx.CreateLocation("Burgomaster's Guest House", "9");
            var BaroviaCemetery = ctx.CreateLocation("Cemetery of Barovia", "9, 11").AddTraits(Traits.Creature.Spirit, Traits.Deceased);

            (var TserPoolEncampnent, var TserPoolEncampnentGroup) = ctx.CreateSettlement("Tser Pool Encampment", "11");
            var MadamEvasTent = ctx.CreateLocation("Madam Eva's Tent", "11");

            var CastleRavenloft = ctx.CreateLocation("Castle Ravenloft", "1, 6, 8, 9, 12-30").AddTraits(
                    Traits.Creature.RedDragon, Traits.Creature.ShadowDemon.Item1, Traits.Creature.ShadowDemon.Item2,
                    Traits.Creature.Trapper, Traits.Creature.GiantSpider, Traits.Creature.HugeSpider,
                    Traits.Creature.Skeleton, Traits.Creature.Horse, Traits.Creature.Nightmare, Traits.Creature.Banshee,
                    Traits.Creature.KeeningSpirit.Item1, Traits.Creature.KeeningSpirit.Item2,
                    Traits.Creature.Gargoyle, Traits.Creature.RustMonster, Traits.Creature.GuardianPortrait,
                    Traits.Creature.Spectre, Traits.Creature.Spirit, Traits.Creature.Wight,
                    Traits.Creature.Wraith, Traits.Creature.Ghost, Traits.Creature.Bat, Traits.Deceased,
                    Traits.Creature.StrahdZombie, Traits.Creature.Cat, Traits.Creature.Witch,
                    Traits.Creature.Hellhound, Traits.Creature.Werewolf, Traits.Creature.IronGolem
                );
            #endregion

            #region NPCs
            var MadamEva = ctx.CreateNPC("Madam Eva", "1, 6, 11, 32").AddTraits(Traits.Creature.Human, Traits.Alignment.CN);

            var GuardianOfSorrow = ctx.CreateNPC("Guardian Of Sorrow", "16").AddTraits(Traits.Alignment.NE);
            var LiefLipsiege = ctx.CreateNPC("Lief Lipsiege", "17").AddTraits(Traits.Alignment.CE, Traits.Creature.Human);
            var Helga = ctx.CreateNPC("Helga", "18").AddTraits(Traits.Alignment.CE, Traits.Creature.Human, Traits.Creature.Vampire);
            var CyrusBelview = ctx.CreateNPC("Cyrus Belview", "23").AddTraits(Traits.Alignment.CN, Traits.Creature.Human);

            var SpectreAbCenteer = ctx.CreateNPC("Spectre Ab-Centeer", "27").AddTraits(Traits.Deceased);
            var ArtistaDeSlop = ctx.CreateNPC("Artista DeSlop", "27").AddTraits(Traits.Deceased);
            var LadyIsoldeYunk = ctx.CreateNPC("Isolde the Incredible","Lady Isolde Yunk", "27").AddTraits(Traits.Deceased);
            var AerialDuPlumette = ctx.CreateNPC("Aerial the Heavy", "Prince Aerial Du Plumette", "27").AddTraits(Traits.Alignment.LE, Traits.Creature.Ghost);
            var ArtankSwilovich = ctx.CreateNPC("Artank Swilovich", "27").AddTraits(Traits.Deceased);

            var DorfniyaDilisny = ctx.CreateNPC("Duchess Dorfniya Dilisnya", "28").AddTraits(Traits.Deceased);
            var Pidlwik = ctx.CreateNPC("Pidlwik", "28").AddTraits(Traits.Deceased);
            var LeanneTriksky = ctx.CreateNPC("Sir Lee the Crusher", "Sir Leanne Triksky", "28").AddTraits(Traits.Deceased);
            var TashaPetrovna = ctx.CreateNPC("Tasha Petrovna", "28").AddTraits(Traits.Deceased);
            var KingToisky = ctx.CreateNPC("King Toisky", "28").AddTraits(Traits.Deceased);
            var KingIntreeKatsky = ctx.CreateNPC("Katsky the Bright", "King Intree Katsky", "28").AddTraits(Traits.Deceased);

            var StahbalIndiBhak = ctx.CreateNPC("Stahbal Indi-Bhak", "28").AddTraits(Traits.Alignment.LE, Traits.Creature.Wight);

            var Khazan = ctx.CreateNPC("Khazan", "28").AddTraits(Traits.Deceased);
            var ElsaFallona = ctx.CreateNPC("Elsa Fallona", "28").AddTraits(Traits.Deceased);
            var SedrikSpinwitovich = ctx.CreateNPC("Admiral Spinwitovich", "Sir Sedrik Spinwitovich", "28").AddTraits(Traits.Deceased);
            var Animus = ctx.CreateNPC("Animus", "28").AddTraits(Traits.Deceased);
            var ErikVonderbucks = ctx.CreateNPC("Sir Erik Vonderbucks", "28").AddTraits(Traits.Deceased);
            var IvanDeRose = ctx.CreateNPC("Ivan DeRose", "28").AddTraits(Traits.Deceased);
            var StephanGregorovich = ctx.CreateNPC("Stephan Gregorovich", "28").AddTraits(Traits.Deceased);
            var IntreeSikValoo = ctx.CreateNPC("Intree Sik-Valoo", "28").AddTraits(Traits.Deceased);
            var ArdentPallette = ctx.CreateNPC("Ardent Pallette", "28").AddTraits(Traits.Deceased);
            var IvanIvanovich = ctx.CreateNPC("Ivan Ivanovich", "28").AddTraits(Traits.Deceased);
            var CirilRomulich = ctx.CreateNPC("Prefect Ciril Romulich", "28").AddTraits(Traits.Deceased);

            var Dollars = ctx.CreateNPC("$$", "29").AddTraits(Traits.Deceased);
            var Finderway = ctx.CreateNPC("St. Finderway", "29").AddTraits(Traits.Deceased);
            var Dostron = ctx.CreateNPC("King Dostron", "29").AddTraits(Traits.Deceased);
            var GralmoreNimblenobs = ctx.CreateNPC("Gralmore Nimblenobs", "29").AddTraits(Traits.Deceased);
            var AmericoStandardski = ctx.CreateNPC("Americo Standardski", "29").AddTraits(Traits.Deceased);

            var Beucephalus = ctx.CreateNPC("Beucephalus", "29, 30").AddTraits(Traits.Creature.Horse, Traits.Creature.Nightmare);

            var TatsaulEris = ctx.CreateNPC("Tatsaul Eris", "30").AddTraits(Traits.Deceased);

            var AnnaPetrovna = ctx.CreateNPC("Anna Petrovna", "28").AddInfo("Probably deceased but they never explicitly said so.");
            var Arik = ctx.CreateNPC("Arik", "8").AddTraits(Traits.Alignment.CN, Traits.Creature.Human);
            var Donavich = ctx.CreateNPC("Father Donavich", "9").AddTraits(Traits.Alignment.LG, Traits.Creature.Human);

            var Strahd = ctx.CreateNPC("Count Strahd von Zarovich").AddTraits(
                Traits.Creature.Vampire, Traits.Creature.Human, Traits.Alignment.CE,
                Traits.Creature.Wolf, Traits.Creature.Worg, Traits.Creature.Bat,
                Traits.Creature.StrahdZombie, Traits.Creature.Zombie).AddInfo("'ClosedBorders':'No one has left Barovia for centuries. This is because of the trapping fog that exists everywhere in Barovia. Once it is breathed, it infuses itself around a character's vital organs as a neutralized poison. The fog does not taste or smell any different than normal fog. It does not harm characters as long as they continue to breathe the air in Barovia. However, when they leave Barovia, the poison becomes active. Characters must save vs. poison or start to choke. Unless choking characters reenter Barovia within 24 hours, they die. The choking stops as soon as they breathe the fog again. The fog is magically produced by Strahd and disappears entirely upon his destruction.'");

            var Sergei = ctx.CreateNPC("Sergei von Zarovich", "1, 4, 30, 31").AddTraits(Traits.Deceased,Traits.Creature.Human);

            var KingBarov = ctx.CreateNPC("King Barov von Zarovich", "28, 30").AddTraits(Traits.Creature.Human, Traits.Deceased);
            var Ravenovia = ctx.CreateNPC("Queen Ravenovia von Zarovich", "5, 28, 30").AddTraits(Traits.Creature.Human, Traits.Deceased);
            
            var Marya = ctx.CreateNPC("Marya Markovia", "27, 28").AddTraits(Traits.Deceased);
            var Endorovich = ctx.CreateNPC("Endorovich the Terrible", "27, 28").AddTraits(Traits.Alignment.LE, Traits.Creature.Spectre);

            var SashaIvliskova = ctx.CreateNPC("Sasha Ivliskova", "28").AddTraits(Traits.Alignment.CE, Traits.Creature.Human, Traits.Creature.Vampire);
            var PatrinaVelikovna = ctx.CreateNPC("Patrina Velikovna", "28").AddTraits(Traits.Alignment.CE, Traits.Creature.Elf, Traits.Creature.Banshee);

            var Tatyana = ctx.CreateNPC("Tatyana", "1, 30, 31").AddTraits(Traits.Deceased);

            var KolyanIndirovich = ctx.CreateNPC("Kolyan Indirovich", "7, 8, 9").AddTraits(Traits.Creature.Human, Traits.Deceased);
            var IreenaKolyana = ctx.CreateNPC("Ireena Kolyana").AddTraits(Traits.Alignment.LG, Traits.Creature.Human);
            var Ismark = ctx.CreateNPC("Ismark the Lesser", "8, 9").AddTraits(Traits.Alignment.LG, Traits.Creature.Human);

            var MadMary = ctx.CreateNPC("Mad Mary", "9, 19").AddTraits(Traits.Alignment.CN, Traits.Creature.Human);
            var Gertruda = ctx.CreateNPC("Gertruda", "9, 19").AddTraits(Traits.Alignment.NG, Traits.Creature.Human);
            var Bildrath = ctx.CreateNPC("Bildrath", "8").AddTraits(Traits.Alignment.LG, Traits.Creature.Human);
            var Parriwimple = ctx.CreateNPC("Parriwimple", "8").AddTraits(Traits.Alignment.LN, Traits.Creature.Human);
            #endregion

            #region Items
            var Sunsword = ctx.CreateItem("Sunsword", "5, 31");
            var IconOfRavenloft = ctx.CreateItem("Icon of Ravenloft", "14");
            var SymbolOfRavenloft = ctx.CreateItem("Holy Symbol of Ravenkind", "17, 30").AddTraits(Traits.Creature.Vampire);
            var TomeOfStrahd = ctx.CreateItem("Tome of Strahd", "11, 31");
            #endregion

            #region Groups
            var BarovianWine = ctx.CreateGroup("Barovian Wine Distillers Brotherhood", "27");
            var BridesOfStrahd = ctx.CreateGroup("Brides of Strahd", "28").AddInfo("Count Strahd has collected a few partners over the years.").AddTraits(Traits.Creature.Vampire);
            var ReincarnationsOfTatyana = ctx.CreateGroup("Reincarnations of Tatyana", "30, 31");
            var Gypsy = ctx.CreateGroup("Gypsy", "1, 4, 7, 11, 28");
            var Burgomaster = ctx.CreateGroup("Burgomaster", "1, 7, 8, 9");
            var BurgomasterOfBarovia = ctx.CreateGroup("Burgomaster of Barovia", "1, 7, 8, 9");
            var HighPriestMostHoly = ctx.CreateGroup("High Priest of the Most Holy Order", "28");
            var HighPriestRavenloft = ctx.CreateGroup("High Priest of Ravenloft", "30");
            #endregion

            #region Domain Add
            Barovia.AddLocations(
                    ctx.CreateLocation("The Old Svalich Road", "7"),
                    ctx.CreateLocation("The Gates of Barovia", "7").AddTraits(Traits.Creature.GreenSlime),
                    ctx.CreateLocation("The Svalich Woods", "1, 6-8").AddTraits(Traits.Creature.Worg),
                    ctx.CreateLocation("The River Ivlis", "8"),
                    ctx.CreateLocation("Road Junction", "11"),
                    ctx.CreateLocation("Tser Falls", "11"),
                    ctx.CreateLocation("The Gates of Ravenloft", "11, 12"),
                    VillageOfBarovia.location, BildrathMercantile, BloodVineTavern, MaryHouse, 
                    BurgomasterHome, BurgomasterGuestHouse, BarovianChurch, BaroviaCemetery,
                    TserPoolEncampnent, MadamEvasTent, CastleRavenloft
                );
            Barovia.AddNPCs(MadamEva, GuardianOfSorrow, LiefLipsiege, Helga, CyrusBelview,
                SpectreAbCenteer, ArtistaDeSlop, LadyIsoldeYunk, AerialDuPlumette, ArtankSwilovich,
                DorfniyaDilisny, Pidlwik, LeanneTriksky, TashaPetrovna, KingToisky, KingIntreeKatsky, StahbalIndiBhak,
                Khazan, ElsaFallona, SedrikSpinwitovich, Animus, ErikVonderbucks, IvanDeRose, StephanGregorovich, IntreeSikValoo, ArdentPallette, IvanIvanovich, CirilRomulich,
                Dollars, Finderway, Dostron, GralmoreNimblenobs, AmericoStandardski, Beucephalus, TatsaulEris,
                AnnaPetrovna, Arik, Donavich, Strahd, Sergei, KingBarov, Ravenovia, Marya, Endorovich, SashaIvliskova, PatrinaVelikovna,
                Tatyana, KolyanIndirovich, IreenaKolyana, Ismark, MadMary, Gertruda, Bildrath, Parriwimple);
            Barovia.AddItems(Sunsword, IconOfRavenloft, SymbolOfRavenloft, TomeOfStrahd);
            Barovia.AddGroups(BarovianWine, BridesOfStrahd, ReincarnationsOfTatyana, VillageOfBarovia.settlement, 
                TserPoolEncampnentGroup, Gypsy, Burgomaster, BurgomasterOfBarovia, HighPriestRavenloft, HighPriestMostHoly);

            ctx.OutsideRavenloft.AddNPCs(AnnaPetrovna);
            ctx.OutsideRavenloft.AddItems(Sunsword);
            #endregion

            #region Location Add
            VillageOfBarovia.location.AddGroups(Burgomaster, BurgomasterOfBarovia);
            VillageOfBarovia.location.AddNPCs(Arik, Donavich, KolyanIndirovich, Ismark, IreenaKolyana, SashaIvliskova, MadMary, Gertruda, Bildrath, Parriwimple);

            BurgomasterHome.AddGroups(Burgomaster, BurgomasterOfBarovia);
            BurgomasterHome.AddNPCs(KolyanIndirovich, Ismark, IreenaKolyana);
            BurgomasterGuestHouse.AddGroups(Burgomaster, BurgomasterOfBarovia);
            BurgomasterGuestHouse.AddNPCs(KolyanIndirovich);

            BloodVineTavern.AddNPCs(Arik, Ismark);
            BarovianChurch.AddNPCs(Donavich);
            MaryHouse.AddNPCs(Gertruda, MadMary);
            BildrathMercantile.AddNPCs(Bildrath, Parriwimple);

            TserPoolEncampnent.AddNPCs(MadamEva);
            MadamEvasTent.AddNPCs(MadamEva);

            CastleRavenloft.AddNPCs(
                GuardianOfSorrow, LiefLipsiege, Helga, CyrusBelview, Strahd,
                SpectreAbCenteer, ArtistaDeSlop, LadyIsoldeYunk, AerialDuPlumette, ArtankSwilovich,
                DorfniyaDilisny, Pidlwik, LeanneTriksky, TashaPetrovna, KingToisky, KingIntreeKatsky, StahbalIndiBhak,
                Khazan, ElsaFallona, SedrikSpinwitovich, Animus, ErikVonderbucks, IvanDeRose, StephanGregorovich, IntreeSikValoo, ArdentPallette, IvanIvanovich, CirilRomulich,
                Dollars, Finderway, Dostron, GralmoreNimblenobs, AmericoStandardski, Beucephalus, TatsaulEris, Sergei, KingBarov, Ravenovia, Marya, Endorovich,
                SashaIvliskova, PatrinaVelikovna, Gertruda);
            CastleRavenloft.AddItems(Sunsword, IconOfRavenloft, SymbolOfRavenloft);
            CastleRavenloft.AddGroups(BridesOfStrahd, HighPriestRavenloft, HighPriestMostHoly);
            #endregion

            #region Group Add
            BarovianWine.AddNPCs(ArtankSwilovich);
            BridesOfStrahd.AddNPCs(SashaIvliskova, PatrinaVelikovna);
            ReincarnationsOfTatyana.AddNPCs(Tatyana, IreenaKolyana);

            Burgomaster.AddNPCs(KolyanIndirovich);
            BurgomasterOfBarovia.AddNPCs(KolyanIndirovich);

            HighPriestRavenloft.AddItems(SymbolOfRavenloft);
            HighPriestMostHoly.AddNPCs(CirilRomulich);

            VillageOfBarovia.settlement.PopulateSettlement(BildrathMercantile, BloodVineTavern, MaryHouse, BurgomasterHome, BurgomasterGuestHouse, BarovianChurch, BaroviaCemetery);
            TserPoolEncampnentGroup.PopulateSettlement(MadamEvasTent);

            Gypsy.AddLocations(TserPoolEncampnent, MadamEvasTent);
            Gypsy.AddNPCs(MadamEva);
            #endregion

            #region Item Add
            TomeOfStrahd.AddNPCs(Strahd);
            #endregion

            ctx.CreateRelationship(KingBarov, "Spouse", Ravenovia);
            ctx.CreateRelationship(KingBarov, "Parent", Strahd);
            ctx.CreateRelationship(KingBarov, "Parent", Sergei);
            ctx.CreateRelationship(Ravenovia, "Parent", Strahd);
            ctx.CreateRelationship(Ravenovia, "Parent", Sergei);

            ctx.CreateRelationship(Endorovich, "Loves", Marya);
            ctx.CreateRelationship(Endorovich, "Accidentally Murdered", Marya);

            ctx.CreateRelationship(Strahd, "Spouse", SashaIvliskova);
            ctx.CreateRelationship(Strahd, "Spouse", PatrinaVelikovna);

            ctx.CreateRelationship(Sergei, "Spouse", Tatyana);

            ctx.CreateRelationship(KolyanIndirovich, "Adopted", IreenaKolyana);
            ctx.CreateRelationship(KolyanIndirovich, "Parent", Ismark);

            ctx.CreateRelationship(MadMary, "Parent", Gertruda);
            ctx.CreateRelationship(Gertruda, "Daughter", MadMary);


            ctx.CreateRelationship(Bildrath, "Uncle", Parriwimple);
            ctx.CreateRelationship(Parriwimple, "Nephew", Bildrath);
        }
        void AddI10TheHouseOnGryphonHill()
        {
            var releaseDate = "01/11/1983";
            string ExtraInfo = "<br/>&emsp;Authors: Tracy Hickman and Laura Hickman";
            ExtraInfo += "<br/>&emsp;Design Team: David Cook, Jeff Grubb, Tracy & Laura Hickman, Harold Johnson, and Douglas Niles";
            ExtraInfo += "<br/>&emsp;Editor: Harold Johnson";
            ExtraInfo += "<br/>&emsp;Cover Artist: Clyde Caldwell";
            ExtraInfo += "<br/>&emsp;Interior Artist: Jeff Easley";
            ExtraInfo += "<br/>&emsp;Cartographer: David S. LaForce";
            ExtraInfo += "<br/>&emsp;Typograper: Betty Elmore & Kim Lindau";
            ExtraInfo += "<br/>&emsp;Keyliner: Linda Bakk";
            ExtraInfo += "<br/>&emsp;Module Info: An adventure for 4-6 characters of levels 8-10";
            using var ctx = Factory.CreateSource("I10: Ravenloft II: The House on Gryphon Hill", releaseDate, ExtraInfo, Traits.Edition.e1, Traits.Media.module);
            if (ctx == null) return;

            #region Domains
            var Barovia = ctx.CreateDomain("Barovia", "5");
            var Mordent = ctx.CreateDomain("Mordent");
            #endregion

            #region Locations
            var CastleRavenloft = ctx.CreateLocation("Castle Ravenloft", "5, 12");

            var Mordentshire = ctx.CreateSettlement("Mordentshire");
            var SaulbridgeSanitarium = ctx.CreateLocation("Saulbridge Sanitarium", "6, 13, 23, 24");
            var GryphonHill = ctx.CreateLocation("Gryphon Hill", "1, 2, 7, 16, 19, 22, 23, 25, 26, 28, 32");
            var HouseOnGryphonHill = ctx.CreateLocation("House on Gryphon Hill", "1, 2, 7, 16, 19, 22, 23, 26, 28-31").AddTraits(Traits.Creature.Vampire,
                Traits.Creature.GroaningSpirit.Item1, Traits.Creature.GroaningSpirit.Item2, Traits.Creature.Gargoyle, Traits.Creature.StoneGolem,
                Traits.Creature.Spirit, Traits.Creature.Ghost, Traits.Creature.Mouse, Traits.Creature.GiantSpider, Traits.Creature.Shade, Traits.Creature.Haunt,
                Traits.Creature.Drelb, Traits.Creature.Stirge, Traits.Creature.LurkerAbove, Traits.Creature.QuasiElementalLightning, Traits.Creature.GreenSlime);
            var HeatherHouse = ctx.CreateLocation("Weathermay Estate", "Heather House", "1, 3, 10, 13, 15, 16, 19, 24, 26, 32, 33").AddTraits(Traits.Creature.GiantToad,
                Traits.Creature.Stirge, Traits.Creature.GreenSlime, Traits.Creature.Vampire, Traits.Creature.InvisibleStalker, Traits.Creature.Haunt, Traits.Creature.Shade);
            var WeathermayMausoleum = ctx.CreateLocation("Weathermay Mausoleum", "1, 15, 32");
            var BlackardInn = ctx.CreateLocation("Blackard Inn", "14, 19, 20").AddTraits(Traits.Creature.Spider);
            var Livery = ctx.CreateLocation("Livery of Mordentshire", "14");
            var Garrison = ctx.CreateLocation("Garrison of Mordentshire", "14").AddTraits(Traits.Creature.GiantRat);
            var BurnedChurch = ctx.CreateLocation("Burned Church of Mordentshire", "14, 22");
            var Smithy = ctx.CreateLocation("Smithy of Mordentshire", "14, 22");
            var MayorsHouse = ctx.CreateLocation("Mayor's House of Mordentshire", "1, 14, 23");
            var KervilsShop = ctx.CreateLocation("Kervil's Shop", "Kervil's General Store", "14, 23");
            var Marketplace = ctx.CreateLocation("Marketplace of Mordentshire", "14");
            var Warehouse = ctx.CreateLocation("Warehouse of Mordentshire", "15, 21");
            var SouthRoad = ctx.CreateLocation("South Road", "15, 25");
            var KeeldevilPoint = ctx.CreateLocation("Keeldevil Point", "17");
            var FishermanAlley = ctx.CreateLocation("Fisherman's Alley", "17, 24").AddTraits(Traits.Creature.Doppelganger);
            var ShippingHouse = ctx.CreateLocation("Shipping House", "21");
            var SeventhSea = ctx.CreateLocation("The Seventh Sea", "21");
            var TravelersInn = ctx.CreateLocation("Traveler's Inn", "21");
            var AnchorStreet = ctx.CreateLocation("Anchor Street", "21");
            var ShoreLane = ctx.CreateLocation("Shore Lane", "21");
            var MillRoad = ctx.CreateLocation("Mill Road", "21");
            var MillBridge = ctx.CreateLocation("Mill Bridge", "21").AddTraits(Traits.Creature.Cat);
            var ArdenRiver = ctx.CreateLocation("Arden River", "21, 25");
            var OldMill = ctx.CreateLocation("Old Mill", "21");
            var Churchyard = ctx.CreateLocation("Churchyard of Mordentshire", "22");
            var OldSaltHouse = ctx.CreateLocation("Old Salt House", "22");
            var SaltyDog = ctx.CreateLocation("Salty Dog Tavern", "22");
            var Butcher = ctx.CreateLocation("Butcher of Mordentshire", "22");
            var Bakery = ctx.CreateLocation("Bakery of Mordentshire", "22");
            var Groundskeeper = ctx.CreateLocation("Groundskeeper Home of Mordentshire", "23");
            var OldBooks = ctx.CreateLocation("Old Books", "23");
            var Wharf = ctx.CreateLocation("Wharf of Mordentshire", "22").AddTraits(Traits.Creature.GroaningSpirit.Item1, Traits.Creature.GroaningSpirit.Item2);
            var Farms = ctx.CreateLocation("Farms of Mordentshire", "24");
            var ArdentBay = ctx.CreateLocation("Ardent Bay", "24").AddTraits(Traits.Creature.StrahdZombie);

            var NorthRoad = ctx.CreateLocation("North Road of Mordentshire", "25");
            var NorthMoors = ctx.CreateLocation("North Moors of Mordentshire", "25").AddTraits(Traits.Creature.Harpy);
            var Cliffs = ctx.CreateLocation("Cliffs of Mordentshire", "25").AddTraits(Traits.Creature.Orc, Traits.Creature.Ogre, Traits.Creature.Ghast);
            var DarkWoods = ctx.CreateLocation("Dark Woods of Mordentshire", "25, 26, 31").AddTraits(Traits.Creature.GiantSpider, Traits.Creature.Ogre, Traits.Creature.Vulture);

            var GryphonRoad = ctx.CreateLocation("Gryphon Road", "26");
            var TheBog = ctx.CreateLocation("Bog of Mordentshire", "26").AddTraits(Traits.Creature.CrimsonDeath.Item1, Traits.Creature.CrimsonDeath.Item2);
            var Cemetery = ctx.CreateLocation("Cemetery of Mordentshire", "26").AddTraits(Traits.Creature.StrahdZombie, Traits.Creature.StrahdSkeleton);

            var HiddenTrack = ctx.CreateLocation("Hidden Track of Gryphon Hill", "26").AddTraits(Traits.Creature.Mihstu, Traits.Creature.Werewolf);
            var HeatherHousePoint = ctx.CreateLocation("Heather House Point", "32").AddTraits(Traits.Creature.DisplacerBeast,
                Traits.Creature.ShadowMastiff, Traits.Creature.Wraith, Traits.Creature.Hellhound, Traits.Creature.Skeleton, Traits.Creature.Raven, Traits.Creature.StrahdZombie,
                Traits.Creature.GiantSpider);
            var Heatherwood = ctx.CreateLocation("Heatherwood", "32, 33").AddTraits(Traits.Creature.DisplacerBeast,
                Traits.Creature.ShadowMastiff, Traits.Creature.Wraith, Traits.Creature.Hellhound, Traits.Creature.Skeleton, Traits.Creature.Raven, Traits.Creature.StrahdZombie,
                Traits.Creature.GiantSpider, Traits.Creature.Deer, Traits.Creature.Rabbit, Traits.Creature.Squirrel, Traits.Creature.Skunk);
            var HeatherRoad = ctx.CreateLocation("Heather Road", "33").AddTraits(Traits.Creature.DisplacerBeast,
                Traits.Creature.ShadowMastiff, Traits.Creature.Wraith, Traits.Creature.Hellhound, Traits.Creature.Skeleton, Traits.Creature.Raven, Traits.Creature.StrahdZombie,
                Traits.Creature.GiantSpider);

            Mordentshire.settlement.AddTraits(
                Traits.Creature.CrimsonDeath.Item1, Traits.Creature.CrimsonDeath.Item2, Traits.Creature.Drelb,
                Traits.Creature.InvisibleStalker, Traits.Creature.LurkerAbove, Traits.Creature.ShadowMastiff,
                Traits.Creature.Spectre, Traits.Creature.Wraith, Traits.Creature.Lich, Traits.Creature.GroaningSpirit.Item1,
                Traits.Creature.GroaningSpirit.Item2, Traits.Creature.Human, Traits.Creature.Ghast, Traits.Creature.Cat,
                Traits.Creature.Wight, Traits.Creature.Dog, Traits.Creature.Raven);
            Mordentshire.location.AddTraits(
                Traits.Creature.CrimsonDeath.Item1, Traits.Creature.CrimsonDeath.Item2, Traits.Creature.Drelb,
                Traits.Creature.InvisibleStalker, Traits.Creature.LurkerAbove, Traits.Creature.ShadowMastiff,
                Traits.Creature.Spectre, Traits.Creature.Wraith, Traits.Creature.Lich, Traits.Creature.GroaningSpirit.Item1,
                Traits.Creature.GroaningSpirit.Item2, Traits.Creature.Human, Traits.Creature.Ghast, Traits.Creature.Cat,
                Traits.Creature.Wight, Traits.Creature.Dog, Traits.Creature.Raven);
            #endregion

            #region Characters
            var CountStrahd = ctx.CreateNPC("Count Strahd von Zarovich").AddTraits(Traits.Creature.Human, Traits.Creature.Vampire, Traits.Creature.Banshee, Traits.Creature.StrahdZombie);
            CountStrahd.ExtraInfo = "Referred to here as either 'Alchemist' or 'Creature'";
            var Sergei = ctx.CreateNPC("Sergei von Zarovich", "5").AddTraits(Traits.Creature.Human, Traits.Deceased);
            var Tatyana = ctx.CreateNPC("Tatyana", "5").AddTraits(Traits.Deceased);
            var LadyWeathermay = ctx.CreateNPC("Lady Virginia Weathermay", "3, 6-9, 32, 33").AddTraits(Traits.Creature.Human);
            var LordWeathermay = ctx.CreateNPC("Lord Byron Weathermay", "3, 6, 8-10, 12-14, 17, 32, 33").AddTraits(Traits.Creature.Human);
            var MistressArdent = ctx.CreateNPC("Mistress Ardent", "3, 6, 9, 32").AddTraits(Traits.Creature.Human);
            var Germain = ctx.CreateNPC("Docteur Germain d'Honarie", "3, 6, 7, 10, 13, 20, 24").AddTraits(Traits.Creature.Human);

            var Marion = ctx.CreateNPC("Marion Atwater", "13").AddTraits(Traits.Creature.Human);
            var Dominic = ctx.CreateNPC("Dominic", "13, 20").AddTraits(Traits.Creature.Human);
            var Luker = ctx.CreateNPC("Luker", "13, 14, 24").AddTraits(Traits.Creature.Human);
            var Cavel = ctx.CreateNPC("Cavel Warden", "15").AddTraits(Traits.Creature.Human);
            var Kedar = ctx.CreateNPC("Kedar Klienan", "16, 17").AddTraits(Traits.Creature.Human);
            var Justinian = ctx.CreateNPC("Justinian", "16").AddTraits(Traits.Creature.Human);
            var Honorius = ctx.CreateNPC("Honorius", "16").AddTraits(Traits.Creature.Human);
            var Carlisle = ctx.CreateNPC("Carlisle", "16").AddTraits(Traits.Creature.Human);
            var Brenna = ctx.CreateNPC("Brenna Raven", "16").AddTraits(Traits.Creature.Human);
            var Tabb = ctx.CreateNPC("Tabb Finhallen", "16").AddTraits(Traits.Creature.Human);
            var Kirk = ctx.CreateNPC("Kirk Terrinton", "16").AddTraits(Traits.Creature.Human);
            var Malvin = ctx.CreateNPC("Mayor Malvin Heatherby", "16, 17").AddTraits(Traits.Creature.Human);
            var Tyler = ctx.CreateNPC("Tyler Smythy", "16, 20").AddTraits(Traits.Creature.Human);
            var Gregor = ctx.CreateNPC("Gregor Boyd", "17").AddTraits(Traits.Creature.Human);
            var Azalin = ctx.CreateNPC("Azalin Rex", "17").AddTraits(Traits.Creature.Human);
            var Glenna = ctx.CreateNPC("Glenna Warden", "19").AddTraits(Traits.Creature.Human);
            var Gwydion = ctx.CreateNPC("Gwydion", "19, 20").AddTraits(Traits.Creature.Human);
            var Gaston = ctx.CreateNPC("Gaston Hedgewick", "19").AddTraits(Traits.Creature.Human);
            var Ariana = ctx.CreateNPC("Ariana Bartel", "19").AddTraits(Traits.Creature.Human);
            var Carina = ctx.CreateNPC("Carina Loch", "19").AddTraits(Traits.Creature.Human);
            var Darcy = ctx.CreateNPC("Darcy Pease", "19").AddTraits(Traits.Creature.Human);
            var Bathilda = ctx.CreateNPC("Bathilda Sud", "19, 23").AddTraits(Traits.Creature.Human);
            var Ida = ctx.CreateNPC("Ida Hobson", "19, 22").AddTraits(Traits.Creature.Human);
            var Kyna = ctx.CreateNPC("Kyna Smythy", "20").AddTraits(Traits.Creature.Human);
            var Solita = ctx.CreateNPC("Solita Maravan", "21").AddTraits(Traits.Creature.Human);
            var Ustis = ctx.CreateNPC("Ustis Maravan", "21").AddTraits(Traits.Deceased, Traits.Creature.Human);
            var Sterling = ctx.CreateNPC("Sterling Toddburry", "21").AddTraits(Traits.Creature.Human);
            var Ethan = ctx.CreateNPC("Ethan Toddburry", "21").AddTraits(Traits.Creature.Human);
            var Christina = ctx.CreateNPC("Christina Bartel", "21").AddTraits(Traits.Creature.Human);
            var Erica = ctx.CreateNPC("Erica Toddburry", "22").AddTraits(Traits.Creature.Human);
            var Joshua = ctx.CreateNPC("Father Joshua Talbot", "22, 28").AddTraits(Traits.Creature.Human);
            var Normal = ctx.CreateNPC("Normal Kervil", "22").AddTraits(Traits.Deceased, Traits.Creature.Human);
            var Neola = ctx.CreateNPC("Neola Caraway", "22").AddTraits(Traits.Creature.Human);
            var Silas = ctx.CreateNPC("Silas Archer", "22").AddTraits(Traits.Creature.Human);
            var Violet = ctx.CreateNPC("Violet Archer", "22").AddTraits(Traits.Creature.Human);
            var Penelope = ctx.CreateNPC("Penelope Archer", "22").AddTraits(Traits.Creature.Human);
            var Elwin = ctx.CreateNPC("Elwin Hobson", "22").AddTraits(Traits.Creature.Human);
            var Tilda = ctx.CreateNPC("Tilda Mayberry", "22").AddTraits(Traits.Creature.Human);
            var Freeda = ctx.CreateNPC("Freeda Mayberry", "22").AddTraits(Traits.Creature.Human);
            var Berwin = ctx.CreateNPC("Berwin Hedgewick", "23").AddTraits(Traits.Creature.Human);
            var Lenor = ctx.CreateNPC("Lenor Hedgewick", "23").AddTraits(Traits.Creature.Human);
            var Lobelia = ctx.CreateNPC("Lobelia Tarner", "23").AddTraits(Traits.Creature.Human);
            var Rae = ctx.CreateNPC("Rae Soddenter", "23").AddTraits(Traits.Creature.Human);
            var Parvis = ctx.CreateNPC("Parvis Soddenter", "23").AddTraits(Traits.Creature.Human);
            var Lee = ctx.CreateNPC("Lee Heatherby", "23").AddTraits(Traits.Creature.Human);
            var Margaret = ctx.CreateNPC("Margaret Heatherby", "23").AddTraits(Traits.Creature.Human);
            var Tobais = ctx.CreateNPC("Tobais Kenkiny", "23").AddTraits(Traits.Creature.Human);
            var Desma = ctx.CreateNPC("Desma Kenkiny", "23").AddTraits(Traits.Creature.Human);

            var Wilfred = ctx.CreateNPC("Lord Wilfred Godefroy", "23, 28, 31").AddTraits(Traits.Creature.Human);
            var Estelle = ctx.CreateNPC("Lady Estelle Weathermay Godefroy", "23, 28, 29").AddTraits(Traits.Creature.Human, Traits.Creature.Ghost);
            var Lilia = ctx.CreateNPC("Penelope Godefroy", "Lilia Godefroy", "23, 29").AddTraits(Traits.Creature.Human, Traits.Creature.Haunt);

            var Goodman = ctx.CreateNPC("Goodman Morris", "23").AddTraits(Traits.Creature.Human);
            var Renier = ctx.CreateNPC("Lord Renier", "23").AddTraits(Traits.Creature.Human);
            Renier.ExtraInfo = Goodman.ExtraInfo = "Probably deceased";
            var Vogler = ctx.CreateNPC("Vogler Kervil", "23").AddTraits(Traits.Creature.Human);
            var Cyrus = ctx.CreateNPC("Cyrus Belview", "24").AddTraits(Traits.Creature.Human);

            var Marston = ctx.CreateNPC("Marston", "24").AddTraits(Traits.Creature.Human);
            var Ellie = ctx.CreateNPC("Ellie", "24").AddTraits(Traits.Creature.Human);
            var Axtel = ctx.CreateNPC("Axtel Bartel", "24").AddTraits(Traits.Creature.Human);
            var Barth = ctx.CreateNPC("Barth Kleinen", "24").AddTraits(Traits.Creature.Human);
            var Percival = ctx.CreateNPC("Percival Sud", "24").AddTraits(Traits.Creature.Human);

            var Hargel = ctx.CreateNPC("Hargel Grummsh", "25").AddTraits(Traits.Creature.Orc, Traits.Creature.Ogre, Traits.Creature.Ghast);
            var Eisman = ctx.CreateNPC("Eisman Khargug", "25").AddTraits(Traits.Creature.Orc);
            var Coriemon = ctx.CreateNPC("Coriemon", "26").AddTraits(Traits.Creature.Bodak, Traits.Creature.Ogre, Traits.Creature.Vulture, Traits.Creature.Wight);
            var Gorbagh = ctx.CreateNPC("Gorbagh Snarltooth", "26").AddTraits(Traits.Creature.Ogre);

            var GastonImrad = ctx.CreateNPC("Gaston Imrad", "29").AddTraits(Traits.Creature.Shade);
            var Sheclke = ctx.CreateNPC("Sheclke Duskman", "29").AddTraits(Traits.Creature.Shade);
            var Arlie = ctx.CreateNPC("Arlie Esterbridge", "29").AddTraits(Traits.Creature.Vampire);
            var Carl = ctx.CreateNPC("Carl Ramm", "31").AddTraits(Traits.Creature.Mummy);
            var Tandle = ctx.CreateNPC("Tandle Coreystal", "31").AddTraits(Traits.Creature.Shade);
            var Ellen = ctx.CreateNPC("Ellen Stinworthy", "31").AddTraits(Traits.Creature.Mummy);
            var Karen = ctx.CreateNPC("Karen Edgerton", "31").AddTraits(Traits.Creature.Wight);
            var Sshhisthulhuu = ctx.CreateNPC("Sshhisthulhuu", "31").AddTraits(Traits.Creature.Mihstu);
            #endregion

            #region Items
            var Apparatus = ctx.CreateItem("Apparatus", "3, 4, 6, 8, 10, 14, 19, 26, 30-32");
            var RodOfRastinon = ctx.CreateItem("Rod of Rastinon", "3, 4, 6, 8, 10, 17, 30");
            var SSOrb = ctx.CreateItem("Soul Search Medallion", "Soul Search Orb", "3, 6, 7, 10, 14");
            var RingOfReverse = ctx.CreateItem("Ring of Reversion", "3, 6, 7, 10, 14, 26");
            var AlchemistDiary = ctx.CreateItem("Alchemist's Diary", "7, 10");
            var MissingEntry = ctx.CreateItem("Missing Entry", "3, 6, 10");

            var Sunsword = ctx.CreateItem("Sunsword", "12");
            var Icon = ctx.CreateItem("Icon of Ravenloft", "12");

            var ScrollNegPlaneProt = ctx.CreateItem("Scroll of Negative Plane Protection", "25");
            var LocketOfSealing = ctx.CreateItem("Locket of Sealing", "25");

            var PotOfClimb = ctx.CreateItem("Potion of Climbing", "25");
            var PotOfExtraHeal = ctx.CreateItem("Potion of Extra-Healing", "25");
            var PotOfSpeed = ctx.CreateItem("Potion of Speed", "25");
            var PotOfSuperHero = ctx.CreateItem("Potion of SuperHeroism", "25");

            var ScrollOfHolySymbol = ctx.CreateItem("Potion of Holy Symbol", "25");
            var ScrollOfInvisToUndead = ctx.CreateItem("Potion of Invisiblity to Undead", "25");
            var ScrollOfProtEvil = ctx.CreateItem("Potion of Protection From Evil, 10' Radius", "25");
            var ScrollOfRestore = ctx.CreateItem("Potion of Restoration", "25");

            var PotOfClairAud = ctx.CreateItem("Potion of Clairaudience", "26");
            var PotOfDiminution = ctx.CreateItem("Potion of Diminution", "26");
            var ElixirOfMadness = ctx.CreateItem("Elixir of Madness", "26");
            var MirrorOfLaw = ctx.CreateItem("Mirror Of Lawful Alignment", "26").AddTraits(Traits.Alignment.LG, Traits.Alignment.LN, Traits.Alignment.LE);
            MirrorOfLaw.ExtraInfo = "The mirror doesn't have a name in the module, this is a placeholder title.";

            var TheInnerSoul = ctx.CreateItem("The Inner Soul", "29");
            var IncenseOfMed = ctx.CreateItem("Incense of Meditation", "30");
            #endregion

            #region Groups
            var Moors = ctx.CreateGroup("Moors of Mordentshire", "1, 3, 12, 16, 23-26").AddTraits(Traits.Creature.Human, Traits.Creature.StrahdZombie,
                Traits.Creature.Griffon, Traits.Creature.Harpy, Traits.Creature.Hellhound, Traits.Creature.Orc, Traits.Creature.Ogre,
                Traits.Creature.QuasiElementalLightning, Traits.Creature.Raven, Traits.Creature.GiantSpider, Traits.Creature.Stirge,
                Traits.Creature.Vulture, Traits.Creature.DireWolf, Traits.Creature.Bodak, Traits.Creature.Ghast, Traits.Creature.GroaningSpirit.Item1,
                Traits.Creature.GroaningSpirit.Item2, Traits.Creature.ShadowMastiff, Traits.Creature.Nightmare, Traits.Creature.Skeleton,
                Traits.Creature.SkeletonSteed, Traits.Creature.Wraith, Traits.Creature.WillOWisp, Traits.Creature.CrimsonDeath.Item1,
                Traits.Creature.CrimsonDeath.Item2, Traits.Creature.Doppelganger, Traits.Creature.DisplacerBeast, Traits.Creature.StrahdSkeleton);
            #endregion

            #region Domains Add
            Barovia.AddLocations(CastleRavenloft);
            Barovia.AddNPCs(CountStrahd, Cyrus);
            Barovia.AddItems(Apparatus, RodOfRastinon, Sunsword, Icon);

            Mordent.AddLocations(Mordentshire.location, SaulbridgeSanitarium, GryphonHill, HeatherHouse, WeathermayMausoleum);
            Mordent.AddGroups(Mordentshire.settlement);
            Mordent.AddNPCs(CountStrahd, LordWeathermay, LadyWeathermay, MistressArdent, Germain, Marion, Luker);
            Mordent.AddItems(RodOfRastinon, SSOrb, RingOfReverse, Apparatus, AlchemistDiary);
            #endregion

            #region Locations Add
            Mordentshire.location.AddNPCs(LordWeathermay, LadyWeathermay, MistressArdent, CountStrahd, Germain, Marion, Luker, Dominic, Cavel);
            HeatherHouse.AddNPCs(LordWeathermay, LadyWeathermay, MistressArdent, CountStrahd);
            CastleRavenloft.AddNPCs(CountStrahd, Tatyana, Sergei);
            SaulbridgeSanitarium.AddNPCs(Germain, Marion, Luker, Cyrus, Marston, Ellie, Axtel, Barth);
            HouseOnGryphonHill.AddNPCs(CountStrahd, Renier, Wilfred, Estelle, Lilia, GastonImrad, Sheclke, Arlie, Carl, Tandle, Ellen, Karen, Sshhisthulhuu);
            HouseOnGryphonHill.AddItems(TheInnerSoul, IncenseOfMed);
            ShippingHouse.AddNPCs(Cavel);
            Garrison.AddNPCs(Tyler, Justinian, Kedar, Carlisle, Honorius);
            BlackardInn.AddNPCs(Dominic, Gwydion);
            Livery.AddNPCs(Tyler, Kyna);
            SeventhSea.AddNPCs(Kirk);
            TravelersInn.AddNPCs(Solita, Tabb, Ustis);
            MillBridge.AddNPCs(Christina, Ariana);
            OldMill.AddNPCs(Sterling, Ethan, Erica);
            BurnedChurch.AddNPCs(Joshua);
            Churchyard.AddNPCs(Normal);
            OldSaltHouse.AddNPCs(Neola);
            SaltyDog.AddNPCs(Brenna);
            Butcher.AddNPCs(Silas, Violet, Penelope);
            Smithy.AddNPCs(Elwin, Ida);
            Bakery.AddNPCs(Tilda, Freeda);
            Marketplace.AddNPCs(Berwin, Lenor, Lobelia, Bathilda, Rae, Parvis, Erica);
            MayorsHouse.AddNPCs(Malvin);
            Groundskeeper.AddNPCs(Lee, Margaret);
            OldBooks.AddNPCs(Tobais, Desma);
            KervilsShop.AddNPCs(Vogler);
            Farms.AddNPCs(Lobelia, Percival, Bathilda, Gaston, Lenor, Berwin, Parvis, Rae);

            NorthMoors.AddItems(ScrollNegPlaneProt, LocketOfSealing);
            Cliffs.AddNPCs(Hargel, Eisman);
            Cliffs.AddItems(PotOfClimb, PotOfExtraHeal, PotOfSpeed, PotOfSuperHero, ScrollOfHolySymbol, ScrollOfInvisToUndead, ScrollOfProtEvil, ScrollOfRestore);
            DarkWoods.AddNPCs(Coriemon, Gorbagh);
            DarkWoods.AddItems(PotOfClairAud, PotOfDiminution, ElixirOfMadness, MirrorOfLaw);
            #endregion

            #region Items Add
            #endregion

            #region Groups Add
            Mordentshire.settlement.PopulateSettlement(SaulbridgeSanitarium, GryphonHill, HeatherHouse, WeathermayMausoleum, BlackardInn,
                Livery, Garrison, ShippingHouse, SeventhSea, TravelersInn);
            Moors.AddNPCs(Marston, Hargel, Eisman, Coriemon, Gorbagh);
            Moors.AddItems(ScrollNegPlaneProt, LocketOfSealing, PotOfClimb, PotOfExtraHeal, PotOfSpeed, PotOfSuperHero, ScrollOfHolySymbol,
                ScrollOfInvisToUndead, ScrollOfProtEvil, ScrollOfRestore, PotOfClairAud, PotOfDiminution, ElixirOfMadness, MirrorOfLaw);
            Moors.AddLocations(NorthRoad, NorthMoors, Cliffs, SouthRoad, DarkWoods, HeatherHouse, WeathermayMausoleum, GryphonRoad, TheBog, Cemetery);
            #endregion

            ctx.CreateRelationship(LordWeathermay, "Father", LadyWeathermay);
            ctx.CreateRelationship(LadyWeathermay, "Daughter", LordWeathermay);

            ctx.CreateRelationship(LadyWeathermay, "Engaged", CountStrahd);
            ctx.CreateRelationship(CountStrahd, "Engaged", LadyWeathermay);

            ctx.CreateRelationship(MistressArdent, "Attends to", LadyWeathermay);
            ctx.CreateRelationship(LadyWeathermay, "Employs", MistressArdent);

            ctx.CreateRelationship(Solita, "Widow", Ustis);
            ctx.CreateRelationship(Ustis, "Late Husband", Solita);

            ctx.CreateRelationship(Sterling, "Father", Ethan);
            ctx.CreateRelationship(Ethan, "Son", Sterling);

            ctx.CreateRelationship(Erica, "Wife", Ethan);
            ctx.CreateRelationship(Ethan, "Husband", Erica);

            ctx.CreateRelationship(Christina, "Mother", Ariana);
            ctx.CreateRelationship(Ariana, "Daughter", Christina);

            ctx.CreateRelationship(Silas, "Husband", Violet);
            ctx.CreateRelationship(Silas, "Father", Penelope);
            ctx.CreateRelationship(Violet, "Wife", Silas);
            ctx.CreateRelationship(Violet, "Mother", Penelope);
            ctx.CreateRelationship(Penelope, "Daughter", Silas);
            ctx.CreateRelationship(Penelope, "Daughter", Violet);

            ctx.CreateRelationship(Elwin, "Husband", Ida);
            ctx.CreateRelationship(Ida, "Wife", Elwin);

            ctx.CreateRelationship(Tilda, "Sister", Freeda);
            ctx.CreateRelationship(Freeda, "Sister", Tilda);

            ctx.CreateRelationship(Berwin, "Son", Lenor);
            ctx.CreateRelationship(Lenor, "Mother", Berwin);

            ctx.CreateRelationship(Rae, "Wife", Parvis);
            ctx.CreateRelationship(Parvis, "Husband", Rae);

            ctx.CreateRelationship(Lee, "Husband", Margaret);
            ctx.CreateRelationship(Lee, "Father", Malvin);
            ctx.CreateRelationship(Margaret, "Wife", Lee);
            ctx.CreateRelationship(Margaret, "Mother", Malvin);

            ctx.CreateRelationship(Tobais, "Husband", Desma);
            ctx.CreateRelationship(Desma, "Wife", Tobais);

            ctx.CreateRelationship(Percival, "Husband", Bathilda);
            ctx.CreateRelationship(Bathilda, "Wife", Percival);
        }
    }
}
