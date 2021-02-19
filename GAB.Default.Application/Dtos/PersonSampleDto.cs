using System;
using System.Collections.Generic;
using System.Text;

namespace $safeprojectname$.Dtos
{
    public class PersonSampleDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateBirth { get; set; }
        public int Age { get; set; }
    }
}
