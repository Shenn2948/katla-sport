using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductStoreHiveAdmin;

using DbHiveAdmin = KatlaSport.DataAccess.ProductStoreHiveAdmin.HiveAdmin;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>Represents a hive admin service.</summary>
    /// <seealso cref="KatlaSport.Services.HiveManagement.IHiveAdminService" />
    public class HiveAdminService : IHiveAdminService
    {
        private readonly IHiveAdminContext _context;

        /// <summary>Initializes a new instance of the <see cref="HiveAdminService"/> class.</summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">context</exception>
        public HiveAdminService(IHiveAdminContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<List<HiveAdmin>> GetHiveAdminsAsync()
        {
            var dbHiveAdmin = await _context.HiveAdmins.OrderBy(x => x.Id).ToArrayAsync();
            var hiveAdmins = dbHiveAdmin.Select(Mapper.Map<HiveAdmin>).ToList();
            return hiveAdmins;
        }

        /// <inheritdoc/>
        public async Task<HiveAdmin> GetHiveAdminAsync(int id)
        {
            var dbHiveAdmins = await _context.HiveAdmins.Where(x => x.Id == id).ToArrayAsync();
            if (dbHiveAdmins.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbHiveAdmin, HiveAdmin>(dbHiveAdmins[0]);
        }

        /// <inheritdoc/>
        public async Task<HiveAdmin> CreateHiveAdminAsync(UpdateHiveAdminRequest createRequest)
        {
            var dbHiveAdmins = await _context.HiveAdmins.Where(x => x.Name == createRequest.Name).ToArrayAsync();
            if (dbHiveAdmins.Length > 0)
            {
                throw new RequestedResourceHasConflictException();
            }

            var dbHiveAdmin = Mapper.Map<UpdateHiveAdminRequest, DbHiveAdmin>(createRequest);
            _context.HiveAdmins.Add(dbHiveAdmin);

            await _context.SaveChangesAsync();

            return Mapper.Map<HiveAdmin>(dbHiveAdmin);
        }

        /// <inheritdoc/>
        public async Task<HiveAdmin> UpdateHiveAdminAsync(int hiveAdminId, UpdateHiveAdminRequest updateRequest)
        {
            var dbHiveAdmins = await _context.HiveAdmins.Where(x => x.Id == hiveAdminId).ToArrayAsync();
            var dbHiveAdmin = dbHiveAdmins.FirstOrDefault() ?? throw new RequestedResourceNotFoundException();

            Mapper.Map(updateRequest, dbHiveAdmin);

            await _context.SaveChangesAsync();

            dbHiveAdmins = await _context.HiveAdmins.Where(x => x.Id == hiveAdminId).ToArrayAsync();

            return dbHiveAdmins.Select(Mapper.Map<HiveAdmin>).FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task DeleteHiveAdminAsync(int hiveAdminId)
        {
            var dbHiveAdmins = await _context.HiveAdmins.Where(x => x.Id == hiveAdminId).ToArrayAsync();

            if (dbHiveAdmins.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbHiveAdmin = dbHiveAdmins[0];
            _context.HiveAdmins.Remove(dbHiveAdmin);
            await _context.SaveChangesAsync();
        }
    }
}