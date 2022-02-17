using Discord.Interactions;

namespace DiscordBot_Boilerplate.Interactions
{
    public class ModalModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("spawn-modal", "Shows a simple echo modal.")]
        public async Task SpawnModal()
        {
            var rnd = new Random();
            await RespondWithModalAsync<EchoModal>($"echo-modal:{rnd.Next().ToString()}").ConfigureAwait(false);
        }

        [ModalInteraction("echo-modal:*")]
        public async Task HandleEchoModal(string randomNumber, EchoModal modal)
        {
            await RespondAsync($"{modal.EchoText} and the random number: {randomNumber}").ConfigureAwait(false);
        }
    }

    public class EchoModal : IModal
    {
        public string Title => "DeModal";

        [InputLabel("The text to echo")]
        [ModalTextInput("echo-text")]
        public string EchoText { get; set; } = "";
    }
}
