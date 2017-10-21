using PFoursquare.API.Model;

namespace PFoursquare.API.Config
{
    public static class Maps
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<RCategory, MCategory>()
                    .MaxDepth(1)
                    .ReverseMap()
                    .PreserveReferences();

                config.CreateMap<RCategoryIcon, MCategoryIcon>()
                    .MaxDepth(1)
                    .ReverseMap()
                    .PreserveReferences();
            });
        }
    }
}
