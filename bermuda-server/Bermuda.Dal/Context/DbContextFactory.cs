using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Dal.Context
{
    using System.Data.Entity;

    class DbContextFactory
    {
        /// <summary>
        /// 创建EF上下文对象，已存在就直接取，不存在就创建，保证线程内是唯一
        /// </summary>
        public static DbContext GetDbContext()
        {
            // TODO
            return null;
        }
    }
}
