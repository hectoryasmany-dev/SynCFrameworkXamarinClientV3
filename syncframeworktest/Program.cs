using BIT.Xpo.Providers.OfflineDataSync;
using DevExpress.Xpo.DB;
using System;
using BIT.Xpo.Providers.OfflineDataSync.UtilitiesExtensions;
using BIT.Xpo.Providers.OfflineDataSync.NetworkExtensions;

namespace syncframeworktest
{
    class Program
    {
        static void Main(string[] args)
        {
            SyncDataStoreAsynchronous.Register();
            string connectionString = "XpoProvider=SyncDataStoreAsynchronous;DataConnectionString='XpoProvider=SQLite;Data Source=DataA.db';DeltaConnectionString='XpoProvider=SQLite;Data Source=DeltaA.db';EnableDeltaTracking='True';ExcludedEntities='';Identity=A";
            var SyncUrl = "";
            var serializationService = new BIT.Data.Services.CompressXmlObjectSerializationService();
            var stringSerializactionService = new BIT.Data.Services.StringSerializationHelper();
            var SyncDataStoreServerConfiguration = new SyncDataStoreServerConfiguration(serializationService, stringSerializactionService, SyncUrl, createHttpClient: null);
            // var syncmio = SyncDataStoreAsynchronous.CreateProviderFromString(connectionString, AutoCreateOption.DatabaseAndSchema, out _);
            var  SyncDataStore = SyncDataStoreAsynchronous.CreateProviderFromString(connectionString, AutoCreateOption.DatabaseAndSchema, out _) as SyncDataStoreAsynchronous;

        }
    }
}
