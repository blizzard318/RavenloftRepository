using Ravenloft;

using var db = new RavenloftContext();
AddToDatabase.Add(db);

var dom = db.Domains.Find("Barovia");

Console.WriteLine(dom != null);