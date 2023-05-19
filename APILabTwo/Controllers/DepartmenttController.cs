using APIBLayer.Dtos;
using APIBLayer.Managers.Departments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIAPresentationLabTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmenttController : ControllerBase
    {
        private readonly IDepartmentManager context;
        public DepartmenttController(IDepartmentManager department)
        {
            context = department;
        }

        [HttpGet]
        [Route("{id")]
        public ActionResult<DepartmentReadDto> DepartmentDetails(int id)
        {
            DepartmentReadDto? dept = context.GetDetails(id);
            if (dept is null)
            {
                return NotFound();
            }
            return dept;
        }
    }
}
