using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace weblab2.Domain.Entities
{
    public class Serviceitem : EntityBase
    {
        [Required(ErrorMessage = "заполните название услуги")]
        [Display(Name = "Название услуги")]
        public override string Title { get; set; }

        [Display(Name = "Краткое название услуги")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное название услуги")]
        public override string Text { get; set; }
    }
}
