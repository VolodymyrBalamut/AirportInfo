﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInfo.model
{
    public class ActualFlight : Base<ActualFlight>
    {
        public int ActualFlightID;
        public int FlightID;
        public DateTime ActualFlightDate;
        public int PlaneID;
        public string StatusFlightTypeName;

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Get()
        {
            throw new NotImplementedException();
        }

        public override void Insert()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
