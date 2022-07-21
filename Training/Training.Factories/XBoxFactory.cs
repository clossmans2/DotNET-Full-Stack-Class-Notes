using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Factories
{
    public class XBoxFactory : RemoteFactory
    {
        private bool _wired;
        private bool _batteries;
        private string _manufacturer;

        public XBoxFactory(bool wired, bool batteries, string manufacturer)
        {
            _wired = wired;
            _batteries = batteries;
            _manufacturer = manufacturer;
        }

        public override Remote GetRemote()
        {
            return new XBoxRemote(_wired, _batteries, _manufacturer);
        }
    }
}
