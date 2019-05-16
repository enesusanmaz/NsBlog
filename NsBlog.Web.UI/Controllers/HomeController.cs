using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NsBlog.Data.Abstract;
using NsBlog.Web.UI.Models;

namespace NsBlog.Web.UI.Controllers
{
    public class HomeController : Controller
    {

        private IPostRepository _postRepository;
        public HomeController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        //[HttpGet("{id}", Name = "OwnerById")]
        //public async Task<IActionResult> GetOwnerById(Guid id)
        //{
        //    try
        //    {
        //        var owner = await _repository.Owner.GetOwnerByIdAsync(id);

        //        if (owner.IsEmptyObject())
        //        {
        //            _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
        //            return NotFound();
        //        }
        //        else
        //        {
        //            _logger.LogInfo($"Returned owner with id: {id}");
        //            return Ok(owner);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var posts = await _postRepository.GetAllPostsAsync();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Some error in the GetAllOwners method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
