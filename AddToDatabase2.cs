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
            if (ctx == null) return;

            var Darkon = ctx.AddDomain(DomainEnum.Darkon);
            var Bluetspur = ctx.AddDomain(DomainEnum.Bluetspur);
            var Lamordia = ctx.AddDomain(DomainEnum.Lamordia);

            (var Nartok, var NartokGroup) = ctx.CreateSettlement("Nartok");
            var MillsOfNartok = ctx.CreateLocation("Mills of Nartok").AddInfo("For Darkonian Lumber");
            var DharlaethAsylum = ctx.CreateLocation("Dharlaeth Asylum").AddInfo("Whilst not stated in the story, Ari Marmell said the Asylum is located in Lamordia.<a href='https://bsky.app/profile/mouseferatu.bsky.social/post/3kelemhzy2l2n'>Bluesky Link</a>");

            var Clarke = ctx.CreateNPC("Clarke").AddTraits(Traits.Creature.Human).AddInfo("Probably deceased");
            var Phillips = ctx.CreateNPC("Phillips").AddTraits(Traits.Creature.Human, Traits.Deceased);

            var Augustus = ctx.CreateNPC("Doctor Augustus").AddTraits(Traits.Creature.Human);
            var Roberts = ctx.CreateNPC("Nurse Roberts").AddTraits(Traits.Creature.Human, Traits.Deceased);
            var HowardAshton = ctx.CreateNPC("Howard Ashton").AddTraits(Traits.Creature.Human);

            Darkon.AddLocations(Nartok, MillsOfNartok);
            Darkon.AddGroups(NartokGroup);
            Darkon.AddNPCs(HowardAshton, Clarke, Phillips);
            Bluetspur.AddNPCs(HowardAshton, Clarke, Phillips);
            Lamordia.AddLocations(DharlaethAsylum);
            Lamordia.AddNPCs(HowardAshton, Augustus, Roberts);

            MillsOfNartok.AddNPCs(HowardAshton, Clarke, Phillips);
            DharlaethAsylum.AddNPCs(HowardAshton, Augustus, Roberts);

            NartokGroup.PopulateSettlement(Nartok, MillsOfNartok);

        }
        void AddMasterOfRavenloft()
        {
            var releaseDate = "01/01/1986";
            string ExtraInfo = "<br/>&emsp;Author: Jean Blashfield Black";
            ExtraInfo += "<br/>&emsp;Cover Art: Clyde Caldwell";
            ExtraInfo += "<br/>&emsp;Interior Art: Gary Williams";
            using var ctx = Factory.CreateSource("Master of Ravenloft", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.novel);
            if (ctx == null) return;

            #region Domains
            var Barovia = ctx.CreateDomain("Barovia").AddTraits(Traits.Creature.Wolf);
            #endregion

            #region Locations
            var CastleRavenloft = ctx.CreateLocation("Castle Ravenloft").AddTraits(
                Traits.Creature.Bat, Traits.Creature.Vampire, Traits.Creature.Gargoyle, Traits.Deceased,
                Traits.Creature.Mummy, Traits.Creature.Mimic, Traits.Creature.Wolf,
                Traits.Creature.Spectre, Traits.Creature.StrahdZombie, Traits.Creature.Human,
                Traits.Creature.Zombie, Traits.Creature.GiantSpider, Traits.Creature.Haunt);
            (var VillageOfBarovia, var VillageOfBaroviaGroup) = ctx.CreateSettlement("Village of Barovia", "18, 21, 23, 24, 29, 30, 32, 34, 36, 40, 42-44, 46, 50, 52, 57, 60, 90, 96, 107, 110, 129, 144, 145, 152, 160, 162, 169, 170, 182, 187");
            VillageOfBarovia.AddTraits(Traits.Creature.VampireBat, Traits.Creature.Bat, Traits.Creature.Horse);
            VillageOfBaroviaGroup.AddTraits(Traits.Creature.VampireBat, Traits.Creature.Bat, Traits.Creature.Horse);
            var BarovianChurch = ctx.CreateLocation("Church of Barovia", "25, 34, 57, 100, 110, 144, 145, 160, 170");
            #endregion

            #region Characters
            var JerenSureblade = ctx.CreateNPC("Jeren Sureblade").AddTraits(Traits.Alignment.LG, Traits.Creature.Human, Traits.Creature.Horse, Traits.Creature.Haunt, Traits.Creature.Vampire);
            var CountStrahd = ctx.CreateNPC("Count Strahd von Zarovich").AddTraits(Traits.Creature.Human, Traits.Creature.Vampire, Traits.Creature.Bat, Traits.Creature.StrahdZombie);
            var Ireena = ctx.CreateNPC("Ireena Kolyana");
            var Mikhash = ctx.CreateNPC("Mikhash", "17");
            var Tatyana = ctx.CreateNPC("Tatyana", "25, 111");
            var Donavich = ctx.CreateNPC("Father Donavich", "34, 57, 144, 160, 170");
            var KingBarov = ctx.CreateNPC("King Barov von Zarovich", "45, 98").AddTraits(Traits.Creature.Human, Traits.Deceased);
            var Ravenovia = ctx.CreateNPC("Queen Ravenovia von Zarovich", "33, 45").AddTraits(Traits.Creature.Human, Traits.Deceased);
            var Sergei = ctx.CreateNPC("Sergei von Zarovich", "107, 183").AddTraits(Traits.Creature.Human, Traits.Deceased);
            #endregion

            #region Items
            var Chosen = ctx.CreateItem("Chosen", "1, 6, 7, 15, 23, 24, 28, 34, 39, 44-46, 48, 52, 54, 56-58, 60, 62, 64, 67, 69, 76, 79, 82-85, 87-90, 95-97, 99, 101, 102, 105, 108, 110, 124-128, 131, 135, 136, 141, 148, 150, 153, 154, 156, 158, 165, 166, 168, 170, 171, 173, 176, 184, 188");
            Chosen.ExtraInfo = "It is Jeren Sureblade's Rod of Lordly Might";
            var WandOfMM = ctx.CreateItem("Wand of Magic Missiles", "17, 18, 20, 35, 40, 43, 45, 47, 48, 53, 58, 66, 74, 75, 78, 88, 96, 104, 119, 125, 129, 132, 135, 146, 166, 167, 173, 179");
            var Luckstone = ctx.CreateItem("Luckstone", "18, 36, 48, 49, 56, 62, 74, 75, 96, 116, 120, 123, 128, 179, 189");
            var Decanter = ctx.CreateItem("Decanter of Endless Water", "30, 114, 115, 151, 139, 166, 189");
            var Medallion = ctx.CreateItem("Holy Medallion of Ravenkind", "Holy Symbol of Ravenkind", "31, 34, 40, 56, 57, 66, 85, 86, 88, 92, 110, 111, 117, 124, 132, 133, 136, 140, 143-145, 146, 159, 160, 161, 166, 170, 171, 182, 187, 189");
            var Icon = ctx.CreateItem("Icon of Ravenloft", "34, 40, 66, 100, 117, 137-140, 146, 159, 161, 166, 167, 189").AddTraits(Traits.Alignment.LG);
            var Sunsword = ctx.CreateItem("Sunsword", "46, 49, 50, 51, 53, 61, 65, 74, 76, 85, 88, 92, 98-100, 106, 110, 111, 121, 122, 119, 129, 130, 134, 143, 145, 147-150, 159-162, 166, 177, 181, 189");
            var PotOfHeal = ctx.CreateItem("Potion of Healing", "137, 165, 166, 183, 188, 189");
            var VialOfHolyWater = ctx.CreateItem("Vial of Holy Water", "47, 56, 86, 89, 94, 102, 106, 123, 130, 136, 142, 143, 145, 147, 149, 158, 166, 171, 188, 189");
            var AmuletOfLight = ctx.CreateItem("Amulet of Light", "20, 29, 36, 37, 51, 53, 61, 65, 69, 79, 80, 82, 84, 91, 105, 106, 118, 120, 126, 133, 137, 138, 149, 153, 183");
            #endregion

            #region Groups
            var Gypsy = ctx.CreateGroup("Gypsy", "17, 162");
            var Burgomaster = ctx.CreateGroup("Burgomaster", "42, 111, 145");
            var BurgomasterOfBarovia = ctx.CreateGroup("Burgomaster of Barovia", "42, 111, 145");
            var HighPriestRavenloft = ctx.CreateGroup("High Priest of Ravenloft", "34, 57, 110, 144");
            #endregion

            #region Domain Add
            Barovia.AddGroups(VillageOfBaroviaGroup, Burgomaster, BurgomasterOfBarovia, Gypsy, HighPriestRavenloft);
            Barovia.AddLocations(CastleRavenloft, VillageOfBarovia, BarovianChurch);
            Barovia.AddNPCs(JerenSureblade, CountStrahd, Mikhash, Ireena, Tatyana, Donavich, KingBarov, Ravenovia, Sergei);
            Barovia.AddItems(Chosen, WandOfMM, Luckstone, Decanter, Medallion, Icon, Sunsword, PotOfHeal, VialOfHolyWater, AmuletOfLight);
            #endregion

            #region Location Add
            CastleRavenloft.AddNPCs(CountStrahd, JerenSureblade, Ireena, Tatyana, KingBarov, Ravenovia, Sergei);
            CastleRavenloft.AddItems(Medallion, Icon, Sunsword);
            CastleRavenloft.AddGroups(HighPriestRavenloft);
            VillageOfBarovia.AddNPCs(CountStrahd, JerenSureblade, Ireena, Donavich);
            VillageOfBarovia.AddGroups(Burgomaster, BurgomasterOfBarovia);
            BarovianChurch.AddNPCs(Donavich);
            #endregion

            #region Item Add
            Ireena.AddItems(WandOfMM, Luckstone, VialOfHolyWater);
            JerenSureblade.AddItems(WandOfMM, Luckstone, VialOfHolyWater, Chosen, Decanter, Medallion, Icon,
                Sunsword, AmuletOfLight, PotOfHeal);
            #endregion

            #region Group Add
            Gypsy.AddNPCs(Mikhash);
            HighPriestRavenloft.AddItems(Medallion);
            VillageOfBaroviaGroup.PopulateSettlement(BarovianChurch);
            #endregion
        }
    }
}