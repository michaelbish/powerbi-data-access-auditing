﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Azure;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace PowerBiAuditApp.Models
{
    public class ReportDetail : TableEntity, Azure.Data.Tables.ITableEntity
    {
        [IgnoreProperty]
        [IgnoreDataMember]
        // Report Id for which Embed token needs to be generated
        public Guid ReportId { get { return new Guid(RowKey); } set { RowKey = value.ToString(); } }

        [IgnoreProperty]
        [IgnoreDataMember]
        // Workspace Id for which Embed token needs to be generated
        public Guid GroupId { get { return new Guid(PartitionKey); } set { PartitionKey = value.ToString(); } }

        public bool Enabled { get; set; }

        public int? DisplayLevel { get; set; }

        public string Name { get; set; }
        public string GroupName { get; set; }

        public string Description { get; set; }

        public string ReportType { get; set; }

        public bool Deleted { get; set; }

        public string StringRoles { get; set; } = null!;

        [IgnoreProperty]
        [IgnoreDataMember]
        public string[] Roles {
            get {
                return StringRoles is not null
                    ? JsonConvert.DeserializeObject<string[]>(StringRoles) ?? Array.Empty<string>()
                    : Array.Empty<string>();
            }
            set => StringRoles = JsonConvert.SerializeObject(value);
        }

        public string StringAadGroups { get; set; } = null!;

        [IgnoreProperty]
        [IgnoreDataMember]
        public AadGroup[] AadGroups {
            get {
                return StringRoles is not null
                    ? JsonConvert.DeserializeObject<AadGroup[]>(StringAadGroups) ?? Array.Empty<AadGroup>()
                    : Array.Empty<AadGroup>();
            }
            set => StringAadGroups = JsonConvert.SerializeObject(value);
        }

        public bool EffectiveIdentityRequired { get; set; }
        public string EffectiveIdentityOverRide { get; set; }
        public bool EffectiveIdentityRolesRequired { get; set; }
        public int? ReportRowLimit { get; set; }

        public List<int> DrillThroughReports { get; set; }

        public List<string> RequiredParameters { get; set; }
        DateTimeOffset? Azure.Data.Tables.ITableEntity.Timestamp { get; set; }
        ETag Azure.Data.Tables.ITableEntity.ETag { get; set; }
    }
}