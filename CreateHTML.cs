using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;

internal static class CreateHTML
{
    #region PAGE CREATOR
    private static string CreateLink(string subdomain, string name) => $"<a href=\"/{subdomain}/{name}\">{name}</a>";
    private static StringBuilder sb = new StringBuilder();
    private class Table : IDisposable
    {
        private readonly string TableID;
        private readonly StringBuilder sb;
        public Table(string title) : this(title, string.Empty, CreateHTML.sb) { }
        public Table(string title, string caption) : this(title, caption, CreateHTML.sb) { }
        public Table(string title, StringBuilder stringBuilder) : this(title, string.Empty, stringBuilder) { }
        public Table(string title, string caption, StringBuilder stringBuilder)
        {
            TableID = title;
            sb = stringBuilder;
            sb.AppendLine($"<b style='font-size:25px'>{title}</b>");
            sb.AppendLine($"<table cellspacing='0' cellpadding='3' rules='cols' border='1' id='{title}'>");
            if (!string.IsNullOrWhiteSpace(caption)) sb.AppendLine($"<caption>{caption}</caption>");
        }
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
            public void CreateHeader (string title)
            {
                sb.AppendLine("<th scope='col'>");
                EndHeader(title);
            }
            public void CreateSortHeader (string title)
            {
                sb.AppendLine($"<th scope='col' onclick=\"sortTable('{TableID}',{col})\" style='cursor:pointer'>");
                EndHeader(title);
            }
            public void CreateSortDateHeader (string title)
            {
                sb.AppendLine($"<th scope='col' onclick=\"sortDate('{TableID}',{col})\" style='cursor:pointer'>");
                EndHeader(title);
            }
            public void CreateEditionHeaders ()
            {
                foreach (var edition in Traits.Edition.Editions)
                    sb.AppendLine($"<th scope='col'>").AppendLine($"<b>{edition.Key}</b>").AppendLine("</th>");
                col += Traits.Edition.Editions.Count;
            }
            private void EndHeader (string title)
            {
                sb.AppendLine($"<b>{title}</b>").AppendLine("</th>");
                col++;
            }
            public void Dispose() => sb.AppendLine("</tr>");
        }
        public void AddRow(params string[] columns)
        {
            sb.AppendLine("<tr>");
            foreach (var column in columns)
            {
                sb.AppendLine($"<td>{column}</td>");
            }
            sb.AppendLine("</tr>");
        }
        public void Dispose() => sb.AppendLine("</table><br/>");
    }
    private static void SaveHTML(string DirectoryName)
    {
        sb.AppendLine("</body>").AppendLine("<script>init();</script>").AppendLine("</html>");
        string filepath = "index.html";
        if (!string.IsNullOrEmpty(DirectoryName))
        {
            var dir = Directory.CreateDirectory(DirectoryName).ToString();
            filepath = Path.Join(dir, filepath);
        }
        File.WriteAllText(filepath, sb.ToString());
    }
    private static void CreateOfficialHeader(string title, int depth = 0)
    {
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

            sb.AppendLine($"<div class='page' id='{pages[0].ID}' style='block'>");
            sb.Append(pages[0].contents);
            for (int i = 1; i < pages.Count; i++)
            {
                sb.AppendLine($"<div class='page' id='{pages[i].ID}' style='none'>");
                sb.Append(pages[i].contents);
            }
        }
        public class Page : IDisposable
        {
            public readonly string ID;
            public readonly StringBuilder contents = new StringBuilder();
            public Page(string ID) => this.ID = ID;
            public void Dispose() => contents.AppendLine("</div>");
        }
    }
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
#endregion

    #region ACTUAL PAGES
    public static void CreateLocationPage()
    {
        CreateOfficialHeader("Locations of Ravenloft", 1);

        using (var subheader = new SubHeader())
        {
            var Locations = Factory.db.Locations
                .Include(s => s.Traits).Include(s => s.Domains).Include(s => s.NPCs).ThenInclude(n => n.Traits).ToHashSet();

            var TempLocationsPerDomain = new Dictionary<string, List<Location>>();
            foreach (var location in Locations)
            {
                foreach (var domain in location.Domains)
                {
                    string key = domain.OriginalName;
                    if (!TempLocationsPerDomain.ContainsKey(key))
                        TempLocationsPerDomain[key] = new List<Location> { location };
                    else TempLocationsPerDomain[key].Add(location);
                }
            }

            //Get all the domain names.
            var LocationsPerDomain = new Dictionary<string, List<Location>>();
            foreach (var DomainOriginalName in TempLocationsPerDomain.Keys)
            {
                var DifferentNamesOfSameDomain = Factory.db.Domains.Where(d => d.OriginalName == DomainOriginalName).Select(d => d.Name).ToHashSet();
                string TotalNamesOfSameDomain = string.Join("/", DifferentNamesOfSameDomain);
                LocationsPerDomain[TotalNamesOfSameDomain] = TempLocationsPerDomain[DomainOriginalName];
            }

            using (var AllPage = subheader.CreatePage("All Locations"))
            {
                var UnknownDomainLocations = LocationsPerDomain[Factory.InsideRavenloft.Key];
                LocationsPerDomain.Remove(Factory.InsideRavenloft.Key); //Last table

                foreach (var DomainNames in LocationsPerDomain.Keys)
                {
                    using (var table = new Table($"Locations of {DomainNames}", AllPage.contents))
                    {
                        using (var headerRow = new Table.HeaderRow(table))
                        {
                            headerRow.CreateHeader("Name(s)");
                            headerRow.CreateEditionHeaders();
                        }
                    }
                }
                using (var table = new Table($"Locations within Ravenloft", "The domain of the location is unknown.",AllPage.contents)) //Last table
                {
                    using (var headerRow = new Table.HeaderRow(table))
                    {
                        headerRow.CreateHeader("Name(s)");
                        headerRow.CreateEditionHeaders();
                    }
                }
            }
            using (var LairPage = subheader.CreatePage("Darklord Lairs"))
            {
                using (var table = new Table($"List of Darklord Lairs"))
                {
                    using (var headerRow = new Table.HeaderRow(table))
                    {
                        headerRow.CreateHeader("Name(s)");
                        headerRow.CreateHeader("Domain(s)");
                        headerRow.CreateHeader("Darklord");
                        headerRow.CreateEditionHeaders();
                    }
                }
            }
            using (var SettlementPage = subheader.CreatePage("Settlements"))
            {

            }
            using (var MistwayPage = subheader.CreatePage("Mistways"))
            {
                using (var table = new Table($"List of Darklord Lairs"))
                {
                    using (var headerRow = new Table.HeaderRow(table))
                    {
                        headerRow.CreateHeader("Name(s)");
                        headerRow.CreateHeader("Domain");
                        headerRow.CreateHeader("Domain");
                        headerRow.CreateEditionHeaders();
                    }
                }
            }
        }
    }
    public static void CreateSourcePage()
    {
        CreateOfficialHeader("Source Materials", 1);

        var MaterialPerEdition = new Dictionary<string, int>(Traits.Edition.Editions.Count);
        var MaterialPerMedia = new Dictionary<string, int>(Traits.Media.Medias.Count);

        const string MainTableID = "List of Media";
        using (var table = new Table(MainTableID))
        {
            using (var headerRow = new Table.HeaderRow(table))
            {
                headerRow.CreateHeader("Name");
                headerRow.CreateSortHeader("Edition");
                headerRow.CreateSortHeader("Media Type");
                headerRow.CreateSortDateHeader("Release Date");
            }
            var Sources = Factory.db.Sources.Include(s => s.Traits).ToArray();
            foreach (var source in Sources)
            {
                var edition = source.Traits.Single(s => s.Type == nameof(Traits.Edition)).Key;
                MaterialPerEdition[edition] = MaterialPerEdition.ContainsKey(edition) ? MaterialPerEdition[edition] + 1 : 1;

                var media = source.Traits.Single(s => s.Type == nameof(Traits.Media)).Key;
                MaterialPerMedia[media] = MaterialPerMedia.ContainsKey(media) ? MaterialPerMedia[media] + 1 : 1;

                table.AddRow(new []{ CreateLink(nameof(Source), source.Key), edition, source.ReleaseDate, media });
            }
        }
        const string EditionTableID = "Editions Breakdown";
        using (var table = new Table(EditionTableID))
        {
            using (var headerRow = new Table.HeaderRow(table))
            {
                headerRow.CreateHeader("Edition");
                headerRow.CreateHeader("Source Materials");
            }
            foreach (var edition in Traits.Edition.Editions)
            {
                if (!MaterialPerEdition.ContainsKey(edition.Key)) MaterialPerEdition[edition.Key] = 0;
                table.AddRow(new[] { edition.Key, MaterialPerEdition[edition.Key].ToString() });
            }
        }
        const string MediaTableID = "Media Breakdown";
        using (var table = new Table(MediaTableID))
        {
            using (var headerRow = new Table.HeaderRow(table))
            {
                headerRow.CreateHeader("Type");
                headerRow.CreateHeader("Source Materials");
            }
            foreach (var media in Traits.Media.Medias)
            {
                if (!MaterialPerMedia.ContainsKey(media.Key)) MaterialPerMedia[media.Key] = 0;
                table.AddRow(new[] { media.Key, MaterialPerMedia[media.Key].ToString() });
            }
        }

        sb.AppendLine("<script>");
            sb.AppendLine($"sortDate('{MainTableID}',3);");
            sb.AppendLine($"sortDate('{EditionTableID}',0);");
            sb.AppendLine($"sortDate('{MediaTableID}',0);");
        sb.AppendLine("</script>");

        SaveHTML(nameof(Source));
    }
    #endregion
}