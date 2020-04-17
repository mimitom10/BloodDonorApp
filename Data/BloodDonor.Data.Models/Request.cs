﻿using BloodDonor.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BloodDonor.Data.Models
{
    public class Request : BaseDeletableModel<string>
    {
        public Request()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [Range(1, 5)]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(50)]
        public string MedicalCondition { get; set; }

        [MaxLength(300)]
        public string PeronalMessage { get; set; }

        [Required]
        public string PatientId { get; set; }

        public virtual Patient Patient { get; set; }

    }

}
