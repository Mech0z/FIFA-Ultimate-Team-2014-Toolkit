using System.Net.Http;
using System.Threading.Tasks;
using UltimateTeam.Toolkit.Constants;
using UltimateTeam.Toolkit.Extensions;
using UltimateTeam.Toolkit.Models;
using UltimateTeam.Toolkit.Parameters;

namespace UltimateTeam.Toolkit.Requests
{
    internal class ClubItemsRequest : FutRequestBase, IFutRequest<ClubItemsResponse>
    {
        private readonly ClubItemSearchParameters _clubItemSearchParameters;

        public ClubItemsRequest(ClubItemSearchParameters clubItemSearchParameters)
        {
            clubItemSearchParameters.ThrowIfNullArgument();
            _clubItemSearchParameters = clubItemSearchParameters;
        }

        public async Task<ClubItemsResponse> PerformRequestAsync()
        {
            var uriString = string.Format(Resources.FutHome + Resources.ClubItems + "?start={0}&count={1}",
                (_clubItemSearchParameters.Page - 1) * _clubItemSearchParameters.PageSize, _clubItemSearchParameters.PageSize); 
            _clubItemSearchParameters.BuildUriString(ref uriString);

            AddMethodOverrideHeader(HttpMethod.Get);
            AddCommonHeaders();
            var clubItemsResponseMessage = await HttpClient
                .GetAsync(uriString)
                .ConfigureAwait(false);

            return await Deserialize<ClubItemsResponse>(clubItemsResponseMessage);
        }
    }
}