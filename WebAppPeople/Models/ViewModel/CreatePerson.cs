using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebAppPeople.Models.Data;

namespace WebAppPeople.Models.ViewModel
{
    public class CreatePerson
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string CurrentCity { get; set; }

        public string CellphoneNumber { get; set; }

        public List<string> CurrentCityList { get; set; }

        public CreatePerson()
        {
            CurrentCityList = new List<string>()
            {
                "Södertälje",
                "Borås",
                "Gävle",
                "Umeå",
                "Lund",
                "JönKöping",
                "Norrköping",
                "Helsihgborg",
                "Linköping",
                "Örebro",
                "Västerås",
                "Upplands",
                "Väsby",
                "Sollentuna",
                "Uppsala",
                "Malmö",
                "Gothenburg",
                "Stockholm"
            };
        }
    }
}
