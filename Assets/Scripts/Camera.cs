using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    // Use this for initialization
    
    //Target de la camara y su distancia atras.
    public GameObject Player,target;
   
    public float Distance;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        transform.position = Player.transform.position - Distance * Player.transform.right;
        transform.position = new Vector3(transform.position.x-1, transform.position.y + 2, transform.position.z);
        transform.LookAt(target.transform);
        
    }
}
