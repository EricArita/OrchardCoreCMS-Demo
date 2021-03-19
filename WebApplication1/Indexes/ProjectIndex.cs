using System;
using System.Collections.Generic;
using System.Text;
using YesSql.Indexes;

namespace YessqlApi.Indexes
{
    public class ProjectIndex : MapIndex
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public byte IsDeleted { get; set; }
    }

    public class ApiProjectIndex : MapIndex
    {
        public string Name { get; set; }
        public byte IsDeleted { get; set; }
        public int LeaderId { get; set; }
    }
}
