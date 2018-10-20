using Newtonsoft.Json;
using RocketLaunchTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RocketLaunchTracker.Services
{
    public class RocketLaunchService
    {
        private const string apiBaseUrl = "https://launchlibrary.net/1.4/";

        public async Task<LaunchInfo> GetNextLaunchesAsync(int count)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apiBaseUrl);

                var resultString = await httpClient.GetStringAsync($"launch/next/{count}");
                var launchInfo = JsonConvert.DeserializeObject<LaunchInfo>(resultString);

                return launchInfo;
            }
        }

        public async Task<Launch> GetLaunchAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apiBaseUrl);

                var resultString = await httpClient.GetStringAsync($"launch/{id}");
                var launch = JsonConvert.DeserializeObject<LaunchInfo>(resultString);

                return launch.launches.First();
            }
        }

        internal Task SendNotificationEmailAsync(string launchId)
        {
            
        }

        private List<SpacePort> GetSpacePorts()
        {
            var jsonString = @"[
    {
      ""country"": ""Algeria"",
      ""location"": ""Centre interarmées d'essais d'engins spéciaux (CIEES), Hammaguir"",
      ""coordinates"":{ ""latitude"": ""31.09951"", ""longitude"": ""-2.83581""},
      ""operational_date"": { ""start_year"": ""1947"", ""end_year"": ""1967""},
      ""rocket_launches"": 230,
      ""heaviest_rocket"": ""18 000 kg"",
      ""highest_altitude"": ""Orbital"",
      ""notes"": ""Operated by France.""
    },
    {
      ""country"": ""Algeria"",
      ""location"": ""Reggane"",
      ""coordinates"":{""latitude"": ""26.71895"", ""longitude"": ""0.27691""},
      ""operational_date"": {""start_year"": ""1961"", ""end_year"": ""1965""},
      ""rocket_launches"": 10,
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Congo (Zaire)"",
      ""location"": ""Shaba North, Kapani Tonneo OTRAG Launch Center"",
      ""coordinates"":{""latitude"": ""-7.92587"", ""longitude"": ""28.52766""},
      ""operational_date"": {""start_year"": ""1977"", ""end_year"": ""1978""},
      ""rocket_launches"": 3,
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""<50 km"",
      ""notes"": ""German OTRAG rockets.""
    },
    {
      ""country"": ""Egypt"",
      ""location"": ""Jabal Hamzah ballistic missile test and launch facility"",
      ""coordinates"":{""latitude"": ""30.125750"", ""longitude"": ""30.605139""},
      ""operational_date"": ""Late 1950s–present"",
      ""rocket_launches"": 6,
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Al Zafir and Al Kahir SRBMs testing""
    },
    {
      ""country"": ""Kenya"",
      ""location"": ""Broglio Space Centre (San Marco), Malindi"",
      ""coordinates"":{""latitude"": ""-2.94080"", ""longitude"": ""40.21340""},
      ""operational_date"": {""start_year"": ""1964"", ""end_year"": ""1988""},
      ""rocket_launches"": 27,
      ""heaviest_rocket"": ""20 000 kg"",
      ""highest_altitude"": ""Orbital"",
      ""notes"": ""Scout rockets, operated by ASI and Sapienza University of Rome, Italy.""
    },
    {
      ""country"": ""Libya"",
      ""location"": ""Sabha, Tawiwa OTRAG Launch Center"",
      ""coordinates"":""26.99392; 14.46425 "",
      ""operational_date"": {""start_year"": ""1981"", ""end_year"": ""1982""},
      ""rocket_launches"": null,
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""50 km"",
      ""notes"": ""German OTRAG rockets.""
    },
    {
      ""country"": ""Mauritania"",
      ""location"": ""Nouadhibou"",
      ""coordinates"":{""latitude"": ""20.92856"", ""longitude"": ""-17.03153""},
      ""operational_date"": {""start_year"": ""1973"", ""end_year"": ""1973""},
      ""rocket_launches"": 1,
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""During a solar eclipse""
    },
    {
      ""country"": ""South Africa"",
      ""location"": ""Overberg South African Test Centre"",
      ""coordinates"":""-34.60265; 20.30248"",
      ""operational_date"": {""start_year"": ""1989"", ""end_year"": ""1990""},
      ""rocket_launches"": null,
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Launched test mission rockets only.""
    },
     {
      ""country"": ""China"",
      ""location"": ""Base 603, Shijiedu, Guangde"",
      ""coordinates"":{""latitude"": ""30.93743"", ""longitude"": ""119.20575""},
      ""operational_date"": {""start_year"": ""1960"", ""end_year"": ""1966""},
      ""rocket_launches"": """",
      ""heaviest_rocket"": ""1 000 kg"",
      ""highest_altitude"": ""<60 km"",
      ""notes"": """"
    },
    {
      ""country"": ""China"",
      ""location"": ""Jiuquan Satellite Launch Center"",
      ""coordinates"":{""latitude"": ""41.11803"", ""longitude"": ""100.46330""},
      ""operational_date"": {""start_year"": ""1970"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": ""464 000 kg"",
      ""highest_altitude"": ""Orbital"",
      ""notes"": ""Human spaceflight""
    },
    {
      ""country"": ""China"",
      ""location"": ""Taiyuan Satellite Launch Center"",
      ""coordinates"":{""latitude"": ""39.14321"", ""longitude"": ""111.96741""},
      ""operational_date"": {""start_year"": ""1980"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""Orbital"",
      ""notes"": ""Polar satellites""
    },
    {
      ""country"": ""China"",
      ""location"": ""Xichang Satellite Launch Center"",
      ""coordinates"":{""latitude"": ""28.24646"", ""longitude"": ""102.02814""},
      ""operational_date"": {""start_year"": ""1984"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""Lunar"",
      ""notes"": ""Geo-synchronous satellites, lunar probes.""
    },
    {
      ""country"": ""China"",
      ""location"": ""Wenchang Satellite Launch Center"",
      ""coordinates"":{""latitude"": ""19.6144917"", ""longitude"": ""110.9511333""},
      ""operational_date"": {""start_year"": ""2016"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": ""879 000 kg"",
      ""highest_altitude"": ""Orbital"",
      ""notes"": ""New site on Hainan Island with pads for Long March 5 and Long March 7 rockets""
    },
    {
      ""country"": ""China"",
      ""location"": ""Jingyu"",
      ""coordinates"":{""latitude"": ""42.0"", ""longitude"": ""126.5""},
      ""operational_date"": """",
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""India"",
      ""location"": ""Vikram Sarabhai Space Centre, Thiruvananthapuram (thumba), Kerala"",
      ""coordinates"":""8.5314; 76.8690"",
      ""operational_date"": {""start_year"": ""1962"", ""end_year"": """"},
      ""rocket_launches"": "">2000"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""India"",
      ""location"": ""Satish Dhawan Space Centre (Sriharikota), Andhra Pradesh"",
      ""coordinates"":{""latitude"": ""13.73740"", ""longitude"": ""80.23510""},
      ""operational_date"": {""start_year"": ""1971"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": ""402 000 kg"",
      ""highest_altitude"": ""Interplanetary"",
      ""notes"": ""Satellites and lunar probes;""
    },
    {
      ""country"": ""India"",
      ""location"": ""Abdul Kalam Island,  Balasore, Odisha"",
      ""coordinates"":{""latitude"": ""20.75804"", ""longitude"": ""87.085533""},
      ""operational_date"": """",
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Indonesia"",
      ""location"": ""Stasiun Peluncuran Roket, Pameungpeuk, Garut"",
      ""coordinates"":{""latitude"": ""-7.646643"", ""longitude"": ""107.689018""},
      ""operational_date"": {""start_year"": ""1965"", ""end_year"": """"},
      ""rocket_launches"": ""14+"",
      ""heaviest_rocket"": ""765 kg"",
      ""highest_altitude"": ""100 km"",
      ""notes"": """"
    },
    {
      ""country"": ""Iran"",
      ""location"": ""Qom Space Center"",
      ""coordinates"":{""latitude"": ""34.65000"", ""longitude"": ""50.90000""},
      ""operational_date"": ""1991"",
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Military testing""
    },
    {
      ""country"": ""Iran"",
      ""location"": ""Emamshahr Space Center"",
      ""coordinates"":{""latitude"": ""36.42000"", ""longitude"": ""55.02000""},
      ""operational_date"": ""1998"",
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Military testing and sounding rockets for ISA.""
    },
    {
      ""country"": ""Iran"",
      ""location"": ""Semnan spaceport"",
      ""coordinates"":{""latitude"": ""35.234631"", ""longitude"": ""53.920941""},
      ""operational_date"": {""start_year"": ""2009"", ""end_year"": """"},
      ""rocket_launches"": ""2"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""Orbital"",
      ""notes"": """"
    },
    {
      ""country"": ""Iraq"",
      ""location"": ""Al-Anbar Test Center"",
      ""coordinates"":{""latitude"": ""32.78220"", ""longitude"": ""44.29962""},
      ""operational_date"": ""1989"",
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Out of function""
    },
    {
      ""country"": ""Israel"",
      ""location"": ""Palmachim Air Force Base"",
      ""coordinates"":{""latitude"": ""31.88484"", ""longitude"": ""34.68020""},
      ""operational_date"": {""start_year"": ""1987"", ""end_year"": """"},
      ""rocket_launches"": ""9"",
      ""heaviest_rocket"": ""70 000 kg"",
      ""highest_altitude"": ""Orbital"",
      ""notes"": """"
    },
    {
      ""country"": ""Japan"",
      ""location"": ""Akita Rocket Range"",
      ""coordinates"":{""latitude"": ""39.57148"", ""longitude"": ""140.05785""},
      ""operational_date"": {""start_year"": ""1956"", ""end_year"": ""1990""},
      ""rocket_launches"": ""81"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""343 km"",
      ""notes"": """"
    },
    {
      ""country"": ""Japan"",
      ""location"": ""Uchinoura Space Center"",
      ""coordinates"":{""latitude"": ""31.25186"", ""longitude"": ""131.07914""},
      ""operational_date"": {""start_year"": ""1962"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": ""139 000 kg"",
      ""highest_altitude"": ""Interplanetary"",
      ""notes"": """"
    },
    {
      ""country"": ""Japan"",
      ""location"": ""Tanegashima Space Center, Tanegashima Island"",
      ""coordinates"":{""latitude"": ""30.39096"", ""longitude"": ""130.96813""},
      ""operational_date"": {""start_year"": ""1967"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": ""445 000 kg"",
      ""highest_altitude"": ""Interplanetary"",
      ""notes"": """"
    },
    {
      ""country"": ""Japan"",
      ""location"": ""Ryori"",
      ""coordinates"":{""latitude"": ""39.03000"", ""longitude"": ""141.83000""},
      ""operational_date"": {""start_year"": ""1970"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Japan"",
      ""location"": ""Niijima (ja)"",
      ""coordinates"":{""latitude"": ""34.33766"", ""longitude"": ""139.26575""},
      ""operational_date"": """",
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Japan"",
      ""location"": ""Obachi"",
      ""coordinates"":{""latitude"": ""40.70342"", ""longitude"": ""141.36938""},
      ""operational_date"": """",
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Kazakhstan"",
      ""location"": ""Baikonur Cosmodrome, Tyuratam"",
      ""coordinates"":{""latitude"": ""45.95515"", ""longitude"": ""63.35028""},
      ""operational_date"": {""start_year"": ""1957"", ""end_year"": """"},
      ""rocket_launches"": "">1000"",
      ""heaviest_rocket"": ""2 400 000 kg"",
      ""highest_altitude"": ""Interplanetary"",
      ""notes"": ""First satellite, first human. Operated by Russia.""
    },
    {
      ""country"": ""Kazakhstan"",
      ""location"": ""Sary Shagan"",
      ""coordinates"":{""latitude"": ""46.38000"", ""longitude"": ""72.87000""},
      ""operational_date"": {""start_year"": ""1958"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Korea, North"",
      ""location"": ""Musudan-ri"",
      ""coordinates"":{""latitude"": ""40.85572"", ""longitude"": ""129.66587""},
      ""operational_date"": {""start_year"": ""1998"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Military rockets; satellite launch""
    },
    {
      ""country"": ""Korea, North"",
      ""location"": ""Sohae"",
      ""coordinates"":{""latitude"": ""39.660"", ""longitude"": ""124.705""},
      ""operational_date"": {""start_year"": ""2012"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Military rockets; satellite launch""
    },
    {
      ""country"": ""Korea South"",
      ""location"": ""Anhueng"",
      ""coordinates"":{""latitude"": ""36.70211"", ""longitude"": ""126.47158""},
      ""operational_date"": {""start_year"": ""1993"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Korea, South"",
      ""location"": ""Naro Space Center, Gohueng"",
      ""coordinates"":{""latitude"": ""34.42585"", ""longitude"": ""127.52793""},
      ""operational_date"": ""2008"",
      ""rocket_launches"": ""3"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""Orbital"",
      ""notes"": ""Attempted satellite launches""
    },
    {
      ""country"": ""Maldives"",
      ""location"": ""Gan Island"",
      ""coordinates"":{""latitude"": ""-0.69328"", ""longitude"": ""73.15672""},
      ""operational_date"": """",
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Several rockets of the Kookaburra type were launched from a pad at 0°41' S and 73°9' E""
    },
    {
      ""country"": ""Pakistan"",
      ""location"": ""Sonmiani Satellite Launch Center, Las Bela, Balochistan"",
      ""coordinates"":{""latitude"": ""25.19242"", ""longitude"": ""66.74881""},
      ""operational_date"": ""1960s –"",
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Sounding rockets, missile testing, for SUPARCO.""
    },
    {
      ""country"": ""Pakistan"",
      ""location"": ""Tilla Satellite Launch Center, Jhelum District, Punjab"",
      ""coordinates"":{""latitude"": ""33.39610"", ""longitude"": ""73.29608""},
      ""operational_date"": ""1980s –"",
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Sounding rockets, missile testing, for SUPARCO.""
    },
    {
      ""country"": ""Russia"",
      ""location"": ""Kheysa"",
      ""coordinates"":{""latitude"": ""80.45000"", ""longitude"": ""58.05000""},
      ""operational_date"": {""start_year"": ""1956"", ""end_year"": ""1980""},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Russia"",
      ""location"": ""Svobodny Cosmodrome, Amur Oblast"",
      ""coordinates"":""51.83441; 128.27570 "",
      ""operational_date"": {""start_year"": ""1957"", ""end_year"": ""2007""},
      ""rocket_launches"": """",
      ""heaviest_rocket"": ""47 000 kg"",
      ""highest_altitude"": ""Orbital"",
      ""notes"": ""ICBM base converted for satellites""
    },
    {
      ""country"": ""Russia"",
      ""location"": ""Sovetskaya Gavan"",
      ""coordinates"":{""latitude"": ""48.97000"", ""longitude"": ""140.30000""},
      ""operational_date"": {""start_year"": ""1963"", ""end_year"": ""1964""},
      ""rocket_launches"": ""6"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""402 km"",
      ""notes"": """"
    },
    {
      ""country"": ""Russia"",
      ""location"": ""Okhotsk"",
      ""coordinates"":{""latitude"": ""59.367"", ""longitude"": ""143.250""},
      ""operational_date"": {""start_year"": ""1981"", ""end_year"": ""2005""},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""1000 km"",
      ""notes"": """"
    },
    {
      ""country"": ""Russia"",
      ""location"": ""Yasny Cosmodrome (formerly Dombarovskiy), Orenburg Oblast"",
      ""coordinates"":{""latitude"": ""51.20706"", ""longitude"": ""59.85003""},
      ""operational_date"": {""start_year"": ""2006"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": ""211 000 kg"",
      ""highest_altitude"": ""Orbital"",
      ""notes"": ""ICBM base converted for satellites""
    },
    {
      ""country"": ""Russia"",
      ""location"": ""Vostochny Cosmodrome, Amur Oblast, Russia"",
      ""coordinates"":{""latitude"": ""51.883"", ""longitude"": ""128.333""},
      ""operational_date"": ""28 April 2016–"",
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Facility on Russian territory to supplement Baikonur Cosmodrome in Kazakhstan""
    },
    {
      ""country"": ""Taiwan"",
      ""location"": ""Haiqian"",
      ""coordinates"":{""latitude"": ""22.10"", ""longitude"": ""120.90""},
      ""operational_date"": {""start_year"": ""1988"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": ""10 000 kg"",
      ""highest_altitude"": ""300 km"",
      ""notes"": ""Science and technology development""
    },
     {
      ""country"": ""France"",
      ""location"": ""Ile du Levant"",
      ""coordinates"":{""latitude"": ""43.04507"", ""longitude"": ""6.47887""},
      ""operational_date"": {""start_year"": ""1948"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Germany"",
      ""location"": ""Rocket Launch Site Berlin, Berlin-Tegel"",
      ""coordinates"":{""latitude"": ""52.35000"", ""longitude"": ""13.21000""},
      ""operational_date"": {""start_year"": ""1930"", ""end_year"": ""1933""},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""4 km"",
      ""notes"": """"
    },
    {
      ""country"": ""Germany"",
      ""location"": ""Peenemünde/Greifswalder Oie"",
      ""coordinates"":{""latitude"": ""54.14300"", ""longitude"": ""13.79400""},
      ""operational_date"": {""start_year"": ""1942"", ""end_year"": ""1945""},
      ""rocket_launches"": "">3000"",
      ""heaviest_rocket"": ""12 500 kg"",
      ""highest_altitude"": "">100 km"",
      ""notes"": ""V-2 rockets during World War II, first rocket to reach space 20 June 1944""
    },
    {
      ""country"": ""Germany"",
      ""location"": ""Cuxhaven"",
      ""coordinates"":{""latitude"": ""53.84884"", ""longitude"": ""8.59154""},
      ""operational_date"": {""start_year"": ""1945"", ""end_year"": ""1964""},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Germany"",
      ""location"": ""Hespenbusch, Großenkneten"",
      ""coordinates"":{""latitude"": ""52.939002"", ""longitude"": ""8.312515""},
      ""operational_date"": {""start_year"": ""1952"", ""end_year"": ""1957""},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""<10 km"",
      ""notes"": """"
    },
    {
      ""country"": ""Germany"",
      ""location"": ""Zingst"",
      ""coordinates"":{""latitude"": ""54.44008"", ""longitude"": ""12.78431""},
      ""operational_date"": {""start_year"": ""1970"", ""end_year"": ""1992""},
      ""rocket_launches"": ""67"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""80 km"",
      ""notes"": """"
    },
    {
      ""country"": ""Greece"",
      ""location"": ""Koroni"",
      ""coordinates"":{""latitude"": ""36.7698"", ""longitude"": ""21.9316""},
      ""operational_date"": {""start_year"": ""1966"", ""end_year"": ""1989""},
      ""rocket_launches"": ""371"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""114 km"",
      ""notes"": """"
    },
    {
      ""country"": ""Iceland"",
      ""location"": ""Vik"",
      ""coordinates"":{""latitude"": ""63.41891"", ""longitude"": ""-19.00463""},
      ""operational_date"": {""start_year"": ""1964"", ""end_year"": ""1965""},
      ""rocket_launches"": ""2"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Italy"",
      ""location"": ""Salto di Quirra"",
      ""coordinates"":{""latitude"": ""39.52731"", ""longitude"": ""9.63303""},
      ""operational_date"": {""start_year"": ""1964"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Norway"",
      ""location"": ""Andøya Space Center"",
      ""coordinates"":{""latitude"": ""69.29430"", ""longitude"": ""16.02070""},
      ""operational_date"": {""start_year"": ""1962"", ""end_year"": """"},
      ""rocket_launches"": "">1200"",
      ""heaviest_rocket"": ""800 kg"",
      ""highest_altitude"": """",
      ""notes"": ""Rockets to the upper atmosphere.""
    },
    {
      ""country"": ""Norway"",
      ""location"": ""Marka"",
      ""coordinates"":{""latitude"": ""58.20000"", ""longitude"": ""7.30000""},
      ""operational_date"": {""start_year"": ""1983"", ""end_year"": ""1984""},
      ""rocket_launches"": """",
      ""heaviest_rocket"": ""16 kg"",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Norway"",
      ""location"": ""SvalRak"",
      ""coordinates"":{""latitude"": ""78.2234"", ""longitude"": ""15.6470""},
      ""operational_date"": {""start_year"": ""1997"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Poland"",
      ""location"": ""Tuchola Forest"",
      ""coordinates"":{""latitude"": ""53.61970"", ""longitude"": ""17.98492""},
      ""operational_date"": {""start_year"": ""1944"", ""end_year"": ""1945""},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Nazi-German V-2 rockets""
    },
    {
      ""country"": ""Poland"",
      ""location"": ""Łeba"",
      ""coordinates"":{""latitude"": ""54.76904"", ""longitude"": ""17.59355""},
      ""operational_date"": {""start_year"": ""1941"", ""end_year"": ""1945""},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Nazi-German rockets""
    },
    {
      ""country"": ""Poland"",
      ""location"": ""Łeba-Rąbka"",
      ""coordinates"":{""latitude"": ""54.754486"", ""longitude"": ""17.517919""},
      ""operational_date"": {""start_year"": ""1963"", ""end_year"": ""1973""},
      ""rocket_launches"": ""36"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Polish rockets""
    },
    {
      ""country"": ""Poland"",
      ""location"": ""Blizna"",
      ""coordinates"":{""latitude"": ""50.18190"", ""longitude"": ""21.61620""},
      ""operational_date"": {""start_year"": ""1943"", ""end_year"": ""1944""},
      ""rocket_launches"": ""139"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Nazi-German V-2 rockets""
    },
    {
      ""country"": ""Russia"",
      ""location"": ""Kapustin Yar Cosmodrome, Astrakhan Oblast"",
      ""coordinates"":{""latitude"": ""48.57807"", ""longitude"": ""46.25420""},
      ""operational_date"": {""start_year"": ""1957"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""Orbital"",
      ""notes"": ""Previously for satellite launches""
    },
    {
      ""country"": ""Russia"",
      ""location"": ""Nyonoksa"",
      ""coordinates"":{""latitude"": ""64.64928"", ""longitude"": ""39.18721""},
      ""operational_date"": {""start_year"": ""1965"", ""end_year"": ""1997""},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Russia"",
      ""location"": ""Plesetsk Cosmodrome"",
      ""coordinates"":{""latitude"": ""62.92556"", ""longitude"": ""40.57778""},
      ""operational_date"": {""start_year"": ""1966"", ""end_year"": """"},
      ""rocket_launches"": "">1000"",
      ""heaviest_rocket"": ""760 000 kg"",
      ""highest_altitude"": ""Orbital"",
      ""notes"": """"
    },
    {
      ""country"": ""Spain"",
      ""location"": ""El Arenosillo"",
      ""coordinates"":{""latitude"": ""37.09687"", ""longitude"": ""-6.73863""},
      ""operational_date"": {""start_year"": ""1966"", ""end_year"": """"},
      ""rocket_launches"": "">500"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Sweden"",
      ""location"": ""Nausta"",
      ""coordinates"":{""latitude"": ""66.357202"", ""longitude"": ""19.275813""},
      ""operational_date"": {""start_year"": ""1961"", ""end_year"": ""1961""},
      ""rocket_launches"": ""1"",
      ""heaviest_rocket"": ""30 kg"",
      ""highest_altitude"": ""<80 km"",
      ""notes"": ""Arcas rocket for atmospheric research.""
    },
    {
      ""country"": ""Sweden"",
      ""location"": ""Kronogård"",
      ""coordinates"":{""latitude"": ""66.4147"", ""longitude"": ""19.2767""},
      ""operational_date"": {""start_year"": ""1961"", ""end_year"": ""1964""},
      ""rocket_launches"": ""18"",
      ""heaviest_rocket"": ""700 kg"",
      ""highest_altitude"": ""135 km"",
      ""notes"": ""Arcas, Nike-Cajun and Nike-Apache rockets for atmospheric research.""
    },
    {
      ""country"": ""Sweden"",
      ""location"": ""Esrange, Kiruna"",
      ""coordinates"":""67.89342; 21.10429 "",
      ""operational_date"": {""start_year"": ""1966"", ""end_year"": ""1972""},
      ""rocket_launches"": ""150"",
      ""heaviest_rocket"": ""700 kg"",
      ""highest_altitude"": ""237 km"",
      ""notes"": ""Operated by ESRO.""
    },
    {
      ""country"": ""Sweden"",
      ""location"": ""Esrange, Kiruna"",
      ""coordinates"":""67.89342; 21.10429 "",
      ""operational_date"": {""start_year"": ""1972"", ""end_year"": """"},
      ""rocket_launches"": ""300"",
      ""heaviest_rocket"": ""12 400 kg"",
      ""highest_altitude"": ""717 km"",
      ""notes"": ""Operated by SSC. Major programmes: Maxus, TEXUS, Maser, stratospheric balloons.""
    },
    {
      ""country"": ""United Kingdom"",
      ""location"": ""Highdown Test Site, Isle of Wight"",
      ""coordinates"":""50.6639345; -1.5763664 "",
      ""operational_date"": {""start_year"": ""1956"", ""end_year"": ""1971""},
      ""rocket_launches"": ""0"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""This site was used for static tests of assembled rockets only prior to them being shipped to Australia for launch.""
    },
    {
      ""country"": ""United Kingdom"",
      ""location"": ""South Uist"",
      ""coordinates"":""57.33000; -7.33000 "",
      ""operational_date"": {""start_year"": ""1959"", ""end_year"": """"},
      ""rocket_launches"": ""1 (2015)"",
      ""heaviest_rocket"": ""approx 1300 kg plus payload"",
      ""highest_altitude"": """",
      ""notes"": ""First space launch from the UK took place from here in October 2015 as part of 'At Sea Demonstration 15' . The rocket was an American 'Terrier-Orion' sounding rocket.""
    },{
      ""country"": ""Canada"",
      ""location"": ""Churchill Rocket Research Range, Manitoba"",
      ""coordinates"":""58.73430; -93.82030 "",
      ""operational_date"": {""start_year"": ""1954"", ""end_year"": ""1998""},
      ""rocket_launches"": "">3500"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Canadian Army.""
    },
    {
      ""country"": ""Canada"",
      ""location"": ""Resolute Bay, Nunavut"",
      ""coordinates"":""74.6870; -94.8962 "",
      ""operational_date"": {""start_year"": ""1966"", ""end_year"": ""1971""},
      ""rocket_launches"": ""17"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""National Research Council Canada.""
    },
    {
      ""country"": ""Canada"",
      ""location"": ""Hall Beach"",
      ""coordinates"":{""latitude"": ""68.77607"", ""longitude"": ""-81.24346""},
      ""operational_date"": {""start_year"": ""1971"", ""end_year"": ""1971""},
      ""rocket_launches"": ""7"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""270 km"",
      ""notes"": """"
    },
    {
      ""country"": ""Canada"",
      ""location"": ""Southend"",
      ""coordinates"":{""latitude"": ""56.333"", ""longitude"": ""-103.233""},
      ""operational_date"": {""start_year"": ""1980"", ""end_year"": ""1980""},
      ""rocket_launches"": ""2"",
      ""heaviest_rocket"": ""1 200 kg"",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""Greenland (Denmark)"",
      ""location"": ""Thule Air Base"",
      ""coordinates"":{""latitude"": ""76.4240"", ""longitude"": ""-68.2936""},
      ""operational_date"": {""start_year"": ""1964"", ""end_year"": ""1980""},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""US Air Force""
    },
    {
      ""country"": ""United States"",
      ""location"": ""Wallops Flight Facility, Delmarva Peninsula, Virginia"",
      ""coordinates"":""37.84621; -75.47938 "",
      ""operational_date"": {""start_year"": ""1945"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Now operated by NASA's Goddard Space Flight Center""
    },
    {
      ""country"": ""United States"",
      ""location"": ""White Sands Missile Range"",
      ""coordinates"":{""latitude"": ""32.56460"", ""longitude"": ""-106.35908""},
      ""operational_date"": {""start_year"": ""1946"", ""end_year"": """"},
      ""rocket_launches"": "">7000"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Military and civilian flights. Served as alternate landing site for the space shuttle.""
    },
    {
      ""country"": ""United States"",
      ""location"": ""Nevada Test and Training Range (formerly Nellis Air Force Range)"",
      ""coordinates"":{""latitude"": ""36.77150"", ""longitude"": ""-116.11374""},
      ""operational_date"": ""1950s–"",
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": """"
    },
    {
      ""country"": ""United States"",
      ""location"": ""Cape Canaveral Air Force Station, Florida"",
      ""coordinates"":{""latitude"": ""28.46675"", ""longitude"": ""-80.55852""},
      ""operational_date"": {""start_year"": ""1956"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""Interstellar"",
      ""notes"": ""Commercial and U.S. Government unmanned missions.""
    },
    {
      ""country"": ""United States"",
      ""location"": ""Vandenberg Air Force Base, California"",
      ""coordinates"":{""latitude"": ""34.77204"", ""longitude"": ""-120.60124""},
      ""operational_date"": {""start_year"": ""1958"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""Interplanetary"",
      ""notes"": ""Satellites, ballistic missile tests. Government and commercial launches.""
    },
    {
      ""country"": ""United States"",
      ""location"": ""Kennedy Space Center, Florida"",
      ""coordinates"":{""latitude"": ""28.6082"", ""longitude"": ""-80.6040""},
      ""operational_date"": {""start_year"": ""1963"", ""end_year"": """"},
      ""rocket_launches"": ""151"",
      ""heaviest_rocket"": ""3 000 000 kg"",
      ""highest_altitude"": ""Interplanetary"",
      ""notes"": ""Launched each NASA manned mission. Adjacent to Cape Canaveral Air Force Station.""
    },
    {
      ""country"": ""United States"",
      ""location"": ""Pacific Missile Range Facility, Hawaii"",
      ""coordinates"": ""22°01′22″N 159°47′06″W / 22.02278°N 159.785°W / 22.02278; -159.785"",
      ""operational_date"": {""start_year"": ""1963"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""testing of antiballistic missile and missile tracking by the US Navy.""
    },
    {
      ""country"": ""United States"",
      ""location"": ""Keweenaw, Michigan"",
      ""coordinates"":{""latitude"": ""47.42980"", ""longitude"": ""-87.71443""},
      ""operational_date"": {""start_year"": ""1964"", ""end_year"": ""1971""},
      ""rocket_launches"": "">50"",
      ""heaviest_rocket"": ""770 kg"",
      ""highest_altitude"": ""<160 km"",
      ""notes"": ""Currently inactive""
    },
    {
      ""country"": ""United States"",
      ""location"": ""Kodiak Launch Complex, Alaska"",
      ""coordinates"":{""latitude"": ""57.43533"", ""longitude"": ""-152.33931""},
      ""operational_date"": {""start_year"": ""1991"", ""end_year"": """"},
      ""rocket_launches"": ""14"",
      ""heaviest_rocket"": ""86 000 kg"",
      ""highest_altitude"": ""Orbital"",
      ""notes"": ""Ballistic missile interceptor tests, satellite launches. Alaska Aerospace Corporation.""
    },
    {
      ""country"": ""United States"",
      ""location"": ""Mojave Air and Space Port, California"",
      ""coordinates"":{""latitude"": ""35.05910"", ""longitude"": ""-118.14880""},
      ""operational_date"": {""start_year"": ""2004"", ""end_year"": """"},
      ""rocket_launches"": """",
      ""heaviest_rocket"": """",
      ""highest_altitude"": ""112 km"",
      ""notes"": ""Privately funded spacecraft (Xoie, Xombie,  Xodiac, SpaceShipOne, SpaceShipTwo).""
    },
    {
      ""country"": ""United States"",
      ""location"": ""Spaceport America (formerly Southwest Regional Spaceport), Upham, New Mexico"",
      ""coordinates"":{""latitude"": ""32.88943"", ""longitude"": ""-106.99945""},
      ""operational_date"": {""start_year"": ""2006"", ""end_year"": """"},
      ""rocket_launches"": ""8"",
      ""heaviest_rocket"": """",
      ""highest_altitude"": """",
      ""notes"": ""Sub-orbital commercial and planned space tourist launches. Operated by the state of New Mexico with Virgin Galactic as the anchor tenant.""
    },
    {
      ""country"": ""United States"",
      ""location"": ""Mid-Atlantic Regional Spaceport (MARS), Delmarva Peninsula, Virginia"",
      ""coordinates"":{""latitude"": ""37.833378"", ""longitude"": ""-75.483284""},
      ""operational_date"": {""start_year"": ""2006"", ""end_year"": """"},
      ""rocket_launches"": ""6"",
      ""heaviest_rocket"": ""89 805 kg"",
      ""highest_altitude"": ""Lunar"",
      ""notes"": ""Operates in partnership with NASA, adjacent to the Wallops Flight Facility site. Designed for both commercial and government launches.""
    }
   ]";

            //var spacePorts = JsonConvert.DeserializeObject<List<SpacePort>>();

            return null;
        }

     
    }
}
