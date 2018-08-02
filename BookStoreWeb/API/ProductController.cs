using AutoMapper;
using BookStoreModel.Models;
using BookStoreServices;
using BookStoreWeb.Infrastructure.Core;
using BookStoreWeb.Infrastructure.Extensions;
using BookStoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace BookStoreWeb.API
{
    [RoutePrefix("api/product")]
    public class ProductController : APIControllerBase
    {
        #region Initialize

        IProductService _productService;

        public ProductController(IErrorService errorService, IProductService productService) :
            base(errorService)
        {
            this._productService = productService;
        }

        #endregion

        [Route("getallparent")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productService.GetAll();

                var responseData = Mapper.Map<List<ProductViewModel>>(model);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productService.GetByID(id);

                var responseData = Mapper.Map<ProductViewModel>(model);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
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
                    _productService.Delete(id);
                    _productService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;

                var model = _productService.GetAll(keyword);

                totalRow = model.Count();

                var query = model.OrderByDescending(x => x.CreateDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<List<ProductViewModel>>(query);

                var pagination = new PaginationSet<ProductViewModel>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel productViewModel)
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
                    Product newProduct = new Product();
                    newProduct.UpdateProduct(productViewModel);

                    newProduct.CreateDate = DateTime.Now;

                    _productService.Add(newProduct);
                    _productService.SaveChanges();

                    var responseData = Mapper.Map<ProductViewModel>(newProduct);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel productViewModel)
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
                    Product dbProduct = _productService.GetByID(productViewModel.ID);
                    dbProduct.UpdateProduct(productViewModel);

                    dbProduct.UpdateDate = DateTime.Now;

                    _productService.Update(dbProduct);
                    _productService.SaveChanges();

                    var responseData = Mapper.Map<ProductViewModel>(dbProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProducts)
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
                    List<Product> dbListProduct = new List<Product>();

                    var ids = new JavaScriptSerializer().Deserialize<List<int>>(checkedProducts);

                    foreach (var id in ids)
                    {
                        _productService.Delete(id);
                    }

                    _productService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK, ids.Count);
                }

                return response;
            });
        }
    }
}