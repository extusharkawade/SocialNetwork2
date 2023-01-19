using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using System.Data.SqlClient;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
                _configuration= configuration;
        }

        [HttpPost]
        [Route("Registration")]

        public Response Registration(Registration registration)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Response response = new Response();

            Dal dal = new Dal();
            response =dal.Registration(registration,connection);
 
            return response;

        }

        [HttpPost]
        [Route("Login")]
        public Response Login(Registration registration)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Response response = new Response();

            Dal dal = new Dal();
            response = dal.Login(registration, connection);

            return response;
        }

        [HttpPost]
        [Route("UserApproval")]
        public Response UserApproval(Registration registration)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Response response = new Response();

            Dal dal = new Dal();
            response = dal.UserApproval(registration, connection);

            return response;
        }

        [HttpPost]
        [Route("StaffRegistration")]
        public Response StaffRegistration(Staff staff)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Response response = new Response();

            Dal dal = new Dal();
            response = dal.StaffRegistration(staff, connection);

            return response; 

        }


        [HttpPost]
        [Route("DeleteStaff")]
        public Response DeleteStaff(Staff staff)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Response response = new Response();

            Dal dal = new Dal();
            response = dal.DeleteStaffRegistration(staff, connection);

            return response;

        }

    }
}
