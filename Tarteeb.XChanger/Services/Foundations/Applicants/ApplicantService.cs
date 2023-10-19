//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Threading.Tasks;
using Tarteeb.XChanger.Brokers.Storages;
using Tarteeb.XChanger.Models;

namespace Tarteeb.XChanger.Services.Foundations.Applicants
{
    public class ApplicantService : IApplicantService
    {
        private readonly IStorageBroker storageBroker;

        public ApplicantService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<ExternalApplicantModel> InsertApplicantAsync(ExternalApplicantModel externalApplicantModel) =>
            await storageBroker.InsertExternalApplicantModelAsync(externalApplicantModel);
    }
}
