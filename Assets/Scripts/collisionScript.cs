using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody rb1;
    [SerializeField] Rigidbody rb2;
    [SerializeField] float scaleSize;
    float additionalForceByScale1;
    float additionalForceByScale2;
    void Start()
    {
        GameObject player2 = GameObject.FindWithTag("player2");
        rb2 = player2.GetComponent<Rigidbody>();
        GameObject player1 = GameObject.FindWithTag("player1");
        rb1 = player1.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player2" )
        {
            Vector3 collisionPointDirection = collision.contacts[0].point.normalized;
            collision.gameObject.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            additionalForceByScale1 = collision.gameObject.transform.localScale.x * 10;
            
            rb2.AddForce(collisionPointDirection * 100 * additionalForceByScale1);
            Debug.Log(additionalForceByScale1);
            Destroy(gameObject);
            //Debug.Log("collision at " + collisionPointDirection);

        }

        if(collision.gameObject.tag == "player1")
        {
            Vector3 collisionPointDirection = collision.contacts[0].point.normalized;
            collision.gameObject.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            additionalForceByScale2 = collision.gameObject.transform.localScale.x * 10; 
            rb1.AddForce(collisionPointDirection * 100 * additionalForceByScale2);
            Destroy(gameObject);
            Debug.Log("collision at " + collisionPointDirection);
        }
        if (collision.gameObject.tag == "Map")
        {
            Destroy(gameObject);
        }
    }
}
