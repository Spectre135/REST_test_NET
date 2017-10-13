using System.Collections.Generic;

namespace si.nkbm.porfu.DTO
{
    public class FatcaDTO
    {
        public IEnumerable<FatcaXmlBean> DataList { get; set; }

        public int RowsCount { get; set; }

    }
}
