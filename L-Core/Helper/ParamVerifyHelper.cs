using L_Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static L_Core.Model.ApiModel;

/*
1.对除签名外的所有请求参数按key做的升序排列,value无需编码。
 （假设当前时间的时间戳是12345678）

例如：有c=3,b=2,a=1 三个参，另加上时间戳后， 按key排序后为：a=1，b=2，c=3，_timestamp=12345678。

2 把参数名和参数值连接成字符串，得到拼装字符：a1b2c3_timestamp12345678

3 用申请到的appkey 连接到接拼装字符串头部和尾部，然后进行32位MD5加密，最后将到得MD5加密摘要转化成大写。

示例：假设appkey=test，md5(testa1b2c3_timestamp12345678test)，取得MD5摘要值 C5F3EB5D7DC2748AED89E90AF00081E6 。

参考地址：http://www.cnblogs.com/codeon/p/5900914.html
*/

namespace L0_Core.Helper
{

    public class ParamVerifyHelper
    {
        Md5Helper md5 = new Md5Helper();

        public string VerifySign(Test pars)
        {
            string res = "";
            var keyDic = GetKeyDics();

            #region 判断请求是否过期---假设过期时间是20秒
            DateTime requestTime = new DateTime(pars._timestamp);

            if (requestTime.AddSeconds(20) < DateTime.Now)
            {
                MessageReq message = new MessageReq();
                message.code = -1;
                message.msg = "接口过期";
                res = JsonConvert.SerializeObject(message);
            }
            #endregion

            #region 根据appkey获取key值
            string secret = keyDic.Where(T => T.Key == pars.appKey).FirstOrDefault().Value;
            #endregion

            #region 校验签名是否合法
            var param = new SortedDictionary<string, string>(new AsciiComparer());
            param.Add("age", pars.age.ToString());
            param.Add("appKey", pars.appKey);

            param.Add("appSecret", secret);//把secret加入进行加密

            param.Add("_timestamp", pars._timestamp.ToString());

            string currentSign = GetSign(param, pars.appKey);

            if (pars._sign != currentSign)
            {
                MessageReq message = new MessageReq();
                message.code = -2;
                message.msg = "签名不合法";
                res = JsonConvert.SerializeObject(message);
            }
            #endregion
            return res;
        }

        public string GetSign(SortedDictionary<string, string> paramDic, string appKey)
        {
            paramDic.Remove("_sign");
            StringBuilder sb = new StringBuilder(appKey);
            foreach (var p in paramDic)
                sb.Append(p.Key).Append(p.Value);
            sb.Append(appKey);

            return md5.GetMd5(sb.ToString());
        }

        private Dictionary<string, string> GetKeyDics()
        {
            //key集合，这里随便弄两个测试数据
            //如果调用方比较多，需要审核授权，根据一定的规则生成key把这些数据存放在数据库中，如果功能扩展开来，可以针对不同的调用方做不同的功能权限管理
            //在调用接口时动态从库里取，每个调用方在调用时带上他的key，调用方一般把自己的key放到网站配置中
            Dictionary<string, string> keySecretDic = new Dictionary<string, string>();
            keySecretDic.Add("key_zhangsan", "D9U7YY5D7FF2748AED89E90HJ88881E6");//张三的key,
            keySecretDic.Add("key_lisi", "I9O6ZZ3D7FF2748AED89E90ZB7732M9");//李四的key

            return keySecretDic;
        }
    }

    /// <summary>
    /// 基于ASCII码排序规则的String比较器
    /// </summary>
    public class AsciiComparer : System.Collections.Generic.IComparer<string>
    {
        public int Compare(string a, string b)
        {
            if (a == b)
                return 0;
            else if (string.IsNullOrEmpty(a))
                return -1;
            else if (string.IsNullOrEmpty(b))
                return 1;
            if (a.Length <= b.Length)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] < b[i])
                        return -1;
                    else if (a[i] > b[i])
                        return 1;
                    else
                        continue;
                }
                return a.Length == b.Length ? 0 : -1;
            }
            else
            {
                for (int i = 0; i < b.Length; i++)
                {
                    if (a[i] < b[i])
                        return -1;
                    else if (a[i] > b[i])
                        return 1;
                    else
                        continue;
                }
                return 1;
            }
        }
    }
}
