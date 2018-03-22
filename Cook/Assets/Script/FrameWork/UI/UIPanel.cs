using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
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
        Opend();
    }

    public void Close()
    {
        PreClose();
        gameObject.SetActive(false);
        Closed();
    }
}
