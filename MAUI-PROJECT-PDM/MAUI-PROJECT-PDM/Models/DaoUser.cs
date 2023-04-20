using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_PROJECT_PDM.Models
{
    class DaoUser
    {
        SQLiteAsyncConnection conn;

        public async Task InitializeDatabase()
        {
            if (conn == null)
            {
                string connString = Path.Combine(FileSystem.AppDataDirectory, "omnifood.db");
                conn = new SQLiteAsyncConnection(connString, false);
                await conn.CreateTableAsync<User>();
            }
        }

        public async Task<int> Insert(User user)
        {
            await InitializeDatabase();
            return await conn.InsertAsync(user);
        }

        public async Task<int> Update(User user)
        {
            await InitializeDatabase();
            return await conn.UpdateAsync(user);
        }

        public async Task<User> GetUserById(int id)
        {
            await InitializeDatabase();
            return await conn.GetAsync<User>(id);
        }

        public async Task<int> InsertAll(List<User> users)
        {
            await InitializeDatabase();
            return await conn.InsertAllAsync(users);
        }

        public async Task<List<User>> GetAll()
        {
            await InitializeDatabase();
            return await conn.Table<User>().ToListAsync();
        }

        public async Task<User> AuthenticateUser(string email, string password)
        {
            await InitializeDatabase();
            var users = await conn.Table<User>()
                .Where(u => u.Email == email && u.Password == password)
                .ToListAsync();
            return users.FirstOrDefault(); 
        }

    }
}
