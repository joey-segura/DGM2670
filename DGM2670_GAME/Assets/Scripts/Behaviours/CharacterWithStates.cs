using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterWithStates : MonoBehaviour
{
    private CharacterController controller;
    public enum characterStates
    {
        StandardWalk,
        WallCrawl
    }
    
    public characterStates currentCharacterState;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
    private void Update()
    {
        switch (currentCharacterState)
        {
            case characterStates.StandardWalk:
                print("Standard Walk");
                break;
            case characterStates.WallCrawl:
                print("Wall Crawl");
                break;
        }
    }
}