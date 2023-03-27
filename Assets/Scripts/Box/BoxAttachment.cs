using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCarrier))]
public abstract class BoxAttachment : MonoBehaviour
{
    protected const int firstBoxNumber = 1;

    
    [SerializeField] protected float _heightBetweenBoxes;

    protected BoxCarrier _boxCarrier;
    protected GameObject _box;
    protected BoxCollider2D _boxCarrierCollider;
    protected BoxCollider2D _boxCollider;
    protected Vector2 _boxCarrierColliderInitialOffset;
    protected Vector2 _boxCarrierColliderInitialSize;

    public virtual bool IsFirstBox { get; set; }

    private void Awake()
    {
        _boxCarrier = GetComponent<BoxCarrier>();
        _boxCarrierCollider = GetComponent<BoxCollider2D>();
        _boxCarrierColliderInitialOffset = _boxCarrierCollider.offset;
        _boxCarrierColliderInitialSize = _boxCarrierCollider.size;
    }

    public void AttachBox()
    {
        ObtainBox();
        Attach();
    }

    protected abstract void ObtainBox();

    protected virtual void Attach()
    {
        ChangeBoxCollider();
        StickBoxToCarrier();
        ExpandBoxCarrierColliderHeight();
    }

    private void ChangeBoxCollider()
    {
        _boxCollider.enabled = false;
        _boxCollider.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    private void StickBoxToCarrier()
    {
        _box.transform.parent = transform;
        _box.transform.position = _boxCarrierCollider.bounds.center;
        _box.transform.localPosition += CalculateBoxNewLocalPosition();
    }

    protected virtual Vector3 CalculateBoxNewLocalPosition()
    {
        float boxCarrierHeightHalf = _boxCarrierCollider.size.y / 2;
        float boxHeightHalf = (_boxCollider.size.y * _box.transform.localScale.y / 2);
        float boxY = boxCarrierHeightHalf + boxHeightHalf;

        if (!IsFirstBox)
        {
            boxY += _heightBetweenBoxes;
        }

        Vector3 boxNewLocalPosition = new Vector3(0, boxY, 0);
        return boxNewLocalPosition;
    }

    private void ExpandBoxCarrierColliderHeight()
    {
        float boxColliderHeight = _boxCollider.size.y * _box.transform.localScale.y;
        if (!IsFirstBox)
        {
            boxColliderHeight += _heightBetweenBoxes;
        }

        _boxCarrierCollider.offset += new Vector2(0, boxColliderHeight / 2);
        _boxCarrierCollider.size += new Vector2(0, boxColliderHeight);
    }

    public void ResetBoxCarrierCollider()
    {
        _boxCarrierCollider.offset = _boxCarrierColliderInitialOffset;
        _boxCarrierCollider.size = _boxCarrierColliderInitialSize;
    }
}
