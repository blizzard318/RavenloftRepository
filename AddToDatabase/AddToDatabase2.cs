using static Factory;

internal static partial class AddToDatabase
{
    public static void Add2()
    {
        AddBeforeIWake();
        AddMasterOfRavenloft();
        void AddBeforeIWake()
        {
            var releaseDate = "31/10/2007";
            string ExtraInfo = "<br/>&emsp;Author: Air Marmell";
            using var ctx = CreateSource("Before I Wake", releaseDate, ExtraInfo, Edition.e0, Media.novel);

            DomainEnum.Darkon.Appeared();
            DomainEnum.Bluetspur.Appeared();
            DomainEnum.Lamordia.Appeared();

            DomainEnum.Darkon.AddSettlement(Settlement.Nartok).BindCharacters(CharacterEnum.HowardAshton, CharacterEnum.Clarke, CharacterEnum.Phillips);
            DomainEnum.Darkon.AddLocation(LocationEnum.MillsOfNartok).BindCharacters(CharacterEnum.HowardAshton, CharacterEnum.Clarke, CharacterEnum.Phillips);

            DomainEnum.Lamordia.AddLocation(LocationEnum.DharlaethAsylum).BindCharacters(CharacterEnum.HowardAshton, CharacterEnum.DoctorAugustus, CharacterEnum.NurseRoberts).ExtraInfo = "Whilst not stated in the story, Ari Marmell said the Asylum is located in Lamordia.<a href='https://bsky.app/profile/mouseferatu.bsky.social/post/3kelemhzy2l2n'>Bluesky Link</a>";

            DomainEnum.Bluetspur.AddLivingCharacter(CharacterEnum.Clarke);
            DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.Clarke);
            CharacterEnum.Clarke.BindCreatures(Creature.Human).ExtraInfo = "Probably deceased";

            DomainEnum.Bluetspur.AddDeadCharacter(CharacterEnum.Phillips);
            DomainEnum.Darkon.AddDeadCharacter(CharacterEnum.Phillips).BindCreatures(Creature.Human);

            DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.DoctorAugustus).BindCreatures(Creature.Human);

            DomainEnum.Lamordia.AddDeadCharacter(CharacterEnum.NurseRoberts).BindCreatures(Creature.Human);

            DomainEnum.Bluetspur.AddLivingCharacter(CharacterEnum.HowardAshton);
            DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.HowardAshton);
            DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.HowardAshton);
            CharacterEnum.HowardAshton.BindCreatures(Creature.Human);
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
                .BindCharacters(CharacterEnum.CountStrahd, CharacterEnum.JerenSureblade, CharacterEnum.IreenaKolyana,
                                                   CharacterEnum.Tatyana, CharacterEnum.KingBarov, CharacterEnum.Ravenovia, CharacterEnum.Sergei)
                .BindItems(ItemEnum.SymbolOfRaven, ItemEnum.IconOfRaven, ItemEnum.Sunsword)
                .BindGroups(GroupEnum.HighPriestRavenloft);

            DomainEnum.Barovia.AddSettlement(Settlement.Barovia, "18, 21, 23, 24, 29, 30, 32, 34, 36, 40, 42-44, 46, 50, 52, 57, 60, 90, 96, 107, 110, 129, 144, 145, 152, 160, 162, 169, 170, 182, 187")
                .BindCreatures(Creature.VampireBat, Creature.Bat, Creature.Horse)
                .BindCharacters(CharacterEnum.CountStrahd, CharacterEnum.JerenSureblade, CharacterEnum.IreenaKolyana, CharacterEnum.FatherDonavich)
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
                .BindItems(ItemEnum.WandOfMM, ItemEnum.Luckstone, ItemEnum.VialOfHolyWater, ItemEnum.Chosen,
                                                   ItemEnum.Decanter, ItemEnum.SymbolOfRaven, ItemEnum.IconOfRaven, ItemEnum.Sunsword,
                                                   ItemEnum.AmuletOfLight, ItemEnum.PotOfHeal);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.CountStrahd)
                .BindCreatures(Creature.Human, Creature.Vampire, Creature.Bat)
                .BindRelatedCreatures(Creature.StrahdZombie);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.IreenaKolyana)
                .BindItems(ItemEnum.WandOfMM, ItemEnum.Luckstone, ItemEnum.VialOfHolyWater);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Mikhash, "17");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Tatyana, "25, 111");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.FatherDonavich, "34, 57, 144, 160, 170");

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.KingBarov, "45, 98").BindCreatures(Creature.Human);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Ravenovia, "33, 45").BindCreatures(Creature.Human);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Sergei, "107, 183").BindCreatures(Creature.Human);
            #endregion

            #region Items
            DomainEnum.Barovia.AddItem(ItemEnum.Chosen, "1, 6, 7, 15, 23, 24, 28, 34, 39, 44-46, 48, 52, 54, 56-58, 60, 62, 64, 67, 69, 76, 79, 82-85, 87-90, 95-97, 99, 101, 102, 105, 108, 110, 124-128, 131, 135, 136, 141, 148, 150, 153, 154, 156, 158, 165, 166, 168, 170, 171, 173, 176, 184, 188").ExtraInfo = "It is Jeren Sureblade's Rod of Lordly Might";

            DomainEnum.Barovia.AddItem(ItemEnum.WandOfMM, "17, 18, 20, 35, 40, 43, 45, 47, 48, 53, 58, 66, 74, 75, 78, 88, 96, 104, 119, 125, 129, 132, 135, 146, 166, 167, 173, 179");
            DomainEnum.Barovia.AddItem(ItemEnum.Luckstone, "18, 36, 48, 49, 56, 62, 74, 75, 96, 116, 120, 123, 128, 179, 189");
            DomainEnum.Barovia.AddItem(ItemEnum.Decanter, "30, 114, 115, 151, 139, 166, 189");
            DomainEnum.Barovia.AddItem(ItemEnum.SymbolOfRaven, "31, 34, 40, 56, 57, 66, 85, 86, 88, 92, 110, 111, 117, 124, 132, 133, 136, 140, 143-145, 146, 159, 160, 161, 166, 170, 171, 182, 187, 189");
            DomainEnum.Barovia.AddItem(ItemEnum.IconOfRaven, "34, 40, 66, 100, 117, 137-140, 146, 159, 161, 166, 167, 189")
                .BindAlignment(Alignment.LG);
            DomainEnum.Barovia.AddItem(ItemEnum.Sunsword, "46, 49, 50, 51, 53, 61, 65, 74, 76, 85, 88, 92, 98-100, 106, 110, 111, 121, 122, 119, 129, 130, 134, 143, 145, 147-150, 159-162, 166, 177, 181, 189");
            DomainEnum.Barovia.AddItem(ItemEnum.PotOfHeal, "137, 165, 166, 183, 188, 189");
            DomainEnum.Barovia.AddItem(ItemEnum.VialOfHolyWater, "47, 56, 86, 89, 94, 102, 106, 123, 130, 136, 142, 143, 145, 147, 149, 158, 166, 171, 188, 189");
            DomainEnum.Barovia.AddItem(ItemEnum.AmuletOfLight, "20, 29, 36, 37, 51, 53, 61, 65, 69, 79, 80, 82, 84, 91, 105, 106, 118, 120, 126, 133, 137, 138, 149, 153, 183");
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
    }
}