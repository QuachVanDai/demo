using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class phuongthuc : MonoBehaviour
{
    // Lưu trữ vị trí ban đầu của đối tượng
    private Vector3 initialPosition;

    // Tween để dịch chuyển đối tượng
    private Tweener tween;

    private void Start()
    {
        // Lấy vị trí ban đầu của đối tượng
        initialPosition = transform.position;
    }

    public void StartTween()
    {
        tween = transform.DOMove(new Vector3(2, 3, 0), 3f);

        tween.Play();
    }

    public void StopTween()
    {
        // Dừng tween
        tween.Pause();
    }

    public void ResetTween()
    {
        // Tạo một tween mới từ vị trí hiện tại đến vị trí ban đầu
        tween = transform.DOMove(initialPosition, 0);
    }
}
