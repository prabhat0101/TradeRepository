using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using TradeRepo.Data.Models;

namespace TradeSaverApi.ModelBinders
{
    public class TradeModelBinder : IModelBinder
    {

        public TradeModelBinder()
        {

        }

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(Trade))
            {
                return false;
            }

            var req = actionContext.Request.Content.ToString();

            ValueProviderResult val = bindingContext.ValueProvider.GetValue(
                bindingContext.ModelName);
            if (val == null)
            {
                return false;
            }

            string key = val.RawValue as string;
            if (key == null)
            {
                bindingContext.ModelState.AddModelError(
                    bindingContext.ModelName, "Wrong value type");
                return false;
            }

            //Trade result;
            //if (Trade.TryParse(key, out result))
            //{
            //    bindingContext.Model = result;
            //    return true;
            //}

            bindingContext.ModelState.AddModelError(
                bindingContext.ModelName, "Cannot convert value to Location");
            return false;
        }
    }
}
