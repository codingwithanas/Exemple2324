using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Jugador : MonoBehaviour
{
    private float _vel;
    private int _numEnemicsTocats;
    private int _numMonedesTocades;
    private int _escutsJugador;

    private TMP_Text _textEnemicsTocats;
    private TMP_Text _textMonedesTocades;
    private TMP_Text _textEscutsJugador;

    public GameObject gameOverPanel;
    public TMP_Text puntsAconseguitsText;

    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8f;
        _numEnemicsTocats = 0;
        _numMonedesTocades = 0;
        _escutsJugador = 0;

        _textEnemicsTocats = GameObject.Find("EnemicsTocats").GetComponent<TMP_Text>();
        _textMonedesTocades = GameObject.Find("MonedesTocades").GetComponent<TMP_Text>();
        _textEscutsJugador = GameObject.Find("EscutsJugador").GetComponent<TMP_Text>();

        ActualitzarTextEnemicsTocats();
        ActualitzarTextMonedesTocades();
        ActualitzarTextEscutsJugador();

        gameOverPanel.SetActive(false);
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaZ = Input.GetAxisRaw("Vertical");

        Vector3 direccioIndicada = new Vector3(direccioIndicadaX, 0, direccioIndicadaZ).normalized;

        transform.position += direccioIndicada * (_vel * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision objecteTocat)
    {
        if (isGameOver) return;

        if (objecteTocat.gameObject.CompareTag("Enemic"))
        {
            _numEnemicsTocats++;
            _escutsJugador--;
            ActualitzarTextEnemicsTocats();
            ActualitzarTextEscutsJugador();
            Destroy(objecteTocat.gameObject);

            if (_escutsJugador < 0)
            {
                GameOver();
            }
        }
        else if (objecteTocat.gameObject.CompareTag("Moneda"))
        {
            _numMonedesTocades++;
            _escutsJugador++;
            ActualitzarTextMonedesTocades();
            ActualitzarTextEscutsJugador();
            Destroy(objecteTocat.gameObject);
        }
    }

    private void ActualitzarTextEnemicsTocats()
    {
        _textEnemicsTocats.text = "Enemics tocats: " + _numEnemicsTocats;
    }

    private void ActualitzarTextMonedesTocades()
    {
        _textMonedesTocades.text = "Monedes tocades: " + _numMonedesTocades;
    }

    private void ActualitzarTextEscutsJugador()
    {
        _textEscutsJugador.text = "Escuts jugador: " + _escutsJugador;
    }

    private void GameOver()
    {
        isGameOver = true;
        puntsAconseguitsText.text = "Punts aconseguits: " + _numMonedesTocades;
        gameOverPanel.SetActive(true);

        // Desactivar jugador, enemigos y monedas
        gameObject.SetActive(false);
        GameObject[] enemics = GameObject.FindGameObjectsWithTag("Enemic");
        foreach (GameObject enemic in enemics)
        {
            enemic.SetActive(false);
        }
        GameObject[] monedes = GameObject.FindGameObjectsWithTag("Moneda");
        foreach (GameObject moneda in monedes)
        {
            moneda.SetActive(false); 
        }
    }
}
