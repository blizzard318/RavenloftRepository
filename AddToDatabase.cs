using static Relationship;

internal static class AddToDatabase
{
    public static void Add () 
    {
        //Domains, NPCs, Items and Locations are Source-locked, but not Traits.

        AddI6Ravenloft();
        AddBeforeIWake();
        AddCommanderLegendsBattleforBaldursGate();
        void AddI6Ravenloft()
        {
            var releaseDate = "01/11/1983";
            string ExtraInfo = "<br/>&emsp;Authors: Tracy Hickman and Laura Hickman";
            ExtraInfo += "<br/>&emsp;Editor: Curtis Smith";
            ExtraInfo += "<br/>&emsp;Graphic Designer: Debra Stubbe";
            ExtraInfo += "<br/>&emsp;Illustrator: Clyde Caldwell";
            ExtraInfo += "<br/>&emsp;Module Info: An adventure for 6-8 characters of levels 5-7";
            ExtraInfo += "<br/>&emsp;Personal Notes: The term 'Vistani' had not been coined yet, instead the term 'gypsy' was used in this book. I've used 'Vistani' in its place.";
            using var ctx = Factory.CreateSource("I6: Ravenloft", releaseDate, ExtraInfo, Traits.Edition.e1, Traits.Media.module);
            if (ctx == null) return;

            var Barovia = ctx.CreateDomain("Barovia")
                .AddItems(
                    ctx.CreateItem("Tarokka", "1, 4, 5").AddTraits(Traits.Status.Vistani),
                    ctx.CreateItem("Sunsword", "5, 31"),
                    ctx.CreateItem("Icon of Ravenloft", "14"),
                    ctx.CreateItem("Holy Symbol of Ravenkind", "17, 30"),
                    ctx.CreateItem("Tome of Strahd", "11, 31")
                ).AddLocations(
                    ctx.CreateLocation("The Old Svalich Road", "7"),
                    ctx.CreateLocation("The Gates of Barovia", "7").AddTraits(Traits.Creature.GreenSlime),
                    ctx.CreateLocation("The Svalich Woods", "1, 6-8").AddTraits(Traits.Creature.Worg),
                    ctx.CreateLocation("The River Ivlis", "8"),
                    ctx.CreateLocation("Burgomaster's Guest House", "9").AddTraits(Traits.Settlement.VillageOfBarovia),
                    ctx.CreateLocation("Cemetery of Barovia", "9, 11").AddTraits(Traits.Settlement.VillageOfBarovia, Traits.Creature.Spirit),
                    ctx.CreateLocation("Road Junction", "11"),
                    ctx.CreateLocation("Tser Falls", "11"),
                    ctx.CreateLocation("The Gates of Ravenloft", "11, 12")
                ).AddTraits(Traits.Creature.Ghoul);

            var VillageOfBarovia = ctx.CreateLocation("Village of Barovia", "1, 6, 7").AddDomains(Barovia).AddTraits(Traits.Location.Settlement, Traits.Settlement.VillageOfBarovia);
            var BildrathMercantile = ctx.CreateLocation("Bildrath's Mercantile", "8").AddDomains(Barovia).AddTraits(Traits.Settlement.VillageOfBarovia);
            var BloodVineTavern = ctx.CreateLocation("Blood of the Vine Tavern", "8, 9").AddDomains(Barovia).AddTraits(Traits.Settlement.VillageOfBarovia).AddInfo("Also known as 'Blood on the Vine' Tavern.");
            var MaryHouse = ctx.CreateLocation("Mad Mary's Townhouse", "9").AddDomains(Barovia).AddTraits(Traits.Settlement.VillageOfBarovia);
            var BurgomasterHome = ctx.CreateLocation("Burgomaster's Home", "1, 9").AddDomains(Barovia).AddTraits(Traits.Settlement.VillageOfBarovia);
            var BarovianChurch = ctx.CreateLocation("Church of Barovia", "9, 10").AddDomains(Barovia).AddTraits(Traits.Settlement.VillageOfBarovia);

            ctx.CreateNPC("Madam Eva","1, 6, 11, 32").AddTraits(Traits.Race.Human, Traits.Alignment.CN, Traits.Status.Raunie.Item1, Traits.Status.Raunie.Item2)
                .AddLocations(
                    ctx.CreateLocation("Tser Pool Encampment", "11").AddDomains(Barovia).AddTraits(Traits.Location.Settlement, Traits.Settlement.TserPoolEncampment),
                    ctx.CreateLocation("Madam Eva's Tent", "11").AddDomains(Barovia).AddTraits(Traits.Settlement.TserPoolEncampment)
                );

            var CastleRavenloft = ctx.CreateLocation("Castle Ravenloft","1, 6, 8, 9, 12-30").AddDomains(Barovia).AddTraits(Traits.Location.Darklord)
                .AddNPCs(
                    ctx.CreateNPC("Guardian Of Sorrow", "16").AddTraits(Traits.Alignment.NE),
                    ctx.CreateNPC("Lief Lipsiege", "17").AddTraits(Traits.Alignment.CE, Traits.Race.Human),
                    ctx.CreateNPC("Helga", "18").AddTraits(Traits.Alignment.CE, Traits.Race.Human, Traits.Creature.Vampire),
                    ctx.CreateNPC("Cyrus Belview", "23").AddTraits(Traits.Alignment.CN, Traits.Race.Human),

                    ctx.CreateNPC("Spectre Ab-Centeer", "27").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Artista DeSlop", "27").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Lady Isolde Yunk", "27").AddTraits(Traits.Status.Deceased).AddInfo("Also known as 'Isolde the Incredible'."),
                    ctx.CreateNPC("Prince Aerial Du Plumette", "27").AddTraits(Traits.Alignment.LE, Traits.Creature.Ghost).AddInfo("Also known as 'Aerial the Heavy'."),
                    ctx.CreateNPC("Artank Swilovich", "27").AddTraits(Traits.Status.Deceased, Traits.Status.BarovianWineDistillersBrotherhood),

                    ctx.CreateNPC("Marya Markovia", "27, 28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Endorovich the Terrible", "27, 28").AddTraits(Traits.Alignment.LE, Traits.Creature.Spectre),

                    ctx.CreateNPC("Duchess Dorfniya Dilisnya", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Pidlwik", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Sir Leanne Triksky", "28").AddTraits(Traits.Status.Deceased).AddInfo("Also known as 'Sir Lee the Crusher'."),
                    ctx.CreateNPC("Tasha Petrovna", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("King Toisky", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("King Intree Katsky", "28").AddTraits(Traits.Status.Deceased).AddInfo("Also known as 'Katsky the Bright'."),
                    ctx.CreateNPC("Stahbal Indi-Bhak", "28").AddTraits(Traits.Alignment.LE, Traits.Creature.Wight),
                    ctx.CreateNPC("Khazan", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Elsa Fallona", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Sir Sedrik Spinwitovich", "28").AddTraits(Traits.Status.Deceased).AddInfo("Also known as 'Admiral Spinwitovich'"),
                    ctx.CreateNPC("Animus", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Sir Erik Vonderbucks", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Ivan DeRose", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Stephan Gregorovich", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Intree Sik-Valoo", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Ardent Pallette", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Ivan Ivanovich", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Prefect Ciril Romulich", "28").AddTraits(Traits.Status.Deceased),

                    ctx.CreateNPC("$$", "29").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("St. Finderway", "29").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("King Dostron", "29").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Gralmore Nimblenobs", "29").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Americo Standardski", "29").AddTraits(Traits.Status.Deceased),

                    ctx.CreateNPC("Beucephalus", "29, 30").AddTraits(Traits.Creature.Horse, Traits.Creature.Nightmare),
                    ctx.CreateNPC("Tatsaul Eris", "30").AddTraits(Traits.Status.Deceased)
                ).AddTraits(
                    Traits.Creature.RedDragon, 
                    Traits.Creature.ShadowDemon, 
                    Traits.Creature.GiantSpider, 
                    Traits.Creature.HugeSpider,
                    Traits.Creature.Skeleton,
                    Traits.Creature.Horse,
                    Traits.Creature.Nightmare,
                    Traits.Creature.Banshee, 
                    Traits.Creature.Trapper, 
                    Traits.Creature.KeeningSpirit.Item1,
                    Traits.Creature.KeeningSpirit.Item2,
                    Traits.Creature.Gargoyle, 
                    Traits.Creature.RustMonster, 
                    Traits.Creature.GuardianPortrait, 
                    Traits.Creature.Spectre, 
                    Traits.Creature.Spirit, 
                    Traits.Creature.Wight, 
                    Traits.Creature.Wraith, 
                    Traits.Creature.Ghost, 
                    Traits.Creature.Bat, 
                    Traits.Creature.StrahdZombie, 
                    Traits.Creature.Cat, 
                    Traits.Creature.Witch, 
                    Traits.Creature.Hellhound, 
                    Traits.Creature.Werewolf, 
                    Traits.Creature.IronGolem
                );

            ctx.CreateNPC("Anna Petrovna", "28").AddDomains(Barovia);
            ctx.CreateNPC("Arik", "8").AddTraits(Traits.Alignment.CN, Traits.Race.Human).AddLocations(VillageOfBarovia, BloodVineTavern);
            ctx.CreateNPC("Donavich", "9").AddTraits(Traits.Alignment.LG, Traits.Race.Human).AddLocations(VillageOfBarovia, BarovianChurch);

            var Strahd = ctx.CreateNPC("Count Strahd von Zarovich").AddTraits(Traits.Creature.Vampire, Traits.Race.Human, Traits.Alignment.CE, Traits.Status.Darklord, Traits.Creature.Wolf, Traits.Creature.Worg, Traits.Creature.Bat, Traits.Creature.StrahdZombie, Traits.Creature.Zombie).AddLocations(CastleRavenloft).AddInfo("'ClosedBorders':'No one has left Barovia for centuries. This is because of the trapping fog that exists everywhere in Barovia. Once it is breathed, it infuses itself around a character's vital organs as a neutralized poison. The fog does not taste or smell any different than normal fog. It does not harm characters as long as they continue to breathe the air in Barovia. However, when they leave Barovia, the poison becomes active. Characters must save vs. poison or start to choke. Unless choking characters reenter Barovia within 24 hours, they die. The choking stops as soon as they breathe the fog again.  The fog is magically produced by Strahd and disappears entirely upon his destruction.'");

            var Sergei = ctx.CreateNPC("Sergei von Zarovich", "1, 4, 30, 31").AddTraits(Traits.Status.Deceased, Traits.Race.Human).AddLocations(CastleRavenloft);

            var KingBarov = ctx.CreateNPC("King Barov", "28, 30").AddTraits(Traits.Status.Deceased, Traits.Race.Human).AddLocations(CastleRavenloft);
            var Ravenovia = ctx.CreateNPC("Queen Ravenovia", "5, 28, 30").AddTraits(Traits.Status.Deceased, Traits.Race.Human).AddLocations(CastleRavenloft);

            ctx.CreateRelationship(KingBarov, RelationshipType.Spouse, Ravenovia);
            ctx.CreateRelationship(KingBarov, RelationshipType.Parent, Strahd);
            ctx.CreateRelationship(KingBarov, RelationshipType.Parent, Sergei);
            ctx.CreateRelationship(Ravenovia, RelationshipType.Parent, Strahd);
            ctx.CreateRelationship(Ravenovia, RelationshipType.Parent, Sergei);


            var SashaIvliskova = ctx.CreateNPC("Sasha Ivliskova", "28").AddTraits(Traits.Alignment.CE, Traits.Race.Human, Traits.Creature.Vampire).AddLocations(CastleRavenloft);
            var PatrinaVelikovna = ctx.CreateNPC("Patrina Velikovna", "28").AddTraits(Traits.Alignment.CE, Traits.Race.Elf, Traits.Creature.Banshee).AddLocations(CastleRavenloft);
            ctx.CreateRelationship(Strahd, RelationshipType.Spouse, SashaIvliskova);
            ctx.CreateRelationship(Strahd, RelationshipType.Spouse, PatrinaVelikovna);

            var Tatyana = ctx.CreateNPC("Tatyana", "1, 30, 31").AddTraits(Traits.Status.Deceased, Traits.Status.Tatyana).AddDomains(Barovia);
            ctx.CreateRelationship(Sergei, RelationshipType.Spouse, Tatyana);



            var KolyanIndirovich = ctx.CreateNPC("Kolyan Indirovich", "7, 8, 9").AddTraits(Traits.Status.Deceased, Traits.Race.Human).AddLocations(VillageOfBarovia, BurgomasterHome);
            var IreenaKolyana = ctx.CreateNPC("Ireena Kolyana").AddTraits(Traits.Alignment.LG, Traits.Race.Human, Traits.Status.Tatyana).AddLocations(VillageOfBarovia, BurgomasterHome);
            var Ismark = ctx.CreateNPC("Ismark the Lesser", "8, 9").AddTraits(Traits.Alignment.LG, Traits.Race.Human).AddLocations(VillageOfBarovia, BurgomasterHome, BloodVineTavern);
            ctx.CreateRelationship(KolyanIndirovich, RelationshipType.Adopted, IreenaKolyana);
            ctx.CreateRelationship(KolyanIndirovich, RelationshipType.Parent, Ismark);



            var MadMary = ctx.CreateNPC("Mad Mary", "9, 19").AddTraits(Traits.Alignment.CN, Traits.Race.Human).AddLocations(VillageOfBarovia, MaryHouse);
            var Gertruda = ctx.CreateNPC("Gertruda", "9, 19").AddTraits(Traits.Alignment.NG, Traits.Race.Human).AddLocations(VillageOfBarovia, CastleRavenloft, MaryHouse);
            ctx.CreateRelationship(MadMary, RelationshipType.Parent, Gertruda);



            var Bildrath = ctx.CreateNPC("Bildrath", "8").AddTraits(Traits.Alignment.LG, Traits.Race.Human).AddLocations(VillageOfBarovia, BildrathMercantile);
            var Parriwimple = ctx.CreateNPC("Parriwimple", "8").AddTraits(Traits.Alignment.LN, Traits.Race.Human).AddLocations(VillageOfBarovia, BildrathMercantile);
            var BildrathParents = ctx.CreateNPC("Bildrath Parents", string.Empty).AddTraits(Traits.NoLink);
            var BildrathSibling = ctx.CreateNPC("Bildrath Sibling", string.Empty).AddTraits(Traits.NoLink);
            ctx.CreateRelationship(BildrathParents, RelationshipType.Parent, Bildrath);
            ctx.CreateRelationship(BildrathParents, RelationshipType.Parent, BildrathSibling);
            ctx.CreateRelationship(BildrathSibling, RelationshipType.Parent, Parriwimple);
        }
        void AddBeforeIWake()
        {
            var releaseDate = "31/10/2007";
            string ExtraInfo = "<br/>&emsp;Author: Air Marmell";
            using var ctx = Factory.CreateSource("Before I Wake", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.novel);
            if (ctx == null) return;

            var Bluetspur = ctx.CreateDomain("Bluetspur").AddNPCs(
                ctx.CreateNPC("Clarke").AddTraits(Traits.Race.Human),
                ctx.CreateNPC("Phillips").AddTraits(Traits.Race.Human, Traits.Status.Deceased),
                ctx.CreateNPC("God-Brain").AddTraits(Traits.Status.Darklord)
                );

            var Darkon = ctx.CreateDomain("Darkon").AddLocations(
                ctx.CreateLocation("Nartok").AddTraits(Traits.Location.Settlement)
                );

            ctx.CreateDomain("Lamordia");

            var DharlaethAsylum = ctx.CreateLocation("Dharlaeth Asylum").AddNPCs(
                ctx.CreateNPC("Doctor Augustus").AddTraits(Traits.Race.Human),
                ctx.CreateNPC("Nurse Roberts").AddTraits(Traits.Race.Human)
                );

            ctx.CreateNPC("Howard Ashton").AddTraits(Traits.Race.Human).AddDomains(Darkon, Bluetspur).AddLocations(DharlaethAsylum);
        }
        void AddCommanderLegendsBattleforBaldursGate()
        {
            var releaseDate = "10/06/2022";
            string ExtraInfo = "<br/>&emsp;A Magic the Gathering Deck";
            using var ctx = Factory.CreateSource("Commander Legends: Battle for Baldur's Gate", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
            if (ctx == null) return;

            var Barovia = ctx.CreateDomain("Barovia").AddNPCs(
                ctx.CreateNPC("Baba Lysaga").AddTraits(Traits.Race.Human, Traits.Creature.Witch)
                );
        }
        Factory.db.SaveChanges();
    }
}
