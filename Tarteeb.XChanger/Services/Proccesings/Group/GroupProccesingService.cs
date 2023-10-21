//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Tarteeb.XChanger.Models.Foundations.Groups;
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

        public async ValueTask<Models.Foundations.Groups.Group> EnsureGroupExistsByName(string name)
        {
            Models.Foundations.Groups.Group maybeGroup = RetrieveGroupByName(name);

            return maybeGroup is null ? await AddGroupAsync(name) : maybeGroup;
        }

        private async ValueTask<Models.Foundations.Groups.Group> AddGroupAsync(string name)
        {
            Models.Foundations.Groups.Group group = new Models.Foundations.Groups.Group();

            group.Id = Guid.NewGuid();
            group.GroupName = name;

            return await groupService.AddGroupAsyc(group);
        }

        public Models.Foundations.Groups.Group RetrieveGroupByName(string name)
        {
            IQueryable<Models.Foundations.Groups.Group> Groups = groupService.RetrieveAllGroups();
            Models.Foundations.Groups.Group group = Groups.FirstOrDefault(groupName => groupName.GroupName == name);
            return group;
        }
    }
}
