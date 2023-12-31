﻿//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Threading.Tasks;
using Tarteeb.XChanger.Models.Foundations.Groups.Exceptions.Categories;
using Tarteeb.XChanger.Models.Proccesings.Group;
using Xeptions;
using ApplicantsGroup = Tarteeb.XChanger.Models.Foundations.Groups.Group;
namespace Tarteeb.XChanger.Services.Proccesings.Group
{
    public partial class GroupProccesingService
    {
        private delegate ValueTask<ApplicantsGroup> ReturningGroupsFunctions();

        private async ValueTask<ApplicantsGroup> TryCatch(ReturningGroupsFunctions returningGroupsFunctions)
        {
            try
            {
                return await returningGroupsFunctions();
            }
            catch (GroupValidationException groupValidationException)
            {
                throw CreateAndLogGroupProccesingValidationException(groupValidationException.InnerException as Xeption);
            }
            catch (GroupDependencyException groupDependencyException)
            {
                throw CreateAndLogGroupProccesingDependencException(groupDependencyException.InnerException as Xeption);
            }
            catch (GroupDependencyValidationException groupDependencyValidationException)
            {
                throw CreateAndLogGroupProccesingDependencValidationException(groupDependencyValidationException.InnerException as Xeption);
            }
            catch (GroupServiceException groupServiceException)
            {
                throw CreateAndLogGroupProccesingServiceException(groupServiceException.InnerException as Xeption);
            }
        }

        private GroupProccesingServiceException CreateAndLogGroupProccesingServiceException(Xeption xeption)
        {
            var groupProccesingServiceException =
                new GroupProccesingServiceException(xeption);

            this.loggingBroker.LogError(groupProccesingServiceException);

            return groupProccesingServiceException;
        }

        private GroupProccesingDependencyException CreateAndLogGroupProccesingDependencException(Xeption xeption)
        {
            var groupProccesingDependencyException =
                new GroupProccesingDependencyException(xeption);

            this.loggingBroker.LogError(groupProccesingDependencyException);

            return groupProccesingDependencyException;
        }

        private GroupProccesingDependencValidationException CreateAndLogGroupProccesingDependencValidationException(Xeption xeption)
        {
            var groupProccesingDependencValidationException =
                new GroupProccesingDependencValidationException(xeption);

            this.loggingBroker.LogError(groupProccesingDependencValidationException);

            return groupProccesingDependencValidationException;
        }

        private GroupProccesingValidationException CreateAndLogGroupProccesingValidationException(Xeption xeption)
        {
            var groupProccesingValidationException =
                new GroupProccesingValidationException(xeption);

            this.loggingBroker.LogError(xeption);

            return groupProccesingValidationException;
        }
    }
}
