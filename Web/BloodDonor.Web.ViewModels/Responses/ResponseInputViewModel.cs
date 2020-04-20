using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BloodDonor.Web.ViewModels.Responses
{
    public class ResponseInputViewModel
    {
        public string Details { get; set; }

        [Required]

        public bool IsAnonymous { get; set; }

        public bool IsConfirmed { get; set; }

        

    }
}
