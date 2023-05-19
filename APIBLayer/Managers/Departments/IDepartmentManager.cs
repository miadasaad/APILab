using APIBLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBLayer.Managers.Departments
{
    public interface IDepartmentManager
    {
        public DepartmentReadDto? GetDetails(int id);
    }
}
