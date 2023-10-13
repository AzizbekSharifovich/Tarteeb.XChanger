﻿//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;

namespace Tarteeb.XChanger.Models;

public class ExternalApplicant
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Guid GroupId { get; set; }
    public string GroupName { get; set; }

}
