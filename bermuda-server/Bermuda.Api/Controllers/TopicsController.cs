﻿using Bermuda.Api.DataCache;
using Bermuda.Api.Models;
using Bermuda.Bll.Service;
using Bermuda.Common;
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

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IList<BmdTopic> topics = new List<BmdTopic>();
            IList<TopicViewModel> vm = new List<TopicViewModel>();

            topics = CacheEngine.GetData<IList<BmdTopic>>("topics_all", () =>
                iservice.Select(x => x.IsPassed == 1)
                    .ToList());

            vm = BaseUtil.ParseToList<TopicViewModel>(topics);

            return Json(vm);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            string KEY = $"topic_{id}";
            BmdTopic topic = new BmdTopic();
            TopicViewModel vm = new TopicViewModel();

            topic = CacheEngine.GetData<BmdTopic>(KEY, () =>
                iservice.Select(x => x.Id == id)
                    .SingleOrDefault());

            vm = BaseUtil.ParseTo<TopicViewModel>(topic);

            return Json(vm);
        }

        // GET api/<controller>/hot
        public IHttpActionResult Get(string type)
        {
            IList<BmdTopic> topics = new List<BmdTopic>();
            IList<TopicViewModel> vm = new List<TopicViewModel>();

            if (type.Equals("top"))
            {
                topics = CacheEngine.GetData<IList<BmdTopic>>("topics_top_all", () =>
                    iservice.Select(x => x.IsPassed == 1)
                        .OrderByDescending(x => x.JoinCount)
                        .ToList());

                vm = BaseUtil.ParseToList<TopicViewModel>(topics);
            }

            return Json(vm);
        }

        // GET api/<controller>/{type}/{count}
        [HttpGet]
        [Route("api/topics/{type}/{count}")]
        public IHttpActionResult Get(string type, int count = 10)
        {
            const string KEY = "topics_hot_top";
            IList<TopicViewModel> vm = new List<TopicViewModel>();

            if (type.Equals("top"))
            {
                var topics = CacheEngine.GetData<IList<BmdTopic>>(KEY, () =>
                    iservice.Select(x => x.IsPassed == 1)
                        .OrderByDescending(x => x.JoinCount)
                        .Take(count)
                        .ToList());

                vm = BaseUtil.ParseToList<TopicViewModel>(topics);
            }

            return Json(vm);
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
