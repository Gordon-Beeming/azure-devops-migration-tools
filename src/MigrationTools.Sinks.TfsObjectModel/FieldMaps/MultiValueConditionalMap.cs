﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Diagnostics;
using Microsoft.ApplicationInsights;
using MigrationTools.Core.Configuration.FieldMap;
using MigrationTools.Core.Configuration;

namespace MigrationTools.Sinks.TfsObjectModel.FieldMaps
{
    public class MultiValueConditionalMap : FieldMapBase
    {

        private MultiValueConditionalMapConfig Config { get { return (MultiValueConditionalMapConfig)_Config; } }

        public override void Configure(IFieldMapConfig config)
        {
            base.Configure(config);
        }

        public override string MappingDisplayName => string.Empty;

        internal override void InternalExecute(WorkItem source, WorkItem target)
        {
            if (fieldsExist(Config.sourceFieldsAndValues, source) && fieldsExist(Config.targetFieldsAndValues, target))
            {
                if (fieldsValueMatch(Config.sourceFieldsAndValues, source))
                {
                    fieldsUpdate(Config.targetFieldsAndValues, target);
                }                
                Trace.WriteLine(string.Format("  [UPDATE] field mapped {0}:{1} to {2}:{3}", source.Id, Config.sourceFieldsAndValues.Keys.ToString(), target.Id, Config.targetFieldsAndValues.Keys.ToString()));
            } else
            {
                Trace.WriteLine(string.Format("  [SKIPPED] Not all source and target fields exist", source.Id, Config.sourceFieldsAndValues.Keys.ToString(), target.Id, Config.targetFieldsAndValues.Keys.ToString()));
            }
        }

        private void fieldsUpdate(Dictionary<string, string> fieldAndValues, WorkItem workitem)
        {
            foreach (string field in fieldAndValues.Keys)
            {
                workitem.Fields[field].Value = fieldAndValues[field];
            }
        }

        private bool fieldsValueMatch(Dictionary<string, string> fieldAndValues, WorkItem workitem)
        {
            bool matches = true;
            foreach (string field in fieldAndValues.Keys)
            {
                if((string)workitem.Fields[field].Value != fieldAndValues[field])
                {
                    matches = false;
                }
            }
            return matches;
        }

        private bool fieldsExist(Dictionary<string, string> fieldsAndValues, WorkItem workitem)
        {
            bool exists = true;
            foreach (string field in fieldsAndValues.Keys)
            {
                if (!workitem.Fields.Contains(field))
                {
                    exists = false;
                }
            }
            return exists;
        }


    }
}
