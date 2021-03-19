using System;
using System.Collections.Generic;
using System.Text;
using YesSql.Indexes;

namespace YessqlApi.Indexes
{
    public class ApiLeaderIndex : MapIndex
    {
        public string FullName { get; set; }
    }
}
