using UnityEngine;
using System.Collections;

public class ZapperController : MonoBehaviour {
	private ScoreManager sm;
    public BugManager bugManager;

    private AudioSource deathSound;

    // Use this for initialization
    void Start () {
		sm = FindObjectOfType<ScoreManager>();
        bugManager = FindObjectOfType<BugManager>();
        deathSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bug")
        {
            deathSound.Play();
            bugManager.KillBug(other);
			sm.score += 10;
        }
    }
}
