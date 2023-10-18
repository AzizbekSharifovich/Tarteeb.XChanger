//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Tarteeb.XChanger.Services.Foundations.Group;

namespace Tarteeb.XChanger.Services.Proccesings.Group
{
    public class GroupProccesingService : IGroupProccesingService
    {
        private readonly IGroupService groupService;

        public GroupProccesingService(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        public async ValueTask<Models.Group> EnsureGroupExistsByName(string name)
        {
            Models.Group maybeGroup = RetrieveGroupByName(name);

            return maybeGroup is null ? await AddGroupAsync(name) : maybeGroup;
        }

        private async ValueTask<Models.Group> AddGroupAsync(string name)
        {
            Models.Group group = new Models.Group();

            group.Id = Guid.NewGuid();
            group.GroupName = name;

            return await groupService.AddGroupAsyc(group);
        }

        public Models.Group RetrieveGroupByName(string name)
        {
            IQueryable<Models.Group> Groups = groupService.RetrieveAllGroups();
            Models.Group group = Groups.FirstOrDefault(groupName => groupName.GroupName == name);
            return group;
        }
    }
}
