using Newtonsoft.Json;
using NWS_API;
using NWS_API_Forecast;
using RestSharp;
using NDBC;

namespace LearnTutorial.Pages;


public partial class ConditionsPage : ContentPage
{
    WaveStation46254? wave;
	public ConditionsPage()
	{
		InitializeComponent();
        InitializeUI();


    }
	void InitializeUI()
	{
        GetWaterTempConditions();
        GetForeCastConditions();
        //GetWaveHeights();
        WaveHeightAndWaterTemp();

    }
    async void WaveHeightAndWaterTemp()
    {

        WaveStation46254 buoy = new WaveStation46254();
        wave=await buoy.GetWaveHeightAndWaterTemp();
        lblNBDCWaveHeight.Text = ConvertMetersToFeet(wave.WaveHeight).ToString("F1");//F1 is one decimal spot
        lblExpectedVisibility.Text = (-16.74 * wave.WaveHeight + 32.50).ToString("F1");//THis is the linear regression equations from my python model
        lblWaterTemp.Text = ConvertToF(wave.WaterTemp).ToString("F1");
    }
    
    static double ConvertMetersToFeet(double meters)
    {
        return meters * 3.2808;
    }
	
    public async void GetWaterTempConditions()
    {
        var options = new RestClientOptions("https://api.weather.gov/stations/LJAC1/observations/latest");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");//seeing if the api needs this
        var response = await client.GetAsync(request);

        NWS_API.Root data = JsonConvert.DeserializeObject<NWS_API.Root>(response.Content);
        try
        {
            double AirTempValue = (double)data.properties.temperature.value;
            lblAirTemp.Text = ConvertToF(AirTempValue).ToString("F1");
        }
        catch(Exception ex)
        {
            lblAirTemp.Text = $"Invalid API Response. Error: {ex.Message}";
            lblAirTemp.HeightRequest = 60;
            
        }
        

        //lblAirTemp.Text = data.properties.temperature.value.ToString();

    }
    public static double ConvertToF(double C)
    {
        return (C * 9) / 5 + 32;
    }
    public async void GetForeCastConditions()
    {
        var options = new RestClientOptions("https://api.weather.gov/gridpoints/SGX/54,20/forecast");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");//seeing if the api needs this
        var response = await client.GetAsync(request);

        NWS_API_Forecast.Root data = JsonConvert.DeserializeObject<NWS_API_Forecast.Root>(response.Content);

        string shortForecastPeriod1 = data.properties.periods
            .Where(p => p.number == 1)
            .Select(p => p.shortForecast)
            .FirstOrDefault();

        lblCurrentWeather.Text= shortForecastPeriod1;

        string detailedForecastPeriod1 = data.properties.periods
            .Where(p => p.number == 1)
            .Select(p => p.detailedForecast)
            .FirstOrDefault();

        lblShortTermForecast.Text= detailedForecastPeriod1;

        //lblAirTemp.Text = data.properties.temperature.value.ToString();

    }
}