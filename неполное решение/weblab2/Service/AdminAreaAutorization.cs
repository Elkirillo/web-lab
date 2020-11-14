using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weblab2.Service
{
    public class AdminAreaAutorization : IControllerModelConvention
    {
        private readonly string area;
        private readonly string policy;

        public AdminAreaAutorization(string area, string policy)
        {
            this.area = area;
            this.policy = policy;
        }

        public void Apply(ControllerModel controller)
        {
            //для контроллера проверяем его атрибуты
            if (controller.Attributes.Any(a => 
                a is AreaAttribute && (a as AreaAttribute).RouteValue.Equals(area, StringComparison.OrdinalIgnoreCase))
                || controller.RouteValues.Any(r =>
                r.Key.Equals("area", StringComparison.OrdinalIgnoreCase) && r.Value.Equals(area, StringComparison.OrdinalIgnoreCase)))
            {
                //то отправляем пользователя на авторизацию
                controller.Filters.Add(new AuthorizeFilter(policy));
            }
        }
    }
}
