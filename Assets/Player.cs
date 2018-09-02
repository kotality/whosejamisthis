using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    protected static Player _self;
    public static Player Self { get { return _self; } }

    protected GameObject _currentPossession;
    public GameObject StartingPossession;
    public GameObject CurrentPossession { get { return _currentPossession; } }
    public GameObject CrownPrefab;
    public State moveState;
    protected StatesManager _sm;
    protected CameraController _cc;
    protected AIManager _aim;
    protected UserInput _ih;

    // Use this for initialization
    void Start () {
		if(_self)
        {
            Debug.LogError("More than one \"Player\" in scene - this should not be the case.");
        }
        else
        {
            _self = this;
            _cc = gameObject.GetComponent<CameraController>();
            if (StartingPossession)
            {
                SetPossessionAs(StartingPossession);
            }
            _ih = gameObject.GetComponent<UserInput>();
        }
	}

    public virtual void SetPossessionAs(GameObject newCreature)
    {
        if(_currentPossession)
        {
            //Kill _currentPossession;
            Destroy(_currentPossession);
        }

        _currentPossession = newCreature;
        if(_cc)
        {
            _cc.target = newCreature.transform;
        }

        _aim = newCreature.GetComponent<AIManager>();
        if(_aim)
        {
            _aim.isControllingCreature = false;
            _aim.MyAgent.enabled = false;
            if(_aim.crownSpawnLocation && CrownPrefab)
            {
                Instantiate(CrownPrefab, _aim.crownSpawnLocation);
            }
        }
        _sm = newCreature.GetComponent<StatesManager>();
        if(_sm)
        {
            _sm.DoTransition(moveState);
            playerMoveState pms = moveState as playerMoveState;
            if(pms && _aim)
            {
                pms.speed = _aim.MyAgent.speed * 2;
            }
        }
    }

    private void Update()
    {
        if(_currentPossession && _ih && _aim)
        {
            if(_ih.Fire1)
            {
                _aim.myDamageEmitter.UseAttack(null);
            }
        }
    }

    public void GameOver()
    {
        StartCoroutine(RestartGame(5.0f));
    }

    protected IEnumerator RestartGame(float t)
    {
        float elapse = 0;
        while(elapse < t)
        {
            yield return null;
            elapse += Time.deltaTime;
        }

        Debug.Log("Game Ends");
        //SceneManager.LoadScene(0);
    }
}
