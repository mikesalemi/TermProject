namespace TermProj
{
    public interface ICallable // facade build pattern. Used for the PhoneBook Class to access the Contact class without getting direct access to member variables
    {
        public string getNumber(); // returns contact number

        public string getName(); // returns contact

        public void changeNumber(string number); // changes a contacts number

        public void changeName(string name); // changes a contacts name
    }
}