using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPut("{username}")]
        public ActionResult Update(string username, User user){
            try
            {
                var verify = _userService.GetUser(username);
                if(verify==null) BadRequest("User não encontrado.");

                _userService.Update(username, user);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " Erro no Update: "+ex.Message);
            }

        }
    }
}