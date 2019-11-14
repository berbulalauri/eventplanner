﻿using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string _holiday = "holidayxml.xml";
            Holiday holiday = new Holiday
            {
                Date = DateTime.Now,
                Designation = "holiday tutorils",
                IsDayOff = false

            };
            Console.WriteLine($"hoilday object was created : ");
            Console.WriteLine($"{holiday}");

            //Stream stream = null;
            Stream writeStream = null;
            Stream readStream = null;

            try
            {
                //BinaryFormatter binaryFormatter = new BinaryFormatter();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Holiday));

                using (writeStream = new FileStream($"../../../{_holiday}", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    xmlSerializer.Serialize(writeStream, holiday);
                    Console.WriteLine($"object was serialized in {_holiday}");
                }
                // writeStream?.Close();


                using (readStream = new FileStream($"../../../{_holiday}", FileMode.OpenOrCreate, FileAccess.Read))
                {
                    Holiday holidayBinnary = (Holiday)xmlSerializer.Deserialize(readStream);
                    Console.WriteLine($"object was Deserialized from {_holiday}");
                    Console.WriteLine(holidayBinnary);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"something went wrong {ex.Message}");

            }
            //finally
            //{
            //    //stream.Close();
            //    writeStream?.Close();
            //    readStream?.Close();
            //}
        }
    }
    [Serializable]
    public class Holiday
    {
        public DateTime Date { get; set; }
        public string Designation { get; set; }
        public bool IsDayOff { get; set; }

        public override string ToString()
        {
            return $"data: {Date}\n Designation: {Designation}\n dayoff: {IsDayOff}";
        }

    }
}
