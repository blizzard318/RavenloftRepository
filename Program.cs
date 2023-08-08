using Ravenloft;

using var db = new RavenloftContext();

var Canon = new Canon() { Name = "Canon" };
var Soft = new Canon() { Name = "Soft" };
var NonCanon = new Canon() { Name = "NonCanon" };
var Homebrew = new Canon() { Name = "Homebrew" };

var e1 = new Edition() { Name = "1e" };
var e2 = new Edition() { Name = "2e" };
var e3 = new Edition() { Name = "3e" };
var e4 = new Edition() { Name = "4e" };
var e5 = new Edition() { Name = "5e" };

var Darklord = new CreatureTrait() { Name = "Darklord" };

var Odiare = new Domain { Name = "Odiare" };
var Maligno = new NPC() {  Name = "Maligno" };

Maligno.Domains.Add(Odiare);

Maligno.Aliases = "Figlio";

Console.WriteLine($"Hello World!");