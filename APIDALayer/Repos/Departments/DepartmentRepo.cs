using APIDAL.Data.Context;
using APIDAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDALayer.Repos.Departments
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly DataBaseContext context;
        public DepartmentRepo(DataBaseContext _context)
        {
            context = _context;
        }
        public Department? getDeptDetails(int id)
        {
            return context.Departments.Include(t => t.Tickets).ThenInclude(d => d.Developers).FirstOrDefault(dept => dept.Id == id);
        }
    }
}
