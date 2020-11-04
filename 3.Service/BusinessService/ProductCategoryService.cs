using _1.Core.Domain;
using _2.Data.Infrastructure.Interface;
using _2.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Service.BusinessService
{
    internal interface IProductCategoryService
    {
        void Add(ProductCategory productCategory);
        void Delete(ProductCategory productCategory);
        void Delete(int productCategoryID);
        void Update(ProductCategory productCategory);
        ProductCategory GetById(int productCategoryID);
        IEnumerable<ProductCategory> GetAll();
        IEnumerable<ProductCategory> GetAllPaging(int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public class ProductCategoryService:IProductCategoryService
    {
        private readonly IDbFactory _dbFactory;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IDbFactory dbFactory, IProductCategoryRepository productCategoryRepository)
        {
            this._dbFactory = dbFactory;
            this._productCategoryRepository = productCategoryRepository;
        }

        public void Add(ProductCategory productCategory)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductCategory productCategory)
        {
            throw new NotImplementedException();
        }

        public void Delete(int productCategoryID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetById(int productCategoryID)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductCategory productCategory)
        {
            throw new NotImplementedException();
        }
    }

    
}
