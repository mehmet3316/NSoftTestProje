using Application.CustpmerHendler;
using Core.Customer.Command;
using Core.Customer.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NSoftTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Kayıt ve güncelleme
        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdateProduct([FromBody] CustomersCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
       
        //Silme
        [HttpDelete("Delete/{KAYITKODU}")]
        public async Task<IActionResult> DeleteProduct(string KAYITKODU)
        {
            var command = new DeleteQuery { KAYITKODU = KAYITKODU };
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        //Kayıt Bul Getir
        [HttpGet("GetById/{KAYITKODU}")]  
        public async Task<IActionResult> GetProduct(string KAYITKODU)
        {
           var query = new CustomersQuery { KAYITKODU =KAYITKODU};
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
