using AutoMapper;
using BookStoreModel.Models;
using BookStoreServices;
using BookStoreWeb.Infrastructure.Core;
using BookStoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStoreWeb.Infrastructure.Extensions;

namespace BookStoreWeb.API
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : APIControllerBase
    {
        #region Initialize

        IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) :
            base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        #endregion

        [Route("getallparent")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetAll();

                var responseData = Mapper.Map<List<ProductCategoryViewModel>>(model);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request,int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetByID(id);

                var responseData = Mapper.Map<ProductCategoryViewModel>(model);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request,string keyword,int page,int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;

                var model = _productCategoryService.GetAll(keyword);

                totalRow = model.Count();

                var query = model.OrderByDescending(x=>x.CreateDate).Skip(page * pageSize).Take(pageSize);  

                var responseData = Mapper.Map<List<ProductCategoryViewModel>>(query);

                var pagination = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, pagination);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request,ProductCategoryViewModel productCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    ProductCategory newProductCategory = new ProductCategory();
                    newProductCategory.UpdateProductCategory(productCategoryViewModel);

                    newProductCategory.CreateDate = DateTime.Now;

                    _productCategoryService.Add(newProductCategory);
                    _productCategoryService.SaveChanges();

                    var responseData = Mapper.Map<ProductCategoryViewModel>(newProductCategory);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel productCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    ProductCategory dbProductCategory = _productCategoryService.GetByID(productCategoryViewModel.ID);
                    dbProductCategory.UpdateProductCategory(productCategoryViewModel);

                    dbProductCategory.UpdateDate = DateTime.Now;

                    _productCategoryService.Update(dbProductCategory);
                    _productCategoryService.SaveChanges();

                    var responseData = Mapper.Map<ProductCategoryViewModel>(dbProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
    }
}