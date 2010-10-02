using FluentNHibernate;
using NHibernate3Sample.Mapping;

namespace NHibernate3Sample.MappingTest
{
    public class TestModel : PersistenceModel
    {
        public TestModel()
        {
            AddMappingsFromAssembly(typeof(CategoryMapping).Assembly);
            AddMappingsFromAssembly(typeof(NewsMapping).Assembly);
            AddMappingsFromAssembly(typeof(PollMapping).Assembly);
            AddMappingsFromAssembly(typeof(UserMapping).Assembly);
        }
    }
}