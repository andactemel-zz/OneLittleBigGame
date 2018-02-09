using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface OnTheGroundViewInterFace {
    void SetVisibleOnGround();
    void SetInVisibleOnGround();
    void SetWalkableStatus(bool Walkable);
    void SetOntheGroundSprite(Sprite OntheGround_New);
    Sprite GetOntheGroundSprite();
}
