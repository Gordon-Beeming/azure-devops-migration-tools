﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MigrationTools.Core.Configuration.FieldMap;
using MigrationTools.Core.Configuration;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;

namespace MigrationTools.Sinks.AzureDevOps.FieldMaps
{
    public class FieldToTagFieldMap : FieldMapBase
    {
        private FieldtoTagMapConfig Config { get { return (FieldtoTagMapConfig)_Config; } }

        public override void Configure(IFieldMapConfig config)
        {
            base.Configure(config);
        }

        public override string MappingDisplayName => Config.sourceField;

        internal override void InternalExecute(WorkItem source, WorkItem target)
        {
            throw new NotImplementedException();
            //if (source.Fields.Contains(this.Config.sourceField))
            //{
            //    List<string> newTags = target.Tags.Split(char.Parse(@";")).ToList();
            //    // to tag
            //    if (source.Fields[this.Config.sourceField].Value != null)
            //    {
            //        string value = source.Fields[this.Config.sourceField].Value.ToString();
            //        if (!string.IsNullOrEmpty(value))
            //        {
            //            if (string.IsNullOrEmpty(Config.formatExpression))
            //            {
            //                newTags.Add(value);
            //            }
            //            else
            //            {
            //                newTags.Add(string.Format(Config.formatExpression, value));
            //            }
            //            target.Tags = string.Join(";", newTags.ToArray());
            //            Trace.WriteLine(string.Format("  [UPDATE] field tagged {0}:{1} to {2}:Tag with foramt of {3}", source.Id, Config.sourceField, target.Id, Config.formatExpression));
            //        }

            //    }

            //}
        }
    }
}
