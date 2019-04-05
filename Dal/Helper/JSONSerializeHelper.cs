using Dal.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Helper
{
    public class JSONSerializeHelper
    {
        public static string Serilialize<T>(T model)
        {
            var json = JsonConvert.SerializeObject(model);
            return json;
        }

        public static T Desirialize<T>(string json)
        {
            var model = JsonConvert.DeserializeObject<T>(json);
            return model;
        }
    }
}
