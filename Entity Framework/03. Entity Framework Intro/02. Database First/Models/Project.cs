﻿namespace SoftUni.Models
{
    using System;
    using System.Collections.Generic;

    public class Project
    {
        public Project()
        {
            Projects = new HashSet<EmployeeProject>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<EmployeeProject> Projects { get; set; }
    }
}
