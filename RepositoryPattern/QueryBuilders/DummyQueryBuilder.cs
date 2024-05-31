using RepositoryPattern.Models;
using RepositoryPattern.QueryBuilders.Abstraction;

namespace RepositoryPattern.QueryBuilders
{
    public class DummyQueryBuilder : QueryBuilder<DummyQueryBuilder, DummyModel>
    {
        /*
         * Here is space for specify sorting/filtering methods for VoxelTables like:
         * 
         * public DummyQueryBuilder WithZGreatherThen(float z) => AddCondition(v=> v.Z > z);
         * 
         */

    }
}
