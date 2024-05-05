using LXP.Common;
using LXP.Common.Entities;
using LXP.Common.ViewModels;
using LXP.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LXP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IServices _services;
        public ValuesController(IServices services) {

           _services=services;
        }

        [HttpGet]
        [Route("getMovie")]
        public List<MoviedetailModel>GetMoviedetails()
        {

            return _services.GetMoviedetails();
        }

        [HttpGet]
        [Route("getMoviebyid")]
        public ActionResult<MoviedetailModel> GetMoviedetailbyid(int id) {

            var data= _services.GetMoviedetailbyid(id);
            if(data == null) {
              return NotFound();
            }
            return Ok(data);
        
        }
        [Route("PostMovie")]
        [HttpPost]
        public void CreateMovie([FromBody]MoviedetailModel moviedetail) {

             _services.CreateMovie(moviedetail);
        
        }

    }
}
