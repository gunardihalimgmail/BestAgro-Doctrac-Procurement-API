using BestAgroCore.Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Procurement.Domain.DTO.TTISApproval;

namespace Procurement.WebAPI.Application.Commands.ApprovalTTIS
{
    public class UpdateMultipleApprovalTTISCommand : ICommand
    {
        public int id_ms_login { get; set; }
        //public List<TTISApproval> dokumenTTIS { get; set; }
        public List<string> ttisID { get; set; }
    }
}
