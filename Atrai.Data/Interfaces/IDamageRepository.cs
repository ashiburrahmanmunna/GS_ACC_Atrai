using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces.Base;
using Atrai.Data.Interfaces.Self;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Atrai.Data.Interfaces
{
    public interface IDamageRepository : IBaseRepository<DamageModel>
    {
        //IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }

    public interface IDamageItemsRepository : IBaseRepository<DamageItemsModel>
    {
    }

    public interface IDamageBatchItemsRepository : IBaseRepository<DamageBatchItemsModel>
    {
    }


    public interface IInternalTransferRepository : IBaseRepository<InternalTransferModel>
    {
        //IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }

    public interface IInternalTransferItemsRepository : IBaseRepository<InternalTransferItemsModel>
    {
    }

    public interface IInternalTransferBatchItemsRepository : IBaseRepository<InternalTransferBatchItemsModel>
    {
    }


    public interface IVGMRepository : IBaseRepository<VGMModel>
    {
    }
    public interface IShortLinkRepository : IBaseRepository<ShortLinkModel>
    {
    }
    public interface IShortLinkHitRepository : ISelfRepository<ShortLinkHitModel>
    {
    }

    public interface IInvoiceBillRepository : IBaseRepository<InvoiceBillModel>
    {
    }

    public interface IOrdersRepository : IBaseRepository<OrdersModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }

    public interface IOrdersItemsRepository : IBaseRepository<OrdersItemsModel>
    {
    }

    public interface IOrdersPaymentRepository : IBaseRepository<OrdersPaymentModel>
    {
    }

    public interface IIssueRepository : IBaseRepository<IssueModel>
    {
        //IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }

    public interface IIssueItemsRepository : IBaseRepository<IssueItemsModel>
    {
    }

    public interface IIssueBatchItemsRepository : IBaseRepository<IssueBatchItemsModel>
    {
    }



    public interface IDeliveryServiceWeightRepository : IBaseRepository<DeliveryServiceWeightModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }


    public interface IDeliveryServiceTimingRepository : IBaseRepository<DeliveryServiceTimingModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }


    public interface IDeliveryServiceDistanceRepository : IBaseRepository<DeliveryServiceDistanceModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }



    public interface IDeliveryServiceRepository : IBaseRepository<DeliveryServiceModel>
    {

    }

    public interface IDeliveryServiceCommentRepository : IBaseRepository<DeliveryServiceCommentModel>
    {

    }


}
