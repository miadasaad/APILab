using APIDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDALayer.Repos.Departments
{
    public interface IDepartmentRepo
    {
        Department getDeptDetails(int id);
    }
}
