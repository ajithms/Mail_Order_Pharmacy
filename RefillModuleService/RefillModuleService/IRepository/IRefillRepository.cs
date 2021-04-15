using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefillModuleService.IRepository
{
     public interface IRefillRepository
     {
        public dynamic ViewAllDetails();
        public dynamic viewRefillStatus(int Subscription_ID);
        public bool AddRefillDetails(Subscription subr);
        public void RemoveRefillDetails(int Subscription_ID);
        
    }
}
