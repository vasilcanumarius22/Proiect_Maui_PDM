using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SQLite;

namespace MAUI_PROJECT_PDM.Models
{
    [SQLite.Table("foods")]
    public class Food
    {
        [PrimaryKey, AutoIncrement]
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        private string title;

        [JsonPropertyName("type")]
        private string type;

        [JsonPropertyName("description")]
        private string description;

        [JsonPropertyName("calories")]
        private float calories;

        [JsonPropertyName("urlImage")]
        private string urlImage;

        public Food(string title, string type, string description, float calories, string urlImage)
        {
            this.title = title;
            this.type = type;
            this.description = description;
            this.calories = calories;
            this.urlImage = urlImage;
        }

        public string Title { get { return title; } set { title = value; } }
        public string Type { get { return type; } set { type = value; } }
        public string Description { get { return description; }
            set
            {
                description = value;
            } }
        public float Calories { get {  return calories; } set {  calories = value; } }
        public string UrlImage { get {  return urlImage; }  }
    }
}
