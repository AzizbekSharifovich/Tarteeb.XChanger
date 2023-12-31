﻿//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Tarteeb.XChanger.Models.Foundations.Groups;

namespace Tarteeb.XChanger.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Group> InsertGroupAsync(Group group);
        IQueryable<Group> RetrieveAllGroups();
        ValueTask<Group> SelectGroupIdAsync(Guid id);
        ValueTask<Group> UpdateGroupAsync(Group group);
        ValueTask<Group> DeleteGroupAsync(Group group);
    }
}
