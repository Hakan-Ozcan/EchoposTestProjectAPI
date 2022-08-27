using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : GenericManager<Product>,IProductService
    {
        private readonly IProductDal _productRepository;

        public ProductManager(IProductDal productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }
        public Product GetByID(int id)
        {
            return _productRepository.Get(i => i.Id == id);
        }

        public bool Delete(int id)
        {
            return _productRepository.Delete(i=>i.Id == id);
        }
    }
}
