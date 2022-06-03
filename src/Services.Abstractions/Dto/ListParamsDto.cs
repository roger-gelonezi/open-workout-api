using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.Dto
{
    public class ListParamsDto
    {
        public DateTime? LastUpdateSince { get; set; }
        public string? OrderBy { get; set; }
        public int? PageSize { get; set; }
        public int? Page { get; set; }
    }
}
