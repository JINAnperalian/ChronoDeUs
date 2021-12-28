using System;

namespace CsServer.CommonBases
{
    public abstract class AttributeBase:Attribute
    {
        public abstract void DoAttribute(object[] args);
    }
}