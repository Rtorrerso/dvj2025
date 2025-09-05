using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaArmas : MonoBehaviour
{
    LayerMask layerMask;

    [Header("compnentes")]
    public Animator animator;
    public AudioSource audioSource;
    public Transform ptoDisparo;   // Start is called before the first frame update

    [Header("Sonidos")]
    public AudioClip sonDisparo;
    public AudioClip sonCarga;
    public AudioClip sonSinBalas;

    [Header("Valores de Arma")]
    public int totalBalas=100;
    public int balasEnCartucho=12;

    [Header("Enemigo")]
    private vida VidaEnemigo;
    public GameObject Enemigo;
    public int dano = 20;
    public GameObject CanvaMira;
    public GameObject sangre;


    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        layerMask = LayerMask.GetMask("Wall", "Enemy");
        //CanvaMira.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (balasEnCartucho > 0)
            {
                if (Physics.Raycast(ptoDisparo.position, ptoDisparo.TransformDirection(Vector3.forward), out hit, 50, layerMask))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                    Debug.Log("Le DI!!!!");
                    Enemigo = hit.collider.gameObject;
                    //CanvaMira.SetActive(true);
                    VidaEnemigo = Enemigo.GetComponent<vida>();
                    VidaEnemigo.RecibirDaño(dano);
                    //GameObject newSangrado = Instantiate(sangre, hit.collider.transform.position, hit.collider.transform.rotation);
                    // hit es tu RaycastHit
                    Vector3 pos = hit.point + hit.normal * 0.01f; // pequeño offset
                    Quaternion rot = Quaternion.LookRotation(hit.normal); // +Z del prefab apunta fuera de la superficie

                    GameObject sangreGO = Instantiate(sangre, pos, rot);
                    //sangreGO.transform.SetParent(hit.collider.transform); // opcional: se mueve con el objeto

                    //vidaEnemigo -= dano;
                    //if (vidaEnemigo <= 0)
                    //{
                    //    Destroy(hit.collider.gameObject,0f);
                    //}
                }
                else
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                    Debug.Log("NOOO Le DI!!!!");
                }
                animator.CrossFadeInFixedTime("Fire", 0f);
                audioSource.PlayOneShot(sonDisparo);
                balasEnCartucho--;
            }
            else
            {
                audioSource.PlayOneShot(sonSinBalas);
            }

        }

        if (Input.GetButtonDown("Reload"))
        {
            balasEnCartucho = 12;
            totalBalas -= balasEnCartucho;
        }
    }

    void CargaArma()
    {
        audioSource.PlayOneShot(sonCarga);
    }
}
