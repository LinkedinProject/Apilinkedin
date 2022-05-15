using LinkedIn.core.Data;
using LinkedIn.core.Repository;
using LinkedIn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.infra.Service
{
  public  class ContactService: IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }


        public bool CreateContact(Contactu contactu)
        {
            return _contactRepository.CreateContact(contactu);
        }
        public bool UpdateContact(Contactu contactu)
        {
            return _contactRepository.UpdateContact(contactu);
        }
        public bool DeleteContact(int contactid)
        {
            return _contactRepository.DeleteContact(contactid);
        }
        public List<Contactu> GetAllContact()
        {
            return _contactRepository.GetAllContact();
        }
    }
}

