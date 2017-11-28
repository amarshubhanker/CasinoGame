using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Shared
{
    public class CasinoValidationResult
    {
        public IList<CasinoValidationFailure> Errors { get; private set; }

        public bool IsValid
        {
            get { return Errors == null || Errors.Count == 0; }
        }

        public CasinoValidationResult(IList<CasinoValidationFailure> failures)
        {
            Errors = failures;
        }

        public CasinoValidationResult()
        {
            Errors = new List<CasinoValidationFailure>();
        }
    }
}
