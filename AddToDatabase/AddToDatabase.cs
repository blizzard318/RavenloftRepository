using static Factory;

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
            using var ctx = CreateSource("I6: Ravenloft", releaseDate, ExtraInfo, Edition.e1, Media.module);
            if (ctx == null) return;

            DomainEnum.Barovia.Appeared().BindCreatures(Creature.Ghoul);

            #region Locations
            DomainEnum.Barovia.AddSettlement(Settlement.Barovia, "1, 6, 7")
                .BindGroups(GroupEnum.Burgomaster, GroupEnum.BurgomasterOfBarovia)
                .BindCharacters(CharacterEnum.Arik, CharacterEnum.FatherDonavich, CharacterEnum.KolyanIndirovich, CharacterEnum.Ismark,
                                CharacterEnum.IreenaKolyana, CharacterEnum.SashaIvliskova, CharacterEnum.MadMary, CharacterEnum.Gertruda,
                                CharacterEnum.Bildrath, CharacterEnum.Parriwimple);
            DomainEnum.Barovia.AddLocation(LocationEnum.OldSvalichRoad, "7");
            DomainEnum.Barovia.AddLocation(LocationEnum.GatesOfBarovia, "7").BindCreatures(Creature.GreenSlime);
            DomainEnum.Barovia.AddLocation(LocationEnum.SvalichWoods, "1, 6-8").BindCreatures(Creature.Worg);
            DomainEnum.Barovia.AddLocation(LocationEnum.RiverIvlis, "8");
            DomainEnum.Barovia.AddLocation(LocationEnum.BildrathMercantile, "8")
                .BindCharacters(CharacterEnum.Bildrath, CharacterEnum.Parriwimple);
            DomainEnum.Barovia.AddLocation(LocationEnum.BloodVineTavern, "8, 9")
                .BindCharacters(CharacterEnum.Arik, CharacterEnum.Ismark);
            DomainEnum.Barovia.AddLocation(LocationEnum.MaryHouse, "9")
                .BindCharacters(CharacterEnum.MadMary, CharacterEnum.Gertruda);
            DomainEnum.Barovia.AddLocation(LocationEnum.BurgomasterHome, "1, 9")
                .BindGroups(GroupEnum.Burgomaster, GroupEnum.BurgomasterOfBarovia)
                .BindCharacters(CharacterEnum.KolyanIndirovich, CharacterEnum.Ismark, CharacterEnum.IreenaKolyana);
            DomainEnum.Barovia.AddLocation(LocationEnum.BaroviaChurch, "9, 10")
                .BindCharacters(CharacterEnum.FatherDonavich);
            DomainEnum.Barovia.AddLocation(LocationEnum.BurgomasterGuestHouse, "9")
                .BindGroups(GroupEnum.Burgomaster, GroupEnum.BurgomasterOfBarovia)
                .BindCharacters(CharacterEnum.KolyanIndirovich);
            DomainEnum.Barovia.AddLocation(LocationEnum.BaroviaCemetery, "9, 11").BindCreatures(Creature.Spirit);

            DomainEnum.Barovia.AddSettlement(Settlement.TserPoolEncampnent, "11");
            DomainEnum.Barovia.AddLocation(LocationEnum.MadamEvasTent, "11");
            DomainEnum.Barovia.AddLocation(LocationEnum.RoadJunction, "11");
            DomainEnum.Barovia.AddLocation(LocationEnum.TserFalls, "11");
            DomainEnum.Barovia.AddLocation(LocationEnum.GatesOfRavenloft, "11, 12");

            DomainEnum.Barovia.AddLocation(LocationEnum.CastleRavenloft, "1, 6, 8, 9, 12-30")
                .BindCreatures(Creature.RedDragon, Creature.ShadowDemon, Creature.Trapper, Creature.GiantSpider,
                                                            Creature.HugeSpider, Creature.Skeleton, Creature.Horse, Creature.Nightmare,
                                                            Creature.Banshee, Creature.Gargoyle, Creature.RustMonster, Creature.GuardianPortrait,
                                                            Creature.Spectre, Creature.Spirit, Creature.Wight, Creature.Wraith, Creature.Ghost,
                                                            Creature.Bat, Creature.StrahdZombie, Creature.BlackCat, Creature.Witch, Creature.Hellhound,
                                                            Creature.Werewolf, Creature.IronGolem)
                .BindCharacters(CharacterEnum.GuardianOfSorrow, CharacterEnum.LiefLipsiege, CharacterEnum.Helga, CharacterEnum.CyrusBelview,
                                CharacterEnum.CountStrahd, CharacterEnum.SpectreAbCenteer, CharacterEnum.ArtistaDeSlop, CharacterEnum.LadyIsoldeYunk,
                                CharacterEnum.AerialDuPlumette, CharacterEnum.ArtankSwilovich, CharacterEnum.DorfniyaDilisny, CharacterEnum.Pidlwik,
                                CharacterEnum.LeanneTriksky, CharacterEnum.TashaPetrovna, CharacterEnum.KingToisky, CharacterEnum.KingIntreeKatsky,
                                CharacterEnum.StahbalIndiBhak, CharacterEnum.Khazan, CharacterEnum.ElsaFallona, CharacterEnum.SedrikSpinwitovich,
                                CharacterEnum.Animus, CharacterEnum.ErikVonderbucks, CharacterEnum.IvanDeRose, CharacterEnum.StephanGregorovich,
                                CharacterEnum.IntreeSikValoo, CharacterEnum.ArdentPallette, CharacterEnum.IvanIvanovich, CharacterEnum.CirilRomulich,
                                CharacterEnum.Dollars, CharacterEnum.Finderway, CharacterEnum.Dostron, CharacterEnum.GralmoreNimblenobs,
                                CharacterEnum.AmericoStandardski, CharacterEnum.Beucephalus, CharacterEnum.TatsaulEris, CharacterEnum.Sergei,
                                CharacterEnum.KingBarov, CharacterEnum.Ravenovia, CharacterEnum.MaryaMarkovia, CharacterEnum.Endorovich,
                                CharacterEnum.SashaIvliskova, CharacterEnum.PatrinaVelikovna, CharacterEnum.Gertruda)
                .BindItems(ItemEnum.Sunsword, ItemEnum.TomeOfStrahd, ItemEnum.IconOfRaven, ItemEnum.SymbolOfRaven, ItemEnum.EmbalmTheLostArt,
                           ItemEnum.LifeAmongUndead, ItemEnum.IdentifyBloodTypes, ItemEnum.MasonryWoodwork)
                .BindGroups(GroupEnum.BridesOfStrahd, GroupEnum.HighPriestRavenloft, GroupEnum.HighPriestMostHoly);
            #endregion

            #region NPCs
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.MadamEva,"1, 6, 11, 32")
                .BindLocations(Settlement.TserPoolEncampnent, LocationEnum.MadamEvasTent)
                .BindGroups(GroupEnum.Vistani)
                .BindCreatures(Creature.Human)
                .BindAlignment(Alignment.CN);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.GuardianOfSorrow, "16")
                .BindAlignment(Alignment.NE);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.LiefLipsiege, "17")
                .BindCreatures(Creature.Human)
                .BindCharacters(CharacterEnum.CountStrahd)
                .BindAlignment(Alignment.CE);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Helga, "18")
                .BindCreatures(Creature.Human, Creature.Vampire)
                .BindCharacters(CharacterEnum.CountStrahd)
                .BindAlignment(Alignment.CE);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.CyrusBelview, "23")
                .BindCreatures(Creature.Human)
                .BindCharacters(CharacterEnum.CountStrahd)
                .BindAlignment(Alignment.CN);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.SpectreAbCenteer, "27");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.ArtistaDeSlop, "27");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.LadyIsoldeYunk, "27");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.LadyIsoldeYunk, "27");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.AerialDuPlumette, "27").BindCreatures(Creature.Ghost).BindAlignment(Alignment.LE);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.ArtankSwilovich, "27");

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.DorfniyaDilisny, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Pidlwik, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.LeanneTriksky, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.TashaPetrovna, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.KingToisky, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.KingIntreeKatsky, "28");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.StahbalIndiBhak, "28").BindCreatures(Creature.Wight).BindAlignment(Alignment.LE);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Khazan, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.ElsaFallona, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.SedrikSpinwitovich, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Animus, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.ErikVonderbucks, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.IvanDeRose, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.StephanGregorovich, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.IntreeSikValoo, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.ArdentPallette, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.IvanIvanovich, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.CirilRomulich, "28");

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Dollars, "29");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Finderway, "29");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Dostron, "29");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.GralmoreNimblenobs, "29");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.AmericoStandardski, "29");

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Beucephalus, "29, 30")
                .BindCharacters(CharacterEnum.CountStrahd).BindCreatures(Creature.Horse, Creature.Nightmare);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.TatsaulEris, "30");

            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.AnnaPetrovna, "28").ExtraInfo = "Probably deceased.";

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Arik, "8").BindCreatures(Creature.Human).BindAlignment(Alignment.CN);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.FatherDonavich, "9").BindCreatures(Creature.Human).BindAlignment(Alignment.LG);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.CountStrahd)
                .BindItems(ItemEnum.TomeOfStrahd)
                .BindCreatures(Creature.Human, Creature.Vampire, Creature.Bat, Creature.Wolf)
                .BindRelatedCreatures(Creature.Worg, Creature.StrahdZombie, Creature.Zombie)
                .BindAlignment(Alignment.CE)
                .BindCharacters(CharacterEnum.KingBarov, CharacterEnum.Ravenovia, CharacterEnum.Sergei);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Sergei, "1, 4, 30, 31").BindCreatures(Creature.Human)
                .BindCharacters(CharacterEnum.KingBarov, CharacterEnum.Ravenovia);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.KingBarov, "28, 30").BindCreatures(Creature.Human)
                .BindCharacters(CharacterEnum.Ravenovia);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Ravenovia, "5, 28, 30").BindCreatures(Creature.Human)
                .BindCharacters(CharacterEnum.KingBarov);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.MaryaMarkovia, "27, 28")
                .BindCharacters(CharacterEnum.Endorovich);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Endorovich, "27, 28")
                .BindCharacters(CharacterEnum.MaryaMarkovia)
                .BindCreatures(Creature.Spectre).BindAlignment(Alignment.LE);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.SashaIvliskova, "28")
                .BindCharacters(CharacterEnum.CountStrahd)
                .BindCreatures(Creature.Human, Creature.Vampire).BindAlignment(Alignment.CE);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.PatrinaVelikovna, "28")
                .BindCharacters(CharacterEnum.CountStrahd)
                .BindCreatures(Creature.Elf, Creature.Banshee).BindAlignment(Alignment.CE);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Tatyana, "1, 30, 31").BindCreatures(Creature.Human)
                .BindCharacters(CharacterEnum.CountStrahd, CharacterEnum.Sergei);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.KolyanIndirovich, "7, 8, 9").BindCreatures(Creature.Human)
                .BindCharacters(CharacterEnum.IreenaKolyana, CharacterEnum.Ismark);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.IreenaKolyana).BindCreatures(Creature.Human).BindAlignment(Alignment.LG)
                .BindCharacters(CharacterEnum.CountStrahd, CharacterEnum.Ismark);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Ismark, "8, 9").BindCreatures(Creature.Human).BindAlignment(Alignment.LG);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.MadMary, "9, 19").BindCreatures(Creature.Human).BindAlignment(Alignment.CN)
                .BindCharacters(CharacterEnum.Gertruda);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Gertruda, "9, 19").BindCreatures(Creature.Human).BindAlignment(Alignment.NG);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Bildrath, "8").BindCreatures(Creature.Human).BindAlignment(Alignment.LN)
                .BindCharacters(CharacterEnum.Parriwimple);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Parriwimple, "8").BindCreatures(Creature.Human).BindAlignment(Alignment.LN);
            #endregion

            #region Items
            DomainEnum.Barovia.AddItem(ItemEnum.Sunsword, "5, 31");
            DomainEnum.OutsideRavenloft.AddItem(ItemEnum.Sunsword, "5, 31");

            DomainEnum.Barovia.AddItem(ItemEnum.IconOfRaven, "14");
            DomainEnum.Barovia.AddItem(ItemEnum.SymbolOfRaven, "17, 30").BindCreatures(Creature.Vampire);
            DomainEnum.Barovia.AddItem(ItemEnum.TomeOfStrahd, "9, 11, 31");

            DomainEnum.Barovia.AddItem(ItemEnum.TomeOfStrahd, "9, 11, 31");

            DomainEnum.Barovia.AddItem(ItemEnum.EmbalmTheLostArt, "21").ExtraInfo = "Mundane Book";
            DomainEnum.Barovia.AddItem(ItemEnum.LifeAmongUndead, "21").ExtraInfo = "Mundane Book";
            DomainEnum.Barovia.AddItem(ItemEnum.IdentifyBloodTypes, "21").ExtraInfo = "Mundane Book";
            DomainEnum.Barovia.AddItem(ItemEnum.MasonryWoodwork, "21").ExtraInfo = "Mundane Book";
            #endregion

            #region Groups
            DomainEnum.Barovia.AddGroup(GroupEnum.BarovianWine, "27").BindCharacters(CharacterEnum.ArtankSwilovich);
            DomainEnum.Barovia.AddGroup(GroupEnum.BridesOfStrahd, "28")
                .BindCreatures(Creature.Vampire)
                .BindCharacters(CharacterEnum.SashaIvliskova, CharacterEnum.PatrinaVelikovna)
                .ExtraInfo = "Count Strahd has collected a few partners over the years.";
            DomainEnum.Barovia.AddGroup(GroupEnum.Tatyana, "30, 31").BindCharacters(CharacterEnum.Tatyana, CharacterEnum.IreenaKolyana);
            DomainEnum.Barovia.AddGroup(GroupEnum.Vistani, "1, 4, 7, 11, 28").BindLocations(Settlement.TserPoolEncampnent, LocationEnum.MadamEvasTent);
            DomainEnum.Barovia.AddGroup(GroupEnum.Burgomaster, "1, 7, 8, 9").BindCharacters(CharacterEnum.KolyanIndirovich);
            DomainEnum.Barovia.AddGroup(GroupEnum.BurgomasterOfBarovia, "1, 7, 8, 9").BindCharacters(CharacterEnum.KolyanIndirovich);
            DomainEnum.Barovia.AddGroup(GroupEnum.HighPriestMostHoly, "28").BindCharacters(CharacterEnum.CirilRomulich);
            DomainEnum.Barovia.AddGroup(GroupEnum.HighPriestRavenloft, "30").BindItems(ItemEnum.SymbolOfRaven);
            #endregion

            Settlement.Barovia.PopulateSettlement(LocationEnum.BildrathMercantile, LocationEnum.BloodVineTavern, LocationEnum.MaryHouse, LocationEnum.BurgomasterHome,
                                                  LocationEnum.BurgomasterGuestHouse, LocationEnum.BaroviaChurch, LocationEnum.BaroviaChurch);
            Settlement.TserPoolEncampnent.PopulateSettlement(LocationEnum.MadamEvasTent);
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
            using var ctx = CreateSource("I10: Ravenloft II: The House on Gryphon Hill", releaseDate, ExtraInfo, Edition.e1, Media.module);

            DomainEnum.Barovia.Appeared("2, 5, 41");
            DomainEnum.Mordent.Appeared();

            #region Locations
            DomainEnum.Barovia.AddLocation(LocationEnum.CastleRavenloft, "5, 12");

            DomainEnum.Mordent.AddSettlement(Settlement.Mordentshire)
                .BindCreatures(Creature.CrimsonDeath, Creature.Drelb, Creature.InvisibleStalker, Creature.LurkerAbove, Creature.ShadowMastiff, Creature.Spectre, Creature.Wraith, Creature.Lich, Creature.GroaningSpirit, Creature.Human, Creature.Ghast, Creature.BlackCat, Creature.Wight, Creature.Dog, Creature.Raven);

            DomainEnum.Mordent.AddLocation(LocationEnum.SaulbridgeSanitarium, "6, 13, 23, 24, Cargo Roster");
            DomainEnum.Mordent.AddLocation(LocationEnum.GryphonHill, "1, 2, 7, 16, 19, 22, 23, 25, 26, 28, 32, 41, 44-47, Cargo Roster, Event Chart");
            DomainEnum.Mordent.AddLocation(LocationEnum.GryphonHillMansion, "1, 2, 7, 16, 19, 22, 23, 26, 28-31, 44, 47, 48")
                .BindCreatures(Creature.Vampire, Creature.GroaningSpirit, Creature.Gargoyle, Creature.StoneGolem, Creature.Spirit, Creature.Ghost, Creature.Mouse, Creature.GiantSpider, Creature.Shade, Creature.Haunt, Creature.Drelb, Creature.Stirge, Creature.LurkerAbove, Creature.QuasiElementalLightning, Creature.GreenSlime);

            DomainEnum.Mordent.AddLocation(LocationEnum.HeatherHouse, "1, 3, 10, 13, 15, 16, 19, 24, 26, 32-39, 41, 44, 45, 47, Cargo Roster")
                .BindCreatures(Creature.GiantToad, Creature.Stirge, Creature.GreenSlime, Creature.Vampire, Creature.InvisibleStalker, Creature.Haunt, Creature.Shade, Creature.GroaningSpirit, Creature.Banshee, Creature.Horse, Creature.SkeletalSteed, Creature.Maggot, Creature.StrahdZombie, Creature.StoneGolem, Creature.Gargoyle, Creature.Raven, Creature.Doppelganger, Creature.StrahdSkeleton, Creature.ShadowMastiff, Creature.Trapper);

            DomainEnum.Mordent.AddLocation(LocationEnum.WeathermayMausoleum, "1, 15, 32, 38, 39, 45, 48, Event Chart")
                .BindCreatures(Creature.Spectre, Creature.Wraith);
            DomainEnum.Mordent.AddLocation(LocationEnum.BlackardInn, "14, 19, 20, Cargo Roster").BindCreatures(Creature.Spider);
            DomainEnum.Mordent.AddLocation(LocationEnum.Livery, "14");
            DomainEnum.Mordent.AddLocation(LocationEnum.Garrison, "14").BindCreatures(Creature.GiantRat);
            DomainEnum.Mordent.AddLocation(LocationEnum.BurnedChurch, "14, 22, Cargo Roster");
            DomainEnum.Mordent.AddLocation(LocationEnum.Smithy, "14, 22, Cargo Roster");
            DomainEnum.Mordent.AddLocation(LocationEnum.MayorsHouse, "1, 14, 23");
            DomainEnum.Mordent.AddLocation(LocationEnum.KervilsShop, "14, 23");
            DomainEnum.Mordent.AddLocation(LocationEnum.Marketplace, "14");
            DomainEnum.Mordent.AddLocation(LocationEnum.Warehouse, "15, 21");
            DomainEnum.Mordent.AddLocation(LocationEnum.SouthRoad, "15, 25");
            DomainEnum.Mordent.AddLocation(LocationEnum.KeeldevilPoint, "17");
            DomainEnum.Mordent.AddLocation(LocationEnum.FishermanAlley, "17, 24, Cargo Roster").BindCreatures(Creature.Doppelganger);
            DomainEnum.Mordent.AddLocation(LocationEnum.ShippingHouse, "21");
            DomainEnum.Mordent.AddLocation(LocationEnum.SeventhSea, "21, 42");
            DomainEnum.Mordent.AddLocation(LocationEnum.TravelersInn, "21, Cargo Roster");
            DomainEnum.Mordent.AddLocation(LocationEnum.AnchorStreet, "21");
            DomainEnum.Mordent.AddLocation(LocationEnum.ShoreLane, "21");
            DomainEnum.Mordent.AddLocation(LocationEnum.MillRoad, "21");
            DomainEnum.Mordent.AddLocation(LocationEnum.MillBridge, "21").BindCreatures(Creature.BlackCat);
            DomainEnum.Mordent.AddLocation(LocationEnum.ArdenRiver, "21, 25, Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.OldMill, "21");
            DomainEnum.Mordent.AddLocation(LocationEnum.Churchyard, "22");
            DomainEnum.Mordent.AddLocation(LocationEnum.OldSaltHouse, "22, Cargo Roster");
            DomainEnum.Mordent.AddLocation(LocationEnum.SaltyDogTavern, "22");
            DomainEnum.Mordent.AddLocation(LocationEnum.Butcher, "22, Cargo Roster");
            DomainEnum.Mordent.AddLocation(LocationEnum.Bakery, "22");
            DomainEnum.Mordent.AddLocation(LocationEnum.Groundskeeper, "23");
            DomainEnum.Mordent.AddLocation(LocationEnum.OldBooks, "23");
            DomainEnum.Mordent.AddLocation(LocationEnum.Wharf, "9, 21, 23").BindCreatures(Creature.GroaningSpirit);
            DomainEnum.Mordent.AddLocation(LocationEnum.Farms, "24");
            DomainEnum.Mordent.AddLocation(LocationEnum.ArdentBay, "24").BindCreatures(Creature.StrahdZombie);

            DomainEnum.Mordent.AddLocation(LocationEnum.WindwandAvenue, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.GlenRoad, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.MarketStreet, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.Barracks, "Map").BindLocations(LocationEnum.Gaol);
            DomainEnum.Mordent.AddLocation(LocationEnum.Gaol, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.HeatherWay, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.MaddingRoad, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.Backwater, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.ButcherLane, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.WoodHollow, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.Cliffedge, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.Scrimshaw, "Map");

            DomainEnum.Mordent.AddLocation(LocationEnum.NorthRoad, "25");
            DomainEnum.Mordent.AddLocation(LocationEnum.NorthMoors, "25, 42").BindCreatures(Creature.Harpy);
            DomainEnum.Mordent.AddLocation(LocationEnum.Cliffs, "25").BindCreatures(Creature.Orc, Creature.Ogre, Creature.Ghast);
            DomainEnum.Mordent.AddLocation(LocationEnum.DarkWoods, "25, 26, 31").BindCreatures(Creature.GiantSpider, Creature.Ogre, Creature.Vulture);

            DomainEnum.Mordent.AddLocation(LocationEnum.GryphonRoad, "26");
            DomainEnum.Mordent.AddLocation(LocationEnum.Bog, "26").BindCreatures(Creature.CrimsonDeath);
            DomainEnum.Mordent.AddLocation(LocationEnum.Cemetery, "26").BindCreatures(Creature.StrahdZombie, Creature.StrahdSkeleton);

            DomainEnum.Mordent.AddLocation(LocationEnum.HiddenTrack, "26").BindCreatures(Creature.Mihstu, Creature.Werewolf);
            DomainEnum.Mordent.AddLocation(LocationEnum.HeatherHousePoint, "32").BindCreatures(Creature.DisplacerBeast, Creature.ShadowMastiff, Creature.Wraith, Creature.Hellhound, Creature.Skeleton, Creature.Raven, Creature.StrahdZombie, Creature.GiantSpider);
            DomainEnum.Mordent.AddLocation(LocationEnum.Heatherwood, "32, 33").BindCreatures(Creature.DisplacerBeast, Creature.ShadowMastiff, Creature.Wraith, Creature.Hellhound, Creature.Skeleton, Creature.Raven, Creature.StrahdZombie, Creature.GiantSpider, Creature.Deer, Creature.Rabbit, Creature.Squirrel, Creature.Skunk);
            DomainEnum.Mordent.AddLocation(LocationEnum.HeatherRoad, "33");
            #endregion

            #region Characters
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.CountStrahd);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.CountStrahd)
                .BindAlignment(Alignment.CE | Alignment.NG)
                .BindCreatures(Creature.Human, Creature.Vampire, Creature.Bat, Creature.Wolf)
                .BindRelatedCreatures(Creature.Banshee, Creature.StrahdZombie, Creature.StrahdSkeleton, Creature.DireWolf, Creature.Hellhound, Creature.ShadowMastiff, Creature.Raven, Creature.VampireBat, Creature.Rat, Creature.Bat, Creature.Quasit, Creature.Werewolf, Creature.Harpy, Creature.Ogre, Creature.Vulture, Creature.Nightmare, Creature.BlackCat, Creature.StrahdSteed)
                .ExtraInfo = "Referred to here as either 'Alchemist' or 'Creature'";

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Sergei, "5")
                .BindCharacters(CharacterEnum.CountStrahd, CharacterEnum.Tatyana)
                .BindCreatures(Creature.Human);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Tatyana, "5, 47")
                .BindCharacters(CharacterEnum.CountStrahd);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LadyWeathermay, "3, 6-9, 32, 33, 36, 40, 44, 45, Cargo Roster")
                .BindCreatures(Creature.Human).BindAlignment(Alignment.LG);

            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.OldLadyWeathermay, "35, 36, 38")
                .BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LordWeathermay, "3, 6, 8-10, 12-14, 17, 32-36, 44, 45")
                .BindCreatures(Creature.Human).BindAlignment(Alignment.LG);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MistressArdent, "3, 6, 9, 32, 35, 44, Cargo Roster")
                .BindCreatures(Creature.Human).BindAlignment(Alignment.CG);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Germain, "3, 6, 7, 10, 13, 20, 24, Cargo Roster")
                .BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Marion, "13").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Dominic, "13, 20, Cargo Roster, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Luker, "13, 14, 24").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.CavelWarden, "15, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.KedarKlienan, "16, 17, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Justinian, "16, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Honorius, "16, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Carlisle, "16, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BrennaRaven, "16, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.TabbFinhallen, "16, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.KirkTerrinton, "16, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MayorMalvinHeatherby, "16, 17, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.TylerSmythy, "16, 20, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.GregorBoyd, "17").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.AzalinRex, "17, 38, 39, Transpossession Rosters Handout").BindCreatures(Creature.Human, Creature.Lich, Creature.Quasit, Creature.Horse).BindAlignment(Alignment.NE);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.GlennaWarden, "19, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Gwydion, "19, 20, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.GastonHedgewick, "19, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.ArianaBartel, "19, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.CarinaLoch, "19, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.DarcyPease, "19, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BathildaSud, "19, 23, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.IdaHobson, "19, 22, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.KynaSmythy, "20, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.SolitaMaravan, "21, Cargo Roster, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.UstisMaravan, "21").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.SterlingToddburry, "21, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.EthanToddburry, "21, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.ChristinaBartel, "21, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.EricaToddburry, "22, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.FatherJoshuaTalbot, "22, 28, Cargo Roster, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.NormalKervil, "22").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.NeolaCaraway, "22, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.SilasArcher, "22, Cargo Roster, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.VioletArcher, "22, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.PenelopeArcher, "22, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.ElwinHobson, "22, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.TildaMayberry, "22, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.FreedaMayberry, "22, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BerwinHedgewick, "23, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LenorHedgewick, "23, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LobeliaTarner, "23, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.RaeSoddenter, "23, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.ParvisSoddenter, "23, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LeeHeatherby, "23, 34, 35, Cargo Roster, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindRelatedCreatures(Creature.Horse);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MargaretHeatherby, "23, 34, 35, Cargo Roster, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.TobaisKenkiny, "23, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.DesmaKenkiny, "23, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LordWilfredGodefroy, "23, 28, 31, 39, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human, Creature.Haunt).BindAlignment(Alignment.CN);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LadyEstelleWeathermayGodefroy, "23, 28, 29, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human, Creature.Ghost);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LiliaGodefroy, "23, 29, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human, Creature.Haunt);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.GoodmanMorris, "23").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LordRenier, "23, 39, 45").BindCreatures(Creature.Human);
            CharacterEnum.GoodmanMorris.ExtraInfo = CharacterEnum.LordRenier.ExtraInfo = "Probably deceased";

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.VoglerKervil, "23, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.CyrusBelview, "24").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.VoglerKervil, "23, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Marston, "24").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Ellie, "24").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.AxtelBartel, "24, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BarthKleinen, "24, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.PercivalSud, "24, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.HargelGrummsh, "25").BindCreatures(Creature.Orc).BindRelatedCreatures(Creature.Ogre, Creature.Ghast);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.EismanKhargug, "25").BindCreatures(Creature.Orc);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.CoriemonHandlet, "26, Transpossession Rosters Handout").BindCreatures(Creature.Bodak).BindRelatedCreatures(Creature.Ogre, Creature.Vulture, Creature.Wight);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.GorbaghSnarltooth, "26").BindCreatures(Creature.Ogre);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.GastonImrad, "29, Transpossession Rosters Handout").BindCreatures(Creature.Shade);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.SheclkeDuskman, "29, Transpossession Rosters Handout").BindCreatures(Creature.Shade);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.ArlieEsterbridge, "29").BindCreatures(Creature.Vampire);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.CarlRamm, "31, Transpossession Rosters Handout").BindCreatures(Creature.Mummy);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.TandleCoreystal, "31, Transpossession Rosters Handout").BindCreatures(Creature.Shade);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.EllenStinworthy, "31, Transpossession Rosters Handout").BindCreatures(Creature.Mummy);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.KarenEdgerton, "31, Transpossession Rosters Handout").BindCreatures(Creature.Wight);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Sshhisthulhuu, "31, Transpossession Rosters Handout").BindCreatures(Creature.Mihstu);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.WinifredKleinen, "35, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BridgetDumas, "35, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BaronFielders, "3, 33, 35, 36, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BaronessFielders, "3, 33, 35, 36, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LadyFielders, "3, 33, 35, 36").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Lucifer, "36").BindCreatures(Creature.Raven);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.EmmaKelley, "37, Transpossession Rosters Handout").BindCreatures(Creature.Vampire);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Tintantilus, "42, 45").BindCreatures(Creature.Quasit, Creature.Bat, Creature.Wolf);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.CharityBliss, "42, Transpossession Rosters Handout").BindCreatures(Creature.Vampire);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.ThadeusMontBreezar, "47, Card Handout")
                .BindCreatures(Creature.Human).BindRelatedCreatures(Creature.Horse).BindAlignment(Alignment.TN)
                .BindLanguages(Language.Common, Language.MountainGiant, Language.Orcish, Language.RedDragon, Language.Treantish, Language.Illithid, Language.Drow, Language.KuoToan);

            var Mysti = ctx.CreateNPC("Mysti Tokana", "48, Card Handout").BindCreatures(Creature.HalfElf, Alignment.CG, Language.Common, Language.Elf, Language.Gnome, Language.Halfling, Language.Goblin, Language.Hobgoblin, Language.Orcish, Language.Gnoll);

            var Amar = ctx.CreateNPC("Amar Bori Sandflinger", "48, Card Handout").BindCreatures(Creature.Gnome, Alignment.TN, Language.Common, Language.Dwarvish, Language.Gnome, Language.Halfling, Language.Goblin, Language.BurrowingMammals, Language.Elf, Language.DesertNomad);

            var Rogold = ctx.CreateNPC("Rogold Gildenman", "Card Handout").BindCreatures(Creature.Human, Creature.Horse, Alignment.LG, Language.Common, Language.Elf, Language.Gnome, Language.HillGiant, Language.Ogre);
            var Barnabas = ctx.CreateNPC("Barnabas", "Card Handout").BindCreatures(Creature.Horse);

            var Phillipe = ctx.CreateNPC("Phillipe Delamana", "Card Handout").BindCreatures(Creature.Human, Alignment.LG, Creature.Horse, Language.Common, Language.Elf, Language.Dwarvish);
            var Rembrania = ctx.CreateNPC("Rembrania", "Card Handout").BindCreatures(Creature.Horse);

            var Brenda = ctx.CreateNPC("Brenda of the Crimson Blade", "Card Handout").BindCreatures(Creature.Human, Alignment.NG, Creature.Horse, Language.Common, Language.Troll);
            var Sugartooth = ctx.CreateNPC("Sugartooth", "Card Handout").BindCreatures(Creature.Horse);

            var Summer = ctx.CreateNPC("Kregash Garzaala", "Brother Summer", "Card Handout").BindCreatures(Creature.HalfOrc, Creature.Orc, Alignment.LN, Creature.Horse, Language.Common, Language.Orcish, Language.DesertNomad);
            var Muffin = ctx.CreateNPC("Muffin", "Card Handout").BindCreatures(Creature.Horse);

            var TG = ctx.CreateNPC("Terribly Good Redanto", "T.G. Redanto", "Card Handout").BindCreatures(Creature.Human, Alignment.TN, Creature.Horse, Language.Common, Language.Elf, Language.Halfling, Language.Orcish, Language.Drow);
            var Apricot = ctx.CreateNPC("Apricot", "Card Handout").BindCreatures(Creature.Horse);

            var Mikhail = ctx.CreateNPC("Mikhail Yelkif", "Cargo Roster");

            var Trellgaard = ctx.CreateNPC("Trellgaard", "Transpossession Rosters Handout").BindCreatures(Creature.Gargoyle);
            var Ilmen = ctx.CreateNPC("Master Ilmen", "Transpossession Rosters Handout").BindCreatures(Creature.StrahdZombie);
            var Caarey = ctx.CreateNPC("Caarey Gelthik", "Transpossession Rosters Handout").BindCreatures(Creature.Ghast);
            var Sean = ctx.CreateNPC("Sean Timothy", "Transpossession Rosters Handout").BindCreatures(Creature.Werewolf);
            var Jerimy = ctx.CreateNPC("Jerimy Estmore", "Transpossession Rosters Handout").BindCreatures(Creature.Wight);
            var Tangle = ctx.CreateNPC("Master Tangle", "Transpossession Rosters Handout").BindCreatures(Creature.Wraith);
            var Wren = ctx.CreateNPC("Wren Thims", "Transpossession Rosters Handout").BindCreatures(Creature.Wraith);
            var Sharon = ctx.CreateNPC("Sharon Teece", "Transpossession Rosters Handout").BindCreatures(Creature.GroaningSpirit);
            var Molly = ctx.CreateNPC("Molly Grayswit", "Transpossession Rosters Handout").BindCreatures(Creature.Vampire);

            var Stelwaard = ctx.CreateNPC("Stelwaard", "Transpossession Rosters Handout").BindCreatures(Creature.Gargoyle);
            var Thinn = ctx.CreateNPC("Thinn Balder", "Transpossession Rosters Handout").BindCreatures(Creature.Zombie);
            var Badder = ctx.CreateNPC("Badder Ghastling", "Transpossession Rosters Handout").BindCreatures(Creature.Ghast);
            var Esther = ctx.CreateNPC("Esther Timothy", "Transpossession Rosters Handout").BindCreatures(Creature.Werewolf);
            var Geam = ctx.CreateNPC("Geam Pelstap", "Transpossession Rosters Handout").BindCreatures(Creature.Wraith);
            var Maquir = ctx.CreateNPC("Maquir Loft", "Transpossession Rosters Handout").BindCreatures(Creature.Wraith);
            var Miranda = ctx.CreateNPC("Miranda Langstry", "Transpossession Rosters Handout").BindCreatures(Creature.GroaningSpirit);
            var Kelman = ctx.CreateNPC("Kelman Osterlaker", "Transpossession Rosters Handout").BindCreatures(Creature.Spectre);

            var Fiona = ctx.CreateNPC("Fiona Matheson", "Transpossession Rosters Handout").BindCreatures(Creature.Human);
            var Fanerath = ctx.CreateNPC("Fanerath", "Transpossession Rosters Handout").BindCreatures(Creature.Gargoyle);
            var Hellinken = ctx.CreateNPC("Hellinken", "Transpossession Rosters Handout").BindCreatures(Creature.Doppelganger);
            var Kattle = ctx.CreateNPC("Kattle Lisbury", "Transpossession Rosters Handout").BindCreatures(Creature.Wight);
            var Emory = ctx.CreateNPC("Emory Maus", "Transpossession Rosters Handout").BindCreatures(Creature.Wight);
            var Marcus = ctx.CreateNPC("Marcus Lithe", "Transpossession Rosters Handout").BindCreatures(Creature.Wraith);
            var Nendrum = ctx.CreateNPC("Nendrum Sintel", "Transpossession Rosters Handout").BindCreatures(Creature.Drelb);
            var Thellactin = ctx.CreateNPC("Thellactin Mianns", "Transpossession Rosters Handout").BindCreatures(Creature.Spectre);
            var Kelly = ctx.CreateNPC("Kelly Duncan", "Transpossession Rosters Handout").BindCreatures(Creature.GroaningSpirit);
            var Cheldon = ctx.CreateNPC("Cheldon Illcome", "Transpossession Rosters Handout").BindCreatures(Creature.Bodak);

            var Mythrel = ctx.CreateNPC("Mythrel", "Transpossession Rosters Handout").BindCreatures(Creature.Gargoyle);
            var Millicent = ctx.CreateNPC("Millicent Hodgson", "Transpossession Rosters Handout").BindCreatures(Creature.Zombie);
            var Natterly = ctx.CreateNPC("Natterly Knutnor", "Transpossession Rosters Handout").BindCreatures(Creature.Ghast);
            var Eowin = ctx.CreateNPC("Eowin Timothy", "Transpossession Rosters Handout").BindCreatures(Creature.Werewolf);
            var Momsin = ctx.CreateNPC("Momsin Alenny", "Transpossession Rosters Handout").BindCreatures(Creature.Wight);
            var Shingol = ctx.CreateNPC("Shingol Tann", "Transpossession Rosters Handout").BindCreatures(Creature.Wraith);
            var Larson = ctx.CreateNPC("Larson Chelf", "Transpossession Rosters Handout").BindCreatures(Creature.Drelb);
            var Yettergun = ctx.CreateNPC("Yettergun Folie", "Transpossession Rosters Handout").BindCreatures(Creature.Spectre);
            var Leslie = ctx.CreateNPC("Leslie Kale", "Transpossession Rosters Handout").BindCreatures(Creature.GroaningSpirit);
            #endregion

            #region Items
            var Apparatus = ctx.CreateItem("Apparatus", "3, 4, 6, 8, 10, 14, 19, 26, 30-32, 34-41, 43-48, Adventure Plot");
            var RodOfRastinon = ctx.CreateItem("Rod of Rastinon", "3, 4, 6, 8, 10, 17, 30, 40, 46, Adventure Plot");
            var SSOrb = ctx.CreateItem("Soul Search Medallion", "Soul Search Orb", "3, 6, 7, 10, 14, 46, Adventure Plot");
            var RingOfReverse = ctx.CreateItem("Ring of Reversion", "3, 6, 7, 10, 14, 26, 46, Adventure Plot").BindCreatures(Alignment.NG);
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
            var MirrorOfLaw = ctx.CreateItem("Mirror Of Lawful Alignment", "26").BindCreatures(Alignment.LG, Alignment.LN, Alignment.LE).AddInfo("The mirror doesn't have a name in the module, this is a placeholder title.");

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
            var ScrollOfProtWS = ctx.CreateItem("Scroll of Protection from Wraiths and Spectres", "Card Handout").BindCreatures(Creature.Wraith, Creature.Spectre);

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
            var Moors = ctx.CreateGroup("Moors of Mordentshire", "1, 3, 12, 16, 23-26, 43").BindCreatures(Creature.Human, Creature.StrahdZombie, Creature.Griffon, Creature.Harpy, Creature.Hellhound, Creature.Orc, Creature.Ogre, Creature.QuasiElementalLightning, Creature.Raven, Creature.GiantSpider, Creature.Stirge, Creature.Vulture, Creature.DireWolf, Creature.Bodak, Creature.Ghast, Creature.GroaningSpirit.Item1, Creature.GroaningSpirit.Item2, Creature.ShadowMastiff, Creature.Nightmare, Creature.Skeleton, Creature.SkeletonSteed.Item1, Creature.SkeletonSteed.Item2, Creature.Wraith, Creature.WillOWisp, Creature.CrimsonDeath.Item1, Creature.CrimsonDeath.Item2, Creature.Doppelganger, Creature.DisplacerBeast, Creature.StrahdSkeleton);
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