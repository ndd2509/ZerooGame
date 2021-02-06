using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update(){
    
            trans.Translate(Vector3.right * Time.deltaTime *10);
       
    }
     private void OnBecameInvisible() {
       
            Destroy(gameObject);
    }
}
