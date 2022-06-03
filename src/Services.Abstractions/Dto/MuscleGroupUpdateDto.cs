using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.Dto
{
    public class MuscleGroupUpdateDto
    {
        public Guid Id { get; set; }
        public string MuscleGroupName { get; set; }
    }
}
