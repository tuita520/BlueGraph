﻿
using System.Reflection;
using UnityEngine;

namespace BlueGraph.Tests
{
    public class InputPort<T>: Port
    {

    }

    public class OutputPort<T>: Port
    {

    }

    public class FuncNode : AbstractNode
    {
        public FuncNode(MethodInfo mi)
        {

        }

        public override object OnRequestValue(Port port)
        {
            throw new System.NotImplementedException();
        }
    }
}
