using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool open = false;
    public Transform doorAxel;
    public void Move(float moveAmount, float duration)
    {
        doorAxel.DOLocalRotate(doorAxel.up * moveAmount, duration);
    }
}
