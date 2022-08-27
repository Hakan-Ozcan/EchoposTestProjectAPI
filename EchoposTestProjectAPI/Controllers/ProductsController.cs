using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EchoposTestProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productManager;

        public ProductsController(IProductService productManager)
        {
            _productManager = productManager;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _productManager.GetList().ToList();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            if (id < 1)
                return BadRequest();

            if (_productManager.GetList().Where(a => a.Id == id).Count() == 0)
                return NotFound();
            else

                try
                {
                    return _productManager.GetByID(id);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Product product)
        {
            return _productManager.Add(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id ,Product product)
        {
            return _productManager.Update(product);
        }
    
        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _productManager.Delete(id);
        }
    }
}

