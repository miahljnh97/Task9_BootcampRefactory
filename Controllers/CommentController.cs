using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static WEB_API_Task.Model.User;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.JsonPatch;

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

        //[HttpPatch("{id}")]
        //public IActionResult CommentPatch([FromBody] JsonPatchDocument<Comments> patchComment, int id)
        //{
        //    if (patchComment != null)
        //    {
        //        var Com = new Comments();
        //        patchComment.ApplyTo(Com, ModelState);

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        return new ObjectResult(Com);
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}

        //public IActionResult PatchById(Comments comment)
        //{
        //    Comment.RemoveAll(x => x.Id == comment.Id);
        //    Comment.Add(comment);
        //    return Ok(Comment);
        //}

        //[HttpPatch("{id}")]
        //public IActionResult PatchById(Comments comment, int id)
        //{
        //    Comments A = Comment.Where(k => k.Id == id).First();
        //    int index = Comment.IndexOf(A);
        //    if (comment.Id == 0)
        //    {
        //        comment.Id = A.Id;
        //    }
        //    if (comment.Content == null)
        //    {
        //        comment.Content = A.Content;
        //    }
        //    if (comment.Status == null)
        //    {
        //        comment.Status = A.Status;
        //    }
        //    if (comment.Author_id == 0)
        //    {
        //        comment.Author_id = A.Author_id;
        //    }
        //    if (comment.Email == null)
        //    {
        //        comment.Email = A.Email;
        //    }
        //    if (comment.Url == null)
        //    {
        //        comment.Url = A.Url;
        //    }
        //    if (comment.Post_id == 0)
        //    {
        //        comment.Post_id = A.Post_id;
        //    }

        //    Comment[index] = new Comments()
        //    {
        //        Id = comment.Id,
        //        Content = comment.Content,
        //        Status = comment.Status,
        //        Author_id = comment.Author_id,
        //        Email = comment.Email,
        //        Url = comment.Url,
        //        Post_id = comment.Post_id
        //    };
        //    return Ok(Comment);
        //}

        [HttpPatch("{id}")]
        public IActionResult PatchbyId(int id, [FromBody]JsonPatchDocument<Comments> patchComment)
        {
            patchComment.ApplyTo(Comment.Find(e => e.Id == id));
            return Ok(Comment.Find(e => e.Id == id));

        }
    }
}