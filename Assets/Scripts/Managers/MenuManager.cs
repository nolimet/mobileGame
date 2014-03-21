using UnityEngine;
using System.Collections;
namespace menu
{
    public class MenuManager : MonoBehaviour
    {

        public TriggerV2[] buttons;
        public MoveToV2[] Menus;
        public int currentMenuID;
        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < Menus.Length; i++)
            {
                Menus[i].menuID = i;
            }
            Menus[0].move = true;
        }

        // Update is called once per frame
        void Update()
        {
            int l = buttons.Length;
            int k = Menus.Length;
            for (int i = 0; i < l; i++)
            {
                if (buttons[i].State)
                {
                    buttons[i].State = false;
                    for (int j = 0; j < k; j++)
                    {
                        Menus[j].move = false;
                        if (Menus[j].menuID == buttons[i].OpenMenuID)
                        {
                            Menus[j].move = true;
                        }
                    }
                }
            }
        }
    }
}
