using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModelUIControl:Singleton<ModelUIControl>
{
    List<UIView> ViewList = new List<UIView>();
    BaseModel model;
    public GameObject viewControl;

    public abstract List<string> AddViewList();
    public abstract BaseModel AddModelData();

    void LoadView(string path)
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
        view.gameObject.transform.parent = viewControl.transform;
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
        if (viewControl == null)
        {
            viewControl = new GameObject();
        }
        viewControl.transform.parent = CanvasRoot.I.gameObject.transform;
        viewControl.name = this.name;
        foreach (string str in lists)
        {
            LoadView(str);
        }

        if(ViewList.Count > 0)
        {
            ViewList[0].Open();
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

    protected BaseModel GetModel()
    {
        return model;
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

