using LightF_API.Helpers;
using LightF_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace LightF_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupervisorsController : ControllerBase
    {
        private readonly string _apiUrl = "";

        private readonly GetDataFromAPI _getDataFromAPI;

        public SupervisorsController(GetDataFromAPI getDataFromAPI, IConfiguration configuration)
        {
            _apiUrl = configuration["AppSettings:ApiUrl"];

            _getDataFromAPI = getDataFromAPI;
        }
        [HttpGet(Name = "supervisors")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                //error handling
                if (string.IsNullOrWhiteSpace(_apiUrl))
                {
                    return BadRequest("Endpoint URL is blank or empty.");
                }

                // Get data from external API
                string? jsonData = "";
                jsonData = await _getDataFromAPI.GetJsonDataFromApi(_apiUrl);

                if (jsonData != null)
                {
                    Console.WriteLine("JSON Data:");
                    Console.WriteLine(jsonData);

                    var jsonOut = ConvertJSONSupervisors(jsonData);
                    Response.Headers.Append("Content-Type", "application/json");

                    return Ok(jsonOut);
                }
                else
                {
                    Console.WriteLine("JSON data from the API is null.");
                }

                var deserializedData = JsonConvert.DeserializeObject(jsonData);
                Console.Write(deserializedData);
                Response.Headers.Append("Content-Type", "application/json");

                return Ok(deserializedData);
            }
            catch (FileNotFoundException)
            {
                return NotFound("JSON file not found.");
            }
            catch (JsonException)
            {
                return BadRequest("Invalid JSON data.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private List<string> ConvertJSONSupervisors(string? jsonIn)
        {
            // convert string into List<Supervisor>
            List<Supervisor> supervisors = JsonConverterHelper.DeserializeJsonList<Supervisor>(jsonIn).ToList<Supervisor>();

            List<string> supervisorListOut = new List<string>();

            if (supervisors == null)
            {
                Console.WriteLine("Failed to deserialize JSON string.");
            }
            else
            {
                // filter out numeric Jurisdictions
                List<Supervisor> supervisorsFiltered = supervisors.Where(x => !IsNumeric(x.Jurisdiction)).ToList();

                // sort by jurisdiction, lastName, firstName
                List<Supervisor> supervisorsFilteredAndSorted = supervisorsFiltered.OrderBy(x => x.Jurisdiction)
                                                                        .ThenBy(x => x.LastName)
                                                                        .ThenBy(x => x.FirstName).ToList();

                foreach (Supervisor sup in supervisorsFilteredAndSorted)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"{sup.Jurisdiction} - {sup.LastName}, {sup.FirstName}");
                    supervisorListOut.Add(sb.ToString());
                }
            }

            return supervisorListOut;

        }

        // Helper method to check if a string is numeric
        static bool IsNumeric(string input)
        {
            return double.TryParse(input, out _);
        }
    }
}
