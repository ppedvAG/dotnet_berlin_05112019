using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HalloWeb.Models
{
    public class Banane
    {
        public int Id { get; set; }
        public Reifegrad Reifegrad { get; set; }

        public DateTime Pflückdatum { get; set; }

        [MaxLength(24)]
        public string Land { get; set; }
    }

    public enum Reifegrad
    {
        Gelb,
        Grün,
        Braun
    }
}
