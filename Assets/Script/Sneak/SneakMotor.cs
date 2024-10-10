using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sneak
{
    ///<summary>
    ///
    ///<summary>
    public enum Direction
    {
        up=0,
        down=1,
        left=2,
        right=3,
    }
    public class SneakMotor
    {
        private Rigidbody2D rigid;
        private Dictionary<Direction, Vector2> forceList;
        public void InitMotor(SneakSingleHeadControl controlScript)
        {
            rigid = controlScript.rigidbody;
            forceList = new Dictionary<Direction, Vector2>()
            {
                { Direction.up, new Vector2(0,1) },
                { Direction.down, new Vector2(0,-1)},
                {Direction.left, new Vector2(-1,0)},
                {Direction.right, new Vector2(1, 0)},
            };
        }
        public void SneakMove(Direction dir,float force)
        {
            rigid.AddForce(forceList[dir]*force,ForceMode2D.Force);
            
        }
    }
}

