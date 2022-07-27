namespace ClockApp.Models
{

    public class IpBase
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public Timezone timezone { get; set; }
        public string ip { get; set; }
        public string type { get; set; }
        public Connection connection { get; set; }
        public Location location { get; set; }
    }

    public class Timezone
    {
        public string id { get; set; }
        public DateTime current_time { get; set; }
        public string code { get; set; }
        public bool is_daylight_saving { get; set; }
        public int gmt_offset { get; set; }
    }

    public class Connection
    {
        public int asn { get; set; }
        public string organization { get; set; }
        public string isp { get; set; }
    }

    public class Location
    {
        public object geonames_id { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string zip { get; set; }
        public Continent continent { get; set; }
        public Country country { get; set; }
        public City city { get; set; }
        public Region region { get; set; }
    }

    public class Continent
    {
        public string code { get; set; }
        public string name { get; set; }
        public string name_translated { get; set; }
    }

    public class Country
    {
        public string alpha2 { get; set; }
        public string alpha3 { get; set; }
        public string[] calling_codes { get; set; }
        public Currency[] currencies { get; set; }
        public string emoji { get; set; }
        public string ioc { get; set; }
        public Language[] languages { get; set; }
        public string name { get; set; }
        public string name_translated { get; set; }
        public string[] timezones { get; set; }
        public bool is_in_european_union { get; set; }
    }

    public class Currency
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public string symbol_native { get; set; }
        public int decimal_digits { get; set; }
        public int rounding { get; set; }
        public string code { get; set; }
        public string name_plural { get; set; }
    }

    public class Language
    {
        public string name { get; set; }
        public string name_native { get; set; }
    }

    public class City
    {
        public string name { get; set; }
        public string name_translated { get; set; }
    }

    public class Region
    {
        public object fips { get; set; }
        public object alpha2 { get; set; }
        public string name { get; set; }
        public string name_translated { get; set; }
    }

}
