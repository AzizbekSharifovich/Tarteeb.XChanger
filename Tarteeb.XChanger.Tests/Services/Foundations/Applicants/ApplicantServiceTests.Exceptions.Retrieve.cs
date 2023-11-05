using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarteeb.XChanger.Models.Foundations.Groups.Exceptions.Categories;
using Tarteeb.XChanger.Models.Foundations.Groups.Exceptions;
using Tarteeb.XChanger.Models.Foundations.Applicants.Exceptions;
using FluentAssertions;

namespace Tarteeb.XChanger.Tests.Services.Foundations.Applicants
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        private async Task ShouldThrowApplicantServiceExceptionOnRetrieveAllServiceErrorOccursAndLogIt()
        {
            //given
            string randomMessage = GetRandomString();

            Exception exception = new Exception(randomMessage);

            var failedApplicantServiceException =
                new FailedApplicantServiceException(exception);

            var expectedApplicantServiceException =
                new ApplicantServiceException(failedApplicantServiceException);

            this.storageBrokerMock.Setup(broker =>
            broker.RetrieveAllExternalApplicantModels()).Throws(failedApplicantServiceException);
            //when
            Action retrieveAllApplicantAction = () =>
                this.applicantService.RetrieveAllExternalApplicantModels();

            ApplicantServiceException actualApplicantServiceException =
                Assert.Throws<ApplicantServiceException>(retrieveAllApplicantAction);
            //then

            actualApplicantServiceException.Should().BeEquivalentTo(expectedApplicantServiceException);

            this.storageBrokerMock.Verify(broker =>
            broker.RetrieveAllExternalApplicantModels(), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAss(
                    expectedApplicantServiceException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
