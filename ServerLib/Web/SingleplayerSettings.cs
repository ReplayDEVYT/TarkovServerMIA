﻿using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Web
{
    public class SingleplayerSettings
    {

        [HTTP("GET", "/singleplayer/settings/bot/maxCap")]
        public static bool SSBotMaxCap(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var resp = ResponseControl.CompressRsp("20");
            return Utils.SendUnityResponse(session, resp);
        }

        [HTTP("GET", "/singleplayer/settings/raid/menu")]
        public static bool SSRaidMenu(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var defaultraid = JsonConvert.SerializeObject(ConfigController.Configs.Gameplay.Raid.DefaultRaidSettings);
            var resp = ResponseControl.CompressRsp(ResponseControl.NoBody(defaultraid));
            return Utils.SendUnityResponse(session, resp);
        }

        [HTTP("GET", "/singleplayer/settings/bot/difficulty/{botname}/{difficulty}")]
        public static bool SSBotDiff(HttpRequest request, HttpsBackendSession session)
        {
            string botname = session.HttpParam["botname"];
            string difficulty = session.HttpParam["difficulty"];
            Utils.PrintRequest(request, session);
            var difff = BotController.GetBotDifficulty(botname, difficulty);
            var resp = ResponseControl.CompressRsp(ResponseControl.NoBody(difff));
            return Utils.SendUnityResponse(session, resp);
        }

        [HTTP("GET", "/singleplayer/airdrop/config")]
        public static bool SSAirdropConfig(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var defaultraid = JsonConvert.SerializeObject(ConfigController.Configs.Gameplay.Raid.AirdropSettings);
            var resp = ResponseControl.CompressRsp(ResponseControl.NoBody(defaultraid));
            return Utils.SendUnityResponse(session, resp);
        }
    }
}
