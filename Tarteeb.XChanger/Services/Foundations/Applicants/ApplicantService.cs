//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Tarteeb.XChanger.Brokers.Loggings;
using Tarteeb.XChanger.Brokers.Storages;
using Tarteeb.XChanger.Models.Foundations.Applicants;

namespace Tarteeb.XChanger.Services.Foundations.Applicants
{
    public partial class ApplicantService : IApplicantService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        public ApplicantService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }
        public async ValueTask<ExternalApplicantModel> InsertApplicantAsync(ExternalApplicantModel externalApplicantModel) =>
            await storageBroker.InsertExternalApplicantModelAsync(externalApplicantModel);

        public ValueTask<ExternalApplicantModel> RetrieveApplicantByIdAsync(Guid applicantId)
        {
            return this.storageBroker.SelectExternalApplicantModelIdAsync(applicantId);
        }
        public IQueryable RetrieveAllApplicants()
        {
            throw new NotImplementedException();
        }
        public ValueTask<ExternalApplicantModel> ModifyExternalApplicantAsync(ExternalApplicantModel externalApplicantModel)
        {
            throw new NotImplementedException();
        }
        public async ValueTask<ExternalApplicantModel> RemoveApplicantAsync(Guid guid)
        {
            var selectedApp = await this.storageBroker.SelectExternalApplicantModelIdAsync(guid);
            return await this.storageBroker.DeleteExternalApplicantModelAsync(selectedApp);
        }
    }
}
