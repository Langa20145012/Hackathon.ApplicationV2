using Hackathon.Application.Models.Entities;

namespace Hackathon.Application.UI.Models
{
    public class MatterDetails
    {       
        public MatterDetails() 
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
