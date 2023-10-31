using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tarteeb.XChanger.Models.Foundations.Applicants;
using Tarteeb.XChanger.Models.Foundations.Applicants.Exceptions;
using Xeptions;
using Xunit.Sdk;

namespace Tarteeb.XChanger.Tests.Services.Foundations.Applicants
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfApplicantIsNullAndLogItAsync()
        {
            //given
            ExternalApplicantModel noApplicant = null;
            var nullApplicantException = new NullApplicantException();

            var expectedApplicantValidationException = new ApplicantValidationException(nullApplicantException);

            //when
            ValueTask<ExternalApplicantModel> addApplicantTask = 
                this.applicantService.AddApplicantAsync(noApplicant);

            ApplicantValidationException actualApplicantVAlidationException =
                await Assert.ThrowsAsync<ApplicantValidationException>(addApplicantTask.AsTask);

            //then
            actualApplicantVAlidationException.Should().BeEquivalentTo(
                expectedApplicantValidationException);

            this.loggingBrokerMock.Verify(broker=>
            broker.LogError(It.Is(SameExceptionAs(
                expectedApplicantValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker=>
            broker.InsertExternalApplicantModelAsync(It.IsAny<ExternalApplicantModel>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();


        }

        
        
    }
}
