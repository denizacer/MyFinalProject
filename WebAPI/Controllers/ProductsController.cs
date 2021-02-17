using Business.Abstract;
using Business.Concrete;
using DataAcces.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//attribute
    public class ProductsController : ControllerBase//inherit. olmalo cont olmasıı için
    {
        //loosely coupled- soyuta bağımlılık
        //IoC Container--inversion of control
        IProductService _productService;
        //ıproductservice injection 

        public ProductsController(IProductService productService)//(()manager ver demek
        {
            _productService = productService;
        }
        //const. erişim olmaz.
        [HttpGet("getall")]
        public IActionResult Get()
        {
            
                //IProductService productService=new ProductManager(new EfProductDal());
                
                 var result = _productService.GetAll(); 
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id) 
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("add")]//data ekleme
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

       
    }
}
