using System;
using System.Configuration;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace Microsoft.Bot.Sample.LuisBot
{
    // For more information about this template visit http://aka.ms/azurebots-csharp-luis
    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {
        public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["LuisAppId"], 
            ConfigurationManager.AppSettings["LuisAPIKey"], 
            domain: ConfigurationManager.AppSettings["LuisAPIHostName"])))
        {
        }

        [LuisIntent("None")]
        public async Task NoneIntent(IDialogContext context, LuisResult result)
        {
            await this.ShowLuisResult(context, result);
        }

        // Go to https://luis.ai and create a new intent, then train/publish your luis app.
        // Finally replace "Gretting" with the name of your newly created intent in the following handler
        [LuisIntent("SearchKnowledgeSession")]
        public async Task SearchKnowledgeSession(IDialogContext context, LuisResult result)
        {
            await this.ShowLuisResult(context, result);
        }

	    [LuisIntent("NextKnowledgeSession")]
	    public async Task NextKnowledgeSession(IDialogContext context, LuisResult result)
	    {
		    await this.ShowLuisResult(context, result);
	    }

	    [LuisIntent("ListKnowledgeSessions")]
	    public async Task ListKnowledgeSessions(IDialogContext context, LuisResult result)
	    {
		    await this.ShowLuisResult(context, result);
	    }

	    [LuisIntent("CreateKnowledgeSession")]
	    public async Task CreateKnowledgeSession(IDialogContext context, LuisResult result)
	    {
		    await this.ShowLuisResult(context, result);
	    }

		private async Task ShowLuisResult(IDialogContext context, LuisResult result) 
        {
            await context.PostAsync($"You have reached {result.Intents[0].Intent}. You said2222: {result.Query}");
            context.Wait(MessageReceived);
        }
    }
}