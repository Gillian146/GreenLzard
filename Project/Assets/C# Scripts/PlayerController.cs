using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private ScoreManager sm;

    // Use this for initialization
    void Start () {
        sm = FindObjectOfType<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Bug")
        {
            sm.score -= 50;
        }
    }
}
