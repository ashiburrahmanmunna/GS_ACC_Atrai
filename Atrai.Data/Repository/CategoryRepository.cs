using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Atrai.Data.Repository.Self;

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Invoice.Core.Interfaces;

namespace Atrai.Data.Repository
{
    public class DocPrefixRepository : BaseRepository<DocPrefixModel>, IDocPrefixRepository
    {
        public DocPrefixRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.DocPrefix,
                Value = x.Id.ToString()
            });
        }
    }

    public class UnitConversionRepository : BaseRepository<UnitConversionModel>, IUnitConversionRepository
    {
        public UnitConversionRepository(InvoiceDbContext context) : base(context)
        {
        }
        
    }

}
