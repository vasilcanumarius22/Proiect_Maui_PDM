using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;
using SQLite;

namespace MAUI_PROJECT_PDM.Models
{
    [SQLite.Table("foods")]
    public class Food
    {
        [PrimaryKey, AutoIncrement]
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public string UserEmail { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("description")]
        public string Description {get; set;}

        [JsonPropertyName("calories")]
        public float Calories { get; set; }

        [JsonPropertyName("urlImage")]
        public string UrlImage { get; set; }

        [JsonIgnore]
        public DateTime Date { get; set; }

    }
}
