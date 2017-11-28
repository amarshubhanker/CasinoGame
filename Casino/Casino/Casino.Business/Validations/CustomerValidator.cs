using FluentValidation;
using Casino.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Validations
{
    public class CustomerValidator : AbstractValidator<ICustomerDTO>
    {
        public CustomerValidator()
        {
            RuleSet(Constants.CustomerMessages.CommonRuleSet, () =>
            {
                RuleFor(customer => customer.Name).NotEmpty()
                                                        .WithMessage(Constants.CustomerMessages.NameMandatory)
                                                        .Length(Constants.NameMinLength, Constants.NameMaxLength)
                                                        .WithMessage(Constants.CustomerMessages.NameCharacterLimit)
                                                        .WithName(Constants.CustomerMessages.Name)
                                                        .Matches("^[a-zA-Z ]*$")
                                                        .WithName(Constants.CustomerMessages.NameFormat);
                RuleFor(customer => customer.EmailId).NotEmpty()
                                                   .WithMessage(Constants.CustomerMessages.EmailMandatory)
                                                   .EmailAddress()
                                                   .WithMessage(Constants.CustomerMessages.EmailValid)
                                                   .Length(1, 100)
                                                   .WithMessage(Constants.CustomerMessages.EmailCharacterLimit);
            });

            RuleSet(Constants.CustomerMessages.AddBalanceRuleSet, () =>
            {
                RuleFor(customer => customer.AccountBalance).NotEmpty()
                                                            .WithMessage(Constants.CustomerMessages.BalanceMandatory)
                                                            .LessThan(Constants.MAX_DECIMAL)
                                                            .WithMessage(Constants.CustomerMessages.BalanceExceedsMaximum)
                                                            .GreaterThan(Constants.MinimumBalance)
                                                            .WithMessage(Constants.CustomerMessages.BalanceLessThanMinimum);
            });
        }
    }
}
