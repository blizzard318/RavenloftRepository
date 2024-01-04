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

            ctx.AddDomain(DomainEnum.Darkon);
            ctx.AddDomain(DomainEnum.Bluetspur);
            ctx.AddDomain(DomainEnum.Lamordia);

            ctx.AddSettlement(DomainEnum.Darkon, Settlement.Nartok);
            ctx.AddLocation(DomainEnum.Darkon, LocationEnum.MillsOfNartok);
            ctx.Bind(Settlement.Nartok, CharacterEnum.HowardAshton, CharacterEnum.Clarke, CharacterEnum.Phillips);
            ctx.Bind(LocationEnum.MillsOfNartok, CharacterEnum.HowardAshton, CharacterEnum.Clarke, CharacterEnum.Phillips);

            ctx.AddLocation(DomainEnum.Lamordia, LocationEnum.DharlaethAsylum);
            LocationEnum.DharlaethAsylum.ExtraInfo = "Whilst not stated in the story, Ari Marmell said the Asylum is located in Lamordia.<a href='https://bsky.app/profile/mouseferatu.bsky.social/post/3kelemhzy2l2n'>Bluesky Link</a>";
            ctx.Bind(LocationEnum.DharlaethAsylum, CharacterEnum.HowardAshton, CharacterEnum.DoctorAugustus, CharacterEnum.NurseRoberts);

            ctx.AddLivingCharacter(DomainEnum.Bluetspur, CharacterEnum.Clarke);
            ctx.AddLivingCharacter(DomainEnum.Darkon, CharacterEnum.Clarke);
            ctx.BindCreatures(CharacterEnum.Clarke, Creature.Human);
            CharacterEnum.Clarke.ExtraInfo = "Probably deceased";

            ctx.AddDeadCharacter(DomainEnum.Bluetspur, CharacterEnum.Phillips);
            ctx.AddDeadCharacter(DomainEnum.Darkon, CharacterEnum.Phillips);
            ctx.BindCreatures(CharacterEnum.Phillips, Creature.Human);

            ctx.AddLivingCharacter(DomainEnum.Lamordia, CharacterEnum.DoctorAugustus);
            ctx.BindCreatures(CharacterEnum.DoctorAugustus, Creature.Human);

            ctx.AddDeadCharacter(DomainEnum.Lamordia, CharacterEnum.NurseRoberts);
            ctx.BindCreatures(CharacterEnum.NurseRoberts, Creature.Human);

            ctx.AddLivingCharacter(DomainEnum.Bluetspur, CharacterEnum.HowardAshton);
            ctx.AddLivingCharacter(DomainEnum.Lamordia, CharacterEnum.HowardAshton);
            ctx.AddLivingCharacter(DomainEnum.Darkon, CharacterEnum.HowardAshton);
            ctx.BindCreatures(CharacterEnum.HowardAshton, Creature.Human);
        }
        void AddMasterOfRavenloft()
        {
            var releaseDate = "01/01/1986";
            string ExtraInfo = "<br/>&emsp;Author: Jean Blashfield Black";
            ExtraInfo += "<br/>&emsp;Cover Art: Clyde Caldwell";
            ExtraInfo += "<br/>&emsp;Interior Art: Gary Williams";
            using var ctx = CreateSource("Master of Ravenloft", releaseDate, ExtraInfo, Edition.e0, Media.novel);
            if (ctx == null) return;

            #region Domains
            ctx.AddDomain(DomainEnum.Barovia);
            #endregion

            #region Locations
            ctx.AddLocation(DomainEnum.Barovia, LocationEnum.CastleRavenloft);
            ctx.BindCreatures(LocationEnum.CastleRavenloft, Creature.Bat, Creature.Vampire, Creature.Gargoyle, Creature.Mummy,
                                                            Creature.Mimic, Creature.Wolf, Creature.Spectre, Creature.StrahdZombie,
                                                            Creature.Human, Creature.Zombie, Creature.GiantSpider, Creature.Haunt);
            ctx.Bind(LocationEnum.CastleRavenloft, CharacterEnum.CountStrahd, CharacterEnum.JerenSureblade, CharacterEnum.IreenaKolyana,
                                                   CharacterEnum.Tatyana, CharacterEnum.KingBarov, CharacterEnum.Ravenovia, CharacterEnum.Sergei);
            ctx.Bind(LocationEnum.CastleRavenloft, ItemEnum.SymbolOfRaven, ItemEnum.IconOfRaven, ItemEnum.Sunsword);
            ctx.Bind(LocationEnum.CastleRavenloft, GroupEnum.HighPriestRavenloft);

            ctx.AddSettlement(DomainEnum.Barovia, Settlement.Barovia, "18, 21, 23, 24, 29, 30, 32, 34, 36, 40, 42-44, 46, 50, 52, 57, 60, 90, 96, 107, 110, 129, 144, 145, 152, 160, 162, 169, 170, 182, 187");
            ctx.BindCreatures(Settlement.Barovia, Creature.VampireBat, Creature.Bat, Creature.Horse);
            ctx.Bind(Settlement.Barovia, CharacterEnum.CountStrahd, CharacterEnum.JerenSureblade, CharacterEnum.IreenaKolyana, CharacterEnum.FatherDonavich);
            ctx.Bind(Settlement.Barovia, GroupEnum.Burgomaster, GroupEnum.BurgomasterOfBarovia);

            ctx.AddLocation(DomainEnum.Barovia, LocationEnum.BaroviaChurch, "25, 34, 57, 100, 110, 144, 145, 160, 170");
            ctx.Bind(LocationEnum.BaroviaChurch, CharacterEnum.FatherDonavich);
            ctx.Bind(Settlement.Barovia, LocationEnum.BaroviaChurch);
            #endregion

            #region Characters
            ctx.AddLivingCharacter(DomainEnum.Barovia, CharacterEnum.JerenSureblade);
            ctx.BindAlignment(CharacterEnum.JerenSureblade, Alignment.LG);
            ctx.BindCreatures(CharacterEnum.JerenSureblade, Creature.Human);
            ctx.BindRelatedCreatures(CharacterEnum.JerenSureblade, Creature.Horse, Creature.Haunt, Creature.Vampire);
            ctx.Bind(CharacterEnum.JerenSureblade, ItemEnum.WandOfMM, ItemEnum.Luckstone, ItemEnum.VialOfHolyWater, ItemEnum.Chosen,
                                                   ItemEnum.Decanter, ItemEnum.SymbolOfRaven, ItemEnum.IconOfRaven, ItemEnum.Sunsword,
                                                   ItemEnum.AmuletOfLight, ItemEnum.PotOfHeal);

            ctx.AddLivingCharacter(DomainEnum.Barovia, CharacterEnum.CountStrahd);
            ctx.BindCreatures(CharacterEnum.CountStrahd, Creature.Human, Creature.Vampire, Creature.Bat);
            ctx.BindRelatedCreatures(CharacterEnum.CountStrahd, Creature.StrahdZombie);

            ctx.AddLivingCharacter(DomainEnum.Barovia, CharacterEnum.IreenaKolyana);
            ctx.Bind(CharacterEnum.IreenaKolyana, ItemEnum.WandOfMM, ItemEnum.Luckstone, ItemEnum.VialOfHolyWater);

            ctx.AddLivingCharacter(DomainEnum.Barovia, CharacterEnum.Mikhash, "17");
            ctx.AddLivingCharacter(DomainEnum.Barovia, CharacterEnum.Tatyana, "25, 111");
            ctx.AddLivingCharacter(DomainEnum.Barovia, CharacterEnum.FatherDonavich, "34, 57, 144, 160, 170");

            ctx.AddDeadCharacter(DomainEnum.Barovia, CharacterEnum.KingBarov, "45, 98");
            ctx.BindCreatures(CharacterEnum.KingBarov, Creature.Human);
            ctx.AddDeadCharacter(DomainEnum.Barovia, CharacterEnum.Ravenovia, "33, 45");
            ctx.BindCreatures(CharacterEnum.Ravenovia, Creature.Human);
            ctx.AddDeadCharacter(DomainEnum.Barovia, CharacterEnum.Sergei, "107, 183");
            ctx.BindCreatures(CharacterEnum.Sergei, Creature.Human);
            #endregion

            #region Items
            ctx.AddItem(DomainEnum.Barovia, ItemEnum.Chosen, "1, 6, 7, 15, 23, 24, 28, 34, 39, 44-46, 48, 52, 54, 56-58, 60, 62, 64, 67, 69, 76, 79, 82-85, 87-90, 95-97, 99, 101, 102, 105, 108, 110, 124-128, 131, 135, 136, 141, 148, 150, 153, 154, 156, 158, 165, 166, 168, 170, 171, 173, 176, 184, 188");
            ItemEnum.Chosen.ExtraInfo = "It is Jeren Sureblade's Rod of Lordly Might";

            ctx.AddItem(DomainEnum.Barovia, ItemEnum.WandOfMM, "17, 18, 20, 35, 40, 43, 45, 47, 48, 53, 58, 66, 74, 75, 78, 88, 96, 104, 119, 125, 129, 132, 135, 146, 166, 167, 173, 179");
            ctx.AddItem(DomainEnum.Barovia, ItemEnum.Luckstone, "18, 36, 48, 49, 56, 62, 74, 75, 96, 116, 120, 123, 128, 179, 189");
            ctx.AddItem(DomainEnum.Barovia, ItemEnum.Decanter, "30, 114, 115, 151, 139, 166, 189");
            ctx.AddItem(DomainEnum.Barovia, ItemEnum.SymbolOfRaven, "31, 34, 40, 56, 57, 66, 85, 86, 88, 92, 110, 111, 117, 124, 132, 133, 136, 140, 143-145, 146, 159, 160, 161, 166, 170, 171, 182, 187, 189");
            ctx.AddItem(DomainEnum.Barovia, ItemEnum.IconOfRaven, "34, 40, 66, 100, 117, 137-140, 146, 159, 161, 166, 167, 189");
            ctx.BindAlignment(ItemEnum.IconOfRaven, Alignment.LG);
            ctx.AddItem(DomainEnum.Barovia, ItemEnum.Sunsword, "46, 49, 50, 51, 53, 61, 65, 74, 76, 85, 88, 92, 98-100, 106, 110, 111, 121, 122, 119, 129, 130, 134, 143, 145, 147-150, 159-162, 166, 177, 181, 189");
            ctx.AddItem(DomainEnum.Barovia, ItemEnum.PotOfHeal, "137, 165, 166, 183, 188, 189");
            ctx.AddItem(DomainEnum.Barovia, ItemEnum.VialOfHolyWater, "47, 56, 86, 89, 94, 102, 106, 123, 130, 136, 142, 143, 145, 147, 149, 158, 166, 171, 188, 189");
            ctx.AddItem(DomainEnum.Barovia, ItemEnum.AmuletOfLight, "20, 29, 36, 37, 51, 53, 61, 65, 69, 79, 80, 82, 84, 91, 105, 106, 118, 120, 126, 133, 137, 138, 149, 153, 183");
            #endregion

            #region Groups
            ctx.AddGroup(DomainEnum.Barovia, GroupEnum.Vistani, "17, 162");
            ctx.Bind(GroupEnum.Vistani, CharacterEnum.Mikhash);
            ctx.AddGroup(DomainEnum.Barovia, GroupEnum.Burgomaster, "42, 111, 145");
            ctx.AddGroup(DomainEnum.Barovia, GroupEnum.BurgomasterOfBarovia, "42, 111, 145");
            ctx.Bind(GroupEnum.Burgomaster, GroupEnum.BurgomasterOfBarovia);

            ctx.AddGroup(DomainEnum.Barovia, GroupEnum.HighPriestRavenloft, "34, 57, 110, 144");
            ctx.Bind(GroupEnum.HighPriestRavenloft, ItemEnum.SymbolOfRaven);
            #endregion
        }
    }
}