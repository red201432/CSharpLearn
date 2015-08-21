using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyForAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    class VersionAttribute:Attribute
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Describtion { get; set; }
    }
}
