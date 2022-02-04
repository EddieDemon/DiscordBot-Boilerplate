using Discord.WebSocket;
using Discord.Interactions;

namespace DiscordBot_Boilerplate.Interactions
{
    public class ButtonModule : InteractionModuleBase<ShardedInteractionContext<SocketMessageComponent>>
    {
        [ComponentInteraction("btn:*")]
        public async Task ButtonClicked(string whichButton)
        {
            var response = whichButton switch
            {
                "click" => "Yay, you clicked me!",
                "dontclick" => "It said, DO NOT CLICK!!!",
                _ => "Realy don't know what button this is."
            };
            await RespondAsync(response).ConfigureAwait(false);
        }
    }
}
