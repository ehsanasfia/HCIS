using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISInsurance.Data;

namespace HCISInsurance.Forms
{
    public partial class frmKPrice : DevExpress.XtraEditors.XtraForm
    {
        public HCISClassesDataContext dc = new HCISClassesDataContext();
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        public Boolean isEdit { get; set; }
        public KPrice EditingK { get; set; }
        public frmKPrice()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                kPriceBindingSource.EndEdit();
                dc.SubmitChanges();
                this.Close();
            }
            else
            {
                kPriceBindingSource.EndEdit();
                EditingK.Date = MainModule.GetPersianDate(DateTime.Now);
                dc.KPrices.InsertOnSubmit(EditingK);
                dc.SubmitChanges();
               
            }
        }

        private void frmKPrice_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            var EditingK = dc.KPrices.FirstOrDefault();
            if (EditingK == null)
                EditingK = new KPrice();
            else
                isEdit = true;
            kPriceBindingSource.DataSource = EditingK;
            insuranceBindingSource.DataSource = dc.Insurances.ToList();
            // txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void btnCalcAllServiceTariff_Click(object sender, EventArgs e)
        {
            if (!splashScreenManager2.IsSplashFormVisible)
                splashScreenManager2.ShowWaitForm();
            try
            {
                var date = txtDateOfTariff.Text;
                if (date.Length != 10)
                {
                    MessageBox.Show("تاریخ به درستی وارد نشده"); return;
                }
                else
                {
                    var lst = new List<Insurance>();
                    foreach (var item in gridView1.GetSelectedRows())
                    {
                        lst.Add(gridView1.GetRow(gridView1.GetRowHandle(item)) as Insurance);
                    }
                    if (lst.Count == 0)
                    {
                        MessageBox.Show("حداقل یک بیمه را انتخاب کنید"); return;
                    }
                    else
                    {
                        if (Int32.Parse(radioGroup1.EditValue.ToString()) == 1)
                        {
                            foreach (var item in lst)
                            {
                                dc.Spu_InsertTariffForAllInsure(date, item.ID);
                            }
                        }

                        if (Int32.Parse(radioGroup1.EditValue.ToString()) == 2)
                        {
                            foreach (var item in lst)
                            {
                                dc.Spu_InsertTariffForAllInsureHashtak(date, item.ID);
                            }
                        }
                        if (Int32.Parse(radioGroup1.EditValue.ToString()) == 3)
                        {
                            foreach (var item in lst)
                            {
                                dc.Spu_InsertTariffForAllInsure(date, item.ID);
                                dc.Spu_InsertTariffForAllInsureHashtak(date, item.ID);
                            }
                        }
                        MessageBox.Show(" تعرفه ها ثبت شد.");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
               
            }
        }
    }
}