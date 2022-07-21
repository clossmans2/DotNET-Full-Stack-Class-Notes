using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Factories
{
    public class XBoxRemote : Remote
    {
        private readonly string _remoteType;
        private string _manufacturer;

        public XBoxRemote(bool wired, bool batteries, string manufacturer)
        {
            _remoteType = "XBox";
            _manufacturer = manufacturer;
            this.Wire = wired ? new XBoxWire() : null;
            this.Batteries = batteries ? new XBoxBatteries() : null;
        }

        public override string RemoteType
        {
            get { return _remoteType; }
        }
        public override string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }
        }
    }
}
