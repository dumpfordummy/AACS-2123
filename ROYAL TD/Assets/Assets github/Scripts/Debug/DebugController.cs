using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    bool showConsole;

    string input;

    public Player player;

    public static DebugCommand KACHING;

    public List<object> commandList;

    private void Awake()
    {
        KACHING = new DebugCommand("kaching", "Adds 1000 resources.", "kaching", () =>
        {
            player.woodResource.addWoodQty(1000);
            player.stoneResource.addStoneQty(1000);
        });

        commandList = new List<object>
        {
            KACHING
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            showConsole = !showConsole;
        }
    }

    private void OnGUI()
    {
        if (!showConsole) { return; }

        float y = 0f;

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);

        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);

        if (Event.current.keyCode == KeyCode.Return)
        {
            HandleInput();
            input = string.Empty;
            showConsole = false;
        }
    }

    private void HandleInput()
    {
        for (int i = 0; i < commandList.Count; i++)
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

            if (input.Contains(commandBase.commandId) && commandList[i] as DebugCommand != null)
            {
                (commandList[i] as DebugCommand).Invoke();
            }
        }
    }
}
