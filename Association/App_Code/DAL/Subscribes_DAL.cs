using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Association.EntityFramework;
using System.Data.Entity;
using System.Web.UI.WebControls;
using System.Data;

namespace Association
{

    public class Subscribes_DAL
    {

        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Subscribes Subscribes = new Tbl_Subscribes();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public List<Tbl_Subscribes> SelectAll_Subscribes()
        {
            return Assoc.Tbl_Subscribes.ToList();
            //return Assoc.Tbl_Subscribes.Include(x=>x.Tbl_Member_Registration.Memb_Name).ToList();
        }

        public Tbl_Subscribes SelectAll_SubscribesByMem_ID(int Mem_ID)
        {
            return Assoc.Tbl_Subscribes.Where(x => x.Mem_ID == Mem_ID).FirstOrDefault();
        }

        public Tbl_Subscribes SelectAll_SubscribesByEmpID(string EmpID)
        {
            return Assoc.Tbl_Subscribes.Where(x => x.Tbl_Member_Registration.Memb_EmpID == EmpID).FirstOrDefault();
        }


        public List<SubMemRegModel> SubscribesWithName()
        {
            return Assoc.Tbl_Subscribes.Select(column => new SubMemRegModel
            {
                Memb_Name = column.Tbl_Member_Registration.Memb_Name,
                Mem_ID = column.Mem_ID,
                Sub_Year = column.Sub_Year,
                Sub_Paied = column.Sub_Paied,
                Jan = column.Jan,
                Feb = column.Feb,
                Mar = column.Mar,
                Apr = column.Apr,
                May = column.May,
                June = column.June,
                July = column.July,
                August = column.August,
                Sep = column.Sep,
                Oct = column.Oct,
                Nov = column.Nov,
                Dec = column.Dec,
                Memb_EmpID = column.Tbl_Member_Registration.Memb_EmpID

            }).ToList();

        }



        public void Insert(
                int Sub_Year
              , int Mem_ID
              , int? Sub_Paied = null
              , bool? Jan = null
              , bool? Feb = null
              , bool? Mar = null
              , bool? Apr = null
              , bool? May = null
              , bool? June = null
              , bool? July = null
              , bool? August = null
              , bool? Oct = null
              , bool? Nov = null
              , bool? Dec = null

            )
        {
            try
            {
                Subscribes.Sub_Year = Sub_Year;
                Subscribes.Mem_ID = Mem_ID;
                Subscribes.Jan = Jan;
                Subscribes.Feb = Feb;
                Subscribes.Mar = Mar;
                Subscribes.Apr = Apr;
                Subscribes.May = May;
                Subscribes.June = June;
                Subscribes.July = July;
                Subscribes.August = August;
                Subscribes.Oct = Oct;
                Subscribes.Nov = Nov;
                Subscribes.Dec = Dec;
                Subscribes.Sub_Paied = Sub_Paied;

                Assoc.Tbl_Subscribes.Add(Subscribes);
                Assoc.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(hand_Excep.HandlingExce(ex));
            }

        }

        public string UpdateByEmpId(
                string EmpId
              , int Sub_Year
              , int Sub_Paied
              , bool? Jan = null
              , bool? Feb = null
              , bool? Mar = null
              , bool? Apr = null
              , bool? May = null
              , bool? Jun = null
              , bool? Jul = null
              , bool? Aug = null
              , bool? Sep = null
              , bool? Oct = null
              , bool? Nov = null
              , bool? Dec = null

            )
        {
            try
            {
                Subscribes = Assoc.Tbl_Subscribes.Where(x => x.Tbl_Member_Registration.Memb_EmpID == EmpId).FirstOrDefault<Tbl_Subscribes>();
                //Subscribes = Assoc.Tbl_Subscribes.Where(O => O.Sub_Year == Sub_Year && O.Mem_ID == Mem_ID).FirstOrDefault<Tbl_Subscribes>();
                if (Subscribes != null)
                {
                    Subscribes.Sub_Paied = Sub_Paied;
                    Subscribes.Sub_Year = Sub_Year;
                    if (Jan != null) Subscribes.Jan = Jan;
                    if (Feb != null) Subscribes.Feb = Feb;
                    if (Mar != null) Subscribes.Mar = Mar;
                    if (Apr != null) Subscribes.Apr = Apr;
                    if (May != null) Subscribes.May = May;
                    if (Jun != null) Subscribes.June = Jun;
                    if (Jul != null) Subscribes.July = Jul;
                    if (Aug != null) Subscribes.August = Aug;
                    if (Sep != null) Subscribes.Sep = Sep;
                    if (Oct != null) Subscribes.Oct = Oct;
                    if (Nov != null) Subscribes.Nov = Nov;
                    if (Dec != null) Subscribes.Dec = Dec;


                    Assoc.Entry(Subscribes).State = EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }



        public string UpdateByMemberId(
              int Mem_ID
            , int Sub_Year
            , int Sub_Paied
            , bool? Jan = null
            , bool? Feb = null
            , bool? Mar = null
            , bool? Apr = null
            , bool? May = null
            , bool? Jun = null
            , bool? Jul = null
            , bool? Aug = null
            , bool? Sep = null
            , bool? Oct = null
            , bool? Nov = null
            , bool? Dec = null

          )
        {
            try
            {
                Subscribes = Assoc.Tbl_Subscribes.Where(x => x.Mem_ID == Mem_ID).FirstOrDefault<Tbl_Subscribes>();

                if (Subscribes != null)
                {
                    Subscribes.Sub_Paied = Sub_Paied;
                    Subscribes.Sub_Year = Sub_Year;
                    if (Jan != null) Subscribes.Jan = Jan;
                    if (Feb != null) Subscribes.Feb = Feb;
                    if (Mar != null) Subscribes.Mar = Mar;
                    if (Apr != null) Subscribes.Apr = Apr;
                    if (May != null) Subscribes.May = May;
                    if (Jun != null) Subscribes.June = Jun;
                    if (Jul != null) Subscribes.July = Jul;
                    if (Aug != null) Subscribes.August = Aug;
                    if (Sep != null) Subscribes.Sep = Sep;
                    if (Oct != null) Subscribes.Oct = Oct;
                    if (Nov != null) Subscribes.Nov = Nov;
                    if (Dec != null) Subscribes.Dec = Dec;


                    Assoc.Entry(Subscribes).State = EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }



    }
}