using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Factories
{
    public class PSRemote : Remote
    {
        private readonly string _remoteType;
        private string _manufacturer;

        public PSRemote(bool wired, bool batteries, string manufacturer)
        {
            _remoteType = "Playstation";
            _manufacturer = manufacturer;
            this.Wire = wired ? new PSWire() : null;
            this.Batteries = batteries ? new PSBatteries() : null;
        }

        public override string RemoteType => _remoteType;

        public override string Manufacturer 
        { 
            get => _manufacturer; 
            set => _manufacturer = value; 
        }
    }
}
