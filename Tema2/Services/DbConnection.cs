//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Tema2.Models;
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tema2.Services;
public class DbConnection
{
    SQLiteAsyncConnection Database;
    public const SQLite.SQLiteOpenFlags Flags =
    // open the database in read/write mode
    SQLite.SQLiteOpenFlags.ReadWrite |
    // create the database if there isn't any
    SQLite.SQLiteOpenFlags.Create |
    // enable multi-threaded database access
    SQLite.SQLiteOpenFlags.SharedCache;

    public DbConnection() { }

    async Task Init()
    {
        if (Database is not null)
            return;

        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MonkeyDb.db");
        try
        {
            Database = new SQLiteAsyncConnection(databasePath, Flags);
        }
        catch (Exception ex)
        {
        }
        await Database.CreateTableAsync<TaskToDo>();
    }

    public async Task<List<TaskToDo>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<TaskToDo>().ToListAsync();
    }

    public async Task<TaskToDo> getItemAsync(int id)
    {
        await Init();
        return await Database.Table<TaskToDo>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(TaskToDo item)
    {
        await Init();
        return await Database.InsertAsync(item);
    }

    public async Task<int> UpdateItemAsync(TaskToDo item)
    {
        await Init();
        return await Database.UpdateAsync(item);
    }

    public async Task<int> SaveAllItemAsync(List<TaskToDo> items)
    {
        await Init();
        return await Database.InsertAllAsync(items);
    }

    public async Task<int> DeleteItemAsync(TaskToDo item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }

    public async Task<int> DeleteAllAsync()
    {
        await Init();
        return await Database.DeleteAllAsync<TaskToDo>();
    }
}

