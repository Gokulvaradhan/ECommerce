using AutoMapper;
using ECommerceApplication.Interface;
using ECommerceDomain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Service
{
    public class PaginationService<T, S> : IPaginationService<T, S> where T : class
    {
        private readonly IMapper _mapper;

        public PaginationService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public PaginationVM<T> GetPagination(List<S> source, PaginationIN pagination)
        {

            var Currentpage = pagination.PageNumber;

            var Pagesize = pagination.PageSize;

            var TotalnoOfrecords = source.Count;

            var TotalPages = (int)Math.Ceiling(TotalnoOfrecords / (double)Pagesize);

            var Result = source.Skip((pagination.PageNumber - 1) * (pagination.PageSize))
                .Take(pagination.PageSize)
                .ToList();

            var items = _mapper.Map<List<T>>(Result);

            PaginationVM<T> paginationVM = new PaginationVM<T>(Currentpage, TotalPages, Pagesize, TotalnoOfrecords, items);

            return paginationVM;
        }
    }
}
