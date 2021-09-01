using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool dir;
    [SerializeField] int lifes;

    private float max, min;
    // Start is called before the first frame update
    void Start()
    {   
        dir=true;
        Vector2 limitRight = Camera.main.ViewportToWorldPoint(new Vector2(1,0));
        Vector2 limitLeft = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        float w = (GetComponent<SpriteRenderer>()).bounds.size.x;
        max = limitRight.x - w/2;
        min = limitLeft.x + w/2;
    }
    // Update is called once per frame
    void Update()
    {
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
            lifes--;
            if(lifes<=0){
                Destroy(this.gameObject);   
            }
        }
        if(collision.gameObject.CompareTag("SuperShot")){
            lifes-=2;
            if(lifes<=0){
                Destroy(this.gameObject);   
            }
        }
    }
}