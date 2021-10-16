namespace ProduitMicroServices.Models
{
    public class ProduitStockDatabaseSettings : IProduitStockDatabaseSettings
    {
        public string ProduitsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IProduitStockDatabaseSettings
    {
        string ProduitsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}