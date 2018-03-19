using System.Web.Mvc;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Bmd.Model;
using Bmd.App.Models;

namespace Bmd.App.Controllers
{
    public class HomeController : Controller
    {
        BmdEntities db = new BmdEntities();

        // GET: Home
        public ActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel();

            vm.HotTopicsVm = GetHotTipicVmList();
            vm.NoticeVm = GetNoticeVmList();
            vm.HotSpeciesVm = GetHotSpeciesVmList();
            vm.HotCurrentVm = GetHotCurrentVmList();
            vm.TopUserVm = GetTopUserVmList();

            return View(vm);
        }

        // 获取热门话题
        public IList<HotTopicViewModel> GetHotTipicVmList()
        {
            IList<HotTopicViewModel> vm = new List<HotTopicViewModel>();

            var topics = db.topic
                .OrderByDescending(t => t.JoinCount)
                .Take(10);

            foreach (var topic in topics)
            {
                vm.Add(new HotTopicViewModel
                {
                    Id = topic.Id,
                    Name = topic.Name,
                    Img = topic.Img
                });
            }

            return vm;
        }

        // 获取启示列表
        public IList<NoticeViewModel> GetNoticeVmList()
        {
            IList<NoticeViewModel> vm = new List<NoticeViewModel>();

            var _notices = db.notice.OrderByDescending(n => n.PublishDate).Take(5);

            foreach (var _notice in _notices)
            {
                var _user = db.bmdUser.Where(u => u.Id == _notice.UserId).FirstOrDefault();

                vm.Add(new NoticeViewModel
                {
                    bmdUser = _user,
                    notices = _notice
                });
            }

            return vm;
        }

        // 获取热门分类
        public IList<HotSpeciesViewModel> GetHotSpeciesVmList()
        {
            IList<HotSpeciesViewModel> vm = new List<HotSpeciesViewModel>();

            var hotSpecies = db.species
                .OrderByDescending(s => s.NoticeCount)
                .Take(10);    

            foreach (var species in hotSpecies)
            {
                vm.Add(new HotSpeciesViewModel
                {
                    Id = species.Id,
                    Name = species.Name,
                    Img = species.Img
                });
            }

            return vm;
        }

        // 获取热门动态
        public IList<HotCurrentViewModel> GetHotCurrentVmList()
        {
            IList<HotCurrentViewModel> vm = new List<HotCurrentViewModel>();

            var hotCurrents = db.current
                .OrderByDescending(c => c.PraiseCount)
                .Take(5);

            foreach (var hotCurrent in hotCurrents)
            {
                var _user = db.bmdUser.Where(u => u.Id == hotCurrent.UserId).FirstOrDefault();

                vm.Add(new HotCurrentViewModel
                {
                    bmdUser = _user,
                    current = hotCurrent
                });
            }

            return vm;
        }

        // 获取用户排行
        public IList<TopUserViewModel> GetTopUserVmList()
        {
            IList<TopUserViewModel> vm = new List<TopUserViewModel>();

            var users = from u in db.bmdUser
                        select u;

            foreach (var user in users)
            {
                var _helpCount = db.notice
                    .Where(n => n.Type == "招领启示" && n.Status == "已领回")
                    .Where(n => n.UserId == user.Id)
                    .Count();

                vm.Add(new TopUserViewModel
                {
                    bmdUser = user,
                    HelpCount = _helpCount
                });
            }

            vm = vm.OrderByDescending(u => u.HelpCount)
                .Take(10)
                .ToList();

            return vm;
        }
    }
}