using Ravenloft;

using var db = new RavenloftContext();

Edition e1 = new Edition() { Name="1e"};
Edition e2 = new Edition() { Name="2e"};
Edition e3 = new Edition() { Name="3e"};
Edition e4 = new Edition() { Name="4e"};
Edition e5 = new Edition() { Name="5e"};

CreatureTrait Darklord = new CreatureTrait() { Name = "Darklord" };

Domain Odiare = new Domain 
{ 
    Name = "Odiare", 
    Canon = Canon.Canon, 
    Darklord = new List<NPC>()
};
NPC Maligno = new NPC()
{
    Name = "Maligno",
    Domains = new List<Domain>() { Odiare },
    Aliases = "Figlio",
    Traits = ""
};
Odiare.Darklord.Add(Maligno);

Console.WriteLine($"Hello World!");