using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Bermuda.Model;

namespace Bermuda.Dal.Dao
{
    public interface INoticeCmntDao
    {
        /// <summary>
        /// 获取对应启示编号的评论
        /// </summary>
        /// <param name="id">启示编号</param>
        /// <returns>数据表或 null</returns>
        DataTable GetNoticeCmntById(Int64 id);

        /// <summary>
        /// 添加启示评论记录
        /// </summary>
        /// <param name="cmnt">实体对象：NoticeCmnt</param>
        /// <returns>布尔值：是否添加成功</returns>
        Boolean AddNoticeCmnt(NoticeCmnt cmnt);
    }
}
