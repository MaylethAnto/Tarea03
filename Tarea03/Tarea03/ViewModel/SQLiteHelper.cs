using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tarea03.Model;

namespace Tarea03.ViewModel
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection _database;

        public SQLiteHelper(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Person>().Wait();
        }

        public Task<List<Person>> GetItemsAsync()
        {
            return _database.Table<Person>().ToListAsync();
        }

        public Task<Person> GetItemAsync(int id)
        {
            return _database.Table<Person>().FirstOrDefaultAsync(x => x.Id == id);
        }
        public Task<int> SaveItemAsync(Person person)
        {
            if (person.Id != 0)
            {
                return _database.UpdateAsync(person);
            }
            else
            {
                return _database.InsertAsync(person);
            }
        }

        public Task<int> DeleteItemAsync(Person person)
        {
            return _database.DeleteAsync(person);
        }
    }

}
