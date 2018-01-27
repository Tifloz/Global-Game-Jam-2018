using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogTrigger : TriggerPlayerAction {

        protected override void OnActionTrigger(GameObject player)
        {
            Debug.Log("Log: On action trigger.");
        }
}
