using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{ public GameObject gameManager;
    Rigidbody rb;
    Vector3 Movement = new Vector3();
    public int speed;
     int myStreak;
    internal string myTarget;
    private Text mykmh;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Movement = Vector3.forward;
        
    }

    // Update is called once per frame
    void Update()
    {
        myTarget = gameManager.GetComponent<GameManager>().currentTarget;
        if (myTarget == "Red")
        {

            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        } 
        if (myTarget == "Yellow")
        {

            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        } 
        if (myTarget == "Green")
        {

            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log(rb.velocity.z);
            Debug.Log(myTarget);
        }
        if (myStreak > 0)
        {

        rb.velocity = Movement*(speed*myStreak);
        }
        else
        rb.velocity = Movement*(speed);

        mykmh.text = myStreak.ToString();
        gameManager.GetComponent<GameManager>().Kmh.text = mykmh.text;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(myTarget))
        {
            myStreak++;
            Notify();
            Debug.Log("RightColor");

            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            myStreak --;
            Debug.Log("WrongColor");
        }
      
        
    }






    public void Notify()
    {

        gameManager.GetComponent<GameManager>().Streake = myStreak;
    }

    
}
