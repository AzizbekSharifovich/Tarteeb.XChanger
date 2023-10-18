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
        Task<Models.Group> AddGroupAsyc(Models.Group group);
        IQueryable<Models.Group> RetrieveAllGroups();
    }
}
