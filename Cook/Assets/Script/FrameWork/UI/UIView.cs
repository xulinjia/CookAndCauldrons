using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIView : MonoBehaviour
{
    protected ModelUIControl ctr;

    public void Load(ModelUIControl ctr)
    {
        this.ctr = ctr;
    }
    public virtual void PreOpen()
    {

    }

    public virtual void Opend()
    {

    }

    public virtual void PreClose()
    {

    }

    public virtual void Closed()
    {

    }

    public void Open()
    {
        PreOpen();
        gameObject.SetActive(true);
        transform.SetAsFirstSibling();
        Opend();
    }

    public void Close()
    {
        PreClose();
        gameObject.SetActive(false);
        transform.SetAsLastSibling();
        Closed();
    }

    public virtual void UnLoad()
    {

    }
}
