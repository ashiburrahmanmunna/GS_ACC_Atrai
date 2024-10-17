using Atrai.Model.Core.Entity;
using System.Collections.Generic;

namespace Atrai.Model.Core.ViewModel
{
    public class DasboardViewDto
    {

        public List<ChartConfiguration> Charts { get; set; } = new List<ChartConfiguration>();
        public List<CustomView> CustomViews { get; set; } = new List<CustomView>();
        public List<CustomView> StatementViews { get; set; } = new List<CustomView>();
        public List<DashBoardLayoutOrder> LayoutOrders { get; set; } = new List<DashBoardLayoutOrder>();
    }


}
