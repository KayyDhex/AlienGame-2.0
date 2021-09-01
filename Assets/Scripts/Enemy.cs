using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool dir;
    [SerializeField] int lives;
    [SerializeField] GameObject Live;

    private float max, min, h, w;
    // Start is called before the first frame update
    void Start()
    {   
        h = (GetComponent<SpriteRenderer>()).bounds.size.y;
        w = (GetComponent<SpriteRenderer>()).bounds.size.x;
        dir=true;
        Vector2 limitRight = Camera.main.ViewportToWorldPoint(new Vector2(1,0));
        Vector2 limitLeft = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        max = limitRight.x - w/2;
        min = limitLeft.x + w/2;
    }
    // Update is called once per frame
    void Update()
    {
        RenderLives();
        if(dir)
        transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        else
        transform.Translate(new Vector2(-speed * Time.deltaTime,0));
        
        if(transform.position.x >= max){
            dir = false;
        }else if(transform.position.x <= min){
            dir = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Shot")){
            lives--;
            if(lives<=0){
                Destroy(this.gameObject);   
            }
        }
        if(collision.gameObject.CompareTag("SuperShot")){
            lives-=2;
            if(lives<=0){
                Destroy(this.gameObject);   
            }
        }
    }
    private void RenderLives(){
        foreach(Transform child in transform){
            Destroy(child.gameObject);
        }

        for(int i = 0; i<lives; i++){
            float newX = (float)(i*0.3-((lives*0.3)/2));
            Instantiate(Live, transform.position + new Vector3(newX,h,0), transform.rotation , transform);
        }
    }
}