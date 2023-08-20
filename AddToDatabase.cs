using System.Collections.Generic;
using static Relationship;
using static Cross;

internal static class AddToDatabase
{
    private static Source currentSource;
    public static void Add (RavenloftContext db) 
    {
        #region Universal Traits
        //Editions
        var e0  = ctx.CreateSourceTrait("Editionless"  , "Edition");
        e0.ExtraInfo = "Everything here are official products that do not belong to any edition of D&D.";
        var e1  = ctx.CreateSourceTrait("1st Edition"  , "Edition");
        var e2  = ctx.CreateSourceTrait("2nd Edition"  , "Edition");
        var e3  = ctx.CreateSourceTrait("3rd Edition"  , "Edition");
        var e35 = ctx.CreateSourceTrait("3.5th Edition", "Edition");
        var e4  = ctx.CreateSourceTrait("4th Edition"  , "Edition");
        var e5  = ctx.CreateSourceTrait("5th Edition"  , "Edition");

        //Canonicity
        var pc = ctx.CreateSourceTrait("Potentially Canon", "Canon");
        var nc = ctx.CreateSourceTrait("Not Canon"        , "Canon");
        nc.ExtraInfo = pc.ExtraInfo = "Unless explicity stated as 'Potentially Canon' or 'Not Canon', everything else is treated Canon.";

        //Source types
        var comic      = ctx.CreateSourceTrait("Comic"      , "Media");
        var module     = ctx.CreateSourceTrait("Module"     , "Media");
        var novel      = ctx.CreateSourceTrait("Novel"      , "Media");
        var gamebook   = ctx.CreateSourceTrait("Gamebook"   , "Media");
        var sourcebook = ctx.CreateSourceTrait("Sourcebook" , "Media");
        var magazine   = ctx.CreateSourceTrait("Magazine"   , "Media");
        var videogame  = ctx.CreateSourceTrait("Video Game" , "Media");
        var boardgame  = ctx.CreateSourceTrait("Board Game" , "Media");

        //Locations
        var Mistway  = ctx.CreateTrait("Mistway", "Location");
        var Cluster  = ctx.CreateTrait("Cluster", "Location");

        //Exclusive to Ravenloft Types
        var Vistani  = ctx.CreateTrait("Vistani" , "Group,Status,Location,Item");
        var Darklord = ctx.CreateTrait("Darklord", "Status,Location");
        Darklord.ExtraInfo = "Locations tagged as Darklord are their Lairs.";

        //Alignment
        var LG = ctx.CreateTrait("Lawful Good"    , "Alignment");
        var NG = ctx.CreateTrait("Neutral Good"   , "Alignment");
        var CG = ctx.CreateTrait("Chaotic Good"   , "Alignment");
        var LN = ctx.CreateTrait("Lawful Neutral" , "Alignment");
        var TN = ctx.CreateTrait("True Neutral"   , "Alignment");
        var CN = ctx.CreateTrait("Chaotic Neutral", "Alignment");
        var LE = ctx.CreateTrait("Lawful Evil"    , "Alignment");
        var NE = ctx.CreateTrait("Neutral Evil"   , "Alignment");
        var CE = ctx.CreateTrait("Chaotic Evil"   , "Alignment");

        //Item traits
        var Mundane = ctx.CreateTrait("Mundane", "Item");
        var Magical = ctx.CreateTrait("Magical", "Item");
        var Melee   = ctx.CreateTrait("Melee"  , "Item");
        var Ranged  = ctx.CreateTrait("Ranged" , "Item");
        var Armor   = ctx.CreateTrait("Armor"  , "Item");
        var Misc    = ctx.CreateTrait("Miscellaneous", "Item");
        Misc.ExtraInfo = "For anything that isn't a Weapon or Armor";

        //Status
        var Deceased = ctx.CreateTrait("Deceased", "Status");
        var Raunie   = ctx.CreateTrait("Raunie"  , "Status");

        //Languages
        var Common = ctx.CreateTrait("Common", "Language");

        //Races
        var Human = ctx.CreateTrait("Human", "Race");
        var Elf   = ctx.CreateTrait("Elf"  , "Race");

        // ## Add these with to page count.
        //Groups
        var BarovianWineDistillersBrotherhood = ctx.CreateTrait("Barovian Wine Distillers Brotherhood", "Group"));

