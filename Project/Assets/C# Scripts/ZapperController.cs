using UnityEngine;
using System.Collections;

public class ZapperController : MonoBehaviour {

    public BugManager bugManager;

    private AudioSource deathSound;

    // Use this for initialization
    void Start () {
        bugManager = FindObjectOfType<BugManager>();
        deathSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Bug")
        {
            deathSound.Play();
            GameObject deadBug =  other.gameObject;
            //deadBug.Gravity
            //deadBug.SetActive(false);
            bugManager.KillBug(other);
        }
    }
}
