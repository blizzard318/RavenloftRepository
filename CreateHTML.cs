﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NUglify;
using System.Text;
using System.Text.RegularExpressions;
using static Traits;

internal static class CreateHTML
{
    private static string CreateLink(string subdomain, string name) => $"<a href=\"/{subdomain}/{name}\">{name}</a>";
    private static void AddLink(this ICollection<string> list, string subdomain, string name) => list.Add(CreateLink(subdomain, name));
    private static string[] Linkify(this ICollection<string> list, string subdomain)
    {
        var retval = new List<string>(list.Count);
        foreach (var item in list) retval.Add(CreateLink(subdomain, item));
        return retval.ToArray();
    }

    #region PREGENERATED DATA
    private class Entity
    {
        public readonly string Names;
        public readonly string[] Editions;
        public Entity(string names, string[] editions) { Names = names; Editions = editions; }
    }
    private static class Get
    {
        private static bool Pregenerated = false;
        private static readonly Dictionary<string, Entity> Domains    = new Dictionary<string, Entity>();
        private static readonly Dictionary<string, Entity> Characters = new Dictionary<string, Entity>();
        private static readonly Dictionary<string, Entity> Locations  = new Dictionary<string, Entity>();
        private static readonly Dictionary<string, Entity> Items      = new Dictionary<string, Entity>();

        public static void Pregenerate() //I don't trust this to be a static constructor.
        {
            if (Pregenerated) return;
            Pregenerated = true;

            Fill("Domain"   , Domains   , Factory.db.Domains  , Factory.db.domainAppearances  );
            Fill("Character", Characters, Factory.db.NPCs     , Factory.db.npcAppearances     );
            Fill("Location" , Locations , Factory.db.Locations, Factory.db.locationAppearances);
            Fill("Item"     , Items     , Factory.db.Items    , Factory.db.itemAppearances    );

            void Fill<T, U>(string Subdomain, Dictionary<string, Entity> ToFill, DbSet<T> ToRead, DbSet<U> Appearances) 
                where T : UseVariableName where U : Appearance, IHasEntity<T>
            {
                var All = ToRead.ToHashSet();
                var OriginalNames = ToRead.Select(s => s.OriginalName).ToHashSet();

                foreach (var OriginalName in OriginalNames)
                {
                    var NamesOfSame = All.Where(d => d.OriginalName == OriginalName).Select(s => s.Name).Distinct().ToArray();
                    if (!All.Any(a => a.Traits.Contains(Traits.NoLink))) NamesOfSame = NamesOfSame.Linkify(Subdomain);

                    var Editions = new string[Traits.Edition.Editions.Count];
                    var Sources = Appearances.Include(a => a.Source.Traits).Where(a => a.Entity.OriginalName == OriginalName).Select(a => a.Source);
                    foreach (var Source in Sources)
                    {
                        var Edition = Source.Traits.Single(t => t.Type == nameof(Traits.Edition));
                        Editions[Traits.Edition.Editions.IndexOf(Edition)] = "X";
                    }

                    ToFill.Add(OriginalName, new Entity(string.Join("/", NamesOfSame), Editions));
                }
            }
        }
        public static string[] AllOriginalsOf (Type type) => GetEntity(type).Keys.ToArray();
        public static string TotalNamesOf<T>(T i) where T : UseVariableName => TotalNamesOf<T>(i.OriginalName);
        public static string TotalNamesOf<T>(string OriginalName) where T : UseVariableName => GetEntity(typeof(T))[OriginalName].Names;
        public static string[] EditionsOf<T>(T i) where T : UseVariableName => EditionsOf<T>(i.OriginalName);
        public static string[] EditionsOf<T>(string OriginalName) where T : UseVariableName => GetEntity(typeof(T))[OriginalName].Editions;

        private static Dictionary<string, Entity> GetEntity (Type type)
        {
                 if (type == typeof(Domain  )) return Domains   ;
            else if (type == typeof(NPC     )) return Characters;
            else if (type == typeof(Location)) return Locations ;
            else if (type == typeof(Item    )) return Items     ;
            throw new NotImplementedException();
        }
    }
    #endregion