        //Creature Types
        var Wolf  = ctx.CreateTrait("Wolf" , "Creature");
        var Bat   = ctx.CreateTrait("Bat"  , "Creature");
        var Horse = ctx.CreateTrait("Horse", "Creature");
        var Cat   = ctx.CreateTrait("Cat"  , "Creature");
        var GiantSpider = ctx.CreateTrait("Giant Spider", "Creature");
        var HugeSpider  = ctx.CreateTrait("Huge Spider" , "Creature");

        var Worg = ctx.CreateTrait("Worg", "Creature");
        var Nightmare = ctx.CreateTrait("Nightmare", "Creature");
        var Hellhound = ctx.CreateTrait("Hellhound", "Creature");
        var GreenSlime = ctx.CreateTrait("Green Slime", "Creature");
        var Gargoyles = ctx.CreateTrait("Gargoyles", "Creature");
        var RustMonster = ctx.CreateTrait("Rust Monster", "Creature");
        var RedDragon = ctx.CreateTrait("Red Dragon", "Creature");
        var GuardianPortrait = ctx.CreateTrait("Guardian Portrait", "Creature");
        var ShadowDemon = ctx.CreateTrait("Shadow Demon", "Creature");
        var IronGolem = ctx.CreateTrait("Iron Golem", "Creature");
        var Trapper = ctx.CreateTrait("Trapper", "Creature");

        var Spirit      = ctx.CreateTrait("Spirit" , "Creature");
        var Ghost       = ctx.CreateTrait("Ghost"  , "Creature");
        var Wraith      = ctx.CreateTrait("Wraith" , "Creature");
        var Spectre     = ctx.CreateTrait("Spectre", "Creature");
        var Banshee     = ctx.CreateTrait("Banshee", "Creature");
        var KeeningSpirit = ctx.CreateTrait("Keening Spirit", "Creature");
        KeeningSpirit.ExtraInfo = "Also known as 'Groaning Spirit'";

        var StrahdZombie = ctx.CreateTrait("Strahd Zombie", "Creature");
        var Zombie       = ctx.CreateTrait("Zombie", "Creature");
        var Skeleton     = ctx.CreateTrait("Skeleton", "Creature");

        var Vampire = ctx.CreateTrait("Vampire", "Creature");
        var Ghoul   = ctx.CreateTrait("Ghoul"  , "Creature");
        var Wight   = ctx.CreateTrait("Wight"  , "Creature");

        var Witch    = ctx.CreateTrait("Witch"   , "Creature");
        var Werewolf = ctx.CreateTrait("Werewolf", "Creature");
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
            if (!ctx.CreateSource("I6: Ravenloft", releaseDate, ExtraInfo, e1, module)) return;

            ctx.AddTraitApperance(Vampire);
            ctx.AddTraitApperance(Human);

            var Barovia = ctx.CreateDomain("Barovia").AddTraits(Vampire, Human);

            var Strahd = ctx.CreateNPC("Count Strahd von Zarovich").AddDomains(Barovia).AddTraits(Vampire, Human, CE, Darklord).AddInfo("'ClosedBorders':'No one has left Barovia for centuries. This is because of the trapping fog that exists everywhere in Barovia. Once it is breathed, it infuses itself around a character's vital organs as a neutralized poison. The fog does not taste or smell any different than normal fog. It does not harm characters as long as they continue to breathe the air in Barovia. However, when they leave Barovia, the poison becomes active. Characters must save vs. poison or start to choke. Unless choking characters reenter Barovia within 24 hours, they die. The choking stops as soon as they breathe the fog again.  The fog is magically produced by Strahd and disappears entirely upon his destruction.'");

            var MadamEva = ctx.CreateNPC("Madam Eva").AddDomains(Barovia).AddTraits(Vistani, Human, CN, Raunie);
            var Sergei = ctx.CreateNPC("Sergei von Zarovich", 1, 4, 30, 31).AddDomains(Barovia).AddTraits(Deceased, Human);

            var KolyanIndirovich = ctx.CreateNPC("Kolyan Indirovich", 7, 8, 9).AddDomains(Barovia).AddTraits(Deceased, Human);
            var IreenaKolyana = ctx.CreateNPC("Ireena Kolyana").AddDomains(Barovia).AddTraits(LG, Human);
            var Bildrath = ctx.CreateNPC("Bildrath", 8).AddDomains(Barovia).AddTraits(LG, Human);
            var Parriwimple = ctx.CreateNPC("Parriwimple", 8).AddDomains(Barovia).AddTraits(LN, Human);
            var Arik = ctx.CreateNPC("Arik", 8).AddDomains(Barovia).AddTraits(CN, Human);
            var Ismark = ctx.CreateNPC("Ismark the Lesser", 8, 9).AddDomains(Barovia).AddTraits(LG, Human);
            var MadMary = ctx.CreateNPC("Mad Mary", 9, 19).AddDomains(Barovia).AddTraits(CN, Human);
            var Gertruda = ctx.CreateNPC("Gertruda", 9, 19).AddDomains(Barovia).AddTraits(NG, Human);
            var Donavich = ctx.CreateNPC("Donavich", 9).AddDomains(Barovia).AddTraits(LG, Human);


