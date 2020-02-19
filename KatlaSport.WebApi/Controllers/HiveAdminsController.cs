using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.HiveManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

#pragma warning disable 1591

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/hiveAdmins")]
    [EnableCors("*", "*", "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class HiveAdminsController : ApiController
    {
        private readonly IHiveAdminService _adminService;

        public HiveAdminsController(IHiveAdminService adminService)
        {
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of hive admins.", Type = typeof(HiveAdmin))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveAdmins()
        {
            var admins = await _adminService.GetHiveAdminsAsync();
            return Ok(admins);
        }

        [HttpGet]
        [Route("{hiveAdminId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a hive admin.", Type = typeof(HiveAdmin))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveAdmin(int hiveAdminId)
        {
            var hive = await _adminService.GetHiveAdminAsync(hiveAdminId);
            return Ok(hive);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new hive admin.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddHiveAdmin([FromBody] UpdateHiveAdminRequest updateHiveAdminRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hiveAdmin = await _adminService.CreateHiveAdminAsync(updateHiveAdminRequest);
            var location = $"/api/hiveAdmins/{hiveAdmin.Id}";
            return Created(location, hiveAdmin);
        }
    }
}