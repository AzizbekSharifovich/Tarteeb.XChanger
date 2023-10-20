//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.SpreadSheets.Exceptions
{
    public class SpreadSheetValidationException : Xeption
    {
        public SpreadSheetValidationException(Xeption innerException)
            : base("Spreadsheet validation error occured. Fix the errors and try again", innerException)
        { }
    }
}
