using ECommerceDomain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Interface
{
    public interface IPaginationService<T, S> where T : class
    {
        PaginationVM<T> GetPagination(List<S> source, PaginationIN pagination);
    }
}

