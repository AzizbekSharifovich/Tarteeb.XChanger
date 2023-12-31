﻿//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace Tarteeb.XChanger.Models.Orchestrations.Groups
{
    public class GroupOchrestartionValidationException : Xeption
    {
        public GroupOchrestartionValidationException(Xeption innerException)
            : base("Group validate error occured. fix the errors", innerException)
        { }
    }
}
