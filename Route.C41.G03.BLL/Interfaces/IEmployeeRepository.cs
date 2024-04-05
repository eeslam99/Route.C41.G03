using Route.C41.G03.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41.G03.BLL.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        //What is Deffrent between IEnmerable and IQueryable??
        ///IEnerable: will reterive all Employees from Database witout Filteration
        ///IQueryable: will reterive all Employees from Database with Filteration ,So it will be good in Performance
        IQueryable<Employee>GetEmployeesByAddress(string address);
    }
}
