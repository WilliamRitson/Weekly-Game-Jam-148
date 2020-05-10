using Pathfinding;
using System.Collections;
using UnityEngine;

public class EnemyAI : Controller
{
    public float moveSpeed = 5f;

    GameObject player;

    [SerializeField]
    private float maxEngagmentDist = 8.0f;
    [SerializeField]
    private float rememberPlayerTime = 2.0f;

    public float repathTime = 0.5f;

    private float lastSawPlayer = Mathf.Infinity; 
    private float squaredMaxEngagmentDist;
    private Ability ability;

    private Vector3 goalPos;
    private Vector3 originPos;
    private Vector3 lastPathPos;
    private Seeker seeker;
    private Path path;
    
    int currentWaypoint = 0;

    private void Start()
    {
        ConnectedToControllables();
        player = GameObject.FindGameObjectWithTag("Player");
        squaredMaxEngagmentDist = maxEngagmentDist * maxEngagmentDist;
        seeker = GetComponent<Seeker>();
        ability = GetComponent<Ability>();
        originPos = transform.position;
        goalPos = originPos;
        StartCoroutine(Repath());
    }

    void Update()
    {
        FollowPath();

        Vector3 playerPos = player.transform.position;
        if ((transform.position - playerPos).sqrMagnitude > squaredMaxEngagmentDist)

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (!player) return;
        }

        if (CanSeePlayer(playerPos))
        {
            lastSawPlayer = 0;
        }
        else
        {
            lastSawPlayer += Time.deltaTime;
        }

        if (lastSawPlayer > rememberPlayerTime)
        {
            goalPos = originPos;
            return;
        }

        goalPos = playerPos;

        TriggerProjectileAttack(goalPos);
        if (ability != null && ability.ShouldUse(player))
        {
            TriggerAbility(goalPos);
        }
    }

    IEnumerator Repath ()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(repathTime);
            if (goalPos != lastPathPos) {
                lastPathPos = goalPos;
                seeker.StartPath(transform.position, goalPos, OnPathFound);
            }
        }
    }

    void FollowPath()
    {
        if (path == null)
        {
            movementDirection = Vector3.zero;
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            path = null;
            return;
        }
        Vector3 nextPoint = path.vectorPath[currentWaypoint];
        Vector3 towardsNextPoint = nextPoint - transform.position;
        movementDirection = towardsNextPoint;
        if (towardsNextPoint.sqrMagnitude < 0.5)
        {
            currentWaypoint++;
        }
    }

    void OnPathFound(Path newPath)
    {
        if (newPath.error) return;
        currentWaypoint = 0;
        path = newPath;
    }

    bool CanSeePlayer(Vector3 playerPos)
    {
        if ((transform.position - playerPos).sqrMagnitude > squaredMaxEngagmentDist)
        {
            return false;
        }
        RaycastHit2D cast = Physics2D.Raycast(transform.position, playerPos - transform.position);
        return cast.collider.gameObject == player;
    }

}





