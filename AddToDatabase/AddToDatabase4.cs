using static Factory;

internal static partial class AddToDatabase
{
    public static void Add4()
    {
        AddFeastOfGoblyns();
        AddShipOfHorrors();
        AddMonstrousCompendiumAppendix1();
        AddDarklords();
        AddBookOfCrypts();
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
            DomainEnum.Kartakass.Appeared("1-2, 5, 8, 10-13, 18-65, 69, 81-82, 96").BindCreatures(Creature.Wolf, Creature.DireWolf, Creature.Worg, Creature.Werewolf, Creature.Wolfwere, Creature.WinterWolf, Creature.Kobold, Creature.Boar, Creature.Wereboar, Creature.Jackal, Creature.Jackalwere, Creature.Wight, Creature.Ghoul, Creature.Goblin, Creature.Leucrotta, Creature.Werefox, Creature.GreaterWolfwere, Creature.LoupGarou).BindLanguages(Language.Common);

            DomainEnum.Gundarak.Appeared("2, 4, 8, 11-13, 27, 30, 43-44, 65-81").BindCreatures(Creature.Rat, Creature.Bat, Creature.Wolf, Creature.Spider, Creature.Werewolf, Creature.Kobold, Creature.Goblin, Creature.Boar, Creature.Worg);

            DomainEnum.Daglan.Appeared("8, 11, 82-92")
                .BindItems(ItemEnum.Plant.GheeGrass, ItemEnum.Food.Ghee)
                .BindCreatures(Creature.Human, Creature.Doppelganger, Creature.Beetle, Creature.Lion, Creature.Goblyn, Creature.Bulette, Creature.Ankheg, Creature.Hyena, Creature.Weretiger, Creature.Jackal, Creature.Giant, Creature.Skeleton, Creature.GiantSkeleton, Creature.Heucuva, Creature.Ghoul, Creature.Ghast, Creature.Ghost, Creature.Wight, Creature.Wraith, Creature.Zombie, Creature.JujuZombie, Creature.Haunt, Creature.KnightHaunt, Creature.Shadow, Creature.Spectre, Creature.Revenant, Creature.Odem);

            DomainEnum.Bluetspur.Appeared("8, 10-11, 29, 37, 51, 82");
            DomainEnum.Sithicus.Appeared("11, 30, 82");
            DomainEnum.Barovia.Appeared("13");
            DomainEnum.Forlorn.Appeared("26");
            DomainEnum.InsideRavenloft.BindCreatures(Creature.Skeleton, Creature.Zombie, Creature.Ghoul, Creature.Shadow, Creature.Wight, Creature.Ghast, Creature.Wraith, Creature.Mummy, Creature.Spectre, Creature.Vampire, Creature.Ghost, Creature.Lich, Creature.Goblyn, Creature.Quickwood, Creature.GreaterWolfwere, Creature.Wolfwere);

            ClusterEnum.PreGCCore.BindDomains(DomainEnum.Kartakass, DomainEnum.Gundarak, DomainEnum.Daglan, DomainEnum.Bluetspur, DomainEnum.Sithicus, DomainEnum.Barovia, DomainEnum.Forlorn);
            #endregion

            #region Darklords
            DomainEnum.Kartakass.AddLivingDarklord(DarklordEnum.HarkonLukas, "1-3, 8-13, 16-19, 26-27, 29-30, 35, 37, 39-42, 44, 81").BindCreatures(Creature.Wolfwere, Creature.DireWolf).BindCloseBorder("Envelope the land in a region of sweet songs. Those who attempt to pass through the border will find themselves growing ever more fatigued. If they do not turn back, they will fall unconscious - only to awaken back in Kartakass.").BindLair(LocationEnum.KartakanInn);

            DomainEnum.Gundarak.AddLivingDarklord(DarklordEnum.LordGundar, "1, 8-9, 11-13, 26-27, 43, 75").BindCharacters(DarklordEnum.Dominiani).BindCreatures(Creature.Vampire).BindRelatedCreatures(Creature.Wolf);

            DomainEnum.Daglan.AddLivingDarklord(DarklordEnum.Radaga, "1, 3-4, 8, 11-12, 14, 46-47, 50, 53, 55-57, 81-83, 85-88, 92")
                .BindAlignment(Alignment.NE | Alignment.LE).BindDomains(DomainEnum.Kartakass).BindLair(LocationEnum.TowerOfMagic)
                .BindCreatures(Creature.Human, Creature.Wight)
                .BindRelatedCreatures(Creature.SkeletonSteed, Creature.Quickwood, Creature.Skeleton, Creature.Goblyn, Creature.GiantSkeleton, Creature.HalfWight)
                .BindCloseBorder("A ring of gobylns 20 creatures deep, constantly feasting on bodies of helpless victims of the border. Those who fly over this border are only temporarily safe as a detachment of goblyns will be sent to hunt them down and kill them");

            DomainEnum.Daglan.AddLivingDarklord(DarklordEnum.Daglan, "1, 11, 13-14, 81-85, 87, 92")
                .BindAlignment(Alignment.CE).BindRelatedCreatures(Creature.Darkenbeast)
                .BindCharacters(DarklordEnum.Radaga).BindLair(LocationEnum.TowerOfMagic);
            #endregion

            #region Characters
            DomainEnum.Gundarak.AddLivingCharacter(DarklordEnum.Dominiani, "1, 3-4, 8-9, 12-13, 26-27, 43, 65-81").BindAlignment(Alignment.CE).BindCreatures(Creature.Vampire).BindRelatedCreatures(Creature.Worg, Creature.Zombie, Creature.Gargoyle, Creature.Horse, Creature.Bat, Creature.LargeBat, Creature.Goblyn);
            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.Akriel, "1, 3-4, 8-9, 12-13, 16-18, 26-29, 37, 41-43, 65-67, 69-70, 75, 81").BindAlignment(Alignment.CE).BindCreatures(Creature.Wolfwere, Creature.Human, Creature.Wolf).BindCharacters(DarklordEnum.HarkonLukas, CharacterEnum.Kahrus, CharacterEnum.MeistersingerZhone);
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

            DomainEnum.Gundarak.AddLivingCharacter(CharacterEnum.Margaret, "69");
            DomainEnum.Gundarak.AddLivingCharacter(CharacterEnum.AnimatedCoffin, "78");

            DomainEnum.Daglan.AddLivingCharacter(CharacterEnum.HordockCann, "88-89");
            #endregion

            #region Items
            DomainEnum.InsideRavenloft.AddItem(ItemEnum.CrownOfSouls, "1, 4, 8-9, 11, 13-15, 26-27, 37, 50, 56, 63, 65, 69, 75-77, 81-83, 85, 87, 92").BindDomains(DomainEnum.Kartakass, DomainEnum.Gundarak, DomainEnum.Daglan).BindCharacters(DarklordEnum.Daglan, DarklordEnum.Radaga).BindCreatures(Creature.Human, Creature.Goblyn, Creature.Elf);
            DomainEnum.Daglan.AddItem(ItemEnum.Staff.Wither, "12, 89").BindCharacters(DarklordEnum.Radaga);
            DomainEnum.Kartakass.AddItem(ItemEnum.Drink.Meekulbrau, "17, 96").BindCreatures(Creature.GreaterWolfwere);
            DomainEnum.Kartakass.AddItem(ItemEnum.Food.Meekulbern, "34, 96").BindCreatures(Creature.GreaterWolfwere);
            DomainEnum.Kartakass.AddItem(ItemEnum.Plant.Woflsbane, "26, 28");
            DomainEnum.Kartakass.AddItem(ItemEnum.Oil.FieryBurning, "29").BindCharacters(CharacterEnum.Jackques);
            DomainEnum.Kartakass.AddItem(ItemEnum.Potion.ExtraHeal, "43").BindCharacters(CharacterEnum.Akriel);
            DomainEnum.Kartakass.AddItem(ItemEnum.DaggerOfVenom, "43").BindCharacters(DarklordEnum.HarkonLukas);
            DomainEnum.Kartakass.AddItem(ItemEnum.HarkonHarp, "43").BindCharacters(DarklordEnum.HarkonLukas);
            DomainEnum.Kartakass.AddItem(ItemEnum.HarkonChess, "43").BindCharacters(DarklordEnum.HarkonLukas);
            DomainEnum.Kartakass.AddItem(ItemEnum.PipesOfPain, "44").BindCharacters(DarklordEnum.HarkonLukas);
            DomainEnum.Kartakass.AddItem(ItemEnum.LordsCoach, "45").BindCharacters(DarklordEnum.HarkonLukas);
            DomainEnum.Kartakass.AddItem(ItemEnum.Plant.Nightblight, "51").BindCreatures(Creature.Vampire, Creature.Wolfwere, Creature.Werewolf);
            DomainEnum.Kartakass.AddItem(ItemEnum.StoneOfDeath, "53").BindCharacters(DarklordEnum.Radaga);

            DomainEnum.Gundarak.AddItem(ItemEnum.Oil.Timelessness, "67, 74, 79");
            DomainEnum.Gundarak.AddItem(ItemEnum.DominianiCursedHelm, "73").BindCharacters(DarklordEnum.Dominiani).BindCreatures(Creature.Wererat);
            DomainEnum.Gundarak.AddItem(ItemEnum.DominianiIncense, "73").BindCharacters(DarklordEnum.Dominiani);
            DomainEnum.Gundarak.AddItem(ItemEnum.Scroll.Return, "74").BindCharacters(DarklordEnum.Dominiani);
            DomainEnum.Gundarak.AddItem(ItemEnum.Book.LifeOrDeathAHistoryOfTCOS, "75").BindCharacters(DarklordEnum.Dominiani);
            DomainEnum.Gundarak.AddItem(ItemEnum.VampireSlayer, "75").ExtraInfo = "A dagger";
            DomainEnum.Gundarak.AddItem(ItemEnum.Ring.Impersonation, "81").BindCharacters(DarklordEnum.HarkonLukas);

            DomainEnum.Daglan.AddItem(ItemEnum.Plant.GheeGrass, "82");
            DomainEnum.Daglan.AddItem(ItemEnum.Food.Ghee, "82").ExtraInfo = "Staple food and feed in Daglan. Also used for baskets, rugs, furniture and small buildings when dried.";
            DomainEnum.Daglan.AddItem(ItemEnum.Cloak.Arachnida, "89");
            DomainEnum.Daglan.AddItem(ItemEnum.Cloak.Poison, "89");
            DomainEnum.Daglan.AddItem(ItemEnum.Potion.UndeadControl, "90");
            DomainEnum.Daglan.AddItem(ItemEnum.Book.VileDarkness, "90");
            DomainEnum.Daglan.AddItem(ItemEnum.CandleOfInvocation, "90");
            DomainEnum.Daglan.AddItem(ItemEnum.PipesOfHaunt, "90");
            DomainEnum.Daglan.AddItem(ItemEnum.SheetOfSmallness, "90");
            #endregion

            #region Groups
            DomainEnum.InsideRavenloft.AddGroup(GroupEnum.Vistani, "9, 26-27");
            DomainEnum.Kartakass.AddGroup(GroupEnum.Meistersinger, "10. 16-17").BindLocations(LocationEnum.MeistersingerDungeon, LocationEnum.MeistersingerKeep, LocationEnum.MeistersingerMansion);
            DomainEnum.InsideRavenloft.AddGroup(GroupEnum.DarkPowers, "11, 14");
            #endregion

            #region Settlements
            DomainEnum.Kartakass.AddSettlement(Settlement.Harmonia, "1, 6, 8, 10, 16-29, 32, 37").BindCreatures(Creature.Wolfwere, Creature.Sheep);
            DomainEnum.Kartakass.AddSettlement(Settlement.Skald, "1, 8-10, 16, 20, 27-28, 30-45, 65, 67, 81").BindCreatures(Creature.Wolfwere);
            DomainEnum.Gundarak.AddSettlement(Settlement.Teufeldorf, "69-70, 72, 79-80").BindCharacters(DarklordEnum.Dominiani);
            DomainEnum.Daglan.AddSettlement(Settlement.Homlock, "4, 8, 82-92")
                .BindCharacters(DarklordEnum.Radaga)
                .BindCreatures(Creature.Skeleton, Creature.Goblyn, Creature.Human);
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

