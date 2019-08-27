using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donmek : MonoBehaviour {

    //altin y miknatis x

    string isim;

	void Start ()
    {
        isim = gameObject.tag;
	}

	void Update ()
    {
        if (isim == "magnet")
        {
            transform.Rotate(0, 1, 0);
           
        }
        if (isim == "gold")
        {
            transform.Rotate(1, 0, 0);
           
        }
    }
}
