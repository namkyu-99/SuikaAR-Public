using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Next_Image_changer : MonoBehaviour
{
    public Image targetImage;
    public Sprite[] sprites;
    public GameObject GameSystem_Object;
    private GameSystem gameSystem;

    void Start()
    {
        // GameSystem 컴포넌트 찾아서 참조
        gameSystem = GameSystem_Object.GetComponent<GameSystem>();
        if (gameSystem == null)
        {
            Debug.LogError("GameSystem이 찾을 수 없습니다.");
        }
    }

    void Update()
    {
        int NextNextIndex = gameSystem.GetNextNextIndex();
        if (NextNextIndex != null)
        {
            ChangeImage(NextNextIndex);
        }
    }

    void ChangeImage(int index)
    {
        if (sprites != null && sprites.Length > index)
        {
            targetImage.sprite = sprites[index];
        }
    }
}
