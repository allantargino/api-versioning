using System.Collections.Generic;

namespace Body.Models.V2
{
    public class TaskItem
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }

        public IEnumerable<User> Users { get; set; }

    }
}