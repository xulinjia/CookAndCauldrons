﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModelUIControl
{
    List<UIView> ViewList = new List<UIView>();
    protected BaseModel model;
    protected ModelManager modelManager;
    public GameObject viewControl;

    public abstract List<string> AddViewList();
    public abstract Type AddModelDataType();

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
        view.gameObject.transform.localPosition = Vector3.zero;
        view.gameObject.transform.localScale = Vector3.one;
        view.gameObject.transform.localRotation = Quaternion.identity;
        RectTransform trans = view.gameObject.GetComponent<RectTransform>();
        trans.anchorMin = Vector2.zero;
        trans.anchorMax = Vector3.one;
        trans.offsetMax = new Vector2(0, 0);
        trans.offsetMin = Vector2.zero;
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
        ModelManager.I.SetModelData(AddModelDataType());
        model = ModelManager.I.GetModelData(AddModelDataType());
        modelManager = ModelManager.I;
        List<string> lists = AddViewList();
        if (viewControl == null)
        {
            viewControl = new GameObject();
            viewControl.AddComponent<RectTransform>();
        }
        viewControl.transform.parent = CanvasRoot.I.gameObject.transform;
        viewControl.transform.localPosition = Vector3.zero;
        viewControl.transform.localScale = Vector3.one;
        viewControl.transform.localRotation = Quaternion.identity;
        RectTransform trans = viewControl.GetComponent<RectTransform>();
        trans.anchorMin = Vector2.zero;
        trans.anchorMax = Vector3.one;
        trans.offsetMax = Vector2.zero;
        trans.offsetMin = Vector2.zero;
        viewControl.name = this.GetType().Name;
        foreach (string str in lists)
        {
            LoadView(str);
        }
        Show();
    }

    protected T GetModel<T>() where T:BaseModel
    {
        return model as T;
    }

    public void Hide()
    {
        for(int i = 0; i < ViewList.Count; i++)
        {
            ViewList[i].Hide();
        }
    }

    public void Show()
    {
        if (ViewList.Count > 0)
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
        MonoBehaviour.DestroyImmediate(viewControl);
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

