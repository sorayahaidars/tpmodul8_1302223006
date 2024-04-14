using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_1302223006
{
    public class CovidConfig
    {
        public String satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public String pesan_ditolak { get; set; }
        public String pesan_diterima { get; set; }
    }
    public class TestConfig
    {

        public CovidConfig config;

        private const string file_path = "D:\\C#\\tpmodul8_1302223006\\covid_config.json.json\";

        public TestConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteConfigFile();
            }
        }

        public void ReadConfigFile()
        {
            String configJsonData = File.ReadAllText(file_path);
            this.config = JsonSerializer.Deserialize<CovidConfig>(configJsonData);
        }

        public void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String text = JsonSerializer.Serialize(config);
            File.WriteAllText(file_path, text);
        }

        public void SetDefault()
        {
            config = new CovidConfig();

            config.satuan_suhu = "celcius";
            config.batas_hari_demam = 14;
            config.pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            config.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        public void UbahSatuan()
        {
            if (this.config.satuan_suhu == "celcius")
            {
                this.config.satuan_suhu = "fahrenheit";
            }
            else
            {
                this.config.satuan_suhu = "celcius";
            }

            String text = JsonSerializer.Serialize(config);
            File.WriteAllText(file_path, text);
        }
    }
}