using BusinessLayer.Interface;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FundooNotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IBus _bus;
        public TicketController(IBus bus)
        {
            _bus = bus;
        }
        private readonly IuserBL iuserBL;
        public TicketController(IuserBL iuserBL)
        {
            iuserBL = this.iuserBL;
        }
        //public IActionResult CreateTicketForPassword(string email)
        //{
        //    if (email!=null)
        //    {
        //        var token = iuserBL.ForgetPasswordd(email);
        //        if (token != null)
        //        {
        //            var result = iuserBL.CreateTicketForPassword(email, token);
        //            Uri uri = new Uri("rabbitmq://localhost/ticketQueue");
        //            var endPoint =  _bus.GetSendEndpoint(uri);
        //            endPoint.Send(result);

        //        }
        //    }
        //}
    }
}
