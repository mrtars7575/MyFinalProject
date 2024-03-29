﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle ,Sql Server,MongoDb 
            _products = new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    CategoryId = 1,
                    ProductName = "Bardak",
                    UnitPrice = 15,
                    UnitsInStock = 15
                },
                new Product
                {
                    ProductId = 2,
                    CategoryId = 1,
                    ProductName = "Kamera",
                    UnitPrice = 500,
                    UnitsInStock = 3
                },
                new Product
                {
                    ProductId = 3,
                    CategoryId = 2,
                    ProductName = "Telefon",
                    UnitPrice = 1500,
                    UnitsInStock = 2
                },
                new Product
                {
                    ProductId = 4,
                    CategoryId = 2,
                    ProductName = "Bilgisayar",
                    UnitPrice = 150,
                    UnitsInStock = 65
                },
                new Product
                {
                    ProductId = 5,
                    CategoryId = 2,
                    ProductName = "Klavye",
                    UnitPrice = 85,
                    UnitsInStock = 1
                }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Ürünleri silmez
            //_products.Remove(product);

            //Referansa ulaşmaya çalışıyoruz
            //Product productToDelete = null;
            //foreach (var item in _products)
            //{
            //    if (product.ProductId == item.ProductId)
            //    {
            //        productToDelete = item;
            //    }
            //}
            //_products.Remove(productToDelete);

            //LINQ
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetrAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gömderdiğimiz ürün ıd sini sahip ürünü  bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
