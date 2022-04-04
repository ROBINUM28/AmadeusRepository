using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Amadeus.BL;
using Amadeus.BL.Interfaces;
using Amadeus.Entities;
using Amadeus.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace Amadeus.Api.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private IAccionBL _accionBL;

        public TravelController(IAccionBL accionBL)
        {
            this._accionBL = accionBL;

        }

        [HttpGet]
        [Route("Travels")]

        public async Task<ActionResult<List<ModelTravel>>> Travels()
        {
            try
            {

                List<ModelTravel> Listado = await _accionBL.GetListTravel();
                return Listado;
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        /// <summary>
        /// Metodo GET
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelTravel>> Travel(int id)
        {

            try
            {
                ModelTravel PropertyId = await _accionBL.GetTravel(id);
                return PropertyId;
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ModelTravel>> Create([FromBody] ModelTravel evalcrud)
        {
            try
            {
                ModelTravel Listado = await _accionBL.CreateTravel(evalcrud.StartDate, evalcrud.Observations, evalcrud.Email, evalcrud.Name, evalcrud.Active, evalcrud.Nacionality);
                return Listado;
            }

            catch (Exception ex)
            {

                return BadRequest(ex.ToString());

            }

        }

        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult<ModelTravel>> Update(int Id,[FromBody] ModelTravel evalcrud) //DateTime startDate, string Observations, string Email, string Name, bool Active, int Nacionality)
        {
            try
            {
                ModelTravel Listado = await _accionBL.UpdateTravel(Id, evalcrud.StartDate, evalcrud.Observations, evalcrud.Email,evalcrud.Name, evalcrud.Active, evalcrud.Nacionality);
                return Listado;
            }

            catch (Exception ex)
            {

                return BadRequest(ex.ToString());

            }

        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult<ModelTravel>> Delete(int Id)
        {
            try
            {
                ModelTravel Listado = await _accionBL.DeleteTravel(Id);
                return Listado;
            }

            catch (Exception ex)
            {

                return BadRequest(ex.ToString());

            }

        }


        


        
    }


}
