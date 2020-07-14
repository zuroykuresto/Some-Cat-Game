using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingObjects : MonoBehaviour {

    public float objectHP =1f;
    public float lastPositionY = 0f;
    public Vector3 lastPosition;
    public float fallDistance = 0f;
    private float speed;
    public bool isGrounded = false;
    private GameObject BreakingObj;
    public float shakeLenght = .5f;
    public float shakeForce = .2f;
    private Rigidbody2D rigidbody2D;
    
    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("speed " + speed, gameObject);
        if (collision.collider.tag == "Floor")
            //Debug.Log("Colide FLOOR" + collision.collider.tag, gameObject);
            isGrounded = true;
        //if fly enough count point
        if (fallDistance > 2.5f && isGrounded == true && objectHP > 0)
        {
            //Destroy(gameObject);//!!add braking anim
            //Debug.Log($"Colide with {collision.collider.tag}fall distance {fallDistance} ", gameObject);
            ScreenShake.instance.StartShake(shakeLenght, shakeForce);
            ScoreScript.scoreValue += Mathf.RoundToInt(1 + fallDistance * 2f + speed);
            objectHP -= 3;

        }
        else if (fallDistance > 1 && isGrounded == true && objectHP > 0)
        {
            objectHP -= 1;
            ScoreScript.scoreValue += 1;
        }
        else ApplyNormal();
        // Debug.Log($"Colide with {collision.collider.tag}fall distance {fallDistance} ", gameObject);

        /* if (collision.collider != null)
             Debug.Log("Landing on" + collision.collider.tag, gameObject);
         ApplyNormal(); */
    }

    // Update is called once per frame
    void Update () { 
        //store speed for point count
        speed = (transform.position - lastPosition).magnitude / Time.time;
        lastPosition = transform.position;
        //Debug.Log("SPEED - " + speed, gameObject);
        //Check if falling
        if (lastPositionY > gameObject.transform.position.y)
        {
            fallDistance += lastPositionY - gameObject.transform.position.y;
        }
        lastPositionY = gameObject.transform.position.y;
    }

    //apply normal state
    void ApplyNormal()
    {
        fallDistance = 0;
        lastPositionY = 0;
    }


}
