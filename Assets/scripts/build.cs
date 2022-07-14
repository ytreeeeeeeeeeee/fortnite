using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class build : MonoBehaviour
{
    [SerializeField] GameObject floor;
    [SerializeField] GameObject floorEx;
    [SerializeField] GameObject wall;
    [SerializeField] GameObject wallEx;
    [SerializeField] GameObject ramp;
    [SerializeField] GameObject rampEx;
    
    public GameObject example;
    
    string typeBuilding;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Destroy(example);
            typeBuilding = "floor";
        }
        else if (Input.GetKey(KeyCode.X))
        {
            Destroy(example);
            typeBuilding = "wall";
        }
        else if (Input.GetKey(KeyCode.C))
        {
            Destroy(example);
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
                if (Input.GetMouseButtonDown(0) && example)
                {
                    Instantiate(floor, example.transform.position, example.transform.rotation);
                }
                break;
            case "wall":
                CreateWall();
                if (Input.GetMouseButtonDown(0) && example)
                {
                    Instantiate(wall, example.transform.position, example.transform.rotation);
                }
                break;
            case "ramp":
                CreateRamp();
                if (Input.GetMouseButtonDown(0) && example)
                {
                    Instantiate(ramp, example.transform.position, example.transform.rotation);
                }
                break;
            case "nothing":
                Destroy(example);
                break;
            default:
                break;
        }
    }
    void CreateFloor()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 6))
        {

            Vector3 pos = new Vector3(Mathf.Abs(Mathf.RoundToInt(hit.point.x / 3) * 3 - hit.point.x) > 0.8f ? (Mathf.RoundToInt(hit.point.x / 3) * 3 - hit.point.x < 0 ? Mathf.RoundToInt((hit.point.x + 0.85f) / 3) * 3 : Mathf.RoundToInt((hit.point.x - 0.85f) / 3) * 3) : Mathf.RoundToInt(hit.point.x / 3) * 3, 
                (Mathf.RoundToInt(hit.point.y) != 0 ? Mathf.RoundToInt(hit.point.y / 3) * 3 : 0) + floorEx.transform.localScale.y / 2,
                Mathf.Abs(Mathf.RoundToInt(hit.point.z / 3) * 3 - hit.point.z) > 0.8f ? (Mathf.RoundToInt(hit.point.z / 3) * 3 - hit.point.z < 0 ? Mathf.RoundToInt((hit.point.z + 0.85f) / 3) * 3 : Mathf.RoundToInt((hit.point.z - 0.85f) / 3) * 3) : Mathf.RoundToInt(hit.point.z / 3) * 3);
            Collider[] checkBuildings = Physics.OverlapBox(pos, new Vector3(0.5f, 0.05f, 0.5f), Quaternion.identity, 1 << 6);
            if (checkBuildings.Length == 0)
            {
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
        }
        else
        {
            Destroy(example);
        }
    }
    void CreateWall()
    {
        RaycastHit hit;
        bool check = false;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 6))
        {
            Vector3 pos = new Vector3(Mathf.RoundToInt(hit.point.x) != 0 ? Mathf.RoundToInt(hit.point.x / 3) * 3 : 0,
                (Mathf.RoundToInt(hit.point.y) != 0 ? Mathf.RoundToInt(hit.point.y / 3) * 3 : 0) + 1.5f,
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
    }
    void CreateRamp()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 6))
        {
            Vector3 pos = new Vector3(Mathf.Abs(Mathf.RoundToInt(hit.point.x / 3) * 3 - hit.point.x) > 0.8f ? (Mathf.RoundToInt(hit.point.x / 3) * 3 - hit.point.x < 0 ? Mathf.RoundToInt((hit.point.x + 0.85f) / 3) * 3 : Mathf.RoundToInt((hit.point.x - 0.85f) / 3) * 3) : Mathf.RoundToInt(hit.point.x / 3) * 3, 
                    (Mathf.RoundToInt(hit.point.y) != 0 ? Mathf.RoundToInt(hit.point.y / 3) * 3 : 0) + 1.5f,
                    Mathf.Abs(Mathf.RoundToInt(hit.point.z / 3) * 3 - hit.point.z) > 0.8f ? (Mathf.RoundToInt(hit.point.z / 3) * 3 - hit.point.z < 0 ? Mathf.RoundToInt((hit.point.z + 0.85f) / 3) * 3 : Mathf.RoundToInt((hit.point.z - 0.85f) / 3) * 3) : Mathf.RoundToInt(hit.point.z / 3) * 3);
            Collider[] checkBuildings = Physics.OverlapBox(pos, new Vector3(0.5f, 0.05f, 0.5f), Quaternion.Euler(-45, 0, 0), 1 << 6);
            if (checkBuildings.Length == 0)
            {
                if (example == null)
                {
                    example = Instantiate(rampEx, pos, Quaternion.identity);
                }
                else
                {
                    example.transform.position = pos;
                    example.transform.eulerAngles = new Vector3(-45, Mathf.RoundToInt(transform.eulerAngles.y) != 0 ? Mathf.RoundToInt(transform.eulerAngles.y / 90) * 90 : 0, 0);
                }
            }
            else
            {
                Destroy(example);
            }
        }
        else
        {
            Destroy(example);
        }
    }
}
