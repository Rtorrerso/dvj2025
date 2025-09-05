using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busqueda : MonoBehaviour
{
    public Transform Parent;       // ahora es un Transform
    public float rotationSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            Debug.Log("Te encontre!!!");
            //transform.parent.position = other.transform.position;
            //transform.parent.LookAt(other.transform);
            StartCoroutine(SmoothLookAt(other.transform));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            Debug.Log("Te encontre!!!");
            //transform.parent.position = other.transform.position;
            //transform.parent.LookAt(other.transform);
            StartCoroutine(SmoothLookAt(other.transform));
        }
    }

    private IEnumerator SmoothLookAt(Transform target)
    {
        Quaternion startRotation = Parent.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(target.position - Parent.position);

        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime * rotationSpeed;

            Parent.rotation = Quaternion.Slerp(startRotation, targetRotation, time);

            yield return null;
        }
    }
}
