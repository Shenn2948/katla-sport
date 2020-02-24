using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductStoreHiveAdmin;
using Image = KatlaSport.DataAccess.ProductStoreHiveAdmin.ImageFile;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>Represents a hive admin image service.</summary>
    /// <seealso cref="KatlaSport.Services.HiveManagement.IHiveAdminImageService" />
    public class HiveAdminImageService : IHiveAdminImageService
    {
        private readonly IHiveAdminContext _context;

        /// <summary>Initializes a new instance of the <see cref="HiveAdminImageService"/> class.</summary>
        /// <param name="context">The context.</param>
        public HiveAdminImageService(IHiveAdminContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<ImageFile> GetHiveAdminImage(int id)
        {
            var dbImages = await _context.ImageFiles.Where(x => x.Id == id).ToArrayAsync();
            if (dbImages.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<Image, ImageFile>(dbImages[0]);
        }

        /// <inheritdoc/>
        public async Task<ImageFile> UploadHiveAdminImage(HiveAdmin admin, byte[] content, string name)
        {
            var dbImages = await _context.ImageFiles.Where(x => x.HiveAdminId == admin.Id).ToArrayAsync();
            if (dbImages.Length > 0)
            {
                throw new RequestedResourceHasConflictException();
            }

            var dbHiveAdmin = Mapper.Map<HiveAdmin, DataAccess.ProductStoreHiveAdmin.HiveAdmin>(admin);
            Image image = _context.ImageFiles.Add(new Image() {HiveAdmin = dbHiveAdmin, Content = content, Name = name});
            await _context.SaveChangesAsync();

            return Mapper.Map<Image, ImageFile>(image);
        }

        /// <inheritdoc/>
        public async Task DeleteHiveAdminImage(int id)
        {
            var dbImages = await _context.ImageFiles.Where(x => x.Id == id).ToArrayAsync();
            if (dbImages.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbImage = dbImages[0];
            _context.ImageFiles.Remove(dbImage);
            await _context.SaveChangesAsync();
        }
    }
}