using Phone_book_app.Classes;

var contacts_dict = new Dictionary<Contact, List<Call>>();


while (true)
{

    Console.WriteLine("~ MENU ~\n"
    + "1 - Ispis svih kontakata\n"
    + "2 - Dodavanje novih kontakata u imenik\n"
    + "3 - Brisanje kontakata iz imenika\n"
    + "4 - Editiranje preference kontakta\n"
    + "5 - Upravljanje kontaktom \n"
    + "6 - Ispis svih poziva \n"
    + "7 - Izlaz iz aplikacije \n"
    );
    Console.WriteLine("Vas odabir: ");
    var choice=Console.ReadLine();

    if(!int.TryParse(choice, out int your_choice))
    {
        Console.WriteLine("Ponovi unos");
        return;        
    }
    else
    {
        switch (your_choice)
        {
            case 1:
                PrintAllContact(contacts_dict);
                break;
            case 2:
                AddNewContact(contacts_dict);
                break;
            case 3:
                DeleteContact();
                break;
            case 4:
                EditPreferenceContact();
                break;
            case 5:
                ManageContact(contacts_dict);
                break;
            case 6:
                PrintAllCalls();
                break;
            case 7:
                break;
            default: break;
        }
    }

}


static void PrintAllContact(Dictionary<Contact, List<Call>> contactsDict)
{
    Console.WriteLine("~ SVI KONTAKTI ~");
    foreach (var contact in contactsDict.Keys)
    {
        Console.WriteLine($"{contact.Name} - {contact.PhoneNumber} ({contact.Preference}\n)");
    }
}
static void AddNewContact(Dictionary<Contact, List<Call>> contactsDict)
{
    Console.WriteLine("Unesite ime novog kontakta:");
    var contactName = Console.ReadLine();
    if (string.IsNullOrEmpty(contactName))
    {
        Console.WriteLine("Neispravan unos imena kontakta.");
    }
    else
    {
        Console.WriteLine("Unesite broj:");
        var contactNum=Console.ReadLine();
        if (string.IsNullOrEmpty(contactName))
        {
            Console.WriteLine("Neispravan unos imena kontakta.");
        }
        else
        {
            var newContact = new Contact(contactName, contactNum);
            contactsDict.Add(newContact, new List<Call>());
            Console.WriteLine("Kontakt dodan u imenik.");
        }
    }
    
}
static void DeleteContact()
{

}
static void EditPreferenceContact()
{

}
static void ManageContact(Dictionary<Contact, List<Call>> contactsDict)
{
    Console.WriteLine("Unesite ime kontakta: ");
    var contact_name= Console.ReadLine();

    if(contact_name == null) { Console.WriteLine("Ponovite unos"); }
    else
    {
        
        var contactToManage = contactsDict.Keys.FirstOrDefault(c => c.Name == contact_name);
        if (contactToManage != null)
        {
            while (true)
            {
                Console.WriteLine("~ SUBMENU ~\n"
               + "1 - Ispis svih poziva\n"
               + "2 - Novi poziv\n"
               + "3 - Izlaz iz podmenua\n"
                 );

                Console.WriteLine("Unesite svoj odabri:");
                var choice = Console.ReadLine();

                if (!int.TryParse(choice, out int sub_choice))
                {
                    Console.WriteLine("Ponovite unos");
                    return;
                }
                else
                {
                    switch (sub_choice)
                    {
                        case 1:
                            //PrintAllCalls();
                            break;
                        case 2:

                            break;
                        case 3:
                            break;
                        default: break;
                    }
                }


            }
        }
        else
        {
            Console.WriteLine("Kontakt ne postoji u imeniku");
        }

        
    }
    

}
static void PrintAllCalls()
{

}
