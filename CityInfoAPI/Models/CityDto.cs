using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfoAPI.Models
{
    public class CityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Descripcion { get; set; }

        public int NumberOfPointsInterest { get; set; }

        public ICollection<PointsOfInterestDto> PointsOfInterest { get; set; }
        = new List<PointsOfInterestDto>();
    }
}
