using Bermuda.Api.Models;
using Bermuda.Bll.Service;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Caching;
using System.Web.Http;
using System.Web.Http.Results;

namespace Bermuda.Api.Controllers
{
    public class HomeController : ApiController
    {
        IBmdTopicService iservice = ServiceFactory.Get<IBmdTopicService>();
        Cache cache = new Cache();

        const string HOST_URL = "http://localhost:53595";

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            if (cache["home"] == null)
            {
                HomeViewModel vm = new HomeViewModel();
                Hashtable mapHome = new Hashtable();

                var _hotTopics = iservice
                    .Select(x => x.IsPassed == 1)
                    .OrderByDescending(x => x.JoinCount)
                    .Take(10)
                    .ToList();

                vm.HotTopics = new List<HotTopicsViewModel>();
                foreach (var item in _hotTopics)
                {
                    HotTopicsViewModel hotTopicVm = new HotTopicsViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Img = HOST_URL + item.ImgUrl
                    };
                    vm.HotTopics.Add(hotTopicVm);
                }

                mapHome.Add("home_hot_topics", vm.HotTopics);
                cache["home"] = mapHome;
            }

            return Json(cache["home"]);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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
