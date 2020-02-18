namespace WEB_API_Task.Model
{
    public class User
    {
        public class Authors
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Salt { get; set; }
            public string Email { get; set; }
            public string Profile { get; set; }
        }

        public class Posts
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public string Tags { get; set; }
            public string Create_time { get; set; }
            public string Update_time { get; set; }
            public int Author_id { get; set; }
        }

        public class Comments
        {
            public int Id { get; set; }
            public string Content { get; set; }
            public string Status { get; set; }
            public int Author_id { get; set; }
            public string Email { get; set; }
            public string Url { get; set; }
            public int Post_id { get; set; }
        }
    }
}
