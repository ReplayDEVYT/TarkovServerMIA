﻿using EFT;
using Newtonsoft.Json;
using ServerLib.Json.Classes;
using ServerLib.Json.Classes.Websocket;
using ServerLib.Utilities;
using ServerLib.Web;
using static ServerLib.Json.Classes.ProfileStatus;

namespace ServerLib.Controllers
{
    public class MatchController
    {
        static MatchController()
        {
            Matches = new();
            Debug.PrintInfo("Initialization Done!", "MatchController");
        }

        public static Dictionary<string, MatchData> Matches;

        public struct MatchData
        {
            public string MatchId;
            public string CreatorId;
            public List<UserStruct> Users;
            public string Ip;
            public int Port;
            public string Location;
            public string Sid;
            public ERaidMode RaidMode;
            public bool IsStarted;
            public struct UserStruct
            {
                public string profileid;
                public string profileToken;

            }
        }
        public static MatchData? GetMatch(string ProfileId)
        {
            foreach (var item in Matches.Values)
            {
                if (item.CreatorId == ProfileId)
                    return item;
            }
            return null;
        }


        public static string GenerateMatchId(string ProfileId)
        {
            try
            {
                var match = GetMatch(ProfileId);
                if (match.HasValue)
                {
                    return match.Value.MatchId;
                }
                else
                {
                    var id = Utils.CreateNewID();
                    Matches.Add(id, new() { CreatorId = ProfileId, MatchId = id, Users = new() { new() { profileid = ProfileId } } });
                    return id;
                }
            }
            catch (Exception ex)
            {
                Debug.PrintError(ex.ToString());
            }
            return string.Empty;

        }

        public static void CheckStatus(string ProfileId, GetGroupStatus groupStatus)
        {
            try
            {
                var match = Matches[GenerateMatchId(ProfileId)];
                match.Location = groupStatus.location;
                match.RaidMode = groupStatus.raidMode;
            }
            catch (Exception ex)
            {
                Debug.PrintError(ex.ToString());
            }

        }

        public static void SendStart(string groupId, string Ip, int Port)
        {
            var ws = NewWebSocket.GetServer();
            if (ws != null)
            {
                var sid = $"{Ip}_{Port}-Match-{Matches.Count}";
                var match = Matches[groupId];
                match.Ip = Ip;
                match.Port = Port;
                match.Sid = sid;
                for (int i = 0; i < match.Users.Count; i++)
                {
                    var user = match.Users[i];
                    UserConfirmed confirmed = new();
                    confirmed.profileid = user.profileid;
                    confirmed.profileToken = Utils.CreateNewID();
                    user.profileToken = confirmed.profileToken;
                    confirmed.status = "Busy";
                    confirmed.ip = Ip;
                    confirmed.port = Port;
                    confirmed.sid = sid;
                    confirmed.version = "live";
                    confirmed.location = match.Location;
                    confirmed.mode = "deathmatch";
                    confirmed.shortId = "VD0ABA";
                    ws.MulticastText(JsonConvert.SerializeObject(confirmed));
                }
                match.IsStarted = true;
            }
        }
    }
}
