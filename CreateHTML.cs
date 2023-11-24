using Microsoft.EntityFrameworkCore;
using NUglify;
using System.Numerics;
using System.Text;

internal static class CreateHTML
{
    private static string CreateLink(string subdomain, string name) => $"<a href='/{subdomain}/{name.Replace(":",string.Empty)}'>{name}</a>";
    private static string CreateLink<T>(string entity) where T : UseName
    {
        var type = typeof(T);
        var subdomain = string.Empty;
             if (type == typeof(Domain)) subdomain = nameof(Domain);
        else if (type == typeof(NPC)) subdomain = "Character";
        else if (type == typeof(Location)) subdomain = nameof(Location);
        else if (type == typeof(Item)) subdomain = nameof(Item);
        else if (type == typeof(Source)) subdomain = nameof(Source);
        return CreateLink(subdomain, entity);
    }

    #region PREGENERATED DATA
    private static class Get
    {
        private sealed class Entity
        {
            public readonly string Names;
            public readonly string[] Editions;
            public Entity(string names, string[] editions) { Names = names; Editions = editions; }
        }
        private static bool Pregenerated = false;
        private static readonly Dictionary<string, Entity> Domains    = new Dictionary<string, Entity>();
        private static readonly Dictionary<string, Entity> Characters = new Dictionary<string, Entity>();
        private static readonly Dictionary<string, Entity> Locations  = new Dictionary<string, Entity>();
        private static readonly Dictionary<string, Entity> Items      = new Dictionary<string, Entity>();

        public static void Pregenerate() //I don't trust this to be a static constructor. This has to run after the db is filled.
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
                    var AllVersions = All.Where(d => d.OriginalName == OriginalName);

