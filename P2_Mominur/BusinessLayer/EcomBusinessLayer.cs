using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;
using RepositoryAccessLayer;

namespace BusinessLayer
{
    public class EcomBusinessLayer
    {
        
        private readonly EcomRepoLayer _repoLayer;
        public EcomBusinessLayer()
        {
            this._repoLayer = new EcomRepoLayer();

        }

        public async Task<List<Products>> ProductsAsync(int type)
        {
            List<Products> productlist = await this._repoLayer.ProductsAsync(type);
            return productlist;
        }

           public async Task<Login> LoginAsync(Login login)
        {
            Login loginTask = await this._repoLayer.LoginAsync(login);
            return loginTask;
        }

         public async Task<Products>AddProductAsync(Products product)
        {
            Products AddProduct = await this._repoLayer.AddProductAsync(product);
            return AddProduct;
        }


    }
    
}