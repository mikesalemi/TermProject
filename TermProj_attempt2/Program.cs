using System;

namespace TermProj
{
    class Program
    {
        static void Main(string[] args)
        {
            Phonebook mike = Phonebook.Instance; // singleton class being used
            mike.setPhonebookOwner("Mike"); // sets owners name
            populatePhoneBook(mike); // adds all contacts to phonebook for program startup
            mike.displayPhonebookInfo(); // displays owner and count of contacts
            mike.displayContactList(); // displays all contacts in the contact list, not the wait-list

        }

        static bool populatePhoneBook(Phonebook myPhoneBook) { // adds all contacts to the contact list
            Contact[] contacts =
            {
                new Contact("John Davis", "7946258746"),
                new Contact("Lisa Kudrow", "8746215487"),
                new Contact("Wayne Simmonds", "9230038706"),
                new Contact("Happy Gilmore", "6632544587"),
                new Contact("Tiger Williams", "8988874521"),
                new Contact("Tiger Woods", "9758543225"),
                new Contact("Courtney Cox", "1012355602"),
                new Contact("Wayne Gretzky", "2011143986"),
                new Contact("Jerome Seinfeld", "7985501234"),
                new Contact("Sean Combs", "1002356986"),
                new Contact("Denzel Washington", "4163202252"),
                new Contact("Jo Beck", "9866636025"),
                new Contact("Eryn Washington", "4475012141"),
                new Contact("Muhammad Ali", "9902523142"),
                new Contact("Mike Tyson", "4765892301"),
                new Contact("Wayne Brody", "7765853215"),
                new Contact("Michael Jordan", "4463202589"),
                new Contact("Michael Schumacher", "7796353601")
            };

            bool allFit = true; // returns true if no contacts are added to the wait-list
            foreach (var c in contacts)
            {
                if (!myPhoneBook.addContact(c.getName(), c.getNumber())) // executed if contact list is full
                    allFit = false;
            }

            Console.WriteLine();
            Console.WriteLine($"{myPhoneBook.waitlistCount()} contacts in wait-list.");
            Console.WriteLine();
            return allFit; // returns false if there are contacts in the wait-list
        }
}
}