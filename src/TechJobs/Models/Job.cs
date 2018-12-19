using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechJobs.Models
{
    public class Job
    {
        public string Name { get; set; }
        public Employer Employer { get; set; }
        public Location Location { get; set; }
        public CoreCompetency CoreCompetency { get; set; }
        public PositionType PositionType { get; set; }

        public int ID { get; set; }
        private static int nextId = 1;

        public Job()
        {
            ID = nextId;
            nextId++;
        }
    }
}