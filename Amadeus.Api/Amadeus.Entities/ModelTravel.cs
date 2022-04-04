using System;

namespace Amadeus.Entities
{
    public class ModelTravel
    {
        public int Id { get; set; }
        public string Observations { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int Nacionality { get; set; }
        public DateTime StartDate { get; set; }
        public string Msg { get; set; }
    }

   
}
