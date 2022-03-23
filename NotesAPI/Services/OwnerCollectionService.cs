using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Services
{
    public class OwnerCollectionService : ICollectionService<Owner>
    {
        private List<Owner> _owners = new List<Owner> { new Owner { Id = new Guid("00000000-0000-0000-0000-000000000001"), Name="A" },
        new Owner {  Id = new Guid("00000000-0000-0000-0000-000000000002"), Name="B"} };
        public bool Create(Owner model)
        {
            var searchIndex = _owners.FindIndex(owner => owner.Id.Equals(model.Id));
            if (searchIndex != -1)
            {
                _owners.Add(model);
                return true;
            }
            return false;
        }

        public bool Delete(Guid id)
        {
            var searchIndex = _owners.FindIndex(owner => owner.Id.Equals(id));
            if (searchIndex != -1)
            {
                _owners.RemoveAt(searchIndex);
                return true;
            }
            return false;
        }

        public Owner Get(Guid id)
        {
            var searchIndex = _owners.FindIndex(owner => owner.Id.Equals(id));
            if (searchIndex != -1)
            {
                return _owners.ElementAt(searchIndex);
            }
            return null;
        }

        public List<Owner> GetAll()
        {
            return _owners;
        }

        public bool Update(Guid id, Owner model)
        {
            var searchIndex = _owners.FindIndex(owner => owner.Id.Equals(id));
            if (searchIndex != -1)
            {
                _owners[searchIndex] = model;
                return true;
            }
            return false;
        }
    }
}
