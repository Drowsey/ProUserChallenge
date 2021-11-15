using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProUser.API.Services;
using ProUser.Contracts;
using ProUser.Models;
using ProUser.Services;

namespace ProUser.Controllers
{
    [Route("[controller]")]
    public class ProUserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ISecurityService _securityService;
        private readonly IAddressService _addressService;
        private readonly WhatsappService _whatsappService = new WhatsappService();


        public ProUserController(UserService userService,
                                ISecurityService securityService,
                                IAddressService addressService)
        {
            _userService = userService;
            _securityService = securityService;
            _addressService = addressService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateAsync([FromBody] User model)
        {
            try
            { 
                if(_userService.IsEmailUsed(model.Email)) return BadRequest("O email já está sendo usado.");

                string userNumero = model.Address.Numero;
                string userComplemento = model.Address.Complemento;

                var user = model;
                
                user.Address = await _addressService.GetAddressByCEPAsync(model.Address.Cep);
                user.Address.Numero = userNumero;
                user.Address.Complemento = userComplemento;
                
                user.Password = _securityService.HashPassword(user.Password);

                return Ok(_userService.Create(user));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao cadastrar usuário: {e.Message}");
            }
        }

        

        [HttpGet]
        [Route("whatsapp")]
        [Authorize]
        public ActionResult Whatsapp()
        {
            _whatsappService.Open();
            return Ok();
        }
    }
}