using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MODUL8_1302210097
{
	public class Config
	{
		public string lang { get; set; }
		public Transfer transfer { get; set; }
		public string[] methods { get; set; }
		public Confirmation confirmation { get; set; }

		public class Transfer
		{
			public int threshold { get; set; }
			public int low_fee { get; set; }
			public int high_fee { get; set; }
		}
		public class Confirmation
		{
			public string en { get; set; }
			public string id { get; set; }
		}

		public Config() { }
		public Config(string lang, Transfer transfer, string[] methods, Confirmation confirmation)
		{
			this.lang = lang;
			this.transfer = transfer;
			this.methods = methods;
			this.confirmation = confirmation;
		}
	}
	public class BankTransferConfig
	{
		public BankTransferConfig()
		{
		public Config config { get; set; }
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string configFileName = "bank_transfer_config.json";
        public BankTransferConfig()
        {
            try
            {
                ReadConfig();
            }
            catch
            {
                SetDefault();
                WriteConfig();
            }
        }
        private Config ReadConfig()
        {
            string jsonFromFile = File.ReadAllText(path + '/' + configFileName);
            config = JsonSerializer.Deserialize<Config>(jsonFromFile);
            return config;
        }
		public void ubahbahasa()
		{
			if(config.lang == "en")
			{
				Console.WriteLine("Please insert the amount of money to transfer : ");
			}else if(config.lang == "id)"{
                Console.WriteLine("Masukan jumlah uang yang akan di-transfer : ");

            }
		}
		public void isinputvalid()
		{
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            decimal fee;
            if (amount < config.transfer.threshold)
            {
                fee = config.transfer.low_fee;
            }
            else
            {
                fee = config.transfer.high_fee;
            }
            Console.WriteLine("Available transfer methods:");
            foreach (string method in config.methods)
            {
                Console.WriteLine(method);
            }

            Console.WriteLine("Confirmation:");
            if (config.lang == "en")
            {
                Console.WriteLine("Are you sure you want to transfer {0:C}?", amount);
            }
            else if (config.lang == "id")
            {
                Console.WriteLine("Apakah Anda yakin ingin mentransfer {0:C}?", amount);
            }
            Console.WriteLine("Transfer fee: {0:C}", fee);
        }
    }

}