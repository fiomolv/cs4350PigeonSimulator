using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsController : MonoBehaviour {

    public GameObject player;
    public GameObject[] panels;

    void Update(){
        if(player.transform.position.x > 0 && player.transform.position.x < 1)
        {
            panels[0].SetActive(true);
        }
        if (player.transform.position.x > 1)
        {
            panels[0].SetActive(false);
        }
        if (player.transform.position.x > 3 && player.transform.position.x < 4)
        {
            panels[1].SetActive(true);
        }
        if (player.transform.position.x > 4)
        {
            panels[1].SetActive(false);
        }
        if (player.transform.position.x > 6 && player.transform.position.x < 7)
        {
            panels[2].SetActive(true);
        }
        if (player.transform.position.x > 7)
        {
            panels[2].SetActive(false);
        }
    }
}
