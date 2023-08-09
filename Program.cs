using Ravenloft;

using var db = new RavenloftContext();

var Canon = new Canon() { Name = "Canon" };
var SoftCanon = new Canon() { Name = "SoftCanon" };
var NonCanon = new Canon() { Name = "NonCanon" };
var Homebrew = new Canon() { Name = "Homebrew" };

var e1 = new Edition() { Name = "1e" };
var e2 = new Edition() { Name = "2e" };
var e3 = new Edition() { Name = "3e" };
var e4 = new Edition() { Name = "4e" };
var e5 = new Edition() { Name = "5e" };
var novel = new Edition() { Name = "Novel" };

var Darklord = new CreatureTrait() { Name = "Darklord" };

var MistTalisman = new ItemTrait() { Name = "Mist Talisman" };

var Odiare = new Domain { Name = "Odiare" };
var Maligno = new NPC() {  Name = "Maligno" };
Maligno.Aliases = "Figlio";

Cross.Add(Odiare, Maligno);


Console.WriteLine($"Hello World!");