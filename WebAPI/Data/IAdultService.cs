using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IAdultService
    {
        void AddAdult(Adult adultToAdd);
        IList<Adult> ReadAllAdults();
        void UpdateAdult(Adult adultToUpdate);
        void DeleteAdult(Adult adultToDelete);
    }
}