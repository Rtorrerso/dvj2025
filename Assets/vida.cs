using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour
{
    public float valor = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RecibirDaño(float daño)
    {
        valor -= daño;
        if (valor <= 0)
        {
            valor = 0;
            Destroy(this.gameObject, 0f);
        }
    }

}
