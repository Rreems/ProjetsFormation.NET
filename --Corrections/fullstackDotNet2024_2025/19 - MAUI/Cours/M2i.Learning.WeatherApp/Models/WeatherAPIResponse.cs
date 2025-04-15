﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2i.Learning.WeatherApp.Models
{

    public class WeatherAPIResponse
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public float generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public Current_Weather_Units current_weather_units { get; set; }
        public Current_Weather current_weather { get; set; }
        public Daily_Units daily_units { get; set; }
        public Daily daily { get; set; }
        public List<Daily2> daily2 { get; set; } = new();
    }

    public class Current_Weather_Units
    {
        public string time { get; set; }
        public string interval { get; set; }
        public string temperature { get; set; }
        public string windspeed { get; set; }
        public string winddirection { get; set; }
        public string is_day { get; set; }
        public string weathercode { get; set; }
    }

    public class Current_Weather
    {
        public string time { get; set; }
        public int interval { get; set; }
        public float temperature { get; set; }
        public float windspeed { get; set; }
        public int winddirection { get; set; }
        public int is_day { get; set; }
        public int weathercode { get; set; }
    }

    public class Daily_Units
    {
        public string time { get; set; }
        public string weathercode { get; set; }
        public string temperature_2m_max { get; set; }
        public string temperature_2m_min { get; set; }
    }

    public class Daily
    {
        public string[] time { get; set; }
        public int[] weathercode { get; set; }
        public float[] temperature_2m_max { get; set; }
        public float[] temperature_2m_min { get; set; }
    }

    public class Daily2
    {
        public string time { get; set; }
        public int weathercode { get; set; }
        public float temperature_2m_max { get; set; }
        public float temperature_2m_min { get; set; }
    }

}
