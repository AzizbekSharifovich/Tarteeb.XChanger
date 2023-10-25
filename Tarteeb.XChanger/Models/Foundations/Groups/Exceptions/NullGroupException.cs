//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.Groups.Exceptions
{
    public class NullGroupException : Xeption
    {
        public NullGroupException()
            : base("Group is null")
        { }
    }
}
