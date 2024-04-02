namespace NDBC
{
    
    public class WaveStation46254
    { 
        public double WaveHeight { get; set; }
        public double WaterTemp { get; set; }
        
        public async Task<WaveStation46254> GetWaveHeightAndWaterTemp()
        {
            string dataUrl = "https://www.ndbc.noaa.gov/data/realtime2/46254.txt";
            WaveStation46254 wave = new WaveStation46254();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetStringAsync(dataUrl);
                    var lines = response.Split('\n');

                    // Assuming the data format remains consistent
                    var dataLine = lines[2]; // Change the index if needed

                    var dataValues = dataLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // Access the WVHT value (8th index)
                    if (dataValues.Length > 8 && double.TryParse(dataValues[8], out double wvht))
                    {
                        wave.WaveHeight = wvht;
                    }
                    else
                    {
                        Console.WriteLine("Unable to extract WVHT value.");
                    }
                    if (dataValues.Length > 14 && double.TryParse(dataValues[14], out double wtrtemp))
                    {
                        wave.WaterTemp = wtrtemp;
                    }
                    else
                    {
                        Console.WriteLine("Unable to extract WVHT value.");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching or parsing data: {ex.Message}");
            }
            return wave;
        }

    }
}
