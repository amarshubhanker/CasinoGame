using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Casino.Shared
{
    public static class Constants
    {
        public const decimal MAX_DECIMAL = (decimal)9999999999999999.99;
        public const int NameMinLength = 1;
        public const int NameMaxLength = 30;
        public const int MinimumBalance = 0;


        public static class CustomerMessages
        {
            public const string CommonRuleSet = "Common";
            public const string AddBalanceRuleSet = "AddBalance";

            public const string EmailCreateRuleSet = "EmailCreate";
            public const string EmailUpdateRuleSet = "EmailUpdate";

            public const string EmailId = "EmailId";
            public const string EmailMandatory = "Email Id is a mandatory field.";
            public const string EmailValid = "Email Id should be valid.";
            public const string EmailCharacterLimit = "Email Id should be less than 100 characters.";

            public const string Name = "Name";
            public const string NameFormat = "Name should contain only alphabets and spaces";
            public const string NameMandatory = "Name is a mandatory field.";
            public const string NameCharacterLimit = "Name should be less than 50 characters.";

            public const string Balance = "Account Balance";
            public const string BalanceMandatory = "Account Balance is a mandatory field.";
            public const string BalanceExceedsMaximum = "Balance is greater than maximum balance";
            public const string BalanceLessThanMinimum = "Balance is less than minimum balance";            

            public const string CreateSuccess = "Create user successful.";
            public const string CreateFailure = "Create user failed.";

            public const string UpdateSuccess = "Update user successful.";
            public const string UpdateFailure = "Update user failed.";

            public const string SearchSuccess = "Search for user successful.";
            public const string SearchFailure = "Search for user failed.";
        }
    }
}
