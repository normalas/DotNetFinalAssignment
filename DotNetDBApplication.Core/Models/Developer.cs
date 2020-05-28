using System.Collections.Generic;

namespace DotNet.Models
{
    public class Developer
    {
        public Developer() { }
        public Developer(string DeveloperName)
        {
            this.DeveloperName = DeveloperName;
        }
        public int DeveloperId { get; set; }
        public string DeveloperName { get; set; }
        public VideoGame DeveloperOf { get; set; }

        public override string ToString()
        {
            return DeveloperName;
        }
    }
}
