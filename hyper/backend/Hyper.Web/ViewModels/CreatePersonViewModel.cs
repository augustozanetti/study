using System.Collections.Generic;
using Hyper.Domain.Entities;
using Hyper.Web.ExtensionMethod;
using Hyper.Web.Validation;

namespace Hyper.Web.ViewModels
{
    public class CreatePersonViewModel : Hyper.Web.Validation.Validation, IValidate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }

        public void Validate()
        {
            if (FirstName.IsNullOrEmpty() || LastName.IsNullOrEmpty())
            {
                AddNotification("0001", "Nome Inválido");
            }

            if (Email.IsNullOrEmpty())
                AddNotification("0002", "Email Inválido");
        }
    }
}