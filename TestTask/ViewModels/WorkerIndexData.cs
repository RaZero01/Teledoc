using System.Collections.Generic;
using TestTask.Models;

namespace TestTask.ViewModels
{
    public class WorkerIndexData
    {
        public IEnumerable<Worker> Workers { get; set; }
        public IEnumerable<Organization> Organizations { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}