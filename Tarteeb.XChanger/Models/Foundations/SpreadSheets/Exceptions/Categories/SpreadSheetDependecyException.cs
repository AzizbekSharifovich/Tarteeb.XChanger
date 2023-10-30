//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.SpreadSheets.Exceptions.Categories;

public class SpreadSheetDependecyException : Xeption
{
    public SpreadSheetDependecyException(Xeption innerException)
        : base(message: "Spread sheet dependecy error occered, contact support", innerException)
    { }
}