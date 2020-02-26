namespace KatlaSport.DataAccess.ProductStoreHiveAdmin
{
    internal class HiveAdminContext : DomainContextBase<ApplicationDbContext>, IHiveAdminContext
    {
        public HiveAdminContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<HiveAdmin> HiveAdmins => GetDbSet<HiveAdmin>();

        public IEntitySet<ImageFile> ImageFiles => GetDbSet<ImageFile>();
    }
}