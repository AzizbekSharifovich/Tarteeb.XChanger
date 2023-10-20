//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Linq;
using System.Threading.Tasks;

namespace Tarteeb.XChanger.Services.Foundations.Group
{
    public interface IGroupService
    {
        Task<Models.Foundations.Groups.Group> AddGroupAsyc(Models.Foundations.Groups.Group group);
        IQueryable<Models.Foundations.Groups.Group> RetrieveAllGroups();
    }
}
