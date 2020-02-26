using System;
using AutoMapper;
using DataAccessHive = KatlaSport.DataAccess.ProductStoreHive.StoreHive;
using DataAccessHiveAdmin = KatlaSport.DataAccess.ProductStoreHiveAdmin.HiveAdmin;
using DataAccessHiveSection = KatlaSport.DataAccess.ProductStoreHive.StoreHiveSection;
using DbHiveAdminImage = KatlaSport.DataAccess.ProductStoreHiveAdmin.ImageFile;

#pragma warning disable 1591

namespace KatlaSport.Services.HiveManagement
{
    public sealed class HiveManagementMappingProfile : Profile
    {
        public HiveManagementMappingProfile()
        {
            CreateMap<UpdateHiveAdminRequest, DataAccessHiveAdmin>();
            CreateMap<ImageFile, DbHiveAdminImage>();

            CreateMap<DataAccessHive, HiveListItem>();
            CreateMap<DataAccessHive, Hive>();
            CreateMap<DataAccessHiveSection, HiveSectionListItem>();
            CreateMap<DataAccessHiveSection, HiveSection>();
            CreateMap<UpdateHiveRequest, DataAccessHive>()
                .ForMember(r => r.LastUpdated, opt => opt.MapFrom(p => DateTime.UtcNow));
            CreateMap<UpdateHiveSectionRequest, DataAccessHiveSection>()
                .ForMember(r => r.LastUpdated, opt => opt.MapFrom(p => DateTime.UtcNow));
        }
    }
}