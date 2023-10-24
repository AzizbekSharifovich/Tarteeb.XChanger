﻿//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================
using EFxceptions.Models.Exceptions;
using FluentAssertions;
using Moq;
using Tarteeb.XChanger.Models.Foundations.Groups.Exceptions;
using Tarteeb.XChanger.Models.Foundations.Groups.Exceptions.Categories;
using Tynamix.ObjectFiller;
using ApplicantsGroup = Tarteeb.XChanger.Models.Foundations.Groups.Group;
namespace Tarteeb.XChanger.Tests.Services.Foundations.Groups
{
    public partial class GroupServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAddIfDuplicateKeyErrorOccursAndLogItAsync()
        {
            //given
            string someMessage = GetRandomString();
            ApplicantsGroup randomGroup = CreateRandomGroup();

            var duplicateKeyException = 
                new DuplicateKeyException(someMessage);

            var alreadyExistsGroupException =
                new AlreadyExistsGroupException(duplicateKeyException);

            var excpectedGroupDependencyValidationException = 
                new GroupDependencyValidationException(alreadyExistsGroupException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertGroupAsync(randomGroup)).ThrowsAsync(duplicateKeyException);
            //when
            ValueTask<ApplicantsGroup> addGroupTask =
                   this.groupService.AddGroupAsyc(randomGroup);

            var actualGroupDependencyValidationException =
                await Assert.ThrowsAnyAsync<GroupDependencyValidationException>(addGroupTask.AsTask);
            //then

            actualGroupDependencyValidationException.
                Should().
                BeEquivalentTo(excpectedGroupDependencyValidationException);

            this.storageBrokerMock.Verify(broker =>
             broker.InsertGroupAsync(randomGroup), Times.Once);


            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAss(
                    excpectedGroupDependencyValidationException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
