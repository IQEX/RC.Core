// =====================================//==============================================================//
//                                      //                                                              //         
// Source="root\\SystemInfo.cs"         //     Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>    //
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
    }
}
