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
    public class OrganizesController : ControllerBase
    {
        private readonly Sys_OrganizeManager sys_OrganizeManager = new Sys_OrganizeManager();

        // GET: api/Organizes
        [HttpGet]
        public object Get(string FullName, string MobilePhone, int PageIndex, int PageSize)
        {
            int totalNumber = 0;
            var dataList = sys_OrganizeManager.PageList(FullName, MobilePhone, PageIndex, PageSize, ref totalNumber);

            return Ok(new
            {
                success = true,
                page = PageIndex,
                pageCount = totalNumber,
                data = dataList
            });
        }

        // GET: api/Organizes/5
        [HttpGet("{id}", Name = "Get")]
        public object Get(int id)
        {
            var model = sys_OrganizeManager.GetById(id);
            return Ok(new
            {
                success = model != null,
                data = model
            });
        }

        // POST: api/Organizes
        [HttpPost]
        public object Post([FromBody] Sys_Organize model)
        {
            string currentUserName = "";
            model.F_CreatorTime=DateTime.Now;
            model.F_CreatorUserId = currentUserName;
            model.F_LastModifyTime=DateTime.Now;
            model.F_LastModifyUserId = currentUserName;

            var addResult = sys_OrganizeManager.Insert(model);
            return Ok(new
            {
                success=addResult
            });
        }

        // PUT: api/Organizes/5
        [HttpPut("{id}")]
        public object Put(int id, [FromBody] Sys_Organize model)
        {
            string currentUserName = "";
            
            model.F_LastModifyTime=DateTime.Now;
            model.F_LastModifyUserId = currentUserName;

            var updateResult = sys_OrganizeManager.Update(model);
            return Ok(new
            {
                success=updateResult
            });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            string currentUserName = "";

            var model =sys_OrganizeManager.GetById(id)?.First();
            if (model == null)
                return NotFound();
            
            model.F_DeleteMark=true;
            model.F_DeleteTime=DateTime.Now;
            model.F_LastModifyUserId = currentUserName;

            var updateResult = sys_OrganizeManager.Update(model);
            return Ok(new
            {
                success=updateResult
            });
        }
    }
}