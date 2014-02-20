using System.Threading.Tasks;
using UltimateTeam.Toolkit.Constants;
using UltimateTeam.Toolkit.Models;
using UltimateTeam.Toolkit.Extensions;

namespace UltimateTeam.Toolkit.Requests
{
    internal class ItemRequest : FutRequestBase, IFutRequest<Item>
    {
        private readonly long _baseId;

        public ItemRequest(long resourceId)
        {
            _baseId = resourceId.CalculateBaseId();
        }

        public async Task<Item> PerformRequestAsync()
        {
            AddUserAgent();
            AddAcceptHeader("*/*");
            AddReferrerHeader(Resources.BaseShowoff);
            AddAcceptEncodingHeader();
            AddAcceptLanguageHeader();
            var itemResponseMessage = await HttpClient
                .GetAsync(string.Format(Resources.Item, _baseId))
                .ConfigureAwait(false);
            var itemWrapper = await Deserialize<ItemWrapper>(itemResponseMessage);

            return itemWrapper.Item;
        }
    }
}
