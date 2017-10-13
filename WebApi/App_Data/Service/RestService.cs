using si.nkbm.porfu.DAO;
using si.nkbm.porfu.DTO;
using Newtonsoft.Json;

namespace si.nkbm.porfu.RESTService
{

    public class RestService
    {
        public FatcaDTO GetFatcaDTO(string SearchString, int pageIndex, int pageSelected, string sortKey, string asc)
        {
            DataDAO dao = new DataDAO();
            
            FatcaDTO dto = new FatcaDTO
            {
                DataList = dao.GetData(SearchString.Replace("undefined", ""), pageIndex, pageSelected, sortKey, asc),
                RowsCount = dao.GetRowsCount(SearchString)
            };

            //return JsonConvert.SerializeObject(dto, new JsonSerializerSettings() { DateFormatString = "dd.MM.yyyy" });

            return dto;

        }
    }
}
