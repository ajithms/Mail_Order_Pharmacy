using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RefillModuleService.IRepository;

namespace RefillModuleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefillController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        IRefillRepository _refill;

        public RefillController(IRefillRepository irefill)
        {

            _refill = irefill;

            _log4net = log4net.LogManager.GetLogger(typeof(RefillController));
        }
        /// <summary>
        /// This method returns refill status by cheaking Subscription ID 
        /// </summary>
        /// <param name="Sub_id"></param>
        /// <returns></returns>
        // GET: api/<RefillController>/7
        [HttpGet("RefillStatus")]
        public IActionResult ViewRefill()
        {
            try
            {
                var item = _refill.ViewAllDetails();
                if (item == null)
                    return null;
                return Ok(item);
               
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpGet("RefillStatus/{Sub_id}")]
        public IActionResult RefillStatus(int Sub_id)
        {
            _log4net.Info(" Http Get request for Refill Status");

            try
            {
                var item = _refill.viewRefillStatus(Sub_id);
                if (item == null)
                    return null;
                return Ok(item);
            }
            catch

            {
                return BadRequest();
            }

        }

        [HttpPost("Add")]
        public IActionResult AddDetails(Subscription sub)
        {
            if (_refill.AddRefillDetails(sub))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("Remove/{id}")]
        public IActionResult RemoveDetails(int id)
        {
            try
            {
                _refill.RemoveRefillDetails(id);
                return Ok();
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
      
    }
}