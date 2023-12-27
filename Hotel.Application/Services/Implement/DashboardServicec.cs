using Hotel.Application.DTOs.AdminSide.Product;
using Hotel.Application.Services.Interface;
using Hotel.Domain.Entities.Product;

namespace Hotel.Application.Services.Implement;

public class DashboardServicec : IDashboardService
{
    private readonly IHotelService _Service;

    public DashboardServicec(IHotelService hotelService)
    {
        _Service = hotelService;
    }

    

    public CreateHotelDTO CreateHotel(CreateHotelDTO model)
    {
        
        var hotel = new Domain.Entities.Product.Hotel()
        {
            Title = model.Title,
            DateTime = DateTime.Now,
            Description = model.Description,
            EntryTime = model.EntryTime,
            ExitTime = model.ExitTime,
            RoomCount = model.RoomCount,
            StageCount = model.StageCount,
        };
        _Service.AddHotel(hotel);

        var address = new HotelAddress()
        {
            Address = model.Address,
            City = model.City,
            State = model.State,
            HotelId = hotel.ID,
        };
        hotel.IsActive = true;
        _Service.InsetAddress(address);
        return model;
    }

    public IEnumerable<Domain.Entities.Product.Hotel> GetAllHotel()
    {
        return _Service.GetAllHotel();
    }

    public Domain.Entities.Product.Hotel GetHotelById(int id)
    {
        return _Service.GetHotelById(id);
    }

    public EditHotelDTO EditHotelById(int id, Domain.Entities.Product.Hotel hotel, HotelAddress address)
    {
        var edithoteldto = _Service.EditHotelById(id,hotel,address);
        return edithoteldto;
    }


    public void UpdateAddress(HotelAddress address)
    {
       _Service.UpdateAddress(address);
    }

    public void UpdateHotel(Domain.Entities.Product.Hotel hotel)
    {
        _Service.UpdateHotel(hotel);
    }

    
}
    