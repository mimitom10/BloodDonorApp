// ReSharper disable VirtualMemberCallInConstructor
namespace BloodDonor.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BloodDonor.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Notifications = new HashSet<Notification>();
           
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        // [Required]
        // [MaxLength(50)]
        // public string FullName { get; set; }

        // [Required]
        // public int LocationId { get; set; }
        // public virtual Location Location { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }


        public virtual Donor Donor { get; set; }

     //   public virtual Patient Patient { get; set; }

       
    }
}
