using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]  //istekte bulunurken bize nasıl ulaşsın
    [ApiController]  //attribute:bir class ile ilgili bilgi verme onu imzalama. Bu class bir controller kendini ona göre yapılandır
    public class ProductsController : ControllerBase
    {
        //bağımlılıktan kurtulmakiçin injection yaparız. burada gevşek bağlılık ver loosely coupled. bir bağlılık var ama soyuta bağlılık manager'ı değiştirirsek sorun olmaz
        IProductService _productService;

        //burada servisi tanımlayamıyor çünkü bir çok somut olabilir karşılığı. Bunun için Ioc kullanılır
        //inversion of control:bellekteki bir liste olarak düşün içene new productmanager,new efproductdal gibi referanslar koyalım
        //hangisine ihtiyaç duyulursa onu ona verin. webapı'nın kendi içinde bir ioc yapısı vardır.
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //dependency chain bağımlılık zinciri
            var result=_productService.GetAll();
            if (result.Success) //result'ın success durumu true ise
            {
                return Ok(result); //postmandeki 200ok. //result'ın data,message ve success durumu görüntülenir.istediğimizide görüntüleyebiliriz
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

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
