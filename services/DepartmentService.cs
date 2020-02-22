using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Modules;

namespace WebApplication1.services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly List<Department> _departments = new List<Department>();

        public DepartmentService()
        {
            _departments.Add(new Department
            {
                Id = 1,
                Name="HR",
                EmployeeCount=16,
                Location="Beijing"
            });
            _departments.Add(new Department
            {
                Id = 2,
                Name = "DEV",
                EmployeeCount = 52,
                Location = "Shanghai"
            });
            _departments.Add(new Department
            {
                Id = 3,
                Name = "OPS",
                EmployeeCount = 200,
                Location = "China"
            });
        }

        public Task Add(Department department)
        {
            department.Id = _departments.Max(x => x.Id) + 1;
            _departments.Add(department);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            return Task.Run(function:()=>_departments.AsEnumerable());
        }

        public Task<Department> GetById(int id)
        {
            return Task.Run(function: () => _departments.FirstOrDefault(x=>x.Id==id));
        }

        public Task<CompanySummary> GetCompanySummary()
        {
            return Task.Run(function: () =>
            {
                return new CompanySummary
                {
                    EmployeeCount = _departments.Sum(x => x.EmployeeCount),
                    AverageDepartmentEmployeeCount = (int)_departments.Average(x => x.EmployeeCount)
                };
            });
        }
    }
}
