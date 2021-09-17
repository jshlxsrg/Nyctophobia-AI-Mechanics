using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.AI;

namespace JU
{
    public class VoiceControl : MonoBehaviour
    {
        EnemyPatrol enemyPatrol;
        EnemyWander enemyWander;
        NavMeshAgent navMeshAgent;

        Transform target;    
        public float speed = 12f;



        [Header("Voice Recognition Settings")]
        private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
        private KeywordRecognizer keywordRecognizer;

        private void Awake()
        {
            GameObject cylinder = GameObject.FindGameObjectWithTag("Player");
            target = cylinder.transform;
            transform.LookAt(target);

            navMeshAgent = GetComponent<NavMeshAgent>();
            enemyWander = GetComponent<EnemyWander>();    
        }

        private void Start()
        {
            enemyPatrol = GetComponent<EnemyPatrol>();
            keywordActions.Add("target", GoToTarget);

            keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
            keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
            keywordRecognizer.Start();

        }

        void Update()
        {
            float distance = Vector3.Distance(navMeshAgent.destination, transform.position);

            if (distance <= 1f)
            {
                enemyWander.Wander();


            }



        }

        private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
        {
            Debug.Log("Keyword " + args.text);
            keywordActions[args.text].Invoke();
        }

        private void GoToTarget()
        {
            navMeshAgent.destination = target.position;
        }
    }
}


/*
  if distance <= 1 then collider detects nothing, wander then patrol
  else if collider detects player then chase
       if distance from target < 10 then collider detects nothing, back to wander then patrol.
 */