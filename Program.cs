AddToDatabase.Add0();
AddToDatabase.Add1();
AddToDatabase.Add2();
AddToDatabase.Add3();

var tasks = new List<Task>
{
    CreateHTML.CreateHomepage     (),
    CreateHTML.CreateSourcePage   (),
    CreateHTML.CreateDomainPage   (),
    CreateHTML.CreateLocationPage (),
    CreateHTML.CreateCharacterPage(),
    CreateHTML.CreateItemPage     (),
    CreateHTML.CreateGroupPage    (),
    CreateHTML.CreateCreaturePage (),
    CreateHTML.CreateSettingPage  (),
    CreateHTML.CreateLanguagePage (),
};

tasks.AddRange(CreateHTML.CreateSourcePages   ());
tasks.AddRange(CreateHTML.CreateDomainPages   ());
tasks.AddRange(CreateHTML.CreateLocationPages ());
tasks.AddRange(CreateHTML.CreateCharacterPages());
tasks.AddRange(CreateHTML.CreateItemPages     ());
tasks.AddRange(CreateHTML.CreateGroupPages    ());
tasks.AddRange(CreateHTML.CreateCreaturePages ());
tasks.AddRange(CreateHTML.CreateSettingPages  ());
tasks.AddRange(CreateHTML.CreateLanguagePages ());

Task.WaitAll(tasks.ToArray());