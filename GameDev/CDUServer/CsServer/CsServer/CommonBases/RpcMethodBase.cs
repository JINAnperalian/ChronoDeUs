using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using CsServer.Attributes;

namespace CsServer.CommonBases
{
    public class RpcMethodBase
    {
        public MethodInfo MethodInfo;
        public List<RpcParamTypeBase> RpcParamTypeBases;


        public RpcMethodBase(MethodInfo methodInfo, List<RpcParamTypeBase> rpcParamTypeBases)
        {
            MethodInfo = methodInfo;
            RpcParamTypeBases = rpcParamTypeBases;
        }
    }
}