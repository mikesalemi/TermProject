namespace TermProj
{
    public class Contact : ICallable
    {
        private string name;
        private string number;

        public Contact(string _name, string _number)
        {
            this.name = _name;
            this.number = _number;
        }
        
        public string getNumber()
        {
            return number;
        }

        public string getName()
        {
            return name;
        }

        public void changeNumber(string _number)
        {
            if (_number != null)
                this.number = _number;
        }

        public void changeName(string _name)
        {
            if (_name != null)
                this.name = _name;
        }
    }
}