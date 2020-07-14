using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public GameObject bouncer;
    private Rigidbody2D _bouncerrigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _bouncerrigidbody2D = bouncer.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Anim ++
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        bouncer = collision.gameObject;
        collision.rigidbody.AddForce(new Vector2(0f, 30F));
        _bouncerrigidbody2D.AddForce(new Vector2(0f, 1000f));
    }
}
