using System;

namespace UltimateTeam.Toolkit.Parameters 
{
    public class ClubItemSearchParameters
    {
        private const byte DefaultPageSize = 12;

        public ClubItemType ClubItemType { get; set; }
        public uint Page { get; set; }

        public byte PageSize { get; set; }

        public ClubItemSearchParameters(ClubItemType clubItemType)
        {
            ClubItemType = clubItemType;
            Page = 1;
            PageSize = DefaultPageSize;
        }

        public string BuildUriString(ref string uriString)
        {
            uriString += "&type=" + (int)ClubItemType;

            return uriString;
        }
    }
}

     