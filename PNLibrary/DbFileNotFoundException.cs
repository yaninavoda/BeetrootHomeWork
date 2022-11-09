namespace PNLibrary
{
    public class DbFileNotFoundException : Exception
    {
        public DbFileNotFoundException() : base("DB file doesn't exist.")
        {

        }
    }
}
