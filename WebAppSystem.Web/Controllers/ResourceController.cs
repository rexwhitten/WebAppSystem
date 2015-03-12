using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using WebAppSystem.Web.Components;
using WebAppSystem.Web.Models;

namespace WebAppSystem.Web.Controllers
{
    [Authorize]
    [RoutePrefix("/api")]
    public class ResourceController : ODataController
    {
        #region [ Components ]
        private ResourceComponent component
        {
            get
            {
                return new ResourceComponent();
            }
        }
        #endregion

        [EnableQuery]
        public IQueryable<ResourceModel> Get([FromODataUri] String path)
        {
            return this.component.SelectByPath(path);
        }


        public async Task<IHttpActionResult> Post([FromODataUri] String path, ResourceModel model)
        {
            int version = this.component.Create(path, model);

            if (version > 1)
            {
                return Updated(model);
            }

            return Created(model);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] String path, ResourceModel model)
        {
            int version = this.component.Create(path, model);

            if (version > 1)
            {
                return Updated(model);
            }

            return Created(model);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] String path)
        {
            this.component.Delete(path);

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}
