using System;
using System.Collections.Generic;
using System.Reflection;
using CsServer.CommonBases;

namespace CsServer.Attributes
{
    public class RpcMethod : AttributeBase
    {
        public int RpcType { get; }
        public List<RpcParamTypeBase> Types=new List<RpcParamTypeBase>();

        public RpcMethod(int rpcType,Type[] types)
        {
            RpcType = rpcType;
            foreach (var type in types)
            {
                Types.Add(new RpcTypeMap()[type.Name]);
            }
        }

        public override void DoAttribute(object[] args)
        {
            EntityBase entity = (EntityBase) args[0];
            MethodInfo method = (MethodInfo) args[1];
            entity.AddRpc(method.Name, method,Types);
        }
    }
}