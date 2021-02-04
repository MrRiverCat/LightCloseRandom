using System;
using System.Collections.Generic;
using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

namespace LightCloseRandom
{
    class LightCloseRandomHandler : IEventHandlerRoundStart
    {
        public Plugin plugin;
        
        private Random random;
        private bool enable;

        private float setValue;
        private List<Room> roomsList;
        private Map map;

        public LightCloseRandomHandler(Plugin plugin)
        {         
            this.plugin = plugin;
        }

        public void OnRoundStart(RoundStartEvent ev)
        {
            //获取配置信息
            setValue = plugin.GetConfigFloat("Set_Light_Enable_Percent");
            if (setValue == 0f) { setValue = 0.5f; }

            roomsList = new List<Room>();
            roomsList = ev.Server.Map.GetRooms();

            map = ev.Server.Map;

            //获取随机值作为启用插件的依据
            float i = random.Next(0, 1);
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
