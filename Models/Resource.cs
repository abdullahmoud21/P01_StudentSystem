using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    internal class Resource
    {
        public enum ResourceTypes
        {
            Video,
            Presentation,
            Document,
            Other
        }
        public int? ResourceId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
         public ResourceTypes ResourceType { get; set; }
        public int CourseId { get; set; }
    }
}
