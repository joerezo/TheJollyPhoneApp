using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LearnTutorial.Models
{
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
