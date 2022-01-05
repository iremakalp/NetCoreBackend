using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // sadece product tablosunu ilgilendiren islemlerin kodlari yazilir 
    // IProductDal deme sebebi sadece product icin gecerli islemleri implemente etmek
    public class EfProductDal: EfEntityRepositoryBase<Product, ManagerContext>, IProductDal
    {

    }
}
