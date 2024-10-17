using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Atrai.Data.Repository
{



    public class DeliveryServiceWeightRepository : BaseRepository<DeliveryServiceWeightModel>, IDeliveryServiceWeightRepository
    {
        public DeliveryServiceWeightRepository(InvoiceDbContext context) : base(context)
        {
        }


        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.WeightName,
                Value = x.Id.ToString()
            });
        }
    }


    public class DeliveryServiceDistanceRepository : BaseRepository<DeliveryServiceDistanceModel>, IDeliveryServiceDistanceRepository
    {
        public DeliveryServiceDistanceRepository(InvoiceDbContext context) : base(context)
        {
        }


        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.DistanceName,
                Value = x.Id.ToString()
            });
        }

    }




    public class DeliveryServiceTimingRepository : BaseRepository<DeliveryServiceTimingModel>, IDeliveryServiceTimingRepository
    {
        public DeliveryServiceTimingRepository(InvoiceDbContext context) : base(context)
        {
        }


        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.TimingName,
                Value = x.Id.ToString()
            });
        }

    }



    public class DeliveryServiceRepository : BaseRepository<DeliveryServiceModel>, IDeliveryServiceRepository
    {
        public DeliveryServiceRepository(InvoiceDbContext context) : base(context)
        {
        }

    }


    public class DeliveryServiceCommentRepository : BaseRepository<DeliveryServiceCommentModel>, IDeliveryServiceCommentRepository
    {
        public DeliveryServiceCommentRepository(InvoiceDbContext context) : base(context)
        {
        }

    }


}
