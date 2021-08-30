using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] float nextFire;

    //limites de la pantalla para pasar del viewport a unit 
    float minX, maxX, minY, maxY, w, h, canFire;
    // Start is called before the first frame update
    void Start()
    {   
        speed = 8.15f;
        w = (GetComponent<SpriteRenderer>()).bounds.size.x;
        h = (GetComponent<SpriteRenderer>()).bounds.size.y;
        Vector2 cornerUpRight = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        maxX = cornerUpRight.x - w/2;
        maxY = cornerUpRight.y - h/2;
        Vector2 cornerDownLeft = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        minX = cornerDownLeft.x + w/2;
        minY = cornerDownLeft.y + w/2;
        //viewport todo esta normalizado esquinas (0,0)(1,0)(0,1)(1,1)

    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.RightArrow)) transform.Translate(new Vector2(speed,0));
        //if(Input.GetKey(KeyCode.LeftArrow)) transform.Translate(new Vector2(-speed,0));
        //if(Input.GetKey(KeyCode.UpArrow)) transform.Translate(new Vector2(0,speed));
        //if(Input.GetKey(KeyCode.DownArrow)) transform.Translate(new Vector2(0,-speed));

        //input manager de Unity
        movement();
        fire();
        
    }
    void movement(){
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(movH * speed * Time.deltaTime,movV * speed * Time.deltaTime));

        float newX = Mathf.Clamp(transform.position.x, minX,maxX);
        float newY = Mathf.Clamp(transform.position.y, minY,maxY);
        transform.position = new Vector2(newX,newY);
    }
    void fire(){

        if(Input.GetKeyDown(KeyCode.Space) && Time.time>=canFire){
            Instantiate(bullet, transform.position - new Vector3(0,h/2,0), transform.rotation);
            canFire = Time.time + nextFire;
        }
    }
}
