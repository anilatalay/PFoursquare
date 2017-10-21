using PFoursquare.API.Model;

namespace PFoursquare.API.Config
{
    public static class Maps
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Category, RCategory>()
                    .MaxDepth(1)
                    .ReverseMap()
                    .PreserveReferences();
            });
        }
    }
}
