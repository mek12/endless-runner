using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera_takip : MonoBehaviour {

    Transform cocuk_position;
    Vector3 mesafe;
    float hiz = 4.0f;
	void Start () {
        cocuk_position=GameObject.Find("cocuk").transform;
    }
	
	
	void LateUpdate ()
    {
        //mesafede x kısmını kendim yaptım.
        mesafe = new Vector3(transform.position.x, transform.position.y, cocuk_position.position.z -3.5f);
        transform.position = Vector3.Lerp(transform.position, mesafe, hiz*Time.deltaTime);
	}
}
