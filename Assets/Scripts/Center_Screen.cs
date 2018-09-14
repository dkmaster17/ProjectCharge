using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center_Screen : MonoBehaviour {

    //Materials
    public Material red, blue;

    //Controller Material
    private int rand;

	void Start () {
        rand = GameManager.instance.Myrandoms();
        if (rand == 1)
        {
            Invoke("Caso_1", 0.001f);
        }
        else
        {
            Invoke("Caso_2", 0.001f);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void Caso_1()
    {

        if (GameManager.instance.AreScreensActive())
        {
            this.GetComponent<Renderer>().material = blue;
        }
        Invoke("Caso_2", 0.001f);

    }
    void Caso_2()
    {

        if (GameManager.instance.AreScreensActive())
        {

            this.GetComponent<Renderer>().material = red;
        }
        Invoke("Caso_1", 0.001f);

    }
}
