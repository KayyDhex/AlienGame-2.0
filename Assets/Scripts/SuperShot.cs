using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperShot : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,speed * Time.deltaTime));
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(!collision.gameObject.CompareTag("SuperShot")) Destroy(this.gameObject);
    }
}
