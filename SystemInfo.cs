// =====================================//==============================================================//
//                                      //                                                              //         
// Source="root\\SystemInfo.cs"         //             Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="7.5"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace Rc.Framework
{
    [Serializable]
    public class VideoAdapter
    {
        public bool isPool;
        // имя компьютера
        public string SystemName;
        // наименование устройства
        public string Caption;
        // описание устройства
        public string Description;
        // идентификатор устройства
        public string DeviceID;
        // размер памяти видеоадаптера
        public string AdapterRAM;
        // текущее разрешение экрана по горизонтали (точек)
        public string CurrentHorizontalResolution;
        // текущее разрешение экрана по вертикали (точек)
        public string CurrentVerticalResolution;
        // число цветов в текущем разрешении экрана
        public string CurrentNumberOfColors;
        // текущее разрешение экрана и число цветов
        public string VideoModeDescription;
        // качество цветопередачи (количество бит на пиксель)
        public string CurrentBitsPerPixel;
        // частота обновления экрана, Гц - (0 - по умолчанию, 0xFFFFFFFF - оптимальная)
        public string CurrentRefreshRate;
        // дата-время последней модификации текущего видеодрайвера
        public string DriverDate;
        // версия текущего видеодрайвера
        public string DriverVersion;
        // идентификатор устройства Plug-and-Play
        public string PNPDeviceID;
        // описание видеопроцессора
        public string VideoProcessor;
    }
    [Serializable]
    public class BaseBoard
    {
        public bool isPool;
        public string Description;
        public string Manufacturer;
        public string Product;
        public string SerialNumber;
        public string Tag;
        public string Version;
    }
    [Serializable]
    public class NetworkAdapter
    {
        public bool isPool;
        // имя компьютера
        public string SystemName;
        // наименование устройства
        public string Caption;
        // наименование устройства
        public string Name;
        // краткое наименование устройства
        public string ServiceName;
        // описание устройства
        public string Description;
        // производитель
        public string Manufacturer;
        // тип устройства
        public string AdapterType;
        // идентификатор устройства
        public string DeviceID;
        // идентификатор устройства Plug-and-Play
        public string PNPDeviceID;
        // индекс сетевого адаптера в системном реестре
        public string Index;
        // MAC - адрес
        public string MACAddress;
    }
    internal static class SystemInfo
    {
        /// <summary>
        /// Получает временную зону 
        /// </summary>
        /// <returns></returns>
        public static string TimeZone()
        {
            return string.Format("(local - UTC): {0}h", (int)Math.Round((DateTime.Now - DateTime.UtcNow).TotalHours));
        }
        /// <summary>
        /// Получает конфигурации базовой платы
        /// </summary>
        /// <returns></returns>
        public static BaseBoard MotherBoardModel()
        {
            BaseBoard Board = new BaseBoard();
            Board.isPool = true;
            try
            {
                string computer = Environment.MachineName;
                string path = @"\\" + computer + @"\root\CIMV2";
                ManagementScope scope = new ManagementScope(path);
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_BaseBoard");
                ManagementObjectSearcher search = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection instances = search.Get();
                foreach (ManagementObject obj in instances)
                {
                    Board.Description = obj["Description"].ToString();
                    Board.Manufacturer = obj["Manufacturer"].ToString();
                    Board.Product = obj["Product"].ToString();
                    Board.SerialNumber = obj["SerialNumber"].ToString();
                    Board.Tag = obj["Tag"].ToString();
                    Board.Version = obj["Version"].ToString();
                }
                Board.isPool = true;
            }
            catch(Exception ex)
            {
                Terminal.WriteLine(ex.ToString());
            }
            return Board;
        }
        /// <summary>
        /// Получение конфигурации видео адаптеров
        /// </summary>
        /// <returns></returns>
        public static VideoAdapter[] ModelVideoAdapter()
        {
            ManagementObjectSearcher searcher11 =
                new ManagementObjectSearcher("root\\CIMV2",
                "SELECT * FROM Win32_VideoController");
            VideoAdapter[] v = new VideoAdapter[searcher11.Get().Count];
            int i = 0;
            
            
            foreach (ManagementObject queryObj in searcher11.Get())
            {
                v[i] = new VideoAdapter();
                v[i].isPool = false;
                try
                {
                    v[i].SystemName = queryObj["SystemName"].ToString();
                    v[i].Description = queryObj["Description"].ToString();
                    v[i].DeviceID = queryObj["DeviceID"].ToString();
                    v[i].AdapterRAM = queryObj["AdapterRAM"].ToString();
                    v[i].CurrentHorizontalResolution = queryObj["CurrentHorizontalResolution"].ToString();
                    v[i].CurrentVerticalResolution = queryObj["CurrentVerticalResolution"].ToString();
                    v[i].CurrentNumberOfColors = queryObj["CurrentNumberOfColors"].ToString();
                    v[i].VideoModeDescription = queryObj["VideoModeDescription"].ToString();
                    v[i].CurrentBitsPerPixel = queryObj["CurrentBitsPerPixel"].ToString();
                    v[i].CurrentRefreshRate = queryObj["CurrentRefreshRate"].ToString();
                    v[i].DriverDate = queryObj["DriverDate"].ToString();
                    v[i].DriverVersion = queryObj["DriverVersion"].ToString();
                    v[i].PNPDeviceID = queryObj["PNPDeviceID"].ToString();
                    v[i].PNPDeviceID = queryObj["PNPDeviceID"].ToString();
                    v[i].VideoProcessor = queryObj["VideoProcessor"].ToString();
                    v[i].isPool = true;
                }
                catch(Exception ex)
                {
                    Terminal.Write(ex.ToString());
                }
                i++;
            }
            return v;
        }
        /// <summary>
        /// Получение конфигурации интернет интерфейсов
        /// </summary>
        /// <returns></returns>
        public static NetworkAdapter[] NetWorkAdapter()
        {
            string computer = Environment.MachineName;
            string path = @"\\" + computer + @"\root\CIMV2";
            ManagementScope scope = new ManagementScope(path);
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter");
            ManagementObjectSearcher search = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection instances = search.Get();
            NetworkAdapter[] Board = new NetworkAdapter[search.Get().Count];
            int i = 0;
            foreach (ManagementObject obj in instances)
            {
                try
                {
                    Board[i] = new NetworkAdapter();
                    Board[i].isPool = false;
                    Board[i].Caption = obj["Caption"].ToString();
                    Board[i].SystemName = obj["SystemName"].ToString();
                    Board[i].Name = obj["Name"].ToString();
                    Board[i].ServiceName = obj["ServiceName"].ToString();
                    Board[i].Description = obj["Description"].ToString();
                    Board[i].Manufacturer = obj["Manufacturer"].ToString();
                    Board[i].DeviceID = obj["DeviceID"].ToString();
                    Board[i].PNPDeviceID = obj["PNPDeviceID"].ToString();
                    Board[i].Index = obj["Index"].ToString();
                    Board[i].AdapterType = obj["AdapterType"].ToString();
                    Board[i].MACAddress = obj["MACAddress"].ToString();
                    Board[i].isPool = true;
                }
                catch(Exception ex)
                {
                    Terminal.WriteLine(ex.ToString());
                }
                i++;
            }
            return Board;
        }
    }
}
