using Bermuda.Api.DataCache;
using Bermuda.Api.Models;
using Bermuda.Bll.Service;
using Bermuda.Common;
using Bermuda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    [RoutePrefix("api/topics")]
    public class TopicController : ApiController
    {
        IBmdTopicService iservice = ServiceFactory.Get<IBmdTopicService>();

        [Route()]
        public IHttpActionResult Get()
        {
            var vm = CacheEngine.GetData<IList<TopicViewModel>>("topics_all", () =>
            {
                var topics = iservice
                    .Select(x => x.IsPassed == 1)
                    .ToList();
                return BaseUtil.ParseToList<TopicViewModel>(topics);
            });

            return Json(vm);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var vm = CacheEngine.GetData<TopicViewModel>($"topic_#{id}", () =>
            {
                var topic = iservice
                    .Select(x => x.Id == id)
                    .SingleOrDefault();
                return BaseUtil.ParseTo<TopicViewModel>(topic);
            });

            return Json(vm);
        }

        [Route("{type}/{count}")]
        public IHttpActionResult Get(string type, int count = 10)
        {
            var vm = CacheEngine.GetData<IList<TopicViewModel>>($"topics_{type}_{count}", () =>
            {
                IList<BmdTopic> topics = new List<BmdTopic>();

                if (type.Equals("top", StringComparison.OrdinalIgnoreCase))
                {
                    topics = iservice.GetHotTopics(count);
                }
                else if (type.Equals("all", StringComparison.OrdinalIgnoreCase))
                {
                    topics = iservice.Select(x => x.IsPassed == 1).ToList();
                }

                return BaseUtil.ParseToList<TopicViewModel>(topics);
            });

            return Json(vm);
        }

        [Authorize]
        [Route("create")]
        public IHttpActionResult Post([FromBody]NewTopicViewModel newTopic)
        {
            var isOk = iservice.Insert(new BmdTopic
            {
                UserId = newTopic.user_id,
                Name = newTopic.name,
                Detail = newTopic.detail,
                ImgUrl = newTopic.img_url
            });

            return Json(isOk);
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
