using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfavorefachefunzioniManager : MonoBehaviour
{
    public Transform Canna;
    bool attackspeed = false;
    float timerattack = 3f;
    float timer2 = 1.0f;
    bool Caricamento = false;
    public GameObject Proiettile;
    public int rosaGun;
    public static bool spinta = false;
    bool freeze = false;

    private Animator GianlucaDiLuca;
    private MeshRenderer AdrianLupu;
    private Color OGColor;
    private Color colorLerp;

    void Awake()
    {
        GianlucaDiLuca = GetComponent<Animator>();
        AdrianLupu = GetComponent<MeshRenderer>();
        OGColor = AdrianLupu.material.color;
    }

    private void Update()
    {
        if (attackspeed == false)
        {
            if (freeze == false)
            {
                if (PlayerManager.oscillazioneArma)
                {
                    GianlucaDiLuca.SetBool("Oscillazione", true);
                }
                else
                {
                    GianlucaDiLuca.SetBool("Oscillazione", false);
                }
            }

            if (freeze == false)
            {
                if (PlayerManager.scattanteArma)
                {
                    GianlucaDiLuca.SetBool("Scattante", true);
                }
                else
                {
                    GianlucaDiLuca.SetBool("Scattante", false);
                }
            }


                if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GianlucaDiLuca.SetBool("Oscillazione", false);
                freeze = true;
                attackspeed = true;
                GianlucaDiLuca.SetBool("Angry", true);
                Caricamento = true;
            }

        }

        if (attackspeed == true)
            {
                timerattack -= Time.deltaTime;
                if (Caricamento == false)
                {
                    AdrianLupu.material.color = Color.blue;
                }
            }

            if (timerattack < 0)
            {
                GianlucaDiLuca.SetBool("Angry", false);
                freeze = false;
                AdrianLupu.material.color = OGColor;
                timerattack = 3f;
                attackspeed = false;
            }

            if (Caricamento == true)
            {
                timer2 -= Time.deltaTime;
                AdrianLupu.material.color = Color.green;
                if (timer2 < 0)
                {
                    Caricamento = false;
                    spinta = true;
                    for (int i = rosaGun; i > 0; i--)
                    {
                        float spreadx = Random.Range(-1.7f, 1.7f);
                        float spready = Random.Range(-1.7f, 1.7f);
                        GameObject go = Instantiate(Proiettile, Canna.transform.position, Canna.transform.rotation);
                        go.transform.Translate(new Vector3(spreadx, spready, 0), Space.Self);

                    }
                    timer2 = 1.0f;
                }
            }

    }
}
