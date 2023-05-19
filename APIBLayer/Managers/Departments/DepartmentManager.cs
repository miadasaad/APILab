using APIBLayer.Dtos;
using APIDAL.Data.Models;
using APIDALayer.Repos.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBLayer.Managers.Departments
{
    public class DepartmentManager:IDepartmentManager
    {
        private readonly IDepartmentRepo context;
        public DepartmentManager(IDepartmentRepo _context)
        {
            context = _context;
        }
        public DepartmentReadDto? GetDetails(int id)
        {
            Department? dept = context.getDeptDetails(id);
            if (dept is null)
            {
                return null;
            }

            return new DepartmentReadDto
            {
                Id = dept.Id,
                Name = dept.Name,
                tickets = dept.Tickets.Select(t => new ticketInfoDto
                {
                    Id = t.Id,
                    Description = t.Description,
                    DeveloperCount = t.Developers.Count
                }).ToList()

            };
            

        }
    }
}
