using ElasticEmail.Api;
using ElasticEmail.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticRecruitmentTask
{
    public class ConnectionConfig
    {
        public EmailsApi config()
        {
            Configuration configuration = setConfigOptions();           
            EmailsApi c = new EmailsApi(configuration);
            return c;
        }
        public Configuration setConfigOptions()
        {
            Configuration configuration = new Configuration();
            configuration.BasePath = "https://api.elasticemail.com/v4";
            configuration.AddApiKey("X-ElasticEmail-ApiKey", "6970EFBEBA0C6C6AF38A349D83C8591CB1A8914DB74298AC6D7F7FF6C1C6FE1EEC8160083DBC56001BC3F42E3E3F11E0");
            return configuration;
        }
    }
}
