using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static WEB_API_Task.Model.User;

namespace WEB_API_Task.Controllers
{

    [ApiController]
    [Route("post")]

    public class PostController : ControllerBase
    {
        private static List<Posts> Post = new List<Posts>()
        {
            new Posts()
            {   Id = 1,
                Title = "Kisah kasih kucing",
                Content = "MAMI Awards",
                Tags = "romantic comedy",
                Create_time = "2017-03-11",
                Update_time = "2020-01-01",
                Author_id = 1},
            new Posts()
            {   Id = 2,
                Title = "Ketika kucing bertasbis",
                Content = "MAMA Awards",
                Tags = "romantic comedy",
                Create_time = "2017-01-17",
                Update_time = "2020-01-20",
                Author_id = 1},
            new Posts()
            {   Id = 3,
                Title = "Kucing GANK",
                Content = "MAMA Awards",
                Tags = "Action",
                Create_time = "2018-02-18",
                Update_time = "2019-12-19",
                Author_id = 2},
            new Posts()
            {   Id = 4,
                Title = "Kucing Cinematic Universe",
                Content = "MAMI Awards",
                Tags = "Action",
                Create_time = "2017-03-11",
                Update_time = "2020-01-01",
                Author_id = 3}
        };

        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Post);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(Post.First(k => k.Id == id));
        }

        [HttpPost]
        public IActionResult PostAdd(Posts post)
        {
            var postAdd = new Posts()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Tags = post.Tags,
                Create_time = post.Create_time,
                Update_time = post.Update_time,
                Author_id = post.Author_id
            };
            Post.Add(postAdd);
            return Ok(Post);
        }

        [HttpDelete]
        public IActionResult DeletePost(int id)
        {
            return Ok(Post.RemoveAll(k => k.Id == id));
        }

        //[HttpPatch("{id}")]
        //public IActionResult PatchById(Posts post)
        //{
        //    Post.RemoveAll(x => x.Id == post.Id);
        //    Post.Add(post);
        //    return Ok(Post);
        //}

        [HttpPatch("{id}")]
        public IActionResult PatchById(Posts post, int id)
        {
            Posts A = Post.Where(k => k.Id == id).First();
            int index = Post.IndexOf(A);
            if (post.Id == 0)
            {
                post.Id = A.Id;
            }
            if (post.Title == null)
            {
                post.Title = A.Title;
            }
            if (post.Content == null)
            {
                post.Content = A.Content;
            }
            if (post.Tags == null)
            {
                post.Tags = A.Tags;
            }
            if (post.Create_time == null)
            {
                post.Create_time = A.Create_time;
            }
            if (post.Update_time == null)
            {
                post.Update_time = A.Update_time;
            }
            if(post.Author_id == 0)
            {
                post.Author_id = A.Author_id;
            }

            Post[index] = new Posts()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Tags = post.Tags,
                Create_time = post.Create_time,
                Update_time = post.Update_time,
                Author_id = post.Author_id
            };
            return Ok(Post);
        }
    }
}