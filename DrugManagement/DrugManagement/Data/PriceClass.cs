using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrugManagement.Data
{
    public partial class FactorD
    {
        private decimal? _PriceSub;
        public decimal? PriceSub
        {
            get
            {
                return this.PriceSub = this.Price * this.AmountBuy;
            }
            set
            {
                if ((this._PriceSub != value))
                {
                    this.SendPropertyChanging();
                    this._PriceSub = value;
                    this.SendPropertyChanged("PriceSub");
                }
            }
        }

    }
}

