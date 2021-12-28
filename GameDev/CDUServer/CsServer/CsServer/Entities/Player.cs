using System;
using CsServer.Attributes;
using CsServer.CommonBases;

namespace CsServer.Entities
{
    public class Player:EntityBase
    {   
        [RpcMethod(0,new []{typeof(RpcTypeInt)})]
        public void HelloWorld(int input)
        {
            Console.WriteLine("HelloWorld {0}",input);
        }
    }
}