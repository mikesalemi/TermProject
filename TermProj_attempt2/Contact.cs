namespace TermProj
{
    public class Contact : ICallable
    {
        private string name; // name of contact
        private string number; // number of contact

        public Contact(string _name, string _number) // constructor for the contact class
        {
            this.name = _name;
            this.number = _number;
        }
        
        public string getNumber() // returns contact number
        {
            return number;
        }

        public string getName() // returns contact name
        {
            return name;
        }

        public void changeNumber(string _number) // changes contact number
        {
            if (_number != null) // implements safeguards
                this.number = _number;
        }

        public void changeName(string _name) // changes contact name
        {
            if (_name != null) // implements safeguard for null values
                this.name = _name;
        }
    }
}