            DomainEnum.Kartakass.AddLocation(LocationEnum.MariaFarm, "28-29, 87-88").BindLocations(LocationEnum.RoadToHarmony).BindCharacters(CharacterEnum.Maria, CharacterEnum.Ontosh, CharacterEnum.Frantosh, CharacterEnum.Jelena, CharacterEnum.Joshua).BindItems(ItemEnum.Plant.Woflsbane);
            DomainEnum.Kartakass.AddLocation(LocationEnum.JackquesFarm, "28-29, 87-88").BindLocations(LocationEnum.RoadToHarmony).BindCharacters(CharacterEnum.Jackques, CharacterEnum.Maria, CharacterEnum.Ontosh, CharacterEnum.Frantosh, CharacterEnum.Jelena).BindItems(ItemEnum.Oil.FieryBurning).BindCreatures(Creature.Wolf);

            DomainEnum.Kartakass.AddLocation(LocationEnum.SingSong, "30").BindLocations(Settlement.Skald).BindCreatures(Creature.Trout, Creature.Salmon);
            DomainEnum.Kartakass.AddLocation(LocationEnum.TheCauldron, "30, 35, 38, 43, 67").BindLocations(Settlement.Skald, LocationEnum.SingSong).ExtraInfo = "Bottom of a waterfall";
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

            DomainEnum.Kartakass.AddLocation(LocationEnum.KartakanInn, "1, 8, 16, 27, 30, 35-45, 65, 81")
                .BindItems(ItemEnum.Drink.Meekulbrau, ItemEnum.Potion.ExtraHeal, ItemEnum.DaggerOfVenom, ItemEnum.HarkonHarp, ItemEnum.HarkonChess, ItemEnum.PipesOfPain, ItemEnum.LordsCoach)
                .BindCreatures(Creature.Wolfwere, Creature.GreaterWolfwere, Creature.Werefox, Creature.Werewolf, Creature.LoupGarou, Creature.MountainLoupGarou, Creature.LowlandLoupGarou, Creature.Mimic, Creature.Horse)
                .BindLocations(Settlement.Skald, LocationEnum.TheCauldron, LocationEnum.SingSong)
                .BindCharacters(DarklordEnum.HarkonLukas, CharacterEnum.Akriel, CharacterEnum.Coraline, CharacterEnum.HeinstockBeeterLupock, CharacterEnum.HaldrakeMoonbaun, CharacterEnum.Ledalar, CharacterEnum.Gleeda, CharacterEnum.Teena)
                .ExtraInfo = "Also known as The Inn of Kartakass, The Great Inn, The Inn, Bard's Home, The Old Inn, and the Lord's House.";

            DomainEnum.Kartakass.AddLocation(LocationEnum.CatacombsOfRadaga, "27, 29, 46-64, 81-82")
                .BindItems(ItemEnum.Plant.Woflsbane, ItemEnum.EyesOfTheEagle, ItemEnum.Plant.Nightblight, ItemEnum.StoneOfDeath, ItemEnum.CrownOfSouls)
                .BindCharacters(DarklordEnum.Radaga).BindDomains(DomainEnum.Bluetspur)
                .BindCreatures(Creature.Quickwood, Creature.Goblyn, Creature.Skeleton, Creature.Zombie, Creature.JujuZombie, Creature.GiantSkeleton, Creature.Leucrotta, Creature.GiantRaven, Creature.GiantCrow, Creature.Kampfult, Creature.FireLizardSkeleton, Creature.GiantCentipede, Creature.Bat, Creature.SoulBeckoner, Creature.GiantSpider, Creature.CrawlingClaw, Creature.UndeadBeast, Creature.Heucuva, Creature.WarriorSkeleton, Creature.Swordwraith);
            DomainEnum.Kartakass.AddLocation(LocationEnum.ArkaliasHill, "51").BindLocations(LocationEnum.CatacombsOfRadaga);

            DomainEnum.Gundarak.AddLocation(LocationEnum.DrDominianiKeep, "4, 8-9, 65-81")
                .BindCharacters(DarklordEnum.Dominiani, CharacterEnum.Margaret, CharacterEnum.AnimatedCoffin)
                .BindItems(ItemEnum.Oil.Timelessness, ItemEnum.DominianiCursedHelm, ItemEnum.DominianiIncense, ItemEnum.Scroll.Return, ItemEnum.Book.LifeOrDeathAHistoryOfTCOS, ItemEnum.VampireSlayer)
                .BindCreatures(Creature.Gargoyle, Creature.Horse, Creature.Bat, Creature.LargeBat, Creature.Beetle, Creature.Spider, Creature.Rat, Creature.Snake, Creature.RotGrub, Creature.Zombie, Creature.JujuZombie, Creature.Shadow, Creature.Goblyn, Creature.Human, Creature.CrawlingClaw);

