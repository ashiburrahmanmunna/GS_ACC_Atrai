//using Invoice.Core.Entity;
//using Invoice.Core.Interfaces.Base;
//using Invoice.Core.Interfaces.Self;

using Atrai.Data.Interfaces.Base;
using Atrai.Model.Core.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Invoice.Core.Interfaces
{
    public interface IDocPrefixRepository : IBaseRepository<DocPrefixModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IUnitConversionRepository : IBaseRepository<UnitConversionModel>
    {
        
    }
}

