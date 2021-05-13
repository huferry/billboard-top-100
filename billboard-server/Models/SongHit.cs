using System;
using System.ComponentModel.DataAnnotations;

namespace billboard_server.Models
{
    /// <summary>
    /// A song hit on the top 40 list.
    /// </summary>
    public class SongHit
    {
        /// <summary>
        /// The ID of the song hit
        /// </summary>
        [Required]
        public string Id { get; set; }
        
        /// <summary>
        /// The date of the list
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// The rank of the song
        /// </summary>
        public int Rank { get; set; }
        
        /// <summary>
        /// The rank of the song in the last week list
        /// </summary>
        public int? LastWeekRank { get; set; }
        
        /// <summary>
        /// The highest rank of the song
        /// </summary>
        public int PeakRank { get; set; }
        
        /// <summary>
        /// The number of weeks the song listed on the board
        /// </summary>
        public int WeeksOnBoard { get; set; }
        
        /// <summary>
        /// The title of the song
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// The name of the performing artist
        /// </summary>
        public string Artist { get; set; }
    }
}