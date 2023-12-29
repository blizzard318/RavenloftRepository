AddToDatabase.Add0();
AddToDatabase.Add1();
AddToDatabase.Add2();

var tasks = new List<Task>
{
    CreateHTML.CreateHomepage(),
    CreateHTML.CreateSourcePage(),
    CreateHTML.CreateDomainPage(),
    CreateHTML.CreateLocationPage(),
    CreateHTML.CreateCharacterPage(),
    CreateHTML.CreateItemPage(),
    CreateHTML.CreateGroupPage(),
};

tasks.AddRange(CreateHTML.CreateSourcePages        ());
tasks.AddRange(CreateHTML.CreateDomainPages        ());
tasks.AddRange(CreateHTML.CreateCreaturePage       ());
tasks.AddRange(CreateHTML.CreateCampaignSettingPage());
tasks.AddRange(CreateHTML.CreateLanguagesPage      ());

Task.WaitAll(tasks.ToArray());