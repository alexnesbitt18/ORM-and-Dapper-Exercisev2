using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_and_Dapper_Exercisev2
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
    }
}
