using Ravenloft;

using var db = new RavenloftContext();
AddToDatabase.Add(db);

Console.WriteLine(db.Canons.Count());