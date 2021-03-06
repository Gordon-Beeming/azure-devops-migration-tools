﻿using MigrationTools.Core.Configuration;
using MigrationTools.Core.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigrationTools.Core.Engine
{
   public interface IFieldMap
    {
        string Name { get; }
        string MappingDisplayName { get; }

        void Configure(IFieldMapConfig config);
        void Execute(WorkItemData source, WorkItemData target);
    }
}
