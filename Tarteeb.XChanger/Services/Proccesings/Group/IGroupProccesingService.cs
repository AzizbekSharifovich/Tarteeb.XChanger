//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Threading.Tasks;

namespace Tarteeb.XChanger.Services.Proccesings.Group
{
    public interface IGroupProccesingService
    {
        ValueTask<Models.Group> EnsureGroupExistsByName(string name);
        Models.Group RetrieveGroupByName(string name);
    }
}
