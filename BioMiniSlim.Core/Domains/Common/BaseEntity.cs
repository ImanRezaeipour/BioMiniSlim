using System;

namespace BioMiniSlim.Core.Domains.Common
{
    public class BaseEntity
    {
        public virtual long Id { get; set; }

        public virtual byte[] RowVersion { get; set; }

        public virtual DateTime? CreatedOn { get; set; }
    }
}
