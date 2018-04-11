using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    void Start()
    {
        TimeClockManager.I.AttachClock(0.5f, GetCurrentScence, 100);

    }
    int code;
    void Update()
    {

    }

    void GetCurrentScence()
    {
        UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(SceneManager.I.Peek().sceneE.ToString());
        if (scene != null)
        {
            GameObject[] rootObjs = scene.GetRootGameObjects();
            string str = scene.name + ":";
            foreach (GameObject obj in rootObjs)
            {
                str = str + obj.name + "--";
            }
            Debug.Log(str);
        }
    }

    [ContextMenu("HAHHA")]
    public void TS()
    {
        RectTransform trans = GetComponent<RectTransform>();
    }
}
