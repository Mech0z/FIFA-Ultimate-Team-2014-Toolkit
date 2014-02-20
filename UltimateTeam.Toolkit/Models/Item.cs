namespace UltimateTeam.Toolkit.Models
{
    public class Item
    {
        private byte _rating;

        /*
        * Players - Defender
        * ------------------
        * Attribute1 = Pace
        * Attribute2 = Shooting
        * Attribute3 = Passing
        * Attribute4 = Dribbling
        * Attribute5 = Defending
        * Attribute6 = Heading
        */

        public byte Attribute1 { get; set; }

        public byte Attribute2 { get; set; }

        public byte Attribute3 { get; set; }

        public byte Attribute4 { get; set; }

        public byte Attribute5 { get; set; }

        public byte Attribute6 { get; set; }

        public uint ClubId { get; set; }

        public string CommonName { get; set; }

        public DateOfBirth DateOfBirth { get; set; }

        public string FirstName { get; set; }

        public byte Height { get; set; }

        public string ItemType { get; set; }

        public string LastName { get; set; }

        public uint LeagueId { get; set; }

        public uint NationId { get; set; }

        public string PreferredFoot { get; set; }

        public RareType Rare { get; set; }

        public byte Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                SetCardType();
            }
        }

        public CardType CardType { get; set; }

        private void SetCardType()
        {
            if (Rating < 65)
                CardType = CardType.Bronze;
            else if (Rating < 75)
                CardType = CardType.Silver;
        }

        public string AssetYear { get; set; }
        public string Desc { get; set; }
        public string Category { get; set; }
        public string BioDesc { get; set; }
        public string Amount { get; set; }

        public string Attr { get; set; } // Physio

        public string Value { get; set; }  // Manager
        public string Weight { get; set; }  // Manager
        public string FormationId { get; set; }  // Manager
        public string TalkRating { get; set; }  // Manager
        public string Negotiation { get; set; }  // Manager
        public string AssetId { get; set; }  // Manager

        public string Pos { get; set; }
        public string Manufacturer { get; set; }
        public string PosBonus { get; set; }
        public string Name { get; set; }

        public string Bronze { get; set; }
        public string Silver { get; set; }
        public string Gold { get; set; }

        public string StadiumId { get; set; }
        public string Cap { get; set; }

        public string Boost { get; set; }
    }
}
