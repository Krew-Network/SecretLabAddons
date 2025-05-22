namespace Admin.Polls
{
    using System.Collections.Generic;
    using LabApi.Features.Wrappers;
    using MEC;
    
    public class Poll
    {
        public string PollName;
        public int[] Votes;
        public List<Player> AlreadyVoted;
        public CoroutineHandle ActiveCoro;
        private ushort _broadcastTime;
        private int _pollDuration;
        
        public Poll(string name)
        {
            _broadcastTime = Plugin.Instance.Config.PollTextDuration;
            _pollDuration = Plugin.Instance.Config.PollDuration;
            PollName = name;
            Votes = new int[2];
            AlreadyVoted = new List<Player>();
            BroadcastToAllPlayers(_broadcastTime, Plugin.Instance.Config.PollStartedBroadcast.Replace("{message}", PollName));
            EndPoll(_pollDuration);
        }

        private void EndPoll(int delay)
        {
            ActiveCoro = Timing.CallDelayed(delay, (() =>
            {
                BroadcastToAllPlayers(_broadcastTime, Plugin.Instance.Config.PollEndedBroadcast.Replace("{numYes}", Votes[0].ToString()).Replace("{numNo}", Votes[1].ToString()));
                Plugin.Instance.ActivePoll = null;
            }));
        }

        private void BroadcastToAllPlayers(ushort time, string message)
        {
            foreach (Player player in Player.List)
            {
                player.ClearBroadcasts();
                player.SendBroadcast(message, time);
            }
        }
    }
}