//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.SpreadSheets.Exceptions.Categories;

public class SpreadSheetServiceException : Xeption
{
    public SpreadSheetServiceException(Xeption innerException)
        : base(message: "Spread sheet service error occured, contact support.", innerException)
    { }  
}
