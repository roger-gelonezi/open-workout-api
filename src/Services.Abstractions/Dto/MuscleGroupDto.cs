using Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.Dto
{
    public class MuscleGroupDto : Entity
    {
        public string MuscleGroupName { get; set; }
    }
}
