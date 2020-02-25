using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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

        [HttpPut]
        [Route("{hiveAdminId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed HiveAdmin.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateHiveAdmin([FromUri] int hiveAdminId, [FromBody] UpdateHiveAdminRequest updateHiveAdminRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _adminService.UpdateHiveAdminAsync(hiveAdminId, updateHiveAdminRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        //[HttpPost, Route("softwarepackage")]
        //[Route("{hiveAdminId:int:min(1)}/image")]
        //[SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed HiveAdmin image.")]
        //[SwaggerResponse(HttpStatusCode.BadRequest)]
        //[SwaggerResponse(HttpStatusCode.Conflict)]
        //[SwaggerResponse(HttpStatusCode.NotFound)]
        //[SwaggerResponse(HttpStatusCode.InternalServerError)]
        //public async Task<IHttpActionResult> UpdateHiveAdminImage([FromUri] int hiveAdminId, HttpPostedFileBase upload)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (upload != null && upload.ContentLength > 0)
        //    {
        //        var imageFile = new ImageFile {HiveAdminId = hiveAdminId, Name = Path.GetFileName(upload.FileName)};
        //        using (var reader = new BinaryReader(upload.InputStream))
        //        {
        //            imageFile.Content = reader.ReadBytes(upload.ContentLength);
        //        }

        //        await _adminService.UpdateHiveAdminImageAsync(hiveAdminId, imageFile);
        //    }

        //    return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        //}

        [HttpPost, Route("updatehiveadminimage")]
        public async Task<IHttpActionResult> UpdateHiveAdminImage()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);
                }
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e));
            }
        }
    }
}