using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.IO;
using System.Web;
using System.Collections.Generic;

namespace BotHeroCard.Dialogs
{
    [Serializable]
    public class HeroCardDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceivedAsync);
            return Task.CompletedTask;
        }
        public async virtual Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            var welcomeMessage = context.MakeMessage();
            welcomeMessage.Text = "Welcome to bot Hero Card Demo";

            await context.PostAsync(welcomeMessage);
     
           await this.DispalyHeroCard(context);
        }

        public async Task DispalyHeroCard(IDialogContext context)
        {

            var replyMessage = context.MakeMessage();
            Attachment attachment = GetHeroCard(); ;
            replyMessage.Attachments = new List<Attachment> { attachment };
            await context.PostAsync(replyMessage);
        }
        private static Attachment GetHeroCard()
        {
            var heroCard = new HeroCard
            {
                // title of the card
                Title = "Suthahar Jegatheesan",
                //subtitle of the card
                Subtitle = "Microsoft certified solution developer",
                // navigate to page , while tab on card
                Tap = new CardAction(ActionTypes.OpenUrl, "Learn More", value: "http://www.devenvexe.com"),
                //Detail Text
                Text = "Suthahar J is a Technical Lead and C# Corner MVP. He has extensive 10+ years of experience working on different technologies, mostly in Microsoft space. His focus areas are  Xamarin Cross Mobile Development ,UWP, SharePoint, Azure,Windows Mobile , Web , AI and Architecture. He writes about technology at his popular blog http://devenvexe.com",
                // list of  Large Image
                Images = new List<CardImage> { new CardImage("http://csharpcorner.mindcrackerinc.netdna-cdn.com/UploadFile/AuthorImage/jssuthahar20170821011237.jpg") },
                // list of buttons 
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Learn More", value: "http://www.devenvexe.com") , new CardAction(ActionTypes.OpenUrl, "C# Corner", value: "http://www.c-sharpcorner.com/members/suthahar-j"), new CardAction(ActionTypes.OpenUrl, "MSDN", value: "https://social.msdn.microsoft.com/profile/j%20suthahar/") }
            };

            return heroCard.ToAttachment();
        }
    }
}