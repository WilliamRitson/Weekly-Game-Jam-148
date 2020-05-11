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
    private bool engagedPlayer = false;

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

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (!player) return;
        }

        Vector3 playerPos = player.transform.position;
        if (CanSeePlayer(playerPos))
        {
            lastSawPlayer = 0;
            SetEngagmentState(true);
        }
        else
        {
            lastSawPlayer += Time.deltaTime;
        }

        if (lastSawPlayer > rememberPlayerTime)
        {
            goalPos = originPos;
            SetEngagmentState(false);
            return;
        }

        goalPos = playerPos;

        TriggerProjectileAttack(goalPos);
        if (ability != null && ability.ShouldUse(player))
        {
            TriggerAbility(goalPos);
        }
    }

    private static readonly string[] sawPlayerShouts = new string[] {
        "Intruder!", "Get them!", "Stop!", "You’re not supposed to be here!", "Surrender!", "Die invader!" };

    private static readonly string[] lostPlayerShouts = new string[] {
        "Where did they go?", "The intruder escaped.", "I will catch you eventually.", "You can’t hide forever."  };

    void SetEngagmentState(bool isEngaged)
    {
        if (engagedPlayer != isEngaged)
        {
            Shout(isEngaged ? sawPlayerShouts : lostPlayerShouts);
        }
        engagedPlayer = isEngaged;
    }

    void Shout(string[] variations)
    {
        string message = variations[Random.Range(0, variations.Length - 1)];
        MovingTextManager.Instance.ShowMessage(message, transform.position, Color.white);
    }

    IEnumerator Repath()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(repathTime);
            if (goalPos != lastPathPos)
            {
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





