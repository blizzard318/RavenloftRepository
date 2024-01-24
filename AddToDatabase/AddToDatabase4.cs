using System.Text.RegularExpressions;
using static Factory;

internal static partial class AddToDatabase
{
    public static void Add4()
    {
        AddFeastOfGoblyns();
        AddShipOfHorrors();
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
                .BindAlignment(Alignment.NE | Alignment.LE).BindDomains(DomainEnum.Kartakass)
                .BindCreatures(Creature.Human, Creature.Wight)
                .BindRelatedCreatures(Creature.SkeletonSteed, Creature.Quickwood, Creature.Skeleton, Creature.Goblyn, Creature.GiantSkeleton, Creature.HalfWight)
                .BindCloseBorder("A ring of gobylns 20 creatures deep, constantly feasting on bodies of helpless victims of the border. Those who fly over this border are only temporarily safe as a detachment of goblyns will be sent to hunt them down and kill them");

            DomainEnum.Daglan.AddLivingDarklord(DarklordEnum.Daglan, "1, 11, 13-14, 81-85, 87, 92")
                .BindAlignment(Alignment.CE).BindRelatedCreatures(Creature.Darkenbeast)
                .BindCharacters(DarklordEnum.Radaga);
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
            DomainEnum.Nebligtode.Appeared();
            #endregion

            #region Characters
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Garvyn, "5-6, 8, 10-11, 14-19").BindAlignment(Alignment.CN);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Killian, "6");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Brummett, "10, 12").BindAlignment(Alignment.CG);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Charlotte, "12");
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Ralfeo, "12-13").BindAlignment(Alignment.NG);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Koresh, "13").BindAlignment(Alignment.CN);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Peregrine, "13").BindAlignment(Alignment.NG);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Thorvid, "13").BindAlignment(Alignment.NG);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Vathan, "17").BindGroups(GroupEnum.Vistani, GroupEnum.VincenziaVistani);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Saul, "17").BindGroups(GroupEnum.Vistani, GroupEnum.VincenziaVistani);
            DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Vincenzia, "17-19").BindGroups(GroupEnum.Vistani, GroupEnum.Raunie, GroupEnum.VincenziaVistani);
            #endregion

            #region Locations
            DomainEnum.Nebligtode.AddLocation(LocationEnum.TheEndurance, "2, 6-19, Map").BindCharacters(CharacterEnum.Garvyn, CharacterEnum.Killian, CharacterEnum.Brummett, CharacterEnum.Ralfeo, CharacterEnum.Koresh, CharacterEnum.Peregrine, CharacterEnum.Thorvid);
            DomainEnum.Nebligtode.AddLocation(LocationEnum.GrabenIsland, "2");
            DomainEnum.Nebligtode.AddLocation(LocationEnum.Todstein, "2");
            DomainEnum.Nebligtode.AddLivingDarklord(DarklordEnum.Meredoth, "2");
            DomainEnum.Nebligtode.AddSettlement(Settlement.Graben, "2");
            #endregion

            #region Groups
            DomainEnum.InsideRavenloft.AddGroup(GroupEnum.Vistani, "17-19");
            DomainEnum.InsideRavenloft.AddGroup(GroupEnum.VincenziaVistani, "17-19");
            #endregion
        }
    }
}