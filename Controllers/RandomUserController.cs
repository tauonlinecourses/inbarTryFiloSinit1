using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prog3_WebApi_Javascript.DTOs;
using System.Text.Json.Nodes;

namespace Prog3_WebApi_Javascript.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomUserController : ControllerBase
    {
        private readonly HttpClient _client;
        public RandomUserController()
        {
            _client = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            string endpoint = "https://randomuser.me/api/";

            var response = await _client.GetAsync(endpoint);

            if(response.IsSuccessStatusCode)
            {
                JsonObject responseContent = response.Content.ReadFromJsonAsync<JsonObject>().Result;
                RandomUser UserToReturn = new RandomUser();
                UserToReturn.FirstName = responseContent["results"][0]["name"]["first"].ToString();
                UserToReturn.LastName = responseContent["results"][0]["name"]["last"].ToString();
                UserToReturn.ImageUrl = responseContent["results"][0]["picture"]["large"].ToString();

                return Ok(UserToReturn);

            }

            return BadRequest("API Call Failed");

        }
    }
}
