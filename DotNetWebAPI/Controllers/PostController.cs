using CoreApiResponse;
using DotNetWebAPI.Data;
using DotNetWebAPI.Interfaces.Manager;
using DotNetWebAPI.Manager;
using DotNetWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DotNetWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : BaseController
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
            try {
                var posts = _postManager.GetAll().OrderBy(c=>c.CreatedDate).ToList();
                return CustomResult("Data loaded successfully",posts);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet]
        public IActionResult GetAllDesc()
        {
            // var posts=_dbContext.Posts.ToList();
            try
            {
                var posts = _postManager.GetAll().OrderBy(c => c.CreatedDate).OrderByDescending(c=>c.CreatedDate).ToList();
                return CustomResult("Data loaded successfully", posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            try {
                var post = _postManager.GetById(id);
                if (post != null)
                {
                    return Ok(post);
                }
                return CustomResult("Data not found",HttpStatusCode.NotFound);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
          
        }
        [HttpPost]
        public IActionResult Add(Post post)
        {
            try {
                post.CreatedDate = DateTime.Now;
                bool isSaved = _postManager.Add(post);
                if (isSaved)
                {
                    //return Created("", post);
                    return CustomResult("Post has been created",post);
                }
                return BadRequest("Failed to save");
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
         
        }

        [HttpPut]
        public IActionResult Edit(Post post)
        {
            try {
                if (post.Id == 0)
                {
                    return BadRequest("Id missing");
                }
                bool isUpdate = _postManager.Update(post);
                if (isUpdate)
                {
                    return Ok(post);
                }
                return BadRequest("Failed to update");
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try {
                var post = _postManager.GetById(id);
                if (post == null)
                {
                    return NotFound("Data not found");
                }
                bool isDelete = _postManager.Delete(post);
                if (isDelete)
                {
                    return Ok("Post has been deleted");
                }
                return BadRequest("Failed");
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
            
        }
       
    }
}
