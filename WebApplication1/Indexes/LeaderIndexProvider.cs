using YessqlApi.Models;
using YesSql.Indexes;

namespace YessqlApi.Indexes
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
