using static Factory;

internal static partial class AddToDatabase
{
    public static void Add2() //Novels
    {
        AddBeforeIWake();
        AddMasterOfRavenloft();
        AddVampireOfTheMists();
        void AddBeforeIWake()
        {
            var releaseDate = "31/10/2007";
            string ExtraInfo = "<br/>&emsp;Author: Air Marmell";
            using var ctx = CreateSource("Before I Wake", releaseDate, ExtraInfo, Edition.e0, Media.novel);

            DomainEnum.Darkon.Appeared();
            DomainEnum.Bluetspur.Appeared();
            DomainEnum.Lamordia.Appeared();

            DomainEnum.Darkon.AddSettlement(Settlement.Nartok).BindCharacters(CharacterEnum.HowardAshton, CharacterEnum.Clarke, CharacterEnum.Phillips).BindLocations(LocationEnum.MillsOfNartok);
            DomainEnum.Darkon.AddLocation(LocationEnum.MillsOfNartok).BindCharacters(CharacterEnum.HowardAshton, CharacterEnum.Clarke, CharacterEnum.Phillips);

            DomainEnum.Lamordia.AddLocation(LocationEnum.DharlaethAsylum).BindCharacters(CharacterEnum.HowardAshton, CharacterEnum.DoctorAugustus, CharacterEnum.NurseRoberts).ExtraInfo = "Whilst not stated in the story, Ari Marmell said the Asylum is located in Lamordia.<a href='https://bsky.app/profile/mouseferatu.bsky.social/post/3kelemhzy2l2n'>Bluesky Link</a>";

            DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.Clarke).BindCreatures(Creature.Human)
                .BindDomains(DomainEnum.Bluetspur).ExtraInfo = "Probably deceased";

            DomainEnum.Darkon.AddDeadCharacter(CharacterEnum.Phillips).BindCreatures(Creature.Human)
                .BindDomains(DomainEnum.Bluetspur);

            DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.DoctorAugustus).BindCreatures(Creature.Human);

            DomainEnum.Lamordia.AddDeadCharacter(CharacterEnum.NurseRoberts).BindCreatures(Creature.Human);

            DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.HowardAshton).BindCreatures(Creature.Human)
                .BindDomains(DomainEnum.Bluetspur, DomainEnum.Lamordia);
        }
        void AddMasterOfRavenloft()
        {
            var releaseDate = "01/01/1986";
            string ExtraInfo = "<br/>&emsp;Author: Jean Blashfield Black";
            ExtraInfo += "<br/>&emsp;Cover Art: Clyde Caldwell";
            ExtraInfo += "<br/>&emsp;Interior Art: Gary Williams";
            using var ctx = CreateSource("Master of Ravenloft", releaseDate, ExtraInfo, Edition.e0, Media.novel);

            DomainEnum.Barovia.Appeared();

            #region Locations
            DomainEnum.Barovia.AddLocation(LocationEnum.CastleRavenloft)
                .BindCreatures(Creature.Bat, Creature.Vampire, Creature.Gargoyle, Creature.Mummy,
                                                            Creature.Mimic, Creature.Wolf, Creature.Spectre, Creature.StrahdZombie,
                                                            Creature.Human, Creature.Zombie, Creature.GiantSpider, Creature.Haunt)
                .BindCharacters(DarklordEnum.CountStrahd, CharacterEnum.JerenSureblade, CharacterEnum.IreenaKolyana,
                                                   CharacterEnum.Tatyana, CharacterEnum.KingBarov, CharacterEnum.Ravenovia, CharacterEnum.Sergei)
                .BindItems(ItemEnum.SymbolOfRaven, ItemEnum.IconOfRaven, ItemEnum.Sunsword)
                .BindGroups(GroupEnum.HighPriestRavenloft);

            DomainEnum.Barovia.AddSettlement(Settlement.Barovia, "18, 21, 23, 24, 29, 30, 32, 34, 36, 40, 42-44, 46, 50, 52, 57, 60, 90, 96, 107, 110, 129, 144, 145, 152, 160, 162, 169, 170, 182, 187")
                .BindCreatures(Creature.VampireBat, Creature.Bat, Creature.Horse)
                .BindCharacters(DarklordEnum.CountStrahd, CharacterEnum.JerenSureblade, CharacterEnum.IreenaKolyana, CharacterEnum.FatherDonavich)
                .BindGroups(GroupEnum.Burgomaster, GroupEnum.BurgomasterOfBarovia)
                .BindLocations(LocationEnum.BaroviaChurch);

            DomainEnum.Barovia.AddLocation( LocationEnum.BaroviaChurch, "25, 34, 57, 100, 110, 144, 145, 160, 170")
                .BindCharacters(CharacterEnum.FatherDonavich);
            #endregion

            #region Characters
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.JerenSureblade)
                .BindAlignment(Alignment.LG)
                .BindCreatures(Creature.Human)
                .BindRelatedCreatures(Creature.Horse, Creature.Haunt, Creature.Vampire)
                .BindItems(ItemEnum.Wand.MagMiss, ItemEnum.Luckstone, ItemEnum.VialOfHolyWater, ItemEnum.Chosen,
                                                   ItemEnum.Decanter, ItemEnum.SymbolOfRaven, ItemEnum.IconOfRaven, ItemEnum.Sunsword,
                                                   ItemEnum.Amulet.Light, ItemEnum.Potion.Heal);

            DomainEnum.Barovia.AddLivingCharacter(DarklordEnum.CountStrahd)
                .BindCreatures(Creature.Human, Creature.Vampire, Creature.Bat)
                .BindRelatedCreatures(Creature.StrahdZombie);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.IreenaKolyana)
                .BindItems(ItemEnum.Wand.MagMiss, ItemEnum.Luckstone, ItemEnum.VialOfHolyWater);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Mikhash, "17");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Tatyana, "25, 111");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.FatherDonavich, "34, 57, 144, 160, 170");

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.KingBarov, "45, 98").BindCreatures(Creature.Human);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Ravenovia, "33, 45").BindCreatures(Creature.Human);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Sergei, "107, 183").BindCreatures(Creature.Human);
            #endregion

            #region Items
            DomainEnum.Barovia.AddItem(ItemEnum.Chosen, "1, 6, 7, 15, 23, 24, 28, 34, 39, 44-46, 48, 52, 54, 56-58, 60, 62, 64, 67, 69, 76, 79, 82-85, 87-90, 95-97, 99, 101, 102, 105, 108, 110, 124-128, 131, 135, 136, 141, 148, 150, 153, 154, 156, 158, 165, 166, 168, 170, 171, 173, 176, 184, 188").ExtraInfo = "It is Jeren Sureblade's Rod of Lordly Might";

            DomainEnum.Barovia.AddItem(ItemEnum.Wand.MagMiss, "17, 18, 20, 35, 40, 43, 45, 47, 48, 53, 58, 66, 74, 75, 78, 88, 96, 104, 119, 125, 129, 132, 135, 146, 166, 167, 173, 179");
            DomainEnum.Barovia.AddItem(ItemEnum.Luckstone, "18, 36, 48, 49, 56, 62, 74, 75, 96, 116, 120, 123, 128, 179, 189");
            DomainEnum.Barovia.AddItem(ItemEnum.Decanter, "30, 114, 115, 151, 139, 166, 189");
            DomainEnum.Barovia.AddItem(ItemEnum.SymbolOfRaven, "31, 34, 40, 56, 57, 66, 85, 86, 88, 92, 110, 111, 117, 124, 132, 133, 136, 140, 143-145, 146, 159, 160, 161, 166, 170, 171, 182, 187, 189");
            DomainEnum.Barovia.AddItem(ItemEnum.IconOfRaven, "34, 40, 66, 100, 117, 137-140, 146, 159, 161, 166, 167, 189")
                .BindAlignment(Alignment.LG);
            DomainEnum.Barovia.AddItem(ItemEnum.Sunsword, "46, 49, 50, 51, 53, 61, 65, 74, 76, 85, 88, 92, 98-100, 106, 110, 111, 121, 122, 119, 129, 130, 134, 143, 145, 147-150, 159-162, 166, 177, 181, 189");
            DomainEnum.Barovia.AddItem(ItemEnum.Potion.Heal, "137, 165, 166, 183, 188, 189");
            DomainEnum.Barovia.AddItem(ItemEnum.VialOfHolyWater, "47, 56, 86, 89, 94, 102, 106, 123, 130, 136, 142, 143, 145, 147, 149, 158, 166, 171, 188, 189");
            DomainEnum.Barovia.AddItem(ItemEnum.Amulet.Light, "20, 29, 36, 37, 51, 53, 61, 65, 69, 79, 80, 82, 84, 91, 105, 106, 118, 120, 126, 133, 137, 138, 149, 153, 183");
            #endregion

            #region Groups
            DomainEnum.Barovia.AddGroup(GroupEnum.Vistani, "17, 162")
                .BindCharacters(CharacterEnum.Mikhash);
            DomainEnum.Barovia.AddGroup(GroupEnum.Burgomaster, "42, 111, 145");
            DomainEnum.Barovia.AddGroup(GroupEnum.BurgomasterOfBarovia, "42, 111, 145")
                .BindGroups(GroupEnum.BurgomasterOfBarovia);
            DomainEnum.Barovia.AddGroup(GroupEnum.HighPriestRavenloft, "34, 57, 110, 144")
                .BindItems(ItemEnum.SymbolOfRaven);
            #endregion
        }
        void AddVampireOfTheMists()
        {
            var releaseDate = "01/01/1991";
            string ExtraInfo = "<br/>&emsp;Author: Christie Golden";
            using var ctx = CreateSource("Vampire of the Mists", releaseDate, ExtraInfo, Edition.e0, Media.novel); //Page 12 = 1

            DomainEnum.Barovia.Appeared().BindCreatures(Creature.Horse, Creature.Wolf, Creature.Sheep, Creature.VistaChiri);

            DomainEnum.Barovia.AddLocation(LocationEnum.CastleRavenloft, "1-2, 24-25, 33, 43, 45, 48, 56").BindCreatures(Creature.Horse);
            DomainEnum.Barovia.AddLocation(LocationEnum.OldSvalichRoad, "3").BindCreatures(Creature.Horse);
            DomainEnum.Barovia.AddLocation(LocationEnum.SvalichWoods, "3").BindCreatures(Creature.Horse);
            DomainEnum.Barovia.AddLocation(LocationEnum.StoneCircle, "3, 28")
                .BindCharacters(CharacterEnum.AnastasiaKartova, CharacterEnum.Petya)
                .BindGroups(GroupEnum.HighPriestMostHoly)
                .BindItems(ItemEnum.SymbolOfRaven).BindCreatures(Creature.Horse);
            DomainEnum.Barovia.AddLocation(LocationEnum.WolfsDen, "30-35, 37")
                .BindCharacters(CharacterEnum.Petya, CharacterEnum.JanderSunstar, CharacterEnum.BurgomasterKartov, CharacterEnum.Andrei)
                .BindItems(ItemEnum.Drink.Tuika);
            DomainEnum.Barovia.AddLocation(LocationEnum.BurgomasterWay, "36-37")
                .BindCharacters(CharacterEnum.BurgomasterKartov)
                .BindGroups(GroupEnum.Burgomaster, GroupEnum.BurgomasterOfBarovia);
            DomainEnum.Barovia.AddLocation(LocationEnum.MaruschkaVardo, "52-58")
                .BindCharacters(CharacterEnum.Maruschka, CharacterEnum.Pika);
            DomainEnum.Barovia.AddLocation(LocationEnum.TserPool, "60");

            DomainEnum.Barovia.AddSettlement(Settlement.TserPoolEncampment, "39, 41, 44-61")
                .BindLocations(LocationEnum.MaruschkaVardo)
                .BindCharacters(CharacterEnum.Petya, CharacterEnum.Maruschka, CharacterEnum.Lara, CharacterEnum.Keva, CharacterEnum.MadamEva, CharacterEnum.Pika)
                .BindGroups(GroupEnum.Vistani, GroupEnum.Raunie);
            DomainEnum.Barovia.AddSettlement(Settlement.Barovia)
                .BindCreatures(Creature.Wolf)
                .BindLocations(LocationEnum.WolfsDen)
                .BindCharacters(CharacterEnum.AnastasiaKartova, CharacterEnum.LudmillaKartova, CharacterEnum.Petya, CharacterEnum.Yelena, CharacterEnum.OlyaIvanova, CharacterEnum.BurgomasterKartov, CharacterEnum.Andrei, CharacterEnum.Ivan)
                .BindGroups(GroupEnum.Burgomaster, GroupEnum.BurgomasterOfBarovia);

            DomainEnum.Barovia.AddLivingDarklord(DarklordEnum.CountStrahd).BindRelatedCreatures(Creature.Wolf);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.JanderSunstar).BindCreatures(Creature.GoldenElf, Creature.Vampire).BindSetting(CampaignSetting.ForgottenRealms).BindRelatedCreatures(Creature.Wolf);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Anna, "1, 10-22, 27, 31, 58").BindGroups(GroupEnum.Tatyana).BindSetting(CampaignSetting.ForgottenRealms).BindDomains(DomainEnum.OutsideRavenloft);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.AnastasiaKartova, "26-29, 34, 36-38, 63-65");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.LudmillaKartova, "26, 63");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Petya, "27-45, 47-51, 54-57, 60-65")
                .BindGroups(GroupEnum.Vistani).BindLanguages(Language.Vistani).BindRelatedCreatures(Creature.Horse);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Yelena, "27");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.OlyaIvanova, "32, 43, 49").BindCharacters(CharacterEnum.Ivan);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.BurgomasterKartov, "27-29, 33-36, 63-65").BindGroups(GroupEnum.Burgomaster, GroupEnum.BurgomasterOfBarovia).BindCharacters(CharacterEnum.AnastasiaKartova, CharacterEnum.LudmillaKartova);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Andrei, "33, 35");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Maruschka, "42, 46-58, 60-63").BindGroups(GroupEnum.Vistani).BindCharacters(CharacterEnum.Andrei).BindLanguages(Language.Vistani).BindRelatedCreatures(Creature.Horse, Creature.Crow, Creature.Raven);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Lara, "46-47").BindGroups(GroupEnum.Vistani);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Keva, "47").BindGroups(GroupEnum.Vistani);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.MadamEva, "47-49, 52-53, 59-62").BindGroups(GroupEnum.Vistani, GroupEnum.Raunie);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Ivan, "32, 49");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Ivan2, "64-65");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Pika, "54").BindCharacters(CharacterEnum.Maruschka).BindCreatures(Creature.Crow, Creature.Raven).ExtraInfo = "It's a black bird";

            DomainEnum.Barovia.AddGroup(GroupEnum.HighPriestMostHoly, "1-3");
            DomainEnum.Barovia.AddGroup(GroupEnum.Tatyana).BindDomains(DomainEnum.OutsideRavenloft);
            DomainEnum.Barovia.AddGroup(GroupEnum.Vistani, "27-65")
                .BindLanguages(Language.Vistani)
                .BindCreatures(Creature.VistaChiri, Creature.Horse, Creature.Dog, Creature.Goat, Creature.Chicken);
            DomainEnum.Barovia.AddGroup(GroupEnum.Raunie, "47-49, 52-53, 59-60");
            DomainEnum.Barovia.AddGroup(GroupEnum.Burgomaster, "27-29, 33-35").BindGroups(GroupEnum.BurgomasterOfBarovia);
            DomainEnum.Barovia.AddGroup(GroupEnum.BurgomasterOfBarovia, "27-29, 33-35");

            DomainEnum.Barovia.AddItem(ItemEnum.SymbolOfRaven, "1-2");
            DomainEnum.Barovia.AddItem(ItemEnum.Drink.Tuika, "31");
            DomainEnum.Barovia.AddItem(ItemEnum.Food.BarovianPlums, "47");
        }
    }
}