namespace TelerikColours.CustomEventArgs
{
    public class AddCountryCustomEventArgs
    {
        public string Name { get; set; }

        public AddCountryCustomEventArgs(string name)
        {
            this.Name = name;
        }
    }
}