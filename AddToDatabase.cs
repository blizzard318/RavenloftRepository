using static Source;

internal static partial class AddToDatabase
{
    public static void Add0 () 
    {
        //Domains, NPCs, Items and Locations are Source-locked, but not Traits.
        //Consider not making new instances within Create, so that adding can be better structured.
        AddI6Ravenloft();
        AddI10TheHouseOnGryphonHill();

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
                    Traits.Creature.StrahdZombie, Traits.Creature.BlackCat, Traits.Creature.Witch,
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

            var Strahd = ctx.CreateNPC("Count Strahd von Zarovich")
                .AddTraits(Traits.Creature.Vampire, Traits.Creature.Human, Traits.Alignment.CE, Traits.Creature.Wolf, Traits.Creature.Bat, Traits.Creature.Worg, Traits.Creature.StrahdZombie, Traits.Creature.Zombie)
                .AddInfo("'ClosedBorders':'No one has left Barovia for centuries. This is because of the trapping fog that exists everywhere in Barovia. Once it is breathed, it infuses itself around a character's vital organs as a neutralized poison. The fog does not taste or smell any different than normal fog. It does not harm characters as long as they continue to breathe the air in Barovia. However, when they leave Barovia, the poison becomes active. Characters must save vs. poison or start to choke. Unless choking characters reenter Barovia within 24 hours, they die. The choking stops as soon as they breathe the fog again. The fog is magically produced by Strahd and disappears entirely upon his destruction.'");

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
            var TomeOfStrahd = ctx.CreateItem("Tome of Strahd", "9, 11, 31");

            var EmbalmTheLostArt = ctx.CreateItem("Embalming, The Lost Art", "21");
            var LifeAmongUndead = ctx.CreateItem("Life Among the Undead: Learning to Cope", "21");
            var IdentifyBloodTypes = ctx.CreateItem("Identifying Blood Types: A Beginners' Handbook", "21");
            var MasonryWoodwork = ctx.CreateItem("Masonry and Woodworking", "21");
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
            CastleRavenloft.AddItems(Sunsword, TomeOfStrahd, IconOfRavenloft, SymbolOfRavenloft,
                EmbalmTheLostArt, LifeAmongUndead, IdentifyBloodTypes, MasonryWoodwork);
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
            var Barovia = ctx.CreateDomain("Barovia", "2, 5, 41");
            var Mordent = ctx.CreateDomain("Mordent");
            #endregion

            #region Locations
            var CastleRavenloft = ctx.CreateLocation("Castle Ravenloft", "5, 12");

            var Mordentshire = ctx.CreateSettlement("Mordentshire");
            var SaulbridgeSanitarium = ctx.CreateLocation("Saulbridge Sanitarium", "6, 13, 23, 24, Cargo Roster");
            var GryphonHill = ctx.CreateLocation("Gryphon Hill", "1, 2, 7, 16, 19, 22, 23, 25, 26, 28, 32, 41, 44-47, Cargo Roster, Event Chart");
            var HouseOnGryphonHill = ctx.CreateLocation("Gryphon Hill Mansion", "1, 2, 7, 16, 19, 22, 23, 26, 28-31, 44, 47, 48").AddTraits(Traits.Creature.Vampire, Traits.Creature.GroaningSpirit.Item1, Traits.Creature.GroaningSpirit.Item2, Traits.Creature.Gargoyle, Traits.Creature.StoneGolem, Traits.Creature.Spirit, Traits.Creature.Ghost, Traits.Creature.Mouse, Traits.Creature.GiantSpider, Traits.Creature.Shade, Traits.Creature.Haunt, Traits.Creature.Drelb, Traits.Creature.Stirge, Traits.Creature.LurkerAbove, Traits.Creature.QuasiElementalLightning, Traits.Creature.GreenSlime);
            var HeatherHouse = ctx.CreateLocation("Weathermay Estate", "Heather House", "1, 3, 10, 13, 15, 16, 19, 24, 26, 32-39, 41, 44, 45, 47, Cargo Roster").AddTraits(Traits.Creature.GiantToad, Traits.Creature.Stirge, Traits.Creature.GreenSlime, Traits.Creature.Vampire, Traits.Creature.InvisibleStalker, Traits.Creature.Haunt, Traits.Creature.Shade, Traits.Creature.GroaningSpirit.Item1, Traits.Creature.GroaningSpirit.Item2, Traits.Creature.Banshee, Traits.Creature.Horse, Traits.Creature.SkeletonSteed.Item1, Traits.Creature.SkeletonSteed.Item2, Traits.Creature.Maggot, Traits.Creature.StrahdZombie, Traits.Creature.StoneGolem, Traits.Creature.Gargoyle, Traits.Creature.Raven, Traits.Creature.Doppelganger, Traits.Creature.StrahdSkeleton, Traits.Creature.ShadowMastiff, Traits.Creature.Trapper);
            var WeathermayMausoleum = ctx.CreateLocation("Weathermay Mausoleum", "1, 15, 32, 38, 39, 45, 48, Event Chart").AddTraits(Traits.Creature.Spectre, Traits.Creature.Wraith);
            var BlackardInn = ctx.CreateLocation("Blackard Inn", "14, 19, 20, Cargo Roster").AddTraits(Traits.Creature.Spider);
            var Livery = ctx.CreateLocation("Livery of Mordentshire", "14");
            var Garrison = ctx.CreateLocation("Garrison of Mordentshire", "14").AddTraits(Traits.Creature.GiantRat);
            var BurnedChurch = ctx.CreateLocation("Church of High Faith", "14, 22, Cargo Roster");
            var Smithy = ctx.CreateLocation("Smithy of Mordentshire", "14, 22, Cargo Roster");
            var MayorsHouse = ctx.CreateLocation("Mayor's House of Mordentshire", "1, 14, 23");
            var KervilsShop = ctx.CreateLocation("Kervil's Shop", "Kervil's General Store", "14, 23");
            var Marketplace = ctx.CreateLocation("Marketplace of Mordentshire", "14");
            var Warehouse = ctx.CreateLocation("Warehouse of Mordentshire", "15, 21");
            var SouthRoad = ctx.CreateLocation("South Road", "15, 25");
            var KeeldevilPoint = ctx.CreateLocation("Keeldevil Point", "17");
            var FishermanAlley = ctx.CreateLocation("Fisherman's Alley", "17, 24, Cargo Roster").AddTraits(Traits.Creature.Doppelganger);
            var ShippingHouse = ctx.CreateLocation("Shipping House", "21");
            var SeventhSea = ctx.CreateLocation("The Seventh Sea", "21, 42");
            var TravelersInn = ctx.CreateLocation("Traveler's Inn", "21, Cargo Roster");
            var AnchorStreet = ctx.CreateLocation("Anchor Street", "21");
            var ShoreLane = ctx.CreateLocation("Shore Lane", "21");
            var MillRoad = ctx.CreateLocation("Mill Road", "21");
            var MillBridge = ctx.CreateLocation("Mill Bridge", "21").AddTraits(Traits.Creature.BlackCat);
            var ArdenRiver = ctx.CreateLocation("Arden River", "21, 25, Map");
            var OldMill = ctx.CreateLocation("Old Mill", "21");
            var Churchyard = ctx.CreateLocation("Churchyard of Mordentshire", "22");
            var OldSaltHouse = ctx.CreateLocation("Old Salt House", "22, Cargo Roster");
            var SaltyDog = ctx.CreateLocation("Salty Dog Tavern", "22");
            var Butcher = ctx.CreateLocation("Butcher of Mordentshire", "22, Cargo Roster");
            var Bakery = ctx.CreateLocation("Bakery of Mordentshire", "22");
            var Groundskeeper = ctx.CreateLocation("Groundskeepers House in Mordentshire", "23");
            var OldBooks = ctx.CreateLocation("Old Books", "23");
            var Wharf = ctx.CreateLocation("Wharf of Mordentshire", "22").AddTraits(Traits.Creature.GroaningSpirit.Item1, Traits.Creature.GroaningSpirit.Item2);
            var Farms = ctx.CreateLocation("Farms of Mordentshire", "24");
            var ArdentBay = ctx.CreateLocation("Ardent Bay", "24").AddTraits(Traits.Creature.StrahdZombie);

            var WindwandAvenue = ctx.CreateLocation("Windwand Avenue", "Map");
            var GlenRoad = ctx.CreateLocation("Glen Road", "Map");
            var MarketStreet = ctx.CreateLocation("Market Street", "Map");
            var BarracksGaol = ctx.CreateLocation("Barracks and Gaol of Mordentshire", "Map");
            var HeatherWay = ctx.CreateLocation("Heather Way", "Map");
            var MaddingRoad = ctx.CreateLocation("Madding Road", "Map");
            var Backwater = ctx.CreateLocation("Backwater", "Map");
            var ButcherLane = ctx.CreateLocation("Butcher Lane", "Map");
            var WoodHollow = ctx.CreateLocation("Wood Hollow", "Map");
            var Cliffedge = ctx.CreateLocation("Cliffedge", "Map");
            var Scrimshaw = ctx.CreateLocation("Scrimshaw", "Map");

            var NorthRoad = ctx.CreateLocation("North Road of Mordentshire", "25");
            var NorthMoors = ctx.CreateLocation("North Moors of Mordentshire", "25, 42").AddTraits(Traits.Creature.Harpy);
            var Cliffs = ctx.CreateLocation("Cliffs of Mordentshire", "25").AddTraits(Traits.Creature.Orc, Traits.Creature.Ogre, Traits.Creature.Ghast);
            var DarkWoods = ctx.CreateLocation("Dark Woods of Mordentshire", "25, 26, 31").AddTraits(Traits.Creature.GiantSpider, Traits.Creature.Ogre, Traits.Creature.Vulture);

            var GryphonRoad = ctx.CreateLocation("Gryphon Road", "26");
            var TheBog = ctx.CreateLocation("Bog of Mordentshire", "26").AddTraits(Traits.Creature.CrimsonDeath.Item1, Traits.Creature.CrimsonDeath.Item2);
            var Cemetery = ctx.CreateLocation("Cemetery of Mordentshire", "26").AddTraits(Traits.Creature.StrahdZombie, Traits.Creature.StrahdSkeleton);

            var HiddenTrack = ctx.CreateLocation("Hidden Track of Gryphon Hill", "26").AddTraits(Traits.Creature.Mihstu, Traits.Creature.Werewolf);
            var HeatherHousePoint = ctx.CreateLocation("Heather House Point", "32").AddTraits(Traits.Creature.DisplacerBeast, Traits.Creature.ShadowMastiff, Traits.Creature.Wraith, Traits.Creature.Hellhound, Traits.Creature.Skeleton, Traits.Creature.Raven, Traits.Creature.StrahdZombie, Traits.Creature.GiantSpider);
            var Heatherwood = ctx.CreateLocation("Heatherwood", "32, 33").AddTraits(Traits.Creature.DisplacerBeast, Traits.Creature.ShadowMastiff, Traits.Creature.Wraith, Traits.Creature.Hellhound, Traits.Creature.Skeleton, Traits.Creature.Raven, Traits.Creature.StrahdZombie, Traits.Creature.GiantSpider, Traits.Creature.Deer, Traits.Creature.Rabbit, Traits.Creature.Squirrel, Traits.Creature.Skunk);
            var HeatherRoad = ctx.CreateLocation("Heather Road", "33");

            Mordentshire.settlement.AddTraits(
                Traits.Creature.CrimsonDeath.Item1, Traits.Creature.CrimsonDeath.Item2, Traits.Creature.Drelb,
                Traits.Creature.InvisibleStalker, Traits.Creature.LurkerAbove, Traits.Creature.ShadowMastiff,
                Traits.Creature.Spectre, Traits.Creature.Wraith, Traits.Creature.Lich, Traits.Creature.GroaningSpirit.Item1,
                Traits.Creature.GroaningSpirit.Item2, Traits.Creature.Human, Traits.Creature.Ghast, Traits.Creature.BlackCat,
                Traits.Creature.Wight, Traits.Creature.Dog, Traits.Creature.Raven);
            Mordentshire.location.AddTraits(
                Traits.Creature.CrimsonDeath.Item1, Traits.Creature.CrimsonDeath.Item2, Traits.Creature.Drelb,
                Traits.Creature.InvisibleStalker, Traits.Creature.LurkerAbove, Traits.Creature.ShadowMastiff,
                Traits.Creature.Spectre, Traits.Creature.Wraith, Traits.Creature.Lich, Traits.Creature.GroaningSpirit.Item1,
                Traits.Creature.GroaningSpirit.Item2, Traits.Creature.Human, Traits.Creature.Ghast, Traits.Creature.BlackCat,
                Traits.Creature.Wight, Traits.Creature.Dog, Traits.Creature.Raven);
            #endregion

            #region Characters
            var CountStrahd = ctx.CreateNPC("Count Strahd von Zarovich").AddTraits(Traits.Creature.Human, Traits.Creature.Vampire, Traits.Creature.Banshee, Traits.Creature.StrahdZombie, Traits.Creature.StrahdSkeleton, Traits.Creature.DireWolf, Traits.Creature.Hellhound, Traits.Creature.ShadowMastiff, Traits.Creature.Raven, Traits.Creature.VampireBat, Traits.Creature.Rat, Traits.Alignment.CE, Traits.Alignment.NG, Traits.Creature.Bat, Traits.Creature.Wolf, Traits.Creature.Quasit.Item1, Traits.Creature.Quasit.Item2, Traits.Creature.Werewolf, Traits.Creature.Harpy, Traits.Creature.Ogre, Traits.Creature.Vulture, Traits.Creature.Nightmare, Traits.Creature.BlackCat, Traits.Creature.StrahdSteed.Item1, Traits.Creature.StrahdSteed.Item2).AddInfo("Referred to here as either 'Alchemist' or 'Creature'");
            var Sergei = ctx.CreateNPC("Sergei von Zarovich", "5").AddTraits(Traits.Creature.Human, Traits.Deceased);
            var Tatyana = ctx.CreateNPC("Tatyana", "5, 47").AddTraits(Traits.Deceased);
            var LadyWeathermay = ctx.CreateNPC("Lady Virginia Anne Weathermay", "3, 6-9, 32, 33, 36, 40, 44, 45, Cargo Roster").AddTraits(Traits.Creature.Human, Traits.Alignment.LG);
            var OldLadyWeathermay = ctx.CreateNPC("Lady Weathermay", "35, 36, 38").AddTraits(Traits.Creature.Human, Traits.Deceased);
            var LordWeathermay = ctx.CreateNPC("Lord Byron Merril Weathermay", "3, 6, 8-10, 12-14, 17, 32-36, 44, 45").AddTraits(Traits.Creature.Human, Traits.Alignment.LG);
            var MistressArdent = ctx.CreateNPC("Mistress Ysilda Gemanine Ardent", "3, 6, 9, 32, 35, 44, Cargo Roster").AddTraits(Traits.Creature.Human, Traits.Alignment.CG);
            var Germain = ctx.CreateNPC("Docteur Germain d'Honaire", "3, 6, 7, 10, 13, 20, 24, Cargo Roster").AddTraits(Traits.Creature.Human);

            var Marion = ctx.CreateNPC("Marion Atwater", "13").AddTraits(Traits.Creature.Human);
            var Dominic = ctx.CreateNPC("Dominic", "13, 20, Cargo Roster, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Luker = ctx.CreateNPC("Luker", "13, 14, 24").AddTraits(Traits.Creature.Human);
            var Cavel = ctx.CreateNPC("Cavel Warden", "15, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Kedar = ctx.CreateNPC("Kedar Klienan", "16, 17, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Justinian = ctx.CreateNPC("Justinian", "16, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Honorius = ctx.CreateNPC("Honorius", "16, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Carlisle = ctx.CreateNPC("Carlisle", "16, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Brenna = ctx.CreateNPC("Brenna Raven", "16, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Tabb = ctx.CreateNPC("Tabb Finhallen", "16, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Kirk = ctx.CreateNPC("Kirk Terrinton", "16, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Malvin = ctx.CreateNPC("Mayor Malvin Heatherby", "16, 17, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Tyler = ctx.CreateNPC("Tyler Smythy", "16, 20, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Gregor = ctx.CreateNPC("Gregor Boyd", "17").AddTraits(Traits.Creature.Human);
            var Azalin = ctx.CreateNPC("Azalin Rex", "17, 38, 39, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human, Traits.Creature.Lich, Traits.Creature.Quasit.Item1, Traits.Creature.Quasit.Item2, Traits.Creature.Horse, Traits.Alignment.NE);
            var Glenna = ctx.CreateNPC("Glenna Warden", "19, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Gwydion = ctx.CreateNPC("Gwydion", "19, 20, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Gaston = ctx.CreateNPC("Gaston Hedgewick", "19, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Ariana = ctx.CreateNPC("Ariana Bartel", "19, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Carina = ctx.CreateNPC("Carina Loch", "19, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Darcy = ctx.CreateNPC("Darcy Pease", "19, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Bathilda = ctx.CreateNPC("Bathilda Sud", "19, 23, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Ida = ctx.CreateNPC("Ida Hobson", "19, 22, Cargo Roster, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Kyna = ctx.CreateNPC("Kyna Smythy", "20, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Solita = ctx.CreateNPC("Solita Maravan", "21, Cargo Roster, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Ustis = ctx.CreateNPC("Ustis Maravan", "21").AddTraits(Traits.Deceased, Traits.Creature.Human);
            var Sterling = ctx.CreateNPC("Sterling Toddburry", "21, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Ethan = ctx.CreateNPC("Ethan Toddburry", "21, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Christina = ctx.CreateNPC("Christina Bartel", "21, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Erica = ctx.CreateNPC("Erica Toddburry", "22, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Joshua = ctx.CreateNPC("Father Joshua Talbot", "22, 28, Cargo Roster, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Normal = ctx.CreateNPC("Normal Kervil", "22").AddTraits(Traits.Deceased, Traits.Creature.Human);
            var Neola = ctx.CreateNPC("Neola Caraway", "22, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Silas = ctx.CreateNPC("Silas Archer", "22, Cargo Roster, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Violet = ctx.CreateNPC("Violet Archer", "22, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Penelope = ctx.CreateNPC("Penelope Archer", "22, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Elwin = ctx.CreateNPC("Elwin Hobson", "22, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Tilda = ctx.CreateNPC("Tilda Mayberry", "22, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Freeda = ctx.CreateNPC("Freeda Mayberry", "22, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Berwin = ctx.CreateNPC("Berwin Hedgewick", "23, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Lenor = ctx.CreateNPC("Lenor Hedgewick", "23, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Lobelia = ctx.CreateNPC("Lobelia Tarner", "23, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Rae = ctx.CreateNPC("Rae Soddenter", "23, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Parvis = ctx.CreateNPC("Parvis Soddenter", "23, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Lee = ctx.CreateNPC("Lee Heatherby", "23, 34, 35, Cargo Roster, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human, Traits.Creature.Horse);
            var Margaret = ctx.CreateNPC("Margaret Heatherby", "23, 34, 35, Cargo Roster, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Tobais = ctx.CreateNPC("Tobais Kenkiny", "23, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Desma = ctx.CreateNPC("Desma Kenkiny", "23, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);

            var Wilfred = ctx.CreateNPC("Lord Wilfred Godefroy", "23, 28, 31, 39, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human, Traits.Creature.Haunt, Traits.Alignment.CN);
            var Estelle = ctx.CreateNPC("Lady Estelle Weathermay Godefroy", "23, 28, 29, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human, Traits.Creature.Ghost);
            var Lilia = ctx.CreateNPC("Penelope Godefroy", "Lilia Godefroy", "23, 29, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human, Traits.Creature.Haunt);

            var Goodman = ctx.CreateNPC("Goodman Morris", "23").AddTraits(Traits.Creature.Human);
            var Renier = ctx.CreateNPC("Lord Renier", "23, 39, 45").AddTraits(Traits.Creature.Human);
            Renier.ExtraInfo = Goodman.ExtraInfo = "Probably deceased";
            var Vogler = ctx.CreateNPC("Vogler Kervil", "23, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Cyrus = ctx.CreateNPC("Cyrus Belview", "24").AddTraits(Traits.Creature.Human);

            var Marston = ctx.CreateNPC("Marston", "24").AddTraits(Traits.Creature.Human);
            var Ellie = ctx.CreateNPC("Ellie", "24").AddTraits(Traits.Creature.Human);
            var Axtel = ctx.CreateNPC("Axtel Bartel", "24, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Barth = ctx.CreateNPC("Barth Kleinen", "24, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Percival = ctx.CreateNPC("Percival Sud", "24, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);

            var Hargel = ctx.CreateNPC("Hargel Grummsh", "25").AddTraits(Traits.Creature.Orc, Traits.Creature.Ogre, Traits.Creature.Ghast);
            var Eisman = ctx.CreateNPC("Eisman Khargug", "25").AddTraits(Traits.Creature.Orc);
            var Coriemon = ctx.CreateNPC("Coriemon Handlet", "26, Transpossession Rosters Handout").AddTraits(Traits.Creature.Bodak, Traits.Creature.Ogre, Traits.Creature.Vulture, Traits.Creature.Wight);
            var Gorbagh = ctx.CreateNPC("Gorbagh Snarltooth", "26").AddTraits(Traits.Creature.Ogre);

            var GastonImrad = ctx.CreateNPC("Gaston Imrad", "29, Transpossession Rosters Handout").AddTraits(Traits.Creature.Shade);
            var Sheclke = ctx.CreateNPC("Sheclke Duskman", "29, Transpossession Rosters Handout").AddTraits(Traits.Creature.Shade);
            var Arlie = ctx.CreateNPC("Arlie Esterbridge", "29").AddTraits(Traits.Creature.Vampire);
            var Carl = ctx.CreateNPC("Carl Ramm", "31, Transpossession Rosters Handout").AddTraits(Traits.Creature.Mummy);
            var Tandle = ctx.CreateNPC("Tandle Coreystal", "31, Transpossession Rosters Handout").AddTraits(Traits.Creature.Shade);
            var Ellen = ctx.CreateNPC("Ellen Stinworthy", "31, Transpossession Rosters Handout").AddTraits(Traits.Creature.Mummy);
            var Karen = ctx.CreateNPC("Karen Edgerton", "31, Transpossession Rosters Handout").AddTraits(Traits.Creature.Wight);
            var Sshhisthulhuu = ctx.CreateNPC("Sshhisthulhuu", "31, Transpossession Rosters Handout").AddTraits(Traits.Creature.Mihstu);

            var Winifred = ctx.CreateNPC("Winifred Kleinen", "35, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Bridget = ctx.CreateNPC("Bridget Dumas", "35, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Baron = ctx.CreateNPC("Baron Fielders", "Baron Fielding", "3, 33, 35, 36, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Baroness = ctx.CreateNPC("Baroness Fielders", "Baroness Fielding", "3, 33, 35, 36, Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Lady = ctx.CreateNPC("Lady Fielders", "Lady Fielding", "3, 33, 35, 36").AddTraits(Traits.Creature.Human);
            var Lucifer = ctx.CreateNPC("Lucifer", "36").AddTraits(Traits.Creature.Raven);
            var Emma = ctx.CreateNPC("Emma Kelley", "37, Transpossession Rosters Handout").AddTraits(Traits.Creature.Vampire);
            var Tintantilus = ctx.CreateNPC("Tintantilus", "42, 45").AddTraits(Traits.Creature.Quasit.Item1, Traits.Creature.Quasit.Item2, Traits.Creature.Bat, Traits.Creature.Wolf);
            var Charity = ctx.CreateNPC("Charity Bliss", "42, Transpossession Rosters Handout").AddTraits(Traits.Creature.Vampire);

            var Thadeus = ctx.CreateNPC("Thadeus the Magnificent", "Thadeus Mont Breezar", "47, Card Handout").AddTraits(Traits.Creature.Human, Traits.Creature.Horse, Traits.Alignment.TN, Traits.Language.Common, Traits.Language.MountainGiant, Traits.Language.Orcish, Traits.Language.RedDragon, Traits.Language.Treantish, Traits.Language.Illithid, Traits.Language.Drow, Traits.Language.KuoToan);

            var Mysti = ctx.CreateNPC("Mysti Tokana", "48, Card Handout").AddTraits(Traits.Creature.HalfElf, Traits.Alignment.CG, Traits.Language.Common, Traits.Language.Elf.Item1, Traits.Language.Elf.Item2, Traits.Language.Gnome.Item1, Traits.Language.Gnome.Item2, Traits.Language.Halfling, Traits.Language.Goblin, Traits.Language.Hobgoblin, Traits.Language.Orcish, Traits.Language.Gnoll);

            var Amar = ctx.CreateNPC("Amar Bori Sandflinger", "48, Card Handout").AddTraits(Traits.Creature.Gnome, Traits.Alignment.TN, Traits.Language.Common, Traits.Language.Dwarvish, Traits.Language.Gnome.Item1, Traits.Language.Gnome.Item2, Traits.Language.Halfling, Traits.Language.Goblin, Traits.Language.BurrowingMammals, Traits.Language.Elf.Item1, Traits.Language.Elf.Item2, Traits.Language.DesertNomad);

            var Rogold = ctx.CreateNPC("Rogold Gildenman", "Card Handout").AddTraits(Traits.Creature.Human, Traits.Creature.Horse, Traits.Alignment.LG, Traits.Language.Common, Traits.Language.Elf.Item1, Traits.Language.Elf.Item2, Traits.Language.Gnome.Item1, Traits.Language.Gnome.Item2, Traits.Language.HillGiant, Traits.Language.Ogre);
            var Barnabas = ctx.CreateNPC("Barnabas", "Card Handout").AddTraits(Traits.Creature.Horse);

            var Phillipe = ctx.CreateNPC("Phillipe Delamana", "Card Handout").AddTraits(Traits.Creature.Human, Traits.Alignment.LG, Traits.Creature.Horse, Traits.Language.Common, Traits.Language.Elf.Item1, Traits.Language.Elf.Item2, Traits.Language.Dwarvish);
            var Rembrania = ctx.CreateNPC("Rembrania", "Card Handout").AddTraits(Traits.Creature.Horse);

            var Brenda = ctx.CreateNPC("Brenda of the Crimson Blade", "Card Handout").AddTraits(Traits.Creature.Human, Traits.Alignment.NG, Traits.Creature.Horse, Traits.Language.Common, Traits.Language.Troll);
            var Sugartooth = ctx.CreateNPC("Sugartooth", "Card Handout").AddTraits(Traits.Creature.Horse);

            var Summer = ctx.CreateNPC("Kregash Garzaala", "Brother Summer", "Card Handout").AddTraits(Traits.Creature.HalfOrc, Traits.Creature.Orc, Traits.Alignment.LN, Traits.Creature.Horse, Traits.Language.Common, Traits.Language.Orcish, Traits.Language.DesertNomad);
            var Muffin = ctx.CreateNPC("Muffin", "Card Handout").AddTraits(Traits.Creature.Horse);

            var TG = ctx.CreateNPC("Terribly Good Redanto", "T.G. Redanto", "Card Handout").AddTraits(Traits.Creature.Human, Traits.Alignment.TN, Traits.Creature.Horse, Traits.Language.Common, Traits.Language.Elf.Item1, Traits.Language.Elf.Item2, Traits.Language.Halfling, Traits.Language.Orcish, Traits.Language.Drow);
            var Apricot = ctx.CreateNPC("Apricot", "Card Handout").AddTraits(Traits.Creature.Horse);

            var Mikhail = ctx.CreateNPC("Mikhail Yelkif", "Cargo Roster");

            var Trellgaard = ctx.CreateNPC("Trellgaard", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Gargoyle);
            var Ilmen = ctx.CreateNPC("Master Ilmen", "Transpossession Rosters Handout").AddTraits(Traits.Creature.StrahdZombie);
            var Caarey = ctx.CreateNPC("Caarey Gelthik", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Ghast);
            var Sean = ctx.CreateNPC("Sean Timothy", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Werewolf);
            var Jerimy = ctx.CreateNPC("Jerimy Estmore", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Wight);
            var Tangle = ctx.CreateNPC("Master Tangle", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Wraith);
            var Wren = ctx.CreateNPC("Wren Thims", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Wraith);
            var Sharon = ctx.CreateNPC("Sharon Teece", "Transpossession Rosters Handout").AddTraits(Traits.Creature.GroaningSpirit.Item1, Traits.Creature.GroaningSpirit.Item2);
            var Molly = ctx.CreateNPC("Molly Grayswit", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Vampire);

            var Stelwaard = ctx.CreateNPC("Stelwaard", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Gargoyle);
            var Thinn = ctx.CreateNPC("Thinn Balder", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Zombie);
            var Badder = ctx.CreateNPC("Badder Ghastling", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Ghast);
            var Esther = ctx.CreateNPC("Esther Timothy", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Werewolf);
            var Geam = ctx.CreateNPC("Geam Pelstap", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Wraith);
            var Maquir = ctx.CreateNPC("Maquir Loft", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Wraith);
            var Miranda = ctx.CreateNPC("Miranda Langstry", "Transpossession Rosters Handout").AddTraits(Traits.Creature.GroaningSpirit.Item1, Traits.Creature.GroaningSpirit.Item2);
            var Kelman = ctx.CreateNPC("Kelman Osterlaker", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Spectre);

            var Fiona = ctx.CreateNPC("Fiona Matheson", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Human);
            var Fanerath = ctx.CreateNPC("Fanerath", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Gargoyle);
            var Hellinken = ctx.CreateNPC("Hellinken", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Doppelganger);
            var Kattle = ctx.CreateNPC("Kattle Lisbury", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Wight);
            var Emory = ctx.CreateNPC("Emory Maus", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Wight);
            var Marcus = ctx.CreateNPC("Marcus Lithe", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Wraith);
            var Nendrum = ctx.CreateNPC("Nendrum Sintel", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Drelb);
            var Thellactin = ctx.CreateNPC("Thellactin Mianns", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Spectre);
            var Kelly = ctx.CreateNPC("Kelly Duncan", "Transpossession Rosters Handout").AddTraits(Traits.Creature.GroaningSpirit.Item1, Traits.Creature.GroaningSpirit.Item2);
            var Cheldon = ctx.CreateNPC("Cheldon Illcome", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Bodak);

            var Mythrel = ctx.CreateNPC("Mythrel", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Gargoyle);
            var Millicent = ctx.CreateNPC("Millicent Hodgson", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Zombie);
            var Natterly = ctx.CreateNPC("Natterly Knutnor", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Ghast);
            var Eowin = ctx.CreateNPC("Eowin Timothy", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Werewolf);
            var Momsin = ctx.CreateNPC("Momsin Alenny", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Wight);
            var Shingol = ctx.CreateNPC("Shingol Tann", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Wraith);
            var Larson = ctx.CreateNPC("Larson Chelf", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Drelb);
            var Yettergun = ctx.CreateNPC("Yettergun Folie", "Transpossession Rosters Handout").AddTraits(Traits.Creature.Spectre);
            var Leslie = ctx.CreateNPC("Leslie Kale", "Transpossession Rosters Handout").AddTraits(Traits.Creature.GroaningSpirit.Item1, Traits.Creature.GroaningSpirit.Item2);
            #endregion

            #region Items
            var Apparatus = ctx.CreateItem("Apparatus", "3, 4, 6, 8, 10, 14, 19, 26, 30-32, 34-41, 43-48, Adventure Plot");
            var RodOfRastinon = ctx.CreateItem("Rod of Rastinon", "3, 4, 6, 8, 10, 17, 30, 40, 46, Adventure Plot");
            var SSOrb = ctx.CreateItem("Soul Search Medallion", "Soul Search Orb", "3, 6, 7, 10, 14, 46, Adventure Plot");
            var RingOfReverse = ctx.CreateItem("Ring of Reversion", "3, 6, 7, 10, 14, 26, 46, Adventure Plot").AddTraits(Traits.Alignment.NG);
            var AlchemistDiary = ctx.CreateItem("Alchemist's Diary", "7, 10, 41, 47, Adventure Plot");
            var MissingEntry = ctx.CreateItem("Missing Entry", "3, 6, 10, 41, 47, Adventure Plot");

            var Sunsword = ctx.CreateItem("Sunsword", "12, 41");
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
            var MirrorOfLaw = ctx.CreateItem("Mirror Of Lawful Alignment", "26").AddTraits(Traits.Alignment.LG, Traits.Alignment.LN, Traits.Alignment.LE).AddInfo("The mirror doesn't have a name in the module, this is a placeholder title.");

            var TheInnerSoul = ctx.CreateItem("The Inner Soul", "29");
            var IncenseOfMed = ctx.CreateItem("Incense of Meditation", "30, Card Handout");
            var THENATUREOFTHESOUL = ctx.CreateItem("THE NATURE OF THE SOUL: Portion or Totality of the Man", "34");

            var SunBlade = ctx.CreateItem("Sun Blade", "39");

            var SwordOfWound = ctx.CreateItem("Sword of Wounding", "42");
            var RingOfDetGood = ctx.CreateItem("Ring of Detect Good", "42");
            var RopeOfEntangle = ctx.CreateItem("Rope of Entangling", "42");
            var MedallionOfProt = ctx.CreateItem("Medallion of Protection: Good", "42");

            var FlashGrenade = ctx.CreateItem("Flash Grenade", "44");
            var CloakOfProt = ctx.CreateItem("Cloak of Protection", "44");
            var RingOfRegen = ctx.CreateItem("Ring of Regeneration", "44");
            var GemOfLight = ctx.CreateItem("Gem of Light", "44");
            var ScrollOfStoring = ctx.CreateItem("Scroll of Storing", "44");

            var ScrollOfProt = ctx.CreateItem("Scroll of Protection from Undead", "44");
            var BroochOfProt = ctx.CreateItem("Brooch of Protection: Good", "44");
            var RingOfProtNM = ctx.CreateItem("Ring of Protection from Normal Missiles", "44");

            var RingOfAim = ctx.CreateItem("Ring of Aiming", "45");
            var PotOfHeal = ctx.CreateItem("Potion of Healing", "45, Card Handout");
            var CloakOfDisplace = ctx.CreateItem("Cloak of Displacement", "45, Card Handout");

            var RingOfProt = ctx.CreateItem("Ring of Protection", "45, Card Handout");
            var ElixirOfHealth  = ctx.CreateItem("Elixir of Health", "45");
            var ScrollOfCall  = ctx.CreateItem("Scroll of Calling", "45");
            var BracersOfDef = ctx.CreateItem("Bracers of Defense", "45, Card Handout");

            var DartOfHoming = ctx.CreateItem("Dart of Homing", "45");
            var DaggerOfVenom = ctx.CreateItem("Dagger of Venom", "45");
            var StaffOfThunder = ctx.CreateItem("Staff of Thunder", "45");
            var PowderOfHaste = ctx.CreateItem("Powder of Haste", "45");
            var ElixirOfDisplace = ctx.CreateItem("Elixir of Displacement", "45");
            var PotOfCWNW = ctx.CreateItem("Potion of Cure Serious Negative Wounds", "45");

            var RodOfFlail = ctx.CreateItem("Rod of Flailing", "Card Handout");
            var ScrollOfProtWS = ctx.CreateItem("Scroll of Protection from Wraiths and Spectres", "Card Handout").AddTraits(Traits.Creature.Wraith, Traits.Creature.Spectre);

            var StaffOfStrike = ctx.CreateItem("Staff of Striking", "Card Handout");
            var AlchemyJug = ctx.CreateItem("Alchemy Jug", "Card Handout");
            var StoneOfControlEarth = ctx.CreateItem("Stone of Controlling Earth Elementals", "Card Handout");
            var ScrollOfProtDev = ctx.CreateItem("Scroll of Protection from Devils", "Card Handout");
            var ScrollOfProtDem = ctx.CreateItem("Scroll of Protection from Demons", "Card Handout");
            var ScrollOfProtPet = ctx.CreateItem("Scroll of Protection from Petrification", "Card Handout");
            var RingOfWaterWalk = ctx.CreateItem("Rng of Water Walking", "Card Handout");

            var DragonSlayer = ctx.CreateItem("Dragon Slayer", "Card Handout");
            var HornOfValhalla = ctx.CreateItem("Bronze Horn of Valhalla", "Card Handout");

            var ArrowOfDirect = ctx.CreateItem("Arrow of Direction", "Card Handout");
            var TrollCleaver = ctx.CreateItem("Troll-Cleaver", "Card Handout");

            var PhylacteryOfFaith = ctx.CreateItem("Phylactery of Faithfulness", "Card Handout");

            var SwordOfLifeSteal = ctx.CreateItem("Sword of Life Stealing", "Card Handout");
            var RopeOfClimb = ctx.CreateItem("Rope of Climbing", "Card Handout");

            var ScarabOfProt = ctx.CreateItem("Scarab of Protection", "Card Handout");
            #endregion

            #region Groups
            var Moors = ctx.CreateGroup("Moors of Mordentshire", "1, 3, 12, 16, 23-26, 43").AddTraits(Traits.Creature.Human, Traits.Creature.StrahdZombie, Traits.Creature.Griffon, Traits.Creature.Harpy, Traits.Creature.Hellhound, Traits.Creature.Orc, Traits.Creature.Ogre, Traits.Creature.QuasiElementalLightning, Traits.Creature.Raven, Traits.Creature.GiantSpider, Traits.Creature.Stirge, Traits.Creature.Vulture, Traits.Creature.DireWolf, Traits.Creature.Bodak, Traits.Creature.Ghast, Traits.Creature.GroaningSpirit.Item1, Traits.Creature.GroaningSpirit.Item2, Traits.Creature.ShadowMastiff, Traits.Creature.Nightmare, Traits.Creature.Skeleton, Traits.Creature.SkeletonSteed.Item1, Traits.Creature.SkeletonSteed.Item2, Traits.Creature.Wraith, Traits.Creature.WillOWisp, Traits.Creature.CrimsonDeath.Item1, Traits.Creature.CrimsonDeath.Item2, Traits.Creature.Doppelganger, Traits.Creature.DisplacerBeast, Traits.Creature.StrahdSkeleton);
            var HighFaith = ctx.CreateGroup("Church of the High Faith in Osterton", "10, Card Handout");
            #endregion

            #region Domains Add
            Barovia.AddLocations(CastleRavenloft);
            Barovia.AddNPCs(CountStrahd, Cyrus);
            Barovia.AddItems(Apparatus, RodOfRastinon, Sunsword, Icon);

            Mordent.AddLocations(Mordentshire.location, SaulbridgeSanitarium, GryphonHill, HeatherHouse, WeathermayMausoleum, HouseOnGryphonHill, BlackardInn, Livery, Garrison, BurnedChurch, Smithy, MayorsHouse, KervilsShop, Marketplace, Warehouse, SouthRoad, KeeldevilPoint, FishermanAlley, ShippingHouse, SeventhSea, TravelersInn, AnchorStreet, ShoreLane, MillRoad, MillBridge, ArdenRiver, OldMill, Churchyard, OldSaltHouse, SaltyDog, Butcher, Bakery, Groundskeeper, OldBooks, Wharf, Farms, ArdentBay, WindwandAvenue, GlenRoad, MarketStreet, BarracksGaol, HeatherWay, MaddingRoad, Backwater, NorthRoad, NorthMoors, Cliffs, DarkWoods, HiddenTrack, HeatherHousePoint, Heatherwood, HeatherRoad, ButcherLane, WoodHollow, Cliffedge, Scrimshaw);
            Mordent.AddGroups(Mordentshire.settlement, Moors, HighFaith);
            Mordent.AddNPCs(CountStrahd, LadyWeathermay, OldLadyWeathermay, LordWeathermay, MistressArdent, Germain, Marion, Dominic, Luker, Cavel, Kedar, Justinian, Honorius, Carlisle, Brenna, Tabb, Kirk, Malvin, Tyler, Gregor, Azalin, Glenna, Gwydion, Gaston, Ariana, Carina, Darcy, Bathilda, Ida, Kyna, Solita, Ustis, Sterling, Ethan, Christina, Erica, Joshua, Normal, Neola, Silas, Violet, Penelope, Elwin, Tilda, Freeda, Berwin, Lenor, Lobelia, Rae, Parvis, Lee, Margaret, Tobais, Desma, Wilfred, Estelle, Lilia, Goodman, Renier, Vogler, Marston, Ellie, Axtel, Barth, Percival, Hargel, Eisman, Coriemon, Gorbagh, GastonImrad, Sheclke, Arlie, Carl, Tandle, Ellen, Karen, Sshhisthulhuu, Winifred, Bridget, Baron, Baroness, Lady, Lucifer, Emma, Tintantilus, Charity, Thadeus, Mysti, Amar, Rogold, Barnabas, Phillipe, Rembrania, Brenda, Sugartooth, Summer, Muffin, TG, Apricot, Mikhail, Trellgaard, Ilmen, Caarey, Sean, Jerimy, Tangle, Wren, Sharon, Molly, Stelwaard, Thinn, Badder, Esther, Geam, Maquir, Miranda, Kelman, Fiona, Fanerath, Hellinken, Kattle, Emory, Marcus, Nendrum, Thellactin, Kelly, Cheldon, Mythrel, Millicent, Natterly, Eowin, Momsin, Shingol, Larson, Yettergun, Leslie);
            Mordent.AddItems(Apparatus, RodOfRastinon, SSOrb, RingOfReverse, AlchemistDiary, MissingEntry, Sunsword, ScrollNegPlaneProt, LocketOfSealing, PotOfClimb, PotOfExtraHeal, PotOfSpeed, PotOfSuperHero, ScrollOfHolySymbol, ScrollOfInvisToUndead, ScrollOfProtEvil, ScrollOfRestore, PotOfClairAud, PotOfDiminution, ElixirOfMadness, MirrorOfLaw, TheInnerSoul, IncenseOfMed, THENATUREOFTHESOUL, SunBlade, SwordOfWound, RingOfDetGood, RopeOfEntangle, MedallionOfProt, FlashGrenade, CloakOfProt, RingOfRegen, GemOfLight, ScrollOfStoring, ScrollOfProt, BroochOfProt, RingOfProtNM, RingOfAim, PotOfHeal, CloakOfDisplace, RingOfProt, ElixirOfHealth, ScrollOfCall, BracersOfDef, DartOfHoming, DaggerOfVenom, StaffOfThunder, PowderOfHaste, ElixirOfDisplace, PotOfCWNW, RodOfFlail, ScrollOfProtWS, StaffOfStrike, AlchemyJug, StoneOfControlEarth, ScrollOfProtDev, ScrollOfProtDem, ScrollOfProtPet, RingOfWaterWalk, DragonSlayer, HornOfValhalla, ArrowOfDirect, TrollCleaver, PhylacteryOfFaith, SwordOfLifeSteal, RopeOfClimb, ScarabOfProt);

            ctx.OutsideRavenloft.AddGroups(HighFaith);
            #endregion

            #region Locations Add
            Mordentshire.location.AddNPCs(CountStrahd, LadyWeathermay, OldLadyWeathermay, LordWeathermay, MistressArdent, Germain, Marion, Dominic, Luker, Cavel, Kedar, Justinian, Honorius, Carlisle, Brenna, Tabb, Kirk, Malvin, Tyler, Gregor, Azalin, Glenna, Gwydion, Gaston, Ariana, Carina, Darcy, Bathilda, Ida, Kyna, Solita, Ustis, Sterling, Ethan, Christina, Erica, Joshua, Normal, Neola, Silas, Violet, Penelope, Elwin, Tilda, Freeda, Berwin, Lenor, Lobelia, Rae, Parvis, Lee, Margaret, Tobais, Desma, Wilfred, Estelle, Lilia, Goodman, Renier, Vogler, Marston, Ellie, Axtel, Barth, Percival, Hargel, Eisman, Coriemon, Gorbagh, GastonImrad, Sheclke, Arlie, Carl, Tandle, Ellen, Karen, Sshhisthulhuu, Winifred, Bridget, Baron, Baroness, Lady, Lucifer, Emma, Tintantilus, Charity, Thadeus, Mysti, Amar, Rogold, Barnabas, Phillipe, Rembrania, Brenda, Sugartooth, Summer, Muffin, TG, Apricot, Mikhail, Trellgaard, Ilmen, Caarey, Sean, Jerimy, Tangle, Wren, Sharon, Molly, Stelwaard, Thinn, Badder, Esther, Geam, Maquir, Miranda, Kelman, Fiona, Fanerath, Hellinken, Kattle, Emory, Marcus, Nendrum, Thellactin, Kelly, Cheldon, Mythrel, Millicent, Natterly, Eowin, Momsin, Shingol, Larson, Yettergun, Leslie);
            Mordentshire.location.AddItems(Apparatus, RodOfRastinon, SSOrb, RingOfReverse, AlchemistDiary, MissingEntry, Sunsword, ScrollNegPlaneProt, LocketOfSealing, PotOfClimb, PotOfExtraHeal, PotOfSpeed, PotOfSuperHero, ScrollOfHolySymbol, ScrollOfInvisToUndead, ScrollOfProtEvil, ScrollOfRestore, PotOfClairAud, PotOfDiminution, ElixirOfMadness, MirrorOfLaw, TheInnerSoul, IncenseOfMed, THENATUREOFTHESOUL, SunBlade, SwordOfWound, RingOfDetGood, RopeOfEntangle, MedallionOfProt, FlashGrenade, CloakOfProt, RingOfRegen, GemOfLight, ScrollOfStoring, ScrollOfProt, BroochOfProt, RingOfProtNM, RingOfAim, PotOfHeal, CloakOfDisplace, RingOfProt, ElixirOfHealth, ScrollOfCall, BracersOfDef, DartOfHoming, DaggerOfVenom, StaffOfThunder, PowderOfHaste, ElixirOfDisplace, PotOfCWNW, RodOfFlail, ScrollOfProtWS, StaffOfStrike, AlchemyJug, StoneOfControlEarth, ScrollOfProtDev, ScrollOfProtDem, ScrollOfProtPet, RingOfWaterWalk, DragonSlayer, HornOfValhalla, ArrowOfDirect, TrollCleaver, PhylacteryOfFaith, SwordOfLifeSteal, RopeOfClimb, ScarabOfProt);

            HeatherHouse.AddNPCs(LordWeathermay, LadyWeathermay, OldLadyWeathermay, Renier, MistressArdent, CountStrahd, Lee, Margaret, Winifred, Bridget, Emma);
            HeatherHouse.AddItems(THENATUREOFTHESOUL, Apparatus, RodOfRastinon, SSOrb, RingOfReverse, MissingEntry);
            CastleRavenloft.AddNPCs(CountStrahd, Tatyana, Sergei);
            SaulbridgeSanitarium.AddNPCs(Germain, Marion, Luker, Cyrus, Marston, Ellie, Axtel, Barth);
            HouseOnGryphonHill.AddNPCs(CountStrahd, Renier, Wilfred, Estelle, Lilia, GastonImrad, Sheclke, Arlie, Carl, Tandle, Ellen, Karen, Sshhisthulhuu);
            HouseOnGryphonHill.AddItems(TheInnerSoul, IncenseOfMed, Apparatus);
            ShippingHouse.AddNPCs(Cavel);
            Garrison.AddNPCs(Tyler, Justinian, Kedar, Carlisle, Honorius);
            BlackardInn.AddNPCs(Dominic, Gwydion);
            Livery.AddNPCs(Tyler, Kyna);
            SeventhSea.AddNPCs(Kirk, Charity);
            TravelersInn.AddNPCs(Solita, Tabb, Ustis);
            MillBridge.AddNPCs(Christina, Ariana);
            OldMill.AddNPCs(Sterling, Ethan, Erica);
            BurnedChurch.AddNPCs(Joshua);
            BurnedChurch.AddItems(RodOfRastinon, SSOrb, RingOfReverse, MissingEntry);
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

            WeathermayMausoleum.AddNPCs(Azalin, Wilfred, Tintantilus, Renier);
            WeathermayMausoleum.AddItems(SunBlade);
            GryphonHill.AddItems(Sunsword);
            CastleRavenloft.AddItems(MissingEntry);

            FishermanAlley.AddNPCs(Mikhail);
            #endregion

            #region Items Add
            SunBlade.AddNPCs(Renier);
            Apparatus.AddLocations(HeatherHouse, WeathermayMausoleum);
            CountStrahd.AddItems(SwordOfWound, RingOfDetGood, RopeOfEntangle, MedallionOfProt,
                FlashGrenade, CloakOfProt, RingOfRegen, GemOfLight, ScrollOfStoring);
            MistressArdent.AddItems(ScrollOfProt, BroochOfProt, RingOfProtNM);
            LordWeathermay.AddItems(RingOfAim, PotOfHeal, CloakOfDisplace);
            LadyWeathermay.AddItems(RingOfProt, ElixirOfHealth, ScrollOfCall, BracersOfDef);
            Azalin.AddItems(DartOfHoming, DaggerOfVenom, StaffOfThunder, PowderOfHaste, ElixirOfDisplace, PotOfCWNW);
            Rogold.AddItems(RodOfFlail, ScrollOfProtWS);
            Thadeus.AddItems(RingOfProt, CloakOfDisplace, StaffOfStrike, AlchemyJug, StoneOfControlEarth, ScrollOfProtDev, ScrollOfProtDem, ScrollOfProtPet, RingOfWaterWalk);
            Phillipe.AddItems(DragonSlayer, HornOfValhalla);
            Brenda.AddItems(ArrowOfDirect, PotOfHeal, TrollCleaver);
            Summer.AddItems(IncenseOfMed, PhylacteryOfFaith);
            TG.AddItems(SwordOfLifeSteal, RopeOfClimb, BracersOfDef);
            Mysti.AddItems(ScarabOfProt);
            #endregion

            #region Groups Add
            Mordentshire.settlement.PopulateSettlement(SaulbridgeSanitarium, GryphonHill, HeatherHouse, WeathermayMausoleum, HouseOnGryphonHill, BlackardInn, Livery, Garrison, BurnedChurch, Smithy, MayorsHouse, KervilsShop, Marketplace, Warehouse, SouthRoad, KeeldevilPoint, FishermanAlley, ShippingHouse, SeventhSea, TravelersInn, AnchorStreet, ShoreLane, MillRoad, MillBridge, ArdenRiver, OldMill, Churchyard, OldSaltHouse, SaltyDog, Butcher, Bakery, Groundskeeper, OldBooks, Wharf, Farms, ArdentBay, WindwandAvenue, GlenRoad, MarketStreet, BarracksGaol, HeatherWay, MaddingRoad, Backwater, NorthRoad, NorthMoors, Cliffs, DarkWoods, HiddenTrack, HeatherHousePoint, Heatherwood, HeatherRoad, ButcherLane, WoodHollow, Cliffedge, Scrimshaw);
            Moors.AddNPCs(Marston);
            Moors.PopulateSettlement(NorthRoad, NorthMoors, Cliffs, SouthRoad, DarkWoods, HeatherHouse, WeathermayMausoleum, GryphonRoad, TheBog, Cemetery);
            HighFaith.AddNPCs(Thadeus, Rogold, Amar, Phillipe, Summer, Brenda, Mysti, TG);
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

            ctx.CreateRelationship(Ethan, "Husband", Erica);
            ctx.CreateRelationship(Erica, "Wife", Ethan);

            ctx.CreateRelationship(Cavel, "Husband", Glenna);
            ctx.CreateRelationship(Glenna, "Wife", Cavel);

            ctx.CreateRelationship(Axtel, "Husband", Christina);
            ctx.CreateRelationship(Christina, "Wife", Axtel);
            ctx.CreateRelationship(Axtel, "Father", Ariana);
            ctx.CreateRelationship(Ariana, "Daughter", Axtel);
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

            ctx.CreateRelationship(Gaston, "Husband", Lenor);
            ctx.CreateRelationship(Lenor, "Wife", Gaston);
            ctx.CreateRelationship(Lenor, "Mother", Berwin);
            ctx.CreateRelationship(Berwin, "Son", Lenor);
            ctx.CreateRelationship(Gaston, "Father", Berwin);
            ctx.CreateRelationship(Berwin, "Son", Gaston);

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

            ctx.CreateRelationship(Azalin, "Master", Tintantilus);
            ctx.CreateRelationship(Tintantilus, "Familiar", Azalin);

            ctx.CreateRelationship(Rogold, "Mounts", Barnabas);
            ctx.CreateRelationship(Barnabas, "Owned By", Rogold);

            ctx.CreateRelationship(Phillipe, "Mounts", Rembrania);
            ctx.CreateRelationship(Rembrania, "Owned By", Phillipe);

            ctx.CreateRelationship(Brenda, "Mounts", Sugartooth);
            ctx.CreateRelationship(Sugartooth, "Owned By", Brenda);

            ctx.CreateRelationship(Summer, "Mounts", Muffin);
            ctx.CreateRelationship(Muffin, "Owned By", Summer);

            ctx.CreateRelationship(TG, "Mounts", Apricot);
            ctx.CreateRelationship(Apricot, "Owned By", TG);

            ctx.CreateRelationship(Thadeus, "Teacher", Mysti);
            ctx.CreateRelationship(Mysti, "Student/Scribe", Thadeus);
        }
    }
}