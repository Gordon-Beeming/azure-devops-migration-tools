﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using MigrationTools.Core.Configuration;
using MigrationTools.Core.DataContracts;
using MigrationTools.Core.Sinks;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigrationTools.Sinks.AzureDevOps
{
    public static class AzureDevOpsExtensions
    {

        public static WorkItemData ToWorkItemData(this WorkItem workItem)
        {
            var internalWorkItem = new WorkItemData();
            internalWorkItem.id = workItem.Id.ToString();
            internalWorkItem.Type = "unknown";
            internalWorkItem.Title = "unknown";
            internalWorkItem.InternalWorkItem = workItem;
            return internalWorkItem;
        }

        public static WorkItem ToWorkItem(this WorkItemData workItemData)
        {
            if (!(workItemData.InternalWorkItem is WorkItem))
            {
                throw new InvalidCastException($"The Work Item stored in the inner field must be of type {(typeof(WorkItem)).FullName}");
            }
            return (WorkItem)workItemData.InternalWorkItem;
        }


    }
}