            var Tatyana = ctx.CreateNPC("Tatyana", 1, 30, 31).AddDomains(Barovia).AddTraits(Deceased);
            var SashaIvliskova = ctx.CreateNPC("Sasha Ivliskova", 28).AddDomains(Barovia).AddTraits(CE, Human, Vampire);
            var PatrinaVelikovna = ctx.CreateNPC("Patrina Velikovna", 28).AddDomains(Barovia).AddTraits(CE, Elf, Banshee);
            var Ravenovia = ctx.CreateNPC("Queen Ravenovia", 5, 28, 30).AddDomains(Barovia).AddTraits(Deceased, Human);
            var KingBarov = ctx.CreateNPC("King Barov", 28, 30).AddDomains(Barovia).AddTraits(Deceased);

            var BildrathParents = ctx.CreateNPC("Bildrath Parents", 8).AddDomains(Barovia);
            var BildrathSibling = ctx.CreateNPC("Bildrath Sibling", 8).AddDomains(Barovia);

            ctx.CreateRelationship(BildrathParents, RelationshipType.Parent, Bildrath);
            ctx.CreateRelationship(BildrathParents, RelationshipType.Parent, BildrathSibling);
            ctx.CreateRelationship(BildrathSibling, RelationshipType.Parent, Parriwimple);

            ctx.CreateRelationship(MadMary, RelationshipType.Parent, Gertruda);

            ctx.CreateRelationship(KolyanIndirovich, RelationshipType.Adopted, IreenaKolyana);
            ctx.CreateRelationship(KolyanIndirovich, RelationshipType.Parent, Ismark);

            ctx.CreateRelationship(KingBarov, RelationshipType.Parent, Strahd);
            ctx.CreateRelationship(KingBarov, RelationshipType.Parent, Sergei);
            ctx.CreateRelationship(KingBarov, RelationshipType.Spouse, Ravenovia);
            ctx.CreateRelationship(Ravenovia, RelationshipType.Parent, Strahd);
            ctx.CreateRelationship(Ravenovia, RelationshipType.Parent, Sergei);

            ctx.CreateRelationship(Strahd, RelationshipType.Spouse, SashaIvliskova);
            ctx.CreateRelationship(Strahd, RelationshipType.Spouse, PatrinaVelikovna);

            ctx.CreateRelationship(Sergei, RelationshipType.Spouse, Tatyana);

            ctx.CreateLocation("The Old Svalich Road", 7).AddDomains(Barovia);
            ctx.CreateLocation("The Gates of Barovia", 7).AddDomains(Barovia);
            ctx.CreateLocation("The Svalich Woods", 1, 6, 7, 8).AddDomains(Barovia).AddTraits(Vistani);
            ctx.CreateLocation("The River Ivlis", 8).AddDomains(Barovia);

            ctx.CreateLocation("Village of Barovia", 1, 6, 7).AddDomains(Barovia).AddTraits(Vistani).AddNPCs(IreenaKolyana,KolyanIndirovich, Bildrath, Parriwimple, Ismark, MadMary, Gertruda, Arik, Donavich);
            ctx.CreateLocation("Bildrath's Mercantile", 8).AddDomains(Barovia).AddNPCs(Bildrath, Parriwimple);
            ctx.CreateLocation("Blood of the Vine Tavern", 8, 9).AddDomains(Barovia).AddNPCs(Arik, Ismark).AddInfo("Also known as 'Blood on the Vine' Tavern.");
            ctx.CreateLocation("Mad Mary's Townhouse", 9).AddDomains(Barovia).AddNPCs(MadMary, Gertruda);
            ctx.CreateLocation("Burgomaster's Home", 1, 9).AddDomains(Barovia).AddNPCs(KolyanIndirovich, IreenaKolyana, Ismark);
            ctx.CreateLocation("Burgomaster's Guest House", 9).AddDomains(Barovia);
            ctx.CreateLocation("Church of Barovia", 9, 10).AddDomains(Barovia).AddNPCs(Donavich);
            ctx.CreateLocation("Cemetery of Barovia", 9, 11).AddDomains(Barovia).AddTraits(Spirit);

