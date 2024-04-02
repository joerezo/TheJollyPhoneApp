using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using LearnTutorial.Models;


namespace LearnTutorial
{
    public class ObservationRepository
    {
        string _dbPath;
        public string StatusMessage {  get; set; }
        SQLiteAsyncConnection conn;

        private async Task Init()
        {
            if (conn != null) { return; }

            conn=new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<Observation>();
        }

        public ObservationRepository(string dbPath)
        {
            _dbPath = dbPath;
        }
        public async Task AddNewObservation(DateTime date, TimeSpan time, double visibility, double LeopardSharkDepth = -1, double GuitarFishDepth = -1, double SpinyLobsterDepth = -1, double GaribaldiDepth = -1)
        {
            int result = 0;
            try
            {
                await Init();
                if (string.IsNullOrEmpty(visibility.ToString()))
                {
                    throw new Exception("Must enter valid visibility to enter observation");
                }

                result = await conn.InsertAsync(new Observation {
                    Date = date,
                    Time = time,
                    Visibility = visibility,
                    GaribaldiDepth = GaribaldiDepth,
                    GuitarFishDepth = GuitarFishDepth,
                    LeopardSharkDepth = LeopardSharkDepth,
                    SpinyLobsterDepth = SpinyLobsterDepth });
                StatusMessage = $"{result} record(s) added";
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Failed to add observation from {date} {time}. Error: {ex.Message}");
            }
        }
        public async Task<string> GetAllObservations()
        {
            try
            {
                await Init();
                var allObservations= await conn.Table<Observation>().ToListAsync();
                var result=allObservations.Select(obs => ($"ID: {obs.Id}\nDate: {obs.Date.Date.ToString("MM/dd/yyyy")}, Time: {obs.Time.ToString(@"hh\:mm")}, Visibility (ft): {obs.Visibility}\n" +
                $"\tDepth\n\tLeopard Shark: {obs.LeopardSharkDepth} ft, Guitar Fish: {obs.GuitarFishDepth} ft, Garibaldi Depth: {obs.GaribaldiDepth} ft, Spiny Lobster: {obs.SpinyLobsterDepth} ft"));
            
                return string.Join(Environment.NewLine, result );
            }
            catch (Exception ex)
            {
                return string.Format($"Failed to retrieve data. Error: {ex.Message}");
            }
            
        }
        public async Task<Observation> GetByID(int id)
        {
            return await conn.Table<Observation>().Where(x=>x.Id==id).FirstOrDefaultAsync(obs => obs.Id == id);
        }
        public async Task Update(Observation observation)
        {
            await conn.UpdateAsync(observation);
        }
        public async Task Delete(Observation observation)
        {
            await conn.DeleteAsync(observation);
        }

        public async Task<string> GetLeopardSharkSightings()
        {
            string Message = "";

            try
            {
                await Init();

                List<Observation> ObservationsList = await conn.Table<Observation>().ToListAsync();

                var filteredList = ObservationsList.Where(o => o.LeopardSharkDepth.HasValue && o.LeopardSharkDepth > 0);

                var sortedList = filteredList.OrderByDescending(obs => obs.Date).ThenByDescending(obs => obs.Time);

                var result = sortedList.Take(5).Select(obs => ($"Date: {obs.Date.Date.ToString("MM/dd/yyyy")}, Time: {obs.Time.ToString(@"hh\:mm")}, Depth (ft): {obs.LeopardSharkDepth}"));


                return Message=string.Join(Environment.NewLine,result);
            }
            catch(Exception ex)
            {
                return Message=$"Failed to retrievedata. Error: {ex.Message}";
            }
        }
        public async Task<string> GetGuitarFishSightings()
        {
            string Message = "";

            try
            {
                await Init();

                List<Observation> ObservationsList = await conn.Table<Observation>().ToListAsync();

                var filteredList = ObservationsList.Where(o => o.GuitarFishDepth.HasValue && o.GuitarFishDepth > 0);

                var sortedList = filteredList.OrderByDescending(obs => obs.Date).ThenByDescending(obs => obs.Time);

                var result = sortedList.Take(5).Select(obs => ($"Date: {obs.Date.Date.ToString("MM/dd/yyyy")}, Time: {obs.Time.ToString(@"hh\:mm")}, Depth (ft): {obs.GuitarFishDepth}"));

                return Message = string.Join(Environment.NewLine, result);
            }
            catch (Exception ex)
            {
                return Message = $"Failed to retrievedata. Error: {ex.Message}";
            }
        }
        public async Task<string> GetGaribaldiSightings()
        {
            string Message = "";

            try
            {
                await Init();

                List<Observation> ObservationsList = await conn.Table<Observation>().ToListAsync();

                var filteredList = ObservationsList.Where(o => o.GaribaldiDepth.HasValue && o.GaribaldiDepth > 0);

                var sortedList = filteredList.OrderByDescending(obs => obs.Date).ThenByDescending(obs => obs.Time);

                var result = sortedList.Take(5).Select(obs => ($"Date: {obs.Date.Date.ToString("MM/dd/yyyy")}, Time: {obs.Time.ToString(@"hh\:mm")}, Depth (ft): {obs.GaribaldiDepth}"));

                return Message = string.Join(Environment.NewLine, result);
            }
            catch (Exception ex)
            {
                return Message = $"Failed to retrievedata. Error: {ex.Message}";
            }
        }
        public async Task<string> GetSpinyLobsterSightings()
        {
            string Message = "";

            try
            {
                await Init();

                List<Observation> ObservationsList = await conn.Table<Observation>().ToListAsync();

                var filteredList = ObservationsList.Where(o => o.SpinyLobsterDepth.HasValue && o.SpinyLobsterDepth > 0);

                var sortedList = filteredList.OrderByDescending(obs => obs.Date).ThenByDescending(obs => obs.Time);

                var result = sortedList.Take(5).Select(obs => ($"Date: {obs.Date.Date.ToString("MM/dd/yyyy")}, Time: {obs.Time.ToString(@"hh\:mm")}, Depth (ft): {obs.SpinyLobsterDepth}"));

                return Message = string.Join(Environment.NewLine, result);
            }
            catch (Exception ex)
            {
                return Message = $"Failed to retrievedata. Error: {ex.Message}";
            }
        }
    }
}
