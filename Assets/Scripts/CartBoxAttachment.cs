using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartBoxAttachment : BoxAttachment
{
    [SerializeField] private PlayerMove _playerMove;

    public override bool IsFirstBox => _boxCarrier.CarriedBoxesCount == firstBoxNumber;

    protected override void ObtainBox()
    {
        _box = _boxCarrier.LastCollidedBox;
        _boxCollider = _box.GetComponent<BoxCollider2D>();
    }

    protected override void Attach()
    {
        base.Attach();
        FixBoxFacingDirection();
    }

    private void FixBoxFacingDirection()
    {
        if (_playerMove.IsPlayerMirroredToRight)
        {
            _box.transform.rotation = Quaternion.Euler(0, 180, 0);
            return;
        }

        _box.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
