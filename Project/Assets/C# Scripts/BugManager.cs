﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BugManager : MonoBehaviour {

    public GameObject bugPrefab;
    public int spawnAmount = 10;
    public System.Random rnd;
    List<GameObject> Bugs;
    float speed;
    Vector3 previousPosition;
    Vector3 targetPosition;
    int spawned = 0;
    bool spawning;
	public float minusHealth;

    // Health Bar
    public float barDisplay; //current progress
    public Vector2 pos = new Vector2(50, 400);
    public Vector2 size = new Vector2(300, 60);
    public Texture2D emptyTex;
    public Texture2D fullTex;

    void Start()
    {
        Bugs = new List<GameObject>();
        targetPosition = GameObject.FindGameObjectWithTag("BugZapper").transform.position;
        speed = 0.1f;
        rnd = new System.Random();  
    }

    IEnumerator BugTimer(Vector3 pos, Vector3 rotation)
    {
        yield return new WaitForSeconds(2);
        GameObject bug = Instantiate(bugPrefab);
        bug.transform.Rotate(rotation);
        bug.transform.position = pos;
        Bugs.Add(bug);
        spawning = false;
    }

    void Update()
    {
        if(spawned < spawnAmount && !spawning)
        {
            int number = rnd.Next(1, 3);
            if (number % 2 == 0)
            {
                StartCoroutine(BugTimer(new Vector3(-0.63f, 0.53f, 1), new Vector3(0, 0, 0)));
                spawned++;
                spawning = true;
            }
            else
            {
                StartCoroutine(BugTimer(new Vector3(0.63f, 0.53f, 1), new Vector3(0, 180, 0)));
                spawned++;
                spawning = true;
            }
        }

        float step = speed * Time.deltaTime;
        foreach(var Bug in Bugs)
        {
            previousPosition = Bug.transform.position;
            Bug.transform.position = Vector3.MoveTowards(previousPosition, targetPosition, step);
        }
        //barDisplay = Time.time * 0.05f;
		barDisplay += 0.0005f;
		if (barDisplay > 1) {
			barDisplay = 1;
		}

		Debug.Log (barDisplay);
    }

    public void KillBug(Collider2D bug)
    {
        Rigidbody2D rb = bug.gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1.0f;
        Animator anim = bug.gameObject.GetComponent<Animator>();
        anim.SetBool("Dead", true);
<<<<<<< HEAD
        //StartCoroutine(DestroyBugTimer(bug.gameObject));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Lizard")
        {
            Vector2 dir = new Vector2(UnityEngine.Random.Range(-50.0f, 50.0f), UnityEngine.Random.Range(0f, 50.0f));
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = dir;
        }
=======
		barDisplay -= minusHealth;
>>>>>>> origin/master
    }

    void OnGUI()
    {
        //draw the background
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);

        //draw the filled-in part
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
        GUI.EndGroup();
        GUI.EndGroup();
    }

<<<<<<< HEAD
    //IEnumerator DestroyBugTimer(GameObject bug)
    //{
    //    yield return new WaitForSeconds(2);
    //    Destroy(bug);
    //}
=======
>>>>>>> origin/master
}
