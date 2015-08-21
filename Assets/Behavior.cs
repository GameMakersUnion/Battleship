using UnityEngine;
using System.Collections;

public class Behavior : MonoBehaviour {

    float health = 100f;
    float magnitudeSpeed = 1f;
    public GameObject shotPrefab;
    float shotSpeed = 40f;
    Bounds bounds;
     

	// Use this for initialization
	void Start () {
        bounds = gameObject.GetComponent<Collider2D>().bounds;
	}
	
	// Update is called once per frame
	void Update () {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 up = gameObject.transform.up;

        //gameObject.transform.localEulerAngles += new Vector3(0,0,1f);
 
        if (x != 0)
        {
            gameObject.transform.localEulerAngles += new Vector3(0, 0, x * 1f);
        }

        if (y != 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(up * magnitudeSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Vector3 where = gameObject.transform.position + new Vector3(bounds.extents.x * up.x, bounds.extents.y * up.y, 0);
            GameObject shot = (GameObject)Instantiate(shotPrefab, where, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().AddForce(up * shotSpeed);
        }



        //class == factory
        //object == products
        //variable == a named refernce to an object.




        Vector3 someVect = new Vector3(1, 2, 3);
        Vector3 someOtherVect = new Vector3(4, 4, 4);
        Vector3 copy_cat = someVect;

	}
}
