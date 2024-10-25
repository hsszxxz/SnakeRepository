using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class FindSneakPosition
{
    public static Transform FindTarget(Transform self)
    {
        Transform head1Trans = SneakManager.Instance.head1.transform;
        Transform head2Trans = SneakManager.Instance.head2.transform;
        if (head1Trans == null || head2Trans == null)
            return null;
        float distance1 = Vector2.Distance(self.position, head1Trans.position);
        float distance2 = Vector2.Distance(self.position, head2Trans.position);
        return (distance1 > distance2) ? head2Trans : head1Trans;
    }
}

