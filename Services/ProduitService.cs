using ProduitMicroServices.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ProduitMicroServices.Services
{
    public class ProduitService
    {
        private readonly IMongoCollection<Produit> _produits;

        public ProduitService(IProduitStockDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _produits = database.GetCollection<Produit>(settings.ProduitsCollectionName);
        }

        public List<Produit> Get() =>
            _produits.Find(produit => true).ToList();

        public Produit Get(string id) =>
            _produits.Find<Produit>(produit => produit.Id == id).FirstOrDefault();

        public Produit Create(Produit produit)
        {
            _produits.InsertOne(produit);
            return produit;
        }

        public void Update(string id, Produit produitIn) =>
            _produits.ReplaceOne(produit => produit.Id == id, produitIn);

        public void Delete(Produit produitIn) =>
            _produits.DeleteOne(produit => produit.Id == produitIn.Id);

        public void Delete(string id) => 
            _produits.DeleteOne(produit => produit.Id == id);
    }
}