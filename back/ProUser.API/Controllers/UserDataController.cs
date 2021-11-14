using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProUser.Contracts;
using ProUser.Models;
using ProUser.Services;

namespace ProUser.Controllers
{
    [Route("[controller]")]
    public class UserDataController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ISecurityService _securityService;


        public UserDataController(UserService userService, ISecurityService securityService)
        {
            _userService = userService;
            _securityService = securityService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            try
            {
                var users = _userService.GetUser();

                if (users == null) return BadRequest("Nenhum usuário encontrado.");

                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar users: {e.Message}");
            }
        }

        [HttpGet("{username}")]
        public ActionResult<User> Get(string username)
        {
            try
            {
                var user = _userService.GetUser(username);

                if (user == null) return BadRequest("Nenhum usuário encontrado.");

                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar users: {e.Message}");
            }
        }


        [HttpDelete("{username}")]
        public ActionResult Delete(string username)
        {
            try
            {
                var user = _userService.GetUser(username);
                if (user == null) NotFound("Usuário não enccontrado.");

                _userService.Delete(username);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}