            DomainEnum.Daglan.AddLocation(LocationEnum.HomlockChurch, "83-85, 87-91")
                .BindItems(ItemEnum.Staff.Wither, ItemEnum.Cloak.Arachnida, ItemEnum.Cloak.Poison, ItemEnum.Potion.UndeadControl, ItemEnum.Book.VileDarkness, ItemEnum.CandleOfInvocation, ItemEnum.PipesOfHaunt, ItemEnum.SheetOfSmallness)
                .BindLocations(Settlement.Homlock).BindCharacters(DarklordEnum.Radaga, CharacterEnum.HordockCann)
                .BindCreatures(Creature.Zombie, Creature.Goblyn, Creature.CrawlingClaw, Creature.GiantSkeleton, Creature.Human, Creature.Elf, Creature.Cloaker, Creature.GiantSpider, Creature.HalfWight, Creature.Skeleton, Creature.Doppelganger, Creature.Darkenbeast, Creature.Beetle, Creature.Ghoul, Creature.Ghast, Creature.DeathSkull);
            DomainEnum.Daglan.AddLocation(LocationEnum.TowerOfMagic, "83-84, 86")
                .BindLocations(Settlement.Homlock).BindCharacters(DarklordEnum.Radaga, DarklordEnum.Daglan);
            DomainEnum.Daglan.AddLocation(LocationEnum.BarrowMounds, "83-84, 86")
                .BindLocations(Settlement.Homlock).BindCreatures(Creature.Goblyn, Creature.Spectre);
            DomainEnum.Daglan.AddLocation(LocationEnum.HomlockCemetery, "84, 86-87")
                .BindLocations(Settlement.Homlock).BindCreatures(Creature.Ghoul, Creature.Ghast);
            #endregion
        }
        void AddShipOfHorrors()
        {
            var releaseDate = "01/02/1991";
            string ExtraInfo = "<br/>&emsp;Designed: Anne Brown";
            ExtraInfo += "<br/>&emsp;Edited: Mike Breault";
            ExtraInfo += "<br/>&emsp;Cover Art: Clyde Caldwell";
            ExtraInfo += "<br/>&emsp;Interior Art: Stephen Fabian";
            ExtraInfo += "<br/>&emsp;Graphic Design: Roy E. Parker";
            ExtraInfo += "<br/>&emsp;Cartography: Karen Wynn Fonstad";
            ExtraInfo += "<br/>&emsp;Typesetting: Angelika Lokotz";
            ExtraInfo += "<br/>&emsp;Production: Paul Hanchette";
            ExtraInfo += "<br/>&emsp;Module Info: An adventure for characters of levels";
            using var ctx = CreateSource("Feast of Goblyns", releaseDate, ExtraInfo, Edition.e2, Media.module);

            #region Domains
            DomainEnum.Nebligtode.Appeared().BindCreatures(Creature.SeaGull, Creature.Porpoise, Creature.Dolphin, Creature.Ghost, Creature.SkeletalShark, Creature.GiantStarfish, Creature.Vodyanoi);
            DomainEnum.InsideRavenloft.BindCreatures(Creature.Lebendtod, Creature.SnowGolem);
            DomainEnum.Lamordia.Appeared("42");
            DomainEnum.SeaOfSorrows.Appeared("42");
            #endregion

            #region Characters
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Garvyn, "5-6, 8, 10-11, 14-19, 22, 24, 26-28, 37-42, 49, 52-53, 61").BindAlignment(Alignment.CN);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Killian, "6");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Brummett, "10, 12, 19-22, 26, 28").BindAlignment(Alignment.CG);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.CharlotteReisland, "12, 23-24, 28, 37-39, 41, 47").BindCreatures(Creature.Ghost);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Ralfeo, "12-13, 23").BindAlignment(Alignment.NG);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Koresh, "13").BindAlignment(Alignment.CN);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Peregrine, "13").BindAlignment(Alignment.NG);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Thorvid, "13").BindAlignment(Alignment.NG);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Jacob, "21, 24, 37-42, 44-45, 47, 52-53");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Basil, "21");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Hugo, "27-28");

            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Vathan, "17").BindGroups(GroupEnum.Vistani, GroupEnum.VincenziaVistani);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Saul, "17").BindGroups(GroupEnum.Vistani, GroupEnum.VincenziaVistani);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Vincenzia, "17-19, 48-49").BindGroups(GroupEnum.Vistani, GroupEnum.Raunie, GroupEnum.VincenziaVistani);

            DomainEnum.Nebligtode.AddLivingDarklord(DarklordEnum.Meredoth, "2, 35, 52-53, 57-63").BindLair(LocationEnum.TodsteinMausoleums).BindRelatedCreatures(Creature.Skeleton).BindCloseBorder("Generate such turbulence in the waters that they become impassable. Fifty-foot waves and mile-wide whirlpools ensure that those within do not escape with their lives.");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.MadelineStern, "28, 37-38, 41-42, 44, 47").BindCharacters(CharacterEnum.Morvan).BindCreatures(Creature.Ghost);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Morvan, "37");

            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.KarlReisland, "39").BindCharacters(CharacterEnum.CharlotteReisland);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.LouisaReisland, "39").BindCharacters(CharacterEnum.CharlotteReisland);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Graben, "2, 39-40");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.HorstGraben, "40").BindCharacters(CharacterEnum.Jacob);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.LucretiaGraben, "41").BindCharacters(CharacterEnum.MadelineStern);

            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.MiriamBrote, "45");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.HarvidFleischer, "45");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Jeremiah, "45");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.MargaretAckerman, "45, 47");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.HiramAckerman, "45, 47");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.PieterFischer, "45-46");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.LarsStromm, "46");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.BarnabasVincent, "46");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.HansMueller, "46");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.MarcusGwynn, "47");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.VanceStellen, "47");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.ColinGraben, "49-53");

            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.EzekielGraben, "50").BindCharacters(CharacterEnum.MariettaGraben, CharacterEnum.MatthiasGraben, CharacterEnum.DanarGraben, CharacterEnum.MetanGraben, CharacterEnum.KuganGraben, CharacterEnum.GeneelGraben, CharacterEnum.MavisGraben);
            DomainEnum.Nebligtode.AddDeadCharacter(CharacterEnum.MatthiasGraben, "50").BindCharacters(CharacterEnum.ColinGraben);
            DomainEnum.Nebligtode.AddDeadCharacter(CharacterEnum.DanarGraben, "50");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.MetanGraben, "50");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.KuganGraben, "50");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.GeneelGraben, "50");
            DomainEnum.Nebligtode.AddDeadCharacter(CharacterEnum.MavisGraben, "50");

            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.MariettaGraben, "50-51").BindCharacters(CharacterEnum.DriddamGraben, CharacterEnum.StymarGraben, CharacterEnum.ArabyGraben, CharacterEnum.ElenaGraben, CharacterEnum.RosaleeGraben);
            DomainEnum.Nebligtode.AddDeadCharacter(CharacterEnum.DriddamGraben, "50-51").BindCharacters(CharacterEnum.BlaineGraben);
            DomainEnum.Nebligtode.AddDeadCharacter(CharacterEnum.StymarGraben, "50");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.ArabyGraben, "50").ExtraInfo = "Never seen again.";
            DomainEnum.Nebligtode.AddDeadCharacter(CharacterEnum.ElenaGraben, "50").BindCharacters(CharacterEnum.Nestor, CharacterEnum.OlsainGraben, CharacterEnum.LucretiaGraben);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.RosaleeGraben, "50");

            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.BlaineGraben, "51");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Nestor, "51").BindCharacters(CharacterEnum.OlsainGraben, CharacterEnum.LucretiaGraben);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.OlsainGraben, "51");
            #endregion

            #region Items
            DomainEnum.Nebligtode.AddItem(ItemEnum.ClaraTheDoll, "22-23").BindCharacters(CharacterEnum.CharlotteReisland);
            DomainEnum.Nebligtode.AddItem(ItemEnum.Potion.ExtraHeal, "60").BindCharacters(DarklordEnum.Meredoth).BindLocations(LocationEnum.TodsteinMausoleums);
            DomainEnum.Nebligtode.AddItem(ItemEnum.Cloak.Prot, "62").BindCharacters(DarklordEnum.Meredoth).BindLocations(LocationEnum.TodsteinMausoleums);
            DomainEnum.Nebligtode.AddItem(ItemEnum.BracersOfDefense, "62").BindCharacters(DarklordEnum.Meredoth).BindLocations(LocationEnum.TodsteinMausoleums);
            DomainEnum.Nebligtode.AddItem(ItemEnum.Potion.FireRes, "62").BindCharacters(DarklordEnum.Meredoth).BindLocations(LocationEnum.TodsteinMausoleums);
            DomainEnum.Nebligtode.AddItem(ItemEnum.Potion.Speed, "62").BindCharacters(DarklordEnum.Meredoth).BindLocations(LocationEnum.TodsteinMausoleums);
            DomainEnum.Nebligtode.AddItem(ItemEnum.Ring.Shoot, "62").BindCharacters(DarklordEnum.Meredoth).BindLocations(LocationEnum.TodsteinMausoleums);
            DomainEnum.Nebligtode.AddItem(ItemEnum.Rod.Smite, "62").BindCharacters(DarklordEnum.Meredoth).BindLocations(LocationEnum.TodsteinMausoleums);
            DomainEnum.Nebligtode.AddItem(ItemEnum.Staff.TheSerpent, "62").BindCharacters(DarklordEnum.Meredoth).BindLocations(LocationEnum.TodsteinMausoleums);
            DomainEnum.Nebligtode.AddItem(ItemEnum.Wand.FlameExtinguish, "62").BindCharacters(DarklordEnum.Meredoth).BindLocations(LocationEnum.TodsteinMausoleums);
            DomainEnum.Nebligtode.AddItem(ItemEnum.BagOfHolding, "62").BindCharacters(DarklordEnum.Meredoth).BindLocations(LocationEnum.TodsteinMausoleums);
            DomainEnum.Nebligtode.AddItem(ItemEnum.FoldingBoat, "62").BindCharacters(DarklordEnum.Meredoth).BindLocations(LocationEnum.TodsteinMausoleums);
            DomainEnum.Nebligtode.AddItem(ItemEnum.SnowshoesOfVariedTracks, "62").BindCharacters(DarklordEnum.Meredoth).BindLocations(LocationEnum.TodsteinMausoleums);
            DomainEnum.Nebligtode.AddItem(ItemEnum.BroomOfFlying, "62").BindCharacters(DarklordEnum.Meredoth).BindLocations(LocationEnum.TodsteinMausoleums);
            DomainEnum.Nebligtode.AddItem(ItemEnum.Decanter, "62").BindCharacters(DarklordEnum.Meredoth).BindLocations(LocationEnum.TodsteinMausoleums);
            DomainEnum.Nebligtode.AddItem(ItemEnum.HatOfStupid, "62").BindCharacters(DarklordEnum.Meredoth).BindLocations(LocationEnum.TodsteinMausoleums);
            #endregion

            #region Locations
            DomainEnum.Nebligtode.AddLocation(LocationEnum.TheEndurance, "2, 6-28, 34, 37-41, 48, 52, 55, 61, Map").BindCharacters(CharacterEnum.Garvyn, CharacterEnum.Killian, CharacterEnum.Brummett, CharacterEnum.Ralfeo, CharacterEnum.Koresh, CharacterEnum.Peregrine, CharacterEnum.Thorvid, CharacterEnum.Jacob, CharacterEnum.Basil, CharacterEnum.Hugo, CharacterEnum.CharlotteReisland, CharacterEnum.MadelineStern);
            DomainEnum.Nebligtode.AddLocation(LocationEnum.GrabenIsland, "2, 39-40, 42-44, 61").BindGroups(GroupEnum.Graben).BindCreatures(Creature.Chicken, Creature.GroundSquirrel, Creature.PrarieDog, Creature.Pheasant, Creature.Quail, Creature.Partridge, Creature.Otter, Creature.Beaver, Creature.Snake, Creature.Frog, Creature.Owl, Creature.Bear, Creature.Wolf, Creature.Cougar, Creature.Rabbit, Creature.Squirrel, Creature.Sheep, Creature.Goat);

            DomainEnum.Nebligtode.AddLocation(LocationEnum.Todstein, "2, 38-40, 42, 49, 52-61").BindCreatures(Creature.SnowshoeHare, Creature.Wolf, Creature.Ptarmigan);

            DomainEnum.Nebligtode.AddSettlement(Settlement.Graben, "2, 43-45, 54").BindGroups(GroupEnum.Graben)
                .BindCreatures(Creature.Sheep, Creature.Goat)
                .BindLocations(LocationEnum.GrabenIsland, LocationEnum.GrabenFamilyEstate, LocationEnum.GrabenBakery, LocationEnum.GrabenButcher, LocationEnum.GrabenCooper, LocationEnum.GrabenCottonSpinner, LocationEnum.GrabenFishMarket, LocationEnum.GrabenGeneralStore, LocationEnum.BlackSheepInn, LocationEnum.GrabenMill, LocationEnum.GrabenWeaver, LocationEnum.GrabenWoolSpinner, LocationEnum.GrabenCemetery);

            DomainEnum.Nebligtode.AddLocation(LocationEnum.EternalTorture, "25-26").BindCreatures(Creature.Ghast);

            DomainEnum.Nebligtode.AddLocation(LocationEnum.GrabenFamilyEstate, "43, 45, 49-53")
                .BindGroups(GroupEnum.Graben).BindCreatures(Creature.Sheep, Creature.Goat, Creature.Cow, Creature.Horse)
                .BindCharacters(CharacterEnum.HorstGraben, CharacterEnum.LucretiaGraben, CharacterEnum.ColinGraben, CharacterEnum.EzekielGraben, CharacterEnum.MariettaGraben, CharacterEnum.MatthiasGraben, CharacterEnum.DanarGraben, CharacterEnum.MetanGraben, CharacterEnum.KuganGraben, CharacterEnum.GeneelGraben, CharacterEnum.MavisGraben, CharacterEnum.DriddamGraben, CharacterEnum.StymarGraben, CharacterEnum.ArabyGraben, CharacterEnum.ElenaGraben, CharacterEnum.RosaleeGraben, CharacterEnum.BlaineGraben, CharacterEnum.Nestor, CharacterEnum.OlsainGraben);

            DomainEnum.Nebligtode.AddSettlement(Settlement.Seeheim, "43").BindLocations(LocationEnum.GrabenIsland);
            DomainEnum.Nebligtode.AddSettlement(Settlement.Kirchenheim, "43").BindLocations(LocationEnum.GrabenIsland);

            DomainEnum.Nebligtode.AddLocation(LocationEnum.KnammenIsland, "43");
            DomainEnum.Nebligtode.AddSettlement(Settlement.Meerdorf, "43").BindLocations(LocationEnum.KnammenIsland);

            DomainEnum.Nebligtode.AddLocation(LocationEnum.GrabenBakery, "45").BindCharacters(CharacterEnum.MiriamBrote);
            DomainEnum.Nebligtode.AddLocation(LocationEnum.GrabenButcher, "45").BindCharacters(CharacterEnum.HarvidFleischer).BindCreatures(Creature.Goat, Creature.Sheep, Creature.Chicken);
            DomainEnum.Nebligtode.AddLocation(LocationEnum.GrabenCooper, "45").BindCharacters(CharacterEnum.Jacob, CharacterEnum.Jeremiah);
            DomainEnum.Nebligtode.AddLocation(LocationEnum.GrabenCottonSpinner, "45, 47").BindCharacters(CharacterEnum.MargaretAckerman, CharacterEnum.HiramAckerman);
            DomainEnum.Nebligtode.AddLocation(LocationEnum.GrabenFishMarket, "45-46").BindCharacters(CharacterEnum.PieterFischer);
            DomainEnum.Nebligtode.AddLocation(LocationEnum.GrabenGeneralStore, "46").BindCharacters(CharacterEnum.LarsStromm);
            DomainEnum.Nebligtode.AddLocation(LocationEnum.BlackSheepInn, "46").BindCharacters(CharacterEnum.BarnabasVincent);
            DomainEnum.Nebligtode.AddLocation(LocationEnum.GrabenMill, "46").BindCharacters(CharacterEnum.HansMueller);
            DomainEnum.Nebligtode.AddLocation(LocationEnum.GrabenWeaver, "47").BindCharacters(CharacterEnum.MarcusGwynn);
            DomainEnum.Nebligtode.AddLocation(LocationEnum.GrabenWoolSpinner, "47").BindCharacters(CharacterEnum.VanceStellen);
            DomainEnum.Nebligtode.AddLocation(LocationEnum.GrabenCemetery, "47-48");
            DomainEnum.Nebligtode.AddLocation(LocationEnum.TodsteinMausoleums, "35, 54-61").BindLocations(LocationEnum.Todstein).BindCreatures(Creature.SnowGolem, Creature.Skeleton, Creature.Squirrel, Creature.Rabbit, Creature.Ferret, Creature.Chipmunk, Creature.HouseCat, Creature.Opossum, Creature.Monkey, Creature.Dog, Creature.Sheep, Creature.Pig, Creature.Goat, Creature.Panther, Creature.Cheetah, Creature.Wolf, Creature.Coyote, Creature.Mule, Creature.Boar, Creature.Badger, Creature.Kangaroo, Creature.Bear, Creature.Moose, Creature.Horse, Creature.Lion, Creature.Elephant);
            #endregion

            #region Groups
            DomainEnum.InsideRavenloft.AddGroup(GroupEnum.Vistani, "17-19, 48-49").BindDomains(DomainEnum.Nebligtode);
            DomainEnum.InsideRavenloft.AddGroup(GroupEnum.VincenziaVistani, "17-19, 48-49").BindDomains(DomainEnum.Nebligtode);
            DomainEnum.Nebligtode.AddGroup(GroupEnum.EnduranceCrew).BindCharacters(CharacterEnum.Garvyn, CharacterEnum.Killian, CharacterEnum.Brummett, CharacterEnum.Ralfeo, CharacterEnum.Koresh, CharacterEnum.Peregrine, CharacterEnum.Thorvid, CharacterEnum.Basil, CharacterEnum.Hugo);
            DomainEnum.Nebligtode.AddGroup(GroupEnum.Graben, "2, 40, 42-47, 49-52").BindCharacters(CharacterEnum.HorstGraben, CharacterEnum.LucretiaGraben, CharacterEnum.ColinGraben, CharacterEnum.EzekielGraben, CharacterEnum.MariettaGraben, CharacterEnum.MatthiasGraben, CharacterEnum.DanarGraben, CharacterEnum.MetanGraben, CharacterEnum.KuganGraben, CharacterEnum.GeneelGraben, CharacterEnum.MavisGraben, CharacterEnum.DriddamGraben, CharacterEnum.StymarGraben, CharacterEnum.ArabyGraben, CharacterEnum.ElenaGraben, CharacterEnum.RosaleeGraben, CharacterEnum.BlaineGraben, CharacterEnum.Nestor, CharacterEnum.OlsainGraben);
            #endregion

            Creature.Lebendtod.BindCreatures(Creature.Ghast);
        }
        void AddMonstrousCompendiumAppendix1()
        {
            var releaseDate = "01/01/1991";
            string ExtraInfo = "<br/>&emsp;Designer: William W. Connors";
            ExtraInfo += "<br/>&emsp;Editing: C. Terry Phillips";
            ExtraInfo += "<br/>&emsp;Cover Art: Jeff Easley";
            ExtraInfo += "<br/>&emsp;Interior Art: Tom Baxa";
            ExtraInfo += "<br/>&emsp;Typesetting: Tracey Zamagne";
            ExtraInfo += "<br/>&emsp;Production: Sarah Feggestad";
            using var ctx = CreateSource("Ravenloft Monstrous Compendium Appendix I", releaseDate, ExtraInfo, Edition.e2, Media.sourcebook);

            DomainEnum.InsideRavenloft.BindCreatures(Creature.Bat, Creature.LargeBat, Creature.GiantBat, Creature.HugeBat, Creature.Mobat, Creature.CarrionCrawler, Creature.Doppelganger, Creature.Drow, Creature.Gargoyle, Creature.Ghost, Creature.Ghoul, Creature.Lacedeon, Creature.Ghast, Creature.FleshGolem, Creature.ClayGolem, Creature.StoneGolem, Creature.IronGolem, Creature.Banshee, Creature.GroaningSpirit, Creature.GuardianDaemonLeast, Creature.GuardianDaemonLesser, Creature.GuardianDaemonGreater, Creature.AnnisHag, Creature.GreenHag, Creature.SeaHag, Creature.Haunt, Creature.Hellhound, Creature.Heucuva, Creature.Homunculus, Creature.Imp, Creature.Jackalwere, Creature.Lich, Creature.Demilich, Creature.Werefox, Creature.Wererat, Creature.Werewolf, Creature.MindFlayer, Creature.Mummy, Creature.Poltergeist, Creature.Rakshasa, Creature.Rat, Creature.GiantRat, Creature.Shadow, Creature.Skeleton, Creature.Spectre, Creature.Vampire, Creature.JiangShi, Creature.Wight, Creature.WillOWisp, Creature.Wolf, Creature.Worg, Creature.DireWolf, Creature.WinterWolf, Creature.Wolfwere, Creature.Wraith, Creature.Zombie, Creature.JujuZombie, Creature.CrawlingClaw, Creature.Cloaker, Creature.Darkenbeast, Creature.CrimsonDeath, Creature.Revenant, Creature.LivingWeb, Creature.UndeadBeast, Creature.UndeadBeastStahnk, Creature.UndeadBeastStahnk, Creature.Dreamshadow, Creature.Dreamwraith, Creature.Fetch, Creature.FireMinion, Creature.FireShadow, Creature.KnightHaunt, Creature.SpectralMinion, Creature.WarriorSkeleton, Creature.Wichtlin, Creature.Yaggol, Creature.CryptThing, Creature.YethHound, Creature.SonOfKyuss, Creature.Necrophidius, Creature.Raven, Creature.GiantRaven, Creature.Scarecrow, Creature.SlowShadow, Creature.Swordwraith, Creature.SoulBeckoner, Creature.SeaZombie, Creature.TigbanuaBuso, Creature.TagamalingBuso, Creature.ChuU, Creature.ConTinh, Creature.JikiKetsuGaki, Creature.JikiNikuGaki, Creature.ShikkiGaki, Creature.ShinenGaki, Creature.GoblinRat, Creature.GoblinSpider, Creature.Hannya, Creature.FoxHengeyokai, Creature.RacoonDogHengeyokai, Creature.RatHengeyokai, Creature.HuHsien, Creature.Ikiryo, Creature.Kaluk, Creature.Krakentua, Creature.Kuei, Creature.Memedi, Creature.Gaki, Creature.Hengeyokai, Creature.Oni, Creature.CommonOni, Creature.GoZuOni, Creature.MeZuOni, Creature.GoheiPOh, Creature.StoneSpirit, Creature.YukiOnNa, Creature.AncientMariner, Creature.Spiritjam, Creature.Baatezu, Creature.Abishai, Creature.Spinagon, Creature.Barbazu, Creature.Erinyes, Creature.Hamatula, Creature.Nupperibo, Creature.PitFiend, Creature.Amnizu, Creature.Gelugon, Creature.Osyluth, Creature.Lemure, Creature.Bebilith, Creature.Bodak, Creature.Gehreleth, Creature.Gith, Creature.Githyanki, Creature.Githzerai, Creature.Hordling, Creature.NightHag, Creature.Nightmare, Creature.TanarRi, Creature.Babau, Creature.Chasme, Creature.Nabassu, Creature.Molydeus, Creature.Dretch, Creature.Manes, Creature.Rutterkin, Creature.AluFiend, Creature.Barlgura, Creature.Cambion, Creature.Succubus, Creature.Balor, Creature.Glabrezu, Creature.Hezrou, Creature.Marilith, Creature.Nalfeshnee, Creature.Vrock, Creature.Vaporighu, Creature.Yugoloth, Creature.Arcanaloth, Creature.Nycaloth, Creature.Ultroloth, Creature.Dergholoth, Creature.Hydroloth, Creature.Mezzoloth, Creature.Piscoloth, Creature.Yagnoloth, Creature.Allura, Creature.Dreamslayer, Creature.Dweomerborn, Creature.Firelich, Creature.Skullbird, Creature.SpiritWarrior, Creature.StellarUndead, Creature.SentinelBat, Creature.SkeletalBat, Creature.Bowlyn, Creature.BrokenOne, Creature.Bussengeist, Creature.DoomGuard, Creature.DopplegangerPlant, Creature.Podling, Creature.RavenloftElemental, Creature.PyreElemental, Creature.BloodElemental, Creature.MistElemental, Creature.GraveElemental, Creature.GhoulLord, Creature.Goblyn, Creature.RavenloftGolem, Creature.BoneGolem, Creature.DollGolem, Creature.GargoyleGolem, Creature.GlassGolem, Creature.MechanicalGolem, Creature.GrimReaper, Creature.AssassinImp, Creature.Impersonator, Creature.Werebat, Creature.Wereraven, Creature.MistHorror, Creature.WanderingHorror, Creature.GreaterMummy, Creature.Quevari, Creature.Quickwood, Creature.Ravenkin, Creature.RavenloftScarecrow, Creature.ShadowDemon, Creature.GiantSkeleton, Creature.Treant, Creature.AnimatedTree, Creature.UndeadTreant, Creature.Valpurgeist, Creature.Dwarf, Creature.Vampire, Creature.Elf, Creature.Gnome, Creature.Halfling, Creature.Kender, Creature.Vampyre, Creature.RedWidow, Creature.GreaterWolfwere, Creature.ZombieLord);

            DarklordEnum.IvanaBoritsi.BindRelatedCreatures(Creature.Ermordenung);
            DomainEnum.Borca.Appeared().BindCreatures(Creature.Ermordenung);
            DomainEnum.Borca.AddLivingDarklord(DarklordEnum.IvanaBoritsi);

            DomainEnum.Darkon.Appeared().AddLivingDarklord(DarklordEnum.AzalinRex);
            DarklordEnum.AzalinRex.BindRelatedCreatures(Creature.BoneGolem, Creature.ZombieGolem);

            DomainEnum.Barovia.Appeared().AddLivingDarklord(DarklordEnum.CountStrahd);
            DomainEnum.Barovia.BindCreatures(Creature.Skeleton, Creature.Zombie, Creature.StrahdSteed);
            DarklordEnum.CountStrahd.BindCreatures(Creature.Vampire).BindRelatedCreatures(Creature.Skeleton, Creature.Zombie, Creature.StrahdSteed);

            DomainEnum.Sanguinia.Appeared().BindCreatures(Creature.DollGolem);

            DarklordEnum.VladDrakov.BindRelatedCreatures(Creature.GargoyleGolem);
            DomainEnum.Falkovnia.Appeared().BindCreatures(Creature.GargoyleGolem);
            DomainEnum.Falkovnia.AddLivingDarklord(DarklordEnum.VladDrakov);

            DarklordEnum.Easen.BindRelatedCreatures(Creature.MechanicalGolem);
            DomainEnum.Vechor.Appeared().BindCreatures(Creature.MechanicalGolem);
            DomainEnum.Vechor.AddLivingDarklord(DarklordEnum.Easen);

            DomainEnum.NightmareLands.Appeared().BindCreatures(Creature.Human);
            DomainEnum.NightmareLands.AddGroup(GroupEnum.AbberNomad).BindCreatures(Creature.Human);

            DarklordEnum.Anhktepot.BindRelatedCreatures(Creature.GreaterMummy);
            DomainEnum.HarAkir.Appeared().BindCreatures(Creature.GreaterMummy);
            DomainEnum.HarAkir.AddLivingDarklord(DarklordEnum.Anhktepot);

            DarklordEnum.Radaga.BindRelatedCreatures(Creature.GiantSkeleton);
            DarklordEnum.HarkonLukas.BindRelatedCreatures(Creature.GreaterWolfwere);
            DomainEnum.Kartakass.Appeared().BindCreatures(Creature.GiantSkeleton, Creature.GreaterWolfwere);
            DomainEnum.Kartakass.AddLivingCharacter(DarklordEnum.Radaga);
            DomainEnum.HarAkir.AddLivingDarklord(DarklordEnum.HarkonLukas);

            Creature.Reaver.BindDomains(DomainEnum.SeaOfSorrows, DomainEnum.Lamordia, DomainEnum.Mordent, DomainEnum.Dementlieu, DomainEnum.Darkon);

            DarklordEnum.LordGundar.BindCreatures(Creature.Vampire);
            DomainEnum.Gundarak.Appeared().BindCreatures(Creature.Vampire);
            DomainEnum.Gundarak.AddLivingCharacter(DarklordEnum.LordGundar);

            DomainEnum.Sithicus.Appeared().BindCreatures(Creature.Kender, Creature.Vampire);
            DomainEnum.Sithicus.AddLivingCharacter(DarklordEnum.LordSoth);

            Creature.TigbanuaBuso.BindCreatures(Creature.TagamalingBuso);
            Creature.Vampire.BindCreatures(Creature.JiangShi);
            Creature.UndeadBeast.BindCreatures(Creature.UndeadBeastStahnk, Creature.UndeadBeastStahnk);
            Creature.Gaki.BindCreatures(Creature.JikiKetsuGaki, Creature.JikiNikuGaki, Creature.ShikkiGaki, Creature.ShinenGaki);
            Creature.Hag.BindCreatures(Creature.Hannya);
            Creature.Hengeyokai.BindCreatures(Creature.GoblinRat, Creature.HuHsien, Creature.FoxHengeyokai, Creature.RacoonDogHengeyokai, Creature.RatHengeyokai);
            Creature.Oni.BindCreatures(Creature.CommonOni, Creature.GoZuOni, Creature.MeZuOni);
            Creature.Baatezu.BindCreatures(Creature.Abishai, Creature.Spinagon, Creature.Barbazu, Creature.Erinyes, Creature.Hamatula, Creature.Nupperibo, Creature.PitFiend, Creature.Amnizu, Creature.Gelugon, Creature.Osyluth, Creature.Lemure);
            Creature.Gith.BindCreatures(Creature.Githyanki, Creature.Githzerai);
            Creature.TanarRi.BindCreatures(Creature.Babau, Creature.Chasme, Creature.Nabassu, Creature.Molydeus, Creature.Dretch, Creature.Manes, Creature.Rutterkin, Creature.AluFiend, Creature.Barlgura, Creature.Cambion, Creature.Succubus, Creature.Balor, Creature.Glabrezu, Creature.Hezrou, Creature.Marilith, Creature.Nalfeshnee, Creature.Vrock);
            Creature.Yugoloth.BindCreatures(Creature.Arcanaloth, Creature.Nycaloth, Creature.Ultroloth, Creature.Dergholoth, Creature.Hydroloth, Creature.Mezzoloth, Creature.Piscoloth, Creature.Yagnoloth);
            Creature.DopplegangerPlant.BindCreatures(Creature.Podling);
            Creature.RavenloftElemental.BindCreatures(Creature.PyreElemental, Creature.BloodElemental, Creature.MistElemental, Creature.GraveElemental);
            GroupEnum.Darkling.BindCreatures(Creature.Ghast, Creature.Wraith);
            Creature.Wraith.BindCreatures(Creature.Wight);
            Creature.Ghast.BindCreatures(Creature.Ghoul);
            Creature.RavenloftGolem.BindCreatures(Creature.BoneGolem, Creature.DollGolem, Creature.GargoyleGolem, Creature.GlassGolem, Creature.MechanicalGolem);
            Creature.MistHorror.BindCreatures(Creature.WanderingHorror);
            Creature.GreaterMummy.BindCreatures(Creature.Mummy);
            Creature.Treant.BindCreatures(Creature.EvilTreant, Creature.UndeadTreant, Creature.AnimatedTree);

            CampaignSetting.ForgottenRealms.BindCreatures(Creature.CrawlingClaw, Creature.Cloaker, Creature.Darkenbeast, Creature.CrimsonDeath, Creature.Revenant, Creature.LivingWeb, Creature.TigbanuaBuso, Creature.TagamalingBuso, Creature.ChuU, Creature.ConTinh, Creature.JikiKetsuGaki, Creature.JikiNikuGaki, Creature.ShikkiGaki, Creature.ShinenGaki, Creature.GoblinRat, Creature.GoblinSpider, Creature.Hannya, Creature.FoxHengeyokai, Creature.RacoonDogHengeyokai, Creature.RatHengeyokai, Creature.HuHsien, Creature.Ikiryo, Creature.Kaluk, Creature.Krakentua, Creature.Kuei, Creature.Memedi, Creature.Gaki, Creature.Hengeyokai, Creature.Oni, Creature.CommonOni, Creature.GoZuOni, Creature.MeZuOni, Creature.GoheiPOh, Creature.StoneSpirit, Creature.YukiOnNa);
            CampaignSetting.Dragonlance.BindCreatures(Creature.UndeadBeast, Creature.UndeadBeastStahnk, Creature.UndeadBeastStahnk, Creature.Dreamshadow, Creature.Dreamwraith, Creature.Fetch, Creature.FireMinion, Creature.FireShadow, Creature.KnightHaunt, Creature.SpectralMinion, Creature.WarriorSkeleton, Creature.Wichtlin, Creature.Yaggol);
            CampaignSetting.Greyhawk.BindCreatures(Creature.CryptThing, Creature.YethHound, Creature.SonOfKyuss, Creature.Necrophidius, Creature.Raven, Creature.GiantRaven, Creature.Scarecrow, Creature.SlowShadow, Creature.Swordwraith, Creature.SoulBeckoner, Creature.SeaZombie, Creature.Wereraven);
            CampaignSetting.Spelljammer.BindCreatures(Creature.AncientMariner, Creature.Spiritjam, Creature.Allura, Creature.Dreamslayer, Creature.Dweomerborn, Creature.Firelich, Creature.Skullbird, Creature.SpiritWarrior, Creature.StellarUndead);

            DomainEnum.InsideRavenloft.AddGroup(GroupEnum.Darkling);
            DomainEnum.InsideRavenloft.AddGroup(GroupEnum.Vistani);
            DomainEnum.InsideRavenloft.AddGroup(GroupEnum.DarkPowers);

            GroupEnum.AbberNomad.BindLanguages(Language.AbberNomad);
            Creature.Quevari.BindLanguages(Language.Quevari);
            Creature.Ravenkin.BindLanguages(Language.Ravenkin);
            Language.Treant.BindLanguages(Language.EvilTreant);
            Language.EvilTreant.BindCreatures(Creature.EvilTreant, Creature.UndeadTreant);
            Creature.Dwarf.BindLanguages(Language.Dwarf);
            Creature.Elf.BindLanguages(Language.Elf);
            Creature.Gnome.BindLanguages(Language.Gnome);
            Creature.Halfling.BindLanguages(Language.Halfling);
            Creature.Kender.BindLanguages(Language.Kender);
        }
        void AddDarklords()
        {
            var releaseDate = "01/08/1991";
            string ExtraInfo = "<br/>&emsp;Design: Andria Hayday (Banshee, Bluebeard, Hags, Headless Horseman, House of Lament, Introduction, Phantom Lover, Recipe for Mummificiation, Tiyet, Zolnik";
            ExtraInfo += "<br/>&emsp;Additional Design: William W. Connors (Ebonbane, Merilee, Monette), Bruce Nesmith (Anhktepot, Von Kharkov), and James Lowder (D' Polarno)";
            ExtraInfo += "<br/>&emsp;Editing: Mile Breault";
            ExtraInfo += "<br/>&emsp;Cover Art: Tim Hildebrandt";
            ExtraInfo += "<br/>&emsp;Interior Art: Stephen Fabian";
            ExtraInfo += "<br/>&emsp;Cartography: David C. Sutherland III";
            ExtraInfo += "<br/>&emsp;Graphic Design: Roy E. Parker";
            ExtraInfo += "<br/>&emsp;Typesetting: Tracey Zamagne";
            ExtraInfo += "<br/>&emsp;Production: Paul Hanchette";
            ExtraInfo += "<br/>&emsp;Invaluable Assistance: Troy Denning";
            ExtraInfo += "<br/>&emsp;Special Thanks: Karen Boomgarden";
            using var ctx = CreateSource("Darklords", releaseDate, ExtraInfo, Edition.e2, Media.sourcebook);

            DomainEnum.HarAkir.Appeared("4, 6-11, 86");
            DomainEnum.HarAkir.AddLivingDarklord(DarklordEnum.Anhktepot, "2, 4, 6-11").BindGroups(GroupEnum.Ra).BindCreatures(Creature.GreaterMummy).BindRelatedCreatures(Creature.Mummy).BindLair(LocationEnum.AnhkepotTomb).BindAlignment(Alignment.CE);
            DomainEnum.HarAkir.AddGroup(GroupEnum.Ra, "6, 9, 11");
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.Ra, "6, 9").BindGroups(GroupEnum.Ra, GroupEnum.Deity);
            DomainEnum.HarAkir.AddLivingCharacter(CharacterEnum.Nephyr, "6").BindCreatures(Creature.Mummy).BindCharacters(DarklordEnum.Anhktepot);
            DomainEnum.HarAkir.AddSettlement(Settlement.Muhar, "8");
            DomainEnum.HarAkir.AddLocation(LocationEnum.PharaohsRest, "8");
            DomainEnum.HarAkir.AddLocation(LocationEnum.AnhkepotTomb, "10-11");

            DomainEnum.Keening.Appeared("12-21, 39").BindCreatures(Creature.Ghost, Creature.Wight, Creature.Zombie, Creature.Bee, Creature.CrawlingClaw, Creature.Rat);
            DomainEnum.Keening.AddLivingDarklord(DarklordEnum.Tristessa, "2, 12-14, 20-21").BindCreatures(Creature.Banshee, Creature.Drow).BindGroups(GroupEnum.Lolth).BindLair(LocationEnum.BansheeLair).BindCloseBorder("Creates a wall of wind. No creature can fly or walk through this wall, and no magic can diminish its force.").BindAlignment(Alignment.CE);
            DomainEnum.Keening.AddLocation(LocationEnum.MountLament, "14, 19");
            DomainEnum.Keening.AddLocation(LocationEnum.BansheeLair, "15");
            DomainEnum.Keening.AddLocation(LocationEnum.OldToll, "15-16");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadMarketSquare, "17-19");
            DomainEnum.Keening.AddLocation(LocationEnum.AlbiaCreek, "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadNewWall,              "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadPalace,               "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadOldMarket,            "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadBarracks,             "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadArena,                "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadInn,                  "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadTemple,               "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadMill,                 "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadBath,                 "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadGate,                 "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadNewWall,              "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadOldWall,              "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadBellTower,            "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadGrainMarket,          "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadClothMarket,          "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadNewMarketFair,        "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadSeasonalHorseMarket,  "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadResidentialDistrict,  "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadTannersDistrict,      "18-19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadBusinessDistrict,     "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadMetalworkersDistrict, "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadManorHouse,           "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadAleHouse,             "19");
            DomainEnum.Keening.AddLocation(LocationEnum.CityOfTheDeadLaborersQuarter,      "19");
            DomainEnum.Keening.AddSettlement(Settlement.CityOfTheDead, "15-19").BindLocations(
                LocationEnum.CityOfTheDeadMarketSquare,
                LocationEnum.CityOfTheDeadNewWall,
                LocationEnum.CityOfTheDeadPalace,
                LocationEnum.CityOfTheDeadOldMarket,
                LocationEnum.CityOfTheDeadBarracks,
                LocationEnum.CityOfTheDeadArena,
                LocationEnum.CityOfTheDeadInn,
                LocationEnum.CityOfTheDeadTemple,
                LocationEnum.CityOfTheDeadMill,
                LocationEnum.CityOfTheDeadBath,
                LocationEnum.CityOfTheDeadGate,
                LocationEnum.CityOfTheDeadNewWall,
                LocationEnum.CityOfTheDeadOldWall,
                LocationEnum.CityOfTheDeadBellTower,
                LocationEnum.CityOfTheDeadGrainMarket,
                LocationEnum.CityOfTheDeadClothMarket,
                LocationEnum.CityOfTheDeadNewMarketFair,
                LocationEnum.CityOfTheDeadSeasonalHorseMarket,
                LocationEnum.CityOfTheDeadResidentialDistrict,
                LocationEnum.CityOfTheDeadTannersDistrict,
                LocationEnum.CityOfTheDeadBusinessDistrict,
                LocationEnum.CityOfTheDeadMetalworkersDistrict,
                LocationEnum.CityOfTheDeadManorHouse,
                LocationEnum.CityOfTheDeadAleHouse,
                LocationEnum.CityOfTheDeadLaborersQuarter);
            DomainEnum.Arak.Appeared("4, 12-15, 39").BindCreatures(Creature.Drow).BindGroups(GroupEnum.Lolth);
            DomainEnum.Arak.AddLivingCharacter(DarklordEnum.Tristessa,"2, 12-14");
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.Lolth, "12-14").BindGroups(GroupEnum.Lolth, GroupEnum.Deity).BindRelatedCreatures(Creature.Drider);
            DomainEnum.Darkon.Appeared("12, 14-15");
            DomainEnum.Darkon.AddSettlement(Settlement.Sidnar, "15");
            Creature.Drow.BindCreatures(Creature.Drider);
            DomainEnum.Falkovnia.Appeared("15, 44");
            DomainEnum.Falkovnia.AddLivingDarklord(DarklordEnum.VladDrakov, "44");
            DomainEnum.Falkovnia.AddLocation(LocationEnum.RiverVuchar, "15");
            DomainEnum.NovaVaasa.Appeared("15");
            DomainEnum.NovaVaasa.AddSettlement(Settlement.Egertus, "15, 39");

            DomainEnum.Blaustein.Appeared("22-26");
            DomainEnum.Blaustein.AddLivingDarklord(DarklordEnum.Bluebeard, "2, 22-26").BindCharacters(CharacterEnum.Ursula, CharacterEnum.Jacinda, CharacterEnum.Beatrice, CharacterEnum.Camilla, CharacterEnum.Matilda, CharacterEnum.Lenor, CharacterEnum.Marguerite, CharacterEnum.Jacqueline).BindLair(LocationEnum.CastleBluebeard).BindRelatedCreatures(Creature.Spectre).BindAlignment(Alignment.LE);
            DomainEnum.Blaustein.AddLivingCharacter(CharacterEnum.Marcella, "22-24, 27").BindCreatures(Creature.Spectre);
            DomainEnum.Blaustein.AddLivingCharacter(CharacterEnum.Lorel, "25, 27").BindCreatures(Creature.Spectre);
            DomainEnum.Blaustein.AddLivingCharacter(CharacterEnum.Antonia, "27").BindCreatures(Creature.Spectre);
            DomainEnum.Blaustein.AddLivingCharacter(CharacterEnum.Ursula, "27").BindCreatures(Creature.Spectre);
            DomainEnum.Blaustein.AddLivingCharacter(CharacterEnum.Jacinda, "27").BindCreatures(Creature.Spectre);
            DomainEnum.Blaustein.AddLivingCharacter(CharacterEnum.Beatrice, "27").BindCreatures(Creature.Spectre);
            DomainEnum.Blaustein.AddLivingCharacter(CharacterEnum.Camilla, "27").BindCreatures(Creature.Spectre);
            DomainEnum.Blaustein.AddLivingCharacter(CharacterEnum.Matilda, "27").BindCreatures(Creature.Spectre);
            DomainEnum.Blaustein.AddLivingCharacter(CharacterEnum.Lenor, "27").BindCreatures(Creature.Spectre);
            DomainEnum.Blaustein.AddLivingCharacter(CharacterEnum.Marguerite, "27").BindCreatures(Creature.Spectre);
            DomainEnum.Blaustein.AddLivingCharacter(CharacterEnum.Jacqueline, "27").BindCreatures(Creature.Spectre);
            DomainEnum.Blaustein.AddLocation(LocationEnum.CastleBluebeard, "25-27").BindCreatures(Creature.Spectre).BindCharacters(CharacterEnum.Ursula, CharacterEnum.Jacinda, CharacterEnum.Beatrice, CharacterEnum.Camilla, CharacterEnum.Matilda, CharacterEnum.Lenor, CharacterEnum.Marguerite, CharacterEnum.Jacqueline);
            GroupEnum.BluebeardWives.BindCharacters(CharacterEnum.Ursula, CharacterEnum.Jacinda, CharacterEnum.Beatrice, CharacterEnum.Camilla, CharacterEnum.Matilda, CharacterEnum.Lenor, CharacterEnum.Marguerite, CharacterEnum.Jacqueline);

            DomainEnum.ShadowbornManor.Appeared("27-35");
            DomainEnum.ShadowbornManor.AddLivingDarklord(DarklordEnum.Ebonbane, "2, 27-35").BindAlignment(Alignment.CE).BindCloseBorder("A mysterious circular stone wall that surrounds the house at a distance of about 100 yards. Characters trying to magically bypass the wall find that their spells and similar abilities have no effect. From within, the wall is solid and utterly invulnerable. Scaling the wall is equally impos’sible, for it seems to flow like water under those who attempt to climb it. Even the most highly skilled of thieves cannot scale it. Unlike lords of other domains, Ebonbane cannot open and close the borders of the Shadowborn estate at will.");
            DomainEnum.ShadowbornManor.AddLivingCharacter(CharacterEnum.KateriShadowborn, "27-31, 33, 35").BindCreatures(Creature.Geist).BindAlignment(Alignment.LG);
            DomainEnum.ShadowbornManor.AddLocation(LocationEnum.ShadowbornManor, "27-35");
            DomainEnum.ShadowbornManor.AddItem(ItemEnum.HolyAvenger, "30").BindCharacters(CharacterEnum.KateriShadowborn);
            DomainEnum.ShadowbornManor.AddItem(ItemEnum.KeyOfEarth, "31").BindCharacters(CharacterEnum.KateriShadowborn, DarklordEnum.Ebonbane);
            DomainEnum.ShadowbornManor.AddItem(ItemEnum.KeyOfFire, "31").BindCharacters(CharacterEnum.KateriShadowborn, DarklordEnum.Ebonbane);
            DomainEnum.ShadowbornManor.AddItem(ItemEnum.KeyOfWater, "31").BindCharacters(CharacterEnum.KateriShadowborn, DarklordEnum.Ebonbane);
            DomainEnum.ShadowbornManor.AddItem(ItemEnum.KeyOfAir, "31").BindCharacters(CharacterEnum.KateriShadowborn, DarklordEnum.Ebonbane);

            DomainEnum.Tepest.Appeared("4, 36-43").BindCreatures(Creature.Wolf, Creature.Goblin);
            DomainEnum.Tepest.AddGroup(GroupEnum.HagsOfTepest, "2, 4, 36-43").BindCreatures(Creature.Hag, Creature.SeaHag, Creature.AnnisHag, Creature.GreenHag).BindCharacters(DarklordEnum.LeticiaMindefisk, DarklordEnum.LaveedaMindefisk, DarklordEnum.LorindaMindefisk);
            DomainEnum.Tepest.AddLivingDarklord(DarklordEnum.LeticiaMindefisk, "36-43").BindLair(LocationEnum.HagCottage).BindCreatures(Creature.Hag, Creature.SeaHag);                                                                  
            DomainEnum.Tepest.AddLivingDarklord(DarklordEnum.LaveedaMindefisk, "36-43").BindLair(LocationEnum.HagCottage).BindCreatures(Creature.Hag, Creature.AnnisHag);                                                                
            DomainEnum.Tepest.AddLivingDarklord(DarklordEnum.LorindaMindefisk, "36-43").BindLair(LocationEnum.HagCottage).BindCreatures(Creature.Hag, Creature.GreenHag);
            DomainEnum.Tepest.AddDeadCharacter(CharacterEnum.RudellaMindefisk, "36-38");
            DomainEnum.Tepest.AddDeadCharacter(CharacterEnum.HolgerMindefisk, "36-38");
            DomainEnum.Tepest.AddLocation(LocationEnum.LakeKronov, "39-40").BindCreatures(Creature.Hag, Creature.SeaSerpent);
            DomainEnum.Tepest.AddLocation(LocationEnum.GoblinLairs, "39").BindCreatures(Creature.Goblin);
            DomainEnum.Tepest.AddLocation(LocationEnum.TimoriRoad, "39, 41").BindGroups(GroupEnum.HagsOfTepest).BindCharacters(DarklordEnum.LeticiaMindefisk, DarklordEnum.LaveedaMindefisk, DarklordEnum.LorindaMindefisk);
            DomainEnum.Tepest.AddLocation(LocationEnum.HagCottage, "39, 41, 43").BindGroups(GroupEnum.HagsOfTepest).BindCharacters(DarklordEnum.LeticiaMindefisk, DarklordEnum.LaveedaMindefisk, DarklordEnum.LorindaMindefisk);
            DomainEnum.Tepest.AddLocation(LocationEnum.CauldronOfRegeneration, "39, 43").BindGroups(GroupEnum.HagsOfTepest).BindCharacters(DarklordEnum.LeticiaMindefisk, DarklordEnum.LaveedaMindefisk, DarklordEnum.LorindaMindefisk);
            DomainEnum.Tepest.AddLocation(LocationEnum.Balinoks, "40-41");
            DomainEnum.Tepest.AddSettlement(Settlement.Viktal, "39");
            DomainEnum.Tepest.AddSettlement(Settlement.Kellee, "39-40").BindCreatures(Creature.Hag);
            DomainEnum.Tepest.AddItem(ItemEnum.HagEye, "42").BindGroups(GroupEnum.HagsOfTepest).BindCharacters(DarklordEnum.LeticiaMindefisk, DarklordEnum.LaveedaMindefisk, DarklordEnum.LorindaMindefisk);
            DomainEnum.Tepest.AddItem(ItemEnum.ImprovedHagEye, "42").BindGroups(GroupEnum.HagsOfTepest).BindCharacters(DarklordEnum.LeticiaMindefisk, DarklordEnum.LaveedaMindefisk, DarklordEnum.LorindaMindefisk);
            DomainEnum.GHenna.Appeared("39");
            DomainEnum.Markovia.Appeared("39");

            CampaignSetting.ForgottenRealms.BindCreatures(Creature.Maeder);
            DomainEnum.WindingRoad.Appeared("44-47").BindCreatures(Creature.Horse, Creature.Maeder, Creature.Medusa);
            DomainEnum.WindingRoad.AddLivingDarklord(DarklordEnum.HeadlessHorseman, "2, 44-47").BindAlignment(Alignment.CE).BindRelatedCreatures(Creature.Horse, Creature.Maeder, Creature.Medusa);
            DomainEnum.Barovia.Appeared("44");
            DomainEnum.Barovia.AddLivingDarklord(DarklordEnum.CountStrahd, "44");
            DomainEnum.Borca.Appeared("44").BindCreatures(Creature.Ermordenung);
            DomainEnum.Borca.AddLivingDarklord(DarklordEnum.IvanaBoritsi, "44, 76");
            DomainEnum.Borca.AddSettlement(Settlement.Levkarest, "44");
            DomainEnum.Borca.AddSettlement(Settlement.Sturben, "44");

            DomainEnum.HouseOfLament.Appeared("2, 48-53").BindCreatures(Creature.Rat, Creature.Maggot, Creature.RotGrub, Creature.BloodElemental);
            DomainEnum.HouseOfLament.AddLocation(LocationEnum.HouseOfLament, "48-53");
            DomainEnum.HouseOfLament.AddLivingDarklord(DarklordEnum.HouseOfLament, "2, 48-53").BindLair(LocationEnum.HouseOfLament);
            DomainEnum.HouseOfLament.AddLivingCharacter(CharacterEnum.LordDranzorg, "48-52");
            DomainEnum.HouseOfLament.AddDeadCharacter(CharacterEnum.LordSilva, "45");
            DomainEnum.HouseOfLament.AddLivingCharacter(CharacterEnum.LadyMaraSilva, "48-53");
            DomainEnum.HouseOfLament.Inspirations.UnionWith(new[]
            {
                "<i>The Haunting (1963)</i> by Robert Wise",
                "<i>The Haunting of Hill House</i> by Shirley Jackson",
            });

            DomainEnum.Valachan.Appeared("54-59").BindCreatures(Creature.Panther);
            DomainEnum.Valachan.AddLivingDarklord(DarklordEnum.UrikVonKharkov, "2, 54-59").BindCharacters(CharacterEnum.Morphayus, CharacterEnum.Selena).BindCreatures(Creature.Panther, Creature.Vampire, Creature.Nosferatu).BindRelatedCreatures(Creature.Smilodon).BindAlignment(Alignment.LE);
            DomainEnum.Valachan.AddItem(ItemEnum.CatOfFelkovic, "56, 58").BindCreatures(Creature.Smilodon);
            DomainEnum.Valachan.AddLocation(LocationEnum.CastlePantara, "58-59").BindCreatures(Creature.Panther);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.Morphayus, "54").BindGroups(GroupEnum.RedWizard).BindSetting(CampaignSetting.ForgottenRealms);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.Selena, "54").BindCharacters(CharacterEnum.Morphayus).BindSetting(CampaignSetting.ForgottenRealms);
            DomainEnum.OutsideRavenloft.AddGroup(GroupEnum.RedWizard, "54").BindSetting(CampaignSetting.ForgottenRealms);
            DomainEnum.Darkon.Appeared("54");
            DomainEnum.Darkon.AddLivingCharacter(DarklordEnum.UrikVonKharkov, "54");
            DomainEnum.Darkon.AddGroup(GroupEnum.TheKargat, "54").BindCreatures(Creature.Vampire, Creature.Nosferatu);
            DomainEnum.Darkon.AddSettlement(Settlement.Karg, "54");

            DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.MerileeMarkuza, "2, 60-63").BindCreatures(Creature.Vampire, Creature.Bat, Creature.Wolf).BindSetting(CampaignSetting.Dragonlance).BindAlignment(Alignment.NE);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.Keesla, "60-62").BindCreatures(Creature.Vampire).BindSetting(CampaignSetting.Dragonlance);
            DomainEnum.Lamordia.Appeared("62-63");
            DomainEnum.Lamordia.AddLivingDarklord(DarklordEnum.Adam, "62");
            DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.DoctorRudolphVanRichten, "63");
            DomainEnum.Lamordia.AddDeadCharacter(CharacterEnum.Claudia, "63").BindCharacters(CharacterEnum.DoctorRudolphVanRichten);

            DomainEnum.TheLighthouse.Appeared("64-67").BindCreatures(Creature.Bat, Creature.Fly, Creature.Gnat);
            DomainEnum.TheLighthouse.AddLivingDarklord(DarklordEnum.CaptainMonette, "3, 64-67").BindCreatures(Creature.Werebat, Creature.Bat).BindAlignment(Alignment.LE).BindLair(LocationEnum.EyeOfMidnight).BindCloseBorder("He can control the currents in the seas that surround his island (at will). Thus, he can make it impossible or deadly to attempt swimming or boating.");
            DomainEnum.TheLighthouse.AddLocation(LocationEnum.EyeOfMidnight, "66-67").BindCharacters(DarklordEnum.CaptainMonette);

            DomainEnum.LeederiksTower.Appeared("68-73");
            DomainEnum.LeederiksTower.AddLivingDarklord(DarklordEnum.PhantomLover, "3, 68-73").BindCreatures(Creature.Snake, Creature.Gargoyle, Creature.Dragon, Creature.BlackDragon).BindRelatedCreatures(Creature.Zombie).BindLair(LocationEnum.LeederiksTower).BindAlignment(Alignment.LE);
            DomainEnum.LeederiksTower.AddLocation(LocationEnum.LeederiksTower, "68-73");

            DomainEnum.Ghastria.Appeared("74-79").BindCreatures(Creature.Bat, Creature.Rat, Creature.Snake, Creature.Wolf, Creature.CarrionCrawler, Creature.Ghost, Creature.Ghoul, Creature.Wight);
            DomainEnum.Ghastria.AddLivingDarklord(DarklordEnum.StezenDPolarno, "3, 74-79").BindLair(LocationEnum.StezenManorHouse).BindCloseBorder("The borders of Ghastria are replaced by huge paintings, much like the flats used for plays. These paintings appear as panoramic, twisted landscapes, and only by walking into one does a player character discover it’s not real. The paintings rise higher than player characters can fly and deeper than they can dig. They cannot be harmed or breached in any way. The borders of Ghastria can’t be closed when Stezen is under the rejuvenating influence of the portrait").BindAlignment(Alignment.NE | Alignment.CE);
            DomainEnum.Ghastria.AddSettlement(Settlement.EastRiding, "76-79").BindLocations(LocationEnum.TheGoldWolf, LocationEnum.TheDarkHeart, LocationEnum.StezenManorHouse, LocationEnum.GarnRiver, LocationEnum.GhastriaStables, LocationEnum.GhastriaOpenAirMarket, LocationEnum.GhastriaMill, LocationEnum.GhastriaAbandonedChapel);
            DomainEnum.Ghastria.AddItem(ItemEnum.PaintingOfStezen, "74-77").BindCharacters(DarklordEnum.StezenDPolarno);
            DomainEnum.Ghastria.AddLocation(LocationEnum.TheGoldWolf, "77-78");
            DomainEnum.Ghastria.AddLocation(LocationEnum.TheDarkHeart, "77-78");
            DomainEnum.Ghastria.AddLocation(LocationEnum.StezenManorHouse, "77-78");
            DomainEnum.Ghastria.AddLocation(LocationEnum.GarnRiver, "77");
            DomainEnum.Ghastria.AddLocation(LocationEnum.GhastriaStables, "77");
            DomainEnum.Ghastria.AddLocation(LocationEnum.GhastriaOpenAirMarket, "77-78");
            DomainEnum.Ghastria.AddLocation(LocationEnum.GhastriaMill, "77");
            DomainEnum.Ghastria.AddLocation(LocationEnum.GhastriaAbandonedChapel, "77-79");
            DomainEnum.Ghastria.AddItem(ItemEnum.RapierOfQuickness, "79").BindCharacters(DarklordEnum.StezenDPolarno);
            DomainEnum.Sithicus.Appeared("74");

            DomainEnum.Sebua.Appeared("4, 80-89").BindCreatures(Creature.Camel, Creature.Goose, Creature.Vulture, Creature.Locust, Creature.Scorpion);
            DomainEnum.Sebua.AddLivingDarklord(DarklordEnum.Tiyet, "3, 80-89").BindCreatures(Creature.Mummy, Creature.Owl, Creature.Monkey).BindRelatedCreatures(Creature.Beetle).BindLair(LocationEnum.TiyetEstate).BindAlignment(Alignment.NE).BindCloseBorder("Create a sandstorm. The storm covers up to a square mile, and lasts up to two hours, depending on Tiyet’s wishes. She can move the sandstorm as she pleases. She requires three rounds to create the storm, but her powers are not restricted during that time. The Dark Powers augment this ability when Tiyet wishes to close the borders of Sebua, creating a storm that exists only along the boundaries of her domain.");
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.Khamose, "80, 82").BindCharacters(DarklordEnum.Tiyet, CharacterEnum.Nufreri);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.Nufreri, "80").BindRelatedCreatures(Creature.Jackal);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.Zordenahkt, "82, 84, 89").BindCharacters(DarklordEnum.Tiyet).BindRelatedCreatures(Creature.Asp, Creature.Snake);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.Apophis, "82-85, 89").BindGroups(GroupEnum.Deity);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.Anubis, "82").BindGroups(GroupEnum.Deity);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.Osiris, "82").BindGroups(GroupEnum.Deity);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.Maat, "82").BindGroups(GroupEnum.Deity);
            DomainEnum.Sebua.AddLocation(LocationEnum.TheAbyss, "83, 85");
            DomainEnum.Sebua.AddLocation(LocationEnum.ValleyOfDeath, "83, 85-86, 89").BindCreatures(Creature.Bat, Creature.Beetle);
            DomainEnum.Sebua.AddLocation(LocationEnum.TempleOfApophis, "82-83, 85, 89").BindCharacters(DarklordEnum.Tiyet, CharacterEnum.Zordenahkt, CharacterEnum.Apophis).BindCreatures(Creature.Asp);
            DomainEnum.Sebua.AddLocation(LocationEnum.RedOasis, "83").BindCreatures(Creature.Mosquito, Creature.Bat);
            DomainEnum.Sebua.AddLocation(LocationEnum.SebuaWell, "83");
            DomainEnum.Sebua.AddLocation(LocationEnum.FetidWell, "83");
            DomainEnum.Sebua.AddLocation(LocationEnum.SandstoneTowers, "83");
            DomainEnum.Sebua.AddLocation(LocationEnum.SebuaDunes, "83");
            DomainEnum.Sebua.AddLocation(LocationEnum.RockyHills, "83");
            DomainEnum.Sebua.AddLocation(LocationEnum.DryRiverBed, "83");
            DomainEnum.Sebua.AddSettlement(Settlement.RuinedVillage, "83");
            DomainEnum.Sebua.AddLocation(LocationEnum.TiyetEstate, "83-84, 86-88").BindCreatures(Creature.Mummy, Creature.Goose, Creature.Cow, Creature.Monkey);
            DomainEnum.Sebua.AddSettlement(Settlement.Anhalla, "83, 85-86").BindCreatures(Creature.Monkey, Creature.Baboon, Creature.Jackal, Creature.Mosquito, Creature.Bat);
            DomainEnum.Sebua.AddLocation(LocationEnum.SebuaOasis, "83").BindCreatures(Creature.Mosquito, Creature.Bat);
            DomainEnum.Sebua.AddItem(ItemEnum.IdolOfApophis, "84").BindCharacters(CharacterEnum.Apophis);

            DomainEnum.Vorostokov.Appeared("90-96").BindCreatures(Creature.Wolf);
            DomainEnum.Vorostokov.AddLivingDarklord(DarklordEnum.GregorZolnik, "3, 90-96").BindCreatures(Creature.LoupDuNoir,Creature.Wolf).BindAlignment(Alignment.CE).BindCloseBorder("If Gregor chooses to seal his border however, snowstorms and avalanches drive travelers back into Vorostokov.");
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.Ireena, "92-93").BindCharacters(DarklordEnum.GregorZolnik).BindRelatedCreatures(Creature.Wolf);
            DomainEnum.Vorostokov.AddDeadCharacter(CharacterEnum.Nicolai, "93").BindCharacters(DarklordEnum.GregorZolnik).BindRelatedCreatures(Creature.Wolf);
            DomainEnum.Vorostokov.AddLivingCharacter(CharacterEnum.MarikMouseEater, "95");
            DomainEnum.Vorostokov.AddLivingCharacter(CharacterEnum.AntoninaZolnik, "90, 92-93, 96").BindCharacters(DarklordEnum.GregorZolnik, CharacterEnum.NatalyaZolnik, CharacterEnum.ElenaZolnik).BindAlignment(Alignment.LE);
            DomainEnum.Vorostokov.AddLivingCharacter(CharacterEnum.NatalyaZolnik, "90, 92-93, 96").BindCharacters(DarklordEnum.GregorZolnik, CharacterEnum.AntoninaZolnik, CharacterEnum.ElenaZolnik).BindAlignment(Alignment.LE);
            DomainEnum.Vorostokov.AddLivingCharacter(CharacterEnum.ElenaZolnik, "90, 92-93, 96").BindCharacters(DarklordEnum.GregorZolnik, CharacterEnum.NatalyaZolnik, CharacterEnum.AntoninaZolnik).BindAlignment(Alignment.LE);
            DomainEnum.Vorostokov.AddSettlement(Settlement.Vorostokov, "90, 92-95").BindCharacters(DarklordEnum.GregorZolnik).BindLocations(LocationEnum.VorostokovCarpenter, LocationEnum.VorostokovSmokehouse, LocationEnum.VorostokovTanner, LocationEnum.VorostokovFurrier, LocationEnum.VorostokovTrader, LocationEnum.VorostokovSmithy, LocationEnum.Sauna, LocationEnum.AlehouseMeetingHall, LocationEnum.VillageGreen, LocationEnum.GregorsHome, LocationEnum.MariksHome);
            DomainEnum.Vorostokov.AddSettlement(Settlement.Kirova, "95");
            DomainEnum.Vorostokov.AddSettlement(Settlement.Torgov, "95");
            DomainEnum.Vorostokov.AddSettlement(Settlement.Nordvik, "95");
            DomainEnum.Vorostokov.AddSettlement(Settlement.Kargo, "95");
            DomainEnum.Vorostokov.AddSettlement(Settlement.Voronina, "95");
            DomainEnum.Vorostokov.AddSettlement(Settlement.Oneka, "95");
            DomainEnum.Vorostokov.AddSettlement(Settlement.Novayalenk, "95");
            DomainEnum.Vorostokov.AddSettlement(Settlement.Siberski, "95");
            DomainEnum.Vorostokov.AddLocation(LocationEnum.BottomlessLake, "95");
            DomainEnum.Vorostokov.AddLocation(LocationEnum.GregorsCave, "95").BindCharacters(DarklordEnum.GregorZolnik);
            DomainEnum.Vorostokov.AddLocation(LocationEnum.RiverTrau, "95");

            DomainEnum.Vorostokov.AddLocation(LocationEnum.VorostokovCarpenter, "95");
            DomainEnum.Vorostokov.AddLocation(LocationEnum.VorostokovSmokehouse, "95");
            DomainEnum.Vorostokov.AddLocation(LocationEnum.VorostokovTanner, "95");
            DomainEnum.Vorostokov.AddLocation(LocationEnum.VorostokovFurrier, "95");
            DomainEnum.Vorostokov.AddLocation(LocationEnum.VorostokovTrader, "95");
            DomainEnum.Vorostokov.AddLocation(LocationEnum.VorostokovSmithy, "95");
            DomainEnum.Vorostokov.AddLocation(LocationEnum.Sauna, "95");
            DomainEnum.Vorostokov.AddLocation(LocationEnum.AlehouseMeetingHall, "95");
            DomainEnum.Vorostokov.AddLocation(LocationEnum.VillageGreen, "95");
            DomainEnum.Vorostokov.AddLocation(LocationEnum.GregorsHome, "95").BindCharacters(DarklordEnum.GregorZolnik, CharacterEnum.AntoninaZolnik, CharacterEnum.NatalyaZolnik, CharacterEnum.ElenaZolnik);
            DomainEnum.Vorostokov.AddLocation(LocationEnum.MariksHome, "95").BindCharacters(CharacterEnum.MarikMouseEater);
        }
        void AddBookOfCrypts()
        {
            var releaseDate = "01/10/1991";
            string ExtraInfo = "<br/>&emsp;Design: Dale 'Slade' Henson with J. Robert King";
            ExtraInfo += "<br/>&emsp;Editing: Anne Brown, J. Robert King, Jean Rabe";
            ExtraInfo += "<br/>&emsp;Proofreading: Anne Brown, David Wise";
            ExtraInfo += "<br/>&emsp;Cover Art: David Dorman";
            ExtraInfo += "<br/>&emsp;Interior Art: Laura and Kelly Freas, Stephen Fabian";
            ExtraInfo += "<br/>&emsp;Cartography: John Knecht";
            ExtraInfo += "<br/>&emsp;Typography: Gaye O'Keefe";
            ExtraInfo += "<br/>&emsp;Keylining: Sarah Feggestad";
            ExtraInfo += "<br/>&emsp;Production: Paul Hanchette";
            ExtraInfo += "<br/>&emsp;Thanks To: James Ward, Tim B. Brown, Bruce Nesmith, Anne Brown, Andia Hayday, Newton H. Ewell, Bill Connors";
            using var ctx = CreateSource("Book of Crypts", releaseDate, ExtraInfo, Edition.e2, Media.module);

            DomainEnum.Lamordia.Appeared("4-9").BindCreatures(Creature.Jellyfish, Creature.FiddlerCrab, Creature.Spider);
            DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.DoctorVictorMordenheim, "4-9").BindAlignment(Alignment.NE);
            DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.KatrinaVonBrandthofen, "4-5, 7-9").BindAlignment(Alignment.LN);
            DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.EliseVonBrandthofen, "4-5, 7-9");
            DomainEnum.Lamordia.AddLivingDarklord(DarklordEnum.Adam, "9");
            DomainEnum.Lamordia.AddLocation(LocationEnum.SchlossMordenheim, "4-9").BindCreatures(Creature.Spider);

            DomainEnum.Valachan.Appeared("9").BindCharacters(CharacterEnum.KatrinaVonBrandthofen);

            DomainEnum.Liffe.BindGroups(GroupEnum.Lendor)
                .BindCreatures(Creature.Spider, Creature.Fly, Creature.Earwig, Creature.Horse, Creature.Cow, Creature.Sheep, Creature.Nosferatu, Creature.MountainLoupGarou, Creature.Human);
            DomainEnum.Liffe.AddSettlement(Settlement.Moondale, "10-20")
                .BindLocations(LocationEnum.MoondaleInn).BindGroups(GroupEnum.AlecRapacionMilitia)
                .BindCreatures(Creature.Spider, Creature.Fly, Creature.Earwig, Creature.Horse, Creature.Cow, Creature.Sheep, Creature.Nosferatu, Creature.MountainLoupGarou)
                .BindCharacters(CharacterEnum.CaptainAlecRapacion, CharacterEnum.Eldon, CharacterEnum.Ravewood, CharacterEnum.DanteLysin);
            DomainEnum.Liffe.AddLocation(LocationEnum.MoondaleInn, "10-11, 13-15, 18-20")
                .BindGroups(GroupEnum.AlecRapacionMilitia)
                .BindCharacters(CharacterEnum.CaptainAlecRapacion, CharacterEnum.Eldon, CharacterEnum.Ravewood, CharacterEnum.DanteLysin)
                .BindCreatures(Creature.Spider, Creature.Fly, Creature.Earwig, Creature.Horse, Creature.Nosferatu);
            DomainEnum.Liffe.AddGroup(GroupEnum.AlecRapacionMilitia, "10-20").BindCharacters(CharacterEnum.CaptainAlecRapacion, CharacterEnum.Ravewood, CharacterEnum.Eldon);
            DomainEnum.Liffe.AddLivingCharacter(CharacterEnum.CaptainAlecRapacion, "10-20").BindCreatures(Creature.MountainLoupGarou, Creature.Human).BindAlignment(Alignment.CE);
            DomainEnum.Liffe.AddLivingCharacter(CharacterEnum.Eldon, "10-13, 15, 20").BindAlignment(Alignment.TN);
            DomainEnum.Liffe.AddLivingCharacter(CharacterEnum.Ravewood, "10-11, 13, 15, 20").BindAlignment(Alignment.TN);
            DomainEnum.Liffe.AddLivingCharacter(CharacterEnum.DanteLysin, "11, 13, 15, 18-20").BindCreatures(Creature.Nosferatu).BindAlignment(Alignment.CN);

            DomainEnum.Liffe.AddSettlement(Settlement.Claveria, "21-29")
                .BindGroups(GroupEnum.Lendor).BindLocations(LocationEnum.NeverwereManor)
                .BindItems(ItemEnum.TalismanOfLendor, ItemEnum.LyronHarpsichordCommanding);
            DomainEnum.Liffe.AddLocation(LocationEnum.NeverwereManor, "21-29")
                .BindCharacters(DarklordEnum.LyronEvensong, CharacterEnum.LadyWindall, CharacterEnum.Rannow)
                .BindItems(ItemEnum.LyronHarpsichordCommanding, ItemEnum.Book.GreatComposers, ItemEnum.Book.FormAndLineInMusic, ItemEnum.Book.PhysicalPropOfSoundProd, ItemEnum.Book.MusicalIntrumentConstruct, ItemEnum.Book.ModesInMusic, ItemEnum.Book.PoetryOfTheMasters, ItemEnum.Book.Sonnets, ItemEnum.Book.AssonanceAndAlliteration, ItemEnum.Book.AdvancesInAnatomy, ItemEnum.Book.VertebrateBiology, ItemEnum.Book.SketchingNudes, ItemEnum.Book.PortfolioOfBirds, ItemEnum.Book.PrinciplesOfPerspective, ItemEnum.Book.ArtOfArchitecture, ItemEnum.Book.TreatiseOfFreeGovern, ItemEnum.Book.DeclineOfFeudHold, ItemEnum.Book.PhilosophyOfDeath, ItemEnum.Book.StudyInDarkness, ItemEnum.Book.DiaryOfBaronLyronEvensong1, ItemEnum.Book.DiaryOfBaronLyronEvensong2, ItemEnum.Book.DiaryOfBaronLyronEvensong3, ItemEnum.Book.DiaryOfBaronLyronEvensong4, ItemEnum.Book.DiaryOfBaronLyronEvensong5, ItemEnum.Book.PoemsOfBaronLyronEvensong, ItemEnum.Book.ImbuingInstrumentsWithMagic);
            DomainEnum.Liffe.AddLivingDarklord(DarklordEnum.LyronEvensong, "21-29").BindAlignment(Alignment.NE)
                .BindItems(ItemEnum.LyronHarpsichordCommanding, ItemEnum.Book.DiaryOfBaronLyronEvensong1, ItemEnum.Book.DiaryOfBaronLyronEvensong2, ItemEnum.Book.DiaryOfBaronLyronEvensong3, ItemEnum.Book.DiaryOfBaronLyronEvensong4, ItemEnum.Book.DiaryOfBaronLyronEvensong5, ItemEnum.Book.PoemsOfBaronLyronEvensong)
                .BindSetting(CampaignSetting.Dragonlance).BindCurse("He would live through a century in dark solitude, confined to his study for one hundred years for every one day he spends in Claviera. Thus, when a week passes in the outside world, Baron Claviera has lived 700 years in his study.");
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.Lendor, "22")
                .BindGroups(GroupEnum.Deity, GroupEnum.Lendor)
                .BindItems(ItemEnum.TalismanOfLendor);
            DomainEnum.Liffe.AddDeadCharacter(CharacterEnum.LadyWindall, "27");
            DomainEnum.Liffe.AddDeadCharacter(CharacterEnum.Rannow, "27");
            DomainEnum.Liffe.AddItem(ItemEnum.TalismanOfLendor, "22");
            DomainEnum.Liffe.AddItem(ItemEnum.LyronHarpsichordCommanding, "25-27");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.GreatComposers, "26");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.FormAndLineInMusic, "26");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.PhysicalPropOfSoundProd, "26");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.MusicalIntrumentConstruct, "26");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.ModesInMusic, "26");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.PoetryOfTheMasters, "26");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.Sonnets, "26");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.AssonanceAndAlliteration, "26");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.AdvancesInAnatomy, "26");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.VertebrateBiology, "26");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.SketchingNudes, "26");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.PortfolioOfBirds, "26");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.PrinciplesOfPerspective, "26");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.ArtOfArchitecture, "26");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.TreatiseOfFreeGovern, "26");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.DeclineOfFeudHold, "27");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.PhilosophyOfDeath, "27");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.StudyInDarkness, "27");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.DiaryOfBaronLyronEvensong1, "27");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.DiaryOfBaronLyronEvensong2, "27");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.DiaryOfBaronLyronEvensong3, "27");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.DiaryOfBaronLyronEvensong4, "27");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.DiaryOfBaronLyronEvensong5, "27");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.PoemsOfBaronLyronEvensong, "27");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.ImbuingInstrumentsWithMagic, "27");

            DomainEnum.Liffe.AddSettlement(Settlement.Armeikos, "30-39")
                .BindLocations(LocationEnum.ArmeikosConstable, LocationEnum.HordumRiver, LocationEnum.HordumBay, LocationEnum.SoundOfLiffe, LocationEnum.HouseOfAlisia, LocationEnum.HouseOfEronNalwand, LocationEnum.HouseOfTheaGyntheos, LocationEnum.HouseOfSinaraDoom)
                .BindCharacters(CharacterEnum.JovisBlackwere, CharacterEnum.EjrikSpellbender, CharacterEnum.EronNalwand, CharacterEnum.TheaGyntheos, CharacterEnum.Alisia, CharacterEnum.Carl, CharacterEnum.SinaraDoom);
            DomainEnum.Liffe.AddLocation(LocationEnum.ArmeikosConstable, "30-31")
                .BindCharacters(CharacterEnum.JovisBlackwere);
            DomainEnum.Liffe.AddLocation(LocationEnum.HordumRiver, "31");
            DomainEnum.Liffe.AddLocation(LocationEnum.HordumBay, "31");
            DomainEnum.Liffe.AddLocation(LocationEnum.SoundOfLiffe, "31");
            DomainEnum.Liffe.AddLocation(LocationEnum.HouseOfAlisia, "32-33").BindCharacters(CharacterEnum.Alisia, CharacterEnum.Carl);
            DomainEnum.Liffe.AddLocation(LocationEnum.HouseOfEronNalwand, "33-34").BindCharacters(CharacterEnum.EronNalwand);
            DomainEnum.Liffe.AddLocation(LocationEnum.HouseOfTheaGyntheos, "34-37").BindCharacters(CharacterEnum.TheaGyntheos).BindItems(ItemEnum.Book.TheasDiary, ItemEnum.HeartOfEjrikSpellbender);
            DomainEnum.Liffe.AddLocation(LocationEnum.HouseOfSinaraDoom, "36").BindCharacters(CharacterEnum.SinaraDoom);
            DomainEnum.Liffe.AddLivingCharacter(CharacterEnum.JovisBlackwere, "30-33, 37, 39").BindCreatures(Creature.Human).BindAlignment(Alignment.LN);
            DomainEnum.Liffe.AddLivingCharacter(CharacterEnum.EjrikSpellbender, "30-39").BindItems(ItemEnum.HeartOfEjrikSpellbender).BindAlignment(Alignment.NE);
            DomainEnum.Liffe.AddDeadCharacter(CharacterEnum.EronNalwand, "31, 33-34");
            DomainEnum.Liffe.AddDeadCharacter(CharacterEnum.TheaGyntheos, "31, 34-38").BindItems(ItemEnum.Book.TheasDiary);
            DomainEnum.Liffe.AddLivingCharacter(CharacterEnum.Alisia, "31-33, 36-37").BindItems(ItemEnum.Scroll.SpeakWithDead);
            DomainEnum.Liffe.AddLivingCharacter(CharacterEnum.Carl, "33, 37").BindAlignment(Alignment.LN);
            DomainEnum.Liffe.AddLivingCharacter(CharacterEnum.SinaraDoom, "35-36, 38");
            DomainEnum.Liffe.AddItem(ItemEnum.Scroll.SpeakWithDead, "33");
            DomainEnum.Liffe.AddItem(ItemEnum.Book.TheasDiary, "35-36");
            DomainEnum.Liffe.AddItem(ItemEnum.HeartOfEjrikSpellbender, "36-38");

            DomainEnum.Borca.Appeared("40-49").BindCreatures(Creature.Ermordenung, Creature.EvilTreant, Creature.DollGolem, Creature.Wolf);
            DomainEnum.Borca.AddSettlement(Settlement.Sturben, "49").BindCharacters(CharacterEnum.EleniaWindalla);
            DomainEnum.Borca.AddSettlement(Settlement.Levkarest, "49").BindCharacters(CharacterEnum.EleniaWindalla);
            DomainEnum.Borca.AddLivingDarklord(DarklordEnum.IvanaBoritsi, "40, 47, 49").BindRelatedCreatures(Creature.Ermordenung);
            DomainEnum.Borca.AddLivingCharacter(CharacterEnum.EleniaWindalla, "40-49").BindCreatures(Creature.Ermordenung).BindRelatedCreatures(Creature.EvilTreant, Creature.DollGolem, Creature.Wolf).BindItems(ItemEnum.Ring.MindShield).BindAlignment(Alignment.LE);
            DomainEnum.Borca.AddDeadCharacter(CharacterEnum.UncleDory, "42, 44, 46").BindCharacters(CharacterEnum.EleniaWindalla).BindRelatedCreatures(Creature.EvilTreant);
            DomainEnum.Borca.AddLivingCharacter(CharacterEnum.MadameNygar, "45-46").BindGroups(GroupEnum.Vistani, GroupEnum.Raunie);
            DomainEnum.Borca.AddItem(ItemEnum.Ring.MindShield, "42, 48");
            DomainEnum.Borca.AddGroup(GroupEnum.Vistani, "44-46");
            DomainEnum.Borca.AddGroup(GroupEnum.Raunie, "44-46");

            DomainEnum.InsideRavenloft.AddSettlement(Settlement.Aferdale, "50-53")
                .BindCreatures(Creature.Cow)
                .BindLocations(LocationEnum.BaggsFarm, LocationEnum.AferdaleCemetery, LocationEnum.WeppesInn, LocationEnum.AdventuresRest)
                .BindGroups(GroupEnum.Malar)
                .BindCharacters(CharacterEnum.Malisha, CharacterEnum.Abane, CharacterEnum.Baggs);

            DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.Malar, "50, 52").BindGroups(GroupEnum.Deity, GroupEnum.Malar).BindSetting(CampaignSetting.ForgottenRealms);
            DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.Malisha, "50").BindGroups(GroupEnum.Malar).BindCreatures(Creature.Illithid);
            DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.Abane, "50-51");
            DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.Baggs, "51-53");
            DomainEnum.InsideRavenloft.AddDeadCharacter(CharacterEnum.Dara, "51-53").BindCreatures(Creature.Ghost).BindAlignment(Alignment.TN);
            DomainEnum.InsideRavenloft.AddDeadCharacter(CharacterEnum.DanielHireman, "53");

            DomainEnum.InsideRavenloft.AddLocation(LocationEnum.BaggsFarm, "51-52").BindCharacters(CharacterEnum.Baggs);
            DomainEnum.InsideRavenloft.AddLocation(LocationEnum.AferdaleCemetery, "52");
            DomainEnum.InsideRavenloft.AddLocation(LocationEnum.WeppesInn, "52-53");
            DomainEnum.InsideRavenloft.AddLocation(LocationEnum.AdventuresRest, "53");

            DomainEnum.InsideRavenloft.AddGroup(GroupEnum.Malar, "50, 52").BindSetting(CampaignSetting.ForgottenRealms);
        }
    }
}