//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Linq;
using System.Threading.Tasks;
using Tarteeb.XChanger.Brokers.Storages;

namespace Tarteeb.XChanger.Services.Foundations.Group
{
    public class GroupService : IGroupService
    {
        private readonly IStorageBroker storageBroker;

        public GroupService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async Task<Models.Foundations.Groups.Group> AddGroupAsyc(Models.Foundations.Groups.Group group) =>
            await storageBroker.InsertGroupAsync(group);

        public IQueryable<Models.Foundations.Groups.Group> RetrieveAllGroups() =>
             storageBroker.RetrieveAllGroups(); 
    }
}
