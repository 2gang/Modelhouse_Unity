using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myCast_lgh : MonoBehaviour
{
    public GameObject head;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject door;
    public GameObject pos3;
    public GameObject door2;
    public GameObject pos4;
    bool isDoor = false;
    bool isDoor2 = false;
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1000;
        Debug.DrawRay(transform.position, forward, Color.green);
        if (Physics.Raycast(transform.position, forward, out hit))
        {
            if (hit.collider.tag == "reTag")
            {
                StartCoroutine(moveCo(pos1));
            }
            else if(hit.collider.tag == "door")
            {
                isDoor = true;
                StartCoroutine(moveCo(pos2));
            }
            else if (hit.collider.tag == "tv")
            {
                StartCoroutine(moveCo(pos3));
            }
            else if (hit.collider.tag == "door2")
            {
                isDoor2 = true;
                StartCoroutine(moveCo(pos4));
            }
            Debug.Log(hit.transform.name);
        }
    }

    IEnumerator moveCo(GameObject pos)//수정
    {
        while (head.transform.position != pos.transform.position)//수정
        {
            head.transform.position = Vector3.MoveTowards(head.transform.position, 
                        pos.transform.position, Time.deltaTime * 0.03f);//수정
            if (isDoor == true)//추가
            {
                door.transform.rotation = Quaternion.Slerp(door.transform.rotation,
                        Quaternion.Euler(0, -120, 0), Time.deltaTime);
            }
            else if (isDoor2 == true)
            {
                door2.transform.rotation = Quaternion.Slerp(door2.transform.rotation,
                        Quaternion.Euler(0, 120, 0), Time.deltaTime);
            }
            yield return null;
        }
    }

}
