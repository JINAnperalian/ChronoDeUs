using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CsServer.Attributes
{
    public abstract class RpcParamTypeBase
    {
        public object? Trans(object o)
        {
            return o;
        }
    }
    public class RpcParamType<T>:RpcParamTypeBase
    {
        public new T? Trans(object o)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(o));
        }
    };
    
    public class RpcTypeInt:RpcParamType<int>
    {
        
    }
    
    public class RpcTypeStr:RpcParamType<string>
    {
        
    }

    public class RpcTypeMap:Dictionary<string,RpcParamTypeBase>
    {
        public RpcTypeMap()
        {
            this["RpcTypeInt"] = new RpcTypeInt();
        }
    }
}