            ctx.CreateLocation("Road Junction", 11).AddDomains(Barovia);

            ctx.CreateLocation("Tser Pool Encampment", 11).AddDomains(Barovia).AddNPCs(MadamEva).AddTraits(Vistani);
            ctx.CreateLocation("Madam Eva's Tent", 11).AddDomains(Barovia).AddNPCs(MadamEva).AddTraits(Vistani);

            ctx.CreateLocation("Tser Falls", 11).AddDomains(Barovia);
            ctx.CreateLocation("The Gates of Ravenloft", 11, 12).AddDomains(Barovia);
            ctx.CreateLocation("Castle Ravenloft").AddDomains(Barovia).AddTraits(Darklord).AddNPCs(
                Strahd, Gertruda, Sergei, 
                ctx.CreateNPC("Guardian Of Sorrow", 16).AddDomains(Barovia).AddTraits(NE),
                ctx.CreateNPC("Lief Lipsiege", 17).AddDomains(Barovia).AddTraits(CE, Human),
                ctx.CreateNPC("Helga", 18).AddDomains(Barovia).AddTraits(CE, Human, Vampire),
                ctx.CreateNPC("Cyrus Belview", 23).AddDomains(Barovia).AddTraits(CN, Human),
                ctx.CreateNPC("Spectre Ab-Centeer", 27).AddDomains(Barovia).AddTraits(Deceased),
                ctx.CreateNPC("Artista DeSlop", 27).AddDomains(Barovia).AddTraits(Deceased),
                ctx.CreateNPC("Lady Isolde Yunk", 27).AddDomains(Barovia).AddTraits(Deceased).AddInfo("Also known as 'Isolde the Incredible'."),
                ctx.CreateNPC("Prince Aeial Du Plumette", 27).AddDomains(Barovia).AddTraits(LE, Ghost).AddInfo("Also known as 'Aerial the Heavy'."),
            var MaryaMarkovia = ctx.CreateNPC("Marya Markovia", 27, 28).AddDomains(Barovia).AddTraits(Deceased);
            var Endorovich = ctx.CreateNPC("Endorovich the Terrible", 27, 28).AddDomains(Barovia).AddTraits(LE, Spectre);
            var DorfniyaDilisnya = ctx.CreateNPC("Duchess Dorfniya Dilisnya", 28).AddDomains(Barovia).AddTraits(Deceased);
            var Pidlwik = ctx.CreateNPC("Pidlwik", 28).AddDomains(Barovia).AddTraits(Deceased);
            var LeanneTriksky = ctx.CreateNPC("Sir Leanne Triksky", 28).AddDomains(Barovia).AddTraits(Deceased).AddInfo("Also known as 'Sir Lee the Crusher'.");
            var TashaPetrovna = ctx.CreateNPC("Tasha Petrovna", 28).AddDomains(Barovia).AddTraits(Deceased);
            var KingToisky = ctx.CreateNPC("King Toisky", 28).AddDomains(Barovia).AddTraits(Deceased);
            var IntreeKatsky = ctx.CreateNPC("King Intree Katsky", 28).AddDomains(Barovia).AddTraits(Deceased).AddInfo("Also known as 'Katsky the Bright'.");
            var StahbalIndiBhak = ctx.CreateNPC("Stahbal Indi-Bhak", 28).AddDomains(Barovia).AddTraits(LE, Wight);
            var Khazan = ctx.CreateNPC("Khazan", 28).AddDomains(Barovia).AddTraits(Deceased);
            var ElsaFallona = ctx.CreateNPC("Elsa Fallona", 28).AddDomains(Barovia).AddTraits(Deceased);
            var SedrikSpinwitovich = ctx.CreateNPC("Sir Sedrik Spinwitovich", 28).AddDomains(Barovia).AddTraits(Deceased).AddInfo("Also known as 'Admiral Spinwitovich'");
            var Animus = ctx.CreateNPC("Animus", 28).AddDomains(Barovia).AddTraits(Deceased);
            var ErikVonderbucks = ctx.CreateNPC("Sir Erik Vonderbucks", 28).AddDomains(Barovia).AddTraits(Deceased);
            var IvanDeRose = ctx.CreateNPC("Ivan DeRose", 28).AddDomains(Barovia).AddTraits(Deceased);
            var StephanGregorovich = ctx.CreateNPC("Stephan Gregorovich", 28).AddDomains(Barovia).AddTraits(Deceased);
            var IntreeSikValoo = ctx.CreateNPC("Intree Sik-Valoo", 28).AddDomains(Barovia).AddTraits(Deceased);
            var ArdentPallette = ctx.CreateNPC("Ardent Pallette", 28).AddDomains(Barovia).AddTraits(Deceased);
            var IvanIvanovich = ctx.CreateNPC("Ivan Ivanovich", 28).AddDomains(Barovia).AddTraits(Deceased);
            var AnnaPetrovna = ctx.CreateNPC("Anna Petrovna", 28);
            var CirilRomulich = ctx.CreateNPC("Prefect Ciril Romulich", 28).AddDomains(Barovia).AddTraits(Deceased);
            var Dollarsigns = ctx.CreateNPC("$$", 29).AddDomains(Barovia).AddTraits(Deceased);
            var StFinderway = ctx.CreateNPC("St. Finderway", 29).AddDomains(Barovia).AddTraits(Deceased);
            var KingDostron = ctx.CreateNPC("King Dostron", 29).AddDomains(Barovia).AddTraits(Deceased);
            var GralmoreNimblenobs = ctx.CreateNPC("Gralmore Nimblenobs", 29).AddDomains(Barovia).AddTraits(Deceased);
            var AmericoStandardski = ctx.CreateNPC("Americo Standardski", 29).AddDomains(Barovia).AddTraits(Deceased);
            var Beucephalus = ctx.CreateNPC("Beucephalus", 29, 30).AddDomains(Barovia).AddTraits(Horse, Nightmare);
            var TatsaulEris = ctx.CreateNPC("Tatsaul Eris", 30).AddDomains(Barovia).AddTraits(Deceased);
            );

