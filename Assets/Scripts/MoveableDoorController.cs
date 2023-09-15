using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class MoveableDoorController : MonoBehaviour
{
    [SerializeField]
    private Vector2 moveDistance;

    [SerializeField]
    private new Rigidbody2D rigidbody2D;

    [SerializeField]
    private float slideTime = .25f;
    
    private Vector2 startPosition;

    private void Start() {
        startPosition = transform.position;
    }

    public void OpenDoor() {
        rigidbody2D.DOMove(startPosition + moveDistance, slideTime).SetEase(Ease.InOutSine);
    }

    public void CloseDoor() {
        rigidbody2D.DOMove(startPosition, slideTime).SetEase(Ease.InOutSine);
    }
}
