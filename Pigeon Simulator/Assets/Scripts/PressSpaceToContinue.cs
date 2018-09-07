using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpaceToContinue : MonoBehaviour {

    public GameObject panel;

    void Update()
    {
        if (panel.activeSelf && Input.GetKeyDown("space"))
        {
            panel.SetActive(false);
        }
    }
}
