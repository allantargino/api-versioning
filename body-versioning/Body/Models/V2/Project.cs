using System;
using System.Collections.Generic;

namespace Body.Models.V2
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }

        public IEnumerable<TaskItem> Tasks { get; set; }
    }
}
