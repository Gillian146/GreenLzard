using UnityEngine;
using System.Collections;

public class Run : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        {
            float move = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", move);
        }
	}

    void Movement()
    {
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(Vector2.right * 3f * Time.deltaTime);
        //    transform.eulerAngles = new Vector2(0, 0);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(Vector2.right * 3f * Time.deltaTime);
        //    transform.eulerAngles = new Vector2(0, -180);
        //}
    }
}
