using System.Collections.Generic;
using Bmd.Model;

namespace Bmd.App.Models
{
    public class IndexViewModel
    {
        public IList<HotTopicViewModel> HotTopicsVm { get; set; }
        public IList<NoticeViewModel> NoticeVm { get; set; }
        public IList<HotSpeciesViewModel> HotSpeciesVm { get; set; }
        public IList<HotCurrentViewModel> HotCurrentVm { get; set; }
        public IList<TopUserViewModel> TopUserVm { get; set; }
    }

    public class HotTopicViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
    }

    public class NoticeViewModel
    {
        public BmdUser bmdUser { get; set; }
        public Notice notices { get; set; }
    }

    public class HotSpeciesViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
    }

    public class HotCurrentViewModel
    {
        public BmdUser bmdUser { get; set; }
        public Current current { get; set; }
    }

    public class TopUserViewModel
    {
        public BmdUser bmdUser { get; set; }
        public int HelpCount { get; set; }
    }
}