using System;
using System.IO;
using Newtonsoft.Json;//Library Standard JSON 


namespace CRUDJSON
{
    class Program
    {
        struct Karyawan
        {
            public string nip;
            public string nama;
            public string gol;
        }
        private string namaFile = @"dbcrud.json";

        private void create()
        {
            Karyawan karyawan = new Karyawan();
            Console.Write("Input Nip : ");
            karyawan.nip = Console.ReadLine();
            Console.Write("\nInput Nama : ");
            karyawan.nama = Console.ReadLine();
            Console.Write("\nInput Golongan : ");
            karyawan.gol = Console.ReadLine();
            string jsonResult = JsonConvert.SerializeObject(karyawan);
            Console.Write(jsonResult.ToString());
            using (var tw = new StreamWriter(namaFile, true))
                {
                    tw.WriteLine(jsonResult.ToString());
                    tw.Close();
                }
            
            
        }
        private void update()
        {
            Karyawan karyawan = new Karyawan();
            string json = File.ReadAllText(namaFile);
            Console.Write("Input Nip yang akan diubah : ");
            karyawan.nip = Console.ReadLine();
            
            string jsonResult = JsonConvert.SerializeObject(karyawan);

            using (var tw = new StreamWriter(namaFile, true))
            {
                tw.WriteLine(jsonResult.ToString());
                tw.Close();
            }


        }

        static void Main(string[] args)
        {
            Program objProgram = new CRUDJSON.Program();
            Console.WriteLine("Choose Your Options : 1 - Add, 2 - Update, 3 - Delete, 4 - Select \n");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    objProgram.create();
                    break;
               
            }
            
            Console.ReadLine();

        }
    }
}
    

