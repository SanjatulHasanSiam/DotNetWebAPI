using DotNetWebAPI.Data;
using DotNetWebAPI.Interfaces.Manager;
using DotNetWebAPI.Manager;
using DotNetWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostManager _postManager;
        public PostController(IPostManager postManager)
        {
            _postManager = postManager;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
           // var posts=_dbContext.Posts.ToList();
            var posts=_postManager.GetAll().ToList();
            return Ok(posts);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var post=_postManager.GetById(id);
            if(post != null)
            {
                return Ok(post);
            }
           return NotFound();
        }
        [HttpPost]
        public IActionResult Add(Post post)
        {
            post.CreatedDate = DateTime.Now;
            //_dbContext.Posts.Add(post);
            //bool isSaved=-_dbContext.SaveChanges()>0;

           bool isSaved=_postManager.Add(post);
            if (isSaved)
            {
                return Created("",post);
            }
            return BadRequest("Failed to save");
        }

        [HttpPut]
        public IActionResult Edit(Post post)
        {
            if(post.Id == 0)
            {
                return BadRequest("Id missing");
            }
            bool isUpdate=_postManager.Update(post);
            if (isUpdate)
            {
                return Ok(post);
            }
            return BadRequest("Failed to update");
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var post=_postManager.GetById(id);
            if (post == null)
            {
                return NotFound("Data not found");
            }
            bool isDelete=_postManager.Delete(post);
            if (isDelete)
            {
                return Ok("Post has been deleted");
            }
            return BadRequest("Failed");
        }
       
    }
}
