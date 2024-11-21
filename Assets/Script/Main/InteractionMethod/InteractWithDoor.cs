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
        protected virtual void Start()
        {
            animation = GetComponent<Animation>();
        }
        protected virtual void InterectMethod()
        {
            animation.Play();
        }
        protected virtual void ShowPanel()
        {
            tiShiPanel.SetActive(true);
        }
        private void Update()
        {
            if (FindSneakPosition.FindTarget(transform)!=null)
            {
                if(Vector2.Distance(FindSneakPosition.FindTarget(transform).position,transform.position)<=distance)
                {
                    ShowPanel();
                    foreach (var input in SneakManager.Instance.inputControlers)
                    {
                        if (input.gameplay.Confirm.WasPressedThisFrame() || input.handleplay.Interact.WasPressedThisFrame())
                        {
                            InterectMethod();
                            break;
                        }
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
    }
}

