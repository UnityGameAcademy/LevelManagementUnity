using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class CreditsScreen : Menu<CreditsScreen>
    {
        // closes the top menu and goes back one Menu in the stack
        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }
    }
}