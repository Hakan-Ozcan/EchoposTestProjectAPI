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
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IRepositoryDal<T> _genericRepository;

        public GenericManager(IRepositoryDal<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public bool Add(T product)
        {
            return _genericRepository.Insert(product);
        }

        public IEnumerable<T> GetList()
        {
            return _genericRepository.List();
        }

        public bool Update(T t)
        {
            return _genericRepository.Update(t);
        }
    }
}
