using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    GameObject BlackFade;
    Animator GianlucaDiLuca;

    static bool perMenu = false;
    static bool perLivello = false;
    static bool perFine = false;

    private void Awake()
    {
        BlackFade = GameObject.Find("BlackFade");
        GianlucaDiLuca = BlackFade.GetComponent<Animator>();
    }
    public void NuovoGioco()
    {
        Debug.Log("pro");
        perLivello = true;
        GianlucaDiLuca.SetBool("DoubleFade", true);
    }

    public void Menu()
    {
        Debug.Log("pro");
        perMenu = true;
        GianlucaDiLuca.SetBool("DoubleFade", true);
    }

    public void FineGioco()
    {
        perFine = true;
        GianlucaDiLuca.SetBool("DoubleFade", true);
    }

    public void Continua()
    {
        Debug.Log("pro");
        PlayerManager.pausa = false;
    }

    public void Esci()
    {
        Debug.Log("pro");
        Application.Quit();
        Debug.Log("lol");
    }

    public void FineFade()
    {
            if (perLivello == true)
            {
            perLivello = false;
            SceneManager.LoadScene("Livello1");
            PlayerManager.pausa = false;
            }

            if (perMenu == true)
            {
            if (GameObject.Find("Distributore") == true)
            {
                GameObject.Find("Distributore").GetComponent<DistributoreManager>().enabled = true;
            }
            InterruptorManager.staccaTutto = false;
            PlayerManager.deathCount = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1;
            perMenu = false;
            SceneManager.LoadScene("Main menu");
            }

            if(perFine == true)
            {
            if (GameObject.Find("Distributore") == true)
            {
                GameObject.Find("Distributore").GetComponent<DistributoreManager>().enabled = true;
            }
            InterruptorManager.staccaTutto = false;
            Time.timeScale = 1;
            perFine = false;
            SceneManager.LoadScene("Fine");
            }
        
    }
}
