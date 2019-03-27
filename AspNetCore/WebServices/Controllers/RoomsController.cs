using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppServices.DataModels;
using WebAppServices.DTO;
using WebAppServices.Repository;

namespace WebAppServices.Controllers
{
    [EnableCors("WebCorsPolicy")]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        protected readonly ILogger<RoomsController> _logger;
        protected IRoomBookingServiceRepository _repository;

        public RoomsController(IRoomBookingServiceRepository repository, ILogger<RoomsController> logger = null)
        {
            _repository = repository;
            if (null != logger)
            {
                _logger = logger;
            }
        }

        [HttpGet]
        [Route("GetAvialableRoom")]
        public IActionResult GetAvialableRoom(string bookIn, string bookOut)
        {
            try
            {
                int currentPage = 0, pageSize = 10;
                DtoRooms returnValue = _repository.GetAvialableRoom(bookIn, bookOut, currentPage, pageSize);
                if (returnValue != null && returnValue.Total > 0)
                {
                    return Ok(returnValue);
                }
                return NoContent();
            }
            catch (Exception exp)
            {
                if (_logger != null)
                    _logger.LogCritical(string.Format("Exception for {0}", "GetBookings With", GetInnerErrorMessage(exp)));
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetBookings")]
        public IActionResult GetBookings()
        {
            try
            {
                DtoRooms returnValue = _repository.GetAllRooms();
                if (returnValue != null && returnValue.Total > 0)
                {
                    return Ok(returnValue);
                }
                return NoContent();
            }
            catch (Exception exp)
            {
                if (_logger != null)
                    _logger.LogCritical(string.Format("Exception for {0}/{1}", "GetBookings", GetInnerErrorMessage(exp)));
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("SaveUser")]
        public IActionResult SaveUser([FromBody]DtoUser objDtoUser)
        {
            try
            {
                if(!this.ModelState.IsValid)
                    return BadRequest(ModelState);

                int returnValue = _repository.SaveUser(objDtoUser);
                if (returnValue > 0)
                {
                    return Ok(returnValue);
                }
                return BadRequest();
            }
            catch (Exception exp)
            {
                if (_logger != null)
                    _logger.LogCritical(string.Format("Exception for {0}/{1}", "GetBookings", GetInnerErrorMessage(exp)));
                return BadRequest();
            }
        }
        private string GetInnerErrorMessage(Exception exp)
        {
            return exp.InnerException != null
                ? exp.Message.ToString() + " " + GetInnerErrorMessage(exp.InnerException)
                : exp.Message.ToString();
        }
    }
}
