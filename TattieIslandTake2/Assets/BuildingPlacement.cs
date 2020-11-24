using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{

    public bool canPlace = false;

    // Start is called before the first frame update
    BoxCollider m_Collider;
    RaycastHit m_Hit;
    bool m_HitDetect;
    public float placeRange = 4f;
    public List<GameObject> gameObjectList;
    void Start()
    {
        m_Collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        print(gameObjectList.Count);
        if (gameObjectList.Count == 0)
        {
            canPlace = true;
        }
        else
        {
            canPlace = false;
        }
        if (canPlace)
        {
            GetComponent<MeshRenderer>().material.color = Color.green;

        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.red;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 15)
        {
            gameObjectList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 15)
        {
            gameObjectList.Remove(other.gameObject);
        }
    }

}

