﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfoAPI.Models
{
    public class CityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfPointsInterest { get; set; }

        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; }
        = new List<PointOfInterestDto>();
    }
}
