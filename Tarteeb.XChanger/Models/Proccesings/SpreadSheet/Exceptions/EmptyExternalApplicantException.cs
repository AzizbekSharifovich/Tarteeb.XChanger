//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace Tarteeb.XChanger.Models.Proccesings.SpreadSheet.Exceptions
{
    public class EmptyExternalApplicantException : Xeption
    {
        public EmptyExternalApplicantException()
            : base("Spreadsheet is empty")
        { }
    }
}
