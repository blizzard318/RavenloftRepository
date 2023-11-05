internal static class Traits
{
    //Trait Types: Edition, Canon, Media, Location, Status, Item, Group, Alignment, Item, Class, Race, Creature, Language, Mistway, Cluster
    public static Trait NoLink = Factory.CreateTrait("NoLink", "NoLink"); //Do not generate a link or a reference.

    #region Universal Traits
    internal static class Edition
    {
        static Edition() => e0.ExtraInfo = "'Editionless' are official products that do not belong to any edition of Dungeons and Dragons.";
        public static List<Source.Trait> Editions = new List<Source.Trait>(7);
        private static Source.Trait CreateEdition(string name)
        {
            var retval = Factory.CreateSourceTrait(name, nameof(Edition));
            Editions.Add(retval);
            return retval;
        }
        public static Source.Trait e1  = CreateEdition("1st Ed"  );
        public static Source.Trait e2  = CreateEdition("2nd Ed"  );
        public static Source.Trait e3  = CreateEdition("3rd Ed"  );
        public static Source.Trait e35 = CreateEdition("3.5th Ed");
        public static Source.Trait e4  = CreateEdition("4th Ed"  );
        public static Source.Trait e5  = CreateEdition("5th Ed"  );
        public static Source.Trait e0  = CreateEdition("Editionless"  );
    }

    internal static class Canon //Annoying to create a page for this, maybe don't.
    {
        static Canon() => nc.ExtraInfo = pc.ExtraInfo = "Unless explicity stated as 'Potentially Canon' or 'Not Canon', everything else is treated Canon.";
        public static List<Source.Trait> Canons = new List<Source.Trait>(2);
        private static Source.Trait CreateCanon(string name)
        {
            var retval = Factory.CreateSourceTrait(name, nameof(Canon));
            Canons.Add(retval);
            return retval;
        }
        public static Source.Trait pc = CreateCanon("Potentially Canon");
        public static Source.Trait nc = CreateCanon("Not Canon"        );
    }

    internal static class Media
    {
        public static List<Source.Trait> Medias = new List<Source.Trait>(9);
        private static Source.Trait CreateMedia(string name)
        {
            var retval = Factory.CreateSourceTrait(name, nameof(Media));
            Medias.Add(retval);
            return retval;
        }
        public static Source.Trait sourcebook = CreateMedia("Sourcebook");
        public static Source.Trait module     = CreateMedia("Module"    );
        public static Source.Trait magazine   = CreateMedia("Magazine"  );
        public static Source.Trait novel      = CreateMedia("Novel"     );
        public static Source.Trait gamebook   = CreateMedia("Gamebook"  );
        public static Source.Trait audiobook  = CreateMedia("Audiobook" );
        public static Source.Trait videogame  = CreateMedia("Video Game");
        public static Source.Trait comic      = CreateMedia("Comic"     );
        public static Source.Trait boardgame  = CreateMedia("Board Game");
    }

    internal static class Location //Seperate them by Mistway,Cluster,Settlement,DarklordLair and else.
    {
        public static List<Trait> Locations = new List<Trait>();
        static Location()
        {
            Darklord.ExtraInfo = "Locations tagged as Darklord are their Lairs.";
            Locations.Add(Darklord);
        }
        private static Trait CreateLocation(string name)
        {
            var retval = Factory.CreateTrait(name, nameof(Location));
            Locations.Add(retval);
            return retval;
        }
        public static Trait Mistway    = CreateLocation(nameof(Traits.Mistway   )); //Subject to removal?
        public static Trait Settlement = CreateLocation(nameof(Traits.Settlement));
        public static Trait Darklord => Status.Darklord;
    }

    internal static class Status //Includes Groups
    {
        public static List<Trait> Statuses = new List<Trait>();
        static Status ()
        {
            Statuses.Add(Darklord);
            Statuses.Add(Vistani);
        }
        private static Trait CreateStatus(string name)
        {
            var retval = Factory.CreateTrait(name, nameof(Status));
            Statuses.Add(retval);
            return retval;
        }
        public static Trait Deceased = CreateStatus("Deceased");

        public static Trait Vistani  = Factory.CreateTrait("Vistani" , nameof(Status), nameof(Item));
        public static Trait Darklord = Factory.CreateTrait("Darklord", nameof(Status), nameof(Location));

        public static Trait Tatyana = CreateStatus("Reincarnations of Tatyana");
        public static Trait BarovianWineDistillersBrotherhood = CreateStatus("Barovian Wine Distillers Brotherhood");

        public static (Trait, Trait) Raunie = (CreateStatus("Raunie"), Vistani);
    }

    internal static class Alignment //Don't create a page for this.
    {
        private static Trait CreateAlignment(string name) => Factory.CreateTrait(name, nameof(Alignment));
        public static Trait LG = CreateAlignment("Lawful Good"    );
        public static Trait NG = CreateAlignment("Neutral Good"   );
        public static Trait CG = CreateAlignment("Chaotic Good"   );
        public static Trait LN = CreateAlignment("Lawful Neutral" );
        public static Trait TN = CreateAlignment("True Neutral"   );
        public static Trait CN = CreateAlignment("Chaotic Neutral");
        public static Trait LE = CreateAlignment("Lawful Evil"    );
        public static Trait NE = CreateAlignment("Neutral Evil"   );
        public static Trait CE = CreateAlignment("Chaotic Evil"   );
    }
    #endregion

    #region Domain-Tracked Traits
    internal static class Language
    {
        public static List<Trait> Languages = new List<Trait>();
        private static Trait CreateLanguage(string name)
        {
            var retval = Factory.CreateTrait(name, nameof(Language));
            Languages.Add(retval);
            return retval;
        }
        public static Trait Common = CreateLanguage("Common");
    }

    internal static class Race
    {
        public static List<Trait> Races = new List<Trait>();
        private static Trait CreateRace(string name)
        {
            var retval = Factory.CreateTrait(name, nameof(Race));
            Races.Add(retval);
            return retval;
        }
        public static Trait Human = CreateRace("Human");
        public static Trait Elf   = CreateRace("Elf"  );
    }

    internal static class Settlement //Everything here has to use Location.Settlement.Key
    {
        public static List<Trait> Settlements = new List<Trait>();
        private static Trait CreateSettlement(string name)
        {
            var retval = Factory.CreateTrait(name, nameof(Settlement));
            Settlements.Add(retval);
            return retval;
        }
        public static Trait VillageOfBarovia   = CreateSettlement("Village of Barovia"  );
        public static Trait TserPoolEncampment = CreateSettlement("Tser Pool Encampment");
        public static Trait Nartok = CreateSettlement("Nartok");
    }

    internal static class Mistway //Everything here has to use Location.Mistway.Key
    {
        public static List<Trait> Mistways = new List<Trait>(2); //Usually just 2.
        private static Trait CreateMistway(string name)
        {
            var retval = Factory.CreateTrait(name, nameof(Mistway));
            Mistways.Add(retval);
            return retval;
        }
    }
    internal static class Cluster //Everything here has to use Location.Cluster.Key
    {
        public static List<Trait> Clusters = new List<Trait>();
        private static Trait CreateCluster(string name)
        {
            var retval = Factory.CreateTrait(name, nameof(Cluster));
            Clusters.Add(retval);
            return retval;
        }
        public static Trait IslandOfTerror = CreateCluster("Island of Terror");
    }

    internal static class Creature
    {
        public static List<Trait> Creatures = new List<Trait>();
        static Creature()
        {
            KeeningSpirit.Item1.ExtraInfo = "Also known as 'Groaning Spirit'";
            KeeningSpirit.Item2.ExtraInfo = "Also known as 'Keening Spirit'";
        }
        private static Trait CreateCreature(string name)
        {
            var retval = Factory.CreateTrait(name, nameof(Creature));
            Creatures.Add(retval);
            return retval;
        }

        public static Trait Wolf        = CreateCreature("Wolf"        );
        public static Trait Bat         = CreateCreature("Bat"         );
        public static Trait Horse       = CreateCreature("Horse"       );
        public static Trait Cat         = CreateCreature("Cat"         );
        public static Trait GiantSpider = CreateCreature("Giant Spider");
        public static Trait HugeSpider  = CreateCreature("Huge Spider" );

        public static Trait Worg             = CreateCreature("Worg"             );
        public static Trait Nightmare        = CreateCreature("Nightmare"        );
        public static Trait Hellhound        = CreateCreature("Hellhound"        );
        public static Trait GreenSlime       = CreateCreature("Green Slime"      );
        public static Trait Gargoyle         = CreateCreature("Gargoyle"         );
        public static Trait RustMonster      = CreateCreature("Rust Monster"     );
        public static Trait RedDragon        = CreateCreature("Red Dragon"       );
        public static Trait ShadowDemon      = CreateCreature("Shadow Demon"     );
        public static Trait IronGolem        = CreateCreature("Iron Golem"       );
        public static Trait Trapper          = CreateCreature("Trapper"          );
        public static Trait GuardianPortrait = CreateCreature("Guardian Portrait");

        public static Trait Spirit        = CreateCreature("Spirit"        );
        public static Trait Ghost         = CreateCreature("Ghost"         );
        public static Trait Wraith        = CreateCreature("Wraith"        );
        public static Trait Spectre       = CreateCreature("Spectre"       );
        public static Trait Banshee       = CreateCreature("Banshee"       );

        public static Trait StrahdZombie = CreateCreature("Strahd Zombie");
        public static Trait Zombie       = CreateCreature("Zombie"       );
        public static Trait Skeleton     = CreateCreature("Skeleton"     );

        public static Trait Vampire = CreateCreature("Vampire");
        public static Trait Ghoul   = CreateCreature("Ghoul"  );
        public static Trait Wight   = CreateCreature("Wight"  );

        public static Trait Witch    = CreateCreature("Witch"   );
        public static Trait Werewolf = CreateCreature("Werewolf");

        public static (Trait, Trait) KeeningSpirit = (CreateCreature("Keening Spirit"), CreateCreature("Groaning Spirit"));
        public static (Trait, Trait) GroaningSpirit = (KeeningSpirit.Item1, KeeningSpirit.Item2);
    }
    #endregion
}
