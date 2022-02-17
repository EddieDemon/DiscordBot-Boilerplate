using Discord;
using Discord.Interactions;

namespace DiscordBot_Boilerplate.Interactions
{
    public class ButtonModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("spawn-button", "Shows a simple button.")]
        public async Task SpawnButton()
        {
            var components = new ComponentBuilder()
                .WithButton("Click me!", "btn:click")
                .WithButton("Don't click me!", "btn:dontclick", ButtonStyle.Danger)
                .WithButton("I'm not even working...", "btn:unwn", ButtonStyle.Secondary, disabled:true)
                .Build();
            await RespondAsync("Press any of the buttons...", components: components).ConfigureAwait(false);
        }

        [ComponentInteraction("btn:*")]
        public async Task ButtonClicked(string whichButton)
        {
            var response = whichButton switch
            {
                "click" => "Yay, you clicked me!",
                "dontclick" => "It said, DO NOT CLICK!!!",
                "what" => "Hey, you called me from another module",
                _ => "Realy don't know what button this is."
            };
            await RespondAsync(response).ConfigureAwait(false);
        }
    }
}
