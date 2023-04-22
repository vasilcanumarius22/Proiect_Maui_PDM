using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MAUI_PROJECT_PDM.Models
{
    class DaoFood
    {
        SQLiteAsyncConnection conn;

        public async Task InitializeDatabase()
        {
            if (conn == null)
            {
                string connString = Path.Combine(FileSystem.AppDataDirectory, "omnifood.db");
                conn = new SQLiteAsyncConnection(connString, false);
                await conn.CreateTableAsync<Food>();
            }
        }

        public async Task<int> Insert(Food food, User user)
        {
            await InitializeDatabase();
            food.UserEmail = user.Email;
            food.Date = DateTime.Now;
            return await conn.InsertAsync(food);
        }


        public async Task<List<Food>> GetAll()
        {
            await InitializeDatabase();
            return await conn.Table<Food>().ToListAsync();
        }

        public async Task<List<Food>> GetAllByDateAndUser(DateTime filterDate, User user)
        {
            await InitializeDatabase();
            return await conn.QueryAsync<Food>("SELECT * FROM foods WHERE date(Date) = ? and UserEmail= ?", filterDate.ToString("yyyy-MM-dd"), user.Email);
        }

        public async Task<int> Remove(Food food)
        {
            await InitializeDatabase();
            return await conn.DeleteAsync(food);
        }

    }
}
