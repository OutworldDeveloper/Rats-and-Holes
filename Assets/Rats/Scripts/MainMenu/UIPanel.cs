using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CanvasGroup))]
public class UIPanel : MonoBehaviour
{

    public UnityEvent OnPanelStart;
    public UnityEvent OnPanelClose;

    private CanvasGroup canvasGroup;
    private Animator animator;

    public virtual void StartPanel()
    {
        OnPanelStart.Invoke();
        animator.SetTrigger("Show");
    }
    public virtual void ClosePanel()
    {
        OnPanelClose.Invoke();
        animator.SetTrigger("Hide");
    }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        animator = GetComponent<Animator>();
    }

}