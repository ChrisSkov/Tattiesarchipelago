using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class KitePlayer : MonoBehaviour
{

    [SerializeField] float stabRange = 3f;
    [SerializeField] float chaseRange = 12f;
    [SerializeField] float kiteThreshold = 2f;
    [SerializeField] float kiteBackDistance = 1f;
    Transform player;
    AIPath path;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        path = GetComponent<AIPath>();

    }

    // Update is called once per frame
    void Update()
    {
        bool isKiting = false;
        //   Gizmos.DrawWireSphere(path.destination, .8f);
        if (InChaseRange() && !isKiting)
        {
            path.destination = player.position;
            if (InKiteRange() && !isKiting)
            {
                isKiting = true;
                float xVal = (float)Random.Range(1, 3);
                float zVal = (float)Random.Range(1, 3);
                path.destination = transform.TransformDirection(new Vector3(transform.position.x + xVal, 0, transform.position.z + zVal));
                if (path.reachedEndOfPath && KiteDistanceReached())
                {
                    isKiting = false;
                }
            }
        }
    }

    private bool InKiteRange()
    {
        return Vector3.Distance(gameObject.transform.position, player.position) <= kiteThreshold;
    }

    bool KiteDistanceReached()
    {
        return Vector3.Distance(gameObject.transform.position, player.position) >= kiteBackDistance;

    }

    private bool InStabRange()
    {
        return Vector3.Distance(gameObject.transform.position, player.position) <= stabRange;
    }

    bool InChaseRange()
    {
        return Vector3.Distance(gameObject.transform.position, player.position) <= chaseRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, stabRange);
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, kiteThreshold);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x,transform.position.y, transform.position.z + kiteBackDistance));

    }
}
