using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Training.Domain.Enums;

namespace Training.Core
{
    public class RepositoryFilterDTO<T> : FilterDTO
    {
        public bool withTraking { get; set; }
        public bool includeUser { get; set; }
        public OrderTypeEnum OrderType { get; set; }
        public Expression<Func<T, bool>> expression { get; set; }
    }


}
