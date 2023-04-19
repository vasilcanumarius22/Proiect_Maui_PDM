using MAUI_PROJECT_PDM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_PROJECT_PDM
{
    public class MockFoods
    {
        static public List<Food> foods = new List<Food> {
            new Food("Japanese Gyozas","vegetarian", "descriere Japanese Gyozas",
                650, "https://my-omnifood-project.netlify.app/img/meals/meal-1.jpg"),
            new Food("Avocado Salad","vegan", "descriere Avocado Salad",
                400, "https://my-omnifood-project.netlify.app/img/meals/meal-2.jpg"),
            new Food("Garlic chicken breast","meat-based", "descriere Garlic chicken breast",
                550, "https://images.immediate.co.uk/production/volatile/sites/30/2013/05/Garlic_chicken-3f62fd9.jpg")
    };
            


        
    }
}
