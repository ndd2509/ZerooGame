using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject myPrefap;
    
     public float speed = 50f, maxspeed = 3, jumpPow = 220f;
    public bool grounded = true, faceright = true, doubleJump = false;
    public Rigidbody2D r2;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("speed", Mathf.Abs(r2.velocity.x));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doubleJump = true;
               r2.AddForce(Vector2.up * jumpPow);
            }
            else
            {
                if(doubleJump){
                    doubleJump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 1f);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.S)){
            
        }
        if(Input.GetKeyDown(KeyCode.G)){
           Instantiate(myPrefap, gameObject.transform.position, Quaternion.identity);
        }
    }
 private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            Destroy(other.gameObject);
        }
    }
    void FixedUpdate(){
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);
        if (r2.velocity.x > maxspeed)
        {
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        }
         if (r2.velocity.x < -maxspeed)
        {
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);
        }
        if(h>0 && !faceright){
            Flip();
        }
        if(h<0 && faceright){
            Flip();
        }
        if(grounded){
            r2.velocity = new Vector2(r2.velocity.x * 1f, r2.velocity.y);
        }
    }

    public void Flip(){
faceright = !faceright;
Vector3 Scale;
Scale = transform.localScale;
Scale.x *= -1;
transform.localScale = Scale;
    }
}
