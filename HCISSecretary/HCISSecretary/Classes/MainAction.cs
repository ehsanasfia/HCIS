using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HCISSecretary.Data;

namespace HCISSecretary.Classes
{

  public   class MainAction
    {
        HCISDataContext DataContext;
       public  MainAction()
        {
           
        }
     public    MainAction(HCISDataContext DataContext) {
            this.DataContext = DataContext;
        }

     public    void Save() {
            try {
                DataContext.SubmitChanges();
             //   DataContext.Dispose();
            }
            catch(Exception ex)
            { MessageBox.Show(ex.ToString()); }
            }
     public    Boolean CheckSrvice(Service EditingService)
        {
            if (EditingService == null)
            {
                MessageBox.Show("سرویس خالی می باشد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return false;
            }
            if (EditingService .CategoryID==null)
            {
                MessageBox.Show("نوع سرویس مشخص نیست", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return false;
            }
            if (EditingService.Name == null)
            {
                MessageBox.Show("نام سرویس مشخص نیست", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return false;
            }
            return true;
        }
     public    Boolean CheckDataContext()
        {
            if (DataContext == null)
            {
                MessageBox.Show("دیتا خالی ارسال شده", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return false;
            }
            return true;
        }
     public    void insertService(Service EditingService)
        {

            if (!CheckSrvice(EditingService))
                return;


            try
            {
                if (!DataContext.Services.Any(x => x.ID == EditingService.ID))
                {
                    DataContext.Services .InsertOnSubmit(EditingService);
                }
                Save();
                MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
   public    void insertPerson(Person EditingPerson)
        {
            try
            {
                if (!DataContext.Persons.Any(x => x.ID == EditingPerson.ID))
                {
                    DataContext.Persons.InsertOnSubmit(EditingPerson);
                }
                Save();
                MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
     public   void insertGivenServiceD(GivenServiceD EditingGivenServiceD)
        {
            try
            {
                if (!DataContext.GivenServiceDs.Any(x => x.ID == EditingGivenServiceD.ID))
                {
                    DataContext.GivenServiceDs.InsertOnSubmit(EditingGivenServiceD);
                }
                Save();
                MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
    }
