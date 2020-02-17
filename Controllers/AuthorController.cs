using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static WEB_API_Task.Model.User;

namespace WEB_API_Task.Controllers
{
    [ApiController]
    [Route("author")]

    public class AuthorController : ControllerBase
    {
        private static List<Authors> Author = new List<Authors>()
        {
            new Authors()
            {   Id = 1,
                Username = "kcg",
                Password = "rahasia",
                Salt = "msg",
                Email = "kucing@email.com",
                Profile = "Doctor" },

            new Authors()
            {   Id = 2,
                Username = "kcg0rn",
                Password = "rahasiasioren",
                Salt = "msg",
                Email = "kucingX@email.com",
                Profile = "Scientist" },

            new Authors()
            {   Id = 3,
                Username = "kcgMwh",
                Password = "Mewahpunyarahasia",
                Salt = "msg",
                Email = "kucingMewah@email.com",
                Profile = "Teacher" }
        };

        private readonly ILogger<AuthorController> _logger;

        public AuthorController(ILogger<AuthorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Author);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(Author.First(k => k.Id == id));
        }

        [HttpPost]
        public IActionResult AuthorAdd(Authors author)
        {
            var authorAdd = new Authors()
            {   Id = author.Id,
                Username = author.Username,
                Password = author.Password,
                Salt = author.Salt,
                Email = author.Email,
                Profile = author.Profile };
            Author.Add(authorAdd);

            return Ok(Author);
        }

        [HttpDelete]
        public IActionResult DeleteAuthor(int id)
        {
            return Ok(Author.RemoveAll(k => k.Id == id));
        }

        [HttpPatch("{id}")]
        public IActionResult PatchById(Authors author)
        {
            Author.RemoveAll(x => x.Id == author.Id);
            Author.Add(author);
            return Ok(Author);
        }
    }
}