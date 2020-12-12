using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseConsumable : MonoBehaviour
{
    public Player player;
    AudioSource source;
    Vector3 mouseWorldPositon = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        player.resources.healthPot.resourceCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PickUpItem();
        if (player.resources.healthPot.resourceCount >= 1 && Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.activeConsumable.ConsumeItem(source);
        }
    }



    private void PickUpItem()
    {
        //Set up hit, ray and mask for raycast
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = LayerMask.GetMask("ConsumablePickUp");

        //execute raycast and calculate mouse position
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            mouseWorldPositon = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            if (Vector3.Distance(transform.position, hit.collider.gameObject.transform.position) <= 5f)
            {
                player.closeToPickUp = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    player.activeConsumable = hit.collider.gameObject.GetComponent<PickUpConsumable>().thisConsumable;
                    player.resources.healthPot.resourceCount++;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
