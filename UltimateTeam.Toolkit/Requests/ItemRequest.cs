using System.Threading.Tasks;
using UltimateTeam.Toolkit.Constants;
using UltimateTeam.Toolkit.Models;
using UltimateTeam.Toolkit.Extensions;

namespace UltimateTeam.Toolkit.Requests
{
    internal class ItemRequest : FutRequestBase, IFutRequest<Item>
    {
        private readonly AuctionInfo _auctionInfo;
        private readonly ItemData _itemData;


        public ItemRequest(ItemData itemData)
        {
            itemData.ThrowIfNullArgument();
            _itemData = itemData;
        }

        public ItemRequest(AuctionInfo auctionInfo)
        {
            auctionInfo.ThrowIfNullArgument();
            _auctionInfo = auctionInfo;
        }

        public async Task<Item> PerformRequestAsync()
        {
            AddUserAgent();
            AddAcceptHeader("*/*");
            AddReferrerHeader(Resources.BaseShowoff);
            AddAcceptEncodingHeader();
            AddAcceptLanguageHeader();

            var baseId = _auctionInfo != null ? _auctionInfo.CalculateBaseId() : _itemData.ResourceId.CalculateBaseId();
            var itemResponseMessage = await HttpClient
                .GetAsync(string.Format(Resources.Item, baseId))
                .ConfigureAwait(false);
            var itemWrapper = await Deserialize<ItemWrapper>(itemResponseMessage);

            return itemWrapper.Item;
        }
    }
}
