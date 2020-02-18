using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static WEB_API_Task.Model.User;
using Microsoft.AspNetCore.JsonPatch;
using WEB_API_Task.Middleware;

namespace WEB_API_Task.Controllers
{
    [ApiController]
    [Route("comment")]

    public class CommentController : ControllerBase
    {
        private static List<Comments> Comment = new List<Comments>()
    {
        new Comments()
        {   Id = 1,
            Content = "Saya setuju dengan kamu.",
            Status = "online a few minutes ago",
            Author_id = 2,
            Email = "kucing@email.com",
            Url = "kcg.url.com",
            Post_id = 1},
        new Comments()
        {   Id = 2,
            Content = "Saya juga setuju dengan kamu.",
            Status = "online",
            Author_id = 2,
            Email = "kucingX@email.com",
            Url = "kcgX.url.com",
            Post_id = 1},
        new Comments()
        {   Id = 3,
            Content = "Saya yakin bisa lebih baik dari ini.",
            Status = "offline",
            Author_id = 2,
            Email = "kucingMewah@email.com",
            Url = "kcgMWH.url.com",
            Post_id = 2},
    };

        private readonly ILogger<CommentController> _logger;

        public CommentController(ILogger<CommentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Log1.PopulateLog("Get Comment");
            return Ok(Comment);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Log1.PopulateLog($"Get Comment Id = {id}");
            return Ok(Comment.First(k => k.Id == id));
        }

        [HttpPost]
        public IActionResult CommentAdd(Comments comment)
        {
            Log1.PopulateLog("Add Post");
            return Ok(Comment.Append(comment));
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            Log1.PopulateLog($"Delete Comment Id = {id}");
            return Ok(Comment.RemoveAll(k => k.Id == id));
        }

        [HttpPatch("{id}")]
        public IActionResult PatchbyId(int id, [FromBody]JsonPatchDocument<Comments> patchComment)
        {
            Log1.PopulateLog($"Update Comment Id = {id}");
            patchComment.ApplyTo(Comment.Find(e => e.Id == id));
            return Ok(Comment.Find(e => e.Id == id));

        }
    }
}