using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BugManager : MonoBehaviour {

    public GameObject bugPrefab;
    //public GameObject bugZapper;
    public int spawnAmount = 10;
    //public Vector2 spawnRange;
    public System.Random rnd;
    //public Transform target;
    GameObject Bug;
    List<GameObject> Bugs;
    float speed;
    Vector3 previousPosition;
    Vector3 targetPosition;
    int spawned = 0;
    bool spawning;

    void Start()
    {
        Bugs = new List<GameObject>();
        targetPosition = GameObject.FindGameObjectWithTag("BugZapper").transform.position;
        speed = 0.1f;
        rnd = new System.Random();  
    }

    IEnumerator BugTimer(Vector3 pos, GameObject bug, Vector3 rotation)
    {
        yield return new WaitForSeconds(2);
        bug = Instantiate(bugPrefab);
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
                StartCoroutine(BugTimer(new Vector3(-0.63f, 0.53f, 1), Bug, new Vector3(0, 0, 0)));
                spawned++;
                spawning = true;
            }
            else
            {
                StartCoroutine(BugTimer(new Vector3(0.63f, 0.53f, 1), Bug, new Vector3(0, 180, 0)));
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
    }

    public void KillBug(Collider2D bug)
    {
        bug.gameObject.SetActive(false);
    }
}
