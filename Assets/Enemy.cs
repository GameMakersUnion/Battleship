using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    Vector2 velocity;

	// Use this for initialization
	void Start () {
        velocity = gameObject.transform.GetComponent<Rigidbody2D>().velocity;
	}
	
	// Update is called once per frame
	void Update () {
        if (velocity != Vector2.zero)
        {
            velocity = Vector2.zero;
        }	    
	}
}
