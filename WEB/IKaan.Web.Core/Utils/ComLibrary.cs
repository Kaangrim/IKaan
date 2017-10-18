using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IKaan.Web.Core.Utils
{
    public class comLibrary
    {
        ///<summary>
        ///Null 일경우 ""리턴
        ///</summary>
        ///<param name="obj">값</param>
        public static string objC(object obj)
        {
            string strR = "";
            try
            {
                strR = obj.ToString().Trim();
                return strR;
            }
            catch
            {
                return strR;
            }
        }

        ///<summary>
        ///string[]를 받아서 구분자로 구분하는 문자열리턴
        ///</summary>
        ///<param name="str">문자열 배열</param>
        ///<param name="des">구분자</param>
        ///<param name="des">문자열</param>
        public static string getArrayToString(string[] str, string des)
        {
            int count;
            string rep = "";

            count = str.Length;
            for (int i = 0; i < count; i++)
            {
                rep = rep + str[i];
                if (i < count - 1)
                    rep = rep + des;
            }
            return rep;
        }

        //<summary>
        /// 숫자에서 컴마를 찍고 문자로 변환
        ///</summary>
        ///<param name="ValueS">값</param>
        public static string setComma(int ValueS)
        {
            try
            {
                return string.Format("{0:#,##0}", ValueS).Trim();
            }
            catch
            {
                return "";
            }
        }

        ///<summary>
        ///두개의 시간 간격을 계산
        ///</summary>
        ///<param name="sTime">시작시간</param>
        ///<param name="eTime">끝시간</param>
        public static double timeEmp(string sTime, string eTime)
        {
            if (sTime.Length < 14 || eTime.Length < 14)
                return -1;
            else
            {
                DateTime dtStart = new DateTime(int.Parse(sTime.Substring(0, 4)),
                    int.Parse(sTime.Substring(4, 2)),
                    int.Parse(sTime.Substring(6, 2)),
                    int.Parse(sTime.Substring(8, 2)),
                    int.Parse(sTime.Substring(10, 2)),
                    int.Parse(sTime.Substring(12, 2))
                    );
                DateTime dtEnd = new DateTime(int.Parse(eTime.Substring(0, 4)),
                    int.Parse(eTime.Substring(4, 2)),
                    int.Parse(eTime.Substring(6, 2)),
                    int.Parse(eTime.Substring(8, 2)),
                    int.Parse(eTime.Substring(10, 2)),
                    int.Parse(eTime.Substring(12, 2))
                    );
                TimeSpan tp;
                tp = dtStart - dtEnd;

                if (tp.TotalHours < 0)
                    return 0 - tp.TotalHours;
                else
                    return tp.TotalHours;
            }
        }

        ///<summary>
        ///초의 값을 HH:MM:SS 의 형식으로
        ///</summary>
        ///<param name="sTimes">시간</param>
        public static string secTotime(double sTimes)
        {
            int iHour = 0;
            int iMin  = 0;
            int iSec  = 0;

            iHour = (int)(sTimes /3600);
            sTimes -= iHour*3600;

            iMin = (int)(sTimes/600);
            sTimes -= iMin*60;

            iSec = (int)sTimes;

            return iHour.ToString("00")+":"+iMin.ToString("00")+":"+iSec.ToString("00");
        }

        ///<summary>
        ///정의된 일자의 요일을 가져오기
        ///</summary>
        ///<param name="dDate">일자</param>
        ///<param name="tYpe">넘버링</param>
        public static string DayWeek(string dDate, int tYpe)
        {
            DateTime datDate = new DateTime(int.Parse(dDate.Substring(0, 4)),
                int.Parse(dDate.Substring(4, 2)),
                int.Parse(dDate.Substring(6, 2)));
            int intDay = int.Parse(datDate.DayOfWeek.ToString("d"));

            if (tYpe == 1)
            {
                switch (intDay)
                {
                    case 0: return "일";
                    case 1: return "월";
                    case 2: return "화";
                    case 3: return "수";
                    case 4: return "목";
                    case 5: return "금";
                    case 6: return "토";
                    case 7: return "일";
                    default: return " ";
                }
            }
            else
            {
                switch (intDay)
                {
                    case 0: return "SUN";
                    case 1: return "MON";
                    case 2: return "TUE";
                    case 3: return "WED";
                    case 4: return "THU";
                    case 5: return "FRI";
                    case 6: return "SAT";
                    case 7: return "SUN";
                    default: return " ";
                }
            }
        }

        ///<summary>
        ///정상적인 일자 체크
        ///</summary>
        ///<param name="sDate">일자</param>
        public static bool ValidDate(string sDate)
        {
            if (sDate.Trim().Length == 8)
            {
                try
                {
                    DateTime datDate = DateTime.ParseExact(sDate, "yyyyMMdd", null);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }

        ///<summary>
        ///특정일자의 가감
        /// 0:년, 1:월, 2:일
        ///</summary>
        ///<param name="sDate">일자</param>
        ///<param name="iFG">넘버링</param> 
        ///<param name="iValue">값</param>
        public static string DateCalculate(string sDate, int iFG, int iValue)
        { 
            DateTime dt = new DateTime(int.Parse(sDate.Substring(0,4)),
                int.Parse(sDate.Substring(4,2)),
                int.Parse(sDate.Substring(6,2)));
            string sTemp = null;

            switch (iFG)
            { 
                case 0:
                    sTemp = dt.AddYears(iValue).ToString("yyyymmdd");
                    break;
                case 1:
                    sTemp = dt.AddMonths(iValue).ToString("yyyymmdd");
                    break;
                case 2:
                    sTemp = dt.AddDays(iValue).ToString("yyyymmdd");
                    break;
            }
            return sTemp;
        }
    }
}