using Microsoft.AspNetCore.Mvc;
using LightF_API.Models;
using System;

namespace LightF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmitController : ControllerBase
    {
        [HttpPost]
        public IActionResult Submit(SupervisorNotification dataIn)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("FirstName=" + dataIn.FirstName);
            Console.WriteLine("LastName=" + dataIn.LastName);
            Console.WriteLine("Email=" + dataIn.Email);
            Console.WriteLine("PhoneNumber=" + dataIn.PhoneNumber);
            Console.WriteLine("Supervisor=" + dataIn.Supervisor);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");

            return Ok(new { Message = "Employee data received successfully" });
        }
    }
}
