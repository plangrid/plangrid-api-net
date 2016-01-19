// <copyright file="RfisTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;

namespace PlanGrid.Api
{
    public class MultipartUploadException : Exception
    {
        public MultipartUploadException()
        {
        }

        public MultipartUploadException(string message) : base(message)
        {
        }

        public MultipartUploadException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
