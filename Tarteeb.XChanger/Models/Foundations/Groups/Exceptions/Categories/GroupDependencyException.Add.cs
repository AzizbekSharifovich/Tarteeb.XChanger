//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.Groups.Exceptions.Categories
{
    public class GroupDependencyException : Xeption
    {
        public GroupDependencyException(Xeption innerException)
            : base("group dependency error occured fix the errors", innerException)
        { }
    }
}
