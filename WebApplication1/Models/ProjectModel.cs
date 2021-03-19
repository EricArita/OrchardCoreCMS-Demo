using System;

namespace YessqlApi.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Tech { get; set; }
        public DateTime Deadline { get; set; }
        public string Leader { get; set; }
        public byte IsDeleted { get; set; }
    }

    public class ApiProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LeaderId { get; set; }
        public byte IsDeleted { get; set; }
    }
}
