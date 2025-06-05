using KoperasiTentera.DAL;
using KoperasiTentera.DomainModel;
using KoperasiTentera.DTO;
using KoperasiTentera.Services;
using Microsoft.AspNetCore.Mvc;

namespace KoperasiTentera.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public RegistrationController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCustomerDto dto)
        {
            var existing = await _repository.GetByICNumberAsync(dto.ICNumber);
            if (existing != null)
                return BadRequest("Customer already exists.");

            var customer = new Customer
            {
                CustomerName = dto.CustomerName,
                ICNumber = dto.ICNumber,
                Email = dto.Email,
                MobileNumber = dto.MobileNumber
            };
            await _repository.AddAsync(customer);
            return Ok("Registration successful");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{icnumber}")]
        public async Task<IActionResult> GetById(string icnumber)
        {
            var customer = await _repository.GetByICNumberAsync(icnumber);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost("sendotp")]
        public async Task<IActionResult> SendOtp(string ICNumber, bool ToMobile = true)
        {
            var customer = await _repository.GetByICNumberAsync(ICNumber);
            if (customer == null)
                return BadRequest("Customer not exists.");

            if (ToMobile)
                SMSService.SendMessage(customer.MobileNumber, KTOtp.GetOtpCode(customer.MobileNumber));
            else
                EmailService.SendMail(customer.Email, $"Your Code is {KTOtp.GetOtpCode(customer.Email)}");

            return Ok(string.Format("Otp send to {0} successful", ToMobile ? "Mobile" : "Email"));
        }

        [HttpPost("validateotp")]
        public async Task<IActionResult> ValidateOtp(string ICNumber, string Code, bool ToMobile = true)
        {
            var customer = await _repository.GetByICNumberAsync(ICNumber);
            if (customer == null)
                return BadRequest("Customer not exists.");

            var isValid = ToMobile ? KTOtp.IsValid(customer.MobileNumber, Code) : KTOtp.IsValid(customer.Email, Code);
            if (isValid)
                return Ok("Valid Otp");

            return BadRequest("Invalid Otp");
        }

        [HttpPost("setpin")]
        public async Task<IActionResult> SetPIN(string ICNumber, string PIN)
        {
            var customer = await _repository.GetByICNumberAsync(ICNumber);
            if (customer == null)
                return BadRequest("Customer not exists.");

            customer.PIN = PIN;
            var result = await _repository.UpdateAsync(customer);
            if (result > 0)
                return Ok("PIN save successful");
            
            return BadRequest("PIN save failed");

        }

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            return Ok("Test Successful");
        }
    }

}
