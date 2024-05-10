using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemics : MonoBehaviour
{
    public GameObject _prefabEnemic;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerarEnemic", 1, 2);
    }
    private void GenerarEnemic()
    {
        GameObject enemic = Instantiate( _prefabEnemic );
        enemic.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
