using Amadeus.BL.Interfaces;
using Amadeus.DAL;
using Amadeus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amadeus.BL.Security
{
    public class Accion : IAccionBL
    {
        /*ACTIONS TRAVELS*/
        public async Task<ModelTravel> GetTravel(int id)
        {
            return await FunctionsDAL.GetTravel(id);
        }
        public async Task<List<ModelTravel>> GetListTravel()
        {
            return await FunctionsDAL.GetListTravel();
        }
        public async Task<ModelTravel> CreateTravel(DateTime StartDate, string Observations, string Email, string Name, bool Active, int Nacionality)
        {
            return await FunctionsDAL.CreateTravel(StartDate, Observations, Email, Name, Active, Nacionality);
        }
        public async Task<ModelTravel> UpdateTravel(int Id, DateTime StartDate, string Observations, string Email, string Name, bool Active, int Nacionality)
        {
            return await FunctionsDAL.UpdateTravel(Id, StartDate, Observations, Email, Name, Active, Nacionality);
        }
        public async Task<ModelTravel> DeleteTravel(int Id)
        {
            return await FunctionsDAL.DeleteTravel(Id);
        }
    }
       
}
