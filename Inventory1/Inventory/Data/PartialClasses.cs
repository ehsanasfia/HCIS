using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.Data
{
    public partial class RequestD
    {
        private int? _AmountSub;
        public int? AmountSub
        {
            get
            {
                return this._AmountSub = this.AmountRequest - this.AmountDelivery;
            }
            set
            {
                if ((this._AmountSub != value))
                {
                    this.SendPropertyChanging();
                    this._AmountSub = value;
                    this.SendPropertyChanged("AmountSub");
                }
            }
        }

    }
}
