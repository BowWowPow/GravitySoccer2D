using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool ballActive;
    public GameObject _Ball;
    private GameObject activeBall;
    public GameObject _BallSpawnPos;
    private int left, right;
    private int ls, rs;
    // Use this for initialization
	void Start () {
        ballActive = false;
        RespawnBall();
        left = 0;
        right = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnBall()
    {
        ballActive = true;
        activeBall = Instantiate(_Ball, _BallSpawnPos.transform.position, Quaternion.identity);

    }

    public void AddGoal(int team)
    {
        Destroy(activeBall);
        if(team == 0)
        {
            ls += 1; 
        }
        if(team == 1)
        {
            rs += 1;
        }
        RespawnBall();
    }

    public int GetScoreLeft()
    {
        return ls;
    }

    public int GetScoreRight()
    {
        return rs;
    }
}
