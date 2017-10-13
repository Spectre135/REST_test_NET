using System.Web.Http;
using si.nkbm.porfu.RESTService;
using System.Net;
using si.nkbm.porfu.DTO;
using System.Net.Http;

public class PorocanjeController : ApiController
{

    [Route("api/porocanje/{searchString}")]
    public HttpResponseMessage Get(string searchString, int pageIndex, int pageSizeSelected, string sortKey, string asc)
    {
        RestService service = new RestService();
        FatcaDTO dto = new FatcaDTO();
        dto = service.GetFatcaDTO(searchString, pageIndex, pageSizeSelected, sortKey, asc);

        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, dto);

        return response;
    }

}
