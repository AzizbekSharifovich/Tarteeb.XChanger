//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.Applicants.Exceptions
{
    public class ApplicantDependencyException :Xeption
    {
        public ApplicantDependencyException(Exception innerException) 
            : base("Applicant dependency error ocured.Fix the error and try again",innerException) 
        { }
    }
}
