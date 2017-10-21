using PFoursquare.API.Model;

namespace PFoursquare.API.Config
{
    public static class Maps
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<RVenue, MVenue>()
                    .MaxDepth(1)
                    .ReverseMap()
                    .PreserveReferences();

                config.CreateMap<RContact, MContact>()
                    .MaxDepth(1)
                    .ReverseMap()
                    .PreserveReferences();

                config.CreateMap<RCategory, MCategory>()
                    .MaxDepth(1)
                    .ReverseMap()
                    .PreserveReferences();

                config.CreateMap<RCategoryIcon, MCategoryIcon>()
                    .MaxDepth(1)
                    .ReverseMap()
                    .PreserveReferences();

                config.CreateMap<RLocation, MLocation>()
                    .MaxDepth(1)
                    .ReverseMap()
                    .PreserveReferences();

                config.CreateMap<RLabeledLatLngs, MLabeledLatLngs>()
                    .MaxDepth(1)
                    .ReverseMap()
                    .PreserveReferences();
            });
        }
    }
}
