using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LearnTutorial.Models
{
    //These are for the SQLite table that gets inputted from the Observation Page. The filepath is made on Maui.Program.Cs. The Methods to intereact with data base are located in the Observation Repository
    [Table ("observations")]
    public class Observation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public double Visibility { get; set; }
        public double? LeopardSharkDepth { get; set; }
        public double? GuitarFishDepth { get; set; }
        public double? SpinyLobsterDepth {  get; set; }
        public double? GaribaldiDepth {  get; set; }
    }
}
