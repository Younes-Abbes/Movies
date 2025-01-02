using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication1.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesAPIController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMoviesAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Movie ID is required.");
            }

            string apiKey = "69aacf73";
            string baseUrl = "http://www.omdbapi.com/";

            // Construct the full URL with the API key and movie ID
            string requestUrl = $"{baseUrl}?apikey={apiKey}&i={id}";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Send a GET request to the OMDB API
                    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);

                    // Ensure the request was successful
                    response.EnsureSuccessStatusCode();

                    // Read the response content as a string
                    string responseData = await response.Content.ReadAsStringAsync();

                    // Return the response data as JSON
                    return Ok(responseData);
                }
                catch (HttpRequestException ex)
                {
                    // Handle errors (e.g., network issues, API errors)
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        $"Error fetching data from OMDB API: {ex.Message}");
                }
            }
        }
    }
}
