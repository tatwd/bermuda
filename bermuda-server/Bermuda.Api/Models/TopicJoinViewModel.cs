using System.Collections.Generic;

namespace Bermuda.Api.Models
{
    public class TopicJoinViewModel
    {
        public TopicViewModel topic { get; set; }
        public IList<CurrentViewModel> currents { get; set; }
    }
}
