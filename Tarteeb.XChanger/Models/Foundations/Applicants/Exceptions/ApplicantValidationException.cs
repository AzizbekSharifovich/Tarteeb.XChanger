//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.Applicants.Exceptions
{
    public class ApplicantValidationException: Xeption
    {
        public ApplicantValidationException(Exception innerException) 
        :base("Applicant validation error ocured,fix the error and try again",innerException)
        { }
    }
}
