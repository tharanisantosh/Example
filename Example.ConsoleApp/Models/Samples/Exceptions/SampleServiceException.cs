﻿// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace Example.ConsoleApp.Models.Samples.Exceptions
{
    public class SampleServiceException : Xeption
    {
        public SampleServiceException(Xeption innerException)
            : base(message: "Sample service error occurred, contact support.", innerException)
        { }
    }
}
