//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Moq;
using System.Linq.Expressions;
using Tarteeb.XChanger.Brokers.DateTimes;
using Tarteeb.XChanger.Brokers.Loggings;
using Tarteeb.XChanger.Brokers.Storages;
using Tarteeb.XChanger.Models.Foundations.Applicants;
using Tarteeb.XChanger.Services.Foundations.Applicants;
using Tynamix.ObjectFiller;
using Xeptions;

namespace Tarteeb.XChanger.Tests.Services.Foundations.Applicants
{
    public partial class ApplicantServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IApplicantService applicantService;

        public ApplicantServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.applicantService = new ApplicantService(
               storageBroker: this.storageBrokerMock.Object,
               dateTimeBroker: this.dateTimeBrokerMock.Object,
               loggingBroker: this.loggingBrokerMock.Object);
        }
        private ExternalApplicantModel CreateRandomApplicant() =>
            CreateApplicantFiller().Create();

        private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);
        
        private Filler<ExternalApplicantModel> CreateApplicantFiller()
        {
            var filler = new Filler<ExternalApplicantModel>();
            return filler;
        }
    }
}
