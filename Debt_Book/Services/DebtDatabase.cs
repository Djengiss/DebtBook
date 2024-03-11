using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debt_Book.Models;


// Responsible for interacting with the SQLite database.
// Provides methods for adding, retrieving, and manipulating debtor and debt data in the database.
namespace Debt_Book.Services
{
    internal class DebtDatabase
    {
        private readonly SQLiteAsyncConnection _connection;

        public DebtDatabase()
        {
            var dataDir = FileSystem.AppDataDirectory;
            var databasePath = Path.Combine(dataDir, "DebtData.db");

            string _dbEncryptionKey = SecureStorage.GetAsync("dbKey").Result;

            if (string.IsNullOrEmpty(_dbEncryptionKey))
            {
                Guid g = new Guid();
                _dbEncryptionKey = g.ToString();
                SecureStorage.SetAsync("dbKey", _dbEncryptionKey);
            }

            var dbOptions = new SQLiteConnectionString(databasePath, true, key: _dbEncryptionKey);

            _connection = new SQLiteAsyncConnection(dbOptions);

            _ = Initialize();
        }
        private async Task Initialize()
        {
            await _connection.CreateTableAsync<Debtor>();
            await _connection.CreateTableAsync<Debt>();
        }

        public async Task<List<Debtor>> GetDebtors()
        {
            return await _connection.Table<Debtor>().ToListAsync();
        }

        public async Task<Debt> GetDebt(int id)
        {
            var query = _connection.Table<Debt>().Where(t => t.DebtorId == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Debtor> GetDebtorId(string name)
        {
            var query = _connection.Table<Debtor>().Where(t => t.Name == name);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> AddDebt(Debt item)
        {
            return await _connection.InsertAsync(item);
        }

        public async Task<int> DeleteDebt(Debt item)
        {
            return await _connection.DeleteAsync(item);
        }

        public async Task<int> UpdateDebt(Debt item)
        {
            return await _connection.UpdateAsync(item);
        }
    }
}
