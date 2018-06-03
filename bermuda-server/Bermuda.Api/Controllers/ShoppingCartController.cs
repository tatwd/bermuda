using Bermuda.Api.DataCache;
using Bermuda.Api.Models;
using Bermuda.Bll.Service;
using Bermuda.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    [RoutePrefix("api/cart")]
    public class ShoppingCartController : ApiController
    {
        IBmdShoppingCartService iservice = ServiceFactory.Get<IBmdShoppingCartService>();

        [Authorize]
        [Route("{uid}")]
        public IHttpActionResult Get(Int64 uid)
        {
            var vm = CacheEngine.GetData<IList<ShoppingCartViewModel>>($"cart_#{uid}", () =>
            {
                var _vm = new List<ShoppingCartViewModel>();
                var cartItems = iservice
                    .Select(x => x.UserId == uid)
                    .ToList();
                var productService = ServiceFactory.Get<IBmdProductService>();

                foreach (var item in cartItems)
                {
                    var product = productService.Select(x => x.Id == item.ProductId).SingleOrDefault();
                    var _cartItem = BaseUtil.DeepParseTo<ShoppingCartViewModel, ProductViewModel>(item, product);
                    _vm.Add(_cartItem);
                }

                return _vm;
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
