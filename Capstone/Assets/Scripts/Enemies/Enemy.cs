using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    public float _health { get; private set; }
    public float _AR { get; private set; }
    public float _MR { get; private set; }

    [SerializeField] private EnemyDetection currTower;
    public EnemyDetection _currTower { get; set; }
    public int _minCoin { get; private set; }
    public int _maxCoin { get; private set; }

    [Header("Speed Variable")]

    private static float verySlowSpeed;
    [field:SerializeField]
    public float _verySlowSpeed { get; private set; }

    private static float slowSpeed;
    [field: SerializeField]
    public float _slowSpeed { get; private set; }

    private static float normalSpeed;
    [field: SerializeField]
    public float _normalSpeed { get; private set; }

    private static float fastSpeed;
    [field: SerializeField]
    public float _fastSpeed { get; private set; }

    private static float veryFastSpeed;
    [field: SerializeField]
    public float _veryFastSpeed { get; private set; }

    private Dictionary<SpeedType, float> speedDict = new Dictionary<SpeedType, float>();

    public float _speed { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        InitializeData();
    }

    public virtual void TakeDamage(float attackDamage, float magicDamage)
    {
        _health -= (attackDamage * (1-_AR) + magicDamage * (1-_MR));
    }

    public virtual void OnDeath()
    {
        if (_health <= 0)
        {
            currTower.RemoveEnemy(gameObject);
            Destroy(gameObject);
        }
    }

    public void DropCoin()
    {
        GameManager.Instance.coins += Random.Range(_minCoin, _maxCoin + 1);
    }

    public void InitializeData()
    {
        InitializeDictionary();

        _health = enemyData.health;
        _AR = enemyData.AR;
        _MR = enemyData.MR;
        _speed = speedDict[enemyData.speedType];
        _minCoin = enemyData.minCoin;
        _maxCoin = enemyData.maxCoin;
    }

    private void InitializeDictionary()
    {
        verySlowSpeed = _verySlowSpeed;
        slowSpeed = _slowSpeed;
        normalSpeed = _normalSpeed;
        fastSpeed = _fastSpeed;
        veryFastSpeed = _veryFastSpeed;

        speedDict.Add(SpeedType.VerySlow, verySlowSpeed);
        speedDict.Add(SpeedType.Slow, slowSpeed);
        speedDict.Add(SpeedType.Normal, normalSpeed);
        speedDict.Add(SpeedType.Fast, fastSpeed);
        speedDict.Add(SpeedType.Swift, veryFastSpeed);
    }
}
