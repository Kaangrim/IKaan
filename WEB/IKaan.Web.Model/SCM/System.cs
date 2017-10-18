using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IKaan.Web.Model.SCM
{
    public class SQLParmeter
    {
        public int ObjectID { get; set; }
        public int SchemaID { get; set; }
        public string ObjectName { get; set; }
        public string ObjectType { get; set; }
        public int ParameterID { get; set; }
        public string ParameterName { get; set; }
        public string ParameterDateType { get; set; }
        public int ParameterMaxBytes { get; set; }
        public bool ParameterOutputState { get; set; }

    }
    
}