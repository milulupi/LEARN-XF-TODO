using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LEARNXFTODO.Data
{
    public class TodoItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TodoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Model.TodoItem>().Wait();
        }

        public Task<List<Model.TodoItem>> GetItemsAsync()
        {
            return database.Table<Model.TodoItem>().ToListAsync();
        }

        public Task<Model.TodoItem> GetItemAsync(int id)
        {
            return database.Table<Model.TodoItem>().Where
                           (i => i.ID == id).FirstOrDefaultAsync();
            
        }

        public Task<List<Model.TodoItem>> GetItemsNotDoneAsync()
        {
            return database.Table<Model.TodoItem>().Where
                           (ii => ii.Done == false).ToListAsync();
            //return database.QueryAsync<Model.TodoItem>("SELECT * FROM [TodoItem] Where [Done] = 0");

        }

        public Task<int> SaveItemAsync(Model.TodoItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }else
            {
                return database.InsertAsync(item);
            }
             
        }

        public Task<int>DeleteItemAsync(Model.TodoItem item){

            return database.DeleteAsync(item);
        }
    }
}
