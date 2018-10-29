using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPMongoDB.Helper
{
    
        /* 
         * {
    "_id": {
        "$oid": "5bc89b37fb6fc0602748cbcf"
    },
    "user": "admin"
           }
         */

        public class Id
        {
            [JsonProperty(PropertyName ="$oid")]
            public string oid { get; set; }
        }

        public class User
        {
            public Id _id { get; set; }
            public string user { get; set; }
        }
    
}
