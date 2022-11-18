using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField]private RectTransform thisTransform;
    [SerializeField]private GameObject variableHolder;
    [SerializeField]private GameObject sceneSwapper;
    [SerializeField]private EnemyInfoHolder enemyInfoHeld;
    [SerializeField]private SceneSwapCombat sceneScript;
    [SerializeField]private float healthActual;
    [SerializeField]private float barLowerByRate;
    // Start is called before the first frame update
    void Start()
    {
        variableHolder = GameObject.Find("EnemyInfoHolder");
        enemyInfoHeld = variableHolder.GetComponent<EnemyInfoHolder>();
        sceneSwapper = GameObject.Find("SceneSwapManager");
        sceneScript = sceneSwapper.GetComponent<SceneSwapCombat>();
        healthActual = enemyInfoHeld.enemyHealth;
        barLowerByRate = thisTransform.localScale.x / healthActual;
    }

    // Update is called once per frame
    void Update()
    {
        thisTransform.localScale = new Vector3(healthActual * barLowerByRate, thisTransform.localScale.y, thisTransform.localScale.z); //change the size of the object according to health
        //this change is relative to whatever the health was when the combat scene was first loaded
        if (healthActual <= 0) 
        {//if im dead
            iDied(); //then that means i died
        }
    }

    public void lowerEnemyHealthBar(float damage)
    {
        healthActual -= damage;
    }

    private void iDied()
    {
        sceneScript.GoToOverworld(); //go to the overworld when the enemy dies
    }
}
