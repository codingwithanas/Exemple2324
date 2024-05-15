using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    private float _vel;
    private int _numEnemicsTocats;
    // Start is called before the first frame update
    void Start()
    {
        _vel = 8f;
        _numEnemicsTocats = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaZ = Input.GetAxisRaw("Vertical");

        Vector3 direccioIndicada = new Vector3(direccioIndicadaX, 0, direccioIndicadaZ).normalized;

        transform.position += direccioIndicada * (_vel * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision ObjecteTocat)
    {
        if (ObjecteTocat.gameObject.tag == "Enemic")
        {
            _numEnemicsTocats++;
            String textEnemicsTocats = "Enemics tocats: " + _numEnemicsTocats;
            GameObject.Find("EnemicsTocats").GetComponent<TMPro.TextMeshProUGUI>().text = textEnemicsTocats;
       
        }
    }
        
}
