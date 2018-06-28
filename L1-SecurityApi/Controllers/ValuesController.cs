using L_Core.Model;
using L0_Core.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static L_Core.Model.ApiModel;

namespace L1_SecurityApi.Controllers
{
    public class ValuesController : ApiController
    {
        ParamVerifyHelper verifyHelper = new ParamVerifyHelper();
        // GET api/values
        public string Get(string json)
        {
            string res = "";

            Test pars = JsonConvert.DeserializeObject<Test>(json);

            #region 验证接口参数是否有效。
            res = verifyHelper.VerifySign(pars); 
            #endregion

            if (string.IsNullOrEmpty(res))
            {
                return "true";
            }
            else
            {
                return res;
            }

        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
