using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class DebugController : MonoBehaviour
{
    bool showConsole;
    bool showHelp;

    string input;

    public Player player;

    public static DebugCommand KACHING, BUDDHA, WANNACRY, GOLDENHAND, SKIPBUILDINGTIME, HELP;

    public List<object> commandList;

    private Vector2 scroll;

    private void Awake()
    {
        KACHING = new DebugCommand("kaching", "Adds 1000 resources.", "kaching", () =>
        {
            player.woodResource.addWoodQty(1000);
            player.stoneResource.addStoneQty(1000);
        });

        BUDDHA = new DebugCommand("buddha", "Immortal Townhall", "buddha", () =>
        {
            TowerHp.ToggleTownhallImmortal();
        });

        WANNACRY = new DebugCommand("wannacry", "Your townhall left 1 hp ._.", "wannacry", () =>
        {
            GameObject.Find("TownHall").GetComponent<TowerHp>().SetCurrentHp(1f);
            GameObject.Find("Town_Hall_HP").GetComponent<TowerHpBar>().setHealth(1);
        });

        GOLDENHAND = new DebugCommand("goldenhand", "1 Hit Kill", "goldenhand", () =>
        {
            player.GetComponentInChildren<Weapon>().ToggleOneHitKill();
        });

        SKIPBUILDINGTIME = new DebugCommand("skip_buildingtime", "Skip current building time", "skip_buildingtime", () =>
        {
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().SkipCurrentBuildingTime();
        });

        HELP = new DebugCommand("help", "Shows list of commands", "help", () =>
        {
            showHelp = true;
        });


        commandList = new List<object>
        {
            KACHING, BUDDHA, WANNACRY, GOLDENHAND, SKIPBUILDINGTIME, HELP
        };

        showHelp = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            input = string.Empty;
            ToggleShowConsole();
        }
    }

    private void OnGUI()
    {
        if (!showConsole) { return; }

        float y = 0f;

        if (showHelp)
        {
            GUI.Box(new Rect(0, y, Screen.width, 100), "");

            Rect viewport = new Rect(0, 0, Screen.width - 30, 20 * commandList.Count);

            scroll = GUI.BeginScrollView(new Rect(0, y + 5f, Screen.width, 90), scroll, viewport);

            for (int i = 0; i < commandList.Count; i++)
            {
                DebugCommandBase command = commandList[i] as DebugCommand;

                string label = $"{command.commandFormat} - {command.commandDescription}";

                Rect labelRect = new Rect(5, 20 * i, viewport.width - 100, 20);

                GUI.Label(labelRect, label);
            }

            GUI.EndScrollView();

            y += 100;
        }

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);

        GUI.SetNextControlName("input");
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input) ?? string.Empty;

        GUI.FocusControl("input");

        if (input.Contains("`"))
            ToggleShowConsole();

        if (Event.current.keyCode == KeyCode.Return)
        {
            if (!input.Equals("help") && commandList.Select(c => ((DebugCommandBase)c).commandId).ToList().Contains(input))
            {
                showHelp = false;
                ToggleShowConsole();
            }
            HandleInput();
            input = string.Empty;
        }
    }

    private void ToggleShowConsole()
    {
        showConsole = !showConsole;
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
