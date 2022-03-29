using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class LocationValidator : AbstractValidator<LocationEditDto>
    {
        public LocationValidator() 
        {
            RuleFor(l => l.Name).NotEmpty();
            RuleFor(l => l.Name).MinimumLength(2);
            RuleFor(l => l.OpeningTime).NotEmpty();
            RuleFor(l => l.OpeningTime).Must(GreaterThan).WithMessage("Saat 08:00'dan önce açılamaz.");
            RuleFor(l => l.ClosingTime).NotEmpty();
            RuleFor(l => l.ClosingTime).Must(SmallerThan).WithMessage("Kapanma saati en geç 20:00 olabilir.");
            RuleFor(l => l.TimeZoneId).NotEmpty();
        }

        private bool GreaterThan(DateTime dateTime)
        {
            return dateTime.TimeOfDay >= TimeSpan.FromHours(8);
        }

        private bool SmallerThan(DateTime dateTime)
        {
            return dateTime.TimeOfDay <= TimeSpan.FromHours(20);
        }
    }
}
