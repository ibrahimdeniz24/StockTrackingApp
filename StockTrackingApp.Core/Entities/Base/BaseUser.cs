using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Core.Entities.Base
{
    public abstract class BaseUser :AuditableEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; } = null!;
        //public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string? Image { get; set; }
        public string? IdentityId { get; set; }
    }
}
