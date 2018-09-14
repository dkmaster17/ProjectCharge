using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    
    //Camarafollows this
    public GameObject player, targetlook;

    //Controles de velocidad player y target
    private float aceleration=0.02f;
    private float speed = 1.0f;

    //Banderas
    private int cont=0;
    
    //Control Direcciones
    private int dir=0;
    private int cont_izq = 0;
    private int cont_der = 0;

    //Control reubicaciones;
    public Transform place;

    //Screens Handle;
    public GameObject screen_left,screen_center;
    private string auxLeft, auxCenter;

    //ControllerWinLose
    private int cor=0;
    
    
	void Start ()
    {
       
    }
    void Update ()
    {
        Movement_player();
	}
    private void Movement_player()
    {
        if (GameManager.instance.IsGameStarted())
        {
            speed += aceleration;
            GameManager.instance.SpeedManager(speed);
            targetlook.transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
            player.transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.SetScreensActive(false);
        auxLeft = screen_left.GetComponent<Renderer>().material.name;
        auxCenter = screen_center.GetComponent<Renderer>().material.name;
    }
    void OnTriggerStay(Collider other)
    {
        if (cont == 0)
        {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))//izquierda
        {
                dir = -1;
                LiveOrDie();
                if (GameManager.instance.IsGameStarted())
                {
                    player.transform.Rotate(Vector3.down, 45);
                    targetlook.transform.Rotate(Vector3.down, 45);
                }
                cont++;
                cont_izq++;
                if (cont_izq==8)
                {
                    cont_izq = 0;
                }
                
                
            }
        if (Input.GetKeyDown(KeyCode.RightArrow))//derecha
        {
                dir = +1;
                LiveOrDie();
                if (GameManager.instance.IsGameStarted())
                {
                    player.transform.Rotate(Vector3.up, 45);
                    targetlook.transform.Rotate(Vector3.up, 45);
                }
                cont++;
                cont_der++;
                if (cont_der == 8)
                {
                    cont_der = 0;
                }
                
            }
            GameManager.instance.UpdateSegments();
            Movement_plataforms();
        }
    }
    void OnTriggerExit(Collider other)
    {
        GameManager.instance.SetScreensActive(true);
        cont = 0;
    }
    void Movement_plataforms()
    {

        if (cont==1&&GameManager.instance.IsGameStarted())
        {
        if (dir == 1)//derecha
        {
                if (cont_der==0)
                {
                    place.position = new Vector3(transform.position.x+15, transform.position.y, transform.position.z );
                    cont_izq = 0 ;
                }
                if (cont_der == 1)
                {
                    place.position = new Vector3(transform.position.x + 15, transform.position.y, transform.position.z - 15);
                    cont_izq = 7;
                }
                if (cont_der == 2)
                {
                    place.position = new Vector3(transform.position.x , transform.position.y, transform.position.z - 15);
                    cont_izq = 6;
                }
                if (cont_der == 3)
                {
                    place.position = new Vector3(transform.position.x - 15, transform.position.y, transform.position.z-15);
                    cont_izq = 5;
                }
                if (cont_der == 4)
                {
                    place.position = new Vector3(transform.position.x - 15, transform.position.y, transform.position.z );
                    cont_izq = 4;
                }
                if (cont_der ==5)
                {
                    place.position = new Vector3(transform.position.x -15, transform.position.y, transform.position.z + 15);
                    cont_izq = 3;
                }
                if (cont_der == 6)
                {
                    place.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 15);
                    cont_izq = 2;
                }
                if (cont_der == 7)
                {
                    place.position = new Vector3(transform.position.x+15, transform.position.y, transform.position.z + 15);
                    cont_izq = 1;
                }
                place.Rotate(Vector3.up, 45);
            }
        else if (dir == -1)//izquierda
        {

                if (cont_izq == 0)
                {
                    place.position = new Vector3(transform.position.x + 15, transform.position.y, transform.position.z);
                    cont_der = 0;
                }
                if (cont_izq == 1)
                {
                    place.position = new Vector3(transform.position.x + 15, transform.position.y, transform.position.z + 15);
                    cont_der = 7;
                }
                if (cont_izq == 2)
                {
                    place.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 15);
                    cont_der = 6;
                }
                if (cont_izq == 3)
                {
                    place.position = new Vector3(transform.position.x - 15, transform.position.y, transform.position.z + 15);
                    cont_der= 5;
                }
                if (cont_izq == 4)
                {
                    place.position = new Vector3(transform.position.x - 15, transform.position.y, transform.position.z);
                    cont_der = 4;
                }
                if (cont_izq == 5)
                {
                    place.position = new Vector3(transform.position.x - 15, transform.position.y, transform.position.z - 15);
                    cont_der = 3;
                }
                if (cont_izq == 6)
                {
                    place.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 15);
                    cont_der = 2;
                }
                if (cont_izq == 7)
                {
                    place.position = new Vector3(transform.position.x + 15, transform.position.y, transform.position.z - 15);
                    cont_der = 1;
                }   
                place.Rotate(Vector3.down, 45);
        }
        transform.position = place.position;
        transform.rotation = place.rotation;
        }
    }
    void LiveOrDie()
    {
        if (auxLeft == auxCenter)//izquierda
        {cor = -1;}
        else if(auxLeft != auxCenter)//derecha
        {cor = 1; }
        
        if (dir == cor)
        {
            GameManager.instance.Segmentmanager();
        }
        else
        {
            GameManager.instance.Dead();
        }
    }
    
}
