namespace Admin.Polls.Commands
{
    using System;
    using CommandSystem;
    using LabApi.Features.Wrappers;
    
    [CommandHandler(typeof (RemoteAdminCommandHandler))]
    [CommandHandler(typeof (ClientCommandHandler))]
    public class VoteCommand : ICommand
    {
        private static Poll ActivePoll => Plugin.Instance.ActivePoll;

        public string Command { get; } = "vote";

        public string[] Aliases { get; } = new string[0];

        public string Description { get; } = "Creates a poll which server users can vote in.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender is CommandSender commandSender ? commandSender.SenderId : (string) null);
            if (ActivePoll == null)
            {
                response = "There is no currently active poll!";
                return false;
            }
            if (ActivePoll.AlreadyVoted.Contains(player))
            {
                response = "You've already voted on this poll!";
                return false;
            }
            switch (CollectionExtensions.At<string>(arguments, 0))
            {
                case "yes":
                case "y":
                    ++ActivePoll.Votes[0];
                    ActivePoll.AlreadyVoted.Add(player);
                    response = "Voted yes!";
                    return true;
                case "no":
                case "n":
                    ++ActivePoll.Votes[1];
                    ActivePoll.AlreadyVoted.Add(player);
                    response = "Voted no!";
                    return true;
                default:
                    response = "Invalid option! Choose \"yes\" or \"no\"!";
                    return false;
            }
        }
    }
}