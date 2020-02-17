using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static WEB_API_Task.Model.User;

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
        new Comments()
        {   Id = 1,
            Content = "Saya setuju dengan kamu.",
            Status = "online a few minutes ago",
            Author_id = 2,
            Email = "kucing@email.com",
            Url = "kcg.url.com",
            Post_id = 1},
    };

        private readonly ILogger<CommentController> _logger;

        public CommentController(ILogger<CommentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Comment);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(Comment.First(k => k.Id == id));
        }

        [HttpPost]
        public IActionResult CommentAdd(Comments comment)
        {
            var commentAdd = new Comments()
            {
                Id = comment.Id,
                Content = comment.Content,
                Status = comment.Status,
                Author_id = comment.Author_id,
                Email = comment.Email,
                Url = comment.Url,
                Post_id = comment.Post_id
            };
            Comment.Add(commentAdd);
            return Ok(Comment);
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            return Ok(Comment.RemoveAll(k => k.Id == id));
        }

        [HttpPatch("{id}")]
        public IActionResult PatchById(Comments comment)
        {
            Comment.RemoveAll(x => x.Id == comment.Id);
            Comment.Add(comment);
            return Ok(Comment);
        }
}