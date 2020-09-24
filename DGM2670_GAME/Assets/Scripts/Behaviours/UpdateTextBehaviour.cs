using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTextBehaviour : MonoBehaviour
{
        public IntData dataValue;
        private Text text;

        private void Start()
        {
                text = GetComponent<Text>();
        }
        
        private void Update()
        {
                text.text = dataValue.value.ToString();
        }
}
