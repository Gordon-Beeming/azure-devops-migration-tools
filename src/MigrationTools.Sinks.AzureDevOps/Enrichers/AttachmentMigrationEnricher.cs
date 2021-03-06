﻿using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigrationTools;
using MigrationTools.Core.DataContracts;
using MigrationTools.Core.Engine.Enrichers;

namespace MigrationTools.Sinks.AzureDevOps.Enrichers
{
    public class AttachmentMigrationEnricher : IAttachmentMigrationEnricher
    {
        private string _exportBasePath;
        private int _maxAttachmentSize;

        public AttachmentMigrationEnricher(string exportBasePath, int maxAttachmentSize = 480000000)
        {
            _exportBasePath = exportBasePath;
            _maxAttachmentSize = maxAttachmentSize;
        }

        public void ProcessAttachemnts(WorkItemData source, WorkItemData target, bool save = true)
        {
            throw new NotImplementedException();
        }

        public void CleanUpAfterSave()
        {
            throw new NotImplementedException();
        }
    }
}
