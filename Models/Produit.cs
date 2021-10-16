using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProduitMicroServices.Models
{
    public class Produit
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Libelle")]
        public string Libelle { get; set; }
        [BsonElement("Quantite")]

        public int Quantite { get; set; }
        [BsonElement("Prix")]

        public float Prix { get; set; }
        [BsonElement("Etat")]
        public bool Etat { get; set; } = false;
    }
}
