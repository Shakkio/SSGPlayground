using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    public GameObject RankC;
    public GameObject RankB;
    public GameObject RankA;
    public GameObject RankS;
    public GameObject PressX;

    float timer = 3.0f;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (PlayerManager.deathCount <= 5)
            {
                RankS.SetActive(true);
            }
            else if (PlayerManager.deathCount > 5 && PlayerManager.deathCount <= 20)
            {
                RankA.SetActive(true);
            }
            else if (PlayerManager.deathCount > 20 && PlayerManager.deathCount <= 30)
            {
                RankB.SetActive(true);
            }
            else
            {
                RankC.SetActive(true);
            }
            PressX.SetActive(true);
        }

        if (PressX == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject.Find("BlackFade").GetComponent<MainMenuManager>().Menu();
            }

        }
    }
}
