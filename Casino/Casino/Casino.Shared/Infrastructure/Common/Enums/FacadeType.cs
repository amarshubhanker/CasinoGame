using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Shared
{
    /// <summary>
    /// The Facade Types
    /// </summary>
    public enum FacadeType
    {
        /// <summary>
        /// Undefined Facade Type (Default)
        /// </summary>
        Undefined = 0,


        [QualifiedTypeName("Casino.BusinessFacades.dll", "Casino.BusinessFacades.CustomerFacade")]
        CustomerFacade = 1,

        [QualifiedTypeName("Casino.BusinessFacades.dll", "Casino.BusinessFacades.RouletteFacade")]
        RouletteFacade = 2

    }
}
