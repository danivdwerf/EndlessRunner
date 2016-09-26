using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathAnimation : MonoBehaviour
{
    [SerializeField]private Image deathObject;
    
    private Animation anim;

    public static DeathAnimation deathAnimation;

    void Start () {
        deathAnimation = this;
        anim = deathObject.GetComponent<Animation>();
    }

    public void Death()
    {
        anim.Play();
    }
}
