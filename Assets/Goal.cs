using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

    // Use this for initialization
    public int goal;
    private GameObject textLeft;
    private GameObject textRight;
    private Text lt, rt;
    private GameManager gm;
	void Start () {
        textLeft = GameObject.FindWithTag("UILeft");
        textRight = GameObject.FindWithTag("UILeft");
        lt = textLeft.GetComponent<Text>();
        rt = textRight.GetComponent<Text>();
        gm = GameObject.FindWithTag("MainCamera").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ball In Goal");
        if(collision.transform.tag == "Ball")
        {
            
            if(goal == 0)
            {
                gm.AddGoal(1);
                rt.text = gm.GetScoreRight().ToString();
            }
            if (goal == 1)
            {
                gm.AddGoal(0);
                lt.text = gm.GetScoreLeft().ToString();
            }
        }
    }
}
