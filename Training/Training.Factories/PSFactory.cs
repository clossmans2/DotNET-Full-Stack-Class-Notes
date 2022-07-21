using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Factories
{
    public class PSFactory : RemoteFactory
    {
        private bool _wired;
        private bool _batteries;
        private string _manufacturer;

        public PSFactory(bool wired, bool batteries, string manufacturer)
        {
            _wired = wired;
            _batteries = batteries;
            _manufacturer = manufacturer;
        }

        public override Remote GetRemote()
        {
            return new PSRemote(_wired, _batteries, _manufacturer);
        }
    }
}
