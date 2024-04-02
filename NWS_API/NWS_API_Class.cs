using Newtonsoft.Json;
using System;

namespace NWS_API
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class BarometricPressure
    {
        public string unitCode { get; set; }
        public double? value { get; set; }
        public string qualityControl { get; set; }
    }

    public class Dewpoint
    {
        public string unitCode { get; set; }
        public object? value { get; set; }
        public string qualityControl { get; set; }
    }

    public class Elevation
    {
        public string unitCode { get; set; }
        public int value { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class HeatIndex
    {
        public string unitCode { get; set; }
        public object? value { get; set; }
        public string qualityControl { get; set; }
    }

    public class MaxTemperatureLast24Hours
    {
        public string unitCode { get; set; }
        public object? value { get; set; }
    }

    public class MinTemperatureLast24Hours
    {
        public string unitCode { get; set; }
        public object? value { get; set; }
    }

    public class PrecipitationLast3Hours
    {
        public string unitCode { get; set; }
        public object? value { get; set; }
        public string qualityControl { get; set; }
    }

    public class Properties
    {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("@type")]
        public string type { get; set; }
        public Elevation elevation { get; set; }
        public string station { get; set; }
        public DateTime timestamp { get; set; }
        public string rawMessage { get; set; }
        public string textDescription { get; set; }
        public object icon { get; set; }
        public List<object> presentWeather { get; set; }
        public Temperature temperature { get; set; }
        public Dewpoint dewpoint { get; set; }
        public WindDirection windDirection { get; set; }
        public WindSpeed windSpeed { get; set; }
        public WindGust windGust { get; set; }
        public BarometricPressure barometricPressure { get; set; }
        public SeaLevelPressure seaLevelPressure { get; set; }
        public Visibility visibility { get; set; }
        public MaxTemperatureLast24Hours maxTemperatureLast24Hours { get; set; }
        public MinTemperatureLast24Hours minTemperatureLast24Hours { get; set; }
        public PrecipitationLast3Hours precipitationLast3Hours { get; set; }
        public RelativeHumidity relativeHumidity { get; set; }
        public WindChill windChill { get; set; }
        public HeatIndex heatIndex { get; set; }
        public List<object> cloudLayers { get; set; }
    }

    public class RelativeHumidity
    {
        public string unitCode { get; set; }
        public object? value { get; set; }
        public string qualityControl { get; set; }
    }

    public class Root
    {
        [JsonProperty("@context")]
        public List<object> context { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class SeaLevelPressure
    {
        public string unitCode { get; set; }
        public object? value { get; set; }
        public string qualityControl { get; set; }
    }

    public class Temperature
    {
        public string unitCode { get; set; }
        public double? value { get; set; }
        public string qualityControl { get; set; }
    }

    public class Visibility
    {
        public string unitCode { get; set; }
        public object? value { get; set; }
        public string qualityControl { get; set; }
    }

    public class WindChill
    {
        public string unitCode { get; set; }
        public object? value { get; set; }
        public string qualityControl { get; set; }
    }

    public class WindDirection
    {
        public string unitCode { get; set; }
        public int? value { get; set; }
        public string qualityControl { get; set; }
    }

    public class WindGust
    {
        public string unitCode { get; set; }
        public object? value { get; set; }
        public string qualityControl { get; set; }
    }

    public class WindSpeed
    {
        public string unitCode { get; set; }
        public decimal? value { get; set; }
        public string qualityControl { get; set; }
    }




}
