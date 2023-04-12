using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCISContracts.Data
{
    public partial class Vw_DocContractHe32
    {
        private char[] _Digit = new char[8];
        public char[] Digit
        {
            get
            {
                return this._Digit;
            }
            set
            {
                if ((this._Digit != value))
                {

                    this._Digit = value;
                }
            }
        }




        private string _StrPrice;
        public string StrPrice
        {
            get
            {
                return this._StrPrice;
            }
            set
            {
                if ((this._StrPrice != value))
                {
                    this._StrPrice = value;
                }
            }
        }

    }

    public partial class DoctorFunction
    {
        private decimal _Price;

        public decimal Price
        {
            get
            {
                if (this.Staff.Offical == true)
                {

                    if (this.Service != null && this.Service.DocPaymentCatOffical != null && this.Service.DoctorPaymentCategory1.DoctorServiceCategoryTariffs != null)
                    {
                        try
                        {
                            var dcd = Service.DoctorPaymentCategory1.DoctorContractDs.FirstOrDefault(x => x.DoctorContractM != null
                                    && x.DoctorContractM.StaffID == StaffID && x.DoctorContractM.StartDate.Substring(0, 7).CompareTo(Date) <= 0 && x.DoctorContractM.EndDate.Substring(0, 7).CompareTo(Date) >= 0);
                            if (dcd.DoctorContractM.UseKhososiTariff)
                                this._Price = this.Service.DoctorPaymentCategory1.DoctorServiceCategoryTariffs.Where(x => x.DSServiceID == this.Service.DocPaymentCatOffical).OrderByDescending(x => x.Date).FirstOrDefault().Khososi ?? 0;
                            else if (dcd.DoctorContractM.UseQeyreDolatiTariff)
                                this._Price = this.Service.DoctorPaymentCategory1.DoctorServiceCategoryTariffs.Where(x => x.DSServiceID == this.Service.DocPaymentCatOffical).OrderByDescending(x => x.Date).FirstOrDefault().QeyreDolati ?? 0;
                            else
                                this._Price = this.Service.DoctorPaymentCategory1.DoctorServiceCategoryTariffs.Where(x => x.DSServiceID == this.Service.DocPaymentCatOffical).OrderByDescending(x => x.Date).FirstOrDefault().Dolati ?? 0;
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                else if (this.Staff.Offical != true)
                {
                    if (this.Service != null && this.Service.DocPaymentCatNonOffical != null && this.Service.DoctorPaymentCategory.DoctorServiceCategoryTariffs != null)
                    {
                        try
                        {
                            var dcd = Service.DoctorPaymentCategory.DoctorContractDs.FirstOrDefault(x => x.DoctorContractM != null
                                   && x.DoctorContractM.StaffID == StaffID && x.DoctorContractM.StartDate.Substring(0, 7).CompareTo(Date) <= 0 && x.DoctorContractM.EndDate.Substring(0, 7).CompareTo(Date) >= 0);
                            if (dcd.DoctorContractM.UseDolatiTariff)
                                this._Price = this.Service.DoctorPaymentCategory1.DoctorServiceCategoryTariffs.Where(x => x.DSServiceID == this.Service.DocPaymentCatOffical).OrderByDescending(x => x.Date).FirstOrDefault().Dolati ?? 0;
                            else if (dcd.DoctorContractM.UseQeyreDolatiTariff)
                                this._Price = this.Service.DoctorPaymentCategory1.DoctorServiceCategoryTariffs.Where(x => x.DSServiceID == this.Service.DocPaymentCatOffical).OrderByDescending(x => x.Date).FirstOrDefault().QeyreDolati ?? 0;
                            else
                                this._Price = this.Service.DoctorPaymentCategory1.DoctorServiceCategoryTariffs.Where(x => x.DSServiceID == this.Service.DocPaymentCatOffical).OrderByDescending(x => x.Date).FirstOrDefault().Khososi ?? 0;

                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                return this._Price;

            }
        }

        private float _AmountForPayment;

        public float AmountForPayment
        {
            get
            {
                if (this.Service.DoctorPaymentCategory.PayWithK == true | this.Service.DoctorPaymentCategory1.PayWithK == true)
                    return (float)this.JozeHerfeyi;

                else if (this.Amount != 0)
                    return (float)this.Amount;

                else if (this.Amount == 0)
                    return (float)this.ConfirmedAmount;



                else return 0;
            }
        }

        private double? _Zarib;

        public double? Zarib
        {
            get
            {
                if (_Zarib == null)
                {
                    try
                    {
                        if (this.Staff.Offical == true)
                        {
                            if (this.Service != null && this.Service.DoctorPaymentCategory1 != null)
                            {
                                var dcd = Service.DoctorPaymentCategory1.DoctorContractDs.FirstOrDefault(x => x.DoctorContractM != null
                                    && x.DoctorContractM.StaffID == StaffID && x.DoctorContractM.StartDate.Substring(0, 7).CompareTo(Date) <= 0 && x.DoctorContractM.EndDate.Substring(0, 7).CompareTo(Date) >= 0);
                                _Zarib = dcd == null || dcd.Multiplier == null || !dcd.Multiplier.HasValue ? 0 : dcd.Multiplier.Value;
                            }
                        }
                        else if (this.Staff.Offical == false)
                        {
                            if (this.Service != null && this.Service.DoctorPaymentCategory != null)
                            {
                                var dcd = Service.DoctorPaymentCategory.DoctorContractDs.FirstOrDefault(x => x.DoctorContractM != null
                                    && x.DoctorContractM.StaffID == StaffID && x.DoctorContractM.StartDate.Substring(0, 7).CompareTo(Date) <= 0 && x.DoctorContractM.EndDate.Substring(0, 7).CompareTo(Date) >= 0);
                                _Zarib = dcd == null || dcd.Multiplier == null || !dcd.Multiplier.HasValue ? 0 : dcd.Multiplier.Value;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        _Zarib = 0;
                    }
                }
                return _Zarib;
            }
        }
    }
}


