﻿// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Example.ConsoleApp.Models.Samples;
using Example.ConsoleApp.Models.Samples.Exceptions;
using System;
using System.Collections.Generic;
using Xeptions;

namespace Example.ConsoleApp.Services.Foundations.Samples
{
    public partial class SampleService
    {
        private delegate Sample ReturningSampleFunction();
        private delegate List<Sample> ReturningSamplesFunction();

        private Sample TryCatch(ReturningSampleFunction returningSampleFunction)
        {
            try
            {
                return returningSampleFunction();
            }
            catch (NullSampleException nullSampleException)
            {
                throw CreateAndLogValidationException(nullSampleException);
            }
            catch (InvalidSampleException invalidSampleException)
            {
                throw CreateAndLogValidationException(invalidSampleException);
            }
            catch (Exception exception)
            {
                var failedSampleServiceException = new FailedSampleServiceException(exception);

                throw CreateAndLogServiceException(failedSampleServiceException);
            }
        }

        private List<Sample> TryCatch(ReturningSamplesFunction returningSamplesFunction)
        {
            try
            {
                return returningSamplesFunction();
            }
            catch (Exception exception)
            {
                var failedSampleServiceException = new FailedSampleServiceException(exception);

                throw CreateAndLogServiceException(failedSampleServiceException);
            }
        }

        private SampleValidationException CreateAndLogValidationException(Xeption exception)
        {
            var sampleValidationException = new SampleValidationException(exception);
            this.loggingBroker.LogError(sampleValidationException);

            return sampleValidationException;
        }

        private SampleServiceException CreateAndLogServiceException(Xeption exception)
        {
            var sampleServiceException = new SampleServiceException(exception);
            this.loggingBroker.LogError(sampleServiceException);

            return sampleServiceException;
        }
    }
}
