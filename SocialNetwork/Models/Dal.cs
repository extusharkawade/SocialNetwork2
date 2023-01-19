using System;  
using System.Data;   
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace SocialNetwork.Models
{
    public class Dal
    {
        public Response Registration(Registration registration, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("insert into Registration(Name,Email,password,PhoneNo,IsActive,IsApproved) " +
                "VALUES('" + registration.Name + "','" + registration.Email + "','" + registration.Password + "','" + registration.PhoneNo + "','" + registration.IsActive + "','" + registration.IsApproved + "'");
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Registration Successfull";


            }
            else
            {
                response.StatusCode=100;
                response.StatusMessage = "Registration Failed";
            }
            return response;
        }

        public Response Login(Registration registration, SqlConnection connection)
            {
            Response response = new Response();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Registration where Email ='"+registration.Email+"' and password ='"+registration.Password+"'",connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if(dataTable.Rows.Count>0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Login successfull";
                Registration registration1 = new Registration();
                registration1.Id = (int)dataTable.Rows[0]["id"];
                registration1.Name = Convert.ToString(dataTable.Rows[0]["Name"]);
                registration1.Email = Convert.ToString(dataTable.Rows[0]["Email"]);
                response.Registration = registration1;


            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Login Failed";
                response.Registration = null;
            }
            return response;

        }


        public Response UserApproval(Registration registration, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("update Registration set IsApproved = 1 where ID ='" + registration.Id + "' and isActive=1", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "User Approved";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User Approval Failed";
            }
            return response;

        }

        public Response AddNews(News news, SqlConnection connection)
        {

            Response response = new Response();
            SqlCommand cmd = new SqlCommand("insert into News(Title,Content,Email,IsActive,CreatedOn)" +
                "VALUES('" + news.Title + "','" + news.Content + "','" + news.Email + "','" + 1 + "','" + DateTime.UtcNow.Date + "')");
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "News Created!";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Unable to create news.";
            }
            return response;


        }

        public Response NewsList(SqlConnection connection)
        {

            Response response = new Response();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from News where IsActive =1",connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if(dataTable.Rows.Count>0)
            {
                List<News> listNews = new List<News>();
                for(int i=0;i<dataTable.Rows.Count;i++)
                {
                    News news = new News();
                    news.Id =Convert.ToInt32( dataTable.Rows[i]["ID"]);
                    news.Title = Convert.ToString(dataTable.Rows[i]["Tital"]);
                    news.Content = Convert.ToString(dataTable.Rows[i]["Content"]);
                    news.Email = Convert.ToString(dataTable.Rows[i]["Email"]);
                    news.IsActive = Convert.ToInt32(dataTable.Rows[i]["IsActive"]);
                    news.CreatedOn = Convert.ToString(dataTable.Rows[i]["CreatedOn"]);
                    listNews.Add(news);
                }
                if(listNews.Count>0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "News data found";
                    response.listNews= listNews;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "News data not found";
                    response.listNews = null;

                }
                
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "News data not found";
                response.listNews = null;
            }
            return response;

        }


        public Response AddArticle(Article article, SqlConnection connection)
        {

            Response response = new Response();
            SqlCommand cmd = new SqlCommand("insert into Article(Title,Content,Email,Image,IsActive,IsApproved)" +
                "VALUES('" + article.Title + "','" + article.Content + "','" + article.Email + "','" + 1 + "','" + DateTime.UtcNow.Date + "')");
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Article Created!";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Unable to create Article.";
            }
            return response;


        }

        public Response ArticleList(SqlConnection connection)
        {

            Response response = new Response();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from Article where IsApproved =1",connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            List<Article> articleList = new List<Article>();
            if(dataTable.Rows.Count > 0)
            {
                for(int i=0;i<dataTable.Rows.Count;i++)
                {
                    Article article = new Article();
                    article.Title =Convert.ToString( dataTable.Rows[i]["Title"]);
                    article.Email = Convert.ToString( dataTable.Rows[i]["Email"]);
                    article.Content = Convert.ToString(dataTable.Rows[i]["Content"]);
                    article.Image = Convert.ToString(dataTable.Rows[i]["Image"]);
                    article.IsApproved = Convert.ToInt32(dataTable.Rows[i]["IsApproved"]);
                    article.IsActive = Convert.ToInt32(dataTable.Rows[i]["IsActive"]);
                    articleList.Add(article);

                }
                if (articleList.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = articleList.Count + "Articles fetch successfully";
                    response.listArticles = articleList;
                }
                else
                {
                    response.StatusCode = 00;
                    response.StatusMessage = "Unable to fetch articles";
                    response.listArticles = null;
                }
            }

            return response;

        }


        public Response ArticleApproval(Article article, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("update Article set IsApproved = 1 where ID ='" + article.Id + "' and isActive=1", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Article Approved";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Article Approval Failed";
            }
            return response;

        }

        public Response StaffRegistration(Staff staff, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("insert into Registration(Name,Email,password,IsActive,IsApproved) " +
                "VALUES('" + staff.Name + "','" + staff.Email + "','" + staff.Password + "','" +1+ "'");
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Staff Registration Successfull";


            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Staff Registration Failed";
            }
            return response;
        }

        public Response DeleteStaffRegistration(Staff staff, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Delete from staff where ID ='"+staff.Id+"'",connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Staff Deleted Successfull";


            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Staff Deletion Failed";
            }
            return response;
        }


        public Response AddEvent(Events events, SqlConnection connection)
        {

            Response response = new Response();
            SqlCommand cmd = new SqlCommand("insert into Events(Title,Content,Email,IsActive,CreatedOn)" +
                "VALUES('" + events.Title + "','" + events.Content + "','" + events.Email + "','" + DateTime.UtcNow.Date + "')");
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Event Created!";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Unable to create Event.";
            }
            return response;


        }

        public Response EventList(SqlConnection connection)
        {

            Response response = new Response();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from Events where IsActive=1", connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            List<Events> eventList= new List<Events>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Events events = new Events();
                    events.Title = Convert.ToString(dataTable.Rows[i]["Title"]);
                    events.Email = Convert.ToString(dataTable.Rows[i]["Email"]);
                    events.Content = Convert.ToString(dataTable.Rows[i]["Content"]);
                    events.IsActive = Convert.ToInt32(dataTable.Rows[i]["IsActive"]);
                    events.CreatedOn = Convert.ToString(dataTable.Rows[i]["CreatedOn"]);
                    eventList.Add(events);

                }
                if (eventList.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = eventList.Count + "Articles fetch successfully";
                    response.listEvents = eventList;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Unable to fetch articles";
                    response.listEvents = null;
                }
            }

            return response;

        }


    }



}
