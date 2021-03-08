using System.Collections.Generic;
using System.Runtime.InteropServices;
using BioMiniSlim.Core.Domains.Common;

namespace BioMiniSlim.Core.Domains.Persons
{
    public class Person: BaseEntity
    {
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual GenderType Gender { get; set; }

        public virtual string NationalCode { get; set; }

        public virtual ICollection<PersonTemplate> Templates { get; set; }
    }
}
