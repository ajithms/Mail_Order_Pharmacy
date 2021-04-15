using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RefillModuleService
{
    public class RefillDetails
    {
        public int RefillOrderId { get; set; }
        public int Subscription_ID { get; set; }
        public int Member_ID { get; set; }
        public string DrugName { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }

        public int NoOfRefills { get; set; }
        public DateTime FirstRefillDate { get; set; }
        public DateTime LastRefillDate { get; set; }
     
       public DateTime PrevRefillDate { get; set; }

        public DateTime NextRefillDate { get; set; }

        public string RefillOccurnace { get; set; }
        // public int Policy_ID { get; set; }
        public string Status { get; set; }

     
       


    }
}
