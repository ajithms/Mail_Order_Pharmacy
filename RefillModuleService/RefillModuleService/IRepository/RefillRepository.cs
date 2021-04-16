using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RefillModuleService.IRepository
{
    public class RefillRepository : IRefillRepository
    {
        public static List<RefillDetails> ls = new List<RefillDetails>()
        {
            new RefillDetails
            {
                RefillOrderId=1,
                Subscription_ID =101,
                Member_ID=1,
                DrugName="Paracetamol",
                Location="Mangalore",
                Quantity=2,
                NoOfRefills=2,
                FirstRefillDate=new DateTime(2020,04,04),
                LastRefillDate=new DateTime(2020,07,04),
                PrevRefillDate=new DateTime(2020,05,04),
                NextRefillDate=new DateTime(2020,06,04),
                RefillOccurnace="Monthly",
                Status="clear"
            },
            new RefillDetails
            {
                RefillOrderId=2,
                Subscription_ID =102,
                Member_ID=2,
                DrugName="Paracetamol",
                Location="Delhi",
                Quantity=2,
                NoOfRefills=2,
                FirstRefillDate=new DateTime(2020,05,04),
                LastRefillDate=new DateTime(2020,08,04),
                PrevRefillDate=new DateTime(2020,07,04),
                NextRefillDate=new DateTime(2020,06,04),
                RefillOccurnace="Monthly",
                Status="Clear"
            }
        };
        /// <summary>
        ///  This method is responsible for returing the refill Details searched by Subscription ID
        /// </summary>
        /// <param name="Sub_Id"></param>
        /// <returns></returns>
        public virtual dynamic ViewAllDetails(int memId)
        {
            var item = ls.Where(x => x.Member_ID == memId).ToList();
            return item;
        }


        public virtual dynamic viewRefillStatus(int Sub_Id)
        {
            var item = ls.Where(x => x.Subscription_ID == Sub_Id).FirstOrDefault();
            if (item == null)
                return null;
            return item;
        }
        public bool AddRefillDetails(Subscription subr)
        {
            try
            {
                RefillDetails refil = new RefillDetails();
                refil.RefillOrderId = subr.SubscriptionID - 100;
                refil.DrugName = subr.DrugName;
                refil.Subscription_ID = subr.SubscriptionID;
                refil.Member_ID = subr.MemberID;
                refil.Location = subr.Location;
                refil.NoOfRefills = subr.NoOfRefills;
                refil.Quantity = subr.Quantity;
                refil.RefillOccurnace = "Monthly";
                refil.Status = "Pending";
                refil.FirstRefillDate = DateTime.Now;
                refil.LastRefillDate = refil.FirstRefillDate.AddMonths(refil.NoOfRefills);
                refil.PrevRefillDate = DateTime.Now;
                refil.NextRefillDate = refil.PrevRefillDate.AddMonths(1);
                ls.Add(refil);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public void RemoveRefillDetails(int sid)
        {
           var obj = ls.SingleOrDefault(x => x.Subscription_ID == sid);
           ls.Remove(obj);
        }
    }
}
