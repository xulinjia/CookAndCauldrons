using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : Singleton<SceneManager>
{
    Stack<SceneData> sceneStack = new Stack<SceneData>();
    public void LoadScene(SceneE e)
    {
        SceneData data = new SceneData();
        data.sceneE = e;
        if (sceneStack.Count == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(e.ToString(), UnityEngine.SceneManagement.LoadSceneMode.Additive);
            sceneStack.Push(data);
        }
        else
        {
            SceneData lastData = sceneStack.Peek();
            if (lastData.sceneE != e)
            {
                sceneStack.Pop();
                sceneStack.Push(data);
                UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(lastData.sceneE.ToString());
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(e.ToString(), UnityEngine.SceneManagement.LoadSceneMode.Additive);
            }
        }
        UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(Peek().sceneE.ToString());
        if (scene != null)
        {
            GameObject[] rootObjs = scene.GetRootGameObjects();
            foreach (GameObject obj in rootObjs)
            {
                SceneStart start = obj.GetComponent<SceneStart>();
                if (start != null)
                {
                    start.StartScence();
                    break;
                }
            }
        }
    }


    public SceneData Peek()
    {
        if(sceneStack.Count == 0)
        {
            return null;
        }
        return sceneStack.Peek();
    }
}

public enum SceneE
{
    Base,
    Load,
    Main,
}

public class SceneData
{
    public SceneE sceneE;
}
