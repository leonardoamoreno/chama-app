using CourseSignUp.Api.Controllers;
using CourseSignUp.Application.Interfaces;
using CourseSignUp.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CourseSignUp.Api.Courses
{
    [ApiController, Route("[controller]")]
    public class CoursesController : ApiController
    {
        private readonly ICourseAppService _courseAppService;

        public CoursesController(ICourseAppService courseAppService)
        {
            _courseAppService = courseAppService;
        }


        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Ok(await _courseAppService.GetById(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> Post([FromBody] CourseViewModel courseViewModel)
        {
            try
            {
                return Ok(await _courseAppService.Register(courseViewModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Route("sign-up")]
        public async Task<IActionResult> Post([FromBody] SignupViewModel signupViewModel)
        {
            try
            {
                return Ok(await _courseAppService.Signup(signupViewModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
