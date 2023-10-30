//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Threading.Tasks;
using Tarteeb.XChanger.Models.Orchestrations.ExternalApplicants.Exceptions;
using Tarteeb.XChanger.Models.Proccesings.SpreadSheet.Exceptions;
using Xeptions;

namespace Tarteeb.XChanger.Services.Orchestrations
{
    public partial class OrchestrationService
    {
        public delegate Task ReturningExternalApplicantFunction();

        public async Task TryCatch(ReturningExternalApplicantFunction returningExternalApplicantFunction)
        {
            try
            {
                await returningExternalApplicantFunction();
            }
            catch (SpreadSheetProccesingValidationException spreadSheetProccesingValidationException)
            {
                
                throw CreateAndLogValidationException(spreadSheetProccesingValidationException.InnerException as Xeption);
            }
        }

        private ExternalApplicantOrchestrationValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var externalApplicantOrchestrationValidationException =
                new ExternalApplicantOrchestrationValidationException(xeption);
            
            this.loggingBroker.LogError(externalApplicantOrchestrationValidationException);

            return externalApplicantOrchestrationValidationException;
        }
    }
}
