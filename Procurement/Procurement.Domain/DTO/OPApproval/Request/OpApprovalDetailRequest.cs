using System;
using System.Collections.Generic;
using System.Text;

namespace Procurement.Domain.DTO.OPApproval.Request
{
    public class OpApprovalDetailRequest
    {
        public int id_ps_op { get; set; }
        public int id_ms_login { get; set; }
    }

    public class CountRequest
    {
        public int id_ms_login { get; set; }
        public string storedProcedure { get; set; }
    }
}
