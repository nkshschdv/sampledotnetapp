
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Technossus.Reincarnation.Core.Interfaces;
using Technossus.Reincarnation.Models;

namespace Technossus.Reincarnation.WebApi.Controllers
{
    public class UploadController : BaseApiController
    {
        private readonly IUploadManager _manager;
        public UploadController(IUploadManager manager)
        {
            _manager = manager;
        }
        [HttpPost]
        [Route("UploadFile")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> UploadFile(File file)
        {
            return Ok(await Task.FromResult(_manager.UploadFileToBlob(file)));
        }
    }
}

