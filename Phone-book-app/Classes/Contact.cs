﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_book_app.Classes
{
    public enum ContactPreference
    {
        Favorite,
        Normal,
        Blocked
    }
    public class Contact
    {

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public ContactPreference Preference { get; set; }
        
        public Contact(string name, string phone)
        {
            Name = name;
            PhoneNumber = phone;
            Preference = ContactPreference.Normal;
        }
        public Contact(ContactPreference preference)
        {
            Preference = preference;
        }
    }
}
