//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.Applicants.Exceptions
{
    public class ApplicantProcessingValidationException :Xeption
    {
        public ApplicantProcessingValidationException(Exception innerException)
            : base("Applicant processing validation error ocured,fix error and try again",innerException) 
        { }
    }
}
