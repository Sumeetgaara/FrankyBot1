using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Luis.Models;

namespace InBytesBot
{
    [LuisModel("886bc401-4bf2-4ca4-b11f-213f8f94187f", "608d8548e09e4389a631b051c73fd0e5")]
    [Serializable]
    public class SimpleLUISDialog : LuisDialog<object>
    {


        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I have no idea what you are talking about.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Hie")]
        public async Task Hie(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hello!this is FrankyBot.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("OfferMenu")]
        public async Task OfferMenu(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Chicken franky,Paneer franky,Cheese franky,Jumbo Mix");
            context.Wait(MessageReceived);
        }

        enum variety { Veg , NonVeg };
        [LuisIntent("Recommend")]
        public async Task Recommend(IDialogContext context, LuisResult result)
        {
             var xs = (IEnumerable<variety>)Enum.GetValues(typeof(variety));

            PromptDialog.Choice(context, Suggest, xs, "Just tell me?");
            
        }

        private async Task Suggest(IDialogContext context, IAwaitable<variety> x )
        {

            var y = string.Empty;

            switch (await x)
            {
                
                case variety.Veg:
                     y = "Paneer Franky will be better choice";
                     break;
                case variety.NonVeg:
                     y = "Chicken Franky will be better choice";
                     break;
        }
       
        var text = $"I think  {y}";
        await context.PostAsync(text);
        context.Wait(MessageReceived);

       }

       




        [LuisIntent("SuperDuperHungry")]
        public async Task SuperDuperHungry(IDialogContext context, LuisResult result)
        {
            
            await context.PostAsync("You should try our Jumbo Mix then.");

            context.Wait(MessageReceived);
        }
         

  
    }
}