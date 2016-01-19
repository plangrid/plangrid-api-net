// <copyright file="Settings.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System.Configuration;

namespace PlanGrid.Api
{
    /// <summary>
    /// To configure these settings, add a line in your <appSettings></appSettings>.  For example:
    /// 
    /// <appSettings>
    ///     <add key="PlanGridApiKey" value="2DB9D3FB-624A-44DA-9CB3-982D0997D231" />
    /// </appSettings>
    /// 
    /// </summary>
    public static class Settings
    {
        public static readonly string ApiBaseUrl = ConfigurationManager.AppSettings["PlanGridApiBaseUrl"];
        public static readonly string ApiKey = ConfigurationManager.AppSettings["PlanGridApiKey"];
    }
}
