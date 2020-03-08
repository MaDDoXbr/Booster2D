using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class TweenMove : MonoBehaviour
{
    public bool RunOnStart;
    public Vector3 endPos;
    public float duration;
    public Ease ease;
    public bool loop;
    [ShowIf("Showlooptype")]
    public LoopType loopType;

    public float Delay;
    public bool Reverse;

    public bool Showlooptype() { return loop; }
    
    void Start()
    {
        if (RunOnStart)
            Run();
    }

    public void Run()
    {
        // var tParms = new TweenParams();
        // tParms = tParms.SetLoops(-1).SetEase(Ease.OutElastic);

        var tween = transform.DOMove(endPos, duration).SetEase(ease).SetDelay(Delay); //.SetAs(tParms)
        if (loop)
            tween.SetLoops(-1, loopType);
        if (Reverse)        
            tween.From();
        tween.Play();
    }

    [Button("Read Target Pos From Editor")]
    public void ReadTargetFromEditor()
    {
        endPos = transform.position;
    }
}
