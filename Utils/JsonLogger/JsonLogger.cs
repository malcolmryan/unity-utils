/**
 * 
 * JSON-based analytics logger. This writes a series of JSON messages to a file in ND-JSON format.
 *
 * It requires the Newtownsoft JSON.NET Unity Pacakge 
 * https://docs.unity3d.com/Packages/com.unity.nuget.newtonsoft-json@3.2/manual/index.html
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6000.0.40f1
 */

using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class Logger : MonoBehaviour
{

#region Parameters
    [SerializeField] private string logFileFormat = "{0}/{1}-{2:yyyy-MM-dd-HH-mm-ss}.json";
    [SerializeField] private string logFilePrefix = "log";
#endregion

#region State
    private string filename;
    private StreamWriter log;
    private bool firstMessage = true;
    private JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
#endregion

#region Init & Destroy
    void Awake()
    {
        OpenLog();
    }

    void OnDestroy()
    {
        CloseLog();
	}

    void OnApplicationPause(bool paused)
    {
        if (paused)
        {
            CloseLog();
        }
        else
        {
            OpenLog();
        }
	}

    void OnApplicationQuit()
    {
        // NOTE: It seems to be impossible to get a reliable "ApplicationQuit" signal from Android 
        CloseLog();    
    }

#endregion

#region Private methods

    protected void OpenLog()
    {
        if (log == null)
        {
            filename = string.Format(logFileFormat, Application.persistentDataPath, logFilePrefix, System.DateTime.Now);
            log = new StreamWriter(filename);
        }
    }

    protected void CloseLog()
    {
        if (log != null)
        {
            log.Close();
            log = null;
        }
    }
 
    protected void Write(Message message)
    {
        log.WriteLine(JsonConvert.SerializeObject(message, settings));
        log.Flush();
    }
#endregion

}
