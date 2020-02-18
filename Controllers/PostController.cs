using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEB_API_Task.Middleware;
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
            Log1.PopulateLog("Get Post");
            return Ok(Post);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Log1.PopulateLog($"Get Post Id = {id}");
            return Ok(Post.First(k => k.Id == id));
        }

        [HttpPost]
        public IActionResult PostAdd(Posts post)
        {
            Log1.PopulateLog("Add Post");
            return Ok(Post.Append(post));
        }

        [HttpDelete]
        public IActionResult DeletePost(int id)
        {
            Log1.PopulateLog($"Delete Post Id = {id}");
            return Ok(Post.RemoveAll(k => k.Id == id));
        }

        [HttpPatch("{id}")]
        public IActionResult PatchbyId(int id, [FromBody]JsonPatchDocument<Posts> patchPost)
        {
            Log1.PopulateLog($"Update Post Id = {id}");
            patchPost.ApplyTo(Post.Find(e => e.Id == id));
            return Ok(Post.Find(e => e.Id == id));
        }
    }
}