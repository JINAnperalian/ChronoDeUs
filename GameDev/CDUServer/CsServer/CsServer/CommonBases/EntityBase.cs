using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CsServer.Attributes;
using CsServer.CommonBases;

namespace CsServer
{
    public class EntityBase
    {
        protected Dictionary<string, RpcMethodBase> RpcMap;

        public EntityBase()
        {
            RpcMap = new Dictionary<string, RpcMethodBase>();
            foreach (var method in this.GetType().GetMethods())
            {
                foreach (var attribute in method.GetCustomAttributes<AttributeBase>())
                {
                    attribute.DoAttribute(new object[] {this, method});
                }
            }
        }

        public void CallRpc(string name, object[] args = null!)
        {
            var method = RpcMap[name];
            object?[] args_trans = new object[method.RpcParamTypeBases.Count];
            for (int i = 0; i < method.RpcParamTypeBases.Count; i++)
            {
                var type = method.RpcParamTypeBases[i];
                args_trans[i] = type.Trans(args[i]);
            }

            RpcMap[name].MethodInfo.Invoke(this, args_trans);
        }

        public void AddRpc(string name, MethodInfo methodInfo, List<RpcParamTypeBase> Types)
        {
            RpcMap[name] = new RpcMethodBase(methodInfo, Types);
        }
    }
}