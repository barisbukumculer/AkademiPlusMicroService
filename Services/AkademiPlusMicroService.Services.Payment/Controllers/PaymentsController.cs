using AkademiPlusMicroService.Services.Payment.Context;
using AkademiPlusMicroService.Services.Payment.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AkademiPlusMicroService.Services.Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {   private readonly PaymentContext _context;

        public PaymentsController(PaymentContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult PaymentList()
        {
            var values = _context.PaymentDetails.ToList();
            return Ok(values);
        }
        [HttpPost]
        public  IActionResult PaymentCreate(PaymentDetail paymentDetail)
        {
            _context.PaymentDetails.Add(paymentDetail);
            _context.SaveChanges();
            return Ok("Ödeme Başarılı Bir Şekilde Alındı.");
        }
    }
}
