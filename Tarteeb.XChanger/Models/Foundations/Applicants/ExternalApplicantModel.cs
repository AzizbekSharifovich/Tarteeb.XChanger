﻿//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;

namespace Tarteeb.XChanger.Models.Foundations.Applicants;

public class ExternalApplicantModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string GroupName { get; set; }
    public Guid GroupId { get; set; }
}
