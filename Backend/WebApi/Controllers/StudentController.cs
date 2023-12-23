using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Interface;
using Entity.Models;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost]
        [Route("Add")]
        public string Add(Student student) => studentService.Add(student).ToString();


    }
}

