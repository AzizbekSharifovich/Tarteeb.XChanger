//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.SpreadSheets.Exceptions.Categories;

public class SpreadSheetDependecyValidationException : Xeption
{
    public SpreadSheetDependecyValidationException(Xeption innerException)
        : base(message: "Spread sheet dependecy validation error occered, fix the errors and try again.",
            innerException)
    { }
}