                    string[] NamesOfSame = AllVersions.Select(s => s.Name).Distinct().ToArray();
                    if (AllVersions.SingleOrDefault(a => a.Traits.Contains(Traits.NoLink)) == null)
                    {
                        for (int i = 0; i < NamesOfSame.Length; i++) NamesOfSame[i] = CreateLink(Subdomain, NamesOfSame[i]);
                    }

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
            return null;
        }
    }
    #endregion

    #region PAGE CREATOR
    private static StringBuilder sb = new StringBuilder();
    private static StringBuilder AddGap(this StringBuilder stringBuilder, int number)
    {
        for (int i = 0; i < number; i++) stringBuilder.Append("&emsp;");
        return stringBuilder;
    }
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
        public Table(string id, string title, string? caption = null, StringBuilder? stringBuilder = null)
        {
            TablesToSort.Add(TableID = id, (SortMethod.alphabet, 0));
            sb = stringBuilder ?? CreateHTML.sb;
            sb.AppendLine($"<b style='font-size:25px'>{title}</b>");
            sb.AppendLine($"<table cellspacing='0' cellpadding='3' rules='cols' border='1' id='{id}'>");
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
            var path = DirectoryName.Replace(":", string.Empty);
            var dir = Directory.CreateDirectory(path).ToString();
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
            sb.Append("<a href='").Append(db).AppendLine("Setting'>Campaign Settings</a> | ");
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
            public int TableInt = 0;
            public Page(string ID) => this.ID = ID;
            public Table CreateTable(string title, string? caption = null) => new Table(ID + (TableInt++).ToString(), title, caption, contents);
            public void SetTable<T>(string title, string? caption, HashSet<string> OriginalNames) where T : UseVariableName
            {
                if (OriginalNames.Count == 0) return;
                using (var table = CreateTable(title, caption))
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
            public void Dispose() => contents.AppendLine("</div>");
        }
    }
    private class UnorderedList : IDisposable
    {
        private readonly StringBuilder contents;
        public UnorderedList (StringBuilder contents) => (this.contents = contents).Append($"<ul>");
        public void Dispose() => contents.Append("</ul>");
    }
    #endregion

    #region BASE PAGES
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
        using (var table = new Table(MainTableID, MainTableID))
        {
            table.AdjustSort(SortMethod.date, 3);
            using (var headerRow = table.CreateHeaderRow())
                headerRow.CreateHeader("Name").CreateSortHeader("Edition", "Media Type").CreateSortDateHeader("Release Date");

            var Sources = Factory.db.Sources.Include(s => s.Traits);
            foreach (var source in Sources)
            {
                var edition = source.Traits.Single(s => s.Type == nameof(Traits.Edition)).Key;
                MaterialPerEdition[edition] = MaterialPerEdition.ContainsKey(edition) ? MaterialPerEdition[edition] + 1 : 1;

                var media = source.Traits.Single(s => s.Type == nameof(Traits.Media)).Key;
                MaterialPerMedia[media] = MaterialPerMedia.ContainsKey(media) ? MaterialPerMedia[media] + 1 : 1;

                table.AddRows(new[] { CreateLink<Source>(source.Key), edition, media, source.ReleaseDate});
            }
        }
        const string EditionTableID = "Editions Breakdown";
        using (var table = new Table(EditionTableID, EditionTableID))
        {
            using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Edition", "Source Materials");
            foreach (var edition in Traits.Edition.Editions)
            {
                if (!MaterialPerEdition.ContainsKey(edition.Key)) MaterialPerEdition[edition.Key] = 0;
                table.AddRows(new[] { edition.Key, MaterialPerEdition[edition.Key].ToString() });
            }
        }
        const string MediaTableID = "Media Breakdown";
        using (var table = new Table(MediaTableID, MediaTableID))
        {
            using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Type", "Source Materials");
            foreach (var media in Traits.Media.Medias)
            {
                if (!MaterialPerMedia.ContainsKey(media.Key)) MaterialPerMedia[media.Key] = 0;
                table.AddRows(new[] { media.Key, MaterialPerMedia[media.Key].ToString() });
            }
        }

        SaveHTML(nameof(Source));
    }
    public static void CreateDomainPage()
    {
        CreateOfficialHeader("Domains of Ravenloft", 1);
        sb.AppendLine($"Quick-link for {CreateLink<Domain>(Factory.InsideRavenloftKey)} | {CreateLink<Domain>(Factory.OutsideRavenloftKey)}");

        var AllDomains = Factory.db.Domains.Include(s => s.Traits).Include(s => s.NPCs).ThenInclude(n => n.Traits);
        var Domains = new Dictionary<string, HashSet<string>>(); //Domain : Darklords
        var Clusters = new Dictionary<string, HashSet<string>>(); //Cluster : Domains
        foreach (var Domain in AllDomains)
        {
            if (Domain.OriginalName == Factory.InsideRavenloftKey || Domain.OriginalName == Factory.OutsideRavenloftKey) continue;
            Domains.TryAdd(Domain.OriginalName, new HashSet<string>());

            var AllDarklords = Domain.NPCs.Where(n => n.Traits.Contains(Traits.Status.Darklord));
            foreach (var Darklord in AllDarklords) Domains[Domain.OriginalName].Add(Get.TotalNamesOf(Darklord));

            var ClustersInDomain = Domain.Traits.Where(t => t.Type == nameof(Traits.Cluster));

            if (ClustersInDomain.Count() == 0) AddToCluster(Traits.Cluster.IslandOfTerror.Key);
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
                        var rowval = new List<string>() { Get.TotalNamesOf<Domain>(domain.Key), string.Join(",", domain.Value) };
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
        CreateSourcePages();
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
            var DomainlessLocations = new HashSet<string>(); //Catch stragglers
            var DomainedLocations = new HashSet<string>(); //Catch stragglers
            foreach (var location in AllLocations)
            {
                if (location.Domains.Count == 0) DomainlessLocations.Add(location.OriginalName);
                else DomainedLocations.Add(location.OriginalName);
                foreach (var domain in location.Domains)
                {
                    LocationsPerDomain.TryAdd(domain.OriginalName, new HashSet<string>());
                    SettlementsPerDomain.TryAdd(domain.OriginalName, new HashSet<string>());

                    LocationsPerDomain[domain.OriginalName].Add(location.OriginalName);
                    if (location.Traits.Contains(Traits.Location.Settlement))
                        SettlementsPerDomain[domain.OriginalName].Add(location.OriginalName);
                }
            }
            //Filter out all locations that eventually have domains.
            DomainlessLocations = DomainlessLocations.Except(DomainedLocations).ToHashSet();

            using (var AllPage = subheader.CreatePage("Domains"))
            {
                var Inside = LocationsPerDomain.TryGetValue(Factory.InsideRavenloftKey, out var UnknownDomainLocations);
                if (Inside) LocationsPerDomain.Remove(Factory.InsideRavenloftKey); //Last table
                var Outside = LocationsPerDomain.TryGetValue(Factory.OutsideRavenloftKey, out var OutsideRavenloftLocations);
                if (Outside) LocationsPerDomain.Remove(Factory.OutsideRavenloftKey); //Last table

                foreach (var DomainName in LocationsPerDomain.Keys)
                {
                    var link = Get.TotalNamesOf<Domain>(DomainName);
                    AllPage.SetTable<Location>($"Locations of {link}", null, LocationsPerDomain[DomainName]);
                }
                if (Inside)
                {
                    var link = CreateLink<Domain>(Factory.InsideRavenloftKey);
                    AllPage.SetTable<Location>($"Locations {link}", "The domain of the location is unknown.", UnknownDomainLocations);
                }
                if (Outside)
                {
                    var link = CreateLink<Domain>(Factory.InsideRavenloftKey);
                    AllPage.SetTable<Location>($"Locations {link}", "This place is related to Ravenloft somehow.", OutsideRavenloftLocations);
                }
                if (DomainlessLocations.Count > 0) //u dun fukd up
                    AllPage.SetTable<Location>("Unsorted Locations", "Please contact site owner to rectify", DomainlessLocations);
            }

            using (var SettlementPage = subheader.CreatePage("Settlements"))
            {
                var Inside = SettlementsPerDomain.TryGetValue(Factory.InsideRavenloftKey, out var UnknownDomainSettlements);
                if (Inside) SettlementsPerDomain.Remove(Factory.InsideRavenloftKey); //Last table
                var Outside = SettlementsPerDomain.TryGetValue(Factory.OutsideRavenloftKey, out var OutsideRavenloftSettlements);
                if (Outside) SettlementsPerDomain.Remove(Factory.OutsideRavenloftKey); //Last table

                foreach (var DomainNames in SettlementsPerDomain.Keys)
                    SettlementPage.SetTable<Location>($"Settlements of {DomainNames}", null, SettlementsPerDomain[DomainNames]);
                if (Inside)
                {
                    var link = CreateLink<Domain>(Factory.InsideRavenloftKey);
                    SettlementPage.SetTable<Location>($"Settlements {link}", "The domain of the settlement is unknown.", UnknownDomainSettlements);
                }
                if (Outside)
                {
                    var link = CreateLink<Domain>(Factory.OutsideRavenloftKey);
                    SettlementPage.SetTable<Location>($"Settlements {link}", "This place is related to Ravenloft somehow.", OutsideRavenloftSettlements);
                }
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
    public static void CreateCharacterPage()
    {
        CreateOfficialHeader("Characters of Ravenloft", 1);

        sb.AppendLine("<label for='showdead'>Show dead characters</label>");
        sb.AppendLine("<input type='checkbox' id='showdead' checked>");

        using (var subheader = new SubHeader())
        {
            const int ALIVE = 0, DEAD = 1;

            var CharactersPerDomain = new Dictionary<string, HashSet<string>[]>();
            var CharactersPergroup = new Dictionary<string, HashSet<string>[]>();
            var CharactersPerCreature = new Dictionary<string, HashSet<string>[]>();

            var AllCharacters = Factory.db.NPCs.Include(s => s.Domains).Include(s => s.Traits);
            var DomainlessCharacters = new HashSet<string>(); //Catch stragglers
            var DomainedCharacter = new HashSet<string>();
            foreach (var character in AllCharacters)
            {
                var StatusTraits = character.Traits.Where(c => c.Type.Contains(nameof(Traits.Status))).ToList();
                var offset = StatusTraits.Remove(Traits.Status.Deceased) ? ALIVE : DEAD;

                foreach (var statusTrait in StatusTraits)
                {
                    CharactersPergroup.TryAdd(statusTrait.Key, Init());
                    CharactersPergroup[statusTrait.Key][offset].Add(character.OriginalName);
                }

                if (character.Domains.Count == 0) DomainlessCharacters.Add(character.OriginalName);
                else DomainedCharacter.Add(character.OriginalName);

                foreach (var domain in character.Domains)
                {
                    CharactersPerDomain.TryAdd(domain.OriginalName, Init());
                    CharactersPerDomain[domain.OriginalName][offset].Add(character.OriginalName);
                }

                var CreatureTraits = character.Traits.Where(c => c.Type.Contains(nameof(Traits.Creature)));
                foreach (var creatureTrait in CreatureTraits)
                {
                    CharactersPerCreature.TryAdd(creatureTrait.Key, Init());
                    CharactersPerCreature[creatureTrait.Key][offset].Add(character.OriginalName);
                }
                static HashSet<string>[] Init() => new HashSet<string>[2] { new HashSet<string>(), new HashSet<string>() };
            }
            //Filter out all characters that eventually have domains.
            DomainlessCharacters = DomainlessCharacters.Except(DomainedCharacter).ToHashSet();

            using (var Domain = subheader.CreatePage("By Domain"))
            {
                var Inside = CharactersPerDomain.TryGetValue(Factory.InsideRavenloftKey, out var InsideCharacters);
                if (Inside) CharactersPerDomain.Remove(Factory.InsideRavenloftKey); //Last table
                var Outside = CharactersPerDomain.TryGetValue(Factory.OutsideRavenloftKey, out var OutsideCharacters);
                if (Outside) CharactersPerDomain.Remove(Factory.OutsideRavenloftKey); //Last table

                foreach (var Key in CharactersPerDomain.Keys)
                    SetTable($"Characters of {Get.TotalNamesOf<Domain>(Key)}", null, CharactersPerDomain[Key], Domain);
                if (Inside)
                {
                    var link = CreateLink<Domain>(Factory.InsideRavenloftKey);
                    SetTable($"Characters {link}", "The domain of the item is unknown.", InsideCharacters, Domain);
                }
                if (Outside)
                {
                    var link = CreateLink<Domain>(Factory.OutsideRavenloftKey);
                    SetTable($"Characters {link}", "They're related to Ravenloft somehow", OutsideCharacters, Domain);
                }
                if (DomainlessCharacters.Count > 0) //u dun fukd up
                    Domain.SetTable<NPC>("Unsorted Characters", "Please contact site owner to rectify", DomainlessCharacters);
            }
            using (var Group = subheader.CreatePage("By Group"))
            {
                foreach (var Key in CharactersPergroup.Keys)
                    SetTable($"Characters of {CreateLink(nameof(Group), Key)}", null, CharactersPergroup[Key], Group);
            }
            using (var Creature = subheader.CreatePage("By Creature Type"))
            {
                foreach (var Key in CharactersPerCreature.Keys)
                    SetTable($"Characters of {CreateLink(nameof(Creature), Key)}", null, CharactersPerCreature[Key], Creature);
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
            var DomainlessItems = new HashSet<string>(); //Catch stragglers
            var DomainedItems = new HashSet<string>(); //Catch stragglers
            foreach (var item in AllItems)
            {
                if (item.Domains.Count == 0) DomainlessItems.Add(item.OriginalName);
                else DomainedItems.Add(item.OriginalName);
                foreach (var domain in item.Domains)
                {
                    ItemsPerDomain.TryAdd(domain.OriginalName, new HashSet<string>());
                    ItemsPerDomain[domain.OriginalName].Add(item.OriginalName);
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
            //Filter out all items that eventually have domains.
            DomainlessItems = DomainlessItems.Except(DomainedItems).ToHashSet();

            using (var Domain = subheader.CreatePage("By Domain"))
            {
                var Inside = ItemsPerDomain.TryGetValue(Factory.InsideRavenloftKey, out var InsideItems);
                if (Inside) ItemsPerDomain.Remove(Factory.InsideRavenloftKey); //Last table
                var Outside = ItemsPerDomain.TryGetValue(Factory.InsideRavenloftKey, out var OutsideItems);
                if (Outside) ItemsPerDomain.Remove(Factory.InsideRavenloftKey); //Last table

                foreach (var Key in ItemsPerDomain.Keys)
                    Domain.SetTable<Item>($"Items of {Get.TotalNamesOf<Domain>(Key)}", null, ItemsPerDomain[Key]);
                if (Inside)
                {
                    var link = CreateLink<Domain>(Factory.InsideRavenloftKey);
                    Domain.SetTable<Item>($"Items {link}", "The domain of the item is unknown.", InsideItems);
                }
                if (Outside)
                {
                    var link = CreateLink<Domain>(Factory.OutsideRavenloftKey);
                    Domain.SetTable<Item>($"Items {link}", "Somehow related.", OutsideItems);
                }
                if (DomainlessItems.Count > 0) //u dun fukd up
                    Domain.SetTable<Item>("Unsorted Items", "Please contact site owner to rectify", DomainlessItems);
            }
            using (var Group = subheader.CreatePage("By Group")) //Status Traits
            {
                foreach (var Key in ItemsPerGroup.Keys)
                    Group.SetTable<Item>($"Items of {CreateLink(nameof(Group), Key)}", null, ItemsPerGroup[Key]);
            }
            using (var Creature = subheader.CreatePage("By Creature")) //Creature Traits
            {
                foreach (var Key in ItemsPerCreature.Keys)
                    Creature.SetTable<Item>($"Items of {CreateLink(nameof(Creature), Key)}", null, ItemsPerCreature[Key]);
            }
        }
        SaveHTML(nameof(Item));
    }

    public static void CreateCreaturePage()
    {

    }
    public static void CreateGroupPage()
    {
        
    }
    public static void CreateCampaignSettingPage()
    {

    }
    public static void CreateLanguagesPage()
    {

    }
    #endregion

    #region CHILD PAGES
    private static void CreateSourcePages()
    {
        var Sources = Factory.db.Sources;
        foreach (var source in Sources)
        {
            CreateOfficialHeader(source.Key, 2);
            sb.AppendLine($"<h3>{source.Key}</h3><br/>");

            sb.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");

            using (var subheader = new SubHeader())
            {
                sb.AppendLine($"<b>Name:</b> {source.Key}<br/>");

                var mediatypes = source.Traits.FindAll(t => t.Type == nameof(Traits.Media)).Select(m => m.Key).ToArray();
                for (int i = 0; i < mediatypes.Count(); i++) mediatypes[i] = CreateLink(nameof(Traits.Media), mediatypes[i]);
                sb.AppendLine($"<b>Media Type(s):</b> {string.Join(',', mediatypes)}<br/>");

                var editionstring = CreateLink(nameof(Traits.Edition), source.Traits.Single(t => t.Type == nameof(Traits.Edition)).Key);
                sb.AppendLine($"<b>Edition:</b> {editionstring}<br/>");

                var canontrait = source.Traits.SingleOrDefault(t => t.Type == nameof(Traits.Canon));
                if (canontrait != null) sb.AppendLine($"<b>Canon:</b> {CreateLink(nameof(Traits.Canon), canontrait.Key)}<br/>");

                sb.AppendLine($"<b>Release Date:</b> {source.ReleaseDate}<br/>");
                sb.AppendLine($"<b>Extra Info:</b> {source.ExtraInfo}");

                var Domains    = GetAppearances<DomainAppearance  ,Domain   >(Factory.db.domainAppearances  );
                var Locations  = GetAppearances<LocationAppearance, Location>(Factory.db.locationAppearances);
                var Characters = GetAppearances<NPCAppearance     , NPC     >(Factory.db.npcAppearances     );
                var Items      = GetAppearances<ItemAppearance    , Item    >(Factory.db.itemAppearances    );
                IQueryable<T> GetAppearances<T, U>(IQueryable<T> dbSet) where T : Appearance, IHasEntity<U> where U : UseVariableName
                    => dbSet.Where(s => s.SourceKey == source.Key && !s.Entity.Traits.Any(t => t == Traits.NoLink));

                using (var Compile = subheader.CreatePage("Compile"))
                {
                    GenerateAppearances<DomainAppearance, Domain>(Domains, nameof(Domains));
                    GenerateAppearances<LocationAppearance, Location>(Locations, nameof(Locations));
                    GenerateAppearances<NPCAppearance, NPC>(Characters, nameof(Characters));
                    GenerateAppearances<ItemAppearance, Item>(Items, nameof(Items));
                    void GenerateAppearances<T, U>(IQueryable<T> dbSet, string type) where T : Appearance, IHasEntity<U> where U : UseVariableName
                    {
                        var multiple = dbSet.Where(s => s.SourceKey == source.Key);
                        if (multiple.Count() > 0)
                        {
                            Compile.contents.Append($"<b class='darkred'>{type}</b><hr class='darkred'/>");
                            foreach (var instance in multiple)
                            {
                                if (string.IsNullOrEmpty(instance.PageNumbers)) continue;
                                Compile.contents.Append(Get.TotalNamesOf(instance.Entity)).Append(", ");
                            }
                            Compile.contents.Remove(Compile.contents.Length - 2, 2).AppendLine("<br/><br/>");
                        }
                    }
                }
                using (var Cascade = subheader.CreatePage("Cascade"))
                {
                    //Take out inside/outside ravenloft to put behind the domains stuff.
                    foreach (var domain in Domains)
                    {
                        Cascade.contents.Append($"<b class='darkred'>{Get.TotalNamesOf(domain.Entity)}</b><hr class='darkred'/>");

                        var CharactersInDomain = Characters.Where(s => s.Entity.Domains.Any(c => c == domain.Entity));
                        var CharactersWithoutLocations = CharactersInDomain.Where(c => c.Entity.Locations.Count == 0);
                        var LocationsInDomain = Locations.Where(s => s.Entity.Domains.Any(l => l == domain.Entity));
                        var ItemsInDomain = Items.Where(i => i.Entity.Domains.Any(i => i == domain.Entity));

                        if (LocationsInDomain.Count() + CharactersWithoutLocations.Count() + ItemsInDomain.Count() > 0)
                        {
                            using var innerlist = new UnorderedList(Cascade.contents);

                            foreach (var location in LocationsInDomain)
                            {
                                AddEntry<LocationAppearance, Location>(location);
                                var CharactersInLocation = CharactersInDomain.Where(c => c.Entity.Locations.Any(c => c == location.Entity));
                                if (CharactersInLocation.Count() > 0)
                                {
                                    using var _ = new UnorderedList(Cascade.contents);
                                    foreach (var character in CharactersInLocation) AddEntry<NPCAppearance, NPC>(character);
                                }
                            }

                            if (CharactersWithoutLocations.Count() > 0)
                            {
                                Cascade.contents.Append($"<li><b>{nameof(Characters)} in non-specified location:</b></li>");
                                using var _ = new UnorderedList(Cascade.contents);
                                foreach (var character in CharactersWithoutLocations) AddEntry<NPCAppearance, NPC>(character);
                            }

                            if (ItemsInDomain.Count() > 0)
                            {
                                Cascade.contents.Append($"<li><b>{nameof(Items)}:</b></li>");
                                using var _ = new UnorderedList(Cascade.contents);
                                foreach (var item in ItemsInDomain) AddEntry<ItemAppearance, Item>(item);
                            }
                        }
                        Cascade.contents.AppendLine("<br/>");

                    }

                    //unsorted pile. To sort.
                    ListUnsorted<LocationAppearance, Location>(Locations .Where(x => x.Entity.Domains.Count() == 0), nameof(Locations ));
                    ListUnsorted<NPCAppearance     , NPC     >(Characters.Where(x => x.Entity.Domains.Count() == 0), nameof(Characters));
                    ListUnsorted<ItemAppearance    , Item    >(Items     .Where(x => x.Entity.Domains.Count() == 0), nameof(Items     ));
                    void ListUnsorted<T, U>(IQueryable<T> Unsorted, string title) where T : Appearance, IHasEntity<U> where U : UseVariableName
                    {
                        if (Unsorted.Count() == 0) return;
                        Cascade.contents.Append($"<b class='darkred'>Unsorted {title}, please alert site owner</b><hr class='darkred'/>");
                        foreach (var entity in Unsorted) AddEntry<T, U>(entity);
                    }

                    Cascade.contents.AppendLine("<br/>");

                    void AddEntry<T, U>(T entity) where T : Appearance, IHasEntity<U> where U : UseVariableName
                    {
                        Cascade.contents.Append("<li>").Append(Get.TotalNamesOf(entity.Entity));
                        if (!string.IsNullOrEmpty(entity.PageNumbers)) Cascade.contents.Append($" (<i>{entity.PageNumbers}</i>)</li>");
                        else sb.Append("</li>");
                    }
                }
            }
            sb.AppendLine("</div></div><br/>");
            SaveHTML(nameof(Source) + "/" + source.Key);
        }
    }

    #endregion
}