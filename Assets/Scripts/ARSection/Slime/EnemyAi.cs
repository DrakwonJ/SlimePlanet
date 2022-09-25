
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public enum SlimeAnimationState { Idle=0,Jump=1,Attack=2,Damage=3,Walk = 4}
public class EnemyAi : MonoBehaviour
{

    public Face faces;
    public GameObject SmileBody;
    public SlimeAnimationState currentState;
    SlimeInfo info;
   
    public Animator animator;
    public int damType = 2;

    public float delayTime = 2.0f;
    public bool isDelay = false;

    private Material faceMaterial;


    void Start()
    {
        faceMaterial = SmileBody.GetComponent<Renderer>().materials[1];
        info = GetComponent<SlimeInfo>();
    }

    void SetFace(Texture tex)
    {
        faceMaterial.SetTexture("_MainTex", tex);
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            isDelay = true;
            StartCoroutine(SlimeAnimeOnPlanet());
        }
        else if (gameObject.transform.parent != null) {
            if (gameObject.transform.parent.name == "SlimeLayout" || gameObject.transform.parent.name == "target1" || gameObject.transform.parent.name == "target2")
                return;
        }
        else if (!isDelay && SceneManager.GetActiveScene().name == "MainScene" && gameObject.GetComponent<PlanetSlime>().onPlanet)
        {
            isDelay = true;
            StartCoroutine(SlimeAnimeOnPlanet());
        }

        else if (SceneManager.GetActiveScene().name == "ARScene" && info.currentHp == 0 && currentState != SlimeAnimationState.Damage)
        {
            StopCoroutine(SlimeAnime());
            currentState = SlimeAnimationState.Damage;
            animator.SetTrigger("Damage");
            animator.SetInteger("DamageType", damType);
            SetFace(faces.damageFace);
            DataManager.dataManager.AddSlimeCode(info.CheckSlimeList(), info.slimeCode);
            DataManager.dataManager.SubmitData("SlimeList");
            DataManager.dataManager.DecreaseData("curChance");
            DataManager.dataManager.IncreaseData("totalCatch");
            DataManager.dataManager.SubmitData();
            if(DataManager.dataManager.daily_catch < 3)
            {
                DataManager.dataManager.IncreaseDailyData("catchSlime");
                DataManager.dataManager.IncreaseDailyData("catchSlime2");
                DataManager.dataManager.SubmitData("DailyQuest");
            }
            if(DataManager.dataManager.weekly_catch < 15)
            {
                DataManager.dataManager.IncreaseWeeklyData("catchSlime");
                DataManager.dataManager.IncreaseWeeklyData("catchSlime2");
                DataManager.dataManager.SubmitData("WeeklyQuest");
            }
            Debug.Log("Take Damage");

            Destroy(gameObject, 1.0f);
        }
        else if (!isDelay && currentState != SlimeAnimationState.Damage)
        {
            isDelay = true;
            StartCoroutine(SlimeAnime());
        }
        else
        {
            return;
        }
    }
    IEnumerator SlimeAnimeOnPlanet()
    {
        int random = Random.Range(0, 10);
        if (random <= 3)
            currentState = SlimeAnimationState.Walk;
        else if (random <= 6)
            currentState = SlimeAnimationState.Jump;
        else
            currentState = SlimeAnimationState.Idle;
        switch (currentState)
        {
            case SlimeAnimationState.Idle:

                SetFace(faces.WalkFace);
                break;
            case SlimeAnimationState.Jump:
                SetFace(faces.jumpFace);
                animator.SetTrigger("Jump");
                break;
            case SlimeAnimationState.Walk:
                SetFace(faces.WalkFace);
                animator.SetTrigger("Walk");
                break;

        }

        yield return new WaitForSeconds(delayTime);
        isDelay = false;
    }

    IEnumerator SlimeAnime()
    {
        currentState = (SlimeAnimationState)Random.Range(0, 3);

        switch (currentState)
        {
            case SlimeAnimationState.Idle:

                SetFace(faces.WalkFace);
                break;
            case SlimeAnimationState.Jump:

                SetFace(faces.jumpFace);
                animator.SetTrigger("Jump");
                Debug.Log("Jumping");
                break;

            case SlimeAnimationState.Attack:

                SetFace(faces.attackFace);
                animator.SetTrigger("Attack");
                Debug.Log("Attack");

                break;
            case SlimeAnimationState.Damage:
                break;

        }
        yield return new WaitForSeconds(delayTime);
        isDelay = false;
    }


}


