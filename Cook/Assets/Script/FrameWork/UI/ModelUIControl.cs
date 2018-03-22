using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModelUIControl
{
    List<UIPanel> PanelList = new List<UIPanel>();

    /// <summary>
    /// Add UIPanel Paths
    /// </summary>
    /// <returns></returns>
    public abstract List<string> AddPanelList();

    public void LoadPanel(string path)
    {
        GameObject Obj = Resources.Load(path) as GameObject;
        if(Obj == null)
            Debug.Log("Can't Load panel by Path:" + path);
        GameObject obj = MonoBehaviour.Instantiate(Obj) as GameObject;
        UIPanel panel = obj.GetComponent<UIPanel>();
        if (panel == null)
            Debug.Log("Can't Get UIPanel by Path:" + path);
        panel.gameObject.SetActive(false);
        PanelList.Add(panel);
    }

    public T GetPanel<T>() where T :UIPanel
    {
       foreach (UIPanel panel in PanelList)
        {
            if(panel is T)
            {
                return panel as T;
            }
        }
        return null;
    }

    public void Load()
    {
        List<string> lists = AddPanelList();
        foreach (string str in lists)
        {
            LoadPanel(str);
        }
    }

    public void UnLoad()
    {

    }
}

public enum ModelUIContrilEnum
{
    LoadUI,
    MainUI,
}
