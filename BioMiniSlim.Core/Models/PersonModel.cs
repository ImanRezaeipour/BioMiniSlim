using BioMiniSlim.Core.Domains.Persons;
using System;

namespace BioMiniSlim.Core.Models
{
    public class PersonModel
    {
        #region Public Properties

        public DateTime? CreatedOn { get; set; }
        public string FirstName { get; set; }
        public GenderType Gender { get; set; }
        public long Id { get; set; }
        public string Image { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public byte[] Template { get; set; }

        #endregion Public Properties
    }
}