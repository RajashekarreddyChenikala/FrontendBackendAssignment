using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDetailsAPI.Models;

namespace EmployeeDetailsAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        EmpDbEntities db = new EmpDbEntities();
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var empdetails = from x in db.Employees select x;
            return empdetails;
        }

        public Employee Get(int id)
        {
            var getbyid= db.Employees.FirstOrDefault(x => x.id==id);
            return getbyid;
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Employee employee)
        {
            try
            {
                decimal sal = 1000m;
                var newemployee = new Employee()
                {
                    id=employee.id,
                    name=employee.name, 
                    dob=employee.dob,
                    skills=employee.skills,
                    address=employee.address,
                    role=employee.role,
                    salary = employee.salary + sal
                };

                db.Employees.Add(newemployee);
                db.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                return message;
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }      
        }
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var entity = db.Employees.FirstOrDefault(e => e.id == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id=" + id.ToString() + " is not found to Delete");
                }
                else
                {
                    db.Employees.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpPut]
        public HttpResponseMessage Put(int id,[FromBody]Employee employee)
        {
            try
            {
                var entity = db.Employees.FirstOrDefault(e => e.id == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id=" + id.ToString() + " is not found to Update");
                }
                else
                {
                    entity.name = employee.name;
                    entity.dob = employee.dob;
                    entity.skills = employee.skills;
                    entity.address = employee.address;
                    entity.role = employee.role;
                    entity.salary = employee.salary;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK,entity);
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
