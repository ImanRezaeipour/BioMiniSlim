using System;
using BioMiniSlim.Core.Domains.Common;

namespace BioMiniSlim.Core.Domains.Persons
{
    public class PersonTemplate:BaseEntity
    {
        public virtual byte[] FingerTemplate { get; set; }

        public virtual string FingerImage { get; set; }

        public virtual Person Person { get; set; }

        public virtual long? PersonId { get; set; }
    }
}
