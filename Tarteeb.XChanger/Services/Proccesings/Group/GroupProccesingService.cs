//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Tarteeb.XChanger.Services.Foundations.Group;
using ApplicantsGroup = Tarteeb.XChanger.Models.Foundations.Groups.Group;

namespace Tarteeb.XChanger.Services.Proccesings.Group
{
    public class GroupProccesingService : IGroupProccesingService
    {
        private readonly IGroupService groupService;

        public GroupProccesingService(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        public async ValueTask<ApplicantsGroup> EnsureGroupExistsByName(string name)
        {
            ApplicantsGroup maybeGroup = RetrieveGroupByName(name);

            return maybeGroup is null ? await AddGroupAsync(name) : maybeGroup;
        }

        private async ValueTask<ApplicantsGroup> AddGroupAsync(string name)
        {
            ApplicantsGroup group = new ApplicantsGroup();

            group.Id = Guid.NewGuid();
            group.GroupName = name;

            return await groupService.AddGroupAsyc(group);
        }

        public ApplicantsGroup RetrieveGroupByName(string name)
        {
            IQueryable<Models.Foundations.Groups.Group> Groups = groupService.RetrieveAllGroups();
            ApplicantsGroup group = 
                Groups.FirstOrDefault(groupName => groupName.GroupName == name);

            return group;
        }
    }
}
