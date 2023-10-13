using BestAgroCore.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procurement.WebAPI.Application.Commands.ApprovalTTIS
{
    public class UpdateApprovalTTISCommand : ICommand
    {
        public int id_ps_ttis { get; set; }
        public int id_ms_login { get; set; }
    }
}
