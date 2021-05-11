using System;
using System.ComponentModel.DataAnnotations;

namespace billboard_server.Models
{
    public class SongHit
    {
        [Required]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public int Rank { get; set; }
        public int? LastWeekRank { get; set; }
        public int PeakRank { get; set; }
        public int WeeksOnBoard { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
    }
}