            AddApp(I6Ravenloft, Spirit, 11, 12, 19);
            Cross.Add(Spirit, Barovia);
            Cross.Add(Spirit, BarovianCemetery);
            Cross.Add(Spirit, CastleRavenloft);

            AddApp(I6Ravenloft, RedDragon, 13);
            Cross.Add(RedDragon, Barovia);
            Cross.Add(RedDragon, CastleRavenloft);

            AddApp(I6Ravenloft, ShadowDemon, 24);
            Cross.Add(ShadowDemon, Barovia);
            Cross.Add(ShadowDemon, CastleRavenloft);

            AddApp(I6Ravenloft, Nightmare, 29, 30);
            Cross.Add(Nightmare, Barovia);
            Cross.Add(Nightmare, CastleRavenloft);

            AddApp(I6Ravenloft, GiantSpider, 12, 19);
            Cross.Add(GiantSpider, Barovia);
            Cross.Add(GiantSpider, CastleRavenloft);

            AddApp(I6Ravenloft, HugeSpider, 28);
            Cross.Add(HugeSpider, Barovia);
            Cross.Add(HugeSpider, CastleRavenloft);

            AddApp(I6Ravenloft, Skeleton, 23);
            Cross.Add(Skeleton, Barovia);
            Cross.Add(Skeleton, CastleRavenloft);

            AddApp(I6Ravenloft, Banshee, 28);
            Cross.Add(Banshee, Barovia);
            Cross.Add(Banshee, CastleRavenloft);

            AddApp(I6Ravenloft, Trapper, 29);
            Cross.Add(Trapper, Barovia);
            Cross.Add(Trapper, CastleRavenloft);

            AddApp(I6Ravenloft, KeeningSpirit, 12);
            Cross.Add(KeeningSpirit, Barovia);
            Cross.Add(KeeningSpirit, CastleRavenloft);

            AddApp(I6Ravenloft, Gargoyles, 12, 13);
            Cross.Add(Gargoyles, Barovia);
            Cross.Add(Gargoyles, CastleRavenloft);

            AddApp(I6Ravenloft, RustMonster, 12);
            Cross.Add(RustMonster, Barovia);
            Cross.Add(RustMonster, CastleRavenloft);

            AddApp(I6Ravenloft, GuardianPortrait, 21);
            Cross.Add(GuardianPortrait, Barovia);
            Cross.Add(GuardianPortrait, CastleRavenloft);

            AddApp(I6Ravenloft, Spectre, 12, 27, 28);
            Cross.Add(Spectre, Barovia);
            Cross.Add(Spectre, CastleRavenloft);

