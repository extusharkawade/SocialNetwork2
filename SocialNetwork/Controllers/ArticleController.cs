using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using System.Data.SqlClient;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ArticleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddArticle")]
        public Response AddArticle(Article article)
        {
            Response response = new Response();
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.AddArticle(article,sqlConnection);
            return response;
        }

        [HttpPost]
        [Route("ArticleList")]
        public Response AllArticle() 
        {
            Response response = new Response();
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.ArticleList( sqlConnection);
            return response;
        }

        [HttpPost]
        [Route("ArticleApproval")]
        public Response ArticleApproval(Article article)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Response response = new Response();

            Dal dal = new Dal();
            response = dal.ArticleApproval(article, connection);

            return response;
        }
    }
}
