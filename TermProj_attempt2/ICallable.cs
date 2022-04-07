namespace TermProj
{
    public interface ICallable
    {
        public string getNumber();

        public string getName();

        public void changeNumber(string number);

        public void changeName(string name);
    }
}