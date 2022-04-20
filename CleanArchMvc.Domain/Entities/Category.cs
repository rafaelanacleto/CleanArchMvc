using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {        
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                "O campos name não pode ser vazio");

            DomainExceptionValidation.When(name.Length <3,
               "O campos name não pode ter menos de 3 caracteres.");

            Name = name;
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ICollection<Product> Products { get; private set; }

    }
}
