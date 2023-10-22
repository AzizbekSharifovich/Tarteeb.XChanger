//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;

namespace Tarteeb.XChanger.Brokers.DateTimes
{
    public interface IDateTimeBroker
    {
        DateTimeOffset GetCurrentDateTime();
    }
}
