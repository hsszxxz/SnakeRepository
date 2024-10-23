using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sneak
{
    ///<summary>
    ///
    ///<summary>
    public class SneakBodyNote : SneakBody
    {
        protected override void Init()
        {
            type = HeadType.Body;
            transform.tag = type.ToString();
        }

    }
}

