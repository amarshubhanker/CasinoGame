using FluentValidation;
using Casino.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Validations
{
    public static class Validator<T, T1> where T : AbstractValidator<T1>, new()
    {
        public static CasinoValidationResult Validate(T1 dto)
        {
            T validator = new T();
            return validator.Validate(dto).ToValidationResult();
        }

        public static CasinoValidationResult Validate(T1 dto, string ruleSet)
        {
            T validator = new T();
            return validator.Validate(dto, ruleSet: ruleSet).ToValidationResult();
        }
    }
}
