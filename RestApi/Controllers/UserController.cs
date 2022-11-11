using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestApi.Models;
using RestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
	
		[HttpGet("tokenAccess/{userName}/{password}")]
		public async Task<IActionResult> GetAccessToken(string userName, string password)
		{
			var user = await UserService.GetAccessToken(userName, password);

			return Ok(user);
		}

		[HttpGet("calculator/{valor1}/{valor2}")]
		public async Task<IActionResult> GetCalculator(string valor1, string valor2, string token)
		{
			var result = await UserService.GetCalculator(valor1, valor2, token);
			return Ok(result);
		}
	}
}
