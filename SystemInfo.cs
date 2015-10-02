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
    /// <summary>
    /// Class to structure Video Adapter
    /// </summary>
    [Serializable]
    public class VideoAdapter
    {
        /// <summary>
        /// Заполнено?
        /// </summary>
        public bool isPool;
        /// <summary>
        /// имя компьютера
        /// </summary>
        public string SystemName;
        /// <summary>
        /// наименование устройства
        /// </summary>
        public string Caption;
        /// <summary>
        /// описание устройства
        /// </summary>
        public string Description;
        /// <summary>
        /// идентификатор устройства
        /// </summary>
        public string DeviceID;
        /// <summary>
        /// Размер памяти видеоадаптера
        /// </summary>
        public string AdapterRAM;
        /// <summary>
        /// текущее разрешение экрана по горизонтали (точек)
        /// </summary>
        public string CurrentHorizontalResolution;
        /// <summary>
        /// текущее разрешение экрана по вертикали (точек)
        /// </summary>
        public string CurrentVerticalResolution;
        /// <summary>
        /// число цветов в текущем разрешении экрана
        /// </summary>
        public string CurrentNumberOfColors;
        /// <summary>
        /// текущее разрешение экрана и число цветов
        /// </summary>
        public string VideoModeDescription;
        /// <summary>
        /// качество цветопередачи (количество бит на пиксель)
        /// </summary>
        public string CurrentBitsPerPixel;
        /// <summary>
        /// частота обновления экрана, Гц - (0 - по умолчанию, 0xFFFFFFFF - оптимальная)
        /// </summary>
        public string CurrentRefreshRate;
        /// <summary>
        /// дата-время последней модификации текущего видеодрайвера
        /// </summary>
        public string DriverDate;
        /// <summary>
        /// версия текущего видеодрайвера
        /// </summary>
        public string DriverVersion;
        /// <summary>
        /// идентификатор устройства Plug-and-Play
        /// </summary>
        public string PNPDeviceID;
        /// <summary>
        /// описание видеопроцессора
        /// </summary>
        public string VideoProcessor;
    }
    /// <summary>
    /// Class to structure Mother Board
    /// </summary>
    [Serializable]
    public class BaseBoard
    {
        /// <summary>
        /// Заполнено?
        /// </summary>
        public bool isPool;
        /// <summary>
        /// Описание платы
        /// </summary>
        public string Description;
        /// <summary>
        /// Производитель
        /// </summary>
        public string Manufacturer;
        /// <summary>
        /// Номер продукта
        /// </summary>
        public string Product;
        /// <summary>
        /// Серийный номер
        /// </summary>
        public string SerialNumber;
        /// <summary>
        /// Тэг
        /// </summary>
        public string Tag;
        /// <summary>
        /// Версия
        /// </summary>
        public string Version;
    }
    /// <summary>
    /// Class to structure Network Adapter
    /// </summary>
    [Serializable]
    public class NetworkAdapter
    {
        /// <summary>
        /// Заполнено?
        /// </summary>
        public bool isPool;
        /// <summary>
        /// имя компьютера
        /// </summary>
        public string SystemName;
        /// <summary>
        /// описание устройства
        /// </summary>
        public string Caption;
        /// <summary>
        /// наименование устройства
        /// </summary>
        public string Name;
        /// <summary>
        /// Сервисное наименование устройства
        /// </summary>
        public string ServiceName;
        /// <summary>
        /// описание устройства
        /// </summary>
        public string Description;
        /// <summary>
        /// производитель
        /// </summary>
        public string Manufacturer;
        /// <summary>
        /// тип устройства
        /// </summary>
        public string AdapterType;
        /// <summary>
        /// идентификатор устройства
        /// </summary>
        public string DeviceID;
        /// <summary>
        /// идентификатор устройства Plug-and-Play
        /// </summary>
        public string PNPDeviceID;
        /// <summary>
        /// индекс сетевого адаптера в системном реестре
        /// </summary>
        public string Index;
        /// <summary>
        /// MAC - адрес
        /// </summary>
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
