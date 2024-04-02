namespace NOAA
{
    // All the code in this file is included in all platforms.
    public class WaveHeightStation46254
    {
        public async Task<double> GetWaveHeight()
        {
            string dataUrl = "https://www.ndbc.noaa.gov/data/realtime2/46254.txt";
            double waveheight = 0;
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
                        waveheight=wvht;
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
            return waveheight;
        }

    }
}
