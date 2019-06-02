﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tensorflow.Keras
{
    public class backend
    {
        /// <summary>
        /// A global dictionary mapping graph objects to an index of counters used
        /// for various layer names in each graph.
        /// Allows to give unique autogenerated names to layers, in a graph-specific way.
        /// </summary>
        public static Dictionary<string, Dictionary<(string, string), int>> PER_GRAPH_LAYER_NAME_UIDS = new Dictionary<string, Dictionary<(string, string), int>>();
        public static Dictionary<string, RefVariable> _GRAPH_VARIABLES = new Dictionary<string, RefVariable>();
        public static void track_variable(RefVariable v)
        {
            var graph = v.graph;
            _GRAPH_VARIABLES[graph.graph_key] = v;
        }

        public static Tensor placeholder(int[] shape = null, 
            int ndim = -1, 
            TF_DataType dtype = TF_DataType.DtInvalid, 
            bool sparse = false, 
            string name = null)
        {
            if(sparse)
            {
                throw new NotImplementedException("placeholder sparse is true");
            }
            else
            {
                return gen_array_ops.placeholder(dtype: dtype, shape: new TensorShape(shape), name: name);
            }
        }

        public static Graph get_graph()
        {
            return ops.get_default_graph();
        }
    }
}
