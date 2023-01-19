namespace SocialNetwork.Models
{
    public class News
    {
        /*create table News(ID int Identity(1,1) Primary key, Title varchar(100)
         * ,Content varchar(255)
,Email varchar(100),
IsActive int,CreatedOn Datetime);*/

        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
        public string Email { get; set; }
        public int IsActive { get; set; }
        public String CreatedOn { get; set; }
    }
}
