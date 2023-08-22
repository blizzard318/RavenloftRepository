using Microsoft.EntityFrameworkCore;
using System.Text;
using static Source;

string URL(string input) => string.Concat(input.Where(c => c != ':' && !char.IsWhiteSpace(c)));

//AddToDatabase.Add();
var db = Factory.db;

var DomainAppearances   = db.domainAppearances  .Include(a => a.Entity).ToHashSet();
var NPCAppearances      = db.npcAppearances     .Include(a => a.Entity.Domains).Include(a => a.Entity.Traits).ToHashSet();
NPCAppearances.RemoveWhere(a => a.Entity.Traits.Contains(Traits.NoLink));
var LocationAppearances = db.locationAppearances.Include(a => a.Entity.Domains).Include(a => a.Entity.Traits).ToHashSet();
var ItemAppearances     = db.itemAppearances    .Include(a => a.Entity.Domains).Include(a => a.Entity.Traits).ToHashSet();

foreach (var source in db.Sources)
{
    var sb = new StringBuilder();
    sb.AppendLine("<!DOCTYPE html>");
    sb.AppendLine("<html>");
    sb.AppendLine("<head>");
    sb.AppendLine("<meta charset='utf-8'>");
    sb.AppendLine("<title>Ravenloft Repository</title>");
    sb.AppendLine("<meta name='theme-color' content=''black'>");
    sb.AppendLine("<meta name='viewport' content=''width=1050px, initial-scale=1''>");
    sb.AppendLine("<meta name='description' content=''Ravenloft Repository'>");
    sb.AppendLine("<link rel='shortcut icon'' href='favicon.ico''>");
    sb.AppendLine("</head>");
    sb.AppendLine("<body>");
    sb.Append($"<h1>{source.Key}</h1>");

    sb.Append("<b>Domains</b>: ");

    var domains   = DomainAppearances  .Where(a => a.Source == source).ToArray();
    var locations = LocationAppearances.Where(a => a.Source == source).ToHashSet();
    var npcs      = NPCAppearances     .Where(a => a.Source == source).ToHashSet();

    foreach (var domain in domains)
    {
        DomainAppearances.Remove(domain);

        sb.Append(domain.GetPageNumbers());
        sb.Append("<br/>&emsp;<b>Settlements</b>: ");

        var locations_in_domain = locations.Where(a => a.Entity.Domains.Contains(domain.Entity)).ToHashSet();
        var settlements = locations_in_domain.Where(a => a.Entity.Traits.Contains(Traits.Location.Settlement)).ToArray();
        foreach (var settlement in settlements)
        {
            locations.Remove(settlement);
            locations_in_domain.Remove(settlement);

            var trait = settlement.Entity.Traits.Single(t => t.Type.Contains(Traits.Location.Settlement.Key));
            sb.Append("<br/>&emsp;&emsp;").Append(settlement.GetPageNumbers()).Append(": ");

            var residences = locations_in_domain.Where(a => a.Entity.Traits.Contains(trait)).ToArray();
            foreach (var residence in residences)
            {
                locations.Remove(residence);
                locations_in_domain.Remove(residence);
                sb.Append("<br/>&emsp;&emsp;&emsp;").Append(residence.GetPageNumbers()).Append(", ");
            }
            if (residences.Count() > 0) sb.Remove(sb.Length - 2, 2);
        }
        if (locations_in_domain.Count() > 0)
        {
            sb.Append("<br/>&emsp;<b>Non-settlements</b>: ");
            foreach (var residence in locations_in_domain)
            {
                locations.Remove(residence);
                sb.Append("<br/>&emsp;&emsp;").Append(residence.GetPageNumbers()).Append(", ");
            }
            sb.Remove(sb.Length - 2, 2);
        }

        var npcs_in_domain = npcs.Where(a => a.Entity.Domains.Contains(domain.Entity)).ToHashSet();
    }
    sb.AppendLine("</body>");
    sb.AppendLine("</html>");

    string filepath = Path.Join(Directory.GetCurrentDirectory(), $"{URL(source.Key)}.html");
    File.WriteAllText(filepath, sb.ToString());
}