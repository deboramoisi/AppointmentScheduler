using AppointmentScheduler.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppointmentScheduler.Controllers.API
{
    [Route("api/Appointment")]
    [ApiController]
    public class AppointmentAPIController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string loginUserId;
        private readonly string role;

        public AppointmentAPIController(
            IAppointmentService appointmentService,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _appointmentService = appointmentService;
            _httpContextAccessor = httpContextAccessor;
            loginUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            loginUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        }

        
    }
}
