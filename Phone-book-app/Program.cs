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
                DeleteContact(contacts_dict);
                break;
            case 4:
                EditPreferenceContact(contacts_dict);
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
        Console.WriteLine("Neispravan unos imena kontakta");
        return;
    }
    Console.WriteLine("Unesite broj:");
    var contactNum = Console.ReadLine();
    if (string.IsNullOrEmpty(contactName))
    {
        Console.WriteLine("Neispravan unos broja");
        return;
    }
    var newContact = new Contact(contactName, contactNum);
    if(contactsDict.ContainsKey(newContact))
    {
        Console.WriteLine("Broj kontakta vec postoji");
        return;
    }
    contactsDict.Add(newContact, new List<Call>());
    Console.WriteLine("Kontakt dodan u imenik");

}
static void DeleteContact(Dictionary<Contact, List<Call>> contactsDict)
{
    Console.WriteLine("Unesite ime kontakta koji zelite izbrisati: ");
    var contactName = Console.ReadLine();
    if (string.IsNullOrEmpty(contactName))
    {
        Console.WriteLine("Ponovite unos");
        return;
    }
    else
    {
        var deleteContact = contactsDict.Keys.FirstOrDefault(contact => contact.Name == contactName);
        if(deleteContact != null)
        {
            contactsDict.Remove(deleteContact);
            Console.WriteLine("Kontakt izbrisan");
        }
        else
        {
            Console.WriteLine("Kontakt ne postoji u imeniku");
        }
    }
}
static void EditPreferenceContact(Dictionary<Contact, List<Call>> contactsDict)
{
    Console.WriteLine("Unesite ime kontakta:");
    var contactName = Console.ReadLine();
    if (string.IsNullOrEmpty(contactName))
    {
        Console.WriteLine("Ponovite unos");
        return;
    }
    else
    {
        var editContact = contactsDict.Keys.FirstOrDefault(contact => contact.Name == contactName);
        if (editContact != null)
        {
            Console.WriteLine($"Odabrani kontakt: {editContact.Name}: {editContact.Preference}");
            Console.WriteLine("1 - Favorite"
                + "2 - Normal"
                + "3 - Blocked"
                + "0 - Odustani"
                );
            var preference = Console.ReadLine();
            if (int.TryParse(preference,out int your_preference))
            {
                switch(your_preference)
                {
                    case 0:
                        break; 
                    case 1:
                        break; 
                    case 2:
                        break;
                    case 3:
                        
                        break;
                }
            }

        }
    }

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
                            PrintAllCalls();
                            break;
                        case 2:
                            NewCall();
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
static void NewCall()
{

}
