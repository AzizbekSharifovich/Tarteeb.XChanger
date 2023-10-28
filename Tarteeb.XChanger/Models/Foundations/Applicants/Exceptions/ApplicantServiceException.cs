//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.Applicants.Exceptions
{
    public class ApplicantServiceException :Xeption
    {
        public ApplicantServiceException(Exception innerException) 
        :base("Applicant service error occured",innerException)
        { }
          
    }
}
