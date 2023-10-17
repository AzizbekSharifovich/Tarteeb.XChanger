//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Microsoft.EntityFrameworkCore;
using Tarteeb.XChanger.Models;

namespace Tarteeb.XChanger.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<ExternalApplicantModel> ExternalApplicantModel { get; set; }
    }
}
