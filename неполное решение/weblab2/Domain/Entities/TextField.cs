using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace weblab2.Domain.Entities
{
    //в этом текстовом поле будут содержаться контакты
    public class TextField : EntityBase
    {
        [Required]
        public string  CodeWord { get; set; }

        [Display(Name = "Название страницы (заголовок)")]
        public override string Title { get; set; } = "Информационная страница";

        [Display(Name = "Содержание страницы")]
        public override string Text { get; set; } = "содержание страницы заполняется админом";
    }
}
