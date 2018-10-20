namespace RocketLaunchTracker.Data
{
    public class Coordinate
    {
        public string latitude { get; set; }

        public string longitude { get; set; }
    }

    public class Dates
    {
        public string start_year { get; set; }

        public string end_year { get; set; }
    }

    public class SpacePort
    {
        public string country { get; set; }
        public string location { get; set; }
        public Coordinate coordinates { get; set; }
        public Dates operational_date { get; set; }
        public string rocket_launches { get; set; }
        public string heaviest_rocket { get; set; }
        public string highest_altitude { get; set; }
        public string notes { get; set; }
    }
}
