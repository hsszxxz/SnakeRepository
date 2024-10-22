using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace interection
{
    ///<summary>
    ///
    ///<summary>
    public class InteractWithDoor : MonoBehaviour
    {
        [Tooltip("玩家距离交互点多远可以交互")]
        public float distance;
        public GameObject tiShiPanel;
        private Animation animation;
        private void Start()
        {
            animation = GetComponent<Animation>();
        }
        private void Update()
        {
            if (FindTarget()!=null)
            {
                if(Vector2.Distance(FindTarget().position,transform.position)<=distance)
                {
                    tiShiPanel.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        animation.Play();
                    }
                }
                else
                {
                    tiShiPanel.SetActive(false);
                }
            }
            else
            {
                tiShiPanel.SetActive(false);
            }
        }
        private Transform FindTarget()
        {
            Transform head1Trans = SneakManager.Instance.head1.transform;
            Transform head2Trans = SneakManager.Instance.head2.transform;
            if (head1Trans == null || head2Trans == null)
                return null;
            float distance1 = Vector2.Distance(transform.position, head1Trans.position);
            float distance2 = Vector2.Distance(transform.position, head2Trans.position);
            return (distance1 > distance2) ? head2Trans : head1Trans;
        }
    }
}

