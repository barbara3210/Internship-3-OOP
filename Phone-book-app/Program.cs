using Phone_book_app.Classes;

var calls = new Dictionary<Contact, List<Call>>();


while(true)
{

    Console.WriteLine("~MENU~\n"
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

    if(int.TryParse(choice, out int your_choice))
    {
        switch (your_choice)
        {
            case 1:
                PrintAllContact();
                break;
            case 2:
                AddNewContact();
                break;
            case 3:
                DeleteContact();
                break;
            case 4:
                EditPreferenceContact();
                break;
            case 5:
                ManageContact();
                break;
            case 6:
                PrintAllCalls();
                break;
            case 7:
                break;
            default: break;
        }
    }
    else { Console.WriteLine("Ponovi unos"); }


    Console.WriteLine("~SUBMENU~\n"
    + "1 - Ispis svih poziva\n"
    + "2 - Novi poziv\n"
    + "3 - Izlaz iz podmenua\n"

    );
}




static void PrintAllContact()
{

}
static void AddNewContact()
{

}
static void DeleteContact()
{

}
static void EditPreferenceContact()
{

}
static void ManageContact()
{

}
static void PrintAllCalls()
{

}
