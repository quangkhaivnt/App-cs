using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPMongoDB.Helper
{
    public class Common
    {
        //Define all global variable
        private static string DB_NAME = "mydatabase";
        private static string COLLECTION_NAME = "user";
        public static string API_KEY = "NcIM5upbXxzxvmFq7bjGjVMRTaJDd99i";


        public static string API_DOCUMENTS_LINK = $"https://api.mlab.com/api/1/databases/{DB_NAME}/collections/{COLLECTION_NAME}";
        public static string API_SELECT_DOCUMENTS_LINK = $"https://api.mlab.com/api/1/databases/{DB_NAME}/collections/{COLLECTION_NAME}?apiKey={API_KEY}";
    }
}
