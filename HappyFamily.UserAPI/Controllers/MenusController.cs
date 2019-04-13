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
    public class MenusController : ControllerBase
    {
        private readonly Sys_MenuManager sysMenuManager = new Sys_MenuManager();

        // GET: api/Menus
        [HttpGet]
        public object Get()
        {
            var dataList = sysMenuManager.GetList(a=>a.F_DeleteMark==false&&a.F_EnableMark==true);

            return Ok(new
            {
                success = true,
                data = dataList
            });
        }

        // GET: api/Menus/5
        [HttpGet("{id}", Name = "Get")]
        public object Get(int id)
        {
            var model = sysMenuManager.GetById(id);
            return Ok(new
            {
                success = model != null,
                data = model
            });
        }

        // POST: api/Menus
        [HttpPost]
        public object Post([FromBody] Sys_Menu model)
        {
            string currentUserName = "";
            model.F_CreatorTime=DateTime.Now;
            model.F_CreatorUserId = currentUserName;
            model.F_LastModifyTime=DateTime.Now;
            model.F_LastModifyUserId = currentUserName;

            var addResult = sysMenuManager.Insert(model);
            return Ok(new
            {
                success=addResult
            });
        }

        // PUT: api/Menus/5
        [HttpPut("{id}")]
        public object Put(int id, [FromBody] Sys_Menu model)
        {
            string currentUserName = "";
            
            model.F_LastModifyTime=DateTime.Now;
            model.F_LastModifyUserId = currentUserName;

            var updateResult = sysMenuManager.Update(model);
            return Ok(new
            {
                success=updateResult
            });
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            string currentUserName = "";

            var model =sysMenuManager.GetById(id)?.First();
            if (model == null)
                return NotFound();
            
            model.F_DeleteMark=true;
            model.F_DeleteTime=DateTime.Now;
            model.F_LastModifyUserId = currentUserName;

            var updateResult = sysMenuManager.Update(model);
            return Ok(new
            {
                success=updateResult
            });
        }
    
    }
}