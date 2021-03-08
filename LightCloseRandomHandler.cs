using System;
using System.Collections.Generic;
using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;
using UnityEngine;

namespace LightCloseRandom
{
    class LightCloseRandomHandler : IEventHandlerRoundStart
    {
        public Plugin plugin;
        //是否启用
        private bool enable;
        //设置概率值
        private float setValue = 0.5f;
        //存储房间
        private List<Room> roomsList;

        public LightCloseRandomHandler(Plugin plugin)
        {         
            this.plugin = plugin;
        }

        public void OnRoundStart(RoundStartEvent ev)
        {
            //获取配置信息
            setValue = plugin.GetConfigFloat("Set_Light_Enable_Percent");

            //假设设置值为0f,后续操作不执行
            if (setValue == 0f) { return; }
            //获取房间
            roomsList = ev.Server.Map.GetRooms();

            //获取随机值作为启用插件的依据
            float i = UnityEngine.Random.Range(0, 1);
            //依据判断是否启用
            if (i <= setValue) { enable = true; }
            else { enable = false; }

            if (enable == false) { return; }
            else
            {               
                //map.OverchargeLights(900f, false);
                //遍历整个房间，并关闭灯光
                for (int n = 0; n < roomsList.Count; n++)
                {
                    roomsList[n].FlickerLights(20f);
                }
            }
        }
    }
}
