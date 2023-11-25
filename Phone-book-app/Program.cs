using Phone_book_app.Classes;
using System.Collections.Generic;
using System;

var contacts_dict = new Dictionary<Contact, List<Call>>();
Initialize(contacts_dict);

while (true)
{


    Console.WriteLine("\n~ MENU ~\n"
    + "1 - Ispis svih kontakata\n"
    + "2 - Dodavanje novih kontakata u imenik\n"
    + "3 - Brisanje kontakata iz imenika\n"
    + "4 - Editiranje preference kontakta\n"
    + "5 - Upravljanje kontaktom \n"
    + "6 - Ispis svih poziva \n"
    + "7 - Izlaz iz aplikacije \n"
    );

    int choice;

    do
    {
        Console.WriteLine("Vas odabir: ");
        var c = Console.ReadLine();
        if (int.TryParse(c, out choice))
            break;
        Console.WriteLine("Ponovite unos");

    } while (true);

    switch (choice)
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
            PrintAllCalls(contacts_dict);
            break;
        case 7:
            break;
        default:
            break;

    }

}

/////////////////////////////////////////////////////////////////////////////////////
static void PrintAllContact(Dictionary<Contact, List<Call>> contactsDict)
{
    Console.WriteLine("~ SVI KONTAKTI ~");
    foreach (var contact in contactsDict.Keys)
    {
        Console.WriteLine($"{contact.Name} - {contact.PhoneNumber} ({contact.Preference})");
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
        var deleteContact = contactsDict.Keys.FirstOrDefault(contact => contact.Name.ToLower() == contactName.ToLower());
        if(deleteContact != null)
        {
            Console.WriteLine("Jeste li sigurni da zelite izbrisati? - DA/NE");
            var answer=Console.ReadLine().ToLower();
            if (string.IsNullOrEmpty(answer))
            {
                Console.WriteLine("Neispravan unos");
                return;
            }
            if (answer == "ne") { return; }
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
        var editContact = contactsDict.Keys.FirstOrDefault(contact => contact.Name.ToLower() == contactName.ToLower());
        if (editContact != null)
        {
            Console.WriteLine($"Odabrani kontakt: {editContact.Name}: {editContact.Preference}");
            Console.WriteLine("1 - Favorite\n"
                + "2 - Normal\n"
                + "3 - Blocked\n"
                + "0 - Odustani\n"
                );
            var preference = Console.ReadLine();
            if (int.TryParse(preference,out int your_preference))
            {
                switch(your_preference)
                {
                    case 0:
                        break; 
                    case 1:
                        editContact.Preference = ContactPreference.Favorite;
                        break; 
                    case 2:
                        editContact.Preference = ContactPreference.Normal;
                        break;
                    case 3:
                        editContact.Preference = ContactPreference.Blocked;
                        break;
                    default: Console.WriteLine("Pogresan unos");
                        break;
                }
            }
            else { Console.WriteLine("Pogresan unos"); }

        }
    }

}
static void ManageContact(Dictionary<Contact, List<Call>> contactsDict)
{
    Console.WriteLine("Unesite ime kontakta: ");
    var contact_name= Console.ReadLine();

    if(contact_name == null) 
    { 
        Console.WriteLine("Ponovite unos");
        return;
    }
    else
    {
        
        var contactToManage = contactsDict.Keys.FirstOrDefault(c => c.Name.ToLower() == contact_name.ToLower());
        if (contactToManage != null)
        {
            while (true)
            {
                Console.WriteLine("\n~ SUBMENU ~\n"
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
                            PrintAllCallsName(contactsDict,contact_name);
                            break;
                        case 2:
                            NewCall(contactsDict);
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
static void NewCall(Dictionary<Contact, List<Call>> contactsDict)
{
    /***2.Kreiranje novog poziva -odgovor na poziv mora biti random generirana vrijednost čije su moguce vrijednosti 
        definirane statusom poziva (Pri tom pripazite da kada se poziv uspostavi mora trajati random broj sekunda, 
            prilikom cega taj random broj može biti vrijednost od 1 do 20 sekundi.
        Također, istovremeno samo moze biti jedan poziv u tijeku unutar citavog dictionaryja!)***/

    Random r= new Random();

    PrintAllContact(contactsDict);

    Console.WriteLine("Upisite koga zovete:");

    var contactName = Console.ReadLine();
    if (string.IsNullOrEmpty(contactName))
    {
        Console.WriteLine("Ponovite unos");
        return;
    }
    var contactToCall = contactsDict.Keys.FirstOrDefault(contact => contact.Name.ToLower() == contactName.ToLower());

    if (contactToCall == null)
    {
        Console.WriteLine("Kontakt ne postoji.");
        return;
    }
    if (contactsDict.Any(i => i.Value.Any(call => call.CallStatus == StatusCall.Ongoing)))
    {
        Console.WriteLine("Poziv u tijeku!");
        return;
    }
    Console.WriteLine($"Pozivamo {contactName}...");
   
    var end = r.Next(1, 21);
    Console.WriteLine($"Vrijeme trajanja poziva: {end} sekundi");

    SimulateCall(contactToCall, contactsDict, end);


}
static void SimulateCall(Contact contact, Dictionary<Contact, List<Call>> contactsDict, int durationSeconds)
{
    var newCall = new Call(DateTime.Now, StatusCall.Ended);

    if (contactsDict.ContainsKey(contact))
    {
        contactsDict[contact].Add(newCall);
    }
    else
    {
        contactsDict.Add(contact, new List<Call> { newCall });
    }

    Console.WriteLine("Poziv završen");
    Console.WriteLine($"Trajanje poziva: {durationSeconds} sekundi");
}
static void PrintAllCalls(Dictionary<Contact, List<Call> > contactsDict)
{
    Console.WriteLine("Unesite ime kontakta: ");
    var contact_name = Console.ReadLine();

    if (contact_name == null)
    {
        Console.WriteLine("Ponovite unos");
        return;
    }
    var contactPrint = contactsDict.Keys.FirstOrDefault(c => c.Name.ToLower() == contact_name.ToLower());
    if (contactPrint != null)
    {
        Console.WriteLine("~ SVI POZIVI ~");

        if(contactsDict.TryGetValue(contactPrint, out var contact))
        {
            foreach(var call in contact)
            {
                Console.WriteLine($"{contact_name} : {call.CallTime} - {call.CallStatus}");
            }
        }
        else
        {
            Console.WriteLine("Nema poziva");
        }
    }
    else
    {
        Console.WriteLine("Kontakt ne postoji u imeniku");
    }
    
    
}
static void PrintAllCallsName(Dictionary<Contact, List<Call>> contactsDict,string person)
{
    
    var contactPrint = contactsDict.Keys.FirstOrDefault(c => c.Name.ToLower() == person.ToLower());
    if (contactPrint != null)
    {
        Console.WriteLine("~ SVI POZIVI ~");

        if (contactsDict.TryGetValue(contactPrint, out var contact))
        {
            foreach (var call in contact)
            {
                Console.WriteLine($"{person} : {call.CallTime} - {call.CallStatus}");
            }
        }
        else
        {
            Console.WriteLine("Nema poziva");
        }
    }
    else
    {
        Console.WriteLine("Kontakt ne postoji u imeniku");
    }


}
static void Initialize(Dictionary<Contact, List<Call>> contactsDict)
{
    var contact1 = new Contact("Ana Anic", "099/8568956");
    var contact2 = new Contact("Petra Anic", "098/8568936");
    var contact3 = new Contact("Ana Petric", "099/2268956");

    var calls1 = new List<Call>
    {
        new Call(DateTime.Now.AddHours(-1),StatusCall.Ended),
        new Call(DateTime.Now.AddHours(-3),StatusCall.Ended),
        new Call(DateTime.Now.AddHours(-6),StatusCall.Ended),
    };
    var calls2 = new List<Call>
    {
        new Call(DateTime.Now.AddHours(-9),StatusCall.Missed),
        new Call(DateTime.Now.AddHours(-15),StatusCall.Ended),
        new Call(DateTime.Now.AddHours(-90),StatusCall.Ended),
    };
    var calls3 = new List<Call>
    {
        new Call(DateTime.Now.AddHours(-1),StatusCall.Ended),
        new Call(DateTime.Now.AddHours(-11),StatusCall.Missed),
        new Call(DateTime.Now.AddHours(-15),StatusCall.Ended),
    };

    contactsDict.Add(contact1,calls1 );
    contactsDict.Add(contact2,calls2);
    contactsDict.Add(contact3,calls3);

}