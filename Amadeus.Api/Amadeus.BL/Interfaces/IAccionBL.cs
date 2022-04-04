using Amadeus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amadeus.BL.Interfaces
{
    public interface IAccionBL
    {
        Task<ModelTravel> GetTravel(int id);

        Task<List<ModelTravel>> GetListTravel();

        Task<ModelTravel> CreateTravel(DateTime StartDate, string Observations, string Email, string Name, bool Active, int Nacionality);

        Task<ModelTravel> UpdateTravel(int Id, DateTime StartDate, string Observations, string Email, string Name, bool Active, int Nacionality);

        Task<ModelTravel> DeleteTravel(int Id);

    }

}
