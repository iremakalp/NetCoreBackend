using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        // dependency injection : uygulamanın calisacagi ve bagimli oldugu akislari
        // disaridan enjekte ederek uygulama akisini dinamik olarak degistirebilir

        //EfProductDal efProductDal= new EfProductDal(); --> tam baglilik
        IProductDal _productDal; // gevsek baglilik
       
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        // Cross Cutting Concerns
        // AOP--> 
        [ValidationAspect(typeof(ProductValidator),Priority = 1)]
        public IResult Add(Product product)
        {
                
            _productDal.Add(product);
            return new SuccessResult(Messages.productAdded);
        }
        public IDataResult<List<Product>> GetAll()
        {
            var result = _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(result);
        }
        [CacheAspect(duration:1)]
        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId);
            return new SuccessDataResult<List<Product>>(result);
        }

        public IDataResult<List<Product>> GetProductByStock(decimal min, decimal max)
        {
            var result = _productDal.GetAll(p => p.Stock >= min && p.Stock <= max);
            return new SuccessDataResult<List<Product>>(result);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            var result = _productDal.GetProductDetails();
            return new SuccessDataResult<List<ProductDetailDto>>(result);
        }
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            _productDal.Update(product);
            //_productDal.Add(product);
            return new SuccessResult(Messages.productAdded);
        }
           
    }
}
