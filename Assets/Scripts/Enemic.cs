using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemic : MonoBehaviour
{
    private float _vel = 4f;
    // Start is called before the first frame update
    void Start()
    {
        _vel = 4f;
        Invoke("DestruirEnemic", 4);
    }
    
    private void DestruirEnemic()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 posJugador = GameObject.Find("Jugador").transform.position;
        
        Vector3 direccioCapAJugador = (posJugador - transform.position).normalized;

        transform.position += direccioCapAJugador *(_vel * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision objecteTocat)
    {
        if (objecteTocat.gameObject.name == "Jugador")
        {
            Destroy(gameObject);
        }
    }

}
