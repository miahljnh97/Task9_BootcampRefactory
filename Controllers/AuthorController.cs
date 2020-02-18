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
        public IActionResult AuthorGet()
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
        public IActionResult PatchById(Authors author, int id)
        {
            Authors A = Author.Where(k => k.Id == id).First();
            int index = Author.IndexOf(A);
            if (author.Id == 0)
            {
                author.Id = A.Id;
            }
            if (author.Username == null)
            {
                author.Username = A.Username;
            }
            if (author.Password == null)
            {
                author.Password = A.Password;
            }
            if (author.Salt == null)
            {
                author.Salt = A.Salt;
            }
            if (author.Email == null)
            {
                author.Email = A.Email;
            }
            if (author.Profile == null)
            {
                author.Profile = A.Profile;
            }
           Author[index] = new Authors()
            {
                Id = author.Id,
                Username = author.Username,
                Password = author.Password,
                Salt = author.Salt,
                Email = author.Email,
                Profile = author.Profile
            };
            return Ok(Author);
        }
    }
}