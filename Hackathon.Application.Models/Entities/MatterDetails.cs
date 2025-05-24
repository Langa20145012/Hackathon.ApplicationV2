using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.Models.Entities
{

    public class MatterDetails1
    {
        public MatterDetails1()
        {
            Matter = new Matter();
            DocumentList = new List<Document>();
            ActiveMatterList = new List<Matter>();
            RejectedMatterList = new List<Matter>();
            CompletedMatterList = new List<Matter>();

        }
        public Matter Matter { get; set; }
        public List<Matter> ActiveMatterList { get; set; }
        public List<Matter> RejectedMatterList { get; set; }
        public List<Matter> CompletedMatterList { get; set; }
        public List<Document> DocumentList { get; set; }
    }
}

