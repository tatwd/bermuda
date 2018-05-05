namespace Bermuda.Api.Models
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        // hot topics model
        public IList<HotTopicsViewModel> HotTopics;

        // notice list model

        // hot species model

        // hot currents model

        // top users model
    }

    // HotTopicsViewModel
    public class HotTopicsViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
    }
}
