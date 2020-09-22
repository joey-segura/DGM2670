using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTextBehaviour : MonoBehaviour
{
        public IntData ammoValue;
        private Text text;

        private void Start()
        {
                text = GetComponent<Text>();
        }
        
        private void Update()
        {
                text.text = ammoValue.value.ToString();
        }
}
