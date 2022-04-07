using System;

namespace TermProj
{
    class Program
    {
        static void Main(string[] args)
        {
            Phonebook mike = Phonebook.Instance;
            Contact[] a =
            {
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf"),
                new Contact("fish", "fdoisnf")
            };

            foreach (var c in a)
            {
                mike.addContact(c.getName(), c.getNumber());
            }
        }
    }
}