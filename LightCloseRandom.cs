using Smod2;
using Smod2.Attributes;
using Smod2.Events;


namespace LightCloseRandom
{
    [PluginDetails(
        author = "Mr.River",
        name = "LightCloseRandom - 灯光关闭随机",
        description = "随机概率触发设施内部进入持续性【停电】状态，让玩家体验到不一样的Site，并加强灯光类道具的使用频率",
        version = "0.0.1"
    )]

    class LightCloseRandom : Plugin
    {
        public override void OnDisable()
        {
            this.Info("LightCloseRandom载入失败");
        }

        public override void OnEnable()
        {
            this.Info("LightCloseRandom载入成功");
        }

        public override void Register()
        {
            LightCloseRandomHandler eventhHander = new LightCloseRandomHandler(this);
            //this.AddConfig("Set_Light_Enable_Percent", 0.5,  true, "");
            this.AddEventHandlers(eventhHander, Priority.Normal);
        }
    }
}
