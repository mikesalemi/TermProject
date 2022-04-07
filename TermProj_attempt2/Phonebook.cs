using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TermProj
{
    public class Phonebook
    {
        private string phonebookOwner;
        private LinkedList<Contact> contactList;
        private static Phonebook instance = new Phonebook(); // singleton object creation
        private Queue<Contact> contactsToBeAdded; 
        private int maxContacts;
        
        private Phonebook() // default constructor for the singleton PhoneBook object
        {
        contactList = new LinkedList<Contact>();
        contactsToBeAdded = new Queue<Contact>();
        maxContacts = 15;
        }

        public void setPhonebookOwner(string name) // set name for owner of the singleton phonebook object
        {
            this.phonebookOwner = name;
        }

        public int waitlistCount() // returns the amount of contacts in the waitlist
        {
            return contactsToBeAdded.Count;
        }
        public static Phonebook Instance   // singleton class implementation. Only one PhoneBook can be created per program.
        {
            get
            {
                return instance;
            }
        }

        // chain of responsibility
        public bool addContact(string name, string number) // this function does not allow adding contacts to the contactList if they have null values for their name ior number. Security is implemented in the contact class to ensure successful adding.
        {
            if (name != null || number != null) // contact is added if both fields are acceptable
            {
                Contact newContact = new Contact(name, number); // contact created
                insertContact(newContact); // contact added
                return true;
            }

            Console.WriteLine("Invalid contact details."); // executed if null values are given for name or number
            return false;
        }

        public void displayContactList() // displays all contacts in the contactList, not in the waitlist queue
        {
            for (int i = 0; i < contactList.Count; i++)
            {
                Console.WriteLine($"{i+1}: {contactList.ElementAt(i).getName()} {contactList.ElementAt(i).getNumber()}"); // displays the index, name and numbver of the contact
            }

            Console.WriteLine(); // spacing
        }

        public Contact getContact(string name) // returns a contact with a matching name as the parameter
        {
            foreach (var contact in contactList) // iterates through the contact listlooking for a match
            {
                if (contact.getName() == name)
                    return contact; // returns match
            }

            return null; // returns null if there is no match
        }

        private void insertContact(Contact newContact) // this function adds a contact to the contact list if there is space is available (10 contacts maximum)
        {
            if (contactList.Count == maxContacts) // if there is no space, contact is added to a waitlist queue to be added later.
            {
                contactsToBeAdded.Enqueue(newContact); // contact enqueued if full contactlist
                Console.WriteLine($"Contact list is full. {newContact.getName()} was added to waitlist.");
            }
            else
            {
                contactList.AddLast(newContact);
                sort();
                Console.WriteLine($"{newContact.getName()} was added to contact list.");
            }
            
        }

        public void displayPhonebookInfo() // displays information regarding the singleton PhoneBook object such as owner and contact count
        {
            Console.WriteLine($"{phonebookOwner}'s phonebook: {contactList.Count} contacts");
        }
        private void sort() // this is our algorithm that is called to sort the contact list in alphabetical order when a new contact is added.
        {
            int length = contactList.Count;
            for (int i = 0; i < length- 1; i++)
            {
                var recentNode = contactList.First;
                for (int j = 0; j < length-i-1; j++)//loop through contacts
                {
                    //get the 2 names
                    char[] c1 = contactList.ElementAt(j).getName().ToLower().ToCharArray();
                    char[] c2 = contactList.ElementAt(j+1).getName().ToLower().ToCharArray();

                    //loop through letters
                    if(c1.Length < c2.Length)
                    {
                        for (int n = 0; n < c1.Length; n++)
                        {
                            if (c2[n] < c1[n])
                            {
                                //swap
                                var temp = recentNode.Next;
                                contactList.Remove(temp);
                                contactList.AddBefore(recentNode, temp);
                                break;
                            }
                            else if (c2[n] > c1[n])
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int n = 0; n < c2.Length; n++)
                        {
                            if (c2[n] < c1[n])
                            {
                                //swap
                                var temp = recentNode.Next;
                                contactList.Remove(temp);
                                contactList.AddBefore(recentNode, temp);
                                break;
                            }
                            else if (c2[n] > c1[n])
                            {
                                break;
                            }
                            else if (n == c2.Length -1)
                            {
                                //swap because c2 is shorter, so it should come before the other one
                                var temp = recentNode.Next;
                                contactList.Remove(temp);
                                contactList.AddBefore(recentNode, temp);
                            }
                        }
                    }
                    
                    recentNode = recentNode.Next;
                }
            }
        }
    }
}