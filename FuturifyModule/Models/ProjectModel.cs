using System;

namespace FuturifyModule.Models
{
    public class ProjectModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string[] Tech { get; set; }
        public DateTime Deadline { get; set; }
        public string Leader { get; set; }
    }
}
