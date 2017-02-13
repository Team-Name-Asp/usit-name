namespace TelerikColours.Mvp.CustomEventArgs
{
    public class FlightSortCustomEventArgs
    {
        public FlightSortCustomEventArgs(string sortType, string sortExpression)
        {
            this.SortExpression = sortExpression;
            this.SortType = sortType;
        }

        public string SortType { get; set; }

        public string SortExpression { get; set; }
    }
}
