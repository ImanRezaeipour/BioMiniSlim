using System;
using System.Collections.Generic;
using BioMiniSlim.Core.Domains.Persons;
using BioMiniSlim.Core.Models;

namespace BioMiniSlim.Service.Services.Persons
{
    public interface IPersonService
    {
        List<PersonModel> GetAll();
        Person CreateByModel(PersonModel model);
        PersonModel GetModelById(Int64 id);
        Person EditByModel(PersonModel model);
        Person FindByTemplate(byte[] template);
        bool DeleteById(long id);
    }
}