using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    [SerializeField]
    private float _velocitat = 6f;
    private Vector3 _direccio;
    private float _tempsCanviDireccio = 2f;

    void Start()
    {
        CanviarDireccio();
        InvokeRepeating("CanviarDireccio", _tempsCanviDireccio, _tempsCanviDireccio);
        Invoke("DestruirMoneda", 6f);
    }

    void Update()
    {
        transform.position += _direccio * (_velocitat * Time.deltaTime);
    }

    private void CanviarDireccio()
    {
        int randomDirection = Random.Range(0, 4);
        switch (randomDirection)
        {
            case 0:
                _direccio = new Vector3(1, 0, 1).normalized; 
                break;
            case 1:
                _direccio = new Vector3(1, 0, -1).normalized; 
                break;
            case 2:
                _direccio = new Vector3(-1, 0, -1).normalized; 
                break;
            case 3:
                _direccio = new Vector3(-1, 0, 1).normalized; 
                break;
        }
    }

    private void DestruirMoneda()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision objecteTocat)
    {
        if (objecteTocat.gameObject.CompareTag("Jugador"))
        {
            Destroy(gameObject);
        }
    }
}
