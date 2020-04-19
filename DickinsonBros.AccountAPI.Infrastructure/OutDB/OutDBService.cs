using DickinsonBros.AccountAPI.Infrastructure.BusService;
using DickinsonBros.AccountAPI.Infrastructure.BusService.Models;
using DickinsonBros.AccountAPI.Infrastructure.OutDB.Models;
using DickinsonBros.Encryption.Abstractions;
using DickinsonBros.SQL.Abstractions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DickinsonBros.AccountAPI.Infrastructure.OutDB
{
    public class OutDBService
    {
        internal readonly string _outDBConnectionString;
        internal readonly ISQLService _sqlService;

        internal const string INSERT = "[OutDB].[Insert]";

        public OutDBService(IOptions<Models.OutDB> outDB, IEncryptionService encryptionService, ISQLService sqlService)
        {
            _outDBConnectionString = encryptionService.Decrypt(outDB.Value.ConnectionString);
            _sqlService = sqlService;
        }

        public async Task InsertItemAsync(Payload payload)
        {
            await _sqlService
                .ExecuteAsync
                    (
                        _outDBConnectionString,
                        INSERT,
                        payload,
                        commandType: CommandType.StoredProcedure
                    );
        }

        public async Task<List<Payload>> PullItemAsync(Payload payload)
        {
            return null;
            //await _sqlService
            //    .ExecuteAsync
            //        (
            //            _outDBConnectionString,
            //            INSERT,
            //            payload,
            //            commandType: CommandType.StoredProcedure
            //        );
        }

        public async Task<List<Payload>> UpdateItemStatusAsync(int itemId, bool successful)
        {
            return null;
            //await _sqlService
            //    .ExecuteAsync
            //        (
            //            _outDBConnectionString,
            //            INSERT,
            //            payload,
            //            commandType: CommandType.StoredProcedure
            //        );
        }

    }

}
