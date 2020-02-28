using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tutorefcore.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace tutorefcore.Controllers
{
    [ApiController]
    [Route("post")]
    public class PostController : ControllerBase
    {

        private readonly ILogger<PostController> _logger;
        private readonly PostContext _context;

        public PostController(ILogger<PostController> logger, PostContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(){
            var post = _context.Post;

            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = post
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var post = _context.Post.First(i => i.Id == id);

            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = post
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var order_item = _context.Post.First(i => i.Id == id);

            _context.Post.Remove(order_item);
            _context.SaveChanges();
            return Ok(order_item);
        }

        [HttpPost]
        public IActionResult Post(Posts post){
            _context.Post.Add(post);
            _context.SaveChanges();
            return Ok(new {
                message = "success send data", 
                status = true,
                data = post
            });
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]JsonPatchDocument<Posts> post){

            post.ApplyTo(_context.Post.Find(id));
            _context.SaveChanges();
            return Ok();
        }

    }
}
