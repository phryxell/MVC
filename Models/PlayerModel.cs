using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Moment2___MVC.Models
{
    public class PlayerModel
    {
        // Properties
        [Required(ErrorMessage = "Fyll i vilken klubb spelaren spelar i")]
        public string Lag { get; set; }
        [Required(ErrorMessage = "Fyll i spelarens namn")]
        [MaxLength(50, ErrorMessage ="Max 50 tecken")]
        public string Namn { get; set; }
        [Required(ErrorMessage = "Fyll i länk till spelarens SoFifa-profil")]
        [Url(ErrorMessage = "Måste vara en giltigt webbaddress")]
        public string Url { get; set; }
        [Required(ErrorMessage = "Ange spelarens potential")]
        [MaxLength(2, ErrorMessage = "Får inte vara fler än två tecken, maxpotential i spelet är 99")]
        public string Potential { get; set; }

        [Required(ErrorMessage = "Ange vilken position spelaren har")]
        public string Position { get; set; }

        [JsonIgnore]
        public List<SelectListItem> Countries { get; set; }
      = new List<SelectListItem>
      {
        new SelectListItem("UK", "UK"),
        new SelectListItem("USA", "USA"),
        new SelectListItem("Belgien", "Belgien"),
        new SelectListItem("Sverige", "Sverige"),
        new SelectListItem("Senegal", "Senegal"),
        new SelectListItem("Serbien", "Serbien"),
        new SelectListItem("Frankrike", "Frankrike"),
        new SelectListItem("Övrigt land", "Övrigt land")
      }; // used to populate the list of options

        [Required(ErrorMessage = "Ange vilket land spelaren spelar för")]
        public string Country { get; set; }

        public PlayerModel()
        {

        }
    }
}
