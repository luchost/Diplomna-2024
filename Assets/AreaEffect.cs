using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffect : Effect
{
    int radius = 100000;
    HashSet<GameObject> affected = new HashSet<GameObject>();

    Collider[] GetObjectsInRange()
    {
        return Physics.OverlapSphere(transform.position, radius, 1);
    }

    void UpdateAffectedObjects(Collider[] objects)
    {
        var old_affected = new HashSet<GameObject>(affected);
        foreach (var obj in objects)
            if (old_affected.Contains(obj.gameObject))
                old_affected.Remove(obj.gameObject);
            else
            {
                affected.Add(obj.gameObject);
                AddEffectsForObject(obj.gameObject);
            }
        foreach (var obj in old_affected)
        {
            affected.Remove(obj);
            if (obj != null)
                RemoveEffectsForObject(obj);
        }
    }

    public override void GameUpdate()
    {
        UpdateAffectedObjects(GetObjectsInRange());
    }

    private void OnDestroy()
    {
        Collider[] empty = new Collider[0];
        UpdateAffectedObjects(empty);
    }
    public virtual void AddEffectsForObject(GameObject obj) {}
    public virtual void RemoveEffectsForObject(GameObject obj) {}

}
