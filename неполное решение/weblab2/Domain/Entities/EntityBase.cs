using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace weblab2.Domain.Entities
{
    //создадим базовый класс для всех сущностей
    public abstract class EntityBase
    {
        protected EntityBase() => DataAdded = DateTime.UtcNow;
        //обязательная
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Название страницы (заголовок)")]
        public virtual string Title { get; set; }

        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Полное описание")]
        public virtual string Text { get; set; }

        [Display(Name = "Титульная картинка")]
        public virtual string TitleImagePath { get; set; }

        [Display(Name = "Seo метатег Title")]
        public virtual string MetaTitle { get; set; }

        [Display(Name = "Seo метатег Description")]
        public virtual string MetaDiscription { get; set; }

        [Display(Name = "Seo метатег Keywords")]
        public virtual string MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public DateTime DataAdded { get; set; }


    }
}
