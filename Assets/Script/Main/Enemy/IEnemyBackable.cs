using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public interface IEnemyBackable
    {
        void ShakeEnemyBack(Transform shakeFrom,float backForce);
    }
}
