using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrugManagement.Data
{
    public partial class RequestM
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();

        private decimal? _TariffTM;
        public decimal? TariffTM
        {
            get
            {
                return this._TariffTM = this.RequestDs.Sum(c => c.TariffT);
            }
            set
            {
                if ((this._TariffTM != value))
                {
                    this.SendPropertyChanging();
                    this._TariffTM = value;
                    this.SendPropertyChanged("TariffT");
                }
            }
        } }


        public partial class RequestD
        {
            HCISDataContexDataContext dc = new HCISDataContexDataContext();
            private int? _AmountSub;
            private decimal? _Tariff;
            private decimal? _TariffT;
            public int? AmountSub
            {
                get
                {
                    return this._AmountSub = this.Amount - this.AmountDelivery;
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
        

        public decimal? Tariff
        {
            get
            {
                return this._Tariff = dc.Func_LastTariff(this.AmountDeliveryDate,this.Drug,114);
            }
            set
            {
                if ((this._Tariff != value))
                {
                    this.SendPropertyChanging();
                    this._Tariff = value;
                    this.SendPropertyChanged("Tariff");
                }
            }
        }
        public decimal? TariffT
        {
            get
            {
                return this._TariffT = this.AmountDelivery * this.Tariff;
            }
            set
            {
                if ((this._Tariff != value))
                {
                    this.SendPropertyChanging();
                    this._TariffT = value;
                    this.SendPropertyChanged("TariffT");
                }
            }
        }
    }
}
