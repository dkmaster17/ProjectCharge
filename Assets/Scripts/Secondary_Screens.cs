using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secondary_Screens : MonoBehaviour {

    //Materials
    public Material blue, red;

    //Gameobjects with these materials
    public GameObject screen_right, screen_left;

    //Controllers materials
    private int rand;

	// Use this for initialization
	void Start ()
    {
        rand = GameManager.instance.Myrandoms();
        if (rand==1)
        {
            Invoke("Caso_01",0.2f);
        }
        else
        {
            Invoke("Caso_02", 0.2f);
        }
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Caso_01()
    {
        if (GameManager.instance.AreScreensActive())
        {
            screen_left.GetComponent<Renderer>().material = red;
            screen_right.GetComponent<Renderer>().material = blue;
        }

        Invoke("Caso_02", 0.2f);
    }
    void Caso_02()
    {
        if (GameManager.instance.AreScreensActive())
        {
            screen_left.GetComponent<Renderer>().material = blue;
            screen_right.GetComponent<Renderer>().material = red;
        }

        Invoke("Caso_01", 0.2f);
    }

}
