using FluentValidation.Results;
using Casino.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Validations
{
    public static class ValidationExtensions
    {
        public static CasinoValidationResult ToValidationResult(this ValidationResult result)
        {
            IList<CasinoValidationFailure> errors = new List<CasinoValidationFailure>();

            foreach (ValidationFailure failure in result.Errors)
            {
                errors.Add(failure.ToValidationFailure());
            }

            return new CasinoValidationResult(errors);
        }

        public static CasinoValidationFailure ToValidationFailure(this ValidationFailure failure)
        {
            return new CasinoValidationFailure(failure.PropertyName, failure.ErrorMessage, failure.AttemptedValue);
        }

    }
}
