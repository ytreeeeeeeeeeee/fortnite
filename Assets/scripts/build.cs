using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class build : MonoBehaviour
{
    [SerializeField] GameObject floor;
    [SerializeField] GameObject floorEx;
    [SerializeField] GameObject wall;
    [SerializeField] GameObject wallEx;
    
    GameObject example;
    string typeBuilding;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            typeBuilding = "floor";
        }
        else if (Input.GetKey(KeyCode.X))
        {
            typeBuilding = "wall";
        }
        else if (Input.GetKey(KeyCode.C))
        {
            typeBuilding = "ramp";
        }
        else if (Input.GetMouseButtonDown(1))
        {
            typeBuilding = "nothing";
        }

        switch (typeBuilding)
        {
            case "floor":
                CreateFloor();
                break;
            case "nothing":
                Destroy(example);
                break;
            case "wall":
                CreateWall();
                break;
            default:
                break;
        }
    }
    void CreateFloor()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (Vector3.Distance(transform.position, hit.point) <= 6)
            {
                Vector3 pos = new Vector3(Mathf.RoundToInt(hit.point.x) != 0 ? Mathf.RoundToInt(hit.point.x / 3) * 3 : 0, 
                    (Mathf.RoundToInt(hit.point.y) != 0 ? Mathf.RoundToInt(hit.point.y / 3) * 3 : 0) + floorEx.transform.localScale.y / 2, 
                    Mathf.RoundToInt(hit.point.z) != 0 ? Mathf.RoundToInt(hit.point.z / 3) * 3 : 0);
                if (example == null)
                {
                    example = Instantiate(floorEx, pos, Quaternion.identity);
                }
                else
                {
                    example.transform.position = pos;
                }
            }
            else
            {
                Destroy(example);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(floor, example.transform.position, example.transform.rotation);
            }
        }
    }
    void CreateWall()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (Vector3.Distance(transform.position, hit.point) <= 6)
            {
                Vector3 pos = new Vector3(Mathf.RoundToInt(hit.point.x) != 0 ? Mathf.RoundToInt(hit.point.x / 3) * 3 : 0,
                    (Mathf.RoundToInt(hit.point.y) != 0 ? Mathf.RoundToInt(hit.point.y / 3) * 3 : 0) + wallEx.transform.localScale.y / 2,
                    Mathf.RoundToInt(hit.point.z) != 0 ? Mathf.RoundToInt(hit.point.z / 3) * 3 : 0);
                if (example == null)
                {
                    example = Instantiate(wallEx, pos, Quaternion.identity);
                }
                else
                {
                    example.transform.position = pos;
                    example.transform.eulerAngles = new Vector3(0, Mathf.RoundToInt(transform.eulerAngles.y) != 0 ? Mathf.RoundToInt(transform.eulerAngles.y / 90) * 90 : 0, 0);
                }
            }
            else
            {
                Destroy(example);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(wall, example.transform.position, example.transform.rotation);
            }
        }
    }
}
