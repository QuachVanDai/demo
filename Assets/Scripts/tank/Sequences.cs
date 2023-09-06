using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sequences : MonoBehaviour
{
    public Transform myTransform;
    public Color targetColor;
    public SpriteRenderer mySprite;
    public int numLoop;
    public Vector3 newTarget;
    public Vector3 newScale;
    public GameObject panel_;
    // Start is called before the first frame update
    void Start()
    {
        mySequences();

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void mySequences()
    {
        // Tạo một Sequence mới
        Sequence mySequence = DOTween.Sequence();

        // Thêm các tween vào Sequence
        mySequence.Append(myTransform.DOMove(newTarget, 1)); // Di chuyển theo trục X trong 1 giây
        mySequence.Append(myTransform.DOScale(newScale, 0.5f)); // Thay đổi tỉ lệ tức thì
        for (int i = 1; i < 6; i++)
        {
            targetColor = new Color(Random.RandomRange(0f, 1.0f), Random.RandomRange(0f, 1.0f), 0, 1);
            mySequence.Append(myTransform.DORotate(new Vector3(0, 0, 90 * i), 0.5f)); // Quay 180 độ trong 0.2 giây
            mySequence.Append(mySprite.DOColor(targetColor, 0.5f));

        }
             mySequence.OnComplete(() =>
               {
                   StartCoroutine(myComplete());
                   // Thực hiện các hành động sau khi tween hoàn thành ở đây
               });
        // Đặt số lần lặp và chạy Sequence
        mySequence.SetLoops(numLoop); // Lặp lại Sequence 2 lần
        mySequence.SetAutoKill(false); // Không tự động hủy sau khi hoàn thành
        mySequence.Play(); // Bắt đầu chạy Sequence
    }

    IEnumerator myComplete()
    {
        panel_.SetActive(true);
        yield return new WaitForSeconds(5);
        panel_.SetActive(false);
    }
}
