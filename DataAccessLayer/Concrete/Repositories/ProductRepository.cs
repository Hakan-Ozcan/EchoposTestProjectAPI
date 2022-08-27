using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class ProductRepository:GenericRepository<Product>,IProductDal   
    {
        private readonly Context _context;

        public ProductRepository(Context context):base(context)
        {
            _context = context;
        }
    }
}
