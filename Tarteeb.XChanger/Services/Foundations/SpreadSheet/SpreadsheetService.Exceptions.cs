//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Collections.Generic;
using EFxceptions.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using Tarteeb.XChanger.Models.Foundations.Applicants;
using Tarteeb.XChanger.Models.Foundations.SpreadSheets.Exceptions;
using Tarteeb.XChanger.Models.Foundations.SpreadSheets.Exceptions.Categories;
using Xeptions;

namespace Tarteeb.XChanger.Services.Foundations.SpreadSheet;

public partial class SpreadsheetService
{
    private delegate List<ExternalApplicantModel> ReturningExternalApplicantFunction();

    private List<ExternalApplicantModel> TryCatch(
        ReturningExternalApplicantFunction returningExternalApplicantFunction)
    {
        try
        {
            return returningExternalApplicantFunction();
        }
        catch (NullSpreadSheetException nullSpreadSheetException)
        {
            throw CreateAndLogValidationException(nullSpreadSheetException);
        }
        catch(InvalidSpreadSheetException invalidSpreadSheetException)
        {
            throw CreateAndLogValidationException(invalidSpreadSheetException);
        }
        catch(DuplicateKeyException duplicateKeyException)
        {
            var alreadyExistsSpreadSheetException = 
                new AlreadyExistsSpreadSheetException(duplicateKeyException);

            throw CreateDependecyValidationException(alreadyExistsSpreadSheetException);
        }
        catch(DbUpdateConcurrencyException dbUpdateConcurrencyException)
        {
            var lockedSpreadSheetException = 
                new LockedSpreadSheetException(dbUpdateConcurrencyException);

            throw CreateDependecyException(lockedSpreadSheetException);
        }
        catch(DbUpdateException dbUpdateException)
        {
            var failedStorageSpreadSheetException =
                new FailedStorageSpreadSheetException(dbUpdateException);

            throw CreateServiceException(failedStorageSpreadSheetException);
        }
        catch(Exception exception)
        {
            var failedServiceSpreadSheetException = new FailedServiceSpreadSheetException(exception);

            throw CreateServiceException(failedServiceSpreadSheetException);
        }
    }

    private SpreadSheetServiceException CreateServiceException(Xeption exception)
    {
        var spreadSheetServiceException = new SpreadSheetServiceException(exception);

        return spreadSheetServiceException;
    }

    private SpreadSheetDependecyException CreateDependecyException(Xeption exception)
    {
        var spreadSheetDependecyException = new SpreadSheetDependecyException(exception);

        return spreadSheetDependecyException;
    }

    private SpreadSheetDependecyValidationException CreateDependecyValidationException(Xeption exception)
    {
        var spreadSheetDependecyValidationException =
            new SpreadSheetDependecyValidationException(exception);

        return spreadSheetDependecyValidationException;
    }

    private SpreadSheetValidationException CreateAndLogValidationException(Xeption xeption)
    {
        var spreadSheetValidationException = 
            new SpreadSheetValidationException(xeption);

        this.loggingBroker.LogError(spreadSheetValidationException);
        
        return spreadSheetValidationException;
    }
}
