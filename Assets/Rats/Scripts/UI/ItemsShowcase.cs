using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Animator))]
public class ItemsShowcase : MonoBehaviour
{

    public bool isAccepted;

    [SerializeField]
    private UIClothingPreview clothingPreview;

    private Animator animator;

    public UnityEvent OnItemShown;

    public void Show(Clothes clothing)
    {
        animator.SetTrigger("Start");
        isAccepted = false;
        clothingPreview.Show(clothing);
        OnItemShown.Invoke();
    }

    public void Hide()
    {
        animator.SetTrigger("End");
    }

    public void btn_Accept()
    {
        isAccepted = true;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

}