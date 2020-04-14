using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.Weather
{
    public static class NMCHelper
    {
        static decimal[] rainLevelLimits = new decimal[] { 0, 9.9m, 24.9m, 49.9m, 99.9m, 249.9m };

        static Dictionary<string, string> weatherPhenomenonDic;

        static Dictionary<string, string> windPowerSpeedDic;

        static NMCHelper()
        {
            weatherPhenomenonDic = new Dictionary<string, string>();
            weatherPhenomenonDic.Add("0", "晴");
            weatherPhenomenonDic.Add("1", "多云");
            weatherPhenomenonDic.Add("2", "阴");
            weatherPhenomenonDic.Add("3", "阵雨");
            weatherPhenomenonDic.Add("4", "雷阵雨");
            weatherPhenomenonDic.Add("5", "雷阵雨伴有冰雹");
            weatherPhenomenonDic.Add("6", "雨夹雪");
            weatherPhenomenonDic.Add("7", "小雨");
            weatherPhenomenonDic.Add("8", "中雨");
            weatherPhenomenonDic.Add("9", "大雨");
            weatherPhenomenonDic.Add("10", "暴雨");
            weatherPhenomenonDic.Add("11", "大暴雨");
            weatherPhenomenonDic.Add("12", "特大暴雨");
            weatherPhenomenonDic.Add("13", "阵雪");
            weatherPhenomenonDic.Add("14", "小雪");
            weatherPhenomenonDic.Add("15", "中雪");
            weatherPhenomenonDic.Add("16", "大雪");
            weatherPhenomenonDic.Add("17", "暴雪");
            weatherPhenomenonDic.Add("18", "雾");
            weatherPhenomenonDic.Add("19", "冻雨");
            weatherPhenomenonDic.Add("20", "沙尘暴");
            weatherPhenomenonDic.Add("21", "小到中雨");
            weatherPhenomenonDic.Add("22", "中到大雨");
            weatherPhenomenonDic.Add("23", "大到暴雨");
            weatherPhenomenonDic.Add("24", "暴雨到大暴雨");
            weatherPhenomenonDic.Add("25", "大暴雨到特大暴雨");
            weatherPhenomenonDic.Add("26", "小到中雪");
            weatherPhenomenonDic.Add("27", "中到大雪");
            weatherPhenomenonDic.Add("28", "大到暴雪");
            weatherPhenomenonDic.Add("29", "浮尘");
            weatherPhenomenonDic.Add("30", "扬沙");
            weatherPhenomenonDic.Add("31", "强沙尘暴");
            weatherPhenomenonDic.Add("32", "中雨");
            weatherPhenomenonDic.Add("33", "中雪");
            weatherPhenomenonDic.Add("53", "霾");

            windPowerSpeedDic = new Dictionary<string, string>();
            windPowerSpeedDic.Add("微风", "1.5");
            windPowerSpeedDic.Add("3级", "4.4");
            windPowerSpeedDic.Add("4级", "6.7");
            windPowerSpeedDic.Add("5级", "9.35");
            windPowerSpeedDic.Add("6级", "12.3");
            windPowerSpeedDic.Add("7级", "15.5");
            windPowerSpeedDic.Add("8级", "18.95");
            windPowerSpeedDic.Add("9级", "22.6");
            windPowerSpeedDic.Add("10级", "26.45");
            windPowerSpeedDic.Add("11级", "30.55");
            windPowerSpeedDic.Add("12级", "34.8");
        }

        public static decimal? GetWindDirect(string direct)
        {
            switch (direct)
            {
                case "北风": return 0;
                case "东北风": return 45;
                case "东风": return 90;
                case "东南风": return 135;
                case "南风": return 180;
                case "西南风": return 225;
                case "西风": return 270;
                case "西北风": return 315;
                default: return null;
            }
        }

        public static string GetSpeed(string power)
        {
            if (windPowerSpeedDic.ContainsKey(power))
            {
                return windPowerSpeedDic[power];
            }
            else if (power == "9999")
            {
                return "9999.0";
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// 获取舒适度中文表示
        /// </summary>
        /// <param name="icomfort"></param>
        /// <returns></returns>
        public static string GetComfort(int icomfort)
        {
            string comfort;
            switch (icomfort)
            {
                case 4: comfort = "很热，极不适应"; break;
                case 3: comfort = "热，很不舒适"; break;
                case 2: comfort = "暖，不舒适"; break;
                case 1: comfort = "温暖，较舒适"; break;
                case 0: comfort = "舒适，最可接受"; break;
                case -1: comfort = "凉爽，较舒适"; break;
                case -2: comfort = "凉，不舒适"; break;
                case -3: comfort = "冷，很不舒适"; break;
                case -4: comfort = "很冷，极不适应"; break;
                default: comfort = "-"; break;
            }
            return comfort;
        }

        public static int? GetRainLevel(decimal? rainfall)
        {
            if (!rainfall.HasValue) return null;
            for (int i = 0; i < 6; i++)
            {
                if (rainfall <= rainLevelLimits[i])
                {
                    return i;
                }
            }
            return 6;
        }

        public static string GetWeatherPhenomenon(string num)
        {
            return weatherPhenomenonDic[num];
        }
    }
}
