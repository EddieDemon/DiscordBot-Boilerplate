using Discord;
using Discord.Interactions;

namespace DiscordBot_Boilerplate.Interactions
{
    public class SelectMenuModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("spawn-selectmenu", "Shows a simple button.")]
        public async Task SpawnButton()
        {
            var selectMenuBuilder= new SelectMenuBuilder()
                .WithCustomId("select")
                .WithMinValues(1)
                .WithMaxValues(2)
                .WithPlaceholder("Placeholder text")
                .AddOption("Option 1", "1", "This is option 1", isDefault: true)
                .AddOption("Option 2", "2", "This is option 2")
                .AddOption("Option 3", "3", "This is option 3");

            var components = new ComponentBuilder()
                .WithSelectMenu(selectMenuBuilder)
                .WithButton("You can call functions in other modules as well.", "btn:what")
                .Build();
            await RespondAsync("Press any of the buttons...", components: components).ConfigureAwait(false);
        }

        [ComponentInteraction("select")]
        public async Task ButtonClicked(string[] selectedValues)
        {
            await RespondAsync($"You've selected {string.Join(", ", selectedValues)}").ConfigureAwait(false);
        }
    }
}
