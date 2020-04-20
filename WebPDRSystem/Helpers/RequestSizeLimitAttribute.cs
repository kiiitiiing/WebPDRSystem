using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPDRSystem.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RequestSizeLimitAttribute : Attribute, IAuthorizationFilter, IOrderedFilter
    {
        private readonly FormOptions _formOptions;

        public RequestSizeLimitAttribute(int valueCountLimit)
        {
            _formOptions = new FormOptions()
            {
                KeyLengthLimit = valueCountLimit,
                ValueCountLimit = valueCountLimit,
                ValueLengthLimit = valueCountLimit
            };
        }

        public int Order { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var contextFeatures = context.HttpContext.Features;

            var formFearture = contextFeatures.Get<IFormFeature>();

            if(formFearture == null || formFearture.Form == null)
            {
                contextFeatures.Set<IFormFeature>(new FormFeature(context.HttpContext.Request, _formOptions));
            }
        }
    }
}
