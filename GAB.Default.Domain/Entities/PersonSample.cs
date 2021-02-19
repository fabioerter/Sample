using $safeprojectname$.Base;
using System;

namespace $safeprojectname$.Entities
{
    public class PersonSample : Entity
    {
        public string FullName { get; set; }
        public DateTime DateBirth { get; set; }
        public int Age { get; set; }
    }
}
