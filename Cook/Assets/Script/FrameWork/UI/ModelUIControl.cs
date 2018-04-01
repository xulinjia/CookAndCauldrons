using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModelUIControl:Singleton<ModelUIControl>
{
    List<UIView> ViewList = new List<UIView>();
    BaseModel model;

    public abstract List<string> AddViewList();
    public abstract BaseModel AddModelData();

    public void LoadView(string path)
    {
        GameObject Obj = Resources.Load(path) as GameObject;
        if(Obj == null)
            Debug.Log("Can't Load view by Path:" + path);
        GameObject obj = MonoBehaviour.Instantiate(Obj) as GameObject;
        UIView view = obj.GetComponent<UIView>();
        if (view == null)
            Debug.Log("Can't Get UIView by Path:" + path);
        view.gameObject.SetActive(false);
        view.Load(this);
        ViewList.Add(view);
    }

    public T GetView<T>() where T :UIView
    {
       foreach (UIView view in ViewList)
        {
            if(view is T)
            {
                return view as T;
            }
        }
        return null;
    }

    public void Load()
    {
        model = AddModelData();
        List<string> lists = AddViewList();
        foreach (string str in lists)
        {
            LoadView(str);
        }
    }

    public void UnLoad()
    {
        model.Unload();
        foreach (UIView view in ViewList)
        {
            view.UnLoad();
        }       
    }

    public void Hide()
    {

    }

    public void Show()
    {

    }
}

public enum ModelUIContrilEnum
{
    LoadUI,
    MainUI,
}

public enum UILayer
{
    Base,
    PoP,
}

