//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Threading.Tasks;

namespace Tarteeb.XChanger.Services.Proccesings.Group
{
    public interface IGroupProccesingService
    {
        ValueTask<Models.Foundations.Groups.Group> EnsureGroupExistsByName(string name);
        Models.Foundations.Groups.Group RetrieveGroupByName(string name);
    }
}
