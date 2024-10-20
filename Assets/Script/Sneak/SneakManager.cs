using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sneak
{
    ///<summary>
    ///
    ///<summary>
    public class SneakManager : MonoSingleton<SneakManager>
    {
        [HideInInspector]
        public int length;//去头去尾的长度
        [HideInInspector]
        public List<SneakBody> bodies;
        [HideInInspector]
        public GameObject sneakBodies;
        [HideInInspector]
        public GameObject head1;
        [HideInInspector]
        public GameObject head2;
        private float forceChange = 0.2f;
        public override void Init()
        {
            base.Init();
            sneakBodies = GameObject.Find("SneakBody");
            bodies = new List<SneakBody>();
            InitHeads();
        }
        private void Start()
        {
            AddSneakBodyToPrevious(head1.GetComponent<SneakBody>());
            AddSneakBodyToPrevious(head1.GetComponent<SneakBody>());
            AddSneakBodyToPrevious(head1.GetComponent<SneakBody>());
        }

        public void InitHeads()
        {
            DeletSneakBody();
            foreach(Transform child in sneakBodies.transform)
            {
                Destroy(child.gameObject);
            }
            head1 = Instantiate(Resources.Load("Prefabs/Head1") as GameObject,sneakBodies.transform);
            head2 = Instantiate(Resources.Load("Prefabs/Head2") as GameObject,sneakBodies.transform);
            head1.GetComponent<SneakBody>().nextBody = head2.GetComponent<SneakBody>();
            head1.GetComponent<SneakBody>().previousBody = null;
            head2.GetComponent<SneakBody>().previousBody = head1.GetComponent<SneakBody>();
            head2.GetComponent<SneakBody>().nextBody = null;
            bodies.Add(head1.GetComponent<SneakBody>());
            bodies.Add(head2.GetComponent<SneakBody>());
        }
        public void AddSneakBodyToPrevious(SneakBody PreviousBody)
        {
            Vector3 prePos = PreviousBody.transform.localPosition;
            SneakBody current = PreviousBody;
            while(current != null)
            {
                current.transform.localPosition += current.transform.up*0.6f;
                current = current.previousBody;
            }
            GameObject note = Instantiate(Resources.Load("Prefabs/SneakBody") as GameObject,sneakBodies.transform);
            note.transform.localPosition = prePos;
            SneakBody body = note.GetComponent<SneakBody>();
            PreviousBody.nextBody.previousBody = body;
            body.previousBody = PreviousBody;
            body.nextBody = PreviousBody.nextBody;
            PreviousBody.nextBody = body;
            note.transform.localRotation =  PreviousBody.transform.localRotation;
            head1.GetComponent<SneakSingleHeadControl>().moveForce += forceChange;
            head2.GetComponent<SneakSingleHeadControl>().moveForce += forceChange;
            bodies.Add(body);
            length++;
        }
        public void AddSneakBodyToNext(SneakBody NextBody)
        {
            Vector3 nextPos = NextBody.transform.localPosition;
            SneakBody current = NextBody;
            while (current != null)
            {
                current.transform.localPosition -= current.transform.up * 0.6f;
                current = current.nextBody;
            }
            GameObject note = Instantiate(Resources.Load("Prefabs/SneakBody") as GameObject,sneakBodies.transform);
            note.transform.localPosition = nextPos;
            SneakBody body = note.GetComponent<SneakBody>();
            NextBody.previousBody.nextBody = body;
            body.previousBody = NextBody.previousBody;
            NextBody.previousBody = body;
            body.nextBody = NextBody;
            note.transform.localRotation = NextBody.transform.localRotation;
            head1.GetComponent<SneakSingleHeadControl>().moveForce += forceChange;
            head2.GetComponent<SneakSingleHeadControl>().moveForce += forceChange;
            bodies.Add(body);
            length++;
        }
        public bool DeletSneakBody(SneakBody sneak)
        {
            if (!bodies.Contains(sneak))
                return false;
            bodies.Remove(sneak);
            SneakBody temp = head1.GetComponent<SneakBody>();
            while (temp !=sneak)
            {
                temp.transform.localPosition = temp.nextBody.transform.localPosition;
                temp.transform.localRotation = temp.nextBody.transform.localRotation;
                temp = temp.nextBody;
            }
            if (temp == null)
                return false;
            temp.nextBody.previousBody = temp.previousBody;
            temp.previousBody.nextBody = temp.nextBody;
            Destroy(temp.gameObject);
            head1.GetComponent<SneakSingleHeadControl>().moveForce -= forceChange;
            head2.GetComponent<SneakSingleHeadControl>().moveForce -= forceChange;
            length--;
            return true;
        }
        public bool DeletSneakBody()
        {
            for (int i = bodies.Count-1; i>=0;i--)
            {
                SneakBody body = bodies[i];
                if (body.type == HeadType.Head1 || body.type == HeadType.Head2)
                    continue;
                if(!DeletSneakBody(body))
                    return false;
            }
            length = 0;
            return true;
        }
    }
}

