using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseLoadButton : MonoBehaviour
{
    public GameObject LoadGame;
    public void CloseLoad()
    {
        ButtonCtrl.OpenButton = true;
        LoadGame.SetActive(false);
    }

    // Start is called before the first frame update
}
