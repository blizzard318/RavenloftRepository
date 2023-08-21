using static Relationship;

internal static class AddToDatabase
{
    public static void Add () 
    {
        #region Universal Traits
        //Editions
        var e0  = Factory.CreateSourceTrait("Editionless"  , "Edition");
        e0.ExtraInfo = "Everything here are official products that do not belong to any edition of D&D.";
        var e1  = Factory.CreateSourceTrait("1st Edition"  , "Edition");
        var e2  = Factory.CreateSourceTrait("2nd Edition"  , "Edition");
        var e3  = Factory.CreateSourceTrait("3rd Edition"  , "Edition");
        var e35 = Factory.CreateSourceTrait("3.5th Edition", "Edition");
        var e4  = Factory.CreateSourceTrait("4th Edition"  , "Edition");
        var e5  = Factory.CreateSourceTrait("5th Edition"  , "Edition");

        //Canonicity
        var pc = Factory.CreateSourceTrait("Potentially Canon", "Canon");
        var nc = Factory.CreateSourceTrait("Not Canon"        , "Canon");
        nc.ExtraInfo = pc.ExtraInfo = "Unless explicity stated as 'Potentially Canon' or 'Not Canon', everything else is treated Canon.";

        //Source types
        var comic      = Factory.CreateSourceTrait("Comic"      , "Media");
        var module     = Factory.CreateSourceTrait("Module"     , "Media");
        var novel      = Factory.CreateSourceTrait("Novel"      , "Media");
        var gamebook   = Factory.CreateSourceTrait("Gamebook"   , "Media");
        var sourcebook = Factory.CreateSourceTrait("Sourcebook" , "Media");
        var magazine   = Factory.CreateSourceTrait("Magazine"   , "Media");
        var videogame  = Factory.CreateSourceTrait("Video Game" , "Media");
        var boardgame  = Factory.CreateSourceTrait("Board Game" , "Media");

        //Locations
        var Mistway  = Factory.CreateTrait("Mistway", "Location");
        var Cluster  = Factory.CreateTrait("Cluster", "Location");

        //Exclusive to Ravenloft Types
        var Vistani  = Factory.CreateTrait("Vistani" , "Group,Status,Location,Item");
        var Darklord = Factory.CreateTrait("Darklord", "Status,Location");
        Darklord.ExtraInfo = "Locations tagged as Darklord are their Lairs.";

        //Alignment
        var LG = Factory.CreateTrait("Lawful Good"    , "Alignment");
        var NG = Factory.CreateTrait("Neutral Good"   , "Alignment");
        var CG = Factory.CreateTrait("Chaotic Good"   , "Alignment");
        var LN = Factory.CreateTrait("Lawful Neutral" , "Alignment");
        var TN = Factory.CreateTrait("True Neutral"   , "Alignment");
        var CN = Factory.CreateTrait("Chaotic Neutral", "Alignment");
        var LE = Factory.CreateTrait("Lawful Evil"    , "Alignment");
        var NE = Factory.CreateTrait("Neutral Evil"   , "Alignment");
        var CE = Factory.CreateTrait("Chaotic Evil"   , "Alignment");

        //Status
        var Deceased = Factory.CreateTrait("Deceased", "Status");
        var Raunie   = Factory.CreateTrait("Raunie"  , "Status");
        #endregion
        #region Domain-Tracked Traits
        //Languages
        var Common = Factory.CreateTrait("Common", "Language");

        //Races
        var Human = Factory.CreateTrait("Human", "Race");
        var Elf   = Factory.CreateTrait("Elf", "Race");

        //Groups
        var BarovianWineDistillersBrotherhood = Factory.CreateTrait("Barovian Wine Distillers Brotherhood", "Group");

        //Creature Types
        var Wolf  = Factory.CreateTrait("Wolf" , "Creature");
        var Bat   = Factory.CreateTrait("Bat"  , "Creature");
        var Horse = Factory.CreateTrait("Horse", "Creature");
        var Cat   = Factory.CreateTrait("Cat"  , "Creature");
        var GiantSpider = Factory.CreateTrait("Giant Spider", "Creature");
        var HugeSpider  = Factory.CreateTrait("Huge Spider" , "Creature");

        var Worg        = Factory.CreateTrait("Worg"        , "Creature");
        var Nightmare   = Factory.CreateTrait("Nightmare"   , "Creature");
        var Hellhound   = Factory.CreateTrait("Hellhound"   , "Creature");
        var GreenSlime  = Factory.CreateTrait("Green Slime" , "Creature");
        var Gargoyle    = Factory.CreateTrait("Gargoyle"    , "Creature");
        var RustMonster = Factory.CreateTrait("Rust Monster", "Creature");
        var RedDragon   = Factory.CreateTrait("Red Dragon"  , "Creature");
        var ShadowDemon = Factory.CreateTrait("Shadow Demon", "Creature");
        var IronGolem   = Factory.CreateTrait("Iron Golem"  , "Creature");
        var Trapper     = Factory.CreateTrait("Trapper"     , "Creature");
        var GuardianPortrait = Factory.CreateTrait("Guardian Portrait", "Creature");

        var Spirit      = Factory.CreateTrait("Spirit" , "Creature");
        var Ghost       = Factory.CreateTrait("Ghost"  , "Creature");
        var Wraith      = Factory.CreateTrait("Wraith" , "Creature");
        var Spectre     = Factory.CreateTrait("Spectre", "Creature");
        var Banshee     = Factory.CreateTrait("Banshee", "Creature");
        var KeeningSpirit = Factory.CreateTrait("Keening Spirit", "Creature");
        KeeningSpirit.ExtraInfo = "Also known as 'Groaning Spirit'";

        var StrahdZombie = Factory.CreateTrait("Strahd Zombie", "Creature");
        var Zombie       = Factory.CreateTrait("Zombie"       , "Creature");
        var Skeleton     = Factory.CreateTrait("Skeleton"     , "Creature");

        var Vampire = Factory.CreateTrait("Vampire", "Creature");
        var Ghoul   = Factory.CreateTrait("Ghoul"  , "Creature");
        var Wight   = Factory.CreateTrait("Wight"  , "Creature");

        var Witch    = Factory.CreateTrait("Witch"   , "Creature");
        var Werewolf = Factory.CreateTrait("Werewolf", "Creature");
        #endregion

        #region Mistways
        #endregion

        #region Clusters
        #endregion

        //Domains, NPCs, Items and Locations are Source-locked, but not Traits.

        AddI6Ravenloft();
        void AddI6Ravenloft()
        {
            var releaseDate = new DateTime(1983, 11, 1);
            string ExtraInfo = "Authors: Tracy Hickman and Laura Hickman\nEditor: Curtis Smith\n";
            ExtraInfo += "Graphic Designer: Debra Stubbe\nIllustrator: Clyde Caldwell\n";
            ExtraInfo += "ModuleInfo:An adventure for 6-8 characters of levels 5-7";
            using var ctx = Factory.CreateSource("I6: Ravenloft", releaseDate, ExtraInfo, e1, module);
            if (ctx == null) return;

            var Barovia = ctx.CreateDomain("Barovia")
                .AddItems(
                    ctx.CreateItem("Tarokka", 1, 4, 5).AddTraits(Vistani),
                    ctx.CreateItem("Sunsword", 5, 31),
                    ctx.CreateItem("Icon of Ravenloft", 14),
                    ctx.CreateItem("Holy Symbol of Ravenkind", 17, 30),
                    ctx.CreateItem("Tome of Strahd", 11, 31)
                ).AddLocations(
                    ctx.CreateLocation("The Old Svalich Road", 7),
                    ctx.CreateLocation("The Gates of Barovia", 7).AddTraits(GreenSlime),
                    ctx.CreateLocation("The Svalich Woods", 1, 6, 7, 8).AddTraits(Worg),
                    ctx.CreateLocation("The River Ivlis", 8),
                    ctx.CreateLocation("Burgomaster's Guest House", 9),
                    ctx.CreateLocation("Road Junction", 11),
                    ctx.CreateLocation("Tser Falls", 11),
                    ctx.CreateLocation("The Gates of Ravenloft", 11, 12)
                ).AddTraits(Ghoul);

            var VillageOfBarovia = ctx.CreateLocation("Village of Barovia", 1, 6, 7).AddDomains(Barovia).AddTraits(Vistani);
            var BildrathMercantile = ctx.CreateLocation("Bildrath's Mercantile", 8).AddDomains(Barovia);
            var BloodVineTavern = ctx.CreateLocation("Blood of the Vine Tavern", 8, 9).AddDomains(Barovia).AddTraits(Vistani).AddInfo("Also known as 'Blood on the Vine' Tavern.");
            var MaryHouse = ctx.CreateLocation("Mad Mary's Townhouse", 9).AddDomains(Barovia);
            var BurgomasterHome = ctx.CreateLocation("Burgomaster's Home", 1, 9).AddDomains(Barovia);
            var BarovianChurch = ctx.CreateLocation("Church of Barovia", 9, 10).AddDomains(Barovia);
            var BarovianCemetery = ctx.CreateLocation("Cemetery of Barovia", 9, 11).AddDomains(Barovia).AddTraits(Spirit);

            var TserPoolEncampment = ctx.CreateLocation("Tser Pool Encampment", 11).AddDomains(Barovia).AddTraits(Vistani);
            var MadamEvaTent = ctx.CreateLocation("Madam Eva's Tent", 11).AddDomains(Barovia).AddTraits(Vistani);

            var CastleRavenloft = ctx.CreateLocation("Castle Ravenloft").AddDomains(Barovia).AddTraits(Darklord)
                .AddNPCs(
                    ctx.CreateNPC("Guardian Of Sorrow", 16).AddTraits(NE),
                    ctx.CreateNPC("Lief Lipsiege", 17).AddTraits(CE, Human),
                    ctx.CreateNPC("Helga", 18).AddTraits(CE, Human, Vampire),
                    ctx.CreateNPC("Cyrus Belview", 23).AddTraits(CN, Human),
                    ctx.CreateNPC("Spectre Ab-Centeer", 27).AddTraits(Deceased),
                    ctx.CreateNPC("Artista DeSlop", 27).AddTraits(Deceased),
                    ctx.CreateNPC("Lady Isolde Yunk", 27).AddTraits(Deceased).AddInfo("Also known as 'Isolde the Incredible'."),
                    ctx.CreateNPC("Prince Aeial Du Plumette", 27).AddTraits(LE, Ghost).AddInfo("Also known as 'Aerial the Heavy'."),
                    ctx.CreateNPC("Artank Swilovich", 27).AddTraits(Deceased, BarovianWineDistillersBrotherhood),
                    ctx.CreateNPC("Marya Markovia", 27, 28).AddTraits(Deceased),
                    ctx.CreateNPC("Endorovich the Terrible", 27, 28).AddTraits(LE, Spectre),
                    ctx.CreateNPC("Duchess Dorfniya Dilisnya", 28).AddTraits(Deceased),
                    ctx.CreateNPC("Pidlwik", 28).AddTraits(Deceased),
                    ctx.CreateNPC("Sir Leanne Triksky", 28).AddTraits(Deceased).AddInfo("Also known as 'Sir Lee the Crusher'."),
                    ctx.CreateNPC("Tasha Petrovna", 28).AddTraits(Deceased),
                    ctx.CreateNPC("King Toisky", 28).AddTraits(Deceased),
                    ctx.CreateNPC("King Intree Katsky", 28).AddTraits(Deceased).AddInfo("Also known as 'Katsky the Bright'."),
                    ctx.CreateNPC("Stahbal Indi-Bhak", 28).AddTraits(LE, Wight),
                    ctx.CreateNPC("Khazan", 28).AddTraits(Deceased),
                    ctx.CreateNPC("Elsa Fallona", 28).AddTraits(Deceased),
                    ctx.CreateNPC("Sir Sedrik Spinwitovich", 28).AddTraits(Deceased).AddInfo("Also known as 'Admiral Spinwitovich'"),
                    ctx.CreateNPC("Animus", 28).AddTraits(Deceased),
                    ctx.CreateNPC("Sir Erik Vonderbucks", 28).AddTraits(Deceased),
                    ctx.CreateNPC("Ivan DeRose", 28).AddTraits(Deceased),
                    ctx.CreateNPC("Stephan Gregorovich", 28).AddTraits(Deceased),
                    ctx.CreateNPC("Intree Sik-Valoo", 28).AddTraits(Deceased),
                    ctx.CreateNPC("Ardent Pallette", 28).AddTraits(Deceased),
                    ctx.CreateNPC("Ivan Ivanovich", 28).AddTraits(Deceased),
                    ctx.CreateNPC("Prefect Ciril Romulich", 28).AddTraits(Deceased),
                    ctx.CreateNPC("$$", 29).AddTraits(Deceased),
                    ctx.CreateNPC("St. Finderway", 29).AddTraits(Deceased),
                    ctx.CreateNPC("King Dostron", 29).AddTraits(Deceased),
                    ctx.CreateNPC("Gralmore Nimblenobs", 29).AddTraits(Deceased),
                    ctx.CreateNPC("Americo Standardski", 29).AddTraits(Deceased),
                    ctx.CreateNPC("Beucephalus", 29, 30).AddTraits(Horse, Nightmare),
                    ctx.CreateNPC("Tatsaul Eris", 30).AddTraits(Deceased)
                ).AddTraits(
                    RedDragon, ShadowDemon, GiantSpider, HugeSpider,Skeleton,Horse,Nightmare, Banshee, Trapper, KeeningSpirit, Gargoyle, RustMonster, GuardianPortrait, Spectre, Spirit, Wight, Wraith, Ghost, Bat, StrahdZombie, Cat, Witch, Hellhound, Werewolf, IronGolem
                );

            ctx.CreateNPC("Anna Petrovna", 28);
            ctx.CreateNPC("Arik", 8).AddTraits(CN, Human).AddLocations(VillageOfBarovia, BloodVineTavern);
            ctx.CreateNPC("Donavich", 9).AddTraits(LG, Human).AddLocations(VillageOfBarovia, BarovianChurch);
            ctx.CreateNPC("Madam Eva").AddTraits(Vistani, Human, CN, Raunie).AddLocations(TserPoolEncampment, MadamEvaTent);

            var Strahd = ctx.CreateNPC("Count Strahd von Zarovich").AddTraits(Vampire, Human, CE, Darklord, Wolf, Worg, Bat, StrahdZombie, Zombie).AddLocations(CastleRavenloft).AddInfo("'ClosedBorders':'No one has left Barovia for centuries. This is because of the trapping fog that exists everywhere in Barovia. Once it is breathed, it infuses itself around a character's vital organs as a neutralized poison. The fog does not taste or smell any different than normal fog. It does not harm characters as long as they continue to breathe the air in Barovia. However, when they leave Barovia, the poison becomes active. Characters must save vs. poison or start to choke. Unless choking characters reenter Barovia within 24 hours, they die. The choking stops as soon as they breathe the fog again.  The fog is magically produced by Strahd and disappears entirely upon his destruction.'");

            var Sergei = ctx.CreateNPC("Sergei von Zarovich", 1, 4, 30, 31).AddTraits(Deceased, Human).AddLocations(CastleRavenloft);

            var KingBarov = ctx.CreateNPC("King Barov", 28, 30).AddTraits(Deceased, Human).AddLocations(CastleRavenloft);
            var Ravenovia = ctx.CreateNPC("Queen Ravenovia", 5, 28, 30).AddTraits(Deceased, Human).AddLocations(CastleRavenloft);

            var Tatyana = ctx.CreateNPC("Tatyana", 1, 30, 31).AddTraits(Deceased);

            var SashaIvliskova = ctx.CreateNPC("Sasha Ivliskova", 28).AddTraits(CE, Human, Vampire).AddLocations(CastleRavenloft);
            var PatrinaVelikovna = ctx.CreateNPC("Patrina Velikovna", 28).AddTraits(CE, Elf, Banshee).AddLocations(CastleRavenloft);

            var KolyanIndirovich = ctx.CreateNPC("Kolyan Indirovich", 7, 8, 9).AddTraits(Deceased, Human).AddLocations(VillageOfBarovia, BurgomasterHome);
            var IreenaKolyana = ctx.CreateNPC("Ireena Kolyana").AddTraits(LG, Human).AddLocations(VillageOfBarovia, BurgomasterHome);
            var Ismark = ctx.CreateNPC("Ismark the Lesser", 8, 9).AddTraits(LG, Human).AddLocations(VillageOfBarovia, BurgomasterHome, BloodVineTavern);

            var MadMary = ctx.CreateNPC("Mad Mary", 9, 19).AddTraits(CN, Human).AddLocations(VillageOfBarovia, MaryHouse);
            var Gertruda = ctx.CreateNPC("Gertruda", 9, 19).AddTraits(NG, Human).AddLocations(VillageOfBarovia, CastleRavenloft, MaryHouse);

            var Bildrath = ctx.CreateNPC("Bildrath", 8).AddTraits(LG, Human).AddLocations(VillageOfBarovia, BildrathMercantile);
            var Parriwimple = ctx.CreateNPC("Parriwimple", 8).AddTraits(LN, Human).AddLocations(VillageOfBarovia, BildrathMercantile);

            ctx.CreateRelationship(KolyanIndirovich, RelationshipType.Adopted, IreenaKolyana);
            ctx.CreateRelationship(KolyanIndirovich, RelationshipType.Parent, Ismark);

            ctx.CreateRelationship(MadMary, RelationshipType.Parent, Gertruda);

            ctx.CreateRelationship(Strahd, RelationshipType.Spouse, SashaIvliskova);
            ctx.CreateRelationship(Strahd, RelationshipType.Spouse, PatrinaVelikovna);

            ctx.CreateRelationship(Sergei, RelationshipType.Spouse, Tatyana);

            ctx.CreateRelationship(KingBarov, RelationshipType.Spouse, Ravenovia);
            ctx.CreateRelationship(KingBarov, RelationshipType.Parent, Strahd);
            ctx.CreateRelationship(KingBarov, RelationshipType.Parent, Sergei);

            ctx.CreateRelationship(Ravenovia, RelationshipType.Parent, Strahd);
            /*ctx.CreateRelationship(Ravenovia, RelationshipType.Parent, Sergei);

            var BildrathParents = ctx.CreateNPC("Bildrath Parents", 8);
            var BildrathSibling = ctx.CreateNPC("Bildrath Sibling", 8);
            ctx.CreateRelationship(BildrathParents, RelationshipType.Parent, Bildrath);
            ctx.CreateRelationship(BildrathParents, RelationshipType.Parent, BildrathSibling);
            ctx.CreateRelationship(BildrathSibling, RelationshipType.Parent, Parriwimple);*/
        }

        Factory.db.SaveChanges();
    }
}
