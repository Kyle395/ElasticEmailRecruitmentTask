using ElasticEmail.Api;
using ElasticEmail.Client;

namespace ElasticRecruitmentTask
{
    public class ConnectionConfig
    {
        private readonly string basePath = "https://api.elasticemail.com/v4";
        private readonly string apiKey = "6970EFBEBA0C6C6AF38A349D83C8591CB1A8914DB74298AC6D7F7FF6C1C6FE1EEC8160083DBC56001BC3F42E3E3F11E0";
        public EmailsApi Config()
        {
            Configuration configuration = SetConfigOptions();           
            EmailsApi emailsApi = new EmailsApi(configuration);
            return emailsApi;
        }
        public Configuration SetConfigOptions()
        {
            Configuration configuration = new Configuration();
            configuration.BasePath = basePath;
            configuration.AddApiKey("X-ElasticEmail-ApiKey", apiKey);
            return configuration;
        }
    }
}
