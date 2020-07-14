using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject player;
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 desirePosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed * Time.fixedDeltaTime);
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        transform.position = smoothedPosition;
        
	}
}
