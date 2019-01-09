using Atata;
using NUnit.Framework;
using PhpTravels.UITests.Components;

namespace PhpTravels.UITests
{
    public class HotelTests : UITestFixture
    {
        [Test]
        public void Hotel_Add()
        {
            LoginAsAdmin();

            Go.To<HotelsPage>().
                Add.ClickAndGo().
                    HotelName.SetRandom(out string name).
                    HotelDescription.SetRandom(out string description).
                    Location.Set("London").
                    HotelType.Set("Motel").
                    Stars.Set("4").
                    FeaturedFrom.Set("30/12/2018").
                    FeaturedTo.Set("31/12/2018").
                    Submit().
                Hotels.Rows[x => x.Name == name].Should.BeVisible();


        }

        [Test]
        public void Hotel_Edit()
        {
            LoginAsAdmin();

            Go.To<HotelsPage>().
                Add.ClickAndGo().
                    HotelName.SetRandom(out string name).
                    HotelDescription.SetRandom(out string description).
                    Location.Set("London").
                    HotelType.Set("Motel").
                    Stars.Set("4").
                    FeaturedFrom.Set("30/12/2018").
                    FeaturedTo.Set("31/12/2018").
                    Submit().
                Hotels.Rows[x => x.Name == name].Edit.ClickAndGo<HotelEditPage>().
                    Location.Set("Washington").
                    Submit().
                Hotels.Rows[x => x.Name == name].Location.Should.Contain("Washington");                


        }


        [Test]
        public void Hotel_Room_Add()
        {
            LoginAsAdmin();

            Go.To<HotelsPage>().
                Add.ClickAndGo().
                    HotelName.SetRandom(out string hotelName).
                    HotelDescription.SetRandom(out string description).
                    Location.Set("London").
                    HotelType.Set("Motel").
                    Stars.Set("4").
                    FeaturedFrom.Set("30/12/2018").
                    FeaturedTo.Set("31/12/2018").
                    Submit();

            Go.To<RoomsPage>().
                Add.ClickAndGo().
                    RoomType.Set("Studio Apartment With Creek View").
                    Hotel.Set(hotelName).
                    Price.SetRandom(out int roomPrice).
                    Submit().
                Rooms.Rows[x => x.Hotel == hotelName].Price.Should.Equal(roomPrice.ToString());


        }
    }
}
