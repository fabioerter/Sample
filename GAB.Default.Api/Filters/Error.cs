using System.Collections.Generic;


namespace $safeprojectname$.Filters
{
    public class Error
    {
        public IEnumerable<string> messages { get; set; }
        public int status { get; set; }
    }
}
