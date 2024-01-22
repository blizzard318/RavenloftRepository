using static Factory;

internal static partial class AddToDatabase
{
    public static void Add4()
    {
        AddFeastOfGoblyns();
        void AddFeastOfGoblyns()
        {
            var releaseDate = "01/09/1990";
            string ExtraInfo = "<br/>&emsp;Designed: Blake Mobley";
            ExtraInfo += "<br/>&emsp;Edited: William W. Connors";
            ExtraInfo += "<br/>&emsp;Black & White Art: Stephen Fabian";
            ExtraInfo += "<br/>&emsp;Color Art: Clyde Caldwell";
            ExtraInfo += "<br/>&emsp;Graphic Design: Roy E. Parker";
            ExtraInfo += "<br/>&emsp;Cartography: Karen Fonstad";
            ExtraInfo += "<br/>&emsp;Typesetting: Gaye O'Keefe & Angelika Lokotz";
            ExtraInfo += "<br/>&emsp;Production: Sarah Feggestad & Paul Hanchette";
            ExtraInfo += "<br/>&emsp;Module Info: An adventure for 6-8 characters of levels 4-7";
            using var ctx = CreateSource("Feast of Goblyns", releaseDate, ExtraInfo, Edition.e2, Media.module);

            #region Domains
            DomainEnum.Kartakass.Appeared("1-2, 5, 8, 10-13, 18-65").BindCreatures(Creature.Wolf, Creature.DireWolf, Creature.Worg, Creature.Werewolf, Creature.Wolfwere, Creature.WinterWolf, Creature.Kobold, Creature.Boar, Creature.Wereboar, Creature.Jackal, Creature.Jackalwere, Creature.Wight, Creature.Ghoul, Creature.Goblin, Creature.Leucrotta, Creature.Werefox, Creature.GreaterWolfwere, Creature.LoupGarou).BindLanguages(Language.Common);
            DomainEnum.Gundarak.Appeared("2, 4, 8, 11-13, 27, 30, 43-44, 65").BindCreatures(Creature.Rat, Creature.Bat, Creature.Wolf, Creature.Spider, Creature.Werewolf, Creature.Kobold, Creature.Goblin);
            DomainEnum.Bluetspur.Appeared("8, 10-11, 29, 37, 51");
            DomainEnum.Daglan.Appeared("8, 11");
            DomainEnum.Sithicus.Appeared("11, 30");
            DomainEnum.Barovia.Appeared("13");
            DomainEnum.Forlorn.Appeared("26");

            DomainEnum.InsideRavenloft.BindCreatures(Creature.Skeleton, Creature.Zombie, Creature.Ghoul, Creature.Shadow, Creature.Wight, Creature.Ghast, Creature.Wraith, Creature.Mummy, Creature.Spectre, Creature.Vampire, Creature.Ghost, Creature.Lich, Creature.Goblyn, Creature.CarnivorousPlant, Creature.GreaterWolfwere, Creature.Wolfwere);
            #endregion

            #region Darklords
            DomainEnum.Kartakass.AddLivingDarklord(DarklordEnum.HarkonLukas, "1-3, 8-13, 16-19, 26-27, 29-30, 35, 37, 39-42, 44").BindCreatures(Creature.Wolfwere, Creature.DireWolf).BindCloseBorder("Envelope the land in a region of sweet songs. Those who attempt to pass through the border will find themselves growing ever more fatigued. If they do not turn back, they will fall unconscious - only to awaken back in Kartakass.").BindLair(LocationEnum.KartakanInn);

            DomainEnum.Gundarak.AddLivingDarklord(DarklordEnum.LordGundar, "1, 8-9, 11-13, 26-27, 43").BindCharacters(DarklordEnum.Dominiani).BindCreatures(Creature.Vampire).BindRelatedCreatures(Creature.Wolf);

            DomainEnum.Daglan.AddLivingDarklord(DarklordEnum.Radaga, "1, 3-4, 8, 11-12, 14, 46-47, 50, 53, 55-57").BindAlignment(Alignment.NE | Alignment.LE).BindDomains(DomainEnum.Kartakass).BindCreatures(Creature.Human, Creature.Wight).BindRelatedCreatures(Creature.SkeletonSteed, Creature.Quickwood);

            DomainEnum.Daglan.AddLivingDarklord(DarklordEnum.Daglan, "1, 11, 13-14").BindAlignment(Alignment.CE).BindCharacters(DarklordEnum.Radaga);
            #endregion

            #region Characters
            DomainEnum.Gundarak.AddLivingCharacter(DarklordEnum.Dominiani, "1, 3-4, 8-9, 12-13, 26-27, 43, 65").BindAlignment(Alignment.CE).BindCreatures(Creature.Vampire);
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.Akriel, "1, 3-4, 8-9, 12-13, 16-18, 26-29, 37, 41-43, 65").BindAlignment(Alignment.CE).BindCreatures(Creature.Wolfwere, Creature.Human, Creature.Wolf).BindCharacters(DarklordEnum.HarkonLukas, CharacterEnum.Kahrus, CharacterEnum.MeistersingerZhone);
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.MeistersingerZhone, "19");
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.Kahrus, "22-23").BindAlignment(Alignment.TN);
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.Devon, "22-23").BindAlignment(Alignment.NG);
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.Bakki, "22-23").BindAlignment(Alignment.NG);
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.JaconosHanabara, "22-23").BindAlignment(Alignment.CE).BindCreatures(Creature.LoupGarou, Creature.Werewolf);

            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.Maria, "28-29").BindCharacters(CharacterEnum.Ontosh, CharacterEnum.Frantosh, CharacterEnum.Jelena, CharacterEnum.Joshua);
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.Ontosh, "28-29").BindCharacters(CharacterEnum.Frantosh, CharacterEnum.Jelena, CharacterEnum.Joshua);
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.Frantosh, "28-29").BindCharacters(CharacterEnum.Jelena, CharacterEnum.Joshua);
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.Jelena, "28-29").BindCharacters(CharacterEnum.Joshua);
            DomainEnum.Kartakass.AddDeadCharacter(CharacterEnum.Joshua, "28");
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.Jackques, "28-29, 44, 65").BindAlignment(Alignment.CE).BindCharacters(CharacterEnum.Joshua).BindCreatures(Creature.Wolfwere).BindRelatedCreatures(Creature.Wolf);
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.MadamLupapus, "30").BindCharacters(DarklordEnum.HarkonLukas);

            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.HeinstockBeeterLupock, "39-41, 44").BindAlignment(Alignment.CE).BindCharacters(DarklordEnum.HarkonLukas).BindCreatures(Creature.Wolfwere);
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.Coraline, "39-40, 43-44").BindAlignment(Alignment.CE).BindCharacters(DarklordEnum.HarkonLukas).BindCreatures(Creature.Werefox);
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.HaldrakeMoonbaun, "40-41, 44").BindAlignment(Alignment.NE).BindCharacters(DarklordEnum.HarkonLukas).BindCreatures(Creature.GreaterWolfwere);
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.Ledalar, "40, 44").BindAlignment(Alignment.CE).BindCharacters(DarklordEnum.HarkonLukas).BindCreatures(Creature.Wolfwere);
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.Gleeda, "40").BindAlignment(Alignment.NE);
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.Teena, "40").BindAlignment(Alignment.NE);
            #endregion

            #region Items
            DomainEnum.InsideRavenloft.AddItem(ItemEnum.CrownOfSouls, "1, 4, 8-9, 11, 13-15, 26-27, 37, 50, 56, 63, 65").BindDomains(DomainEnum.Kartakass, DomainEnum.Gundarak, DomainEnum.Daglan).BindCharacters(DarklordEnum.Daglan, DarklordEnum.Radaga).BindCreatures(Creature.Human, Creature.Goblyn, Creature.Elf);
            DomainEnum.Daglan.AddItem(ItemEnum.Staff.Wither, "12").BindCharacters(DarklordEnum.Radaga);
            DomainEnum.Kartakass.AddItem(ItemEnum.Drink.Meekulbrau, "17");
            DomainEnum.Kartakass.AddItem(ItemEnum.Plant.Woflsbane, "26, 28");
            DomainEnum.Kartakass.AddItem(ItemEnum.OilOfFieryBurning, "29").BindCharacters(CharacterEnum.Jackques);
            DomainEnum.Kartakass.AddItem(ItemEnum.Potion.ExtraHeal, "43").BindCharacters(CharacterEnum.Akriel);
            DomainEnum.Kartakass.AddItem(ItemEnum.DaggerOfVenom, "43").BindCharacters(DarklordEnum.HarkonLukas);
            DomainEnum.Kartakass.AddItem(ItemEnum.HarkonHarp, "43").BindCharacters(DarklordEnum.HarkonLukas);
            DomainEnum.Kartakass.AddItem(ItemEnum.HarkonChess, "43").BindCharacters(DarklordEnum.HarkonLukas);
            DomainEnum.Kartakass.AddItem(ItemEnum.PipesOfPain, "44").BindCharacters(DarklordEnum.HarkonLukas);
            DomainEnum.Kartakass.AddItem(ItemEnum.LordsCoach, "45").BindCharacters(DarklordEnum.HarkonLukas);
            DomainEnum.Kartakass.AddItem(ItemEnum.Plant.Nightblight, "51").BindCreatures(Creature.Vampire, Creature.Wolfwere, Creature.Werewolf);
            DomainEnum.Kartakass.AddItem(ItemEnum.StoneOfDeath, "53").BindCharacters(DarklordEnum.Radaga);
            #endregion

            #region Groups
            DomainEnum.InsideRavenloft.AddGroup(GroupEnum.Vistani, "9, 26-27");
            DomainEnum.Kartakass.AddGroup(GroupEnum.Meistersinger, "10. 16-17").BindLocations(LocationEnum.MeistersingerDungeon, LocationEnum.MeistersingerKeep, LocationEnum.MeistersingerMansion);
            DomainEnum.InsideRavenloft.AddGroup(GroupEnum.DarkPowers, "11, 14");
            #endregion

            #region Settlements
            DomainEnum.Kartakass.AddSettlement(Settlement.Harmonia, "1, 6, 8, 10, 16-29, 32, 37").BindCreatures(Creature.Wolfwere, Creature.Sheep);
            DomainEnum.Kartakass.AddSettlement(Settlement.Skald, "1, 8-10, 16, 20, 27-28, 30-45, 65").BindCreatures(Creature.Wolfwere);
            DomainEnum.Daglan.AddSettlement(Settlement.Homlock, "4, 8").BindCharacters(DarklordEnum.Radaga);
            #endregion

            #region Locations
            DomainEnum.Kartakass.AddLocation(LocationEnum.KartakanWoods, "6").BindCreatures(Creature.DireWolf);
            DomainEnum.Kartakass.AddLocation(LocationEnum.Balinoks, "10, 65");
            DomainEnum.Kartakass.AddLocation(LocationEnum.HarmonicHall, "16-19, 34").BindLocations(Settlement.Harmonia).BindCharacters(CharacterEnum.MeistersingerZhone);
            DomainEnum.Kartakass.AddLocation(LocationEnum.CrystalClub, "16-18").BindCharacters(DarklordEnum.HarkonLukas, CharacterEnum.Akriel).BindCreatures(Creature.Wolfwere).BindItems(ItemEnum.Drink.Meekulbrau);
            DomainEnum.Kartakass.AddLocation(LocationEnum.RoadToHarmony, "16").BindLocations(Settlement.Harmonia, Settlement.Skald).BindCharacters(CharacterEnum.Maria, CharacterEnum.Joshua);
            DomainEnum.Kartakass.AddLocation(LocationEnum.MeistersingerMansion, "16, 19").BindLocations(Settlement.Harmonia).BindCharacters(CharacterEnum.MeistersingerZhone);
            DomainEnum.Kartakass.AddLocation(LocationEnum.TheLoop, "16, 18").BindLocations(Settlement.Harmonia, LocationEnum.MeistersingerMansion);
            DomainEnum.Kartakass.AddLocation(LocationEnum.Amphitheater, "16-17").BindLocations(Settlement.Harmonia);
            DomainEnum.Kartakass.AddLocation(LocationEnum.SouthHillHarmonia, "18").BindLocations(Settlement.Harmonia).BindCreatures(Creature.Wolfwere);
            DomainEnum.Kartakass.AddLocation(LocationEnum.SouthGateHarmonia, "19").BindLocations(Settlement.Harmonia);
            DomainEnum.Kartakass.AddLocation(LocationEnum.WestGateHarmonia, "19").BindLocations(Settlement.Harmonia);
            DomainEnum.Kartakass.AddLocation(LocationEnum.CityMoatHarmonia, "19").BindLocations(Settlement.Harmonia);
            DomainEnum.Kartakass.AddLocation(LocationEnum.MinstrelRiver, "19-20").BindLocations(Settlement.Harmonia);
            DomainEnum.Kartakass.AddLocation(LocationEnum.MeistersingerDungeon, "19").BindLocations(Settlement.Harmonia);
            DomainEnum.Kartakass.AddLocation(LocationEnum.WhirlingBridge, "20").BindLocations(Settlement.Harmonia);
            DomainEnum.Kartakass.AddLocation(LocationEnum.GuardTowersHarmonia, "20-21").BindLocations(Settlement.Harmonia).BindCreatures(Creature.Human);
            DomainEnum.Kartakass.AddLocation(LocationEnum.CliffLift, "21").BindLocations(Settlement.Harmonia);
            DomainEnum.Kartakass.AddLocation(LocationEnum.TheGreatCatapult, "21").BindLocations(Settlement.Harmonia);
            DomainEnum.Kartakass.AddLocation(LocationEnum.JailHouseHarmonia, "22-25").BindLocations(Settlement.Harmonia).BindCharacters(CharacterEnum.Kahrus, CharacterEnum.Devon, CharacterEnum.Bakki, CharacterEnum.JaconosHanabara).BindCreatures(Creature.Werewolf);
            DomainEnum.Kartakass.AddLocation(LocationEnum.TheAlleyHarmonia, "26-27").BindLocations(Settlement.Harmonia).BindCharacters(DarklordEnum.HarkonLukas, CharacterEnum.Akriel).BindCreatures(Creature.DireWolf);

            DomainEnum.Kartakass.AddLocation(LocationEnum.MariaFarm, "28-29").BindLocations(LocationEnum.RoadToHarmony).BindCharacters(CharacterEnum.Maria, CharacterEnum.Ontosh, CharacterEnum.Frantosh, CharacterEnum.Jelena, CharacterEnum.Joshua).BindItems(ItemEnum.Plant.Woflsbane);
            DomainEnum.Kartakass.AddLocation(LocationEnum.JackquesFarm, "28-29").BindLocations(LocationEnum.RoadToHarmony).BindCharacters(CharacterEnum.Jackques, CharacterEnum.Maria, CharacterEnum.Ontosh, CharacterEnum.Frantosh, CharacterEnum.Jelena).BindItems(ItemEnum.OilOfFieryBurning).BindCreatures(Creature.Wolf);

            DomainEnum.Kartakass.AddLocation(LocationEnum.SingSong, "30").BindLocations(Settlement.Skald).BindCreatures(Creature.Trout, Creature.Salmon);
            DomainEnum.Kartakass.AddLocation(LocationEnum.TheCauldron, "30, 35, 38, 43").BindLocations(Settlement.Skald, LocationEnum.SingSong).ExtraInfo = "Bottom of a waterfall";
            DomainEnum.Kartakass.AddLocation(LocationEnum.GundarRoad, "30, 32").BindLocations(Settlement.Skald).BindDomains(DomainEnum.Gundarak);
            DomainEnum.Kartakass.AddLocation(LocationEnum.PeasantsWay, "30").BindLocations(Settlement.Skald).BindDomains(DomainEnum.Sithicus);
            DomainEnum.Kartakass.AddLocation(LocationEnum.DireCreek, "30, 32").BindLocations(Settlement.Skald, LocationEnum.SingSong);
            DomainEnum.Kartakass.AddLocation(LocationEnum.ClockTowerMill, "30").BindLocations(Settlement.Skald, LocationEnum.TheCauldron, LocationEnum.SingSong).BindCharacters(CharacterEnum.MadamLupapus);
            DomainEnum.Kartakass.AddLocation(LocationEnum.MillHouseSkald, "30").BindLocations(Settlement.Skald);
            DomainEnum.Kartakass.AddLocation(LocationEnum.MeistersingerKeep, "30-31").BindLocations(Settlement.Skald).BindCreatures(Creature.Sheep);
            DomainEnum.Kartakass.AddLocation(LocationEnum.OldFortress, "31-32, 34").BindLocations(Settlement.Skald);
            DomainEnum.Kartakass.AddLocation(LocationEnum.OutTown, "31-32").BindLocations(Settlement.Skald);
            DomainEnum.Kartakass.AddLocation(LocationEnum.TheWharvesSkald, "32").BindLocations(Settlement.Skald, LocationEnum.SingSong).BindCreatures(Creature.Trout, Creature.Salmon);
            DomainEnum.Kartakass.AddLocation(LocationEnum.LowerSkald, "32").BindLocations(Settlement.Skald);
            DomainEnum.Kartakass.AddLocation(LocationEnum.SkaldSawMill, "32-33").BindLocations(Settlement.Skald, LocationEnum.SingSong).BindCreatures(Creature.Wolfwere);
            DomainEnum.Kartakass.AddLocation(LocationEnum.LowerTollBridge, "33").BindLocations(Settlement.Skald, LocationEnum.SingSong, LocationEnum.LowerIsland);
            DomainEnum.Kartakass.AddLocation(LocationEnum.LowerIsland, "33").BindLocations(Settlement.Skald, LocationEnum.SingSong);
            DomainEnum.Kartakass.AddLocation(LocationEnum.UpperTollBridge, "33").BindLocations(Settlement.Skald, LocationEnum.SingSong, LocationEnum.UpperIsland);
            DomainEnum.Kartakass.AddLocation(LocationEnum.UpperIsland, "33").BindLocations(Settlement.Skald, LocationEnum.SingSong);
            DomainEnum.Kartakass.AddLocation(LocationEnum.HighWharves, "33").BindLocations(Settlement.Skald, LocationEnum.SingSong).BindCharacters(CharacterEnum.Akriel);
            DomainEnum.Kartakass.AddLocation(LocationEnum.UpperSkald, "34").BindLocations(Settlement.Skald);
            DomainEnum.Kartakass.AddLocation(LocationEnum.GrandHallOfSongAndDance, "34").BindLocations(Settlement.Skald);
            DomainEnum.Kartakass.AddLocation(LocationEnum.OldShacks, "34").BindLocations(Settlement.Skald).BindCreatures(Creature.Wolfwere).BindItems(ItemEnum.Food.Meekulbern);

            DomainEnum.Kartakass.AddLocation(LocationEnum.KartakanInn, "1, 8, 16, 27, 30, 35-45, 65")
                .BindItems(ItemEnum.Drink.Meekulbrau, ItemEnum.Potion.ExtraHeal, ItemEnum.DaggerOfVenom, ItemEnum.HarkonHarp, ItemEnum.HarkonChess, ItemEnum.PipesOfPain, ItemEnum.LordsCoach)
                .BindCreatures(Creature.Wolfwere, Creature.GreaterWolfwere, Creature.Werefox, Creature.Werewolf, Creature.LoupGarou, Creature.MountainLoupGarou, Creature.LowlandLoupGarou, Creature.Mimic, Creature.Horse)
                .BindLocations(Settlement.Skald, LocationEnum.TheCauldron, LocationEnum.SingSong)
                .BindCharacters(DarklordEnum.HarkonLukas, CharacterEnum.Akriel, CharacterEnum.Coraline, CharacterEnum.HeinstockBeeterLupock, CharacterEnum.HaldrakeMoonbaun, CharacterEnum.Ledalar, CharacterEnum.Gleeda, CharacterEnum.Teena)
                .ExtraInfo = "Also known as The Inn of Kartakass, The Great Inn, The Inn, Bard's Home, The Old Inn, and the Lord's House.";

            DomainEnum.Kartakass.AddLocation(LocationEnum.CatacombsOfRadaga, "27, 29, 46-64")
                .BindItems(ItemEnum.Plant.Woflsbane, ItemEnum.EyesOfTheEagle, ItemEnum.Plant.Nightblight, ItemEnum.StoneOfDeath, ItemEnum.CrownOfSouls)
                .BindCharacters(DarklordEnum.Radaga).BindDomains(DomainEnum.Bluetspur)
                .BindCreatures(Creature.Quickwood, Creature.Goblyn, Creature.Skeleton, Creature.Zombie, Creature.JujuZombie, Creature.GiantSkeleton, Creature.Leucrotta, Creature.GiantRaven, Creature.GiantCrow, Creature.Kampfult, Creature.FireLizardSkeleton, Creature.GiantCentipede, Creature.Bat, Creature.SoulBeckoner, Creature.GiantSpider, Creature.CrawlingClaw, Creature.UndeadBeast, Creature.Heucuva, Creature.WarriorSkeleton, Creature.Swordwraith);
            DomainEnum.Kartakass.AddLocation(LocationEnum.ArkaliasHill, "51").BindLocations(LocationEnum.CatacombsOfRadaga);

            DomainEnum.Gundarak.AddLocation(LocationEnum.DrDominianiKeep, "4, 8-9, 65").BindCharacters(DarklordEnum.Dominiani);
            #endregion
        }
    }
}