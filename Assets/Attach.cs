using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour {

    private DistanceJoint2D d;
    public List<GameObject> _blocks = new List<GameObject>();
    public float force;
    private Rigidbody2D brb;
    private GameObject attachedBlock;
    private Rigidbody2D prb;
    private LineRenderer plr;
    private bool isAttached;
    public float offset;
    public int playerN;
    private string controllerN;
	void Start () {
        d = this.gameObject.GetComponent<DistanceJoint2D>();

        //brb1 = _block_1.GetComponent<Rigidbody2D>();
        //brb2 = _block_1.GetComponent<Rigidbody2D>();
        prb = this.gameObject.GetComponent<Rigidbody2D>();
        plr = this.gameObject.GetComponent<LineRenderer>();
        controllerN = "joystick" + playerN.ToString() + "Horz";
	}
	
	// Update is called once per frame
	void Update () {
        if(isAttached)
        {
            RenderLine();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            d.enabled = true;
            d.connectedBody = FindClosestAttachPoint();
            Debug.Log("pressed");
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            d.enabled = false;
            d.connectedBody = null; 
            Debug.Log("released");
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            prb.AddForce(prb.velocity.normalized * force);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            prb.AddForce(-prb.velocity.normalized * force);

        }
	}

    public void AttachTo()
    {
        d.enabled = true;
        d.connectedBody = FindClosestAttachPoint();
        prb.freezeRotation = true;
        isAttached = true;
        plr.enabled = false;
        Debug.Log("pressed"); 
    }

    public void DetatchFrom()
    {
        d.enabled = false;
        prb.freezeRotation = false;
        plr.enabled = false;
        isAttached = false;
        d.connectedBody = null;
        Debug.Log("released");
    }

    private void RenderLine()
    {
        plr.SetPosition(0,this.transform.position);
        plr.SetPosition(1,attachedBlock.transform.position);
        plr.enabled = true;
    }

    public void AddForceInDirection()
    {
        Vector2 inputDirection = Vector2.zero;
        inputDirection.x = Input.GetAxis(controllerN);
        inputDirection.y = 0.0f;
        //nputDirection.y = Input.GetAxis("Joystick1Vert");
        Debug.Log("Direction: " + inputDirection.ToString());
        prb.AddForce(inputDirection * force);
    }

    public void MoveIn()
    {
        Debug.Log("MOVING IN");
        d.distance -= offset;
    }

    public void MoveOut()
    {
        Debug.Log("MOVING OUT");
        d.distance += offset;
    }

    public Rigidbody2D FindClosestAttachPoint()
    {
        GameObject closest = _blocks[0];
        foreach(GameObject temp in _blocks)
        {
            if(Vector3.Distance(transform.position,closest.transform.position) > Vector3.Distance(transform.position,temp.transform.position))
            {
                closest = temp;
            }
        }
        attachedBlock = closest;
        return closest.GetComponent<Rigidbody2D>();
    }
}
