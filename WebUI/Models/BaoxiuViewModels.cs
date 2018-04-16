using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class BaoxiuViewModels
    {
        public class CreateViewModel
        {
            [Required]
            [Display(Name = "联系人姓名")]
            public string UserName { get; set; }

            [Required]
            [Display(Name = "手机号码", Description = "Des用于接收维修状态信息短信", Prompt = "pro用于接收维修状态信息短信")]
            public string UserMobilePhone { get; set; }

            
            [Display(Name = "故障现象")]
            public string FaultPhenomenon { get; set; }
        }
    }
}