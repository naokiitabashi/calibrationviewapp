using System.Collections.Generic;
using IronPython.Hosting;
using UnityEngine;

/// <summary>
///Attach to any object on the scene
/// </summary>
public class QiitaViewCountFromPython : MonoBehaviour
{

    void Start()
    {
        var engine = Python.CreateEngine();

        ICollection<string> searchPaths = engine.GetSearchPaths();

        //Add the path of the file to be used
        searchPaths.Add(Application.dataPath);
        searchPaths.Add(Application.dataPath + @"\Plugins\Lib\");
        searchPaths.Add(Application.dataPath + @"\Plugins\Lib\site-packages\");
        engine.SetSearchPaths(searchPaths);

        //Run
        dynamic py = engine.ExecuteFile(Application.dataPath + @"\qiita.py");

        //Get class
        dynamic viewCount = py.ViewCount();
        //Display the string returned by the function on the console
        Debug.Log(viewCount.count());
    }
}