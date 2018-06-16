using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {

    Node [] pathNode;
    public GameObject assignedObject;   //navpoint
    public GameObject bird;
    public float speed;
    float timer;
    int currentNode;
    static Vector3 currentPositionHolder;

    private Quaternion _lookRotation;
    private Vector3 _direction;

    // Use this for initialization
    void Start () {
        pathNode = GetComponentsInChildren<Node>();
        checkNode();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime * speed;

        if (bird.transform.position.z < 1f && bird.transform.position.z > -1f) {    //Collider hallinta
            bird.GetComponent<CircleCollider2D>().enabled = true;
        }
        else {
            bird.GetComponent<CircleCollider2D>().enabled = false;
        }

        if (assignedObject.transform.position != currentPositionHolder) {   //add movement
            //assignedObject.transform.position = Vector3.Lerp(assignedObject.transform.position, currentPositionHolder, speed);
            assignedObject.transform.position = Vector3.MoveTowards(assignedObject.transform.position, currentPositionHolder, speed);

            bird.transform.position = Vector3.MoveTowards(bird.transform.position, assignedObject.transform.position, speed /1.3f);


            //ROTATION JUTTUJA

            _direction = (assignedObject.transform.position - bird.transform.position);
            _lookRotation = Quaternion.LookRotation(_direction);
            bird.transform.rotation = Quaternion.Slerp(bird.transform.rotation, _lookRotation, Time.deltaTime * 3f); //toimiva rotate
            
            
            bird.transform.LookAt(assignedObject.transform.position);

            //assignedObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, currentPositionHolder, 1f);

            //Vector3 lookDirection = Vector3.RotateTowards(transform.forward, currentPositionHolder, 1f *Time.deltaTime, 0.1f);
            //assignedObject.transform.rotation = Quaternion.LookRotation(lookDirection);
            //assignedObject.GetComponent<Rigidbody>().AddForce((currentPositionHolder - assignedObject.transform.position) * speed);

            //Debug.Log("Im going for node " + currentNode);
        }
        else {

            //Debug.Log("" + currentNode);

            if (currentNode < pathNode.Length - 1) {    //go for next node
                currentNode++;
                checkNode();
            }
            else {      //loop
                currentPositionHolder = pathNode[0].transform.position;
                currentNode = 0;
            }
        }
	}

    void checkNode() {
        //if (currentNode < pathNode.Length -1)
        //timer = 0f;
        currentPositionHolder = pathNode[currentNode].transform.position;
    }
}
