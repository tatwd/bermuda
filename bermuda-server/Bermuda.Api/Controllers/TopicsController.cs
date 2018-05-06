using Bermuda.Api.DataCache;
using Bermuda.Bll.Service;
using Bermuda.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Caching;
using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    public class TopicsController : ApiController
    {
        IBmdTopicService iservice = ServiceFactory.Get<IBmdTopicService>();
        Cache cache = new Cache();

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var topics = CacheEngine.GetData<IList<BmdTopic>>("topics_all", () =>
                iservice.Select(x => x.IsPassed == 1).ToList());
            return Json(topics);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            string KEY = $"topic_{id}";

            if (cache[KEY] == null)
            {
                var topics = iservice.Select(x => x.IsPassed == 1 && x.Id == id).SingleOrDefault();

                if (topics == null)
                    return Json(topics);

                cache.Insert(KEY, topics);
            }
            return Json(cache.Get(KEY));
        }

        // GET api/<controller>/hot
        public IList<BmdTopic> Get(string type)
        {
            if (type.Equals("hot"))
            {
                if (cache["topics_hot"] == null)
                {
                    var topics = iservice
                        .Select(x => x.IsPassed == 1)
                        .OrderByDescending(x => x.JoinCount)
                        .ToList();
                    cache.Insert("topics_hot", topics);
                    return topics;
                }
                return cache.Get("topics_hot") as IList<BmdTopic>;
            }
            return null;
        }

        // GET api/<controller>/{type}/{count}
        [HttpGet]
        [Route("api/topics/{type}/{top}")]
        public IList<BmdTopic> Get(string type, int top = 10)
        {
            const string KEY = "topics_hot_top";

            if (type.Equals("hot"))
            {
                if (cache[KEY] == null)
                {
                    var topics = iservice
                        .Select(x => x.IsPassed == 1)
                        .OrderByDescending(x => x.JoinCount)
                        .Take(top)
                        .ToList();

                    cache.Insert(KEY, topics);
                    return topics;
                }
                return cache.Get(KEY) as IList<BmdTopic>;
            }

            return null;
        }

        // POST api/<controller>
        public void Post([FromBody]BmdTopic newTopic)
        {
            var obj = newTopic;
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