    #region PAGE CREATOR
    private static StringBuilder sb = new StringBuilder();
    private enum SortMethod { alphabet, date }
    private class Table : IDisposable
    {
        private static readonly Dictionary<string, (SortMethod method, int index)> TablesToSort = new Dictionary<string, (SortMethod, int)>();
        public static void SortAllTablesOnPage()
        {
            if (TablesToSort.Count == 0) return;
            foreach (var table in TablesToSort)
            {
                switch (table.Value.method)
                {
                    case SortMethod.alphabet:
                        CreateHTML.sb.AppendLine($"sortTable('{table.Key}',{table.Value.index});");
                        break;
                    case SortMethod.date:
                        CreateHTML.sb.AppendLine($"sortDate('{table.Key}',{table.Value.index});");
                        break;
                }
            }
            TablesToSort.Clear();
        }

        private readonly string TableID;
        private readonly StringBuilder sb;
        public Table(string title, string? caption = null, StringBuilder? stringBuilder = null)
        {
            TablesToSort.Add(TableID = title, (SortMethod.alphabet, 0));
            sb = stringBuilder ?? CreateHTML.sb;
            sb.AppendLine($"<b style='font-size:25px'>{title}</b>");
            sb.AppendLine($"<table cellspacing='0' cellpadding='3' rules='cols' border='1' id='{title}'>");
            if (!string.IsNullOrWhiteSpace(caption)) sb.AppendLine($"<caption>{caption}</caption>");
        }
        public void AdjustSort(SortMethod method, int index) => TablesToSort[TableID] = (method, index);
        public HeaderRow CreateHeaderRow() => new HeaderRow(this);
        public class HeaderRow : IDisposable
        {
            private readonly string TableID;
            private readonly StringBuilder sb;
            private int col = 0;
            public HeaderRow(Table table)
            {
                TableID = table.TableID;
                sb = table.sb;
                sb.AppendLine("<tr style='background-color:var(--header)'>");
            }
            public HeaderRow CreateHeader(params string[] titles)
            {
                foreach (var title in titles)
                {
                    sb.AppendLine("<th scope='col'>");
                    EndHeader(title);
                }
                return this;
            }
            public HeaderRow CreateSortHeader(params string[] titles)
            {
                foreach (var title in titles)
                {
                    sb.AppendLine($"<th scope='col' onclick=\"sortTable('{TableID}',{col})\" style='cursor:pointer'>");
                    EndHeader(title);
                }
                return this;
            }
            public HeaderRow CreateSortDateHeader(params string[] titles)
            {
                foreach (var title in titles)
                {
                    sb.AppendLine($"<th scope='col' onclick=\"sortDate('{TableID}',{col})\" style='cursor:pointer'>");
                    EndHeader(title);
                }
                return this;
            }
            public HeaderRow CreateEditionHeaders()
            {
                foreach (var edition in Traits.Edition.Editions)
                    sb.AppendLine($"<th scope='col'>").AppendLine($"<b>{edition.Key}</b>").AppendLine("</th>");
                col += Traits.Edition.Editions.Count;
                return this;
            }
            private void EndHeader(string title)
            {
                sb.AppendLine($"<b>{title}</b>").AppendLine("</th>");
                col++;
            }
            public void Dispose() => sb.AppendLine("</tr>");
        }
        public void AddRows(string[] columns)
        {
            sb.AppendLine("<tr>");
            foreach (var column in columns) sb.AppendLine($"<td>{column}</td>");
            sb.AppendLine("</tr>");
        }
        public void AddRows(string HTMLclass, string[] columns)
        {
            sb.AppendLine($"<tr stye='{HTMLclass}'>");
            foreach (var column in columns) sb.AppendLine($"<td>{column}</td>");
            sb.AppendLine("</tr>");
        }
        public void Dispose() => sb.AppendLine("</table><br/>");
    }
    private static void SaveHTML(string DirectoryName)
    {
        sb.AppendLine("</body>").AppendLine("<script>init();");
        Table.SortAllTablesOnPage();
        sb.AppendLine("</script>").AppendLine("</html>");
        string filepath = "index.html";
        if (!string.IsNullOrEmpty(DirectoryName))
        {
            var dir = Directory.CreateDirectory(DirectoryName).ToString();
            filepath = Path.Join(dir, filepath);
        }
        var html = sb.ToString();
        //html = Uglify.Html(html).Code; //Compression.
        File.WriteAllText(filepath, html);
    }
    private static void CreateOfficialHeader(string title, int depth = 0)
    {
        Get.Pregenerate();
        const string DepthText = "../";
        var db = new StringBuilder(DepthText.Length * depth);
        for (int i = 0; i < depth; i++) db.Append(DepthText);

        sb.Clear();
        sb.AppendLine("<!DOCTYPE html>");
        sb.AppendLine("<html>");

        sb.AppendLine("<head>");
            sb.AppendLine("<meta charset='utf-8'>");
            sb.AppendLine($"<title>{title}</title>");
            sb.AppendLine("<meta name='theme-color' content='black'>"); //Always black
            sb.AppendLine("<meta name='viewport' content='width=device-width, initial-scale=1'>");
            sb.AppendLine("<meta name='description' content='Ravenloft Repository'>");
            sb.Append("<link rel='stylesheet' href='").Append(db).AppendLine("styles.css'>");
            sb.Append("<link rel='shortcut icon' href='").Append(db).AppendLine("favicon.ico'>");
            sb.Append("<script src='").Append(db).AppendLine("sort.js'></script>");
        sb.AppendLine("</head>");

        sb.AppendLine("<body>");

        sb.AppendLine("<span style='float:right;display:inline-block;height:0px'>");
            sb.AppendLine("<label for='darkmode'>Dark Mode</label>");
            sb.AppendLine("<input type='checkbox' id='darkmode'>");
        sb.AppendLine("</span>");

        sb.AppendLine("<h1>Ravenloft Catalogue</h1><hr/>");

        sb.AppendLine("<h2>");
            sb.Append("<a href='").Append(db).AppendLine("'>Official</a> | ");
            sb.AppendLine("<a href='../3rdParty'>3rd Party</a>");
        sb.AppendLine("</h2><hr />");

        sb.AppendLine("<h2>");
            sb.Append("<a href='").Append(db).AppendLine("Source'>Sources</a> | ");
            sb.Append("<a href='").Append(db).AppendLine("Domain'>Domains</a> | ");
            sb.Append("<a href='").Append(db).AppendLine("Location'>Locations</a> | ");
            sb.Append("<a href='").Append(db).AppendLine("Character'>Characters</a> | ");
            sb.Append("<a href='").Append(db).Append("Item'>Items</a>").AppendLine("<br/>");
            sb.Append("<a href='").Append(db).AppendLine("Creature'>Creatures</a> | ");
            sb.Append("<a href='").Append(db).AppendLine("Group'>Groups</a> | ");
            sb.Append("<a href='").Append(db).AppendLine("Language'>Languages</a>");
        sb.AppendLine("</h2><hr />");
    }
    private class SubHeader : IDisposable
    {
        private readonly List<Page> pages = new List<Page>();
        public Page CreatePage (string ID)
        {
            var retval = new Page(ID);
            pages.Add(retval);
            return retval;
        }
        public void Dispose()
        {
            sb.AppendLine("<h2>");
            for (int i = 0; i < pages.Count - 1; i++)
                sb.AppendLine($"<input type='button' onclick=\"OpenPage('{pages[i].ID}')\" value='{pages[i].ID}'> | ");
            sb.AppendLine($"<input type='button' onclick=\"OpenPage('{pages[pages.Count -1].ID}')\" value='{pages[pages.Count - 1].ID}'>");
            sb.Append("</h2>").AppendLine("<br/>");

            sb.AppendLine($"<div class='page' id='{pages[0].ID}' style='display:block'>");
            sb.Append(pages[0].contents);
            for (int i = 1; i < pages.Count; i++)
            {
                sb.AppendLine($"<div class='page' id='{pages[i].ID}' style='display:none'>");
                sb.Append(pages[i].contents);
            }
        }
        public class Page : IDisposable
        {
            public readonly string ID;
            public readonly StringBuilder contents = new StringBuilder();
            public Page(string ID) => this.ID = ID;
            public Table CreateTable(string title, string? caption = null) => new Table(title, caption, contents);
            public void Dispose() => contents.AppendLine("</div>");
        }
    }
    private static void SetTable<T>(string title, string? caption, HashSet<string> OriginalNames, SubHeader.Page page) where T : UseVariableName
    {
        using (var table = page.CreateTable(title, caption))
        {
            using (var headerRow = table.CreateHeaderRow())
                headerRow.CreateHeader("Name(s)").CreateEditionHeaders();

            foreach (var original in OriginalNames)
            {
                var rowval = new List<string>() { Get.TotalNamesOf<T>(original) };
                rowval.AddRange(Get.EditionsOf<T>(original));
                table.AddRows(rowval.ToArray());
            }
        }
    }

