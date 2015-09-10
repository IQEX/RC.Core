// =====================================//==============================================================//
//                                      //                                                              //         
// Source="root\\Security\\CryptByte.cs"//             Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="6.3"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Security
{
    [Obsolete("Необходимый нам костыль, не используйте это!")]
    internal class CryptByte
    {
        internal string ToCrypt(byte[] clr)
        {
            StringBuilder buld2 = new StringBuilder();
            foreach(byte var in clr)
            {
                String PST = var.ToString("000");
                buld2.Append(("0x" + PST + "0x000x0").Length.ToString("00000") + "0x" + PST + "0x" + (var * 2 / 3).ToString("000") + "x0");
            }
            return buld2.ToString();
        }
        internal byte[] EnCrypt(string str)
        {                                                           // Я до сих пор внятно не понял как оно работает, но главное работает
            char[] lchrst = str.ToCharArray();                      // Мы переводим строку в массив символов
            string vtsrt = "";                                      // Буфер
            for (int i = 0; i <= lchrst.Length - 1; i++) 
            {
                string slit = (lchrst[i].ToString() + 
                    lchrst[i + 1].ToString() + 
                    lchrst[i + 2].ToString() + 
                    lchrst[i + 3].ToString() + 
                    lchrst[i + 4].ToString()).ToString();           // Соеденяем "длину" байта
                int leghtBit = Convert.ToInt32(slit);               // Получаем длину
                str = str.Remove(0, 5);                             // Удаляем длину из исходной строки
                i = i + 4;                                          // Прибавляем в целому числу кол во символов длины
                string b1 = str.Substring(0, leghtBit);             // Получаем кодированную строку байта
                str = str.Remove(0, leghtBit);                      // Удаляем байт из исходной строки
                string ss1 = b1.Remove(0, 2);
                string ss2 = ss1.Substring(0, 3);
                // декодируем и получаем целочисленное число
                vtsrt += ss2 + "|";
                i = i + leghtBit;                                   // Прибавляем в целому числу кол во символов байта
            }
            string[] bit2 = vtsrt.Split('|');                       // Разделяем строку байтов на массив строк
            int[] bit3 = new int[bit2.Length - 1];                  // буфер
            int p = 0;
            foreach(string sy in bit2)
            {
                if(sy != "")
                    bit3[p++] = Convert.ToInt32(sy);                // Ковертируем строку в целове число
            }
            byte[] bit4 = new byte[bit3.Length];                    // буфер
            int xl = 0;
            foreach(int sy2 in bit3)
            {
                bit4[xl++] = Convert.ToByte(sy2);                   // Конвертируем целые числа в байты
            }
            return bit4;                                            // При помощи магии мы декодировали строку в байты
        }
    }
}
