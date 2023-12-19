using static Relationship;

internal static class AddToDatabase
{
    private static (Location, Group) CreateSettlement(this Factory ctx, string name, string pageNumbers = "Throughout") => ctx.CreateSettlement(name, name, pageNumbers);
    private static (Location,Group) CreateSettlement(this Factory ctx, string name, string originalName, string pageNumbers)
    {
        var location = ctx.CreateLocation(name, originalName, pageNumbers).AddTraits(Traits.Location.Settlement);
        var group = ctx.CreateGroup(name, originalName, pageNumbers).AddTraits(Traits.Location.Settlement);
        group.AddLocations(location);
        return (location, group);
    }
    private static void PopulateSettlement (this Group Settlement, params Location[] locations)
    {
        Settlement.AddLocations(locations);
        foreach (var location in Settlement.Locations) 
        { 
            Settlement.AddNPCs(location.NPCs.ToArray()); 
            Settlement.AddItems(location.Items.ToArray()); 
        }
    }
    public static void Add () 
    {
        //Domains, NPCs, Items and Locations are Source-locked, but not Traits.
        //Consider not making new instances within Create, so that adding can be better structured.
        AddI6Ravenloft();
        AddBeforeIWake();
        AddCommanderLegendsBattleforBaldursGate();
        AddDiceMastersStrahd();
        AddSpellfireMastertheMagic();
        AddTSRCollectorCards();
        AddMasterOfRavenloft();

        Factory.db.SaveChanges();

        void AddI6Ravenloft()
        {
            var releaseDate = "01/11/1983";
            string ExtraInfo = "<br/>&emsp;Authors: Tracy Hickman and Laura Hickman";
            ExtraInfo += "<br/>&emsp;Editor: Curtis Smith";
            ExtraInfo += "<br/>&emsp;Graphic Designer: Debra Stubbe";
            ExtraInfo += "<br/>&emsp;Illustrator: Clyde Caldwell";
            ExtraInfo += "<br/>&emsp;Module Info: An adventure for 6-8 characters of levels 5-7";
            using var ctx = Factory.CreateSource("I6: Ravenloft", releaseDate, ExtraInfo, Traits.Edition.e1, Traits.Media.module);
            if (ctx == null) return;

            #region Domains
            var Barovia = ctx.CreateDomain("Barovia").AddTraits(Traits.Creature.Ghoul);
            #endregion

            #region Locations
            (var VillageOfBarovia, var VillageOfBaroviaGroup) = ctx.CreateSettlement("Village of Barovia", "1, 6, 7");
            var BildrathMercantile = ctx.CreateLocation("Bildrath's Mercantile", "8");
            var BloodVineTavern = ctx.CreateLocation("Blood of the Vine Tavern", "8, 9").AddInfo("Also known as 'Blood on the Vine' Tavern.");
            var MaryHouse = ctx.CreateLocation("Mad Mary's Townhouse", "9");
            var BurgomasterHome = ctx.CreateLocation("Burgomaster's Home", "1, 9");
            var BarovianChurch = ctx.CreateLocation("Church of Barovia", "9, 10");
            var BurgomasterGuestHouse = ctx.CreateLocation("Burgomaster's Guest House", "9");
            var BaroviaCemetery = ctx.CreateLocation("Cemetery of Barovia", "9, 11").AddTraits(Traits.Creature.Spirit);

            (var TserPoolEncampnent, var TserPoolEncampnentGroup) = ctx.CreateSettlement("Tser Pool Encampment", "11");
            var MadamEvasTent = ctx.CreateLocation("Madam Eva's Tent", "11");

            var CastleRavenloft = ctx.CreateLocation("Castle Ravenloft", "1, 6, 8, 9, 12-30").AddTraits(
                    Traits.Creature.RedDragon, Traits.Creature.ShadowDemon.Item1, Traits.Creature.ShadowDemon.Item2,
                    Traits.Creature.Trapper, Traits.Creature.GiantSpider, Traits.Creature.HugeSpider,
                    Traits.Creature.Skeleton, Traits.Creature.Horse, Traits.Creature.Nightmare, Traits.Creature.Banshee,
                    Traits.Creature.KeeningSpirit.Item1, Traits.Creature.KeeningSpirit.Item2,
                    Traits.Creature.Gargoyle, Traits.Creature.RustMonster, Traits.Creature.GuardianPortrait,
                    Traits.Creature.Spectre, Traits.Creature.Spirit, Traits.Creature.Wight,
                    Traits.Creature.Wraith, Traits.Creature.Ghost, Traits.Creature.Bat,
                    Traits.Creature.StrahdZombie, Traits.Creature.Cat, Traits.Creature.Witch,
                    Traits.Creature.Hellhound, Traits.Creature.Werewolf, Traits.Creature.IronGolem
                );
            #endregion

            #region NPCs
            var MadamEva = ctx.CreateNPC("Madam Eva", "1, 6, 11, 32").AddTraits(Traits.Creature.Human, Traits.Alignment.CN);

            var GuardianOfSorrow = ctx.CreateNPC("Guardian Of Sorrow", "16").AddTraits(Traits.Alignment.NE);
            var LiefLipsiege = ctx.CreateNPC("Lief Lipsiege", "17").AddTraits(Traits.Alignment.CE, Traits.Creature.Human);
            var Helga = ctx.CreateNPC("Helga", "18").AddTraits(Traits.Alignment.CE, Traits.Creature.Human, Traits.Creature.Vampire);
            var CyrusBelview = ctx.CreateNPC("Cyrus Belview", "23").AddTraits(Traits.Alignment.CN, Traits.Creature.Human);

            var SpectreAbCenteer = ctx.CreateNPC("Spectre Ab-Centeer", "27").AddTraits(Traits.Deceased);
            var ArtistaDeSlop = ctx.CreateNPC("Artista DeSlop", "27").AddTraits(Traits.Deceased);
            var LadyIsoldeYunk = ctx.CreateNPC("Isolde the Incredible","Lady Isolde Yunk", "27").AddTraits(Traits.Deceased);
            var AerialDuPlumette = ctx.CreateNPC("Aerial the Heavy", "Prince Aerial Du Plumette", "27").AddTraits(Traits.Alignment.LE, Traits.Creature.Ghost);
            var ArtankSwilovich = ctx.CreateNPC("Artank Swilovich", "27").AddTraits(Traits.Deceased);

            var DorfniyaDilisny = ctx.CreateNPC("Duchess Dorfniya Dilisnya", "28").AddTraits(Traits.Deceased);
            var Pidlwik = ctx.CreateNPC("Pidlwik", "28").AddTraits(Traits.Deceased);
            var LeanneTriksky = ctx.CreateNPC("Sir Lee the Crusher", "Sir Leanne Triksky", "28").AddTraits(Traits.Deceased);
            var TashaPetrovna = ctx.CreateNPC("Tasha Petrovna", "28").AddTraits(Traits.Deceased);
            var KingToisky = ctx.CreateNPC("King Toisky", "28").AddTraits(Traits.Deceased);
            var KingIntreeKatsky = ctx.CreateNPC("Katsky the Bright", "King Intree Katsky", "28").AddTraits(Traits.Deceased);

            var StahbalIndiBhak = ctx.CreateNPC("Stahbal Indi-Bhak", "28").AddTraits(Traits.Alignment.LE, Traits.Creature.Wight);

            var Khazan = ctx.CreateNPC("Khazan", "28").AddTraits(Traits.Deceased);
            var ElsaFallona = ctx.CreateNPC("Elsa Fallona", "28").AddTraits(Traits.Deceased);
            var SedrikSpinwitovich = ctx.CreateNPC("Admiral Spinwitovich", "Sir Sedrik Spinwitovich", "28").AddTraits(Traits.Deceased);
            var Animus = ctx.CreateNPC("Animus", "28").AddTraits(Traits.Deceased);
            var ErikVonderbucks = ctx.CreateNPC("Sir Erik Vonderbucks", "28").AddTraits(Traits.Deceased);
            var IvanDeRose = ctx.CreateNPC("Ivan DeRose", "28").AddTraits(Traits.Deceased);
            var StephanGregorovich = ctx.CreateNPC("Stephan Gregorovich", "28").AddTraits(Traits.Deceased);
            var IntreeSikValoo = ctx.CreateNPC("Intree Sik-Valoo", "28").AddTraits(Traits.Deceased);
            var ArdentPallette = ctx.CreateNPC("Ardent Pallette", "28").AddTraits(Traits.Deceased);
            var IvanIvanovich = ctx.CreateNPC("Ivan Ivanovich", "28").AddTraits(Traits.Deceased);
            var CirilRomulich = ctx.CreateNPC("Prefect Ciril Romulich", "28").AddTraits(Traits.Deceased);

            var Dollars = ctx.CreateNPC("$$", "29").AddTraits(Traits.Deceased);
            var Finderway = ctx.CreateNPC("St. Finderway", "29").AddTraits(Traits.Deceased);
            var Dostron = ctx.CreateNPC("King Dostron", "29").AddTraits(Traits.Deceased);
            var GralmoreNimblenobs = ctx.CreateNPC("Gralmore Nimblenobs", "29").AddTraits(Traits.Deceased);
            var AmericoStandardski = ctx.CreateNPC("Americo Standardski", "29").AddTraits(Traits.Deceased);

            var Beucephalus = ctx.CreateNPC("Beucephalus", "29, 30").AddTraits(Traits.Creature.Horse, Traits.Creature.Nightmare);

            var TatsaulEris = ctx.CreateNPC("Tatsaul Eris", "30").AddTraits(Traits.Deceased);

            var AnnaPetrovna = ctx.CreateNPC("Anna Petrovna", "28").AddInfo("Probably deceased but they never explicitly said so.");
            var Arik = ctx.CreateNPC("Arik", "8").AddTraits(Traits.Alignment.CN, Traits.Creature.Human);
            var Donavich = ctx.CreateNPC("Father Donavich", "9").AddTraits(Traits.Alignment.LG, Traits.Creature.Human);

            var Strahd = ctx.CreateNPC("Count Strahd von Zarovich").AddTraits(
                Traits.Creature.Vampire, Traits.Creature.Human, Traits.Alignment.CE,
                Traits.Creature.Wolf, Traits.Creature.Worg, Traits.Creature.Bat,
                Traits.Creature.StrahdZombie, Traits.Creature.Zombie).AddInfo("'ClosedBorders':'No one has left Barovia for centuries. This is because of the trapping fog that exists everywhere in Barovia. Once it is breathed, it infuses itself around a character's vital organs as a neutralized poison. The fog does not taste or smell any different than normal fog. It does not harm characters as long as they continue to breathe the air in Barovia. However, when they leave Barovia, the poison becomes active. Characters must save vs. poison or start to choke. Unless choking characters reenter Barovia within 24 hours, they die. The choking stops as soon as they breathe the fog again. The fog is magically produced by Strahd and disappears entirely upon his destruction.'");

            var Sergei = ctx.CreateNPC("Sergei von Zarovich", "1, 4, 30, 31").AddTraits(Traits.Deceased,Traits.Creature.Human);

            var KingBarov = ctx.CreateNPC("King Barov von Zarovich", "28, 30").AddTraits(Traits.Creature.Human, Traits.Deceased);
            var Ravenovia = ctx.CreateNPC("Queen Ravenovia von Zarovich", "5, 28, 30").AddTraits(Traits.Creature.Human, Traits.Deceased);
            
            var Marya = ctx.CreateNPC("Marya Markovia", "27, 28").AddTraits(Traits.Deceased);
            var Endorovich = ctx.CreateNPC("Endorovich the Terrible", "27, 28").AddTraits(Traits.Alignment.LE, Traits.Creature.Spectre);

            var SashaIvliskova = ctx.CreateNPC("Sasha Ivliskova", "28").AddTraits(Traits.Alignment.CE, Traits.Creature.Human, Traits.Creature.Vampire);
            var PatrinaVelikovna = ctx.CreateNPC("Patrina Velikovna", "28").AddTraits(Traits.Alignment.CE, Traits.Creature.Elf, Traits.Creature.Banshee);

            var Tatyana = ctx.CreateNPC("Tatyana", "1, 30, 31").AddTraits(Traits.Deceased);

            var KolyanIndirovich = ctx.CreateNPC("Kolyan Indirovich", "7, 8, 9").AddTraits(Traits.Creature.Human, Traits.Deceased);
            var IreenaKolyana = ctx.CreateNPC("Ireena Kolyana").AddTraits(Traits.Alignment.LG, Traits.Creature.Human);
            var Ismark = ctx.CreateNPC("Ismark the Lesser", "8, 9").AddTraits(Traits.Alignment.LG, Traits.Creature.Human);

            var MadMary = ctx.CreateNPC("Mad Mary", "9, 19").AddTraits(Traits.Alignment.CN, Traits.Creature.Human);
            var Gertruda = ctx.CreateNPC("Gertruda", "9, 19").AddTraits(Traits.Alignment.NG, Traits.Creature.Human);
            var Bildrath = ctx.CreateNPC("Bildrath", "8").AddTraits(Traits.Alignment.LG, Traits.Creature.Human);
            var Parriwimple = ctx.CreateNPC("Parriwimple", "8").AddTraits(Traits.Alignment.LN, Traits.Creature.Human);
            #endregion

            #region Items
            var Sunsword = ctx.CreateItem("Sunsword", "5, 31");
            var IconOfRavenloft = ctx.CreateItem("Icon of Ravenloft", "14");
            var SymbolOfRavenloft = ctx.CreateItem("Holy Symbol of Ravenkind", "17, 30").AddTraits(Traits.Creature.Vampire);
            var TomeOfStrahd = ctx.CreateItem("Tome of Strahd", "11, 31");
            #endregion

            #region Groups
            var BarovianWine = ctx.CreateGroup("Barovian Wine Distillers Brotherhood", "27");
            var BridesOfStrahd = ctx.CreateGroup("Brides of Strahd", "28").AddInfo("Count Strahd has collected a few partners over the years.").AddTraits(Traits.Creature.Vampire);
            var ReincarnationsOfTatyana = ctx.CreateGroup("Reincarnations of Tatyana", "30, 31");
            var Gypsy = ctx.CreateGroup("Gypsy", "1, 4, 7, 11, 28");
            var BurgomasterOfBarovia = ctx.CreateGroup("Burgomaster of Barovia", "1, 7, 8, 9");
            #endregion

            #region Domain Add
            Barovia.AddLocations(
                    ctx.CreateLocation("The Old Svalich Road", "7"),
                    ctx.CreateLocation("The Gates of Barovia", "7").AddTraits(Traits.Creature.GreenSlime),
                    ctx.CreateLocation("The Svalich Woods", "1, 6-8").AddTraits(Traits.Creature.Worg),
                    ctx.CreateLocation("The River Ivlis", "8"),
                    ctx.CreateLocation("Road Junction", "11"),
                    ctx.CreateLocation("Tser Falls", "11"),
                    ctx.CreateLocation("The Gates of Ravenloft", "11, 12"),
                    VillageOfBarovia, BildrathMercantile, BloodVineTavern, MaryHouse, 
                    BurgomasterHome, BurgomasterGuestHouse, BarovianChurch, BaroviaCemetery,
                    TserPoolEncampnent, MadamEvasTent, CastleRavenloft
                );
            Barovia.AddNPCs(MadamEva, GuardianOfSorrow, LiefLipsiege, Helga, CyrusBelview,
                SpectreAbCenteer, ArtistaDeSlop, LadyIsoldeYunk, AerialDuPlumette, ArtankSwilovich,
                DorfniyaDilisny, Pidlwik, LeanneTriksky, TashaPetrovna, KingToisky, KingIntreeKatsky, StahbalIndiBhak,
                Khazan, ElsaFallona, SedrikSpinwitovich, Animus, ErikVonderbucks, IvanDeRose, StephanGregorovich, IntreeSikValoo, ArdentPallette, IvanIvanovich, CirilRomulich,
                Dollars, Finderway, Dostron, GralmoreNimblenobs, AmericoStandardski, Beucephalus, TatsaulEris,
                AnnaPetrovna, Arik, Donavich, Strahd, Sergei, KingBarov, Ravenovia, Marya, Endorovich, SashaIvliskova, PatrinaVelikovna,
                Tatyana, KolyanIndirovich, IreenaKolyana, Ismark, MadMary, Gertruda, Bildrath, Parriwimple);
            Barovia.AddItems(Sunsword, IconOfRavenloft, SymbolOfRavenloft, TomeOfStrahd);
            Barovia.AddGroups(BarovianWine, BridesOfStrahd, ReincarnationsOfTatyana, VillageOfBaroviaGroup, TserPoolEncampnentGroup, Gypsy);

            ctx.OutsideRavenloft.AddNPCs(AnnaPetrovna);
            ctx.OutsideRavenloft.AddItems(Sunsword);
            #endregion

            #region Location Add
            VillageOfBarovia.AddNPCs(Arik, Donavich, KolyanIndirovich, Ismark, IreenaKolyana, SashaIvliskova, MadMary, Gertruda, Bildrath, Parriwimple);
            BurgomasterHome.AddNPCs(KolyanIndirovich, Ismark, IreenaKolyana);
            BloodVineTavern.AddNPCs(Arik, Ismark);
            BarovianChurch.AddNPCs(Donavich);
            MaryHouse.AddNPCs(Gertruda, MadMary);
            BildrathMercantile.AddNPCs(Bildrath, Parriwimple);

            TserPoolEncampnent.AddNPCs(MadamEva);
            MadamEvasTent.AddNPCs(MadamEva);

            CastleRavenloft.AddNPCs(
                GuardianOfSorrow, LiefLipsiege, Helga, CyrusBelview, Strahd,
                SpectreAbCenteer, ArtistaDeSlop, LadyIsoldeYunk, AerialDuPlumette, ArtankSwilovich,
                DorfniyaDilisny, Pidlwik, LeanneTriksky, TashaPetrovna, KingToisky, KingIntreeKatsky, StahbalIndiBhak,
                Khazan, ElsaFallona, SedrikSpinwitovich, Animus, ErikVonderbucks, IvanDeRose, StephanGregorovich, IntreeSikValoo, ArdentPallette, IvanIvanovich, CirilRomulich,
                Dollars, Finderway, Dostron, GralmoreNimblenobs, AmericoStandardski, Beucephalus, TatsaulEris, Sergei, KingBarov, Ravenovia, Marya, Endorovich,
                SashaIvliskova, PatrinaVelikovna, Gertruda);
            CastleRavenloft.AddItems(Sunsword, IconOfRavenloft, SymbolOfRavenloft);
            CastleRavenloft.AddGroups(BridesOfStrahd);
            #endregion

            #region Group Add
            BarovianWine.AddNPCs(ArtankSwilovich);
            BridesOfStrahd.AddNPCs(SashaIvliskova, PatrinaVelikovna);
            ReincarnationsOfTatyana.AddNPCs(Tatyana, IreenaKolyana);

            BurgomasterOfBarovia.AddNPCs(KolyanIndirovich);
            BurgomasterOfBarovia.AddLocations(BurgomasterHome, BurgomasterGuestHouse);

            VillageOfBaroviaGroup.PopulateSettlement(BildrathMercantile, BloodVineTavern, MaryHouse, BurgomasterHome, BurgomasterGuestHouse, BarovianChurch, BaroviaCemetery);
            TserPoolEncampnentGroup.PopulateSettlement(MadamEvasTent);

            Gypsy.AddLocations(TserPoolEncampnent, MadamEvasTent);
            Gypsy.AddNPCs(MadamEva);
            #endregion

            #region Item Add
            TomeOfStrahd.AddNPCs(Strahd);
            #endregion

            ctx.CreateRelationship(KingBarov, "Spouse", Ravenovia);
            ctx.CreateRelationship(KingBarov, "Parent", Strahd);
            ctx.CreateRelationship(KingBarov, "Parent", Sergei);
            ctx.CreateRelationship(Ravenovia, "Parent", Strahd);
            ctx.CreateRelationship(Ravenovia, "Parent", Sergei);

            ctx.CreateRelationship(Endorovich, "Loves", Marya);
            ctx.CreateRelationship(Endorovich, "Accidentally Murdered", Marya);

            ctx.CreateRelationship(Strahd, "Spouse", SashaIvliskova);
            ctx.CreateRelationship(Strahd, "Spouse", PatrinaVelikovna);

            ctx.CreateRelationship(Sergei, "Spouse", Tatyana);

            ctx.CreateRelationship(KolyanIndirovich, "Adopted", IreenaKolyana);
            ctx.CreateRelationship(KolyanIndirovich, "Parent", Ismark);

            ctx.CreateRelationship(MadMary, "Parent", Gertruda);
            ctx.CreateRelationship(Gertruda, "Daughter", MadMary);


            ctx.CreateRelationship(Bildrath, "Uncle", Parriwimple);
            ctx.CreateRelationship(Parriwimple, "Nephew", Bildrath);
        }
        void AddMasterOfRavenloft()
        {
            var releaseDate = "01/01/1986";
            string ExtraInfo = "<br/>&emsp;Author: Jean Blashfield Black";
            ExtraInfo += "<br/>&emsp;Cover Art: Clyde Caldwell";
            ExtraInfo += "<br/>&emsp;Interior Art: Gary Williams";
            using var ctx = Factory.CreateSource("Master of Ravneloft", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.novel);
            if (ctx == null) return;

            #region Domains
            var Barovia = ctx.CreateDomain("Barovia").AddTraits(
                Traits.Creature.Wolf
                );
            #endregion

            #region Locations
            var CastleRavenloft = ctx.CreateLocation("Castle Ravenloft").AddTraits(Traits.Creature.Bat, Traits.Creature.Vampire, Traits.Creature.Gargoyle);
            (var VillageOfBarovia, var VillageOfBaroviaGroup) = ctx.CreateSettlement("Village of Barovia");
            VillageOfBarovia.AddTraits(Traits.Creature.VampireBat, Traits.Creature.Bat, Traits.Creature.Horse);
            VillageOfBaroviaGroup.AddTraits(Traits.Creature.VampireBat, Traits.Creature.Bat, Traits.Creature.Horse);
            #endregion

            #region Characters
            var JerenSureblade = ctx.CreateNPC("Jeren Sureblade").AddTraits(Traits.Alignment.LG, Traits.Creature.Human, Traits.Creature.Horse);
            var CountStrahd = ctx.CreateNPC("Count Strahd von Zarovich").AddTraits(Traits.Creature.Human, Traits.Creature.Vampire, Traits.Creature.Bat);
            var Mikhash = ctx.CreateNPC("Mikhash", "17");
            var Ireena = ctx.CreateNPC("Ireena Kolyana");
            var Tatyana = ctx.CreateNPC("Tatyana", "25");
            var Donavich = ctx.CreateNPC("Father Donavich", "25");
            var KingBarov = ctx.CreateNPC("King Barov von Zarovich", "45").AddTraits(Traits.Creature.Human, Traits.Deceased);
            var Ravenovia = ctx.CreateNPC("Queen Ravenovia von Zarovich", "45").AddTraits(Traits.Creature.Human, Traits.Deceased);
            #endregion

            #region Items
            var Chosen = ctx.CreateItem("Chosen", "1, 6, 7, 15, 23, 24, 34, 54, 105, 171");
            Chosen.ExtraInfo = "It is Jeren Sureblade's Rod of Lordly Might";
            var WandOfMM = ctx.CreateItem("Wand of Magic Missile", "43");
            var Luckstone = ctx.CreateItem("Luckstone", "36, 189");
            var Decanter = ctx.CreateItem("Decanter of Endless Water", "189");
            var Medallion = ctx.CreateItem("Holy Medallion of Ravenkind", "Holy Symbol of Ravenkind", "34, 136, 145, 146, 171, 189");
            var Icon = ctx.CreateItem("Icon of Ravenloft", "34, 100, 138, 139, 146, 159, 189").AddTraits(Traits.Alignment.LG);
            var Sunsword = ctx.CreateItem("Sunsword", "46, 49, 92, 106, 119, 143, 145, 148, 149, 159, 161, 162, 189");
            var PotOfHeal = ctx.CreateItem("Potion of Healing", "189");
            var VialOfHolyWater = ctx.CreateItem("Vial of Holy Water", "189");
            var AmuletOfLight = ctx.CreateItem("Amulet of Light", "20, 37, 80, 91, 105, 118, 126, 133, 149");
            #endregion

            #region Groups
            var Gypsy = ctx.CreateGroup("Gypsy", "17, 162");
            var BurgomasterOfBarovia = ctx.CreateGroup("Burgomaster of Barovia", "42");
            #endregion

            #region Domain Add
            Barovia.AddLocations(CastleRavenloft, VillageOfBarovia);
            Barovia.AddNPCs(JerenSureblade, CountStrahd, Mikhash, Ireena, Tatyana, Donavich);
            Barovia.AddItems(Chosen, WandOfMM, Luckstone, Decanter, Medallion, Icon, Sunsword, PotOfHeal, VialOfHolyWater, AmuletOfLight);
            #endregion

            #region Location Add
            CastleRavenloft.AddNPCs(CountStrahd, JerenSureblade, Ireena, Tatyana);
            CastleRavenloft.AddItems(Medallion, Icon, Sunsword);
            VillageOfBarovia.AddNPCs(CountStrahd, JerenSureblade, Ireena, Donavich);
            #endregion

            #region Item Add
            Chosen.AddNPCs(JerenSureblade);
            WandOfMM.AddNPCs(JerenSureblade, Ireena);
            Luckstone.AddNPCs(JerenSureblade, Ireena);
            AmuletOfLight.AddNPCs(JerenSureblade);
            Sunsword.AddNPCs(JerenSureblade);
            #endregion

            #region Group Add
            Gypsy.AddNPCs(Mikhash);
            VillageOfBaroviaGroup.PopulateSettlement(VillageOfBarovia);
            #endregion
        }
        void AddBeforeIWake()
        {
            var releaseDate = "31/10/2007";
            string ExtraInfo = "<br/>&emsp;Author: Air Marmell";
            using var ctx = Factory.CreateSource("Before I Wake", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.novel);
            if (ctx == null) return;

            var Darkon = ctx.CreateDomain("Darkon");
            var Bluetspur = ctx.CreateDomain("Bluetspur");
            var Lamordia = ctx.CreateDomain("Lamordia");

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

            MillsOfNartok.AddNPCs(HowardAshton,Clarke, Phillips);
            DharlaethAsylum.AddNPCs(HowardAshton, Augustus,Roberts);

            NartokGroup.PopulateSettlement(Nartok, MillsOfNartok);

        }
        void AddCommanderLegendsBattleforBaldursGate()
        {
            var releaseDate = "10/06/2022";
            string ExtraInfo = "<br/>&emsp;Illustrator: Slawomir Maniak";
            ExtraInfo += "<br/>&emsp;A Magic the Gathering Deck";
            using var ctx = Factory.CreateSource("Commander Legends: Battle for Baldur's Gate", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
            if (ctx == null) return;

            ctx.CreateDomain("Barovia").AddNPCs(ctx.CreateNPC("Baba Lysaga").AddTraits(Traits.Creature.Human, Traits.Creature.Witch));
        }
        void AddDiceMastersStrahd()
        {
            var releaseDate = "8/10/2016";
            var ExtraInfo = string.Empty;
            using var ctx = Factory.CreateSource("Dice Masters: Strahd", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
            if (ctx == null) return;

            ctx.InsideRavenloft.AddLocations(ctx.CreateLocation("Castle Ravenloft"));
            ctx.InsideRavenloft.AddNPCs(ctx.CreateNPC("Count Strahd von Zarovich"));
        }
        void AddSpellfireMastertheMagic()
        {
            const string ExtraInfo = "Cards not listed are either not related to Ravenloft or too generic to add.";
            AddRavenloftSet();
            AddArtifactsSet();
            Add3rdEditionSet();
            AddUnderdarkSet();
            AddRunesNRuinsSet();
            Add4thEditionSet();
            AddNightstalkersSet();
            AddDungeonsSet();

            AddInquisitionSet();
            AddMilleniumSet();
            AddConquestSet();

            void AddRavenloftSet()
            {
                var releaseDate = "01/08/1994";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Ravenloft Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                var Barovia = ctx.CreateDomain("Barovia", "1/100");
                var Darkon = ctx.CreateDomain("Darkon", "2/100");
                ctx.CreateDomain("Lamordia", "3/100");
                ctx.CreateDomain("Mordent", "4/100");
                ctx.CreateDomain("Kartakass", "5/100");
                ctx.CreateDomain("Keening", "6/100");
                var Tepest = ctx.CreateDomain("Tepest", "7/100");
                ctx.CreateDomain("Verbrek", "8/100").AddTraits(Traits.Creature.Wolf);
                ctx.CreateDomain("Invidia", "9/100");
                ctx.CreateDomain("Nova Vaasa", "10/100");
                ctx.CreateDomain("Dementlieu", "11/100");
                ctx.CreateDomain("Valachan", "12/100");
                var HarAkir = ctx.CreateDomain("Har'Akir", "13/100");
                ctx.CreateDomain("Souragne", "14/100");
                ctx.CreateDomain("Sri Raji", "15/100");

                ctx.CreateLocation("Castle Ravenloft", "16/100").AddDomains(Barovia);

                var AzalinGraveyard = ctx.CreateLocation("Azalin's Graveyard", "17/100").AddTraits(Traits.Creature.Zombie);
                var TheKargat = ctx.CreateGroup("The Kargat", "18/100");
                var KargatMausoleum = ctx.CreateLocation("Kargat Mausoleum", "18/100");
                Darkon.AddLocations(AzalinGraveyard, KargatMausoleum);
                Darkon.AddGroups(TheKargat);
                KargatMausoleum.AddGroups(TheKargat);

                ctx.CreateDomain("Paridon", "19/100").AddTraits(Traits.Creature.Doppelganger); //WHY IS PARIDON MISSING DOPPELGANGERS

                ctx.CreateLocation("Pharaoh's Rest", "20/100").AddDomains(HarAkir);

                ctx.InsideRavenloft.AddGroups(ctx.CreateGroup("Dark Powers", "22/100"));
                ctx.InsideRavenloft.AddItems(ctx.CreateItem("Spell Book of Drawmji", "29/100").AddTraits(Traits.CampaignSetting.Greyhawk));

                ctx.InsideRavenloft.AddTraits(
                    Traits.Creature.GraveElemental, // 35/100
                    Traits.Creature.Shade // 47/100
                );

                ctx.InsideRavenloft.AddItems(ctx.CreateItem("Tarokka Deck", "56/100"));

                var Klorr = ctx.CreateNPC("Klorr", "57/100");
                var TimepieceOfKlorr = ctx.CreateItem("Timepiece of Klorr", "57/100");
                TimepieceOfKlorr.AddNPCs(Klorr);

                ctx.InsideRavenloft.AddItems(
                    ctx.CreateItem("Ring of Regeneration", "58/100"),
                    ctx.CreateItem("Sun Sword", "Sunsword", "59/100"),
                    ctx.CreateItem("Blood Coin", "60/100"),
                    ctx.CreateItem("Staff of Mimicry", "61/100"),
                    ctx.CreateItem("Soul Searcher Medallion", "62/100"),
                    ctx.CreateItem("Ring of Reversion", "63/100"),
                    ctx.CreateItem("Amulet of the Beast", "64/100"));

                var Felkovic = ctx.CreateNPC("Felkovic", "65/100");
                var CatOfFelkovic = ctx.CreateItem("Cat of Felkovic", "65/100");
                CatOfFelkovic.AddNPCs(Felkovic);

                ctx.InsideRavenloft.AddNPCs(Klorr, Felkovic);
                ctx.InsideRavenloft.AddItems(TimepieceOfKlorr, CatOfFelkovic);

                ctx.InsideRavenloft.AddItems(
                    ctx.CreateItem("Apparatus", "66/100"),
                    ctx.CreateItem("Crown of Souls", "67/100"),
                    ctx.CreateItem("Holy Symbol of Ravenkind", "68/100"),
                    ctx.CreateItem("Tapestry of Dark Souls", "69/100"),
                    ctx.CreateItem("Fang of the Nosferatu", "70/100")
                );
                ctx.InsideRavenloft.AddTraits(
                    Traits.Creature.Vampire, // 71/100
                    Traits.Creature.Wolf, // 72/100
                    Traits.Creature.FleshGolem, // 73/100
                    Traits.Creature.GhostShip, // 74/100
                    Traits.Creature.StrahdZombie, // 75/100
                    Traits.Creature.Spectre // 77/100
                );
                ctx.InsideRavenloft.AddGroups(ctx.CreateGroup("Vistani", "78/100"));

                ctx.InsideRavenloft.AddTraits(
                    Traits.Creature.LoupGarou, // 79/100
                    Traits.Creature.Werebat //90/100
                );

                var Azalin = ctx.CreateNPC("Azalin Rex", "82/100");
                AzalinGraveyard.AddNPCs(Azalin);

                ctx.InsideRavenloft.AddNPCs(
                    Azalin,
                    ctx.CreateNPC("Adam", "83/100"),
                    ctx.CreateNPC("Ankhtepot", "84/100"),
                    ctx.CreateNPC("Ireena Kolyana", "85/100"),
                    ctx.CreateNPC("Doctor Rudolph Van Richten", "86/100"),
                    ctx.CreateNPC("Harkon Lukas", "87/100"),
                    ctx.CreateNPC("The Headless Horseman", "88/100").AddTraits(Traits.Creature.Horse),
                    ctx.CreateNPC("Arijani", "89/100"),
                    ctx.CreateNPC("Wilfred Godefroy", "90/100"),
                    ctx.CreateNPC("Tiyet", "91/100"),
                    ctx.CreateNPC("Sir Tristen Hiregaard", "92/100"),
                    ctx.CreateNPC("Gabrielle Aderre", "93/100")
                );

                Tepest.AddGroups(ctx.CreateGroup("Hags Of Tepest", "94/100").AddTraits(Traits.Creature.Hag));

                ctx.InsideRavenloft.AddNPCs(
                    ctx.CreateNPC("Sir Edmund Bloodsworth", "95/100").AddTraits(Traits.Creature.Doppelganger),
                    ctx.CreateNPC("High Master Illithid", "96/100").AddTraits(Traits.Creature.MindFlayer.Item1, Traits.Creature.MindFlayer.Item2),
                    ctx.CreateNPC("Doctor Victor Mordenheim", "97/100"),
                    ctx.CreateNPC("Sergei Von Zarovich", "98/100"),
                    ctx.CreateNPC("Lord Soth", "99/100"),
                    ctx.CreateNPC("Count Strahd von Zarovich", "100/100")
                );
            }
            void AddArtifactsSet()
            {
                var releaseDate = "01/05/1995";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Artifacts Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.CreateItem("Seal of Lost Arak", "12/100").AddDomains(ctx.CreateDomain("Arak", "12/100"));
                ctx.CreateItem("Crystal of the Ebon Flame", "13/100").AddTraits(Traits.CampaignSetting.Greyhawk).AddDomains(ctx.InsideRavenloft);

                ctx.CreateGroup("Darklord", "33/100").AddDomains(ctx.InsideRavenloft);

                ctx.InsideRavenloft.AddTraits(Traits.Creature.InvisibleStalker); //80/100

                ctx.CreateNPC("Yagno Petrovna", "82/100").AddDomains(ctx.InsideRavenloft);
                ctx.CreateDomain("Bluet Spur", "Bluetspur", "88/100");
                ctx.CreateDomain("Kalidnay", "92/100").AddTraits(Traits.CampaignSetting.DarkSun);

                ctx.CreateItem("Death Rock", "2/20").AddDomains(ctx.InsideRavenloft);

                ctx.CreateNPC("Count Strahd von Zarovich", "8/20").AddDomains(ctx.InsideRavenloft);
                ctx.CreateNPC("Ghostly Piper", "10/20").AddDomains(ctx.InsideRavenloft);
            }
            void Add3rdEditionSet()
            {
                var releaseDate = "01/10/1995";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, 3rd Edition Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.CreateItem("Tapestry of the Stag", "426/440").AddTraits(Traits.Creature.VampireBat, Traits.CampaignSetting.Greyhawk).AddDomains(ctx.InsideRavenloft);
            }
            void AddUnderdarkSet()
            {
                var releaseDate = "01/12/1995";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Underdark Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.InsideRavenloft.AddLocations(
                    ctx.CreateLocation("UnderDread", "9/100"),
                    ctx.CreateLocation("The Dread Chamber", "18/100")
                );
                ctx.InsideRavenloft.AddNPCs(
                    ctx.CreateNPC("The Red Death", "68/100"),
                    ctx.CreateNPC("Chantal the Banshee", "97/100").AddTraits(Traits.Creature.Banshee),
                    ctx.CreateNPC("Iseult", "99/100")
                );
                
            }
            void AddRunesNRuinsSet()
            {
                var releaseDate = "01/02/1996";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Runes & Ruins Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.CreateLocation("Tower of Spirits", "15/25").AddDomains(ctx.InsideRavenloft);
            }
            void Add4thEditionSet()
            {
                var releaseDate = "01/07/1996";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, 4th Edition Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.CreateDomain("Arak", "60/500").AddTraits(Traits.Creature.Drow);
                ctx.CreateDomain("Bluet Spur", "Bluetspur", "59/500");
                ctx.CreateDomain("Borca", "61/500");

                ctx.Darklords = ctx.CreateGroup("Darklord", "62/500");
                var LordGundar = ctx.CreateNPC("Lord Gundar", "62/500").AddTraits(Traits.Creature.Ghost);
                var Gundarak = ctx.CreateDomain("Gundarak", "62/500");
                ctx.CreateDarklordGroup(Gundarak, LordGundar);

                ctx.CreateDomain("Sithicus", "63/500");
                ctx.CreateDomain("Nightmare Lands", "64/500");

                ctx.InsideRavenloft.AddNPCs(
                    ctx.CreateNPC("Red Jack", "113/500"),
                    ctx.CreateNPC("Red Tide", "114/500").AddTraits(Traits.Creature.Vampire),

                    ctx.CreateNPC("Pearl", "304/500"),
                    ctx.CreateNPC("Amber", "305/500"),
                    ctx.CreateNPC("Aquamarina", "306/500")
                );
                ctx.InsideRavenloft.AddTraits(
                    Traits.Creature.Mummy, //352/500
                    Traits.Creature.Ghoul //353/500
                );
                ctx.InsideRavenloft.AddNPCs(ctx.CreateNPC("Ting Ling", "354/500"));
                ctx.InsideRavenloft.AddLocations(ctx.CreateLocation("The Death Ship", "355/500"));
                //Traits.Creature.Mummy, //356/500
                ctx.InsideRavenloft.AddNPCs(
                    ctx.CreateNPC("Bride of Malice", "357/500").AddTraits(Traits.Creature.Vampire, Traits.Creature.Dragon),
                    ctx.CreateNPC("Vulture of the Core", "358/500").AddTraits(Traits.Creature.Vulture),
                    ctx.CreateNPC("The Bog Monster", "360/500")
                );
            }
            void AddNightstalkersSet()
            {
                var releaseDate = "01/09/1996";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Nightstalkers Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.CreateDomain("Falkovnia", "5/100");
                ctx.CreateDomain("Richemulot", "6/100");

                ctx.CreateLocation("Haunted Graveyard", "11/100").AddTraits(Traits.Creature.Ghost).AddDomains(ctx.InsideRavenloft);

                ctx.InsideRavenloft.AddNPCs(
                    ctx.CreateNPC("Jacqueline Renier", "32/100"),
                    ctx.CreateNPC("Ratik Ubel", "33/100"),
                    ctx.CreateNPC("Julio, Master Thief of Haslic", "34/100"),
                    ctx.CreateNPC("Nemon Hotep", "67/100"),
                    ctx.CreateNPC("Shera the Wise", "68/100"),
                    ctx.CreateNPC("Varney the Vampire", "16/25").AddTraits(Traits.Creature.Vampire),
                    ctx.CreateNPC("Gib Lhadsemlo", "18/25").AddTraits(Traits.Creature.FleshGolem)
                );

                ctx.CreateLocation("Mad Scientist's Laboratory", "25/25").AddDomains(ctx.InsideRavenloft);
            }
            void AddDungeonsSet()
            {
                var releaseDate = "01/10/1997";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Dungeons Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.InsideRavenloft.AddLocations(
                    ctx.CreateLocation("Castle Strahd", "Castle Ravenloft", "7/100").AddTraits(Traits.Creature.VampireBat),
                    ctx.CreateLocation("The Ruins of Lololia", "32/100")
                );
                ctx.InsideRavenloft.AddItems(ctx.CreateItem("Borer", "61/100"));
            }
            void AddInquisitionSet()
            {
                var releaseDate = "01/03/2001";
                var AddedExtraInfo = ExtraInfo + "<br/>This set was made by fans, but was still using Spellfire trademark.";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Inquisition Set", releaseDate, AddedExtraInfo, Traits.Edition.e0, Traits.Media.boardgame, Traits.Canon.NotCanon);
                if (ctx == null) return;

                ctx.InsideRavenloft.AddNPCs(
                    ctx.CreateNPC("Lord Soth", "87/99"),
                    ctx.CreateNPC("Soth's Steed", "87/99").AddTraits(Traits.Creature.Horse)
                );
            }
            void AddMilleniumSet()
            {
                var releaseDate = "01/03/2002";
                var AddedExtraInfo = ExtraInfo + "<br/>This set was made by fans, but was still using Spellfire trademark.";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Millenium Set", releaseDate, AddedExtraInfo, Traits.Edition.e0, Traits.Media.boardgame, Traits.Canon.NotCanon);
                if (ctx == null) return;

                var Strahd = ctx.CreateNPC("Count Strahd von Zarovich", "23/99");
                ctx.InsideRavenloft.AddNPCs(Strahd);
                var Medallion = ctx.CreateItem("Strahd's Medallion", "23/99").AddTraits(Traits.Creature.Vampire);
                ctx.InsideRavenloft.AddItems(Medallion);
            }
            void AddConquestSet()
            {
                var releaseDate = "01/08/2004";
                var AddedExtraInfo = ExtraInfo + "<br/>This set was made by fans, but was still using Spellfire trademark.";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Conquest Set", releaseDate, AddedExtraInfo, Traits.Edition.e0, Traits.Media.boardgame, Traits.Canon.NotCanon);
                if (ctx == null) return;

                ctx.CreateLocation("Castle Strahd", "Castle Ravenloft", "73/81").AddTraits(Traits.Creature.VampireBat).AddDomains(ctx.InsideRavenloft);
            }
        }
        void AddTSRCollectorCards()
        {
            const string ExtraInfo = "Cards not listed are either not related to Ravenloft or too generic to add.";

            Add1991Cards();
            Add1992Cards();
            Add1992PromoCards();
            Add1993Cards();
            Add1993PromoCards();

            void Add1991Cards()
            {
                var releaseDate = "01/01/1991";
                using var ctx = Factory.CreateSource("TSR Collector Cards, 1991 Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                var CloakOfProtection = ctx.CreateItem("Cloak of Protection", "381/750, 489/750, 611/750, 680/750");
                var BracersOfDef = ctx.CreateItem("Bracers of Defense", "381/750");
                var RingOfShoot = ctx.CreateItem("Ring of Shooting Stars", "381/750");
                var RodOfSmite = ctx.CreateItem("Rod of Smiting", "381/750");
                var StaffOfTheSerpent = ctx.CreateItem("Staff of the Serpent", "381/750");

                var Meredoth = ctx.CreateNPC("Meredoth", "381/750").AddTraits(Traits.Creature.Human, Traits.Alignment.CE);
                Meredoth.AddItems(BracersOfDef, CloakOfProtection, RingOfShoot, RodOfSmite, StaffOfTheSerpent);

                ctx.InsideRavenloft.AddNPCs(Meredoth);
                ctx.InsideRavenloft.AddItems(Meredoth.Items.ToArray());
                ctx.InsideRavenloft.AddTraits(
                    Traits.Creature.GrimReaper, //382/750
                    Traits.Creature.Werebat, //383/750
                    Traits.Creature.Bussengeist //384/750
                );

                ctx.Darklords = ctx.CreateGroup("Darklord", "481-489/750, 611/750");

                var Gabrielle = ctx.CreateNPC("Gabrielle Aderre", "481/750").AddTraits(Traits.Creature.Human, Traits.Alignment.NE);
                var Invidia = ctx.CreateDomain("Invidia", "481/750");
                var Vistani = ctx.CreateGroup("Vistani", "481/750");
                var HalfVistani = ctx.CreateGroup("Half Vistani", "481/750");
                Gabrielle.AddGroups(HalfVistani, Vistani);
                Invidia.AddGroups(Vistani, HalfVistani);
                ctx.CreateDarklordGroup(Invidia, Gabrielle);

                var Azalin = ctx.CreateNPC("Azalin Rex", "482/750").AddTraits(Traits.Creature.Human, Traits.Creature.Lich, Traits.Alignment.LE);
                var Darkon = ctx.CreateDomain("Darkon", "482/750");
                ctx.CreateDarklordGroup(Darkon, Azalin);

                var VladDrakov = ctx.CreateNPC("Vlad Drakov", "483/750").AddTraits(Traits.Creature.Human, Traits.Alignment.NE, Traits.CampaignSetting.Dragonlance);
                var Falkovnia = ctx.CreateDomain("Falkovnia", "483/750");
                var RingOfFreeAct = ctx.CreateItem("Ring of Free Action", "483/750");
                var RodOfFlail = ctx.CreateItem("Rod of Flailing", "483/750");
                var GauntletsOfOgrePower = ctx.CreateItem("Gauntlets of Ogre Power", "483/750");
                VladDrakov.AddItems(RingOfFreeAct, RodOfFlail, GauntletsOfOgrePower);
                Falkovnia.AddItems(VladDrakov.Items.ToArray());
                ctx.CreateDarklordGroup(Falkovnia, VladDrakov);

                var WilfredGodefroy = ctx.CreateNPC("Lord Wilfred Godefroy", "484/750").AddTraits(Traits.Creature.Human, Traits.Creature.Ghost, Traits.Alignment.CE);
                var Mordent = ctx.CreateDomain("Mordent", "484/750");
                ctx.CreateDarklordGroup(Mordent, WilfredGodefroy);

                var Hazlik = ctx.CreateNPC("Hazlik", "485/750").AddTraits(Traits.Creature.Human, Traits.Alignment.CE, Traits.CampaignSetting.ForgottonRealms);
                var Hazlan = ctx.CreateDomain("Hazlan", "485/750");
                var RedWizard = ctx.CreateGroup("Red Wizard of Thay", "485/750").AddTraits(Traits.CampaignSetting.ForgottonRealms);
                RedWizard.AddNPCs(Hazlik);
                Hazlan.AddGroups(RedWizard);
                RedWizard.AddDomains(ctx.InsideRavenloft, ctx.OutsideRavenloft);
                ctx.CreateDarklordGroup(Hazlan, Hazlik);

                var Barovia = ctx.CreateDomain("Barovia", "486/750, 488/750, 489/750, 611/750");

                var HarkonLukas = ctx.CreateNPC("Harkon Lukas", "486/750").AddTraits(Traits.Creature.Human, Traits.Creature.Wolfwere, Traits.Alignment.NE);
                Barovia.AddNPCs(HarkonLukas);
                var Kartakass = ctx.CreateDomain("Kartakass", "486/750");
                var CursedBerserker = ctx.CreateItem("Sword Cursed Berserker", "486/750");
                var ElixirOfMadness = ctx.CreateItem("Elixir of Madness", "486/750");
                HarkonLukas.AddItems(CursedBerserker, ElixirOfMadness);
                Kartakass.AddItems(HarkonLukas.Items.ToArray());
                ctx.CreateDarklordGroup(Kartakass, HarkonLukas);

                var Ludmilla = ctx.CreateNPC("Ludmilla", "487/750").AddTraits(Traits.Creature.Human, Traits.Creature.Pig);
                ctx.InsideRavenloft.AddNPCs(Ludmilla);
                var FrantisekMarkov = ctx.CreateNPC("Frantisek Markov", "487/750").AddTraits(Traits.Creature.Human, Traits.Alignment.LE, Traits.Creature.Pig);
                var Markovia = ctx.CreateDomain("Markovia", "487/750");
                ctx.CreateDarklordGroup(Markovia, FrantisekMarkov);

                ctx.CreateRelationship(FrantisekMarkov, "Husband", Ludmilla);
                ctx.CreateRelationship(Ludmilla, "Wife", FrantisekMarkov);

                var ReligionOfZhakata = ctx.CreateGroup("Religion of Zhakata", "488/750");
                var Zhakata = ctx.CreateNPC("Zhakata", "488/750").AddTraits(Traits.Deity);
                var YagnoPetrovna = ctx.CreateNPC("Yagno Petrovna", "488/750").AddTraits(Traits.Creature.Human, Traits.Alignment.LE);
                ReligionOfZhakata.AddNPCs(Zhakata, YagnoPetrovna);
                Barovia.AddNPCs(YagnoPetrovna);
                var GHenna = ctx.CreateDomain("G'henna", "488/750");
                GHenna.AddNPCs(Zhakata);
                GHenna.AddGroups(ReligionOfZhakata);
                ctx.CreateDarklordGroup(GHenna, YagnoPetrovna);

                ctx.CreateRelationship(YagnoPetrovna, "Worships", Zhakata);

                var Reincarnation = ctx.CreateGroup("Reincarnations of Tatyana", "489/750, 611/750");
                var Tatyana = ctx.CreateNPC("Tatyana", "489/750, 611/750").AddTraits(Traits.Deceased);
                Reincarnation.AddNPCs(Tatyana);
                Barovia.AddGroups(Reincarnation);
                var Strahd = ctx.CreateNPC("Count Strahd von Zarovich", "489/750, 611/750").AddTraits(Traits.Creature.Human, Traits.Creature.Vampire, Traits.Alignment.LE);
                Barovia.AddNPCs(Tatyana);
                var AmuletOfProof = ctx.CreateItem("Amulet of Proof against Detection and Location", "489/750, 611/750");
                Strahd.AddItems(CloakOfProtection, AmuletOfProof);
                Barovia.AddItems(Strahd.Items.ToArray());
                ctx.CreateDarklordGroup(Barovia, Strahd);

                ctx.CreateRelationship(Strahd, "Loves", Tatyana);

                var EleazerClyde = ctx.CreateNPC("Eleazer Clyde", "680/750").AddTraits(Traits.Creature.Vampire, Traits.Creature.Human, Traits.Alignment.LE);
                ctx.InsideRavenloft.AddNPCs(EleazerClyde);
                var RingOfSpellStoring = ctx.CreateItem("Ring of Spell Storing", "680/750");
                var StaffOfThunderAndLightning = ctx.CreateItem("Staff of Thunder and Lightning", "680/750");
                var TalismanOfUltimateEvil = ctx.CreateItem("Talisman of Ultimate Evil", "680/750");
                EleazerClyde.AddItems(RingOfSpellStoring, StaffOfThunderAndLightning, CloakOfProtection, TalismanOfUltimateEvil);
                ctx.InsideRavenloft.AddItems(EleazerClyde.Items.ToArray());

                var KnightsSolamnia = ctx.CreateGroup("Knights of Solamnia", "710/750").AddTraits(Traits.CampaignSetting.Dragonlance);
                var KnightsRose = ctx.CreateGroup("Knights of the Rose", "710/750").AddTraits(Traits.CampaignSetting.Dragonlance);
                var Kitiara = ctx.CreateNPC("Kitiara", "710/750").AddTraits(Traits.CampaignSetting.Dragonlance);
                ctx.OutsideRavenloft.AddNPCs(Kitiara);
                ctx.OutsideRavenloft.AddGroups(KnightsSolamnia, KnightsRose);
                ctx.InsideRavenloft.AddGroups(KnightsSolamnia, KnightsRose);
                var LordSoth = ctx.CreateNPC("Lord Soth", "710/750").AddTraits(
                    Traits.Creature.DeathKnight, Traits.Creature.Human, Traits.Alignment.CE, Traits.CampaignSetting.Dragonlance
                );
                LordSoth.AddGroups(KnightsSolamnia, KnightsRose);
                ctx.InsideRavenloft.AddNPCs(LordSoth);
                ctx.InsideRavenloft.AddGroups(KnightsSolamnia, KnightsRose);

                ctx.CreateRelationship(LordSoth, "Desires", Kitiara);

                var Tlaan = ctx.CreateNPC("T'Laan", "723/750").AddTraits(Traits.Alignment.CE, Traits.Creature.Vampire, Traits.CampaignSetting.Spelljammer);
                ctx.InsideRavenloft.AddNPCs(Tlaan);
            }
            void Add1992Cards()
            {
                var releaseDate = "01/01/1992";
                using var ctx = Factory.CreateSource("TSR Collector Cards, 1992 Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                var TarlVanovitch = ctx.CreateNPC("Tarl Vanovitch", "23/750");
                ctx.InsideRavenloft.AddNPCs(TarlVanovitch);
                var SunBlade = ctx.CreateItem("Tarl Vanovitch's Sun Blade", "23/750").AddTraits(Traits.Alignment.NG, Traits.Creature.Vampire);
                TarlVanovitch.AddItems(SunBlade);
                ctx.InsideRavenloft.AddItems(TarlVanovitch.Items.ToArray());

                var QuebeHauntedMansion = ctx.CreateLocation("Quebe's Haunted Mansion", "51/750").AddTraits(Traits.Creature.Ghoul, Traits.Creature.Vampire, Traits.Creature.Snake);
                ctx.InsideRavenloft.AddLocations(QuebeHauntedMansion);

                ctx.InsideRavenloft.AddTraits(Traits.Creature.LivingWall); //53/750

                var HoelgarArnutsson = ctx.CreateNPC("Hoelgar Arnutsson", "61/750").AddTraits(Traits.Alignment.CE, Traits.Creature.Human, Traits.Creature.GoldDragon);
                ctx.InsideRavenloft.AddNPCs(HoelgarArnutsson);
                var DragonSlayer = ctx.CreateItem("Dragonslayer", "61/750");
                HoelgarArnutsson.AddItems(DragonSlayer);
                ctx.InsideRavenloft.AddItems(HoelgarArnutsson.Items.ToArray());

                var RafeWillowand = ctx.CreateNPC("Rafe Willowand", "68/750").AddTraits(Traits.Alignment.CN, Traits.Creature.HalfElf);
                ctx.InsideRavenloft.AddNPCs(RafeWillowand);
                var BroochOfProt = ctx.CreateItem("Brooch of Protection from Magic Missile", "68/750");
                var BracersOfDefence = ctx.CreateItem("Bracers of Defence", "68/750, 86/750");
                RafeWillowand.AddItems(BroochOfProt, BracersOfDefence );
                ctx.InsideRavenloft.AddItems(RafeWillowand.Items.ToArray());

                var Darkon = ctx.CreateDomain("Darkon", "86/750, 149/750, 151/750, 199/750, 326/750");
                var MarionRobinsdottir = ctx.CreateNPC("Marion Robinsdottir", "86/750, 149/750").AddTraits(Traits.Alignment.CG, Traits.Creature.Human, Traits.Creature.Zombie);
                Darkon.AddNPCs(MarionRobinsdottir);
                var IncenseOfMed = ctx.CreateItem("Incense of Meditation", "86/750");
                var RingOfFreeAct = ctx.CreateItem("Ring of Free Action", "86/750");
                MarionRobinsdottir.AddItems(BracersOfDefence, IncenseOfMed, RingOfFreeAct);
                Darkon.AddItems(MarionRobinsdottir.Items.ToArray());

                var Falkovnia = ctx.CreateDomain("Falkovnia", "90/750");
                var SymbukTorul = ctx.CreateNPC("Symbuk Torul", "90/750").AddTraits(Traits.Alignment.TN, Traits.Creature.Human, Traits.Creature.Tiger);
                Falkovnia.AddNPCs(SymbukTorul);
                var ArmorOfBlend = ctx.CreateItem("Armor of Blending", "90/750, 462/750");
                var EarringSetWithPeriapt = ctx.CreateItem("Earring Set with Periapt of Wound Closure", "90/750");
                SymbukTorul.AddItems(ArmorOfBlend, EarringSetWithPeriapt);
                Falkovnia.AddItems(SymbukTorul.Items.ToArray());

                var mrrob = ctx.CreateItem("Marion Robinsdottir's Robe of Blending", "86/750, 149/750");
                mrrob.AddNPCs(MarionRobinsdottir);
                Darkon.AddItems(mrrob);

                var AzalinRex = ctx.CreateNPC("Azalin Rex", "151/750");
                var ScarabOfDeath = ctx.CreateItem("Mazrikoth's Scarab of Death", "151/750");
                AzalinRex.AddItems(ScarabOfDeath);
                Darkon.AddItems(AzalinRex.Items.ToArray());

                var AlanikRay = ctx.CreateNPC("Alanik Ray", "199/750").AddTraits(Traits.Creature.Elf, Traits.Alignment.LN);
                Darkon.AddNPCs(AlanikRay);

                var DorothaKenig = ctx.CreateNPC("Dorotha Kenig", "200/750").AddTraits(Traits.Creature.HalfElf, Traits.Alignment.LG);
                Darkon.AddNPCs(DorothaKenig);
                (var Viaki, var ViakiGroup) = ctx.CreateSettlement("Viaka", "Viaki", "200/750");
                Darkon.AddLocations(Viaki);
                Darkon.AddGroups(ViakiGroup);
                Viaki.AddNPCs(DorothaKenig);
                ViakiGroup.PopulateSettlement(Viaki);

                var ReligionOfLathander = ctx.CreateGroup("Religion of Lathander", "262/750").AddTraits(Traits.CampaignSetting.ForgottonRealms);
                var Lathander = ctx.CreateNPC("Lathander", "262/750").AddTraits(Traits.CampaignSetting.ForgottonRealms, Traits.Deity);
                ReligionOfLathander.AddDomains(ctx.InsideRavenloft, ctx.OutsideRavenloft);
                ctx.OutsideRavenloft.AddNPCs(Lathander);
                var Almen = ctx.CreateNPC("Almen", "262/750");
                ReligionOfLathander.AddNPCs(Lathander, Almen);
                ctx.InsideRavenloft.AddNPCs(Almen);
                var awoi = ctx.CreateItem("Almen's Wand of Illumination", "262/750");
                awoi.AddNPCs(Lathander, Almen);
                ReligionOfLathander.AddItems(awoi);
                ctx.InsideRavenloft.AddItems(Almen.Items.ToArray());

                ctx.Darklords = ctx.CreateGroup("Darklord", "285/750, 326/750");

                var Strahd = ctx.CreateNPC("Count Strahd von Zarovich", "285/750").AddTraits(Traits.Creature.Human, Traits.Creature.Vampire, Traits.Alignment.LE);
                var Barovia = ctx.CreateDomain("Barovia", "285/750");
                ctx.CreateDarklordGroup(Barovia, Strahd);

                ctx.InsideRavenloft.AddTraits(
                    Traits.Creature.Nosferatu, //286/750
                    Traits.Creature.Dwarf,     //287/750
                    Traits.Creature.Halfling,  //288/750
                    Traits.Creature.Kender,    //289/750
                    Traits.Creature.Elf,       //290/750
                    Traits.Creature.Gnome,     //291/750
                    Traits.Creature.Vampyre    //292/750
                    );

                var JanderSunstar = ctx.CreateNPC("Jander Sunstar", "293/750").AddTraits(Traits.Creature.Elf, Traits.Creature.GoldenElf, Traits.Creature.Vampire, Traits.Alignment.TN);
                Barovia.AddNPCs(JanderSunstar);

                var Leilana = ctx.CreateNPC("Leilana", "296/750").AddTraits(Traits.Creature.Elf, Traits.Alignment.LG, Traits.Creature.Unicorn);
                ctx.InsideRavenloft.AddNPCs(Leilana);

                var Killeen = ctx.CreateNPC("Killeen", "312/750").AddTraits(Traits.Creature.Elf, Traits.Alignment.NG);
                var VladDrakov = ctx.CreateNPC("Vlad Drakov", "312/750");
                Falkovnia.AddNPCs(Killeen, VladDrakov);
                var RobeOfBlending = ctx.CreateItem("Robe of Blending", "312/750");
                var WandOfSecretDoor = ctx.CreateItem("Wand of Secret Door and Trap Location", "312/750");
                Killeen.AddItems(RobeOfBlending, WandOfSecretDoor);
                Falkovnia.AddItems(RobeOfBlending, WandOfSecretDoor);

                var Kevlin = ctx.CreateNPC("Kevlin", "320/750").AddTraits(Traits.Creature.Human, Traits.Alignment.NE);
                Falkovnia.AddNPCs(Kevlin);
                var RingOfHumanInfluence = ctx.CreateItem("Ring of Human Influence", "320/750");
                var RingOfVampiricRegeneration = ctx.CreateItem("Ring of Vampiric Regeneration", "320/750");
                Falkovnia.AddItems(RingOfHumanInfluence, RingOfVampiricRegeneration);
                Kevlin.AddItems(RingOfHumanInfluence, RingOfVampiricRegeneration);
                var ServantsOfTheIronCrown = ctx.CreateGroup("Servants of the Iron Crown").AddTraits(Traits.Alignment.NE);
                Falkovnia.AddGroups(ServantsOfTheIronCrown);
                ServantsOfTheIronCrown.AddNPCs(Kevlin);

                var Mazrikoth = ctx.CreateNPC("Mazrikoth", "326/750").AddTraits(Traits.Creature.Human, Traits.Alignment.LE);
                Darkon.AddNPCs(Mazrikoth);
                var StaffOfThunderAndLightning = ctx.CreateItem("Staff of Thunder & Lightning", "326/750, 456/750");
                var BookOfVileDarkness = ctx.CreateItem("Book of Vile Darkness", "326/750");
                var TalismanOfUltimateEvil = ctx.CreateItem("Talisman of Ultimate Evil", "326/750");
                Mazrikoth.AddItems(ScarabOfDeath, StaffOfThunderAndLightning, BookOfVileDarkness, TalismanOfUltimateEvil);
                Darkon.AddItems(StaffOfThunderAndLightning, BookOfVileDarkness, TalismanOfUltimateEvil);
                AzalinRex.AddTraits(Traits.Creature.Lich);
                ctx.CreateDarklordGroup(Darkon, AzalinRex);

                var Vecna = ctx.CreateNPC("Vecna", "405/750").AddTraits(Traits.Creature.Lich).AddTraits(Traits.Deceased);
                ctx.InsideRavenloft.AddNPCs(Vecna);
                var EyeOfVecna = ctx.CreateItem("Eye of Vecna", "405/750").AddTraits(Traits.Alignment.NE);
                var HandOfVecna = ctx.CreateItem("Hand of Vecna", "406/750").AddTraits(Traits.Alignment.NE);
                Vecna.AddItems(EyeOfVecna, HandOfVecna);
                ctx.InsideRavenloft.AddItems(EyeOfVecna, HandOfVecna);

                var Daglan = ctx.CreateNPC("Dagian", "Daglan", "410/750").AddTraits(Traits.Creature.Wight);
                ctx.InsideRavenloft.AddNPCs(Daglan);
                var CrownOfSouls = ctx.CreateItem("Crown of Souls", "410/750").AddTraits(Traits.Creature.Wight);
                Daglan.AddItems(CrownOfSouls);
                ctx.InsideRavenloft.AddItems(CrownOfSouls);

                var Katrina = ctx.CreateNPC("Katrina Von Brandthofen", "424/750").AddTraits(Traits.Creature.Human, Traits.Alignment.LN);
                var NecklaceOfAdaptation = ctx.CreateItem("Necklace of Adaptation", "424/750");
                Katrina.AddItems(NecklaceOfAdaptation);
                var Victor = ctx.CreateNPC("Doctor Victor Mordenheim", "424/750");
                ctx.InsideRavenloft.AddNPCs(Katrina, Victor);
                ctx.InsideRavenloft.AddItems(NecklaceOfAdaptation);
                ctx.CreateRelationship(Victor, "Uncle", Katrina);
                ctx.CreateRelationship(Katrina, "Niece", Victor);

                var BrightGaelea = ctx.CreateNPC("Bright Gaelea", "441/750").AddTraits(Traits.Creature.Human, Traits.Alignment.LG, Traits.Alignment.NE, Traits.Creature.Succubus);
                ctx.InsideRavenloft.AddNPCs(BrightGaelea);

                var Bilkon = ctx.CreateNPC("Bilkon", "456/750").AddTraits(Traits.Creature.Human, Traits.Alignment.CG);
                Barovia.AddNPCs(Bilkon);
                var RingOfProt = ctx.CreateItem("Ring of Protection", "456/750, 576/750");
                var CloakOfProt = ctx.CreateItem("Cloak of Protection", "456/750");
                Bilkon.AddItems(RingOfProt, StaffOfThunderAndLightning, CloakOfProt);
                Barovia.AddItems(RingOfProt, StaffOfThunderAndLightning, CloakOfProt);

                var ThaedranMeridian = ctx.CreateNPC("Thaedran Meridian", "461/750").AddTraits(Traits.Creature.Human, Traits.Alignment.NE);
                var DevanCory = ctx.CreateNPC("Devan Cory", "461/750");
                ctx.InsideRavenloft.AddNPCs(ThaedranMeridian, DevanCory);

                var Knightengale = ctx.CreateNPC("Knightengale", "462/750").AddTraits(Traits.Creature.Human, Traits.Alignment.LG, Traits.CampaignSetting.ForgottonRealms);
                var Gondegal = ctx.CreateNPC("Gondegal", "462/750").AddTraits(Traits.CampaignSetting.ForgottonRealms);
                Falkovnia.AddNPCs(Knightengale, Gondegal);
                var FerroniereOfBrilliance = ctx.CreateItem("Ferroniere of Brilliance", "462/750");
                var HolyAvenger = ctx.CreateItem("Holy Avenger", "462/750");
                Knightengale.AddItems(ArmorOfBlend, FerroniereOfBrilliance,HolyAvenger);
                Falkovnia.AddItems(ArmorOfBlend, FerroniereOfBrilliance,HolyAvenger);

                ctx.InsideRavenloft.AddGroups(ctx.CreateGroup("Darkling", "485/750").AddTraits(Traits.Alignment.CE));

                ctx.InsideRavenloft.AddTraits(
                    Traits.Creature.Goblyn, //486/750
                    Traits.Creature.BoneGolem, //487/750
                    Traits.Creature.ShadowDemon.Item1, //488/750
                    Traits.Creature.ShadowDemon.Item2 //488/750
                    );

                var Nhalvaen = ctx.CreateNPC("Nhalvaen", "546/750").AddTraits(Traits.Creature.Elf, Traits.Alignment.NE, Traits.Creature.Fox);
                var Kartakass = ctx.CreateDomain("Kartakass", "546/750");
                Kartakass.AddNPCs(Nhalvaen);
                var CloakOfDisplace = ctx.CreateItem("Cloak of Displacement", "546/750");
                var WandOfMagicMissile = ctx.CreateItem("Wand of Magic Missile", "546/750");
                var HarpOfCharm = ctx.CreateItem("Harp of Charming", "546/750");
                Nhalvaen.AddItems(CloakOfDisplace, WandOfMagicMissile, HarpOfCharm);
                Kartakass.AddItems(CloakOfDisplace, WandOfMagicMissile, HarpOfCharm);

                var Burganet = ctx.CreateNPC("Burganet", "576/750").AddTraits(Traits.Creature.Human, Traits.Alignment.NE, Traits.Alignment.LG);
                Barovia.AddNPCs(Burganet);
                Burganet.AddItems(RingOfProt);
                Barovia.AddItems(RingOfProt);

                ctx.InsideRavenloft.AddTraits(
                    Traits.Creature.BrokenOne, //601/750
                    Traits.Creature.DoomGuard, //602/750
                    Traits.Creature.GhoulLord, //603/750
                    Traits.Creature.Ghast, //603/750
                    Traits.Creature.AssassinImp, //604/750
                    Traits.Creature.Quickwood, //605/750
                    Traits.Creature.Reaver, //606/750
                    Traits.Creature.StrahdSteed, //608/750
                    Traits.Creature.Horse, //608/750
                    Traits.Creature.GreaterWolfwere, //609/750
                    Traits.Creature.SeaZombie //620/750
                    );

                ctx.InsideRavenloft.AddItems(ctx.CreateItem("Ring of Reversion", "628/750"));

                ctx.InsideRavenloft.AddNPCs(ctx.CreateNPC("Anhktepot", "645/750").AddTraits(Traits.Creature.GreaterMummy));

                ctx.InsideRavenloft.AddTraits(
                    Traits.Creature.Skeleton, //646/750
                    Traits.Creature.Odem, //647/750
                    Traits.Creature.Wight, //648/750
                    Traits.Creature.Wraith, //649/750
                    Traits.Creature.Geist, //650/750
                    Traits.Creature.Shadow, //651/750
                    Traits.Creature.Ghost, //652/750
                    Traits.Creature.Lich //653/750
                    );

                var EliasSturn = ctx.CreateNPC("Master Elias Sturn", "678/750").AddTraits(Traits.Creature.Human, Traits.Alignment.CG);
                EliasSturn.AddItems(RingOfHumanInfluence);
                ctx.InsideRavenloft.AddNPCs(EliasSturn);
            }
            void Add1992PromoCards()
            {
                var releaseDate = "01/01/1992";
                using var ctx = Factory.CreateSource("TSR Collector Cards, 1992 GenCon Promo Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.InsideRavenloft.AddTraits(Traits.Creature.Zombie); //10/11
            }
            void Add1993Cards()
            {
                var releaseDate = "01/01/1993";
                using var ctx = Factory.CreateSource("TSR Collector Cards, 1993 Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.InsideRavenloft.AddTraits(Traits.Creature.Ghost); //4/495

                var Tavelia = ctx.CreateNPC("Tavelia", "15/495").AddTraits(Traits.Creature.Human, Traits.Creature.Vampire, Traits.Alignment.CE);
                ctx.InsideRavenloft.AddNPCs(Tavelia);
                var GirdleOfManyPouches = ctx.CreateItem("Girdle of Many Pounches", "15/495");
                Tavelia.AddItems(GirdleOfManyPouches);
                ctx.InsideRavenloft.AddItems(GirdleOfManyPouches);

                ctx.Darklords = ctx.CreateGroup("Darklord", "18/495, 172/495");
                var AntonMisroi = ctx.CreateNPC("Anton Misroi", "18/495");
                var Souragne = ctx.CreateDomain("Souragne", "18/495");
                ctx.CreateDarklordGroup(Souragne, AntonMisroi);
                var LarissaSnowmane = ctx.CreateNPC("Larissa Snowmane", "18/495").AddTraits(Traits.Creature.Human, Traits.Alignment.NG);
                Souragne.AddNPCs(AntonMisroi, LarissaSnowmane);

                var AmuletOfVadarin = ctx.CreateItem("Amulet of Vadarin", "21/495, 49/495");

                var Giles = ctx.CreateNPC("Giles the Bowman", "31/495").AddTraits(Traits.Creature.Human, Traits.Alignment.NG);
                var Darkon = ctx.CreateDomain("Darkon", "31/495, 173/495, 178/495, 311/495, 319/495");
                Darkon.AddNPCs(Giles);
                var BootsOfTheNorth = ctx.CreateItem("Boots of the North", "31/495");
                var RingOfProt = ctx.CreateItem("Ring of Protection", "31/495, 311/495");
                var ArrowOfWerewolfSlay = ctx.CreateItem("Arrow of Werewolf Slaying", "31/495");
                Giles.AddItems(BootsOfTheNorth, RingOfProt, ArrowOfWerewolfSlay);
                Darkon.AddItems(BootsOfTheNorth, RingOfProt, ArrowOfWerewolfSlay);

                var Dural = ctx.CreateNPC("Dural of the Iron Hills", "48/495").AddTraits(Traits.Creature.HillDwarf, Traits.Alignment.NG);
                var Borca = ctx.CreateDomain("Borca", "48/495");
                Borca.AddNPCs(Dural);
                var AxeOfHurling = ctx.CreateItem("Axe of Hurling", "48/495");
                Dural.AddItems(AxeOfHurling);
                Borca.AddItems(AxeOfHurling);

                var Vadarin = ctx.CreateNPC("Vadarin", "49/495").AddTraits(Traits.Creature.HighElf, Traits.Alignment.NE);
                Borca.AddNPCs(Vadarin);
                var BracersOfDefense = ctx.CreateItem("Bracers of Defense", "49/495, 474/495");
                Vadarin.AddItems(BracersOfDefense, AmuletOfVadarin);
                Borca.AddItems(BracersOfDefense, AmuletOfVadarin);
                ctx.CreateRelationship(Dural, "Hunts", Vadarin);

                var PaladinsOfTheRaven = ctx.CreateGroup("Paladins of the Raven", "87/495, 252/495, 417/495, 474/495").AddTraits(Traits.Alignment.LG);
                ctx.InsideRavenloft.AddGroups(PaladinsOfTheRaven);
                var Melykurion = ctx.CreateNPC("Melykurion of the Raven", "87/495, 252/495, 417/495").AddTraits(Traits.Creature.Human, Traits.Alignment.LG);
                ctx.InsideRavenloft.AddNPCs(Melykurion);
                PaladinsOfTheRaven.AddNPCs(Melykurion);
                var CastleBloodmere = ctx.CreateLocation("Castle Bloodmere", "87/495, 252/495, 351/495");
                CastleBloodmere.AddNPCs(Melykurion);
                ctx.InsideRavenloft.AddLocations(CastleBloodmere);

                var Theodoric = ctx.CreateNPC("Theodoric the Book", "101/495").AddTraits(Traits.Creature.Human, Traits.Alignment.LG);
                var Barovia = ctx.CreateDomain("Barovia", "101/495, 108/495");
                Barovia.AddNPCs(Theodoric);

                var BonnieLee = ctx.CreateNPC("Bonnie Lee", "108/495").AddTraits(Traits.Creature.HalfElf, Traits.Alignment.NG);
                var Kartakass = ctx.CreateDomain("Kartakass", "108/495");
                var Gundarak = ctx.CreateDomain("Gundarak", "108/495");
                BonnieLee.AddDomains(Kartakass,Gundarak,Barovia);
                var PotionOfSpeed = ctx.CreateItem("Potion of Speed", "108/495");
                BonnieLee.AddItems(PotionOfSpeed);
                Kartakass.AddItems(PotionOfSpeed);
                Gundarak.AddItems(PotionOfSpeed);
                Barovia.AddItems(PotionOfSpeed);

                var DarkPowers = ctx.CreateGroup("Dark Powers", "146/495");
                var StefanDyreth = ctx.CreateNPC("Stefan Dyreth", "146/495").AddTraits(Traits.Creature.Human, Traits.Alignment.LE);
                ctx.InsideRavenloft.AddNPCs(StefanDyreth);
                var CloakOfProt = ctx.CreateItem("Cloak of Protection", "146/495, 311/495");
                StefanDyreth.AddItems(CloakOfProt);
                ctx.InsideRavenloft.AddItems(CloakOfProt);

                var Senmet = ctx.CreateNPC("Senmet", "153/495").AddTraits(Traits.Creature.Human, Traits.Alignment.LE, Traits.Creature.GreaterMummy);
                var Anhktepot = ctx.CreateNPC("Anhktepot", "153/495, 175/495");
                var HarAkir = ctx.CreateDomain("Har'Akir", "153/495");
                HarAkir.AddNPCs(Senmet, Anhktepot);
                ctx.CreateRelationship(Senmet, "wants to overthrow", Anhktepot);

                var Trisler = ctx.CreateNPC("Trisler", "154/495").AddTraits(Traits.Creature.Human, Traits.Alignment.LG);
                HarAkir.AddNPCs(Trisler);
                var Vistani = ctx.CreateGroup("Vistani", "154/495");
                var HalfVistani = ctx.CreateGroup("Half Vistani", "154/495");
                var Darkling = ctx.CreateGroup("Darkling", "154/495");
                Trisler.AddGroups(Vistani, HalfVistani, Darkling);
                HarAkir.AddGroups(Vistani, HalfVistani, Darkling);
                var AnkletOfProt = ctx.CreateItem("Anklet of Protection from Fire", "154/495");
                var NecklaceOfPrayer = ctx.CreateItem("Necklace of Prayer Beads", "154/495");
                Trisler.AddItems(AnkletOfProt, NecklaceOfPrayer);
                HarAkir.AddItems(AnkletOfProt, NecklaceOfPrayer);

                var Adam = ctx.CreateNPC("Adam", "172/495").AddTraits(Traits.Alignment.CE);
                var Victor = ctx.CreateNPC("Doctor Victor Mordenheim", "172/495");
                var Eva = ctx.CreateNPC("Eva", "172/495");
                var Lamordia = ctx.CreateDomain("Lamordia", "172/495");
                Lamordia.AddNPCs(Victor, Eva);
                var IsleOfAgony = ctx.CreateLocation("Isle of Agony", "172/495");
                Lamordia.AddLocations(IsleOfAgony);
                IsleOfAgony.AddNPCs(Adam);
                ctx.CreateDarklordGroup(Lamordia, Adam);

                var RatikUbel = ctx.CreateNPC("Ratik Ubel", "173/495").AddTraits(Traits.Creature.Human, Traits.Creature.Revenant, Traits.Alignment.TN);
                Darkon.AddNPCs(RatikUbel);
                (var IlAluk,var IlAlukGroup) = ctx.CreateSettlement("Il Aluk", "173/495");
                Darkon.AddLocations(IlAluk);
                Darkon.AddGroups(IlAlukGroup);
                IlAluk.AddNPCs(RatikUbel);
                IlAlukGroup.PopulateSettlement(IlAluk);

                var NataliaVhorishkova = ctx.CreateNPC("Natalia Vhorishkova", "174/495").AddTraits(Traits.Creature.Human, Traits.Creature.Werewolf, Traits.Alignment.CE);
                var Arkandale = ctx.CreateDomain("Arkandale", "174/495");
                var RudolphVanRichten = ctx.CreateNPC("Doctor Rudolph Van Richten", "174/495");
                Arkandale.AddNPCs(NataliaVhorishkova, RudolphVanRichten);
                ctx.CreateRelationship(RudolphVanRichten, "almost kills", NataliaVhorishkova);

                Anhktepot.AddTraits(Traits.Creature.Human, Traits.Creature.GreaterMummy, Traits.Alignment.CE); //175/495

                var Bluebeard = ctx.CreateNPC("Bluebeard", "176/495").AddTraits(Traits.Creature.Human, Traits.Alignment.LE);
                ctx.InsideRavenloft.AddNPCs(Bluebeard);

                var HeadlessHorseman = ctx.CreateNPC("The Headless Horseman", "177/495").AddTraits(Traits.Creature.Human, Traits.Alignment.CE);
                var IvanaBoritsi = ctx.CreateNPC("Ivana Boritsi", "177/495");
                ctx.InsideRavenloft.AddNPCs(HeadlessHorseman, IvanaBoritsi);
                ctx.CreateRelationship(IvanaBoritsi, "Beheaded", HeadlessHorseman);

                var RedWizard = ctx.CreateGroup("Red Wizard of Thay", "178/495");
                var UrikVonKharkov = ctx.CreateNPC("Baron Urik von Kharkov", "178/495").AddTraits(Traits.Creature.Human, Traits.Creature.Nosferatu, Traits.Creature.Panther, Traits.Alignment.LE);
                Darkon.AddNPCs(UrikVonKharkov);
                var TheKargat = ctx.CreateGroup("The Kargat", "178/495").AddTraits(Traits.Creature.Nosferatu, Traits.Creature.Vampire);
                Darkon.AddGroups(TheKargat);

                var Stezen = ctx.CreateNPC("Stezen D'Polarno", "179/495").AddTraits(Traits.Creature.Human, Traits.Alignment.NE, Traits.Alignment.CE);
                var Tiyet = ctx.CreateNPC("Tiyet", "180/495").AddTraits(Traits.Creature.Human, Traits.Creature.Mummy, Traits.Alignment.NE);
                ctx.InsideRavenloft.AddNPCs(Stezen, Tiyet);

                var LyronEvensong = ctx.CreateNPC("Baron Lyron Evensong", "190/495, 262/495");
                ctx.InsideRavenloft.AddNPCs(LyronEvensong);
                var HarpsichordOfCommand = ctx.CreateItem("Lyron's Harpsichord of Commanding", "190/495");
                LyronEvensong.AddItems(HarpsichordOfCommand);
                ctx.InsideRavenloft.AddItems(HarpsichordOfCommand);

                var Hannibil = ctx.CreateNPC("Hannibil of the Raven", "87/495, 252/495, 417/495").AddTraits(Traits.Creature.Human, Traits.Alignment.LG);
                PaladinsOfTheRaven.AddNPCs(Hannibil);
                var CastellanPietor = ctx.CreateNPC("Castellan Pietor", "252/495, 351/495, 417/495");
                CastleBloodmere.AddNPCs(Hannibil, CastellanPietor);
                ctx.InsideRavenloft.AddNPCs(Hannibil, CastellanPietor);
                var PotionOfHeal = ctx.CreateItem("Potion of Healing", "252/495");
                Hannibil.AddItems(PotionOfHeal);
                ctx.InsideRavenloft.AddItems(PotionOfHeal);
                ctx.CreateRelationship(Melykurion, "Brother", Hannibil);
                ctx.CreateRelationship(Hannibil, "Brother", Melykurion);

                LyronEvensong.AddTraits(Traits.Creature.Human, Traits.Alignment.NE, Traits.CampaignSetting.Dragonlance); //262/495

                var Azalin = ctx.CreateNPC("Azalin Rex", "311/495, 319/495");
                var KaleenCorigrave = ctx.CreateNPC("Kaleen Corigrave", "311/495").AddTraits(Traits.Creature.Human, Traits.Alignment.NG, Traits.CampaignSetting.ForgottonRealms);
                Darkon.AddNPCs(KaleenCorigrave, Azalin);
                var AmuletOfProtVsUndead = ctx.CreateItem("Amulet of Protection versus Undead", "311/495");
                KaleenCorigrave.AddItems(CloakOfProt, RingOfProt, AmuletOfProtVsUndead);
                Darkon.AddItems(CloakOfProt, RingOfProt, AmuletOfProtVsUndead);

                var KaraliJenei = ctx.CreateNPC("Karali Jenei", "313/495").AddTraits(Traits.Creature.Human, Traits.Alignment.CE);
                ctx.InsideRavenloft.AddNPCs(KaraliJenei);
                var Dukkar = ctx.CreateGroup("Dukkar", "313/495");
                ctx.InsideRavenloft.AddGroups(Dukkar);
                KaraliJenei.AddGroups(Darkling, Vistani, Dukkar);
                var RingOfInvis = ctx.CreateItem("Ring of Invisibility", "313/495");
                var CloakOfArachnida = ctx.CreateItem("Cloak of Arachnida", "313/495");
                KaraliJenei.AddItems(RingOfInvis, CloakOfArachnida);
                ctx.InsideRavenloft.AddItems(RingOfInvis, CloakOfArachnida);

                var Tyr = ctx.CreateNPC("Tyr", "319/495").AddTraits(Traits.CampaignSetting.ForgottonRealms, Traits.Deity);
                ctx.OutsideRavenloft.AddNPCs(Tyr);
                var ReligionOfTyr = ctx.CreateGroup("Religion of Tyr", "319/495").AddTraits(Traits.CampaignSetting.ForgottonRealms);
                ReligionOfTyr.AddDomains(ctx.InsideRavenloft, ctx.OutsideRavenloft);
                var Latislav = ctx.CreateNPC("Latislav of Darkon", "319/495").AddTraits(Traits.Creature.Human, Traits.Alignment.LG, Traits.CampaignSetting.ForgottonRealms);
                ReligionOfTyr.AddNPCs(Tyr, Latislav);
                Darkon.AddNPCs(Latislav);
                var StaffOfCuring = ctx.CreateItem("Staff of Curing", "319/495");
                var AmuletOfLifeProt = ctx.CreateItem("Amulet of Life Protection", "319/495");
                var MaceOfDisrupt = ctx.CreateItem("Mace of Disruption", "319/495");
                Latislav.AddItems(StaffOfCuring, AmuletOfLifeProt, MaceOfDisrupt);
                Darkon.AddItems(StaffOfCuring, AmuletOfLifeProt, MaceOfDisrupt);
                ctx.CreateRelationship(Azalin, "seeks to kill", Latislav);

                var IconOfTheRaven = ctx.CreateItem("Icon of the Raven", "351/495, 484/495").AddTraits(Traits.Alignment.NG);
                ctx.InsideRavenloft.AddItems(IconOfTheRaven);

                var BrindletopleTimeBomb = ctx.CreateItem("Brindletople's Time Bomb", "353/495, 490/495");
                ctx.InsideRavenloft.AddItems(BrindletopleTimeBomb);

                var Markovia = ctx.CreateDomain("Markovia", "361,495");
                var FrantisekMarkov = ctx.CreateNPC("Frantisek Markov", "361,495");
                var JurgenVastish = ctx.CreateNPC("Jurgen Vastish", "361/495").AddTraits(Traits.Creature.Human, Traits.Alignment.NG);
                Markovia.AddNPCs(FrantisekMarkov, JurgenVastish);
                var BlessedBolt = ctx.CreateItem("Blessed Bolt", "361/495");
                JurgenVastish.AddItems(BlessedBolt);
                Markovia.AddItems(BlessedBolt);

                var WeeJas = ctx.CreateNPC("Wee Jas", "373/495").AddTraits(Traits.CampaignSetting.Greyhawk, Traits.Deity);
                ctx.OutsideRavenloft.AddNPCs(WeeJas);
                var ReligionOfWeeJas = ctx.CreateGroup("Religion of Wee Jas", "373/495").AddTraits(Traits.CampaignSetting.Greyhawk);
                ReligionOfWeeJas.AddDomains(ctx.InsideRavenloft, ctx.OutsideRavenloft);
                var Vashtar = ctx.CreateNPC("Vashtar", "373/495").AddTraits(Traits.Creature.Human, Traits.Alignment.LE, Traits.CampaignSetting.Greyhawk);
                ctx.InsideRavenloft.AddNPCs(Vashtar);
                ReligionOfWeeJas.AddNPCs(WeeJas, Vashtar);

                var MarkScarab = ctx.CreateItem("Mark's Scarab of Protection", "408/495, 417/495");
                var Mark = ctx.CreateNPC("Mark of the Raven", "87/495, 252/495, 408/495, 417/495").AddTraits(Traits.Creature.Human, Traits.Alignment.LG);
                PaladinsOfTheRaven.AddNPCs(Mark);
                ctx.InsideRavenloft.AddNPCs(Mark);
                var HolyAvenger = ctx.CreateItem("Holy Avenger", "417/495");
                Mark.AddItems(MarkScarab, HolyAvenger);
                ctx.InsideRavenloft.AddItems(MarkScarab, HolyAvenger);
                ctx.CreateRelationship(Mark, "Brother", Hannibil);
                ctx.CreateRelationship(Mark, "Brother", Melykurion);
                ctx.CreateRelationship(Melykurion, "Brother", Mark);
                ctx.CreateRelationship(Hannibil, "Brother", Mark);

                var TithionWand = ctx.CreateItem("Tithion's Wand of Fire", "467/495, 474/495");
                var Tithion = ctx.CreateNPC("Tithion", "467/495, 474/495").AddTraits(Traits.Creature.Human, Traits.Alignment.LE);
                ctx.InsideRavenloft.AddNPCs(Tithion);
                CastleBloodmere.AddNPCs(Tithion);
                Tithion.AddItems(BracersOfDefense, TithionWand);
                ctx.InsideRavenloft.AddItems(TithionWand);

                var Seldain = ctx.CreateNPC("Seldain", "483/495").AddTraits(Traits.Creature.Human, Traits.Alignment.LE);
                ctx.InsideRavenloft.AddNPCs(Seldain);
                CastleBloodmere.AddNPCs(Seldain);

                var Arabel = ctx.CreateNPC("Patron Arabel", "Father Arabel", "351/495, 484/495").AddTraits(Traits.Creature.Human, Traits.Alignment.LG);
                PaladinsOfTheRaven.AddNPCs(Arabel);
                ctx.InsideRavenloft.AddNPCs(Arabel);
                var StaffOfStriking = ctx.CreateItem("Staff of Striking", "484/495");
                Arabel.AddItems(IconOfTheRaven, StaffOfStriking);
                ctx.InsideRavenloft.AddItems(StaffOfStriking);

                var Brindletople = ctx.CreateNPC("Brindletople", "353/495, 490/495").AddTraits(Traits.Creature.Gnome, Traits.Alignment.LN);
                ctx.InsideRavenloft.AddNPCs(Brindletople);
                var GemOfInsight = ctx.CreateItem("Gem of Insight");
                Brindletople.AddItems(GemOfInsight, BrindletopleTimeBomb);
                ctx.InsideRavenloft.AddItems(GemOfInsight);
            }
            void Add1993PromoCards()
            {
                var releaseDate = "01/01/1993";
                using var ctx = Factory.CreateSource("TSR Collector Cards, 1993 GenCon Promo Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                var Milil = ctx.CreateNPC("Milil", "10/60").AddTraits(Traits.Deity);
                ctx.OutsideRavenloft.AddNPCs(Milil);
                var ReligionOfMilil = ctx.CreateGroup("Religion of Milil", "10/60").AddTraits(Traits.CampaignSetting.ForgottonRealms);
                Milil.AddGroups(ReligionOfMilil);
                var Kartakass = ctx.CreateDomain("Kartkass","10/60");
                var ChurchOfMilil = ctx.CreateLocation("Church of Milil", "10/60");
                ChurchOfMilil.AddNPCs(Milil);
                ChurchOfMilil.AddGroups(ReligionOfMilil);
                (var Harmonia, var HarmoniaGroup) = ctx.CreateSettlement("Harmonia", "10/60");
                Kartakass.AddGroups(ReligionOfMilil, HarmoniaGroup);
                var MeistersingerMansion = ctx.CreateLocation("Meistersinger Mansion", "10/60");
                Kartakass.AddLocations(ChurchOfMilil, Harmonia, MeistersingerMansion);
                var Casimiar = ctx.CreateNPC("Meistersinger Casimiar of Harmonia", "10/60").AddTraits(Traits.Creature.Human, Traits.Creature.Wolfwere, Traits.Alignment.NE);
                Kartakass.AddNPCs(Casimiar);
                Casimiar.AddLocations(ChurchOfMilil, Harmonia, MeistersingerMansion);
                HarmoniaGroup.PopulateSettlement(ChurchOfMilil, MeistersingerMansion);

                var Sithicus = ctx.CreateDomain("Sithicus", "13/60");
                var LordSoth = ctx.CreateNPC("Lord Soth", "13/60").AddTraits(Traits.Creature.DeathKnight, Traits.Alignment.CE, Traits.CampaignSetting.Dragonlance);
                ctx.Darklords = ctx.CreateGroup("Darklord", "13/60");
                ctx.CreateDarklordGroup(Sithicus, LordSoth);
                ctx.InsideRavenloft.AddNPCs(ctx.CreateNPC("Count Strahd von Zarovich", "13/60"));

                var Bluetspur = ctx.CreateDomain("Bluetspur", "15/60");
                var HighMaster = ctx.CreateNPC("High Master Illithid", "15/60").AddTraits(Traits.Creature.Illithid.Item1, Traits.Creature.Illithid.Item2, Traits.Alignment.LE, Traits.Creature.Vampire);
                Bluetspur.AddNPCs(HighMaster);
                var Apparatus = ctx.CreateItem("Apparatus", "15/60");
                Bluetspur.AddItems(Apparatus);
                HighMaster.AddItems(Apparatus);

                var Jaraq = ctx.CreateNPC("Jaraq the Deceiver", "18/60").AddTraits(Traits.Creature.HalfElf, Traits.Alignment.CE, Traits.Creature.Vampire);
                ctx.InsideRavenloft.AddNPCs(Jaraq);
                var RingOfSpellStore = ctx.CreateItem("Ring of Spell Storing", "18/60");
                var LensOfSpeedRead = ctx.CreateItem("Lens of SpeedReading", "18/60");
                var DeckOfIllusions = ctx.CreateItem("Deck of Illusions", "18/60");
                Jaraq.AddItems(RingOfSpellStore, LensOfSpeedRead, DeckOfIllusions);
                ctx.InsideRavenloft.AddItems(RingOfSpellStore, LensOfSpeedRead, DeckOfIllusions);
            }
        }
    }
}
