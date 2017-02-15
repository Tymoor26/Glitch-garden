using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;
    void Start()
    {
        animator = GameObject.FindObjectOfType<Animator>();
        projectileParent = GameObject.Find("Projectiles");

        
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
        SetMyLaneSpawner();

    }

    void Update()
    {
        if (IsAttackerAheadInLane()) { animator.SetBool("isAttacking", true); }
        else                         { animator.SetBool("isAttacking", false);}

    }

    bool IsAttackerAheadInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0) { return false; }


        foreach (Transform child in myLaneSpawner.transform)
        {
            if (child.position.x > transform.position.x) { return true; }
        }
        return false;
    }

    void SetMyLaneSpawner()
    {
        Spawner[] spawnPoints = GameObject.FindObjectsOfType<Spawner>();

        foreach (Spawner thisSpawn in spawnPoints)
        {
            if(transform.position.y == thisSpawn.transform.position.y) { myLaneSpawner = thisSpawn; }
        }

        if (!myLaneSpawner) { Debug.LogError("my lane spawner not found"); }
    }
    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
