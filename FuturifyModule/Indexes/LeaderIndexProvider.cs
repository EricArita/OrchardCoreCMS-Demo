using FuturifyModule.Models;
using YesSql.Indexes;

namespace FuturifyModule.Indexes
{
    public class ApiLeaderIndexProvider : IndexProvider<ApiLeaderModel>
    {
        public override void Describe(DescribeContext<ApiLeaderModel> context)
        {
            context.For<ApiLeaderIndex>().Map(leader => new ApiLeaderIndex
            {
                FullName = leader.FullName,
            });
        }
    }
}
