using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class canvas : MonoBehaviour
{
    public Text textComponent; // Tham chiếu đến thành phần Text cần thay đổi nội dung.
    // Start is called before the first frame update
    void Start()
    {
        // Sử dụng phương thức DOText để tạo tween cho văn bản.
        textComponent.DOText("Good bye!", 2f,true) // Văn bản ban đầu và thời gian hoàn thành tween.
            .SetDelay(1f); // Thời gian trễ trước khi tween bắt đầu.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
