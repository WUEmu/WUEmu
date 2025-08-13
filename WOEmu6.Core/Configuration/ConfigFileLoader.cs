using System.IO;
using System.Text.Json;

namespace WOEmu6.Core.Configuration
{
    public class ConfigFileLoader
    {
        private readonly string _path;

        public ConfigFileLoader(string path)
        {
            _path = path;
        }

        public T GetConfig<T>()
        {
            if (!System.IO.File.Exists(_path))
                throw new FileNotFoundException("Could not find server.json!");
            
            using (var fs = System.IO.File.Open(_path, FileMode.Open))
            {
                var reader = new StreamReader(fs);
                var contents = reader.ReadToEnd();
                return JsonSerializer.Deserialize<T>(contents, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            }
        }
    }
}
