using System;

namespace FuturifyModule.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Tech { get; set; }
        public DateTime Deadline { get; set; }
        public string Leader { get; set; }
        public byte IsDeleted { get; set; } = 0;
    }
}
