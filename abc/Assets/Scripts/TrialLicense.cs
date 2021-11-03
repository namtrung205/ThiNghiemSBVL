using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using UnityEngine.Networking;
using System.Net;
using System.Globalization;
using UnityEngine.UI;
using System.IO;

public class TrialLicense : MonoBehaviour
{
    public long releaseTicksDay;
    private long lastRunTicksDay;

    public Text days;

    public uint numbDaysCanRun;

    public GameObject windowWarningTrial;
    public GameObject listEx;

    public string nameBinData = @"Templates\Data.bin";

    void Start()
    {
    #if UNITY_STANDALONE_WIN
        try
        {
            IEnumerable<string> linesOfBin = File.ReadLines(nameBinData);

            foreach (string line in linesOfBin)
            {
                if (line.Contains("|"))
                {
                    String[] dataSplit = line.Split('|');
                    releaseTicksDay = (long)Convert.ToInt64(dataSplit[0]);
                    lastRunTicksDay = (long)Convert.ToInt64(dataSplit[1]);
                }
            }

            DateTime todayRun = DateTime.Now;
            DateTime releaseDay = new DateTime(releaseTicksDay);
            DateTime lastRunDay = new DateTime(lastRunTicksDay);

            double countDaysFromLastRun = (lastRunDay - todayRun).TotalDays;
            if(countDaysFromLastRun > 0) //detect user fake date time
            {
                days.text = "0";
                if (windowWarningTrial != null)
                {
                    windowWarningTrial.SetActive(true);
                }
                if (listEx != null)
                {
                    listEx.SetActive(false);
                }
                return;
            }

            double countDays = (todayRun - releaseDay).TotalDays;

            if (countDays > numbDaysCanRun)
            {
                days.text = "0";
                if (windowWarningTrial != null)
                {
                    windowWarningTrial.SetActive(true);
                }
                if (listEx != null)
                {
                    listEx.SetActive(false);
                }
            }
            else
            {
                windowWarningTrial.SetActive(false);
                days.text = ((int)(numbDaysCanRun - countDays + 1)).ToString();
                String dataToSave = releaseTicksDay.ToString() + "|" + todayRun.Ticks.ToString();
                File.WriteAllText(nameBinData, dataToSave);
                return;
            }
        }
        catch (Exception)
        {
            days.text = "0";
            if (windowWarningTrial != null)
            {
                windowWarningTrial.SetActive(true);
            }
            if (listEx != null)
            {
                listEx.SetActive(false);
            }
            return;
        }
#else
        return;
#endif
    }



    //void Start()
    //{
    //    if (UnityEngine.PlayerPrefs.HasKey("FirstInstallDate"))
    //    {
    //        string tickString = UnityEngine.PlayerPrefs.GetString("FirstInstallDate");
    //        UnityEngine.Debug.Log(tickString);
    //        firstInstallDateTicks = Convert.ToInt64(UnityEngine.PlayerPrefs.GetString("FirstInstallDate"));

    //        DateTime firstInstallDate = new DateTime(firstInstallDateTicks);

    //        //Get to day ticks
    //        DateTime todayRunDate = GetNextTimeOffline();

    //        double countDays = (todayRunDate - firstInstallDate).TotalDays;

    //        UnityEngine.Debug.Log("Number count day : " + countDays);

    //        if (countDays > 0.0000001)
    //        {
    //            UnityEngine.Debug.Log("Check Run Only!");
    //            //Application.Quit();
    //        }
    //        else
    //        {
    //            Days.text = ((int)(0.0000001 - countDays)).ToString();
    //            return;
    //        }
    //    }
    //    else
    //    {
    //        firstInstallDateTicks = GetNextTimeOffline().Ticks;
    //        UnityEngine.Debug.Log("Run first Time");
    //        UnityEngine.Debug.Log(firstInstallDateTicks);
    //        UnityEngine.PlayerPrefs.SetString("FirstInstallDate", firstInstallDateTicks.ToString());

    //        Days.text = "30";

    //        return;
    //    }
    //}



    //public static DateTime GetNextTimeOnline()
    //{
    //    var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
    //    var response = myHttpWebRequest.GetResponse();
    //    string todaysDates = response.Headers["date"];
    //    return DateTime.ParseExact(todaysDates,
    //                                "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
    //                                CultureInfo.InvariantCulture.DateTimeFormat,
    //                                DateTimeStyles.AssumeUniversal);
    //}

}
