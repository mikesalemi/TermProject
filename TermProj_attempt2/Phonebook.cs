using System;
using System.Collections;
using System.Collections.Generic;

namespace TermProj
{
    public class Phonebook
    {
        private string phonebookOwner;
        private LinkedList<Contact> contactList = new LinkedList<Contact>();
        private static Phonebook instance = new Phonebook("DEFAULT");
        private Queue<Contact> contactsToBeAdded = new Queue<Contact>();
        private int maxContacts = 10;
        
        private Phonebook(string _phonebookOwner)
        {
            this.phonebookOwner = _phonebookOwner;
        }

        public static Phonebook Instance   // singleton class
        {
            get
            {
                return instance;
            }
        }

        public bool addContact(string name, string number)
        {
            if (name != null && number != null)
            {
                Contact newContact = new Contact(name, number);
                insertContact(newContact);
                Console.WriteLine("Contact added.");
                return true;
            }

            Console.WriteLine("Invalid contact details.");
            return false;
        }

        public Contact getContact(string name)
        {
            foreach (var contact in contactList)
            {
                if (contact.getName() == name)
                    return contact;
            }

            return null;
        }

        private void insertContact(Contact newContact) 
        {
            if (contactList.Count == maxContacts)
            {
                contactsToBeAdded.Enqueue(newContact);
                Console.WriteLine("Contact list is full. Contact added to waitlist.");
            }
            else
            {
                // sorting algorithm here
                
            }
            
        }

        public void displayPhonebookInfo()
        {
            Console.WriteLine($"{phonebookOwner}'s phonebook: {contactList.Count} contacts");
        }
    }
}