    #endregion

    #region ACTUAL PAGES
    public static void CreateHomepage()
    {
        CreateOfficialHeader("Ravenloft");

        sb.AppendLine("<br/>");
        sb.AppendLine("Hi, this is a GM's reference website for the Ravenloft Campaign Setting.<br/><br/>");
        sb.AppendLine("I wanted a list of everything and I figured others would like having this too.<br/>");
        sb.AppendLine("Most things will have a listed source so you can read it further on your own.<br/>");
        sb.AppendLine("(I won't be listing sources outside of Ravenloft material, e.g. I won't link to the Bestiary entry for zombies)<br/>");
        sb.AppendLine("This is not meant to replace <a href='https://www.fraternityofshadows.com/wiki/'>Mistipedia</a> or anyone else's efforts,");
        sb.AppendLine("it is definitely inspired by the <a href='https://www.fraternityofshadows.com/rldb/'>Ravenloft Catalogue</a>.<br/>");

        SaveHTML(string.Empty);
    }

    public static void CreateSourcePage()
    {
        CreateOfficialHeader("Source Materials", 1);

        var MaterialPerEdition = new Dictionary<string, int>(Traits.Edition.Editions.Count);
        var MaterialPerMedia = new Dictionary<string, int>(Traits.Media.Medias.Count);

        const string MainTableID = "List of Media";
        using (var table = new Table(MainTableID))
        {
            using (var headerRow = table.CreateHeaderRow())
                headerRow.CreateHeader("Name").CreateSortHeader("Edition", "Media Type").CreateSortDateHeader("Release Date");

            var Sources = Factory.db.Sources.Include(s => s.Traits);
            foreach (var source in Sources)
            {
                var edition = source.Traits.Single(s => s.Type == nameof(Traits.Edition)).Key;
                MaterialPerEdition[edition] = MaterialPerEdition.ContainsKey(edition) ? MaterialPerEdition[edition] + 1 : 1;

                var media = source.Traits.Single(s => s.Type == nameof(Traits.Media)).Key;
                MaterialPerMedia[media] = MaterialPerMedia.ContainsKey(media) ? MaterialPerMedia[media] + 1 : 1;

                table.AddRows(new[] { CreateLink(nameof(Source), source.Key), edition, source.ReleaseDate, media });
            }
        }
        const string EditionTableID = "Editions Breakdown";
        using (var table = new Table(EditionTableID))
        {
            using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Edition", "Source Materials");
            foreach (var edition in Traits.Edition.Editions)
            {
                if (!MaterialPerEdition.ContainsKey(edition.Key)) MaterialPerEdition[edition.Key] = 0;
                table.AddRows(new[] { edition.Key, MaterialPerEdition[edition.Key].ToString() });
            }
        }
        const string MediaTableID = "Media Breakdown";
        using (var table = new Table(MediaTableID))
        {
            using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Type", "Source Materials");
            foreach (var media in Traits.Media.Medias)
            {
                if (!MaterialPerMedia.ContainsKey(media.Key)) MaterialPerMedia[media.Key] = 0;
                table.AddRows(new[] { media.Key, MaterialPerMedia[media.Key].ToString() });
            }
        }

        sb.AppendLine("<script>");
        sb.AppendLine($"sortDate('{MainTableID}',3);");
        sb.AppendLine($"sortDate('{EditionTableID}',0);");
        sb.AppendLine($"sortDate('{MediaTableID}',0);");
        sb.AppendLine("</script>");

        SaveHTML(nameof(Source));
    }
    public static void CreateLocationPage()
    {
        CreateOfficialHeader("Locations of Ravenloft", 1);

        using (var subheader = new SubHeader())
        {
            //Key is domain, entries are all location names
            var LocationsPerDomain   = new Dictionary<string, HashSet<string>>();
            var SettlementsPerDomain = new Dictionary<string, HashSet<string>>();

            var AllLocations = Factory.db.Locations.Include(s => s.Domains).Include(s => s.Traits);
            foreach (var location in AllLocations)
            {
                foreach (var domain in location.Domains)
                {
                    LocationsPerDomain.TryAdd(domain.OriginalName, new HashSet<string>());
                    SettlementsPerDomain.TryAdd(domain.OriginalName, new HashSet<string>());

                    LocationsPerDomain[domain.OriginalName].Add(location.OriginalName);
                    if (location.Traits.Contains(Traits.Location.Settlement))
                        SettlementsPerDomain[domain.OriginalName].Add(location.OriginalName);
                }
            }

            using (var AllPage = subheader.CreatePage("All Locations"))
            {
                var Inside = LocationsPerDomain.TryGetValue(Factory.InsideRavenloft.Key, out var UnknownDomainLocations);
                if (Inside) LocationsPerDomain.Remove(Factory.InsideRavenloft.Key); //Last table
                var Outside = LocationsPerDomain.TryGetValue(Factory.InsideRavenloft.Key, out var OutsideRavenloftLocations);
                if (Outside) LocationsPerDomain.Remove(Factory.InsideRavenloft.Key); //Last table

                foreach (var DomainName in LocationsPerDomain.Keys)
                    SetTable<Location>($"Locations of {Get.TotalNamesOf<Domain>(DomainName)}", null, LocationsPerDomain[DomainName], AllPage);
                if (Inside) 
                    SetTable<Location>($"Locations within Ravenloft", "The domain of the location is unknown.", UnknownDomainLocations, AllPage);
                if (Outside) 
                    SetTable<Location>($"Locations outside Ravenloft", "This place is related to Ravenloft somehow.", OutsideRavenloftLocations, AllPage);

            }

            using (var SettlementPage = subheader.CreatePage("Settlements"))
            {
                var UnkownExist = SettlementsPerDomain.TryGetValue(Factory.InsideRavenloft.Key, out var UnknownDomainSettlements);
                if (UnkownExist) SettlementsPerDomain.Remove(Factory.InsideRavenloft.Key); //Last table

                foreach (var DomainNames in SettlementsPerDomain.Keys)
                    SetTable<Location>($"Settlements of {DomainNames}", null, SettlementsPerDomain[DomainNames], SettlementPage);
                if (UnkownExist)
                    SetTable<Location>($"Settlements within Ravenloft", "The domain of the settlement is unknown.", UnknownDomainSettlements, SettlementPage);
            }

            using (var LairPage = subheader.CreatePage("Darklord Lairs"))
            {
                using (var table = LairPage.CreateTable($"List of Darklord Lairs"))
                {
                    using (var headerRow = table.CreateHeaderRow())
                        headerRow.CreateHeader("Name(s)", "Domain(s)", "Darklord").CreateEditionHeaders();

                    var DarkLordLairsCopies = Factory.db.Locations.Where(s => s.Traits.Any(s => s == Traits.Status.Darklord)).Include(s => s.Domains).Include(s => s.NPCs).ThenInclude(s => s.Traits).GroupBy(s => s.OriginalName);

                    foreach (var SingleSetOfLairCopies in DarkLordLairsCopies)
                    {
                        var TotalNamesofTotalDomains = new HashSet<string>();
                        var TotalNamesofTotalDarklords = new HashSet<string>();

                        foreach (var CopyOfLair in SingleSetOfLairCopies) //Different sources may have different darklords/domains for same location
                        {
                            foreach (var domain in CopyOfLair.Domains) TotalNamesofTotalDomains.Add(Get.TotalNamesOf(domain));

                            var DomainDarklords = CopyOfLair.NPCs.Where(n => n.Traits.Contains(Traits.Status.Darklord));
                            foreach (var DomainDarklord in DomainDarklords) TotalNamesofTotalDarklords.Add(Get.TotalNamesOf(DomainDarklord));
                        }

                        var rowval = new List<string>() 
                        { 
                            Get.TotalNamesOf<Location>(SingleSetOfLairCopies.Key), 
                            string.Join(",", TotalNamesofTotalDomains),
                            string.Join(",", TotalNamesofTotalDarklords)
                        };
                        rowval.AddRange(Get.EditionsOf<Location>(SingleSetOfLairCopies.Key));

                        table.AddRows(rowval.ToArray());
                    }
                }
            }
            using (var MistwayPage = subheader.CreatePage("Mistways"))
            {
                using (var table = MistwayPage.CreateTable($"List of Mistways"))
                {
                    using (var headerRow = table.CreateHeaderRow())
                    {
                        headerRow.CreateHeader("Name(s)", "Domain", "Domain");
                        headerRow.CreateEditionHeaders();
                    }
                    var Mistways = Factory.db.Locations.Where(s => s.Traits.Any(s => s == Traits.Location.Mistway)).Include(s => s.Domains).GroupBy(s => s.OriginalName).Select(s => s.First()); //There is no deviation/variation of mistways. Revise this if that ever happens.
                    foreach (var Mistway in Mistways)
                    {
                        var TotalNamesofTotalDomains = new List<string>(2);
                        foreach (var domain in Mistway.Domains) TotalNamesofTotalDomains.Add(Get.TotalNamesOf(domain));

                        var rowval = new List<string>() { Get.TotalNamesOf(Mistway) };
                        rowval.AddRange(TotalNamesofTotalDomains); //If this goes beyond 2 then the HTML goes fucky-wucky.
                        rowval.AddRange(Get.EditionsOf(Mistway));

                        table.AddRows(rowval.ToArray());
                    }
                }
            } 
        }

        SaveHTML(nameof(Location));
    }
    public static void CreateDomainPage()
    {
        CreateOfficialHeader("Domains of Ravenloft", 1);
        sb.AppendLine($"Quick-link for {CreateLink(nameof(Domain), Factory.InsideRavenloft.Key)}");
        sb.AppendLine($"Quick-link for {CreateLink(nameof(Domain), Factory.OutsideRavenloft.Key)}");

        var AllDomains = Factory.db.Domains.Include(s => s.Traits).Include(s => s.NPCs).ThenInclude(n => n.Traits);
        var Domains = new Dictionary<string, HashSet<string>>(); //Domain : Darklords
        var Clusters = new Dictionary<string, HashSet<string>>(); //Cluster : Domains
        foreach (var Domain in AllDomains)
        {
            if (Domain == Factory.InsideRavenloft || Domain == Factory.OutsideRavenloft) continue;
            Domains.TryAdd(Domain.OriginalName, new HashSet<string>());

            var AllDarklords = Domain.NPCs.Where(n => n.Traits.Contains(Traits.Status.Darklord));
            foreach (var Darklord in AllDarklords) Domains[Domain.OriginalName].Add(Get.TotalNamesOf(Darklord));

            var ClustersInDomain = Domain.Traits.Where(t => t.Type == nameof(Traits.Cluster));

            if (ClustersInDomain.Count() == 0)             AddToCluster(Traits.Cluster.IslandOfTerror.Key);
            else foreach (var Cluster in ClustersInDomain) AddToCluster(CreateLink(nameof(Cluster), Cluster.Key));

            void AddToCluster(string key)
            {
                Clusters.TryAdd(key, new HashSet<string>());
                Clusters[key].Add(Domain.OriginalName);
            }
        }

        using (var subheader = new SubHeader()) 
        {
            using (var Domain = subheader.CreatePage("All Domain"))
            {
                using (var table = Domain.CreateTable("List of Domains"))
                {
                    using (var headerRow = table.CreateHeaderRow())
                        headerRow.CreateHeader("Name(s)", "Darklord(s)").CreateEditionHeaders();

                    foreach (var domain in Domains)
                    {
                        var rowval = new List<string>() { Get.TotalNamesOf<Domain>(domain.Key), string.Join(",",domain.Value) };
                        rowval.AddRange(Get.EditionsOf<Domain>(domain.Key));
                        table.AddRows(rowval.ToArray());
                    }
                }
            }
            using (var Group = subheader.CreatePage("By Cluster/Type"))
            {
                using (var table = Group.CreateTable("Domains per Cluster"))
                {
                    using (var headerRow = table.CreateHeaderRow())
                        headerRow.CreateHeader("Name", "Domains");

                    foreach (var cluster in Clusters)
                        table.AddRows(new[] { cluster.Key, cluster.Value.Count().ToString() });
                }
                foreach (var cluster in Clusters)
                {
                    using (var table = Group.CreateTable(cluster.Key))
                    {
                        using (var headerRow = table.CreateHeaderRow())
                            headerRow.CreateHeader(cluster.Key).CreateEditionHeaders();

                        foreach (var domain in cluster.Value)
                        {
                            var rowval = new List<string>() { Get.TotalNamesOf<Domain>(domain) };
                            rowval.AddRange(Get.EditionsOf<Domain>(domain));
                            table.AddRows(rowval.ToArray());
                        }
                    }
                }
            }
        }
        SaveHTML(nameof(Domain));
    }
    public static void CreateCharacterPage()
    {
        CreateOfficialHeader("Characters of Ravenloft", 1);

        sb.AppendLine("<label for='showdead'>Show dead characters</label>");
        sb.AppendLine("<input type='checkbox' id='showdead' checked>");

        using (var subheader = new SubHeader())
        {
            const int ALIVE = 0, DEAD = 1;
            const int PERDOMAIN = 0, PERGROUP = 1, PERCREATURE = 2;

            var Characters = new Dictionary<string, HashSet<string>[]>[3]; //Alive, Dead
            for (int i = 0; i < Characters.Length; i++) Characters[i] = new Dictionary<string, HashSet<string>[]>();

            var AllCharacters = Factory.db.NPCs.Include(s => s.Domains).Include(s => s.Traits);
            foreach (var character in AllCharacters)
            {
                var StatusTraits = character.Traits.Where(c => c.Type.Contains(nameof(Traits.Status))).ToList();

                var offset = StatusTraits.Remove(Traits.Status.Deceased) ? ALIVE : DEAD;

                foreach (var domain in character.Domains)
                {
                    Characters[PERDOMAIN].TryAdd(domain.OriginalName, Init());
                    Characters[PERDOMAIN][domain.OriginalName][offset].Add(character.OriginalName);
                }

                foreach (var statusTrait in StatusTraits)
                {
                    Characters[PERGROUP].TryAdd(statusTrait.Key, Init());
                    Characters[PERGROUP][statusTrait.Key][offset].Add(character.OriginalName);
                }

                var CreatureTraits = character.Traits.Where(c => c.Type.Contains(nameof(Traits.Creature)));
                foreach (var creatureTrait in CreatureTraits)
                {
                    Characters[PERCREATURE].TryAdd(creatureTrait.Key, Init());
                    Characters[PERCREATURE][creatureTrait.Key][offset].Add(character.OriginalName);
                }
                static HashSet<string>[] Init() => new HashSet<string>[2] { new HashSet<string>(), new HashSet<string>() };
            }

            using (var Domain = subheader.CreatePage("By Domain"))
            {
                var CharactersPerDomain = Characters[PERDOMAIN];
                var Inside = CharactersPerDomain.TryGetValue(Factory.InsideRavenloft.Key, out var InsideCharacters);
                if (Inside) CharactersPerDomain.Remove(Factory.InsideRavenloft.Key); //Last table
                var Outside = CharactersPerDomain.TryGetValue(Factory.InsideRavenloft.Key, out var OutsideCharacters);
                if (Outside) CharactersPerDomain.Remove(Factory.InsideRavenloft.Key); //Last table

                ForEachLoop(Domain, Characters[PERDOMAIN]);
                if (Inside)
                    SetTable("Characters within Ravenloft", "The domain of the item is unknown.", InsideCharacters, Domain);
                if (Outside)
                    SetTable("Characters outside Ravenloft", "They're related to Raveloft somehow", OutsideCharacters, Domain);
            }
            using (var Group = subheader.CreatePage("By Group"))
                ForEachLoop(Group, Characters[PERGROUP]);

            using (var Creature = subheader.CreatePage("By Creature Type"))
                ForEachLoop(Creature, Characters[PERCREATURE]);

            static void ForEachLoop(SubHeader.Page page, Dictionary<string, HashSet<string>[]> NPCList)
            {
                foreach (var Key in NPCList.Keys)
                    SetTable($"Items of {Get.TotalNamesOf<NPC>(Key)}", null, NPCList[Key], page);
            }

            static void SetTable(string title, string? caption, HashSet<string>[] OriginalNames, SubHeader.Page page)
            {
                using (var table = page.CreateTable(title, caption))
                {
                    using (var headerRow = table.CreateHeaderRow())
                        headerRow.CreateHeader("Name(s)").CreateEditionHeaders();

                    foreach (var character in OriginalNames[ALIVE])
                    {
                        var rowval = new List<string>() { Get.TotalNamesOf<NPC>(character) };
                        rowval.AddRange(Get.EditionsOf<NPC>(character));
                        table.AddRows(rowval.ToArray());
                    }
                    foreach (var character in OriginalNames[DEAD])
                    {
                        var rowval = new List<string>() { Get.TotalNamesOf<NPC>(character) };
                        rowval.AddRange(Get.EditionsOf<NPC>(character));
                        table.AddRows("dead", rowval.ToArray());
                    }
                }
            }
        }
        sb.AppendLine("<script>");
        sb.AppendLine($"document.getElementById('showdead').addEventListener('change', () => document.querySelectorAll('.dead').forEach(x => x.style.visibility = document.getElementById('darkmode').checked?'visible':'collapse');");
        sb.AppendLine("</script>");

        SaveHTML("Character");
    }
    public static void CreateItemPage()
    {
        CreateOfficialHeader("Items of Ravenloft", 1);

        using (var subheader = new SubHeader())
        {
            //Key is domain, entries are all location names
            var ItemsPerDomain = new Dictionary<string, HashSet<string>>();
            var ItemsPerGroup = new Dictionary<string, HashSet<string>>();
            var ItemsPerCreature = new Dictionary<string, HashSet<string>>();

            var AllItems = Factory.db.Items.Include(s => s.Domains).Include(s => s.Traits);
            foreach (var item in AllItems)
            {
                foreach (var domain in item.Domains)
                {
                    ItemsPerDomain.TryAdd(domain.OriginalName, new HashSet<string>());
                    ItemsPerGroup[domain.OriginalName].Add(item.OriginalName);
                }

                var StatusTraits = item.Traits.Where(c => c.Type.Contains(nameof(Traits.Status))).ToList();
                foreach (var statusTrait in StatusTraits)
                {
                    ItemsPerGroup.TryAdd(statusTrait.Key, new HashSet<string>());
                    ItemsPerGroup[statusTrait.Key].Add(item.OriginalName);
                }

                var CreatureTraits = item.Traits.Where(c => c.Type.Contains(nameof(Traits.Creature)));
                foreach (var creatureTrait in CreatureTraits)
                {
                    ItemsPerCreature.TryAdd(creatureTrait.Key, new HashSet<string>());
                    ItemsPerCreature[creatureTrait.Key].Add(item.OriginalName);
                }
            }
            using (var Domain = subheader.CreatePage("By Domain"))
            {
                var UnkownExist = ItemsPerDomain.TryGetValue(Factory.InsideRavenloft.Key, out var UnknownItemLocations);
                if (UnkownExist) ItemsPerDomain.Remove(Factory.InsideRavenloft.Key); //Last table

                ForEachLoop(Domain, ItemsPerDomain);
                if (UnkownExist)
                    SetTable<Item>($"Items within Ravenloft", "The domain of the item is unknown.", UnknownItemLocations, Domain);
            }
            using (var Group = subheader.CreatePage("By Group")) //Status Traits
                ForEachLoop(Group, ItemsPerGroup);

            using (var Creature = subheader.CreatePage("By Creature")) //Creature Traits
                ForEachLoop(Creature, ItemsPerCreature);

            static void ForEachLoop(SubHeader.Page page, Dictionary< string, HashSet<string>> ItemList)
            {
                foreach (var Key in ItemList.Keys)
                    SetTable<Item>($"Items of {Get.TotalNamesOf<Item>(Key)}", null, ItemList[Key], page);
            }
        }
        SaveHTML(nameof(Item));
    }
    #endregion
}