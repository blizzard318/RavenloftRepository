using static Factory;

internal static partial class AddToDatabase
{
    public static void Add3() //Non-Ravenloft Ravenlfot
    {
        AddMistsOfRavenloft();
        AddSpelljammerCrystalSpheres();
        AddWorldSerpentInn();
        void AddMistsOfRavenloft()
        {
            var releaseDate = "09/09/2021";
            string ExtraInfo = "<br/>&emsp;Writing & Design: Scott Fitzgerald Gray, Chris Dupuis";
            ExtraInfo += "<br/>&emsp;Module Info: An adventure for 5 characters of 1st or 2nd level";
            using var ctx = CreateSource("Mist of Ravenloft", releaseDate, ExtraInfo, Edition.e5, Media.module, Canon.pc);

            DomainEnum.Barovia.Appeared().BindCreatures(Creature.Human, Creature.Raven, Creature.Wolf, Creature.Zombie, Creature.CrawlingClaw, Creature.Skeleton, Creature.TwigBlight, Creature.NeedleBlight, Creature.VineBlight, Creature.AwakenedShrub, Creature.Werewolf, Creature.Bat);

            DomainEnum.Barovia.AddLocation(LocationEnum.CastleRavenloft, "2, 7, 9").BindCharacters(DarklordEnum.CountStrahd);
            DomainEnum.Barovia.AddLocation(LocationEnum.TserPool, "8-12").BindGroups(GroupEnum.Vistani, GroupEnum.AishaVistani);
            DomainEnum.Barovia.AddSettlement(Settlement.TserPoolEncampment, "9, 12").BindCharacters(CharacterEnum.MadamEva)
                .BindGroups(GroupEnum.Vistani, GroupEnum.AishaVistani).BindLocations(LocationEnum.TserPool);
            DomainEnum.Barovia.AddLocation(LocationEnum.OldBonegrinder, "12");

            DomainEnum.Barovia.AddLivingDarklord(DarklordEnum.CountStrahd, "1, 2, 6-10, 12").BindCreatures(Creature.Human, Creature.Vampire);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.Sedgewick, "2-5").BindCreatures(Creature.Owlbear);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Blinsky, "7").BindRelatedCreatures(Creature.Skeleton);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Aisha, "7-11").BindCreatures(Creature.Human).BindGroups(GroupEnum.Raunie);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Casius, "8, 10-12").BindCreatures(Creature.Human)
                .BindCharacters(CharacterEnum.Elana, CharacterEnum.Marnius);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Elana, "8, 12").BindCreatures(Creature.Human)
                .BindCharacters(CharacterEnum.Marnius);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Marnius, "8, 11, 12").BindCreatures(Creature.Human);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Walla, "8, 9, 11").BindCreatures(Creature.Dog);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.KingBarov, "8").BindCreatures(Creature.Human);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.MadamEva, "10").BindCreatures(Creature.Human);

            DomainEnum.Barovia.AddItem(ItemEnum.Potion.Heal, "4, 9").BindDomains(DomainEnum.OutsideRavenloft);

            DomainEnum.Barovia.AddGroup(GroupEnum.Vistani, "1, 6-11").BindItems(ItemEnum.Potion.Heal)
                .BindCharacters(CharacterEnum.Aisha, CharacterEnum.Casius, CharacterEnum.Elana, CharacterEnum.Marnius, CharacterEnum.MadamEva);
            DomainEnum.Barovia.AddGroup(GroupEnum.AishaVistani, "1, 6-11").BindGroups(GroupEnum.Vistani).BindCreatures(Creature.Horse, Creature.Dog)
                .BindCharacters(CharacterEnum.Aisha, CharacterEnum.Casius, CharacterEnum.Elana, CharacterEnum.Marnius, CharacterEnum.Walla);
        }
        void AddSpelljammerCrystalSpheres()
        {
            var releaseDate = "01/10/1990";
            string ExtraInfo = "<br/>&emsp;Design: J. Paul LaFountain";
            ExtraInfo += "<br/>&emsp;Cartography: Diesel";
            ExtraInfo += "<br/>&emsp;Editing: Anne Brown";
            ExtraInfo += "<br/>&emsp;Typography: Angelika Lokotz";
            ExtraInfo += "<br/>&emsp;Cover Art: Brom";
            ExtraInfo += "<br/>&emsp;Graphic Design: Paul Hanchette";
            ExtraInfo += "<br/>&emsp;Interior Art: Paul Abrams";
            ExtraInfo += "<br/>&emsp;Module Info: An adventure for 4-8 characters of levels 5-7";
            using var ctx = CreateSource("Spelljammer: Crystal Spheres", releaseDate, ExtraInfo, Edition.e2, Media.module);

            DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.TLaan).BindAlignment(Alignment.CE)
                .BindCreatures(Creature.Vampire, Creature.HalfElf)
                .BindSetting(CampaignSetting.Spelljammer, CampaignSetting.ForgottenRealms);
            DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.MorganDarkdawn)
                .BindDomains(DomainEnum.OutsideRavenloft)
                .BindSetting(CampaignSetting.Spelljammer, CampaignSetting.Greyhawk)
                .ExtraInfo = "Reportedly escaped Ravenloft.";
        }
        void AddWorldSerpentInn()
        {
            var releaseDate = "01/10/1990";
            string ExtraInfo = "<br/>&emsp;Design: J. Paul LaFountain";
            ExtraInfo += "<br/>&emsp;Cartography: Diesel";
            ExtraInfo += "<br/>&emsp;Editing: Anne Brown";
            ExtraInfo += "<br/>&emsp;Typography: Angelika Lokotz";
            ExtraInfo += "<br/>&emsp;Cover Art: Brom";
            ExtraInfo += "<br/>&emsp;Graphic Design: Paul Hanchette";
            ExtraInfo += "<br/>&emsp;Interior Art: Paul Abrams";
            ExtraInfo += "<br/>&emsp;Module Info: An adventure for 4-8 characters of levels 5-7";
            using var ctx = CreateSource("Mist of Ravenloft", releaseDate, ExtraInfo, Edition.e2, Media.module);
        }
    }
}