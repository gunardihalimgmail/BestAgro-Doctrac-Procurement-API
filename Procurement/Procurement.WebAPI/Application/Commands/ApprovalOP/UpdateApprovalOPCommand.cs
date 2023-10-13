using BestAgroCore.Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Procurement.WebAPI.Application.Commands.ApprovalOP
{
    public class UpdateApprovalOPCommand: ICommand
    {
        public int ID_Ms_Login { get; set; }
        public List<string> ID_Ps_OP { get; set; }


    }
}
