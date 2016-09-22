using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathAnimation : MonoBehaviour
{
    [SerializeField]private Image death_object;
    
    private Animation dAnim;

    public static DeathAnimation deathAnimation;

    void Start () {
        deathAnimation = this;
        dAnim = death_object.GetComponent<Animation>();
    }

    public void Death()
    {
        dAnim.Play();
    }
}
