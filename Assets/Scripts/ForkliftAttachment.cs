using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftAttachment : BoxAttachment
{
    private new const int firstBoxNumber = 0;

    private int _boxNumber = 0;

    public override bool IsFirstBox => _boxNumber == firstBoxNumber;

    public void AttachMultipleBoxes()
    {
        List<GameObject> boxes = _boxCarrier.CarriedBoxes;
        foreach (GameObject box in boxes)
        {

            AttachBox();
            _boxNumber++;
        }

        _boxNumber = 0;
    }

    protected override void ObtainBox()
    {
        _box = _boxCarrier.CarriedBoxes[_boxNumber];
        _boxCollider = _box.GetComponent<BoxCollider2D>();
    }
}

