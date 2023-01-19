using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialNetwork.Models;
using System.Data.SqlClient;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public EventsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddEvent")]

        public Response AddEvent(Events events)
            {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());


            Dal dal =  new Dal();
           response =  dal.AddEvent(events, connection);
            return response;
        }

        [HttpPost]
        [Route("EventList")]
        public Response AllEvents()
        {
            Response response = new Response();
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.EventList(sqlConnection);
            return response;
        }
    }
}
