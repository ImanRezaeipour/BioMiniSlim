using System;
using BioMiniSlim.Core.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using BioMiniSlim.Core.Domains.Persons;
using BioMiniSlim.Data.UnitOfWork;
using BioMiniSlim.Service.Services.Device;

namespace BioMiniSlim.Service.Services.Persons
{
    public class PersonService : IPersonService
    {
        #region Private Fields

        private readonly IDbSet<Person> _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDeviceManager _deviceManager;

        #endregion Private Fields

        #region Public Constructors

        public PersonService(IUnitOfWork unitOfWork, IDeviceManager deviceManager)
        {
            _unitOfWork = unitOfWork;
            _deviceManager = deviceManager;
            _personRepository = unitOfWork.Repository<Person>();
        }

        #endregion Public Constructors

        #region Public Methods

        public List<PersonModel> GetAll()
        {
            var persons = _personRepository.AsNoTracking().ToList();
            var model = persons.Select(m => new PersonModel
            {
                FirstName = m.FirstName,
                Gender = m.Gender,
                Id = m.Id,
                LastName = m.LastName,
                CreatedOn = m.CreatedOn,
                NationalCode = m.NationalCode
            }).ToList();

            return model;
        }

        public PersonModel GetModelById(Int64 id)
        {
            var person = _personRepository.Include(m => m.Templates).FirstOrDefault(m => m.Id == id);

            var model = new PersonModel
            {
                Image = person.Templates.FirstOrDefault().FingerImage,
                Id = person.Id,
                CreatedOn = person.CreatedOn,
                FirstName = person.FirstName,
                NationalCode = person.NationalCode,
                Gender = person.Gender,
                LastName = person.LastName,
                Template = person.Templates.FirstOrDefault().FingerTemplate
            };

            return model;
        }

        public Person CreateByModel(PersonModel model)
        {
            var person = new Person
            {
                FirstName = model.FirstName,
                Gender = model.Gender,
                LastName = model.LastName,
                Id = new Random(1).Next(),
                CreatedOn = model.CreatedOn,
                NationalCode = model.NationalCode
            };

            var template = new PersonTemplate
            {
                Id = new Random(1).Next(),
                FingerTemplate = model.Template,
                FingerImage = model.Image
            };
            if(person.Templates == null)
                person.Templates = new HashSet<PersonTemplate>();
            person.Templates.Add(template);

            _personRepository.Add(person);

            _unitOfWork.CommitAllChanges();

            return person;
        }



        public Person EditByModel(PersonModel model)
        {
            var person = _personRepository.Find(model.Id);
            person.FirstName = model.FirstName;
            person.LastName = model.LastName;
            person.NationalCode = model.NationalCode;
            
            var template = new PersonTemplate
            {
                FingerImage = model.Image,
                FingerTemplate = model.Template,
                Id = new Random(1).Next()
            };

            person.Templates.Clear();
            if (person.Templates == null)
                person.Templates = new HashSet<PersonTemplate>();
            person.Templates.Add(template);

            _unitOfWork.CommitAllChanges();

            return person;
        }

        public Person FindByTemplate(byte[] template)
        {

            var persons = _personRepository.Include(model => model.Templates).ToList();

            foreach (var person in persons)
            {
                var result = _deviceManager.Match(template, person.Templates.FirstOrDefault()?.FingerTemplate);
                if (result)
                    return person;
            }
            return null;
        }

        public bool DeleteById(long id)
        {
            var person = _personRepository.FirstOrDefault(model => model.Id == id);
            if (person == null)
                return true;

            _personRepository.Remove(person);
            _unitOfWork.CommitAllChanges();
            return true;
        }

        #endregion Public Methods
    }
}