using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace TennisClub.Models
{
    public class Player
    {
        //public Player()
        //{
        //}

        private string _ranking = "Unranked";
        private int _startingPoints = 1200;

        public int Id { get; set; }
        public string FullName {get; set;}
        [Required(ErrorMessage = "Your name is required")]
        [MinimumAge(16)]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Birthdate { get; set; }
        [Required(ErrorMessage = "Your D.O.B is required")]
        public string Nationality { get; set; }
        public string RankName => _ranking;
        public int Points => _startingPoints;

       


    }
    
}
