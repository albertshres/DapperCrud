//this is fourth step
using Dapper;
using DapperCrudYtb.Models;
using System.Data;

namespace DapperCrudYtb.Services
{
    public class BikeRepository : IBikeRepository
    {
        //this IDbConnection represents the connection
        //with the data source
        private readonly IDbConnection _db;

        public BikeRepository(IDbConnection db)
        {
            _db = db;
        }

        //single value chaiye Excecute use garne else query use garne in dapper 
        public async Task<IEnumerable<Bike>> GetAllAsync()
        {
            var sql = "select * from BikeSP";
            return await _db.QueryAsync<Bike>(sql);
        }

        public async Task<Bike> GetByIdAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@BikeId", id,DbType.Int32);

            return await _db.QueryFirstOrDefaultAsync<Bike>("GetBike", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CreateAsync(Bike bike)
        {
            var parameters= new DynamicParameters();
            parameters.Add("@BName", bike.BName, DbType.String);
            parameters.Add("@Manufacture", bike.Manufacture, DbType.String);
            parameters.Add("@Color",bike.Color,DbType.String);
            parameters.Add("@CC", bike.CC, DbType.Int32);

            return await _db.ExecuteAsync("InsertBike", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(Bike bike)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@BikeId", bike.BikeId, DbType.Int32);
            parameters.Add("BName",bike.BName, DbType.String);
            parameters.Add("@Manufacture",bike.Manufacture, DbType.String);
            parameters.Add("@Color", bike.Color, DbType.String);
            parameters.Add("@CC", bike.CC, DbType.Int32);

            return await _db.ExecuteAsync("UpdateBikes",parameters, commandType: CommandType.StoredProcedure);  

        }

        public async Task<int> DeleteAsync(int id)
        {
            var parameters=new DynamicParameters();
            parameters.Add("@BikeId",id, DbType.Int32);

            return await _db.ExecuteAsync("DeleteBike",parameters,commandType: CommandType.StoredProcedure);

        }
    }
}
