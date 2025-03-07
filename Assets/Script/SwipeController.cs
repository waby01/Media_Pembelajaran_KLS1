using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
   [SerializeField] int maXpage;
   int currentPage;
    Vector3 targerPos;
    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform MenuPagesRect;

    [SerializeField] float tweenTime;
    [SerializeField] LeanTweenType tweenType;

    private void Awake()
    {
        currentPage = 1;
        targerPos = MenuPagesRect.localPosition;
    }

    public void Next()
    {
        if (currentPage < maXpage)
        {
            currentPage++;
            targerPos += pageStep;
            MovePage();
        }
    }

    public void Back()
    {
        if (currentPage > 1)
        {
            currentPage--;
            targerPos -= pageStep;
            MovePage();
        }
    }

    void MovePage()
    {
        MenuPagesRect.LeanMoveLocal (targerPos, tweenTime).setEase(tweenType);
    }

}
