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

            DomainEnum.Barovia.Appeared()
                .BindCreatures(Creature.Horse, Creature.Wolf, Creature.Sheep, Creature.VistaChiri, Creature.Elf, Creature.GoldenElf, Creature.Squirrel, Creature.GrayFox, Creature.BrownHare, Creature.Deer, Creature.Owl, Creature.Skeleton, Creature.Cow, Creature.Spider, Creature.Zombie, Creature.Rabbit, Creature.Trout, Creature.Pig, Creature.Fox, Creature.Dog);

            Creature.GrayFox.BindCreatures(Creature.Fox);
            Creature.Rabbit.BindCreatures(Creature.Hare);

            DomainEnum.Barovia.AddLocation(LocationEnum.CastleRavenloft).BindGroups(GroupEnum.VonZarovich)
                .BindCharacters(DarklordEnum.CountStrahd, CharacterEnum.JanderSunstar, CharacterEnum.Natasha, CharacterEnum.HighPriestKir, CharacterEnum.KatrinaYakovlenaPulchenka, CharacterEnum.Irina, CharacterEnum.Marya, CharacterEnum.Shura, CharacterEnum.Anton)
                .BindCreatures(Creature.Horse, Creature.Vampire, Creature.Wolf, Creature.Skeleton, Creature.Spider, Creature.Zombie, Creature.Werewolf, Creature.Dog)
                .BindItems(ItemEnum.StrahdCarriage, ItemEnum.Book.CoatsOfArmsVonZarovich, ItemEnum.Book.SkinAndSteelHistoryBaalVerzi, ItemEnum.Book.LegendsFromTheCircle, ItemEnum.Book.TalesOfTheNight, ItemEnum.Book.ArtOfKalimarKandru, ItemEnum.Book.BaroviaYear15ToPresent, ItemEnum.Book.WordsOfWisdom, ItemEnum.HawksAndHares, ItemEnum.Book.TomeOfStrahd);
            DomainEnum.Barovia.AddLocation(LocationEnum.OldSvalichRoad, "3").BindCreatures(Creature.Horse);
            DomainEnum.Barovia.AddLocation(LocationEnum.SvalichWoods, "3, 83, 85, 94, 103, 125, 160, 239")
                .BindCreatures(Creature.Horse, Creature.Squirrel, Creature.GrayFox, Creature.BrownHare, Creature.Deer, Creature.Wolf, Creature.Owl);
            DomainEnum.Barovia.AddLocation(LocationEnum.BurgomasterHome, "26-27, 37, 63, 65-66, 122, 132, 137-142, 154-158, 160-163, 199-206")
                .BindCharacters(CharacterEnum.BurgomasterKartov, CharacterEnum.AnastasiaKartova, CharacterEnum.LudmillaKartova, CharacterEnum.AlexiSashaPetrovich, CharacterEnum.Ivan2, CharacterEnum.BurgomasterRadavich)
                .BindCreatures(Creature.Horse);
            DomainEnum.Barovia.AddLocation(LocationEnum.StoneCircle, "3, 28, 134-136, 152-153, 204")
                .BindCharacters(CharacterEnum.AnastasiaKartova, CharacterEnum.Petya)
                .BindGroups(GroupEnum.HighPriestMostHoly)
                .BindItems(ItemEnum.SymbolOfRaven)
                .BindCreatures(Creature.Horse, Creature.Rabbit, Creature.Owl);
            DomainEnum.Barovia.AddLocation(LocationEnum.WolfsDen, "30-35, 37, 94, 123, 136-137, 167-168, 244")
                .BindCharacters(CharacterEnum.Petya, CharacterEnum.JanderSunstar, CharacterEnum.BurgomasterKartov, CharacterEnum.Andrei)
                .BindItems(ItemEnum.Drink.Tuika);
            DomainEnum.Barovia.AddLocation(LocationEnum.BurgomasterWay, "36-37, 137, 153")
                .BindCharacters(CharacterEnum.BurgomasterKartov)
                .BindGroups(GroupEnum.Burgomaster, GroupEnum.BurgomasterOfBarovia);
            DomainEnum.Barovia.AddLocation(LocationEnum.MaruschkaVardo, "52-58")
                .BindCharacters(CharacterEnum.Maruschka, CharacterEnum.Pika);
            DomainEnum.Barovia.AddLocation(LocationEnum.TserPool, "60");
            DomainEnum.Barovia.AddLocation(LocationEnum.GatesOfBarovia, "71");
            DomainEnum.Barovia.AddLocation(LocationEnum.BaroviaChurch, "82, 129-131, 150, 163, 169, 187-190, 206-207, 210, 214-216")
                .BindCharacters(CharacterEnum.MartynPelkar, CharacterEnum.AlexiSashaPetrovich, CharacterEnum.KatrinaYakovlenaPulchenka, CharacterEnum.Cristina, CharacterEnum.Leisl)
                .BindItems(ItemEnum.SunCup);
            DomainEnum.Barovia.AddLocation(LocationEnum.RiverIvlis, "94, 103, 209, 217-218, 239");
            DomainEnum.Barovia.AddLocation(LocationEnum.Balinoks, "120");
            DomainEnum.Barovia.AddLocation(LocationEnum.BaroviaBakery, "129, 132")
                .BindCharacters(CharacterEnum.VladRastolnikov, CharacterEnum.KolyaKalinov);
            DomainEnum.Barovia.AddLocation(LocationEnum.BaroviaMarketStreet, "129-130, 153, 187").BindLocations(LocationEnum.BaroviaChurch);
            DomainEnum.Barovia.AddLocation(LocationEnum.BaroviaSeamstressShop, "132, 153, 194-196").BindCharacters(CharacterEnum.Cristina);
            DomainEnum.Barovia.AddLocation(LocationEnum.BaroviaPigPen, "166-167").BindCreatures(Creature.Pig);

            DomainEnum.Barovia.AddSettlement(Settlement.TserPoolEncampment, "39, 41, 44-61")
                .BindLocations(LocationEnum.MaruschkaVardo)
                .BindCharacters(CharacterEnum.Petya, CharacterEnum.Maruschka, CharacterEnum.Lara, CharacterEnum.Keva, CharacterEnum.MadamEva, CharacterEnum.Pika, CharacterEnum.JanderSunstar)
                .BindGroups(GroupEnum.Vistani, GroupEnum.Raunie);
            DomainEnum.Barovia.AddSettlement(Settlement.Barovia)
                .BindCreatures(Creature.Wolf, Creature.Trout, Creature.Horse, Creature.Sheep, Creature.Pig)
                .BindLocations(LocationEnum.WolfsDen, LocationEnum.BurgomasterWay, LocationEnum.BurgomasterHome, LocationEnum.BaroviaChurch, LocationEnum.BaroviaBakery, LocationEnum.BaroviaMarketStreet, LocationEnum.BaroviaSeamstressShop)
                .BindCharacters(CharacterEnum.AnastasiaKartova, CharacterEnum.LudmillaKartova, CharacterEnum.Petya, CharacterEnum.Yelena, CharacterEnum.OlyaIvanova, CharacterEnum.BurgomasterKartov, CharacterEnum.Andrei, CharacterEnum.Ivan, CharacterEnum.Ivan2, CharacterEnum.JanderSunstar, CharacterEnum.Tatyana, CharacterEnum.Vlad, CharacterEnum.Mikhail, CharacterEnum.Irina, CharacterEnum.Igor, CharacterEnum.VladRastolnikov, CharacterEnum.KolyaKalinov, CharacterEnum.AlexiSashaPetrovich, CharacterEnum.Cristina, CharacterEnum.Leisl, CharacterEnum.KatrinaYakovlenaPulchenka, CharacterEnum.Ivar, CharacterEnum.Tatyana, CharacterEnum.Yakov)
                .BindGroups(GroupEnum.Burgomaster, GroupEnum.BurgomasterOfBarovia);
            DomainEnum.Barovia.AddSettlement(Settlement.Vallaki, "81-82, 103, 122, 127, 135, 168, 173")
                .BindCharacters(CharacterEnum.PavelIvanovich);

            DomainEnum.Barovia.AddLivingDarklord(DarklordEnum.CountStrahd).BindGroups(GroupEnum.VonZarovich)
                .BindCharacters(CharacterEnum.Irina, CharacterEnum.Marya, CharacterEnum.Shura, CharacterEnum.Anton, CharacterEnum.KingBarov, CharacterEnum.Ravenovia, CharacterEnum.Sergei, CharacterEnum.Sturm)
                .BindCreatures(Creature.Vampire).BindRelatedCreatures(Creature.Wolf, Creature.Horse, Creature.Skeleton, Creature.Zombie)
                .BindItems(ItemEnum.StrahdCarriage, ItemEnum.Book.CoatsOfArmsVonZarovich, ItemEnum.Book.SkinAndSteelHistoryBaalVerzi, ItemEnum.Book.LegendsFromTheCircle, ItemEnum.Book.TalesOfTheNight, ItemEnum.Book.ArtOfKalimarKandru, ItemEnum.Book.BaroviaYear15ToPresent, ItemEnum.Book.WordsOfWisdom, ItemEnum.HawksAndHares, ItemEnum.Book.TomeOfStrahd);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.JanderSunstar).BindCreatures(Creature.GoldenElf, Creature.Elf, Creature.Vampire, Creature.Bat, Creature.Wolf).BindSetting(CampaignSetting.ForgottenRealms).BindRelatedCreatures(Creature.Wolf);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Anna).BindGroups(GroupEnum.Tatyana).BindSetting(CampaignSetting.ForgottenRealms).BindDomains(DomainEnum.OutsideRavenloft);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.AnastasiaKartova, "26-29, 34, 36-38, 63-66, 122-126, 132-134, 138, 140-141, 155, 157-158, 160-162, 204-205, 260")
                .BindCharacters(CharacterEnum.AlexiSashaPetrovich);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.LudmillaKartova, "26, 63, 132-133, 138-139, 142, 156-157, 163-164, 200-201")
                .BindCharacters(CharacterEnum.AnastasiaKartova);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Petya, "27-45, 47-51, 54-57, 60-65, 122, 124-125, 204-205, 209, 211, 262")
                .BindGroups(GroupEnum.EvaVistani, GroupEnum.Vistani)
                .BindCharacters(CharacterEnum.Maruschka, CharacterEnum.AnastasiaKartova, CharacterEnum.AlexiSashaPetrovich, CharacterEnum.MadamEva)
                .BindLanguages(Language.Vistani)
                .BindRelatedCreatures(Creature.Horse);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Yelena, "27, 66");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.OlyaIvanova, "32, 43, 49, 258")
                .BindCharacters(CharacterEnum.Ivan).BindGroups(GroupEnum.Tatyana);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.BurgomasterKartov, "27-29, 33-36, 63-65, 122-123, 137, 140, 154-155, 158, 162")
                .BindGroups(GroupEnum.Burgomaster, GroupEnum.BurgomasterOfBarovia)
                .BindCharacters(CharacterEnum.AnastasiaKartova, CharacterEnum.LudmillaKartova, CharacterEnum.AlexiSashaPetrovich);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Andrei, "33, 35, 154, 165");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Maruschka, "42, 46-58, 60-63")
                .BindGroups(GroupEnum.EvaVistani, GroupEnum.Vistani)
                .BindCharacters(CharacterEnum.MadamEva)
                .BindLanguages(Language.Vistani)
                .BindRelatedCreatures(Creature.Horse, Creature.Crow, Creature.Raven);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Lara, "46-47").BindGroups(GroupEnum.EvaVistani, GroupEnum.Vistani);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Keva, "47").BindGroups(GroupEnum.EvaVistani, GroupEnum.Vistani);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.MadamEva, "47-49, 52-53, 59-62, 66, 81").BindGroups(GroupEnum.Vistani, GroupEnum.EvaVistani, GroupEnum.Raunie);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Ivan, "32, 49");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Ivan2, "64-65, 156").BindCharacters(CharacterEnum.BurgomasterKartov);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Pika, "54").BindCharacters(CharacterEnum.Maruschka).BindCreatures(Creature.Crow, Creature.Raven).ExtraInfo = "It's a black bird";
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Natasha, "87-89, 91, 93, 101-102, 108, 115, 117, 121-122, 127, 192");
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.TormTheTrue, "95").BindGroups(GroupEnum.Deity, GroupEnum.TormTheTrue).BindSetting(CampaignSetting.ForgottenRealms);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.MartynPelkar, "94-97, 128-131, 159-164, 169, 187-191, 201-202, 206-207, 265")
                .BindGroups(GroupEnum.Lathander);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.Lathander, "97, 128-130, 150, 162-163, 186-190, 201-202, 205, 207, 212, 219, 230-231, 261, 263")
                .BindGroups(GroupEnum.Deity, GroupEnum.Lathander).BindSetting(CampaignSetting.ForgottenRealms).BindItems(ItemEnum.SunCup);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Tatyana, "111").BindCharacters(DarklordEnum.CountStrahd);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.HighPriestKir, "1-3, 111, 249")
                .BindGroups(GroupEnum.HighPriestMostHoly).BindItems(ItemEnum.SymbolOfRaven);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Vlad, "123");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Mikhail, "123");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Irina, "123, 177-178, 192").BindCreatures(Creature.Vampire).BindCharacters(CharacterEnum.Igor);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Igor, "123");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.VladRastolnikov, "129-130, 132, 153-154, 158-159");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.KolyaKalinov, "129-136, 152-154, 159, 165, 169");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.AlexiSashaPetrovich, "129-136, 152-164, 168-169, 187-191, 202-207, 210-219, 221, 228-231, 260-266")
                .BindGroups(GroupEnum.HalfVistani,GroupEnum.Lathander).BindItems(ItemEnum.VialOfHolyWater);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.PavelIvanovich, "135, 157");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Cristina, "132, 153, 165, 188-190, 194-197").BindGroups(GroupEnum.Lathander);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Leisl, "165-169, 180, 213-219, 228-230").BindGroups(GroupEnum.Lathander);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.KatrinaYakovlenaPulchenka, "167-169, 172-173, 176-181, 188-192, 206-208, 214-222, 229-233, 265")
                .BindCreatures(Creature.Werewolf).BindGroups(GroupEnum.Lathander);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Ivar, "189").BindCharacters(CharacterEnum.Cristina);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.BurgomasterRadavich, "200-201")
                .BindGroups(GroupEnum.Burgomaster, GroupEnum.BurgomasterOfBarovia).BindCharacters(CharacterEnum.LudmillaKartova);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Marya, "221").BindCreatures(Creature.Vampire);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Shura, "221").BindCreatures(Creature.Vampire);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.KingBarov, "234-235, 241").BindGroups(GroupEnum.VonZarovich);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Ravenovia, "234-235, 238, 241").BindGroups(GroupEnum.VonZarovich);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Sturm, "235, 241-242").BindGroups(GroupEnum.VonZarovich);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Sergei, "235-236, 238-245, 247, 249-256, 265")
                .BindGroups(GroupEnum.VonZarovich).BindCharacters(CharacterEnum.Tatyana);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Tatyana, "236-237, 240-247, 249, 251, 254-256, 258-260, 265-266").BindGroups(GroupEnum.Tatyana);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Yakov, "244-245");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Anton, "253");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Marina, "258").BindGroups(GroupEnum.Tatyana);

            DomainEnum.Barovia.AddGroup(GroupEnum.HighPriestMostHoly, "1-3, 111, 249");
            DomainEnum.Barovia.AddGroup(GroupEnum.Tatyana).BindDomains(DomainEnum.OutsideRavenloft);
            DomainEnum.Barovia.AddGroup(GroupEnum.Vistani, "27-66, 70, 76, 82-83, 86, 93, 103, 122-124, 153-154, 158-159, 166-168, 189, 191, 204-205, 220-221")
                .BindLanguages(Language.Vistani)
                .BindCreatures(Creature.VistaChiri, Creature.Horse, Creature.Dog, Creature.Goat, Creature.Chicken, Creature.Sheep);
            DomainEnum.Barovia.AddGroup(GroupEnum.Raunie, "47-49, 52-53, 59-62, 66").BindGroups(GroupEnum.Vistani);
            DomainEnum.Barovia.AddGroup(GroupEnum.Burgomaster, "27-29, 33-36, 63-65, 122-123, 134, 137, 140-141, 165, 193, 195, 199-201, 203, 215, 239")
                .BindGroups(GroupEnum.BurgomasterOfBarovia);
            DomainEnum.Barovia.AddGroup(GroupEnum.BurgomasterOfBarovia, "27-29, 33-36, 63-65, 122-123, 134, 137, 140-141, 165, 193, 195, 199-201, 203, 215");
            DomainEnum.Barovia.AddGroup(GroupEnum.TormTheTrue, "95").BindSetting(CampaignSetting.ForgottenRealms);
            DomainEnum.Barovia.AddGroup(GroupEnum.Lathander, "97, 150, 162-163, 186-190, 201-202, 205, 212, 219, 230-231").BindSetting(CampaignSetting.ForgottenRealms);
            DomainEnum.Barovia.AddGroup(GroupEnum.EvaVistani, "27-66, 70, 76, 82-83, 86, 93, 122-124, 166-168, 191, 204-205, 220-221").BindGroups(GroupEnum.Vistani);
            DomainEnum.Barovia.AddGroup(GroupEnum.HalfVistani, "123, 132, 153, 156, 158, 189, 207").BindGroups(GroupEnum.Vistani);
            DomainEnum.Barovia.AddGroup(GroupEnum.LostOnes, "158, 170");
            DomainEnum.Barovia.AddGroup(GroupEnum.VonZarovich, "234-235, 238, 240, 242");
            DomainEnum.Barovia.AddGroup(GroupEnum.DarkPowers, "246-247");
            DomainEnum.Barovia.AddGroup(GroupEnum.BaalVerzi, "91-92, 251-253");
            DomainEnum.Barovia.AddGroup(GroupEnum.Kartov).BindCharacters(CharacterEnum.BurgomasterKartov, CharacterEnum.AnastasiaKartova, CharacterEnum.LudmillaKartova, CharacterEnum.AlexiSashaPetrovich);

            DomainEnum.Barovia.AddItem(ItemEnum.SymbolOfRaven, "1-2, 120");
            DomainEnum.Barovia.AddItem(ItemEnum.Drink.Tuika, "31");
            DomainEnum.Barovia.AddItem(ItemEnum.Food.BarovianPlums, "47");
            DomainEnum.Barovia.AddItem(ItemEnum.StrahdCarriage, "69-71, 88, 193, 198-199").BindCreatures(Creature.Horse);
            DomainEnum.Barovia.AddItem(ItemEnum.Book.CoatsOfArmsVonZarovich, "91");
            DomainEnum.Barovia.AddItem(ItemEnum.Book.SkinAndSteelHistoryBaalVerzi, "91-92").BindGroups(GroupEnum.BaalVerzi);
            DomainEnum.Barovia.AddItem(ItemEnum.Book.LegendsFromTheCircle, "92, 100");
            DomainEnum.Barovia.AddItem(ItemEnum.Book.TalesOfTheNight, "92");
            DomainEnum.Barovia.AddItem(ItemEnum.Book.ArtOfKalimarKandru, "92");
            DomainEnum.Barovia.AddItem(ItemEnum.Book.BaroviaYear15ToPresent, "92");
            DomainEnum.Barovia.AddItem(ItemEnum.Book.WordsOfWisdom, "92-93");
            DomainEnum.Barovia.AddItem(ItemEnum.SunCup, "180").BindGroups(GroupEnum.Lathander);
            DomainEnum.Barovia.AddItem(ItemEnum.VialOfHolyWater, "112, 261");
            DomainEnum.Barovia.AddItem(ItemEnum.HawksAndHares, "219-220, 222");
            DomainEnum.Barovia.AddItem(ItemEnum.Book.TomeOfStrahd, "236-237");
        }
    }
}