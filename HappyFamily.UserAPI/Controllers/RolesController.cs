using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyFamily.Enties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyFamily.UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly Sys_RoleManager sysRoleManager = new Sys_RoleManager();

        // GET: api/Roles
        [HttpGet]
        public object Get()
        {
            var dataList = sysRoleManager.GetList(a=>a.F_DeleteMark==false&&a.F_EnableMark==true);

            return Ok(new
            {
                success = true,
                data = dataList
            });
        }

        // GET: api/Roles/5
        [HttpGet("{id}", Name = "Get")]
        public object Get(int id)
        {
            var model = sysRoleManager.GetById(id);
            return Ok(new
            {
                success = model != null,
                data = model
            });
        }

        // POST: api/Roles
        [HttpPost]
        public object Post([FromBody] Sys_Role model)
        {
            string currentUserName = "";
            model.F_CreatorTime=DateTime.Now;
            model.F_CreatorUserId = currentUserName;
            model.F_LastModifyTime=DateTime.Now;
            model.F_LastModifyUserId = currentUserName;

            var addResult = sysRoleManager.Insert(model);
            return Ok(new
            {
                success=addResult
            });
        }

        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public object Put(int id, [FromBody] Sys_Role model)
        {
            string currentUserName = "";
            
            model.F_LastModifyTime=DateTime.Now;
            model.F_LastModifyUserId = currentUserName;

            var updateResult = sysRoleManager.Update(model);
            return Ok(new
            {
                success=updateResult
            });
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            string currentUserName = "";

            var model =sysRoleManager.GetById(id)?.First();
            if (model == null)
                return NotFound();
            
            model.F_DeleteMark=true;
            model.F_DeleteTime=DateTime.Now;
            model.F_LastModifyUserId = currentUserName;

            var updateResult = sysRoleManager.Update(model);
            return Ok(new
            {
                success=updateResult
            });
        }
    
    }
}