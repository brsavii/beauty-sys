using Domain.Interfaces.Services;
using Domain.Objects.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController, Authorize]
    [Route("Payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPatch("UpdatePayment")]
        public async Task<IActionResult> UpdatePayment(int id, UpdatePaymentRequest updatePaymentRequest)
        {
            try
            {
                await _paymentService.UpdatePayment(id, updatePaymentRequest);

                return Ok("Pagamento atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SavePayment")]
        public async Task<IActionResult> SavePayment(CreatePaymentRequest createPaymentRequest)
        {
            try
            {
                await _paymentService.SavePayment(createPaymentRequest);

                return Ok("Pagamento salvo com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletePayment/{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            try
            {
                await _paymentService.DeletePayment(id);

                return Ok("Pagamento deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
