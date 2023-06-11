using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_MODELS
{
    public partial class GroupTour
    {
        public GroupTour() { }
        public GroupTour(string naam, DateTime startDate, DateTime enddate, decimal budget, decimal price, int maxParticipants, int themeId, int ageCategoryId, int responsibleId, int destinationId)
        {
            Name = naam;
            Startdate = startDate;
            Enddate = enddate;
            Budget = budget;
            Price = price;
            MaxParticipants = maxParticipants;
            ThemeID = themeId;
            AgeCategoryID = ageCategoryId;
            ResponsibleID = responsibleId;
            DestinationID = destinationId;
        }
    }
}
