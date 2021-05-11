using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;

namespace billboard_server.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            DateTime toDate(string s)
            {
                try
                {
                    return DateTime.ParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return DateTime.Today;
                }
            }

            int toInt(string s)
            {
                return string.IsNullOrWhiteSpace(s) ? 0 : int.Parse(s);
            }
            
            var hits = Read<dynamic>("./seeds/charts.json")
                .Where(a => a.date > "2016-12-31")
                .Select(a => new object[]
                {
                    Guid.NewGuid().ToString("N"),
                    toDate(a.date),
                    toInt(a.rank),
                    a.song.ToString(),
                    a.artist.ToString(),
                    toInt(a["last-week"]),
                    toInt(a["peak-rank"]),
                    toInt(a["weeks-on-board"])
                })
                .ToArray();

            foreach (var item in hits)
            {
                migrationBuilder.InsertData("SongHits", new[]{"Id", "Date", "Rank", "Title", "Artist", "LastWeekRank", "PeakRank", "WeeksOnBoard"}, item);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
        
        private IList<T> Read<T>(string fileName)
        {
            using var reader = new StreamReader(fileName);
            return JsonConvert.DeserializeObject<IList<T>>(reader.ReadToEnd());
        }
    }
}
