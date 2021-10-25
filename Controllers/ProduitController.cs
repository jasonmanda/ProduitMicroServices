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

        public ProduitController(ILogger<ProduitController> logger, ProduitService produitService)
        {
            _logger = logger;
            _produitService = produitService;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Produit produit)
        {
            _produitService.Create(produit);
            // _logger.LogInformation("{0}", JsonSerializer.Serialize(produit));
            return new JsonResult(produit);
        }
        [HttpPut("{id:int}")]
        public IActionResult Put( [FromRoute]string id, [FromBody] Produit produit)
        {
            try
            {
                        _produitService.Update(id, produit);
            return new JsonResult(produit);
            }
            catch (Exception exp)
            {
                
                return new BadRequestObjectResult(new {ErrorMessage=exp.Message});
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete( [FromRoute]string id)
        {
                if(String.IsNullOrEmpty(id))return BadRequest(id);
                _produitService.Delete(id);
            return new JsonResult(new {Message="Suppression réussie"});
        }
        [HttpGet]
        public IEnumerable<Produit> Get()
        =>
            _produitService.Get();

    }
}
