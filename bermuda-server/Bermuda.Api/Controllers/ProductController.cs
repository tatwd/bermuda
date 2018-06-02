using Bermuda.Api.DataCache;
using Bermuda.Api.Models;
using Bermuda.Bll.Service;
using Bermuda.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        IBmdProductService iservice = ServiceFactory.Get<IBmdProductService>();

        [Route()]
        public IHttpActionResult Get()
        {
            var vm = CacheEngine.GetData<IList<ProductViewModel>>("products_all", () =>
            {
                var _vm = new List<ProductViewModel>();
                var userService = ServiceFactory.Get<IBmdUserService>();
                var products = iservice
                    .Select(x => x.Qty > 0)
                    .OrderByDescending(x => x.CreatedAt)
                    .ToList();

                foreach (var product in products)
                {
                    var user = userService.GetUserById(product.UserId.Value);
                    var vmproduct = BaseUtil.DeepParseTo<ProductViewModel, UserViewModel>(product, user);
                    _vm.Add(vmproduct);
                }

                return _vm.Count <= 0 ? null : _vm;
            });

            return Json(vm);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var vm = CacheEngine.GetData<ProductViewModel>($"product_#{id}", () =>
            {
                var product = iservice
                    .Select(x => x.Id == id)
                    .SingleOrDefault();
                var user = product != null
                    ? ServiceFactory.Get<IBmdUserService>()
                        .GetUserById(product.UserId.Value)
                    : null;

                return BaseUtil.DeepParseTo<ProductViewModel, UserViewModel>(product, user);
            });

            return Json(vm);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
