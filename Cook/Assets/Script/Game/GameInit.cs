using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : SingletonData<GameInit>
{
    void Start()
    {
        SceneManager.I.LoadScene(SceneE.Load);
    }
}
