using EntitiesLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CarValidation
{
    public class CarValidation:AbstractValidator<Car>
    {
        public CarValidation()
        {
            RuleFor(x => x.CarName).NotNull().NotEmpty().WithMessage("Ürün adı Boş geçilemez!").WithMessage("Araba adı Boş geçilemez!").
              MinimumLength(2).WithMessage("Araba adı en az 1 karaktere sahip olmalı!").
              MaximumLength(30).WithMessage("Araba adı en fazla 35 karaktere sahip olmalı");

        }
    }
}
