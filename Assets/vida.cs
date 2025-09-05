using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class vida : MonoBehaviour
{
    public TMP_Text TxtVida;
    public Animator Eanimator;
    public float valor = 100;
    // Start is called before the first frame update
    void Start()
    {
        TxtVida.text = valor.ToString();
        Eanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RecibirDaño(float daño)
    {
        valor -= daño;
        TxtVida.text = valor.ToString();
        if (valor <= 0)
        {
            valor = 0;
            //Destroy(this.gameObject, 0f);
            Eanimator.CrossFadeInFixedTime("fallBack", 0f);
            Destroy(this.gameObject, 1.5f);
            
        }
    }

}
