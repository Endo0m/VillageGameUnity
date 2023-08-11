using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public ImageTimer HarvestTimer;
    public ImageTimer EatingTimer;
    public Image RaidTimerImg;
    public Image PeasantTimerImg;
    public Text peasantCreateTimeText;
    public Image WarriorTimerImg;
    public Text warriorCreateTimeText;
    public Image PeasantTimerImg2;
    public Text peasantCreateTimeText2;
    public Image WarriorTimerImg2;
    public Text warriorCreateTimeText2;

    public GameObject PauseCheack;
    public GameObject CanvasMenu;
    public GameObject CanvasPause;
    public GameObject CanvasGame;

    public GameObject LosePanel;
    public GameObject WinPanel;


    public Button peasantButton;
    public Button warriorButton;
    public Button peasantButton2;
    public Button warriorButton2;

    public Text resourcesText;

    public int peasantCount;
    public int warriorCount;
    public int wheatCount;

    public int wheatPerPeasant;
    public int wheatToWarrior;

    public int peasantCost;
    public int warriorCost;


    public float peasantCreateTime;
    public float warriorCreateTime;
    public float peasantCreateTime2;
    public float warriorCreateTime2;


    public float raidMaxTime;
    public Text raidCreateTimeText;

    public int raidIncrease;
    public int nextRaid;

    private float persantTimer = -2;
    private float warriorTimer = -2;
    private float persantTimer2 = -2;
    private float warriorTimer2 = -2;
    private float raidTimer;

    public Text nextCountEnemy;
    public Text loseGameScoreText;
    public Text winGameScoreText;
    public Text costPeasantText;
    public Text costWarriorText;
    public Text farmText;
    public Text expenses;


    public AudioSource audioSourse;
    public AudioClip clickMusic;
    public AudioClip persantHere;
    public AudioClip warriorHere;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip gameSound;

    private bool gameRestarted = false;
    private bool peasantCreated = true;
    private bool peasantCreated2 = true;
    private bool warriorCreated = true;
    private bool warriorCreated2 = true;

    private float harvestStat;
    private float experiesentWavesStat;
    private float deadWarriorsStat;

    private int peasantMaxCount = 55;
    private int warriorMaxCount = 35;
    private int wheatCountMax = 1200;


    void Start()
    {
        PauseCheack.GetComponent<GameObject>();
        CanvasMenu.GetComponent<GameObject>();
        CanvasPause.GetComponent<GameObject>();
        CanvasGame.GetComponent<GameObject>();

        raidMaxTime = 20f;
        raidIncrease = 2;
        nextRaid = 0;
        experiesentWavesStat = 0;
        peasantCount = 4;
        warriorCount = 0;
        wheatCount = 10;

        costPeasantText.text = peasantCost.ToString();
        costWarriorText.text = warriorCost.ToString();
        farmText.text = wheatPerPeasant.ToString();
        expenses.text = wheatToWarrior.ToString();

        nextCountEnemy.text = nextRaid.ToString();

        UpdateText();
        raidTimer = raidMaxTime;
        audioSourse = GetComponent<AudioSource>();
        audioSourse.Play();
    }

    void Update()
    {
        raidTimer -= Time.deltaTime;
        RaidTimerImg.fillAmount = raidTimer / raidMaxTime;
        raidCreateTimeText.text = string.Format("{0:0}", raidTimer);

        if (raidTimer <= 0)
        {
            raidTimer = raidMaxTime;
            warriorCount -= nextRaid;
            deadWarriorsStat += nextRaid;
            experiesentWavesStat += 1;
            nextRaid += raidIncrease;
            nextCountEnemy.text = nextRaid.ToString();
        }

        if (PauseCheack.activeSelf)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }


        if (HarvestTimer.Tick)
        {
            if (wheatCount < wheatCountMax)
            {

                wheatCount += peasantCount * wheatPerPeasant;
            }
            harvestStat += peasantCount * wheatPerPeasant;
        }

        if (EatingTimer.Tick)
        {
            wheatCount -= warriorCount * wheatToWarrior;
        }

        if (persantTimer > 0)
        {
            persantTimer -= Time.deltaTime;
            PeasantTimerImg.fillAmount = persantTimer / peasantCreateTime;
            peasantCreateTimeText.text = string.Format("{0:0}", persantTimer);
        }
        else if (persantTimer > -1 && !peasantCreated)
        {
            if (peasantCount < peasantMaxCount)
            {
                audioSourse.PlayOneShot(persantHere);
                PeasantTimerImg.fillAmount = 1;
                peasantButton.interactable = true;
                peasantCreated = true;
                peasantCount += 1;
            }
            persantTimer = -2;
        }

        if (persantTimer2 > 0)
        {

            persantTimer2 -= Time.deltaTime;
            PeasantTimerImg2.fillAmount = persantTimer2 / peasantCreateTime2;
            peasantCreateTimeText2.text = string.Format("{0:0}", persantTimer2);
        }
        else if (persantTimer2 > -1 && !peasantCreated2)
        {
            if (peasantCount < peasantMaxCount)
            {
                audioSourse.PlayOneShot(persantHere);
                PeasantTimerImg2.fillAmount = 1;
                peasantButton2.interactable = true;
                peasantCreated2 = true;
                peasantCount += 1;
            }
            persantTimer2 = -2;
        }

        if (warriorTimer > 0)
        {
            warriorTimer -= Time.deltaTime;
            warriorButton.interactable = false;
            WarriorTimerImg.fillAmount = warriorTimer / warriorCreateTime;
            warriorCreateTimeText.text = string.Format("{0:0}", warriorTimer);

        }
        else if (warriorCount < warriorMaxCount && warriorTimer > -1)
        {
            warriorButton.interactable = true;
            if (warriorCount < warriorMaxCount)
            {
                audioSourse.PlayOneShot(warriorHere);
                WarriorTimerImg.fillAmount = 1;
                warriorCreated = true;
                warriorCount += 1;
            }
            warriorTimer = -2;
        }

        if (warriorTimer2 > 0)
        {
            warriorTimer2 -= Time.deltaTime;
            warriorButton2.interactable = false;
            WarriorTimerImg2.fillAmount = warriorTimer2 / warriorCreateTime2;
            warriorCreateTimeText2.text = string.Format("{0:0}", warriorTimer2);

        }
        else if (warriorCount < warriorMaxCount && warriorTimer2 > -1)
        {
            warriorButton2.interactable = true;
            if (warriorCount < warriorMaxCount)
            {
                audioSourse.PlayOneShot(warriorHere);
                WarriorTimerImg2.fillAmount = 1;
                warriorCreated2 = true;
                warriorCount += 1;
            }
            warriorTimer2 = -2;
        }

        UpdateText();

        if (warriorCount < 0 || wheatCount < -2)
        {
            Time.timeScale = 0;
            LosePanel.SetActive(true);
            loseGameScoreText.text = experiesentWavesStat + "\n" + "\n" + "\n" + deadWarriorsStat + "\n" + "\n" + "\n" + harvestStat;
            audioSourse.clip = null;
            audioSourse.PlayOneShot(loseSound, 0.05f);
            audioSourse.loop = false;
        }

        if (wheatCount > 750 && experiesentWavesStat >= 10)
        {
            Time.timeScale = 0;
            WinPanel.SetActive(true);
            winGameScoreText.text = experiesentWavesStat + "\n" + "\n" + "\n" + deadWarriorsStat + "\n" + "\n" + "\n" + harvestStat;
            audioSourse.clip = null;
            audioSourse.PlayOneShot(winSound, 0.1f);
            audioSourse.loop = false;
        }
        if (gameRestarted)
        {
            gameRestarted = false;
        }
    }

    public void PauseGameButton()
    {
        Time.timeScale = 0;
        CanvasPause.SetActive(true);
        PauseCheack.SetActive(false);
    }

    public void RestartGameButton()
    {
        gameRestarted = true;
        peasantCreated = false;
        peasantCreated2 = false;
        warriorCreated = false;
        warriorCreated2 = false;
        CanvasPause.SetActive(false);
        CanvasGame.SetActive(false);
        LosePanel.SetActive(false);
        WinPanel.SetActive(false);
        CanvasMenu.SetActive(true);
        PauseCheack.SetActive(false);

        raidTimer = raidMaxTime;
        raidMaxTime = 20f;
        raidIncrease = 2;
        nextRaid = 0;
        nextCountEnemy.text = nextRaid.ToString();
        peasantCount = 0;
        warriorCount = -2;
        wheatCount = 10;

        persantTimer = 0f; // сбросить таймер создания крестьянина до нуля
        persantTimer2 = 0f;
        warriorTimer = 0f;
        warriorTimer2 = 0f; // сбросить таймер создания воина до нуля

        warriorCreateTimeText2.text = string.Empty;
        warriorCreateTimeText.text = string.Empty;
        peasantCreateTimeText.text = string.Empty;
        peasantCreateTimeText2.text = string.Empty;

        peasantButton.interactable = true; // включить кнопку создания крестьянина
        warriorButton2.interactable = true; // включить кнопку создания воина

        audioSourse.clip = gameSound;
        audioSourse.Play();
    }

    public void CreatePeasant()
    {
        if (wheatCount >= peasantCost && peasantButton.interactable == true)
        {
            audioSourse.PlayOneShot(clickMusic);
            wheatCount -= peasantCost;
            persantTimer = peasantCreateTime;
            peasantButton.interactable = false;
            peasantCreated = false;
        }
    }
    public void CreatePeasant2()
    {
        if (wheatCount >= peasantCost && peasantButton2.interactable == true)
        {
            audioSourse.PlayOneShot(clickMusic);
            wheatCount -= peasantCost;
            persantTimer2 = peasantCreateTime2;
            peasantButton2.interactable = false;
            peasantCreated2 = false;
        }
    }

    public void CreateWarrior()
    {
        if (wheatCount >= warriorCost && warriorButton.interactable == true)
        {
            audioSourse.PlayOneShot(clickMusic);
            wheatCount -= warriorCost;
            warriorTimer = warriorCreateTime;
            warriorButton.interactable = false;
            warriorCreated = false;

        }
    }
    public void CreateWarrior2()
    {

        if (wheatCount >= warriorCost && warriorButton2.interactable == true)
        {
            audioSourse.PlayOneShot(clickMusic);
            wheatCount -= warriorCost;
            warriorTimer2 = warriorCreateTime2;
            warriorButton2.interactable = false;
            warriorCreated2 = false;

        }
    }
    private void UpdateText()
    {
        resourcesText.text = peasantCount + "\n" + "\n" + warriorCount + "\n" + "\n" + wheatCount;
    }
}
