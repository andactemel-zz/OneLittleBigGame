using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface OnTheGroundViewInterFace {
    void SetVisibleOnGround();
    void SetInVisibleOnGround();
    void MakeWalkable();
    void UnMakeWalkable();
    void SetOntheGroundSprite(Sprite OntheGround_New);
    Sprite GetOntheGroundSprite();
}
