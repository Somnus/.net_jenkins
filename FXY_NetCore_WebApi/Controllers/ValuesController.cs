using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FXY_NetCore_DbContext;
using FXY_NetCore_DbEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace FXY_NetCore_WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValuesController : Controller
    {
        protected DefaultContext Context { get; set; }
        public ValuesController(DefaultMySqlContext defaultMySqlContext, IMemoryCache cache)
        {
            Context = new DefaultContext(defaultMySqlContext, cache);
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {


            Student student = new Student() { UUID = Guid.NewGuid().ToString(), Name = "成钢", BirthPlace = "西藏" };
            Context.Add(student);
            Context.SaveChanges();

            Student student1 = Context.Get<Student>(student.UUID);

            Thread.Sleep(10000);

            Student student2 = Context.Get<Student>(student.UUID);

            return new List<string>() { student.UUID };
        }


        public Student GetStudent(string uuid)
        {
            Student student = Context.Get<Student>(uuid);
            return student;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
