AddToDatabase.Add0();
AddToDatabase.Add1();
AddToDatabase.Add2();

var tasks = new List<Task>
{
    CreateHTML.CreateHomepage(),
    CreateHTML.CreateSourcePage(),
    CreateHTML.CreateDomainPage()
};

/*;
CreateHTML.CreateLocationPage();
CreateHTML.CreateCharacterPage();
CreateHTML.CreateItemPage();
CreateHTML.CreateGroupPage();

CreateHTML.CreateCreaturePage();
CreateHTML.CreateCampaignSettingPage();
CreateHTML.CreateLanguagesPage();*/

tasks.AddRange(CreateHTML.CreateSourcePages());
tasks.AddRange(CreateHTML.CreateDomainPages());

Task.WaitAll(tasks.ToArray());