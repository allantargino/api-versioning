using System;
using System.Collections.Generic;

namespace Body.Models.V1
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }

        public IEnumerable<TaskItem> Tasks { get; set; }
    }
}
