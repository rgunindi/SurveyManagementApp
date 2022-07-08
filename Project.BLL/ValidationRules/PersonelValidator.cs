using FluentValidation;
using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ValidationRules
{
    public class PersonelValidator:AbstractValidator<Personel>
    {
        public PersonelValidator()
        {
            RuleFor(x => x.PersonelPassword).NotEmpty().WithMessage("Fill all fields!");
        }
    }
}
