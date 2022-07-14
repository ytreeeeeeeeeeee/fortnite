using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exampleController : MonoBehaviour
{
    [SerializeField] string tagBuilding;
    Camera playerCamera;
    void Start()
    {
        playerCamera = Camera.main;
    }
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == tagBuilding)
        {
            Destroy(playerCamera.GetComponent<build>().example);
        }
    }
}
