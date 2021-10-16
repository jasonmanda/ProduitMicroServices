using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProduitMicroServices.Models;
using System.Text.Json;
using ProduitMicroServices.Services;

namespace ProduitMicroServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProduitController : ControllerBase
    {
        private readonly ILogger<ProduitController> _logger;
        private readonly ProduitService _produitService;

        public ProduitController(ILogger<ProduitController> logger,ProduitService produitService)
        {
            _logger = logger;
            _produitService = produitService;
        }
        [HttpPost]
        public JsonResult Create(Produit produit)
        {
         _produitService.Create(produit);
            _logger.LogInformation("{0}", JsonSerializer.Serialize(produit));
            return new JsonResult(produit);
        }
        [HttpPut("{id:int}")]
        public JsonResult Edit(string id, Produit produit)
        {

            _logger.LogInformation("{0}", id);
            _logger.LogInformation("{0}", JsonSerializer.Serialize(produit));
            return new JsonResult(produit);
        }
        [HttpDelete("{id:int}")]
        public JsonResult Delete(string id)
        {

            _logger.LogInformation("{0}", id);
            return new JsonResult(id);
        }
        [HttpGet]
        public IEnumerable<Produit> Get()
        =>
            _produitService.Get();
        
    }
}
