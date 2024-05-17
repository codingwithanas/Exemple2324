using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMonedes : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabMoneda;
    [SerializeField]
    private Transform _puntoGeneracion1;
    [SerializeField]
    private Transform _puntoGeneracion2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerarMoneda", 1, 4);
    }

    private void GenerarMoneda()
    {
        int randomPunto = Random.Range(0, 2);
        Transform puntoSeleccionado = randomPunto == 0 ? _puntoGeneracion1 : _puntoGeneracion2;

        GameObject moneda = Instantiate(_prefabMoneda, puntoSeleccionado.position, Quaternion.identity);
    }
}
