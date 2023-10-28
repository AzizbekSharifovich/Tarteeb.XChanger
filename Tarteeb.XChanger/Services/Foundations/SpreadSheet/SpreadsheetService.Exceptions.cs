//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Collections.Generic;
using Tarteeb.XChanger.Models.Foundations.Applicants;
using Tarteeb.XChanger.Models.Foundations.Applicants.Exceptions;
using Tarteeb.XChanger.Models.Foundations.SpreadSheets.Exceptions;
using Xeptions;

namespace Tarteeb.XChanger.Services.Foundations.SpreadSheet
{
    public partial class SpreadsheetService
    {
        private delegate List<ExternalApplicantModel> ReturningExternalApplicantFunction();

        private List<ExternalApplicantModel> TryCatch(ReturningExternalApplicantFunction returningExternalApplicantFunction)
        {
            try
            {
                return returningExternalApplicantFunction();
            }
            catch (NullSpreadSheetException nullSpreadSheetException)
            {
                throw CreateAndLogValidationException(nullSpreadSheetException);
            }
        }

        private SpreadSheetValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var spreadSheetValidationException = 
                new SpreadSheetValidationException(xeption);

            this.loggingBroker.LogError(spreadSheetValidationException);
            
            return spreadSheetValidationException;
        }
    }
}
