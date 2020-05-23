using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OmniMasterFX.Application.Products.Commands;
using OmniMasterFX.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OmniMasterFX.WebUI.Controllers
{
    public class ProductsController : ApiController
    {
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<int>> GetIndex()
        {
            var t = HttpContext.User.Identity;
            return -1;
        }

        // POST: /api/products/
        [HttpPost]
        public async Task<ActionResult<Product>> Index(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
