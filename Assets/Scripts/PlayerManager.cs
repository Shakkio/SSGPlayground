using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    Rigidbody m_rigidbody;

    public float speed = 350.0f;
    float gravity = -32.0f;
    public static Vector3 velocity;
    Vector3 piedinoPiedoodle;

    public float jumpForce = 20.0f;
    public float dashForce = 600.0f;

    bool honey = false;
    public float honeySpeed = 100.0f;
    public float honeyJumpForce = 6f;
    public float honeyDashForce = 100.0f;
    float caricamentoIniziale = 1.0f;
    
    public float mouseSensitivity = 10.0f;
    public Transform mainCamera;
    public static Vector3 spawnpoint;
    public static Vector3 rotationSpawnpoint;

    float m_RotX = 0.0f;

    bool m_forward = false;
    bool m_back = false;
    bool m_left = false;
    bool m_right = false;

    bool jump = false;
    bool m_dash = false;
    float m_dashtimer = 0.5f;
    public static bool canDash = false;
    Vector3 m_directionDash;

    public float rocketPower = 10f;
    public static bool oscillazioneArma = false;
    public static bool scattanteArma = false;

    public static bool pausa = false;
    public GameObject Fermo;
    public static int deathCount = 0;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        spawnpoint = transform.position;
        m_rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //fermare il giocatore per 1 secondo all'inizio della scena
        if (caricamentoIniziale > 0)
        {
            caricamentoIniziale -= Time.deltaTime;
        }
        else
        { 
        if (pausa == false) 
        { 
        transform.Rotate(0.0f, Input.GetAxis("Mouse X") * mouseSensitivity, 0.0f);

        m_RotX = m_RotX + -Input.GetAxis("Mouse Y") * mouseSensitivity;
        m_RotX = Mathf.Clamp(m_RotX, -90.0f, 90.0f);
        mainCamera.localEulerAngles = new Vector3(m_RotX, 0.0f, 0.0f);


        m_forward = Input.GetKey(KeyCode.W);
        m_back = Input.GetKey(KeyCode.S);
        m_left = Input.GetKey(KeyCode.A);
        m_right = Input.GetKey(KeyCode.D);

        if (Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z), 0.4f, 1 << 8).Length > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
            }
        }
        //MieleLayerJump
        if (Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z), 0.4f, 1 << 11).Length > 0)
        {
            Debug.Log("dai");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
            }
        }
        //MovingPlatformLayerJump
        if (Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z), 0.4f, 1 << 15).Length > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
            }
        }
        //ENRAGEDLayerJump
        if (Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z), 0.4f, 1 << 14).Length > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
            }
        }

        if (canDash)
        {
            if (!m_dash)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    canDash = false;
                    m_dash = true;
                    m_directionDash = transform.TransformDirection(Vector3.forward);
                }
            }
        }
        else
        {
            if (Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z), 0.4f, 1 << 8).Length > 0)
            {
                canDash = true;
            }
            else if (Physics.Raycast(piedinoPiedoodle, Vector3.down, 1.4f, 1 << 14))
            {
                canDash = true;
            }
            else if (Physics.Raycast(piedinoPiedoodle, Vector3.down, 1.4f, 1 << 11))
            {
                canDash = true;
            }
        }

        //check Miele
        if (Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z), 0.4f, 1 << 11).Length > 0)
        {
            honey = true;
        }
        else
        {
            honey = false;
        }

        piedinoPiedoodle = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        RaycastHit AndreaMilitoStrikesBack;

        //riposizione base
         if (Physics.Raycast(piedinoPiedoodle, Vector3.down, out AndreaMilitoStrikesBack, 1.4f, 1 << 8))
         {
             transform.position = new Vector3(transform.position.x, AndreaMilitoStrikesBack.point.y + 1.2f, transform.position.z);
         }

        //riposizione miele
        if (Physics.Raycast(piedinoPiedoodle, Vector3.down, out AndreaMilitoStrikesBack, 1.4f, 1 << 11))
        {
            if (jump == true) 
            { 
            transform.position = new Vector3(transform.position.x, AndreaMilitoStrikesBack.point.y + 1.2f, transform.position.z);
            }
        }

        //rinascita
        /*if (Input.GetKeyDown(KeyCode.R))
        {
        velocity = Vector3.zero;
        transform.position = spawnpoint;
        transform.eulerAngles = rotationSpawnpoint;
        }
        */
                
              //controllo e parentela con piattaforma movente
              RaycastHit movingPlatform;
        if (Physics.Raycast(piedinoPiedoodle, Vector3.down, out movingPlatform, 3f, 1 << 15))
        {
            this.transform.parent = movingPlatform.transform;
            canDash = true;
        }
        else
        {
            this.transform.parent = null;
        }

        //arma che scatta
        if (GameObject.Find("SSG"))
        {
            if (m_dash == true)
            {
                scattanteArma = true;
            }
            else
            {
                scattanteArma = false;
            }
        }

        //DOOM2 arma che si muove
        if (GameObject.Find("SSG"))
        {
            if(m_forward || m_back || m_left || m_right)
            {
                oscillazioneArma = true;
            }
            else
            {
                oscillazioneArma = false;
            }
        }

        }

        
        //Pausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa == true)
            {
                pausa = false;
            }
            else if (pausa == false)
            {
                pausa = true;
            }

            
        }

        //Gestione Pausa
        if (pausa == true)
        {
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Fermo.SetActive(true);
        }
        else
        {
                Fermo.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
        }

        

        }
    }

    void FixedUpdate()
    {

        //gravity per ogni layer

        if (Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z), 0.4f, 1 << 11).Length > 0)
        {
            velocity.y = 0;
        }
        else if (Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z), 0.4f, 1 << 15).Length > 0)
        {
            velocity.y = 0;
        }
        else if (Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z), 0.4f, 1 << 13).Length > 0)
        {
            velocity.y = 0;
        }
        else if (Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z), 0.4f, 1 << 14).Length > 0)
        {
            velocity.y = 0;
        }
        else if (Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z), 0.4f, 1 << 8).Length > 0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        //ricalcolo potenza ogni frame
        velocity = new Vector3(0.0f, velocity.y, 0.0f);

        //movimento condizionato o meno dal miele
        if (m_forward && honey)
        {
            velocity += transform.TransformDirection(Vector3.forward) * honeySpeed * Time.deltaTime;
        }
        else if (m_forward == true && honey == false)
        {
            velocity += transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;
        }

        if (m_back && honey)
        {
            velocity += transform.TransformDirection(Vector3.back) * honeySpeed * Time.deltaTime;
        }
        else if (m_back == true && honey == false)
        {
            velocity += transform.TransformDirection(Vector3.back) * speed * Time.deltaTime;
        }

        if (m_left && honey)
        {
            velocity += transform.TransformDirection(Vector3.left) * honeySpeed * Time.deltaTime;
        }
        else if (m_left == true && honey == false)
        {
            velocity += transform.TransformDirection(Vector3.left) * speed * Time.deltaTime;
        }

        if (m_right && honey)
        {
            velocity += transform.TransformDirection(Vector3.right) * honeySpeed * Time.deltaTime;
        }
        else if (m_right == true && honey == false)
        {
            velocity += transform.TransformDirection(Vector3.right) * speed * Time.deltaTime;
        }

        if (jump && honey)
        {
            velocity.y = honeyJumpForce;
            jump = false;
        }
        else if (jump == true && honey == false)
        {
            velocity.y = jumpForce;
            jump = false;
        }

        if (m_dash && honey)
        {
            velocity += m_directionDash * honeyDashForce * Time.deltaTime;
            m_dashtimer -= Time.deltaTime;
        }
        else if (m_dash == true && honey == false)
        {
            velocity += m_directionDash * dashForce * Time.deltaTime;
            m_dashtimer -= Time.deltaTime;
        }

        //restrizione sul dash per evitare accumulo
        if (m_dashtimer <= 0)
        {
            m_dash = false;
            m_dashtimer = 0.5f;
        }

        //riassegnazione ricalcolo posizione
        m_rigidbody.velocity = velocity;

        //spinta
        if (PerfavorefachefunzioniManager.spinta == true)
        {
            PerfavorefachefunzioniManager.spinta = false;
            m_rigidbody.AddForce(mainCamera.transform.TransformDirection(Vector3.back) * rocketPower, ForceMode.VelocityChange);
        }

    }

    private void OnDrawGizmos()
    {
        piedinoPiedoodle = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(piedinoPiedoodle, Vector3.down * 1.2f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z), 0.4f);
         
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BucoNero")
        {
            deathCount++;
            velocity = Vector3.zero;
            transform.position = spawnpoint;
            transform.eulerAngles = rotationSpawnpoint;
        }  
    }
}
