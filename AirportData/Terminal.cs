using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportData
{
    public class Terminal : Base<Terminal>
    {
        public string AirportCode;
        public string TerminalCode;

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
