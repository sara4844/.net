using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTracksAPI.Models
{
    public abstract class QueryParameters
    {
        const int maxPageSize = 30;
        public int Page { get; set; } = 1;
        private int _pageSize = 10;
        public int Size { 
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        
    }
}