            AddApp(I6Ravenloft, GreenSlime, 12);
            Cross.Add(GreenSlime, Barovia);
            Cross.Add(GreenSlime, GatesOfRavenloft);

            AddApp(I6Ravenloft, Horse, 11, 29, 30);
            Cross.Add(Horse, Strahd);
            Cross.Add(Horse, Barovia);

            AddApp(I6Ravenloft, Wight, 6, 28);
            Cross.Add(Wight, Barovia);
            Cross.Add(Wight, CastleRavenloft);

            AddApp(I6Ravenloft, Wraith, 6, 12, 18);
            Cross.Add(Wraith, Barovia);
            Cross.Add(Wraith, CastleRavenloft);

            AddApp(I6Ravenloft, Ghost, 6, 27);
            Cross.Add(Ghost, Barovia);
            Cross.Add(Ghost, CastleRavenloft);

            AddApp(I6Ravenloft, Ghoul, 6);
            Cross.Add(Ghoul, Barovia);

            AddApp(I6Ravenloft, Worg, 1, 3, 6, 8);
            Cross.Add(Worg, Barovia);
            Cross.Add(Zombie, Strahd);

            AddApp(I6Ravenloft, Bat, 1, 3, 6, 12, 27);
            Cross.Add(Bat, Barovia);
            Cross.Add(Bat, Strahd);
            Cross.Add(Bat, CastleRavenloft);

            AddApp(I6Ravenloft, Zombie, 6, 23);
            Cross.Add(Zombie, Barovia);
            Cross.Add(Zombie, Strahd);

            AddApp(I6Ravenloft, StrahdZombie, 3, 12, 17, 24);
            Cross.Add(StrahdZombie, Barovia);
            Cross.Add(StrahdZombie, Strahd);
            Cross.Add(StrahdZombie, CastleRavenloft);

            AddApp(I6Ravenloft, Cat, 21);
            Cross.Add(Cat, Barovia);
            Cross.Add(Cat, CastleRavenloft);

            AddApp(I6Ravenloft, Witch, 21, 22);
            Cross.Add(Witch, Barovia);
            Cross.Add(Witch, CastleRavenloft);

            AddApp(I6Ravenloft, Hellhound, 29);
            Cross.Add(Hellhound, Barovia);
            Cross.Add(Hellhound, CastleRavenloft);

            AddApp(I6Ravenloft, Werewolf, 24);
            Cross.Add(Werewolf, Barovia);
            Cross.Add(Werewolf, CastleRavenloft);

            AddApp(I6Ravenloft, IronGolem, 26);
            Cross.Add(IronGolem, Barovia);
            Cross.Add(IronGolem, CastleRavenloft);
            
            var Tarokka = Add(new Item("Tarokka"));
            AddApp(I6Ravenloft, Tarokka, 1, 4, 5);
            Cross.Add(
                items: new[] { Tarokka },
                domains: new[] { Barovia },
                npcs: new[] { MadamEva },
                locations: new[] { MadamEvaTent },
                traits: new[] { Mundane, Vistani }
            );

            var Sunsword = Add(new Item("Sunsword"));
            AddApp(I6Ravenloft, Sunsword, 5, 31);
            Cross.Add(
                items: new[] { Sunsword },
                domains: new[] { Barovia },
                locations: new[] { CastleRavenloft },
                traits: new[] { Magical, Melee }
            );
            
            var IconOfRavenloft = Add(new Item("Icon of Ravenloft"));
            AddApp(I6Ravenloft, IconOfRavenloft, 14);
            Cross.Add(
                items: new[] { IconOfRavenloft },
                domains: new[] { Barovia },
                locations: new[] { CastleRavenloft },
                traits: new[] { Magical, LG }
            );
            
            var HolySymbolOfRavenkind = Add(new Item("Holy Symbol of Ravenkind"));
            AddApp(I6Ravenloft, HolySymbolOfRavenkind, 17, 30);
            Cross.Add(
                items: new[] { HolySymbolOfRavenkind },
                domains: new[] { Barovia },
                locations: new[] { CastleRavenloft },
                traits: new[] { Magical, LG }
            );

            var TomeOfStrahd = Add(new Item("Tome of Strahd"));
            AddApp(I6Ravenloft, TomeOfStrahd, 11, 31);
            Cross.Add(
                items: new[] { TomeOfStrahd },
                domains: new[] { Barovia },
                npcs: new[] { Strahd },
                locations: new[] { CastleRavenloft },
                traits: new[] { Mundane }
            );
        }

        db.SaveChanges();
    }
}
