using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.Dto
{
    public class MuscleGroupGetListDto : ListParamsDto
    {
        public string? MuscleGroupName { get; set; }
    }
}
