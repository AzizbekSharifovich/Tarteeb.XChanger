﻿//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Linq.Expressions;
using Moq;
using Tarteeb.XChanger.Brokers.DateTimes;
using Tarteeb.XChanger.Brokers.Loggings;
using Tarteeb.XChanger.Brokers.Storages;
using Tarteeb.XChanger.Models.Foundations.Groups.Exceptions.Categories;
using Tarteeb.XChanger.Services.Foundations.Group;
using Tynamix.ObjectFiller;
using Xeptions;
using ApplicantGroup = Tarteeb.XChanger.Models.Foundations.Groups.Group;
namespace Tarteeb.XChanger.Tests.Services.Foundations.Groups
{
    public partial class GroupServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;


        private readonly GroupService groupService;

        public GroupServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            groupService = new GroupService(
                this.storageBrokerMock.Object,
                this.dateTimeBrokerMock.Object, 
                this.loggingBrokerMock.Object);
        }

        private ApplicantGroup CreateRandomGroup() =>
            CreateGroupFiller().Create();

        private Filler<ApplicantGroup> CreateGroupFiller()
        {
            var filler = new Filler<ApplicantGroup>();
            return filler;
        }


        private Expression<Func<Xeption, bool>> SameExceptionAss(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        private string GetRandomString() =>
              new MnemonicString().GetValue();
    }
}
