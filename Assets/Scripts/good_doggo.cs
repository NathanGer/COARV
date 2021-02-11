﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class good_doggo : MonoBehaviour
{
    public float speed;
    private Animator anim;
    public int framecount = 19;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            transform.Translate(speed*Vector3.forward, Space.World);
            transform.position = new Vector3(-6, 2, -6);
        }
        
        if (Input.GetKey(KeyCode.Z)) {
            transform.Translate(speed*Vector3.forward, Space.World);
            transform.eulerAngles = new Vector3(0,0,0);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle_Battle")) {
                anim.Play("Base Layer.RunForwardBattle", 0, 1f);
            }
        }
        if (Input.GetKey(KeyCode.Q)) {
            transform.Translate(speed*Vector3.left, Space.World);
            transform.eulerAngles = new Vector3(0,270,0);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle_Battle")) {
                anim.Play("Base Layer.RunForwardBattle", 0, 1f);
            }
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(speed*Vector3.back, Space.World);
            transform.eulerAngles = new Vector3(0,180,0);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle_Battle")) {
                anim.Play("Base Layer.RunForwardBattle", 0, 1f);
            }
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(speed*Vector3.right, Space.World);
            transform.eulerAngles = new Vector3(0,90,0);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle_Battle")) {
                anim.Play("Base Layer.RunForwardBattle", 0, 1f);
            }
        }

        if ( Input.GetKeyDown(KeyCode.Space) && !( anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Attack01") ) ) {
            anim.Play("Base Layer.Attack01", 0, 1.3f);
            framecount = 0;
        }

        if (framecount==18) {
            var cols = Physics.OverlapSphere(transform.position+2*transform.forward, 1);
            var rigidbodies = new List<Rigidbody>();
            foreach (var col in cols)
            {
                if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
                {
                    rigidbodies.Add(col.attachedRigidbody);
                }
            }
            foreach (var rb in rigidbodies)
            {
                rb.AddExplosionForce(20, transform.position+1*transform.forward, 2, -0.5f, ForceMode.Impulse);
            }
        }

        framecount+=1;
    }
}
