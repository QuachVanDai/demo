using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.EditorApplication;

public class TweenSequence : MonoBehaviour
{
    public Transform myTransform;
    public SpriteRenderer mySprite;
    public Color targetColor;
    public int numLoop;
    public GameObject panel_;
    private void Start()
    {
        myTransform = transform; // Lấy tham chiếu đến Transform của đối tượng hiện tại
                                 //  CreateTweenSequence();
        CreateTweenSequence();
    }

    private void CreateTweenSequence()
    {
        // Tạo một Sequence mới
        Sequence mySequence = DOTween.Sequence();

        // Thêm các tween vào Sequence
        mySequence.Append(myTransform.DOMoveX(2, 1)); // Di chuyển theo trục X trong 1 giây
        mySequence.Append(myTransform.DOScale(new Vector3(2, 2, 2), 0.5f)); // Thay đổi tỉ lệ tức thì
        for(int i=1; i<21; i++)
        {
            targetColor = new Color(Random.RandomRange(0f, 1.0f), Random.RandomRange(0f, 1.0f),0, 1);
            mySequence.Append(myTransform.DORotate(new Vector3(0, 0, -90*i), 0.25f)); // Quay 180 độ trong 0.2 giây
            mySequence.Append(mySprite.DOColor(targetColor, 0.24f));

        }
        /*       mySequence.OnComplete(() =>
               {
                   panel_.SetActive(true);
                   Debug.Log("Tween đã hoàn thành!");
                   // Thực hiện các hành động sau khi tween hoàn thành ở đây
               });*/
        // Đặt số lần lặp và chạy Sequence
        mySequence.SetLoops(numLoop); // Lặp lại Sequence 2 lần
        mySequence.SetAutoKill(false); // Không tự động hủy sau khi hoàn thành
        mySequence.Play(); // Bắt đầu chạy Sequence
    }
}
