using API.OpenPDV.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API.OpenPDV.Data
{
    public class OpenPDVContext
    {
        private readonly IMongoDatabase _database;

        public OpenPDVContext(IOptions<OpenPDVDatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");

        public IMongoCollection<SaleItem> SaleItems => _database.GetCollection<SaleItem>("SaleItems");

        public IMongoCollection<Sale> Sales => _database.GetCollection<Sale>("Sales");

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");

        public IMongoCollection<CashRegister> CashRegisters => _database.GetCollection<CashRegister>("CashRegisters");

        public IMongoCollection<CashRegisterClosing> CashRegisterClosings => _database.GetCollection<CashRegisterClosing>("CashRegisterClosings");
    }

    public class OpenPDVDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
