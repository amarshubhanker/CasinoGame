using Nagarro.EmployeePortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ISampleDTO sampleDTO = (ISampleDTO)DTOFactory.Instance.Create(DTOType.SampleDTO);
            sampleDTO.SampleProperty1 = 1;
            sampleDTO.SampleProperty2 = "sample from web";

            ISampleFacade sampleFacade = (ISampleFacade)FacadeFactory.Instance.Create(FacadeType.SampleFacade);
            OperationResult<ISampleDTO> result = sampleFacade.SampleMethod(sampleDTO);
            if (result.IsValid())
            {
                var resultData = result.Data;
            }
        }
    }
}
