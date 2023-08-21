using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Text;

AddToDatabase.Add();
var db = Factory.db;

IIncludableQueryable<NPCAppearance, NPC> NPCAppearances = db.npcAppearances.Include(a => a.Entity);
IIncludableQueryable<LocationAppearance, Location> LocationAppearances = db.locationAppearances.Include(a => a.Entity);
IIncludableQueryable<DomainAppearance, Domain> DomainAppearances = db.domainAppearances.Include(a => a.Entity);
IIncludableQueryable<ItemAppearance, Item> ItemAppearances = db.itemAppearances.Include(a => a.Entity);

string URL (string input) => string.Concat(input.Where(c => c != ':' && !char.IsWhiteSpace(c)));

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
    //sb.AppendLine("<details>");
        //sb.AppendLine($"<summary><b>{source.Name}</b></summary>");
        sb.AppendLine($"<h1>{source.Key}</h1>");
        sb.Append("Domains: ");

        //var apperances = db.Appearances.Where(a => a.Source == source && a.Entity.Discriminator == "Domain");
        /*foreach (var appearance in apperances)
        {
            sb.Append(appearance.Entity.Name).Append(" (");
            sb.Append(appearance.PageNumbers).Append("),");
        }
        sb.Remove(sb.Length - 1, 1);*/
        //sb.AppendLine("</details>");
        sb.AppendLine("</body>");
    sb.AppendLine("</html>");

    string filepath = Path.Join(Directory.GetCurrentDirectory(), $"{URL(source.Key)}.html");
    File.WriteAllText(filepath, sb.ToString());
    Console.WriteLine(source.Key);
    Console.WriteLine(db.Domains.Count());
    Console.WriteLine(db.NPCs.Count());
}

/*var dom = db.Domains.Find("Barovia");
Console.WriteLine(dom != null);*/