using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject parent1;
    [SerializeField] private GameObject parent2;
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] private GameObject target;
    private GameObject bullet;
    public Transform parentTransformBullet;
    Vector3 offset;
    [SerializeField] private Transform bulletpoint1;
    [SerializeField] private Transform bulletpoint2;
    [SerializeField] private Rigidbody rb1;
    [SerializeField] private Rigidbody rb2;



    //triplejump
    public int count;

    //charing orb
    public float maxTimer = 2;
    public float startTimer = 0;
    void Start()
    {

        rb1 = parent1.GetComponent<Rigidbody>();
        rb2 = parent2.GetComponent<Rigidbody>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        rotation(player1,KeyCode.F,KeyCode.G);
        
        rotation(player2, KeyCode.K, KeyCode.L);

        Shoot(bulletprefab, bulletpoint1, KeyCode.T);
        Shoot(bulletprefab, bulletpoint2, KeyCode.O);
        setJump(rb1, KeyCode.W);
        setJump(rb2, KeyCode.UpArrow);

    }

    private void FixedUpdate()
    {
        Movement(rb1, KeyCode.A, KeyCode.W, KeyCode.D);
        Movement(rb2, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.RightArrow);
        
        
    }

    public void rotation(GameObject gameObject, KeyCode keycode1 , KeyCode keycode2)
    {
        if (Input.GetKey(keycode1))
        {
            float rotationSpeed = 300f; // Adjust the rotation speed as needed

            // Get the current rotation of the GameObject
            Quaternion currentRotation = gameObject.transform.rotation;

            // Calculate the desired rotation increment
            float rotationIncrement = rotationSpeed * Time.deltaTime;

            // Create a new rotation by adding the increment to the current rotation
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles + new Vector3(0f, 0f, rotationIncrement));

            // Apply the new rotation to the GameObject
            gameObject.transform.rotation = newRotation;
        }

        if (Input.GetKey(keycode2)){

            float rotationSpeed = 300f;

            Quaternion currentRotation = gameObject.transform.rotation;

            // Calculate the desired rotation increment
            float rotationIncrement = rotationSpeed * Time.deltaTime;

            // Create a new rotation by adding the increment to the current rotation
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles - new Vector3(0f, 0f, rotationIncrement));

            // Apply the new rotation to the GameObject
            gameObject.transform.rotation = newRotation;
        }
    }



    public void Movement(Rigidbody player, KeyCode left , KeyCode up , KeyCode right)
    {
        Debug.Log(rb1.velocity.y);
        if(Input.GetKey(left))
        {
            player.velocity = new Vector3( -1 * 500 * Time.deltaTime , player.velocity.y, player.velocity.z);
            

        }
        
        if (Input.GetKey(right))
        {
            player.velocity = new Vector3(1 * 500 * Time.deltaTime, player.velocity.y, player.velocity.z);
        }

    }


    public void Shoot(GameObject prefab , Transform bulletpoint ,KeyCode keycode)
    {
        if(Input.GetKeyDown(keycode)) // getkey for some awesome continous effects lol flame thrpwer fr
        { 
            bullet = Instantiate(prefab, bulletpoint.position, Quaternion.identity);
      
           // bullet.GetComponent<Rigidbody>().AddForce(bulletpoint.right * 10, ForceMode.Impulse);
        }

        if(Input.GetKey(keycode))
        {
            bullet.transform.position =  bulletpoint.position; // rotation of parent is applying by other keys now the position is all that matters and the bullet position 
            bullet.transform.localScale += new Vector3(startTimer, startTimer, 0);

            if(startTimer > maxTimer) { startTimer = maxTimer; }

            startTimer += Time.deltaTime;

        }


        if(Input.GetKeyUp(keycode))
        {
            bullet.GetComponent<Rigidbody>().AddForce(bulletpoint.right * 10, ForceMode.Impulse);
        }
        
    }



    

    public int getJumpCount() { return count; }


    public void setJump(Rigidbody player , KeyCode keycode)
    {
        if(Input.GetKeyDown(keycode))
        {
            player.velocity = new Vector3(player.velocity.x, Time.deltaTime * 1000, player.velocity.z);

        }
    }



    
}
